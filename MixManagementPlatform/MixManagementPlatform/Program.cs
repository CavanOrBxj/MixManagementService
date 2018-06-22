using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    static class Program
    {
        public const string RegeditApplicationKey = "MixManagementPlatform";
        public const string RegeditDirKey = "StartApp";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var pros = Process.GetProcessesByName("MixManagementPlatform");
            if (pros.Length > 1)
            {
                MessageBox.Show("软件已启动，请勿重复打开！", "警告");
                return;
            }
            Environment.CurrentDirectory = Application.StartupPath;
            string fileName = @"Log\Mix" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log";
            if (!Directory.Exists(@"Log")) Directory.CreateDirectory(@"Log");
            TextWriterTraceListener mixListener = new TextWriterTraceListener(fileName);
            mixListener.Name = "MixListener";
            mixListener.IndentSize = 0;
            Trace.AutoFlush = true;
            Trace.IndentSize = 0;
            Trace.Listeners.Add(mixListener);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            //Application.Run(new Form1());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MixLogHelper.Error("Program", "未捕获异常", ((Exception)e.ExceptionObject).StackTrace);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MixLogHelper.Error("Program", "未捕获线程异常", e.Exception.StackTrace);
        }

        /// <summary>
        /// 获取CurrentUser注册表
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetRegeditData(string dirName, string keyName)
        {
            object value = 0;
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            {
                value = regKey.GetValue(keyName, 0);
            }
            return value;
        }

        /// <summary>
        /// 写入CurrentUser注册表
        /// </summary>
        /// <param name="dirName">数据对应注册表路径</param>
        /// <param name="keyName">子键名</param>
        /// <param name="keyValue">写入keyName的键值</param>
        public static void SetRegeditData(string dirName, string keyName, object keyValue)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(RegeditApplicationKey).CreateSubKey(dirName))
            {
                regKey.SetValue(keyName, keyValue);
            }
            MixLogHelper.Info("Program", string.Format("注册表写入: SOFTWARE\\" + RegeditApplicationKey + "\\" + dirName + "({0})", keyValue));
        }
    }
}
