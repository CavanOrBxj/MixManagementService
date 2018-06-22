using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MixManagementPlatform.Layouts
{
    public partial class CmdServerConfigLayout : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件

        public CmdServerConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(385, 220);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "config.xml");
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
                var elements = from ele in xe.Elements() select ele;
                textUri.Text = elements.FirstOrDefault(ele => ele.Name == "uri").Value;
                textConsumer.Text = elements.FirstOrDefault(ele => ele.Name == "consumer").Value;
                textServer.Text = elements.FirstOrDefault(ele => ele.Name == "server").Value;
                textPort.Text = elements.FirstOrDefault(ele => ele.Name == "port").Value;
            }
            catch(Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化CMDServer配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;
                XElement xe = XElement.Load(Path.Combine(Path.GetDirectoryName(path), "config.xml"));
                var elements = from ele in xe.Elements() select ele;

                elements.FirstOrDefault(ele => ele.Name == "uri").Value = textUri.Text.Trim();
                elements.FirstOrDefault(ele => ele.Name == "consumer").Value = textConsumer.Text.Trim();
                elements.FirstOrDefault(ele => ele.Name == "server").Value = textServer.Text.Trim();
                elements.FirstOrDefault(ele => ele.Name == "port").Value = textPort.Text.Trim();

                xe.Save(Path.Combine(Path.GetDirectoryName(path), "config.xml"));
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
