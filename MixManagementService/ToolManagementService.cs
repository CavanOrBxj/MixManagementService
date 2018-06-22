using ControlAstro.Enums.ControlEnums;
using ControlAstro.Utils;
using Dos.Common;
using MixManagementService.EntityModule;
using MixManagementService.SqlManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MixManagementService
{
    public partial class ToolManagementService : ServiceBase
    {

        private readonly string ClassName;

        private SqlServerLogic sqlServer;

        private EventWaitHandle _waitHandle = new AutoResetEvent(false);

        private BindingCollection<TModule> moduleList;

        private Dictionary<int, int> processDic; //模块Id对应进程id

        private int counter = 0;


        private bool autoCheckModuleStateFlag = true;

       public static log4net.ILog logInfo;
        public ToolManagementService()
        {
            InitializeComponent();
            ClassName = GetType().Name;
            processDic = new Dictionary<int, int>();
            moduleList = new BindingCollection<TModule>();

            var appSettings = System.Configuration.ConfigurationManager.AppSettings;

            string sql = "select * from SQLServerInfo";
            DataTable data = DB.Context.FromSql(sql).ToDataTable();
            if (data.Rows.Count>0)
            {
                SingletonInfo.GetInstance().SqlServerIP = data.Rows[0][1].ToString();
                SingletonInfo.GetInstance().SqlServerUser = data.Rows[0][2].ToString();
                SingletonInfo.GetInstance().SqlServerPWD = data.Rows[0][3].ToString();
            
            }

        }

        public void StartService()
        {
            logInfo = log4net.LogManager.GetLogger("loginfo");
            logInfo.Info("融合平台工具管理服务启动");
            CheckModuleConfig();
            logInfo.Info("检查配置信息完成");
            LoadDataGridView();
            logInfo.Info("读取配置文件并加载完成");
         //   UserLoginStatus();  测试注释 
            logInfo.Info("系统当前登录状态判断完成");  
            AutoStartModule();
            logInfo.Info("自动启动模块完成");  
           // AutoCheckModuleState();
        }

        protected override void OnStart(string[] args)
        {
           // new Thread(Run).Start(); //调试用

            StartService();
        }

        protected override void OnStop()
        {
            stopp();
        }

        private void Run()
        {
            Thread.Sleep(10000);
            StartService();
        }
            

        private void stopp()
        {
            StopAllModule();
          
        }


        /// <summary>
        /// 检查模块配置信息是否存在
        /// </summary>
        private void CheckModuleConfig()
        {
            try
            {
                if (!TModuleLogic.IsTableExist("moduleinfo"))
                {
                    MixLogHelper.Info(ClassName, "创建数据表moduleinfo");
                    DB.Context.FromSql("CREATE TABLE 'moduleinfo' (" +
                    "'id'  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "'name'  TEXT NOT NULL," +
                    "'path'  TEXT NOT NULL," +
                    "'autostart'  INTEGER NOT NULL," +
                    "'delay'  INTEGER NOT NULL," +
                    "'state'  INTEGER NOT NULL," +
                    "'startindex'  INTEGER NOT NULL," +
                    "'arguments'  TEXT," +
                    "'temtype'  INTEGER NOT NULL" +
                    ")").ExecuteNonQuery();
                    MixLogHelper.Info(ClassName, "moduleinfo创建成功");
                }
                else if (!TModuleLogic.VerifyField().IsSuccess)
                {
                    DB.Context.FromSql("DROP TABLE moduleinfo").ExecuteNonQuery();
                    DB.Context.FromSql("CREATE TABLE 'moduleinfo' (" +
                    "'id'  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                    "'name'  TEXT NOT NULL," +
                    "'path'  TEXT NOT NULL," +
                    "'autostart'  INTEGER NOT NULL," +
                    "'delay'  INTEGER NOT NULL," +
                    "'state'  INTEGER NOT NULL," +
                    "'startindex'  INTEGER NOT NULL," +
                    "'arguments'  TEXT," +
                    "'temtype'  INTEGER NOT NULL" +
                    ")").ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MixLogHelper.Error(ClassName, "创建数据表异常", e.StackTrace);
            }

            try
            {
                if (Convert.ToInt32(ConfigFunc.GetRegeditData_LocalMachine(ConfigFunc.RegeditDirKey, "FirstStart")) == 0)
                {
                    //开始初始化模块配置和数据库信息
                    bool success = InitModuleDatabase();
                    if (success)
                    {
                         ConfigFunc.SetRegeditData_LocalMachine(ConfigFunc.RegeditDirKey, "FirstStart", 1);
                    }
                       

                }
            }
            catch (Exception e)
            {
                MixLogHelper.Error(ClassName, "数据库初始化异常", e.StackTrace);
            }
            finally
            {

            }
        }
        private bool InitModuleDatabase()
        {
            if (sqlServer == null)
            {
                sqlServer = new SqlServerLogic(string.Format("Server={0};uid={1};pwd={2};", SingletonInfo.GetInstance().SqlServerIP, SingletonInfo.GetInstance().SqlServerUser, SingletonInfo.GetInstance().SqlServerPWD));
            }
            int createData = sqlServer.FromSql("CREATE DATABASE volador");
            MixLogHelper.Info(ClassName, createData != -100 ? "volador数据库创建成功" : "volador数据库创建失败");


            string pp = AppDomain.CurrentDomain.BaseDirectory;
            bool success = sqlServer.ExecuteCommand(sqlServer.GetSqlFile(Path.Combine(pp, "sqlinit"), "volador"));
            MixLogHelper.Info(ClassName, success ? "volador表创建成功" : "volador表创建失败");

            return success;
        }



        /// <summary>
        /// 读取配置文件并加载
        /// </summary>
        private void LoadDataGridView()
        {
            try
            {
                moduleList = new BindingCollection<TModule>(DB.Context.From<TModule>().OrderBy(TModule._.startindex.Desc).ToList());

                if (moduleList.Count<1)
                {
                    logInfo.Info("读取sqlite数据失败");
                }
            }
            catch (Exception e)
            {
                MixLogHelper.Error(ClassName, "数据配置加载异常", e.StackTrace);
            }
        }

        /// <summary>
        /// 系统当前登录状态判断
        /// </summary>
        private void UserLoginStatus()
        {
            logInfo.Info("系统登录状态判断");
            Process[] processList = Process.GetProcessesByName("explorer");
            if (processList.Length > 0)
            {
                SingletonInfo.GetInstance().LoginFlag = true;
                SingletonInfo.GetInstance().IsFirstLogin = false;
                logInfo.Info("系统此时已被登录");
            }
            else
            {
                SingletonInfo.GetInstance().LoginFlag = false;
                SingletonInfo.GetInstance().IsFirstLogin = true;
                logInfo.Info("系统此时未被登录");
            }

        
        }
        private void AutoStartModule()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    for (int i = 0; i < moduleList.Count; i++)
                    {
                        if (moduleList[i].autostart != 0)
                        {
                            Thread.Sleep(moduleList[i].delay * 500);
                            //  if (Disposing || IsDisposed) return;
                            if (File.Exists(moduleList[i].path))
                            {
                                bool isSuccess = StartModule(moduleList[i]);
                                if (isSuccess)
                                {
                                    moduleList[i].state = (int)LightState.On;
                                }
                                else
                                {
                                    MixLogHelper.Error(ClassName, "模块自启失败", "模块自启失败，请尝试手动启动");
                                    return;
                                }
                            }
                            else
                            {
                                MixLogHelper.Error(ClassName, "模块不存在", "模块不存在，请检查模块路径");
                            }
                        }
                    }

             //       var taskreceive = Task.Factory.StartNew(() =>
             //       {
             //           CheckLoginUser();
             //       }
             //);  测试注释  陈良提出  不需要用户登录的时候显示 工具软件界面（即：不需要两种启动进程的方法，这样可以避免中间去关闭已经启动的进程）
                }
                catch
                {
                    return;
                }
                finally
                {
                    _waitHandle.Set();
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }


        private void CheckLoginUser()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Process[] processList = Process.GetProcessesByName("explorer");
                if (processList.Length > 0)
                {
                    //有用户登录  正常情况下  继续执行  但是如果是第一次登录则要关闭当前开启的进程 然后重启
                    if (processList.Length == 1 && SingletonInfo.GetInstance().IsFirstLogin)
                    {
                        logInfo.Info("系统第一次被登录");
                        SingletonInfo.GetInstance().IsFirstLogin = false;
                        SingletonInfo.GetInstance().LoginFlag = true;
                        StopAllModule();
                        Thread.Sleep(1000);
                        AutoStartModule();
                        break;
                    }
                }
                else
                {
                    logInfo.Info("系统仍未被登录");
                
                }
            }
        }

        private bool StartModule(TModule module)
        {
            bool isSuccess = false;
            try
            {
                //启动进程
                int processId = 0;
                string arg = string.Empty;
                if (Path.GetFileNameWithoutExtension(module.path).Equals("cmd"))
                {
                    if (!string.IsNullOrWhiteSpace(module.arguments) && !string.IsNullOrEmpty(module.arguments))
                        arg += "/c" + module.arguments + "&pause";
                }
                else
                {
                    arg += module.arguments;
                }
                bool isOpen = false;
                MixManagementService.CreateProcessAsUserWrapper.PROCESS_INFORMATION processInfo = new CreateProcessAsUserWrapper.PROCESS_INFORMATION();
                Process process = new Process();


                #region 测试注释 20180621 两种启动进程方式
                //if (SingletonInfo.GetInstance().LoginFlag)
                //{
                //    if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(module.path)).ToList().Count > 0)
                //    {
                //        //已经开启
                //    }
                //    else
                //    {
                //        //如果没开启，则打开某软件(cmd) 文件名称、文件路径
                //      //  Interop.CreateProcess(Path.GetFileName(module.path), Path.GetDirectoryName(module.path) + "\\", arg, ref processInfo, ref isOpen);

                //        CreateProcessAsUserWrapper.LaunchChildProcess(module.path,arg,ref processInfo, ref isOpen);
                //    //    process = Process.GetProcessById(processInfo.dwProcessID);
                //        process = Process.GetProcessById(processInfo.dwProcessId);
                //        logInfo.Info("进程以CreateProcessAsUser方式启动");
                //    }
                //}
                //else
                //{
                //    process.StartInfo.FileName = module.path;
                //    process.StartInfo.Arguments = arg;
                //    process.StartInfo.UseShellExecute = true;
                //    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(module.path);
                //    isOpen = process.Start();
                //    logInfo.Info("进程以Process方式启动");
                //}
                #endregion


                process.StartInfo.FileName = module.path;
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(module.path);
                isOpen = process.Start();
                logInfo.Info("进程以Process方式启动");



                isSuccess = isOpen;
                if (isOpen)
                {
                   processId = process.Id;
                  
                    if (module.path.Contains(@"bin\startup.bat"))
                    {
                        //对tomcat启动进程的特殊处理
                        process.EnableRaisingEvents = false;
                        Process[] processByName = Process.GetProcessesByName("ginkgo");
                        int count = 0;
                        while (processByName.Length == 0)
                        {
                            if (count > 5) break;
                            Thread.Sleep(100);
                            processByName = Process.GetProcessesByName("ginkgo");
                            count++;
                        }
                        Thread.Sleep(500);
                        processByName = Process.GetProcessesByName("ginkgo");
                        if (processByName.Length > 0)
                        {
                            foreach (var pro in processByName)
                            {
                                try
                                {
                                    if (pro != null && pro.MainModule != null && !string.IsNullOrWhiteSpace(pro.MainModule.FileName))
                                    {
                                        if (pro.MainModule.FileName.Contains(@"\bin\ginkgo"))
                                        {
                                            pro.EnableRaisingEvents = true;
                                            pro.Exited += Process_Exited;
                                            processId = pro.Id;
                                            break;
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    else
                    {
                        process.EnableRaisingEvents = true;
                        process.Exited += Process_Exited;
                        ////进程最小化
                        //while (process.MainWindowHandle == IntPtr.Zero)
                        //{
                        //    Thread.Sleep(100);
                        //}
                        //ControlAstro.Native.WinApi.ShowWindow(process.MainWindowHandle, (int)ControlAstro.Native.WinApi.nCmdShowWindow.SW_SHOWMINIMIZED);
                    }
                    lock (processDic)
                    {
                        if (processDic.ContainsKey(module.id))
                        {
                            processDic[module.id] = processId;
                        }
                        else
                        {
                            processDic.Add(module.id, processId);
                        }
                    }
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                MixLogHelper.Error(ClassName, "启动模块异常", e.StackTrace);
                return false;
            }
        }



        private void Process_Exited(object sender, EventArgs e)
        {
            try
            {
                Process p = sender as Process;
                int moduleKey = processDic.FirstOrDefault(q => q.Value == p.Id).Key;
                TModule module = moduleList.FirstOrDefault(m => m.id == moduleKey);
                if (!p.HasExited)
                {
                    p.Kill();
                }
                p.Close();
                p.Dispose();
                //if (module != null)
                //{
                //    lock (processDic)
                //    {
                //        if (processDic.ContainsKey(module.id)) processDic.Remove(module.id);
                //    }
                //    module.state = (int)LightState.Off;
                //}
            }
            catch (ArgumentNullException)
            {
                MixLogHelper.Error(ClassName, "退出模块时，模块数据有误");
            }
            catch (ArgumentOutOfRangeException)
            {
                MixLogHelper.Error(ClassName, "退出模块时，数据表索引超出范围");
            }
            catch (Exception ex)
            {
                MixLogHelper.Error(ClassName, ex.StackTrace);
            }
        }



        private void AutoCheckModuleState()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                _waitHandle.WaitOne();
                Thread.Sleep(5000);
                while (autoCheckModuleStateFlag)
                {
                    if (processDic.Count > 0)
                    {
                        try
                        {
                            var processes = Process.GetProcesses();
                            bool invaludateNeeded = false;
                            foreach (var id in processDic)
                            {
                                var pro = processes.FirstOrDefault(p => p.Id == id.Value);
                                if (pro == null)
                                {
                                    lock (processDic)
                                    {
                                        if (processDic.ContainsKey(id.Key)) processDic.Remove(id.Key);
                                    }
                                }
                                int state = (pro != null) ? (pro.Responding ? 0 : 1) : -1;
                                var module = moduleList.FirstOrDefault(q => q.id == id.Key);
                                if (state != module.state)
                                {
                                    module.state = state;
                                    invaludateNeeded = true;
                                }
                            }
                            if (invaludateNeeded)
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    Thread.Sleep(2000);
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        private bool StopAllModule()
        {
            try
            {
                foreach (var key in processDic.Values)
                {
                    using (Process p = Process.GetProcessById(key))
                    {
                        p.Kill();
                        logInfo.Info(p.ProcessName+"被关闭");  
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
