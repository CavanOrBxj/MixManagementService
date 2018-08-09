using ControlAstro.Controls;
using ControlAstro.Enums.ControlEnums;
using ControlAstro.Forms;
using ControlAstro.Utils;
using MixManagementPlatform.Controls;
using MixManagementPlatform.EntityModule;
using MixManagementPlatform.SqlManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FormMain : UserForm
    {
        public static readonly string[] ModuleType = new string[] { "智能广播服务管理平台", "CMDServer", "Tomcat服务", "解复用", "录音","TS指令服务","回传服务", "电话平台", "WAV转MP3", "天安密码器服务", "对接服务" };

        private SqlServerLogic sqlServer;
        private BindingCollection<TModule> moduleList;
        private Dictionary<int, int> processDic; //模块Id对应进程id
        private Point contextMenuDownPoint;
        private bool autoCheckModuleStateFlag = true;
        private readonly string ClassName;
        private EventWaitHandle _waitHandle = new AutoResetEvent(false);

        private System.Windows.Forms.Timer timer;
        private ToolTipEx tooltip;

        private bool flag;


        public FormMain(bool modeflag=false)
        {
            InitializeComponent();
            ClassName = GetType().Name;
            BackBrush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,
                Color.FromArgb(150, 210, 255, 220), Color.White, 90);
            BackAngle = 45;
            lblVersion.Text = "版本号：" + Application.ProductVersion;
            lblVersion.Location = new Point(Width - lblVersion.Width - 2, Height - lblVersion.Height - 2);

            flag = modeflag;
            if (flag)//显示为设置模式
            {
                dgvMix.Columns["ColumnEdit"].Visible = false;
                dgvMix.Columns["ColumnState"].Visible = false;
                
            }
            menuStrip.Renderer = new ToolStripRendererEx();
            menuStripDgv.Renderer = new ToolStripRendererEx();
            dgvMix.AutoGenerateColumns = false;
            dgvMix.ShowCellErrors = false;
            dgvMix.DataError += DgvMix_DataError;
            tooltip = new ToolTipEx();
            tooltip.UseAnimation = true;
            tooltip.UseFading = true;
            
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            //timer.Start();
            
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            Height = Height + 50 > 512 ? 512 : Height + 50;
            if (Height == 512)
            {
                timer.Stop();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            processDic = new Dictionary<int, int>();
            moduleList = new BindingCollection<TModule>();
            moduleList.ListChanged += ModuleList_ListChanged;

            CheckModuleConfig();
            LoadDataGridView();

            //启动需要自动启动的模块
            AutoStartModule();

            AutoCheckModuleState();
        }

        private void ModuleList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(dgvMix.InvokeRequired)
            {
                dgvMix.Invoke(new MethodInvoker(() => { dgvMix.Invalidate(); }));
            }
            else
            {
                dgvMix.Invalidate();
            }
        }

        private void AutoCheckModuleState()
        {
            if(flag)
            {
                return;
            }
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
                                if(pro==null)
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
                                dgvMix.Invoke(new MethodInvoker(() =>
                                {
                                    dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnEdit.Index, true));
                                    dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnState.Index, true));
                                }));
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

        private bool InitModuleDatabase()
        {
            var appSettings = System.Configuration.ConfigurationManager.AppSettings;
            if (sqlServer == null)
            {
                sqlServer = new SqlServerLogic(string.Format("Server={0};uid={1};pwd={2};", appSettings["DatabaseServerIP"], appSettings["DatabaseUser"], appSettings["DatabasePwd"]));
            }
            int createData = sqlServer.FromSql("CREATE DATABASE volador");
            MixLogHelper.Info(ClassName, createData != -100 ? "volador数据库创建成功" : "volador数据库创建失败");

            bool success = sqlServer.ExecuteCommand(sqlServer.GetSqlFile(Path.Combine(Application.StartupPath, "sqlinit"), "volador"));
            MixLogHelper.Info(ClassName, success ? "volador表创建成功" : "volador表创建失败");

            return success;
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
            Label lblOverInfo = new Label();
            try
            {
                if (flag)//设置模式
                {
                    return;
                }
                if (Convert.ToInt32(Program.GetRegeditData(Program.RegeditDirKey, "FirstStart")) == 0)
                {
                    FormDataBaseConfig form = new FormDataBaseConfig();
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        lblOverInfo.Text = "初次启动正在初始化数据，请稍候。。。";
                        lblOverInfo.BringToFront();
                        Controls.Add(lblOverInfo);

                        //开始初始化模块配置和数据库信息
                        bool success = InitModuleDatabase();
                     //   if (!success) MessageBox.Show("数据库创建失败", "提示"); 不需要提示
                        if (success)
                            Program.SetRegeditData(Program.RegeditDirKey, "FirstStart", 1);
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            catch(Exception e)
            {
                MixLogHelper.Error(ClassName, "数据库初始化异常", e.StackTrace);
                MessageBox.Show(this, "数据初始化异常，请联系管理人员", "提示");
            }
            finally
            {
                if (Controls.Contains(lblOverInfo)) Controls.Remove(lblOverInfo);
            }
        }

        /// <summary>
        /// 读取配置文件并加载
        /// </summary>
        private void LoadDataGridView()
        {
            try
            {
                moduleList = new BindingCollection<TModule>(DB.Context.From<TModule>().OrderBy(TModule._.startindex.Desc).ToList());
                dgvMix.DataSource = moduleList;
                foreach(DataGridViewRow row in dgvMix.Rows)
                {
                    if ((row.DataBoundItem as TModule).temtype < 0)
                    {
                        (row.Cells[ColumnModuleConfig.Index] as DataGridViewDisableButtonCell).Enabled = false;
                    }
                }
                if (dgvMix.RowCount > 0)
                {
                    dgvMix.AutoResizeColumn(ColumnLoaction.Index);
                }
            }
            catch (Exception e)
            {
                MixLogHelper.Error(ClassName, "数据配置加载异常", e.StackTrace);
                MessageBox.Show(this, "数据配置加载异常，请稍候重试");
            }
        }

        /// <summary>
        /// 顺序自启
        /// </summary>
        private void AutoStartModule()
        {
            if(flag)//设置模式
            {
                return;
            }

            dgvMix.Enabled = false;
            btnYes.Enabled = false;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnAutoStart.Enabled = false;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    for (int i = 0; i < moduleList.Count; i++)
                    {
                        if (moduleList[i].autostart != 0)
                        {
                            Thread.Sleep(moduleList[i].delay * 1000);
                            if (Disposing || IsDisposed) return;
                            if (File.Exists(moduleList[i].path))
                            {
                                bool isSuccess = StartModule(moduleList[i]);
                                if (isSuccess)
                                {
                                    moduleList[i].state = (int)LightState.On;
                                }
                                else
                                {
                                    Invoke(new MethodInvoker(() => { MessageBox.Show(this, "模块自启失败，请尝试手动启动"); }));
                                    return;
                                }
                            }
                            else
                            {
                                Invoke(new MethodInvoker(() =>
                                {
                                    MessageBox.Show(this, moduleList[i].name + "模块不存在，请检查模块路径", "温馨提示");
                                }));
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(this, "模块自启失败，请手动启动");
                    return;
                }
                finally
                {
                    dgvMix.Invoke(new MethodInvoker(() =>
                    {
                        try
                        {
                            dgvMix.Enabled = true;
                            btnYes.Enabled = true;
                            btnAdd.Enabled = true;
                            btnDel.Enabled = true;
                            btnAutoStart.Enabled = true;
                            dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnEdit.Index, true));
                            dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnState.Index, true));
                        }
                        catch (Exception ex)
                        {
                            MixLogHelper.Error(ClassName, ex.StackTrace);
                        }
                    }));
                    _waitHandle.Set();
                }
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        #region dgvMix
        private void dgvMix_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Color foreColor = e.State.HasFlag(DataGridViewElementStates.Selected) ? dgvMix.RowHeadersDefaultCellStyle.SelectionForeColor : dgvMix.RowHeadersDefaultCellStyle.ForeColor;
            //Color backColor = e.State.HasFlag(DataGridViewElementStates.Selected) ? dgvMix.RowHeadersDefaultCellStyle.SelectionBackColor : dgvMix.RowHeadersDefaultCellStyle.BackColor;
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvMix.DefaultCellStyle.Font,
                new Rectangle(e.RowBounds.Location.X + 10, e.RowBounds.Location.Y, dgvMix.RowHeadersWidth - 10, dgvMix.RowTemplate.Height),
                foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void dgvMix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnEdit.Index && e.RowIndex >= 0 && !dgvMix.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                InitStartModule(e);
            }
            if (e.ColumnIndex == ColumnModuleConfig.Index && e.RowIndex >= 0 &&
                (dgvMix[e.ColumnIndex, e.RowIndex] as DataGridViewDisableButtonCell).Enabled)
            {
                EditModuleConfig(e.RowIndex);
            }
        }

        private void dgvMix_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex != ColumnEdit.Index)
            {
                new FormModule(this, 0, dgvMix.Rows[e.RowIndex].DataBoundItem as TModule).ShowDialog();
            }
        }

        private void dgvMix_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMix.SelectedRows.Count > 0)
            {
                TModule module = dgvMix.SelectedRows[0].DataBoundItem as TModule;
                textBoxName.Text = module.name;
                textBoxLocation.Text = module.path;
                checkBoxAutoStart.Checked = module.autostart != 0;
                textBoxDelay.Text = module.delay.ToString();
                textBoxArguments.Text = module.arguments;
            }
        }

        private void DgvMix_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                dgvMix.DataSource = null;
                dgvMix.DataSource = moduleList;
                dgvMix.Invalidate();
            }
            catch
            {
            }
            MixLogHelper.Error(ClassName, string.Format("模块数据绑定异常(行：{0} 列：{1} 异常信息：{2})", e.RowIndex, e.ColumnIndex, e.Context), e.Exception.StackTrace);
            e.Cancel = false;
            e.ThrowException = false;
        }

        private void dgvMix_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColumnState.Index && e.RowIndex >= 0)
            {
                switch ((int)e.Value)
                {
                    case -1:
                        e.Value = "已停止";
                        break;
                    case 0:
                        e.Value = "正在运行";
                        break;
                    case 1:
                        e.Value = "未响应";
                        break;
                }
                e.FormattingApplied = true;
            }
        }
        #endregion

        #region 模块的启动和关闭

        private void InitStartModule(DataGridViewCellEventArgs e)
        {
            dgvMix.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            Rectangle rect = RectangleToClient(dgvMix.RectangleToScreen(dgvMix.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true)));
            btnYes.Enabled = false;

            Thread thread = new Thread(new ThreadStart(()=> 
            {
                try
                {
                    TModule module = dgvMix.Rows[e.RowIndex].DataBoundItem as TModule;
                    bool isSuccess = false;
                    if (module.state == (int)LightState.Off)
                    {
                        if (File.Exists(module.path))
                        {
                            isSuccess = StartModule(module);
                            if (isSuccess || (processDic.ContainsKey(module.id) && Process.GetProcessById(processDic[module.id]).Responding))
                            {
                                module.state = (int)LightState.On;
                            }
                            else
                            {
                                Invoke(new MethodInvoker(() =>
                                {
                                    ShowToolTip("操作失败，请再次尝试", 2000);
                                }));
                            }
                        }
                        else
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                MessageBox.Show(this, module.name + "模块不存在，请检查模块路径", "温馨提示");
                                //DialogResult result = MessageBox.Show(this, module.name + "模块不存在，是否要删除", "温馨提示", MessageBoxButtons.YesNo);
                                //if (result == DialogResult.Yes)
                                //{
                                //    moduleList.RemoveAt(moduleList.IndexOf(module));
                                //}
                            }));
                        }
                    }
                    else
                    {
                        isSuccess = StopModule(module);
                        if(isSuccess)
                        {
                            lock (processDic)
                            {
                                if (processDic.ContainsKey(module.id)) processDic.Remove(module.id);
                            }
                            module.state = (int)LightState.Off;
                        }
                        else
                        {
                            if (MessageBox.Show(this, "停止失败，是否强制结束进程", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Process.GetProcessById(processDic[module.id]).Kill();
                                Thread.Sleep(550);
                                if (!processDic.ContainsKey(module.id))
                                {
                                    module.state = (int)LightState.Off;
                                    return;
                                }
                                Invoke(new MethodInvoker(() =>
                                {
                                    ShowToolTip("操作失败，请再次尝试", 2000);
                                }));
                            }
                        }
                    }
                }
                catch
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        ShowToolTip("操作失败，请稍候重试", 2000);
                    }));
                    return;
                }
                finally
                {
                    dgvMix.Invoke(new MethodInvoker(() =>
                    {
                        dgvMix.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                        dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnEdit.Index, true));
                        dgvMix.Invalidate(dgvMix.GetColumnDisplayRectangle(ColumnState.Index, true));
                        btnYes.Enabled = true;
                    }));
                }
            }));
            thread.Start();
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
                Process process = new Process();
                process.StartInfo.FileName = module.path;
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(module.path);
                process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

                bool isOpen = false;
                isOpen = process.Start();
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
                        //进程最小化
                        while (process.MainWindowHandle == IntPtr.Zero)
                        {
                            Thread.Sleep(100);
                        }
                        ControlAstro.Native.WinApi.ShowWindow(process.MainWindowHandle, (int)ControlAstro.Native.WinApi.nCmdShowWindow.SW_SHOWMINIMIZED);
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

        private bool StopModule(TModule module)
        {
            try
            {
                if (!processDic.ContainsKey(module.id))
                {
                    return true;
                }
                var key = processDic[module.id];
                if(key != 0)
                {
                    Process p = Process.GetProcessById(key);
                    if (p != null && key != 0)
                    {
                        var hasClosed = p.CloseMainWindow();
                        return hasClosed;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
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
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

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
                if (module != null)
                {
                    lock (processDic)
                    {
                        if (processDic.ContainsKey(module.id)) processDic.Remove(module.id);
                    }
                    module.state = (int)LightState.Off;
                    dgvMix.InvalidateRow(moduleList.IndexOf(module));
                }
            }
            catch(ArgumentNullException)
            {
                MixLogHelper.Error(ClassName, "退出模块时，模块数据有误");
            }
            catch(ArgumentOutOfRangeException)
            {
                MixLogHelper.Error(ClassName, "退出模块时，数据表索引超出范围");
            }
            catch(Exception ex)
            {
                MixLogHelper.Error(ClassName, ex.StackTrace);
            }
        }

        private void lblFileOpen_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLocation.Text = fileDialog.FileName;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processDic.Count != 0)
            {
                DialogResult result = MessageBox.Show(this, "是否关闭所有模块", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        StopAllModule();
                    }
                }
            }
            if (!e.Cancel)
            {
                foreach (var m in moduleList)
                {
                    TModuleLogic.UpdateModule(m.id, new Dos.ORM.Field[] { TModule._.state, TModule._.startindex }, new object[] { -1, m.autostart != 0 ? m.startindex : 0 });
                    //sql.UpdateModuleState(m.id);
                }
            }
            autoCheckModuleStateFlag = e.Cancel;
        }

        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            DelModule();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            EditModule();
        }

        private void toolStripMenuItemInfo_Click(object sender, EventArgs e)
        {
            InfoModule();
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddModule();
        }

        private void toolStripMenuItemEditConfig_Click(object sender, EventArgs e)
        {
            EditModuleConfig(dgvMix.SelectedRows[0].Index);
        }

        #region 模块增删

        private void AddModule()
        {
            try
            {
                FormModule formModule = new FormModule(this, 2);
                DialogResult result = formModule.ShowDialog();
                if (result == DialogResult.OK && formModule.NewModule != null)
                {
                    FormModuleConfig formConfig = new FormModuleConfig(this, formModule.NewModule);
                    DialogResult resultConfig = formConfig.ShowDialog();
                    var insertResult = TModuleLogic.InsertModule(formModule.NewModule);
                    if (insertResult.IsSuccess)
                    {
                        var qureyResult = TModuleLogic.QureyModule(formModule.NewModule);
                        if (qureyResult.IsSuccess) formModule.NewModule.id = (qureyResult.Data as List<TModule>)[0].id;
                        moduleList.Add(formModule.NewModule);
                        if (resultConfig == DialogResult.OK)
                        {
                            ShowToolTip("添加成功，配置成功", 3000);
                        }
                        else if (result == DialogResult.Ignore)
                        {
                            ShowToolTip("添加成功，配置文件不存在或有异常", 3000);
                        }
                        else
                        {
                            ShowToolTip("添加成功，配置已取消 ", 3000);
                        }
                    }
                    else
                    {
                        ShowToolTip("添加失败", 3000);
                    }
                    //sql.InsertModule(formModule.NewModule);
                    //var ds = sql.FromSqlForReader(string.Format("select id from moduleinfo where name='{0}' and path='{1}' and autostart={2} and delay={3} and startindex={4} and arguments='{5}'",
                    //    formModule.NewModule.name, formModule.NewModule.path, formModule.NewModule.autostart,
                    //    formModule.NewModule.delay, formModule.NewModule.startindex, formModule.NewModule.arguments));
                    //formModule.NewModule.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                }
                formModule.Dispose();
            }
            catch(Exception e)
            {
                MixLogHelper.Error(ClassName, "添加模块信息异常", e.StackTrace);
            }
        }

        private void InfoModule()
        {
            if (dgvMix.SelectedRows.Count > 0)
            {
                new FormModule(this, 0, moduleList[dgvMix.SelectedRows[0].Index]).ShowDialog();
            }
            else
            {
                ShowToolTip("未选中模块", 2000);
                //MessageBox.Show("未选中模块");
            }
        }

        private void EditModule()
        {
            try
            {
                if (dgvMix.SelectedRows.Count > 0)
                {
                    FormModule form = new FormModule(this, 1, moduleList[dgvMix.SelectedRows[0].Index]);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TModuleLogic.UpdateModule(form.NewModule);
                        //sql.UpdateModule(moduleList[dgvMix.SelectedRows[0].Index].id, form.NewModule);
                        moduleList[dgvMix.SelectedRows[0].Index] = form.NewModule;
                        lblError.Visible = false;
                        dgvMix.InvalidateRow(dgvMix.SelectedRows[0].Index);
                        form.Dispose();
                    }
                }
                else
                {
                    ShowToolTip("未选中模块", 2000);
                }
            }
            catch
            {

            }
        }

        private void DelModule()
        {
            try
            {
                if (dgvMix.SelectedRows.Count > 0)
                {
                    TModule module = moduleList[dgvMix.SelectedRows[0].Index];
                    DialogResult result = MessageBox.Show(this, "确定要删除该模块：" + module.name + "？", "温馨提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        var databaseResult = TModuleLogic.DeletModule(module.id);
                        if(databaseResult.IsSuccess)
                        {
                            ShowToolTip("删除成功", 2000);
                        }
                        else
                        {
                            ShowToolTip("删除失败", 2000);
                        }
                        if (processDic.ContainsKey(module.id))
                        {
                            StopModule(module);
                        }
                        moduleList.RemoveAt(dgvMix.SelectedRows[0].Index);
                        lblError.Visible = false;
                    }
                }
                else
                {
                    ShowToolTip("未选中模块", 2000);
                    //MessageBox.Show("未选中模块");
                }
            }
            catch(Exception e)
            {
                MixLogHelper.Error(ClassName, "删除模块异常", e.StackTrace);
            }
        }

        private void DelModule(TModule module)
        {

        }

        private void AutoStartConfig()
        {
            try
            {
                FormStartIndex formindex = new FormStartIndex(this, moduleList);
                if (formindex.ShowDialog() == DialogResult.OK)
                {
                    var index = formindex.GetStartIndex();
                    for (int i = index.Count - 1; i >= 0; i--)
                    {
                        moduleList.FirstOrDefault(q => q.id == index[i].id).startindex = index.Count - i;
                        //sql.FromSql(string.Format("update moduleinfo set startindex={0} where id={1}", index.Count - i, index[i].id));
                        TModuleLogic.UpdateModule(index[i].id, new Dos.ORM.Field[] { TModule._.startindex, }, new object[] { index.Count - i, });
                    }
                    moduleList.Sort(TypeDescriptor.GetProperties(typeof(TModule)).Find("startindex", false), ListSortDirection.Descending);
                    dgvMix.Invalidate();
                }
                formindex.Dispose();
            }
            catch(Exception e)
            {
                MixLogHelper.Error(ClassName, "启动顺序配置异常", e.StackTrace);
            }
        }

        #endregion

        private void ToolStripMenuItemAutoStart_Click(object sender, EventArgs e)
        {
            AutoStartConfig();
        }

        /// <summary>
        /// 添加新模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                btnYes.Enabled = false;
                if(dgvMix.SelectedRows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(textBoxLocation.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text))
                    {
                        int rowIndex = dgvMix.SelectedRows[0].Index;
                        moduleList[rowIndex].path = textBoxLocation.Text.Trim();
                        moduleList[rowIndex].name = textBoxName.Text.Trim();
                        moduleList[rowIndex].autostart = checkBoxAutoStart.Checked ? 1 : 0;
                        if (!checkBoxAutoStart.Checked)
                        {
                            moduleList[rowIndex].startindex = 0;
                        }
                        else
                        {
                            moduleList[rowIndex].startindex = moduleList[rowIndex].startindex == 0 ? 1 : moduleList[rowIndex].startindex;
                        }
                        moduleList[rowIndex].delay = string.IsNullOrWhiteSpace(textBoxDelay.Text) ? 0 : int.Parse(textBoxDelay.Text.Trim());
                        moduleList[rowIndex].arguments = textBoxArguments.Text.Trim() ?? null;
                        //sql.UpdateModule(moduleList[rowIndex].id, moduleList[rowIndex]);
                        TModuleLogic.UpdateModule(moduleList[rowIndex]);
                        dgvMix.InvalidateRow(rowIndex);
                        lblError.Visible = false;
                        ShowToolTip("模块更新成功", 2000);
                    }
                    else
                    {
                        lblError.Text = "模块名称、地址不能为空";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    ShowToolTip("未选中模块", 2000);
                }
            }
            catch(Exception ex)
            {
                MixLogHelper.Error(ClassName, "增加模块异常", ex.StackTrace);
            }
            finally
            {
                btnYes.Enabled = true;
            }
        }

        private void menuStripDgv_Opening(object sender, CancelEventArgs e)
        {
            contextMenuDownPoint = dgvMix.PointToClient(MousePosition);
            var hit = dgvMix.HitTest(contextMenuDownPoint.X, contextMenuDownPoint.Y);
            if (hit.Type == DataGridViewHitTestType.Cell || hit.Type == DataGridViewHitTestType.RowHeader)
            {
                dgvMix.Rows[hit.RowIndex].Selected = true;
            }
            toolStripMenuItemDel.Enabled = dgvMix.SelectedRows.Count > 0;
            toolStripMenuItemEdit.Enabled = dgvMix.SelectedRows.Count > 0;
            toolStripMenuItemInfo.Enabled = dgvMix.SelectedRows.Count > 0;
            toolStripMenuItemEditConfig.Enabled = dgvMix.SelectedRows.Count > 0;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddModule();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DelModule();
        }

        /// <summary>
        /// 配置启动顺序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            if (moduleList.Count < 2)
            {
                ShowToolTip("当前可配置模块数量过少", 2000);
                return;
            }
            AutoStartConfig();
        }

        /// <summary>
        /// 显示ToolTip
        /// </summary>
        /// <param name="msg">要显示的文本</param>
        /// <param name="duration">显示时长（单位：毫秒）</param>
        private void ShowToolTip(string msg, int duration)
        {
            SizeF size = CreateGraphics().MeasureString(msg, SystemFonts.DefaultFont);
            size.Width += 50;
            size.Height += 30;
            tooltip.Size = size.ToSize();
            if (duration > 0)
            {
                tooltip.Show(msg, this, (Width - tooltip.Size.Width) / 2, (Height - tooltip.Size.Height) / 2, duration);
            }
            else
            {
                tooltip.Show(msg, this, (Width - tooltip.Size.Width) / 2, (Height - tooltip.Size.Height) / 2);
            }
        }

        /// <summary>
        /// 根据模块不同对应不同的配置界面
        /// </summary>
        /// <param name="e"></param>
        private void EditModuleConfig(int rowIndex)
        {
            FormModuleConfig form = new FormModuleConfig(this, (dgvMix.Rows[rowIndex].DataBoundItem as TModule));
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                ShowToolTip("配置成功", 2000);
            }
            else if (result == DialogResult.Ignore)
            {
                ShowToolTip("配置文件不存在或有异常", 2000);
            }
        }

    }
}
