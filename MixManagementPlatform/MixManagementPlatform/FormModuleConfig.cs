using ControlAstro.Forms;
using MixManagementPlatform.EntityModule;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FormModuleConfig : UserForm
    {
        private int type;
        private Layouts.TsSheduleCenterConfigLayout pnlTsSheduleCenter;
        private Layouts.CmdServerConfigLayout pnlCmdServer;
        private Layouts.TomcatServerConfigLayout pnlTomcat;
        private Layouts.DemultiplexConfigLayout pnlDemultiplex;
        private Layouts.RecordConfigLayout pnlRecord;

        public FormModuleConfig(Form form, int type, string path = null)
        {
            InitializeComponent();
            BackColor = form.BackColor;
            if (form is UserForm && (form as UserForm).BackBrush != null)
            {
                BackBrush = (form as UserForm).BackBrush;
                BackAngle = (form as UserForm).BackAngle;
            }
            this.type = type;

            InitData(path);
        }

        public FormModuleConfig(Form form, TModule module) : this(form, module.temtype, module.path)
        {
        }



        private void InitData(string path)
        {
            Text = "参数配置-" + FormMain.ModuleType[type];
            switch (type)
            {
                case 0:
                    pnlTsSheduleCenter = new Layouts.TsSheduleCenterConfigLayout(path);
                    pnlTsSheduleCenter.Location = new Point(3, 40);
                    pnlTsSheduleCenter.BackColor = Color.Transparent;
                    Controls.Add(pnlTsSheduleCenter);
                    Size = new Size(pnlTsSheduleCenter.Width + 5, pnlTsSheduleCenter.Height + 110);
                    break;
                case 1:
                    pnlCmdServer = new Layouts.CmdServerConfigLayout(path);
                    pnlCmdServer.Location = new Point(5, 45);
                    pnlCmdServer.BackColor = Color.Transparent;
                    Controls.Add(pnlCmdServer);
                    Size = new Size(pnlCmdServer.Width + 15, pnlCmdServer.Height + 115);
                    break;
                case 2:
                    pnlTomcat = new Layouts.TomcatServerConfigLayout(path);
                    pnlTomcat.Location = new Point(5, 45);
                    pnlTomcat.BackColor = Color.Transparent;
                    Controls.Add(pnlTomcat);
                    Size = new Size(pnlTomcat.Width + 15, pnlTomcat.Height + 115);
                    break;
                case 3:
                    pnlDemultiplex = new Layouts.DemultiplexConfigLayout(path);
                    pnlDemultiplex.Location = new Point(5, 45);
                    pnlDemultiplex.BackColor = Color.Transparent;
                    Controls.Add(pnlDemultiplex);
                    Size = new Size(pnlDemultiplex.Width + 15, pnlDemultiplex.Height + 115);
                    break;
                case 4:
                    pnlRecord = new Layouts.RecordConfigLayout(path);
                    pnlRecord.Location = new Point(5, 45);
                    pnlRecord.BackColor = Color.Transparent;
                    Controls.Add(pnlRecord);
                    Size = new Size(pnlRecord.Width + 15, pnlRecord.Height + 115);
                    break;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            bool saveSuccessed = false;
            switch (type)
            {
                case 0:
                    if (!pnlTsSheduleCenter.ValidateData()) return;
                    saveSuccessed = pnlTsSheduleCenter.SaveData();
                    break;
                case 1:
                    if (!pnlCmdServer.ValidateData()) return;
                    saveSuccessed = pnlCmdServer.SaveData();
                    break;
                case 2:
                    if (!pnlTomcat.ValidateData()) return;
                    saveSuccessed = pnlTomcat.SaveData();
                    break;
                case 3:
                    if (!pnlDemultiplex.ValidateData()) return;
                    saveSuccessed = pnlDemultiplex.SaveData();
                    break;
                case 4:
                    if (!pnlRecord.ValidateData()) return;
                    saveSuccessed = pnlRecord.SaveData();
                    break;
            }
            DialogResult = saveSuccessed ? DialogResult.OK : DialogResult.Ignore;
        }

    }
}
