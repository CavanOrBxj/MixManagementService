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
    public partial class WAV2MP3 : UserControl
    {
        private string path;
        private bool hasConfigFile; //是否存在对应的配置文件
        private IniFileOperator iniFile;

        public WAV2MP3(string path)
        {
            InitializeComponent();
            Size = new Size(405, 291);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "Config.ini");
             
                hasConfigFile = File.Exists(configPath);
                if (!File.Exists(configPath))
                {
                    MessageBox.Show(this, "配置文件不存在");
                    return;
                }
                txtWAVFilePath.Text = AppConfigurator.GetAppConfig("BasePath", configPath);
                txtMP3FilePath.Text = AppConfigurator.GetAppConfig("MonBasePath", configPath);
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
                string configPath = Path.Combine(Path.GetDirectoryName(path), "Config.ini");
                
                AppConfigurator.UpdateAppSettingsConfig("BasePath", txtWAVFilePath.Text, configPath);
                AppConfigurator.UpdateAppSettingsConfig("MonBasePath", txtMP3FilePath.Text, configPath);
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
                    txtWAVFilePath.Text = fileDialog.SelectedPath;
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
                    txtMP3FilePath.Text = fileDialog.SelectedPath;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
