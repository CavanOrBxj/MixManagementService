using ControlAstro.Forms;
using System;
using System.Collections.Generic;

namespace MixManagementPlatform
{
    public partial class FormDataBaseConfig : UserForm
    {
        public FormDataBaseConfig()
        {
            InitializeComponent();
            Load += FormDataBaseConfig_Load;
        }

        private void FormDataBaseConfig_Load(object sender, EventArgs e)
        {
            var appSettings = System.Configuration.ConfigurationManager.AppSettings;
            textServerIp.Text = appSettings["DatabaseServerIP"];
            textUser.Text = appSettings["DatabaseUser"];
            textPwd.Text = appSettings["DatabasePwd"];
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textServerIp.Text))
            {
                System.Windows.Forms.MessageBox.Show(this, "数据库IP地址不能为空");
                return;
            }

            AppConfigurator.UpdateAppConfig("DatabaseServerIP", textServerIp.Text.Trim());
            AppConfigurator.UpdateAppConfig("DatabaseUser", textUser.Text.Trim());
            AppConfigurator.UpdateAppConfig("DatabasePwd", textPwd.Text.Trim());

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
