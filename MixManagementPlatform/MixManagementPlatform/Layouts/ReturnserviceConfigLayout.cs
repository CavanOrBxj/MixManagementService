using MixManagementPlatform.Utils;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MixManagementPlatform.Layouts
{
    public partial class ReturnserviceConfigLayout : UserControl
    {
        private string path;
        private IniFileOperator iniFile;
        private bool hasConfigFile; //是否存在对应的配置文件

        public ReturnserviceConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(369, 601);
            this.path = path;
            if (path != null && !string.IsNullOrWhiteSpace(path))
            {
                InitData();
            }
        }

        private void InitData()
        {
            try
            {
                string configPath = Path.Combine(Path.GetDirectoryName(path), "gxreback.ini");
                if (System.Configuration.ConfigurationManager.AppSettings["LogConfigPathFlag"] != "0")
                {
                    MixLogHelper.Info(GetType().Name, configPath);
                }
                hasConfigFile = File.Exists(configPath);
                if (!File.Exists(configPath))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                if (iniFile == null) iniFile = new IniFileOperator(configPath);
                textServerName.Text = iniFile.ReadString("Database", "ServerName", "");
                textDataBase.Text = iniFile.ReadString("Database", "DataBase", "");
                textLogID.Text = iniFile.ReadString("Database", "LogID", "");
                textLogPass.Text = iniFile.ReadString("Database", "LogPass", "");

                textIP.Text= iniFile.ReadString("LocalHost", "LoaclIP", "");
                textUDPPORT.Text= iniFile.ReadString("LocalHost", "UDPLocalPort", "");
                textTCPPORT.Text= iniFile.ReadString("LocalHost", "TCPLocalPort", "");

                textMQServer.Text = iniFile.ReadString("MQ", "MQIP", "");
                textMQServerPORT.Text = iniFile.ReadString("MQ", "MQPORT", "");
                textMQTopicName.Text = iniFile.ReadString("MQ", "TopicName", "");

                txtFTPServer.Text = iniFile.ReadString("Reback", "FTPServer", "");
                txtFTPPort.Text = iniFile.ReadString("Reback", "FTPPort", "");
                txtFTPUserName.Text = iniFile.ReadString("Reback", "FTPUserName", "");
                txtFTPPwd.Text = iniFile.ReadString("Reback", "FTPPwd", "");
                txtftppath.Text = iniFile.ReadString("Reback", "ftppath", "");


            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化广西协议回传服务配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                string configPath = Path.Combine(Path.GetDirectoryName(path), "gxreback.ini");
                if(iniFile==null) iniFile = new IniFileOperator(configPath);

                iniFile.WriteString("Database", "ServerName", textServerName.Text.Trim());
                iniFile.WriteString("Database", "DataBase", textDataBase.Text.Trim());
                iniFile.WriteString("Database", "LogID", textLogID.Text.Trim());
                iniFile.WriteString("Database", "LogPass", textLogPass.Text.Trim());

                iniFile.WriteString("LocalHost", "LoaclIP", textIP.Text.Trim());
                iniFile.WriteString("LocalHost", "UDPLocalPort", textUDPPORT.Text.Trim());
                iniFile.WriteString("LocalHost", "TCPLocalPort", textTCPPORT.Text.Trim());


                iniFile.WriteString("MQ", "MQIP", textMQServer.Text.Trim());
                iniFile.WriteString("MQ", "MQPORT", textMQServerPORT.Text.Trim());
                iniFile.WriteString("MQ", "TopicName", textMQTopicName.Text.Trim());


                iniFile.WriteString("Reback", "FTPServer", txtFTPServer.Text.Trim());
                iniFile.WriteString("Reback", "FTPPort", txtFTPPort.Text.Trim());
                iniFile.WriteString("Reback", "FTPUserName", txtFTPUserName.Text.Trim());
                iniFile.WriteString("Reback", "FTPPwd", txtFTPPwd.Text.Trim());
                iniFile.WriteString("Reback", "ftppath", txtftppath.Text.Trim());

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateData()
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox && c.Name != "textLogPass")
                {
                    if (string.IsNullOrWhiteSpace((c as TextBox).Text))
                    {
                        MessageBox.Show(this, c.Tag.ToString() + "未填写");
                        return false;
                    }
                }
            }
            return true;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                base.OnPaintBackground(e);
            }
            catch
            {
                e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);
            }
        }

    }
}
