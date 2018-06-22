using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace MixManagementService
{
    public class Interop
    {
        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        public static void ShowMessageBox(string message, string title)
        {
            int resp = 0;
            WTSSendMessage(
                WTS_CURRENT_SERVER_HANDLE,
                WTSGetActiveConsoleSessionId(),
                title, title.Length,
                message, message.Length,
                0, 0, out resp, false);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WTSGetActiveConsoleSessionId();

        [DllImport("wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSSendMessage(
            IntPtr hServer,
            int SessionId,
            String pTitle,
            int TitleLength,
            String pMessage,
            int MessageLength,
            int Style,
            int Timeout,
            out int pResponse,
            bool bWait);

        public static void CreateProcess(string app, string path,string arg,ref PROCESS_INFORMATION pi,ref bool opresult)
        {
            bool result;
            IntPtr hToken = WindowsIdentity.GetCurrent().Token;
          
            IntPtr hDupedToken = IntPtr.Zero;

          //  PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);

            STARTUPINFO si = new STARTUPINFO();
            si.cb = Marshal.SizeOf(si);
            int dwSessionID = WTSGetActiveConsoleSessionId();//远程桌面登陆的情况 获取SessionId 要进行选择

          //  ToolManagementService.logInfo.Info(dwSessionID.ToString());
            ShowMessageBox(dwSessionID.ToString(), "Service Message");
            result = WTSQueryUserToken(dwSessionID, out hToken);//获得当前Session的用户令牌

            if (!result)
            {
                int error = Marshal.GetLastWin32Error();
                ShowMessageBox("WTSQueryUserToken failed,ErrorCode" + error.ToString() + "SessionID:"+dwSessionID.ToString(), "Service Message");
            }
            //复制令牌
            result = DuplicateTokenEx(
                  hToken,
                  GENERIC_ALL_ACCESS,
                  ref sa,
                  (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                  (int)TOKEN_TYPE.TokenPrimary,
                  ref hDupedToken
               );

            if (!result)
            {
                ShowMessageBox("DuplicateTokenEx failed", "AlertService Message");
            }

            IntPtr lpEnvironment = IntPtr.Zero;
            int dwCreationFlags = NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE | CREATE_UNICODE_ENVIRONMENT;
            //创建用户Session环境
            result = CreateEnvironmentBlock(out lpEnvironment, hDupedToken, false);

            if (!result)
            {
                ShowMessageBox("CreateEnvironmentBlock failed", "AlertService Message");
            }
            // 在复制的用户Session下执行应用程序，创建进程。   模拟用户的情况下创建
            opresult = CreateProcessAsUser(
            hDupedToken,
            path + app,
            " "+arg,// String.Empty,
            ref sa, ref sa,
            false, dwCreationFlags, lpEnvironment,//IntPtr.Zero,
            path, ref si, ref pi);


            // 清理工作
            if (!opresult)
            {
                int error = Marshal.GetLastWin32Error();
                string message = String.Format("CreateProcessAsUser Error: {0}", error);
                ShowMessageBox(message, "AlertService Message");
            }

            if (pi.hProcess != IntPtr.Zero)
                CloseHandle(pi.hProcess);
            if (pi.hThread != IntPtr.Zero)
                CloseHandle(pi.hThread);
            if (hDupedToken != IntPtr.Zero)
                CloseHandle(hDupedToken);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 dwProcessID;
            public Int32 dwThreadID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public Int32 Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }

        public const int GENERIC_ALL_ACCESS = 0x10000000;

         #region Constants
  
          //public const int TOKEN_DUPLICATE = 0x0002;
          public const uint MAXIMUM_ALLOWED = 0x2000000;
          public const int CREATE_NEW_CONSOLE = 0x00000010;
          public const int CREATE_UNICODE_ENVIRONMENT = 0x00000400;
  
          public const int NORMAL_PRIORITY_CLASS = 0x20;
          //public const int IDLE_PRIORITY_CLASS = 0x40;        
          //public const int HIGH_PRIORITY_CLASS = 0x80;
          //public const int REALTIME_PRIORITY_CLASS = 0x100;
  
          #endregion



        [DllImport("kernel32.dll", SetLastError = true,
            CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", SetLastError = true,
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CreateProcessAsUser(
            IntPtr hToken,
            string lpApplicationName,
            string lpCommandLine,
            ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes,
            bool bInheritHandle,
            Int32 dwCreationFlags,
            IntPtr lpEnvrionment,
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            ref PROCESS_INFORMATION lpProcessInformation);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool DuplicateTokenEx(
            IntPtr hExistingToken,
            Int32 dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpThreadAttributes,
            Int32 ImpersonationLevel,
            Int32 dwTokenType,
            ref IntPtr phNewToken);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSQueryUserToken(
            Int32 sessionId,
            out IntPtr Token);

        [DllImport("userenv.dll", SetLastError = true)]
        static extern bool CreateEnvironmentBlock(
            out IntPtr lpEnvironment,
            IntPtr hToken,
            bool bInherit);

    }
}
