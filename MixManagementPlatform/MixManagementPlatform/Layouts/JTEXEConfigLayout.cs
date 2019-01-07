using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MixManagementPlatform.Layouts
{
    public partial class JTEXEConfigLayout : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件

        public JTEXEConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(385, 274);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "JT.exe.config");
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
                XmlDocument dom = new XmlDocument();
                dom.Load(configPath);

                System.Xml.XmlNode root = dom.SelectSingleNode("configuration");

                string strConfig = @"configuration/connectionStrings/add";

                System.Xml.XmlNode node = dom.SelectSingleNode(strConfig);
                string[]  pps=node.Attributes["connectionString"].Value.Split(';');
                string JTSQLIP = "", JTDataBase = "", JTLogID = "", JTLogPass="";
                for (int i = 0; i < pps.Length; i++)
                {
                    if (pps[i].Contains("Data Source"))
                    {
                        JTSQLIP = pps[i].Split('=')[1];
                    }

                    if (pps[i].Contains("Initial Catalog"))
                    {
                        JTDataBase = pps[i].Split('=')[1];
                    }

                    if (pps[i].Contains("User ID"))
                    {
                        JTLogID = pps[i].Split('=')[1];
                    }

                    if (pps[i].Contains("Password"))
                    {
                        JTLogPass = pps[i].Split('=')[1];
                    }
                }

                txtJTSQLIP.Text = JTSQLIP;
                txtJTDataBase.Text = JTDataBase;
                txtJTLogID.Text = JTLogID;
                txtJTLogPass.Text = JTLogPass;


                string strConfigString = @"configuration/userSettings/CarMS.Properties.Settings/setting[@name='{0}']/value";
                System.Xml.XmlNode xmlNodeComOne = dom.SelectSingleNode(string.Format(strConfigString, "ComOne"));
                txtJTLocalHost.Text = xmlNodeComOne.InnerText;
                System.Xml.XmlNode xmlNodeBotOne = dom.SelectSingleNode(string.Format(strConfigString, "BotOne"));
                txtJTPort.Text = xmlNodeBotOne.InnerText;
            }
            catch(Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化JTEXE配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                string configPath = Path.Combine(Path.GetDirectoryName(path), "JT.exe.config");
           
                XmlDocument dom = new XmlDocument();
                dom.Load(configPath);
                string strConfigString = @"configuration/userSettings/CarMS.Properties.Settings/setting[@name='{0}']/value";
                System.Xml.XmlNode xmlNodeComOne = dom.SelectSingleNode(string.Format(strConfigString, "ComOne"));
                xmlNodeComOne.InnerText = txtJTLocalHost.Text;

                System.Xml.XmlNode xmlNodeBotOne = dom.SelectSingleNode(string.Format(strConfigString, "BotOne"));
                xmlNodeBotOne.InnerText = txtJTPort.Text;


                string strConfig = @"configuration/connectionStrings/add";

                System.Xml.XmlNode node = dom.SelectSingleNode(strConfig);
                node.Attributes["connectionString"].Value = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", txtJTSQLIP.Text, txtJTDataBase.Text, txtJTLogID.Text, txtJTLogPass.Text);

                dom.Save(configPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateData()
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox)
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
