using MixManagementPlatform.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MixManagementPlatform.Layouts
{
    public partial class TomcatServerConfigLayout : UserControl
    {
        //数据库地址 jdbc:jtds:sqlserver://localhost:1433/voladorkb
        //MQ地址 tcp://localhost:61616
        //文件地址 http://192.168.4.87:8080/ch-eoc/upload/
        //项目地址
        //adminUserOrgCode P37
        //updateSrvTime 
        //updateSrvStatus
        private string path;
        private PropertyFileOperator propertyFileOperator;
        private bool hasConfigFile; //是否存在对应的配置文件

        public TomcatServerConfigLayout(string path)
        {
            InitializeComponent();
            Size = new Size(420, 230);
            this.path = path;
            if (path != null && !string.IsNullOrWhiteSpace(path))
            {
                this.path = Directory.GetParent(Path.GetDirectoryName(path)).FullName;
                InitData();
            }
        }

        private void InitData()
        {
            try
            {
                string configPath1 = Path.Combine(path, @"webapps\ginkgo\WEB-INF\classes", "db.properties");
                string configPath2 = Path.Combine(path, @"webapps\ginkgo\WEB-INF", "web.xml");
                string configPath3 = Path.Combine(path, @"conf", "server.xml");

                if(System.Configuration.ConfigurationManager.AppSettings["LogConfigPathFlag"] != "0")
                {
                    MixLogHelper.Info(GetType().Name, configPath1);
                    MixLogHelper.Info(GetType().Name, configPath2);
                    MixLogHelper.Info(GetType().Name, configPath3);
                }
                hasConfigFile = File.Exists(configPath1) && File.Exists(configPath2);
                if (!File.Exists(configPath1) || !File.Exists(configPath2))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                propertyFileOperator = new PropertyFileOperator(configPath1);
                textJDBCUrl.Text = propertyFileOperator.GetPropertiesText("jdbcUrl");
                textBrokerUrl.Text = propertyFileOperator.GetPropertiesText("brokerURL");
                textAdminUserOrgCode.Text = propertyFileOperator.GetPropertiesText("adminUserOrgCode");
                textUpdateSrvTime.Text = propertyFileOperator.GetPropertiesText("updateSrvTime");
                textUpdateSrvStatus.Text = propertyFileOperator.GetPropertiesText("updateSrvStatus");

                XElement xeWeb = XElement.Load(configPath2);
                var elements = xeWeb.XPathSelectElements("//*");
                var media = elements.FirstOrDefault(ele => ele.Name.LocalName == "param-name" && ele.Value == "mediaUrl");
                var value = (media.NextNode as XElement).Value;
                textMediaUrl.Text = value;

                //XElement xeServer = XElement.Load(configPath3);
                //var contextElements = xeServer.XPathSelectElements("//Context");
                //textDocBase.Text = contextElements.FirstOrDefault(q => q.Attributes("docBase").Count() > 0).Attribute("docBase").Value;
            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "初始化CMDServer配置文件异常", e.StackTrace);
            }
        }

        public bool SaveData()
        {
            try
            {
                if (!hasConfigFile) return false;

                string configPath2 = Path.Combine(path, @"webapps\ginkgo\WEB-INF", "web.xml");
                XElement xe = XElement.Load(configPath2);
                var elements = xe.XPathSelectElements("//*");
                var media = elements.FirstOrDefault(ele => ele.Name.LocalName == "param-name" && ele.Value == "mediaUrl");
                (media.NextNode as XElement).Value = textMediaUrl.Text.Trim();
                xe.Save(configPath2);

                //string configPath3 = Path.Combine(path, @"conf", "server.xml");
                //XElement xeServer = XElement.Load(configPath3);
                //var contextElements = xeServer.XPathSelectElements("//Context");
                //contextElements.FirstOrDefault(q => q.Attributes("docBase").Count() > 0).Attribute("docBase").Value = textDocBase.Text.Trim();
                //xeServer.Save(configPath3);

                if (propertyFileOperator == null)
                {
                    string configPath1 = Path.Combine(path, @"webapps\ginkgo\WEB-INF\classes", "db.properties");
                    propertyFileOperator = new PropertyFileOperator(configPath1);
                }
                propertyFileOperator.SetPropertiesText("jdbcUrl", textJDBCUrl.Text.Trim());
                propertyFileOperator.SetPropertiesText("brokerURL", textBrokerUrl.Text.Trim());
                propertyFileOperator.SetPropertiesText("adminUserOrgCode", textAdminUserOrgCode.Text.Trim());
                propertyFileOperator.SetPropertiesText("updateSrvTime", textUpdateSrvTime.Text.Trim());
                propertyFileOperator.SetPropertiesText("updateSrvStatus", textUpdateSrvStatus.Text.Trim());
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
                if (c is TextBox && c.Enabled)
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
