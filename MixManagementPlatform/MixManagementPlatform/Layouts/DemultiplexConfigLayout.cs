using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MixManagementPlatform.Layouts
{
    public partial class DemultiplexConfigLayout : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件

        public DemultiplexConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(405, 235);
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
                MixLogHelper.Error(GetType().Name, "初始化Demultiplex配置文件异常", e.StackTrace);
            }
            
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                XElement xe = XElement.Load(Path.Combine(Path.GetDirectoryName(path), "Skin", "Main_dlg.xml"));
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
