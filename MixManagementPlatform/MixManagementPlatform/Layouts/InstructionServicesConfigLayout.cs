using MixManagementPlatform.Utils;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MixManagementPlatform.Layouts
{
    public partial class InstructionServicesConfigLayout : UserControl
    {
        private string path;
        private IniFileOperator iniFile;
        private bool hasConfigFile; //是否存在对应的配置文件

        public InstructionServicesConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(395, 563);

            InitMicroMode(cbBoxProtocol);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "InstructionServer.ini");
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

                textMQServerIP.Text = iniFile.ReadString("MQ", "MQIP", "");
                textMQServerPORT.Text = iniFile.ReadString("MQ", "MQPORT", "");
                textMQServerTopicName.Text = iniFile.ReadString("MQ", "TopicName", "");

                cbBoxProtocol.SelectedValue = iniFile.ReadInteger("ProtocolType", "ProtocolType", 1);
                textLocalHost.Text= iniFile.ReadString("LocalHost", "IP", "");

                textTCPReceivePort.Text= iniFile.ReadString("TCP", "ReceivePort", "");

            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化Ts指令服务配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                string configPath = Path.Combine(Path.GetDirectoryName(path), "InstructionServer.ini");
                if(iniFile==null) iniFile = new IniFileOperator(configPath);

                iniFile.WriteString("Database", "ServerName", textServerName.Text.Trim());
                iniFile.WriteString("Database", "DataBase", textDataBase.Text.Trim());
                iniFile.WriteString("Database", "LogID", textLogID.Text.Trim());
                iniFile.WriteString("Database", "LogPass", textLogPass.Text.Trim());

                iniFile.WriteString("MQ", "MQIP", textMQServerIP.Text.Trim());
                iniFile.WriteString("MQ", "MQPORT", textMQServerPORT.Text);
                iniFile.WriteString("MQ", "TopicName", textMQServerTopicName.Text);

                iniFile.WriteInteger("ProtocolType", "ProtocolType", (int)cbBoxProtocol.SelectedValue);

                iniFile.WriteString("LocalHost", "IP", textLocalHost.Text);

                iniFile.WriteString("TCP", "ReceivePort", textTCPReceivePort.Text);
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

        private void InitMicroMode(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Display"] = "广西协议";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = "国标协议";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
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
