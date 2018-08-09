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
        private Layouts.RecordConfigLayoutNew pnlRecordNew;
        private Layouts.ReturnserviceConfigLayout pnlReturnservice;//6
        private Layouts.InstructionServicesConfigLayout pnlInstructionServices;//5
        private Layouts.WAV2MP3 pnlwav2mp3;//8

        private Layouts.Universaldisplay pnluniversal;


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
                    pnlRecordNew = new Layouts.RecordConfigLayoutNew(path);
                    pnlRecordNew.Location = new Point(5, 45);
                    pnlRecordNew.BackColor = Color.Transparent;
                    Controls.Add(pnlRecordNew);
                    Size = new Size(pnlRecordNew.Width + 15, pnlRecordNew.Height + 115);
                    break;

                case 5:
                    pnlInstructionServices = new Layouts.InstructionServicesConfigLayout(path);
                    pnlInstructionServices.Location = new Point(5, 45);
                    pnlInstructionServices.BackColor = Color.Transparent;
                    Controls.Add(pnlInstructionServices);
                    // Size = new Size(pnlInstructionServices.Width + 15, pnlInstructionServices.Height + 115);
                    Size = new Size(pnlInstructionServices.Width +15, pnlInstructionServices.Height+115);
                    break;
                case 6:
                    pnlReturnservice = new Layouts.ReturnserviceConfigLayout(path);
                    pnlReturnservice.Location = new Point(5, 45);
                    pnlReturnservice.BackColor = Color.Transparent;
                    Controls.Add(pnlReturnservice);
                    Size = new Size(pnlReturnservice.Width, pnlReturnservice.Height + 115);
                    break;

                case 8:
                    pnlwav2mp3 = new Layouts.WAV2MP3(path);
                    pnlwav2mp3.Location = new Point(5, 45);
                    pnlwav2mp3.BackColor = Color.Transparent;
                    Controls.Add(pnlwav2mp3);
                    Size = new Size(pnlwav2mp3.Width, pnlwav2mp3.Height + 115);
                    break;

                case 7:
                case 9:
                case 10:
                    pnluniversal = new Layouts.Universaldisplay(path);
                    pnluniversal.Location = new Point(5, 45);
                    pnluniversal.BackColor = Color.Transparent;
                    Controls.Add(pnluniversal);
                    Size = new Size(pnluniversal.Width, pnlwav2mp3.Height + 115);
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
                    if (!pnlRecordNew.ValidateData()) return;
                    saveSuccessed = pnlRecordNew.SaveData();
                    break;

                case 5:
                    if (!pnlInstructionServices.ValidateData()) return;
                    saveSuccessed = pnlInstructionServices.SaveData();
                    break;

                case 6:
                    if (!pnlReturnservice.ValidateData()) return;
                    saveSuccessed = pnlReturnservice.SaveData();
                    break;

                case 8:
                    if (!pnlwav2mp3.ValidateData()) return;
                    saveSuccessed = pnlwav2mp3.SaveData();
                    break;
            }
            DialogResult = saveSuccessed ? DialogResult.OK : DialogResult.Ignore;
        }

    }
}
