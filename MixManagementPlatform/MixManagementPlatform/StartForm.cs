using ControlAstro.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MixManagementPlatform
{
    public partial class StartForm : UserForm
    {
        public StartForm()
        {
            InitializeComponent();
            Load += StartForm_Load;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            textServerIp.Text = AppConfigurator.GetAppConfig("DatabaseServerIP");
            textUser.Text = AppConfigurator.GetAppConfig("DatabaseUser"); 
            textPwd.Text =AppConfigurator.GetAppConfig("DatabasePwd");

            SingletonInfo.GetInstance().SqlServerIP = textServerIp.Text.Trim();
            SingletonInfo.GetInstance().SqlServerUser = textUser.Text.Trim();
            SingletonInfo.GetInstance().SqlServerPWD = textPwd.Text.Trim();

            if (IsServerAlreadyExisted())
            {
                //进入服务设置UI 安装\卸载 启动\停止 服务设置 切换为桌面客户端等
                this.Hide();
                FrmServiceSetup dlg = new FrmServiceSetup();
                dlg.ShowDialog();
                Close(); //整个程序退出 
            }
            else
            { 
                //进入选择模式UI  选择程序启动模式  windows服务  或者 桌面客户端
            }
        }

        /// <summary>
        /// 判断MixManagementService 是否已经运行
        /// 说明:在VS调试环境下仍然会重入(不用考虑)
        /// </summary>
        /// <returns>
        /// true: 系统中已经有实例
        /// false: 系统中没有实例
        /// </returns>
        private bool IsServerAlreadyExisted()
        {
            //获取进程列表
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("MixManagementService");
            if (processes.Length < 1)
            {
                return false;
            }
            else
            {
                Process[] localAll = Process.GetProcesses();
                //遍历有相同名称正在运行的进程
                foreach (System.Diagnostics.Process process in localAll)
                {
                    ////都不含路径
                    //if (process.MainModule.ModuleName == processes[0].MainModule.ModuleName)
                    //{
                    //    if (process.Id != processes[0].Id)
                    //        return true; //系统中已经有实例
                    //}

                    if (process.Id != processes[0].Id)
                        return true; //系统中已经有实例

                }
            }
            //系统中没有实例
            return false;
        }


        private void btnYes_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textServerIp.Text))
            {
                System.Windows.Forms.MessageBox.Show(this, "数据库IP地址不能为空");
                return;
            }
            if (rdbWindowsServer.Checked == false && rdbDeskttopClient.Checked == false)
            {
                System.Windows.Forms.MessageBox.Show(this, "请选择一种启动方式");
                return;
            }
            AppConfigurator.UpdateAppConfig("DatabaseServerIP", textServerIp.Text.Trim());
            AppConfigurator.UpdateAppConfig("DatabaseUser", textUser.Text.Trim());
            AppConfigurator.UpdateAppConfig("DatabasePwd", textPwd.Text.Trim());

            if (rdbWindowsServer.Checked)
            {
                //windows服务模式

                //进入服务设置UI 安装\卸载 启动\停止 服务设置 切换为桌面客户端等
                this.Hide();
                FrmServiceSetup dlg = new FrmServiceSetup();
                dlg.ShowDialog();
                Close(); //整个程序退出 
            }
            else
            {
                SingletonInfo.GetInstance().SqlServerIP = textServerIp.Text.Trim();
                SingletonInfo.GetInstance().SqlServerUser = textUser.Text.Trim();
                SingletonInfo.GetInstance().SqlServerPWD = textPwd.Text.Trim();
                //桌面客户端模式
                this.Hide();
                FormMain dlg = new FormMain();
                dlg.ShowDialog();
                Close();
            }

           
        }
    }
}
