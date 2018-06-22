using ControlAstro.Forms;
using MixManagementPlatform.EntityModule;
using System.Data;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FormModule : UserForm
    {
        public TModule NewModule { get; set; }
        private int type;  //0是查看，1是更新，2是添加

        public FormModule(Form form, int type, TModule module = null)
        {
            InitializeComponent();
            NewModule = module ?? new TModule();
            BackColor = form.BackColor;
            if (form is UserForm && (form as UserForm).BackBrush != null)
            {
                BackBrush = (form as UserForm).BackBrush;
                BackAngle = (form as UserForm).BackAngle;
            }
            this.type = type;
            InitModuleType(cbBoxType);
            InitData(module);
        }

        private void InitData(TModule module)
        {
            //0是查看，1是更新，2是添加
            switch(type)
            {
                case 0:
                    Text = "查询模块信息";
                    cbBoxType.Enabled = false;
                    textBoxName.ReadOnly = true;
                    checkBoxAutoStart.Enabled = false;
                    textBoxDelay.ReadOnly = true;
                    textBoxArguments.ReadOnly = true;
                    lblFile.Enabled = false;
                    break;
                case 1:
                    Text = "更新模块信息";
                    cbBoxType.Enabled = true;
                    textBoxName.ReadOnly = false;
                    checkBoxAutoStart.Enabled = true;
                    textBoxDelay.ReadOnly = false;
                    textBoxArguments.ReadOnly = false;
                    lblFile.Enabled = true;
                    break;
                case 2:
                    Text = "添加模块信息";
                    cbBoxType.Enabled = true;
                    textBoxName.ReadOnly = false;
                    checkBoxAutoStart.Enabled = true;
                    textBoxDelay.ReadOnly = false;
                    textBoxArguments.ReadOnly = false;
                    lblFile.Enabled = true;
                    break;
            }
            if (type != 2)
            {
                textBoxName.Text = module.name;
                textBoxLocation.Text = module.path;
                checkBoxAutoStart.Checked = module.autostart != 0;
                textBoxDelay.Text = module.delay.ToString();
                textBoxArguments.Text = module.arguments;
                cbBoxType.SelectedValue = module.temtype;
            }
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            if (type == 0)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            if (!ValidateData()) return;
            NewModule.temtype = (int)cbBoxType.SelectedValue;
            NewModule.name = textBoxName.Text.Trim();
            NewModule.path = textBoxLocation.Text.Trim();
            NewModule.autostart = checkBoxAutoStart.Checked ? 1 : 0;
            NewModule.delay = string.IsNullOrWhiteSpace(textBoxDelay.Text) ? 0 : int.Parse(textBoxDelay.Text.Trim());
            if (!checkBoxAutoStart.Checked)
            {
                NewModule.startindex = 0;
            }
            else
            {
                NewModule.startindex = NewModule.startindex == 0 ? 1 : NewModule.startindex;
            }
            NewModule.arguments = textBoxArguments.Text.Trim() ?? string.Empty;
            if (type == 2) NewModule.state = -1;
            DialogResult = DialogResult.OK;
        }

        private void lblFileOpen_Click(object sender, System.EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLocation.Text = fileDialog.FileName;
            }
        }

        private bool ValidateData()
        {
            if(string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show(this, "模块名不能为空", "提示");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxLocation.Text))
            {
                MessageBox.Show(this, "模块路径不能为空", "提示");
                return false;
            }
            return true;
        }

        private void InitModuleType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Display"] = FormMain.ModuleType[0];
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = FormMain.ModuleType[1];
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = FormMain.ModuleType[2];
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = FormMain.ModuleType[3];
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = FormMain.ModuleType[4];
            dr["Value"] = 4;
            dt.Rows.Add(dr);
            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

        private void cbBoxType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(type == 2)
            {
                switch ((int)cbBoxType.SelectedValue)
                {
                    case 0:
                        textBoxName.Text = FormMain.ModuleType[0];
                        textBoxArguments.Text = "001 user 001";
                        break;
                    case 1:
                        textBoxName.Text = FormMain.ModuleType[1];
                        textBoxArguments.Text = "auto";
                        break;
                    case 2:
                        textBoxName.Text = FormMain.ModuleType[2];
                        textBoxArguments.Text = string.Empty;
                        break;
                    case 3:
                        textBoxName.Text = FormMain.ModuleType[3];
                        textBoxArguments.Text = "auto";
                        break;
                    case 4:
                        textBoxName.Text = FormMain.ModuleType[4];
                        textBoxArguments.Text = "auto";
                        break;
                }
                checkBoxAutoStart.Checked = true;
            }
        }
    }
}
