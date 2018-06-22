using MixManagementPlatform.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MixManagementPlatform.Layouts
{
    public partial class RecordConfigLayout : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件
        private IniFileOperator iniFile;

        public RecordConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(405, 345);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "Skin", "Main_dlg.xml");
                string configPathIni = Path.Combine(Path.GetDirectoryName(path), "Config.ini");
                if (System.Configuration.ConfigurationManager.AppSettings["LogConfigPathFlag"] != "0")
                {
                    MixLogHelper.Info(GetType().Name, configPath);
                    MixLogHelper.Info(GetType().Name, configPathIni);
                }
                hasConfigFile = File.Exists(configPath) && File.Exists(configPathIni);
                if (!File.Exists(configPath)|| !File.Exists(configPathIni))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                if (iniFile == null || iniFile.IniFileName != configPathIni) iniFile = new IniFileOperator(configPathIni);
                textHost.Text = iniFile.ReadString("HostConfig", "Host", "");
                textPort.Text = iniFile.ReadString("HostConfig", "Port", "");
                textUserName.Text = iniFile.ReadString("HostConfig", "UserName", "");
                textWatchWord.Text = Encoding.Default.GetString(Convert.FromBase64String(iniFile.ReadString("HostConfig", "WatchWord", "")));
                
                XElement xe = XElement.Load(configPath);
                var editElements = xe.XPathSelectElements("//Edit");
                textEdt_InputIP.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_InputIP").Attribute("text").Value;
                textEdt_InputPort.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_InputPort").Attribute("text").Value;
                textEdt_SeverIP.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_SeverIP").Attribute("text").Value;
                textEdt_ServerPort.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_ServerPort").Attribute("text").Value;
                textEdt_LoalIP.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_LoalIP").Attribute("text").Value;
                textEdt_Localport.Text = editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_Localport").Attribute("text").Value;
            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化Record配置文件异常", e.StackTrace);
            }
            
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                string configPath = Path.Combine(Path.GetDirectoryName(path), "Skin", "Main_dlg.xml");
                string configPathIni = Path.Combine(Path.GetDirectoryName(path), "Config.ini");

                if (iniFile == null || iniFile.IniFileName != configPathIni) iniFile = new IniFileOperator(configPathIni);
                iniFile.WriteString("HostConfig", "Host", textHost.Text.Trim());
                iniFile.WriteString("HostConfig", "Port", textPort.Text.Trim());
                iniFile.WriteString("HostConfig", "UserName", textUserName.Text.Trim());
                iniFile.WriteString("HostConfig", "WatchWord", Convert.ToBase64String(Encoding.Default.GetBytes(textWatchWord.Text.Trim())));

                XElement xe = XElement.Load(configPath);
                var editElements = xe.XPathSelectElements("//Edit");
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_InputIP").Attribute("text").Value = textEdt_InputIP.Text.Trim();
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_InputPort").Attribute("text").Value = textEdt_InputPort.Text.Trim();
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_SeverIP").Attribute("text").Value = textEdt_SeverIP.Text.Trim();
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_ServerPort").Attribute("text").Value = textEdt_ServerPort.Text.Trim();
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_LoalIP").Attribute("text").Value = textEdt_LoalIP.Text.Trim();
                editElements.FirstOrDefault(q => q.Attribute("name").Value == "edt_Localport").Attribute("text").Value = textEdt_Localport.Text.Trim();

                xe.Save(Path.Combine(Path.GetDirectoryName(path), "Skin", "Main_dlg.xml"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateData()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
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
