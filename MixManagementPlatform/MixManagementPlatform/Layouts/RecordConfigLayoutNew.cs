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
    public partial class RecordConfigLayoutNew : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件
        private IniFileOperator iniFile;

        public RecordConfigLayoutNew(string path)
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "DataTranNewGUI.exe");
             
                hasConfigFile = File.Exists(configPath);
                if (!File.Exists(configPath))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                txtSliceCount.Text = AppConfigurator.GetAppConfig("SliceCount", configPath);
                txtSliceTime.Text = AppConfigurator.GetAppConfig("SliceTime", configPath);
                textServerIp.Text = AppConfigurator.GetAppConfig("ServerIP", configPath);
                txtServerPort.Text = AppConfigurator.GetAppConfig("ServerPort", configPath);
                txtBasePath.Text = AppConfigurator.GetAppConfig("BasePath", configPath);
                txtMonBasePath.Text = AppConfigurator.GetAppConfig("MonBasePath", configPath);
                txtFTPHost.Text = AppConfigurator.GetAppConfig("FTPHost", configPath);
                txtFTPPort.Text = AppConfigurator.GetAppConfig("FTPPort", configPath);
                txtFTPUserName.Text = AppConfigurator.GetAppConfig("FTPUserName", configPath);
                txtFTPPwd.Text = AppConfigurator.GetAppConfig("FTPPwd", configPath);
         
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "DataTranNewGUI.exe");

                AppConfigurator.UpdateAppSettingsConfig("SliceCount", txtSliceCount.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("SliceTime", txtSliceTime.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("ServerIP", textServerIp.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("ServerPort", txtServerPort.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("BasePath", txtBasePath.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("MonBasePath", txtMonBasePath.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("FTPHost", txtFTPHost.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("FTPPort", txtFTPPort.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("FTPUserName", txtFTPUserName.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("FTPPwd", txtFTPPwd.Text, configPath);
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

        private void lblFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBasePath.Text = fileDialog.SelectedPath;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void lblFileMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtMonBasePath.Text = fileDialog.SelectedPath;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtSliceCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = txtSliceCount.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSliceTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = txtSliceTime.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void txtServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = txtServerPort.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void txtFTPPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                int len = txtFTPPort.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
    }
}
