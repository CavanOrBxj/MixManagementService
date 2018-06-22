using ControlAstro.Forms;
using ControlAstro.Utils;
using MixManagementPlatform.EntityModule;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FormStartIndex : UserForm
    {
        private List<TModule> list;
        private readonly string ClassName;

        public FormStartIndex(Form form, BindingCollection<TModule> moduleList)
        {
            InitializeComponent();
            ClassName = GetType().Name;

            BackColor = form.BackColor;
            if (form is UserForm && (form as UserForm).BackBrush != null)
            {
                BackBrush = (form as UserForm).BackBrush;
                BackAngle = (form as UserForm).BackAngle;
            }

            try
            {
                dgvModule.AutoGenerateColumns = false;
                list = moduleList.Where(m => m.autostart != 0).ToList();
                dgvModule.DataSource = list;
                btnUp.Enabled = list.Count > 1;
                btnDown.Enabled = list.Count > 1;
            }
            catch(Exception e)
            {
                MixLogHelper.Error(ClassName, "初始化启动模块数据异常  ", e.StackTrace);
            }
        }

        public List<TModule> GetStartIndex()
        {
            return list;
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (dgvModule.SelectedRows.Count > 0)
            {
                var index = dgvModule.SelectedRows[0].Index;
                list.Reverse(index - 1, 2);
                dgvModule.Rows[index - 1].Selected = true;
                dgvModule.Invalidate();
                dgvModule_SelectionChanged(dgvModule, System.EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(this, "未选中模块");
            }
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (dgvModule.SelectedRows.Count > 0)
            {
                var index = dgvModule.SelectedRows[0].Index;
                list.Reverse(index, 2);
                dgvModule.Rows[index + 1].Selected = true;
                dgvModule.Invalidate();
                dgvModule_SelectionChanged(dgvModule, System.EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(this, "未选中模块");
            }
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            if (list.Count > 1)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void dgvModule_SelectionChanged(object sender, System.EventArgs e)
        {
            if(dgvModule.RowCount > 1)
            {
                if (dgvModule.SelectedRows.Count > 0)
                {
                    btnUp.Enabled = dgvModule.SelectedRows[0].Index != 0;
                    btnDown.Enabled = dgvModule.SelectedRows[0].Index != dgvModule.RowCount - 1;
                }
            }
        }

    }
}
