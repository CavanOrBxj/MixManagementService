using ControlAstro.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FrmServiceSetup : UserForm
    {

        string strServiceName = string.Empty;
        public FrmServiceSetup()
        {
            InitializeComponent();
            strServiceName = string.IsNullOrEmpty(lblServiceName.Text) ? "MixManagementService" : lblServiceName.Text;
            this.Load += FrmServiceSetup_Load;
            InitControlStatus(strServiceName, btnInstallOrUninstall, btnStartOrEnd, btnGetStatus, lblMsg, gbMain);
        }

        void FrmServiceSetup_Load(object sender, EventArgs e)
        {
            UpdateSqlConnection();
        }


        /// <summary>  
        /// 初始化控件状态  
        /// </summary>  
        /// <param name="serviceName">服务名称</param>  
        /// <param name="btn1">安装按钮</param>  
        /// <param name="btn2">启动按钮</param>  
        /// <param name="btn3">获取状态按钮</param>  
        /// <param name="txt">提示信息</param>  
        /// <param name="gb">服务所在组合框</param>  
        void InitControlStatus(string serviceName, Button btn1, Button btn2, Button btn3, Label txt, GroupBox gb)
        {
            try
            {
                btn1.Enabled = true;

                if (ServiceAPI.isServiceIsExisted(serviceName))
                {
                    btn3.Enabled = true;
                    btn2.Enabled = true;
                    btn1.Text = "卸载服务";
                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 4)
                    {
                        btn2.Text = "停止服务";
                    }
                    else
                    {
                        btn2.Text = "启动服务";
                    }
                    GetServiceStatus(serviceName, txt);
                    //获取服务版本  
                    string temp = string.IsNullOrEmpty(ServiceAPI.GetServiceVersion(serviceName)) ? string.Empty : "(" + ServiceAPI.GetServiceVersion(serviceName) + ")";
                    gb.Text += temp;
                }
                else
                {
                    btn1.Text = "安装服务";
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    txt.Text = "服务【" + serviceName + "】未安装！";
                }
            }
            catch (Exception ex)
            {
                txt.Text = "error";
                LogAPI.WriteLog(ex.Message);
            }
        }


        /// <summary>  
        /// 安装或卸载服务  
        /// </summary>  
        /// <param name="serviceName">服务名称</param>  
        /// <param name="btnSet">安装、卸载</param>  
        /// <param name="btnOn">启动、停止</param>  
        /// <param name="txtMsg">提示信息</param>  
        /// <param name="gb">组合框</param>  
        void SetServerce(string serviceName, Button btnSet, Button btnOn, Button btnShow, Label txtMsg, GroupBox gb)
        {
            try
            {
                string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string serviceFileName = location.Substring(0, location.LastIndexOf('\\')) + "\\" + serviceName + ".exe";

                if (btnSet.Text == "安装服务")
                {
                    ServiceAPI.InstallmyService(null, serviceFileName);
                    if (ServiceAPI.isServiceIsExisted(serviceName))
                    {
                        txtMsg.Text = "服务【" + serviceName + "】安装成功！";
                        btnOn.Enabled = btnShow.Enabled = true;
                        string temp = string.IsNullOrEmpty(ServiceAPI.GetServiceVersion(serviceName)) ? string.Empty : "(" + ServiceAPI.GetServiceVersion(serviceName) + ")";
                        gb.Text = "融合平台工具管理服务" + temp;
                        btnSet.Text = "卸载服务";
                        btnOn.Text = "启动服务";
                    }
                    else
                    {
                        txtMsg.Text = "服务【" + serviceName + "】安装失败，请检查日志！";
                    }
                }
                else
                {
                    if (btnStartOrEnd.Text == "停止服务")
                    {
                        MessageBox.Show("请先停止服务","提示");
                        btnStartOrEnd.Focus();
                        return;
                    }
                    ServiceAPI.UnInstallmyService(serviceFileName);
                    if (!ServiceAPI.isServiceIsExisted(serviceName))
                    {
                        txtMsg.Text = "服务【" + serviceName + "】卸载成功！";
                        btnOn.Enabled = btnShow.Enabled = false;
                        btnSet.Text = "安装服务";
                        //gb.Text =strServiceName; 
                        gb.Text = "融合平台工具管理服务";
                    }
                    else
                    {
                        txtMsg.Text = "服务【" + serviceName + "】卸载失败，请检查日志！";
                    }
                }
            }
            catch (Exception ex)
            {
                txtMsg.Text = "error";
                LogAPI.WriteLog(ex.Message);
            }
        }


        //获取服务状态  
        void GetServiceStatus(string serviceName, Label txtStatus)
        {
            try
            {
                if (ServiceAPI.isServiceIsExisted(serviceName))
                {
                    string statusStr = "";
                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    switch (status)
                    {
                        case 1:
                            statusStr = "服务未运行！";
                            break;
                        case 2:
                            statusStr = "服务正在启动！";
                            break;
                        case 3:
                            statusStr = "服务正在停止！";
                            break;
                        case 4:
                            statusStr = "服务正在运行！";
                            break;
                        case 5:
                            statusStr = "服务即将继续！";
                            break;
                        case 6:
                            statusStr = "服务即将暂停！";
                            break;
                        case 7:
                            statusStr = "服务已暂停！";
                            break;
                        default:
                            statusStr = "未知状态！";
                            break;
                    }
                    txtStatus.Text = statusStr;
                }
                else
                {
                    txtStatus.Text = "服务【" + serviceName + "】未安装！";
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = "error";
                LogAPI.WriteLog(ex.Message);
            }
        }


        //启动服务  
        void OnService(string serviceName, Button btn, Label txt)
        {
            try
            {
                if (btn.Text == "启动服务")//启动服务
                {
                    ServiceAPI.RunService(serviceName);

                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 2 || status == 4 || status == 5)
                    {
                        txt.Text = "服务【" + serviceName + "】启动成功！";
                        btn.Text = "停止服务";
                    }
                    else
                    {
                        txt.Text = "服务【" + serviceName + "】启动失败！";
                    }
                }
                else //关闭服务
                {
                    ServiceAPI.StopService(serviceName);

                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 1 || status == 3 || status == 6 || status == 7)
                    {
                        txt.Text = "服务【" + serviceName + "】停止成功！";
                        btn.Text = "启动服务";
                    }
                    else
                    {
                        txt.Text = "服务【" + serviceName + "】停止失败！";
                    }
                }
            }
            catch (Exception ex)
            {
                txt.Text = "error";
                LogAPI.WriteLog(ex.Message);
            }
        }


        private void btnInstallOrUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                btnInstallOrUninstall.Enabled = false;
                SetServerce(strServiceName, btnInstallOrUninstall, btnStartOrEnd, btnGetStatus, lblMsg, gbMain);
                btnInstallOrUninstall.Enabled = true;
                btnInstallOrUninstall.Focus();  
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnStartOrEnd_Click(object sender, EventArgs e)
        {
            try
            {
                btnStartOrEnd.Enabled = false;
                OnService(strServiceName, btnStartOrEnd, lblMsg);
                btnStartOrEnd.Enabled = true;
                btnStartOrEnd.Focus(); 
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetStatus.Enabled = false;
                GetServiceStatus(strServiceName, lblMsg);
                btnGetStatus.Enabled = true;
                btnGetStatus.Focus();  
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        /// <summary>
        /// sqlite中 数据库连接信息设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSqlConnection()
        {
            try
            {
                string strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

                AppConfigurator.UpdateConnectionStringsConfig("SqliteConn", "Data Source=" + strPath + "module-config.sqlite", "Dos.ORM.Sqlite", strPath + "MixManagementService.exe");

                string sql = "SELECT * FROM SQLServerInfo";
                string connStr = @"Data Source=" + strPath + @"module-config.sqlite;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
                using (SQLiteConnection conn = new SQLiteConnection(connStr))
                {
                    conn.Open();
                    using (SQLiteDataAdapter ap = new SQLiteDataAdapter(sql, conn))
                    {
                        DataSet ds = new DataSet();
                        ap.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        string sql_ = "";
                        if (dt.Rows.Count > 0)
                        {
                            //更新
                            sql_ = string.Format("update SQLServerInfo set IP='{0}',USER='{1}',PWD='{2}' WHERE id=1", SingletonInfo.GetInstance().SqlServerIP, SingletonInfo.GetInstance().SqlServerUser, SingletonInfo.GetInstance().SqlServerPWD);
                        }
                        else
                        {
                            //插入
                            sql_ = string.Format("INSERT INTO SQLServerInfo (id,IP,USER,PWD) values ({0},{1},{2},{3})", "1", SingletonInfo.GetInstance().SqlServerIP, SingletonInfo.GetInstance().SqlServerUser, SingletonInfo.GetInstance().SqlServerPWD);

                        }
                        using (SQLiteCommand command = new SQLiteCommand(sql_, conn))
                        {
                            command.ExecuteNonQuery();
                        }

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnServerSet_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain dlg = new FormMain(true);
                dlg.ShowDialog();
                if (MessageBox.Show("服务配置修改后需重启服务，是否重启服务？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ServiceAPI.StopService(strServiceName)) 
                    {
                        Thread.Sleep(1000);
                        ServiceAPI.RunService(strServiceName);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
