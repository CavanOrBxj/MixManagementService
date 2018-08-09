namespace MixManagementPlatform.Layouts
{
    partial class WAV2MP3
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMP3FilePath = new System.Windows.Forms.TextBox();
            this.txtWAVFilePath = new System.Windows.Forms.TextBox();
            this.lblEdt_Localport = new System.Windows.Forms.Label();
            this.lblEdt_LoalIP = new System.Windows.Forms.Label();
            this.lblFile = new ControlAstro.Controls.LabelButton();
            this.lblFileMon = new ControlAstro.Controls.LabelButton();
            this.fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtMP3FilePath
            // 
            this.txtMP3FilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMP3FilePath.Location = new System.Drawing.Point(138, 173);
            this.txtMP3FilePath.Name = "txtMP3FilePath";
            this.txtMP3FilePath.Size = new System.Drawing.Size(211, 21);
            this.txtMP3FilePath.TabIndex = 45;
            this.txtMP3FilePath.Tag = "网卡端口";
            // 
            // txtWAVFilePath
            // 
            this.txtWAVFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWAVFilePath.Location = new System.Drawing.Point(138, 123);
            this.txtWAVFilePath.Name = "txtWAVFilePath";
            this.txtWAVFilePath.Size = new System.Drawing.Size(211, 21);
            this.txtWAVFilePath.TabIndex = 44;
            this.txtWAVFilePath.Tag = "";
            // 
            // lblEdt_Localport
            // 
            this.lblEdt_Localport.AutoSize = true;
            this.lblEdt_Localport.Location = new System.Drawing.Point(31, 177);
            this.lblEdt_Localport.Name = "lblEdt_Localport";
            this.lblEdt_Localport.Size = new System.Drawing.Size(71, 12);
            this.lblEdt_Localport.TabIndex = 47;
            this.lblEdt_Localport.Text = "MP3存放路径";
            // 
            // lblEdt_LoalIP
            // 
            this.lblEdt_LoalIP.AutoSize = true;
            this.lblEdt_LoalIP.Location = new System.Drawing.Point(31, 127);
            this.lblEdt_LoalIP.Name = "lblEdt_LoalIP";
            this.lblEdt_LoalIP.Size = new System.Drawing.Size(89, 12);
            this.lblEdt_LoalIP.TabIndex = 46;
            this.lblEdt_LoalIP.Text = "音频文件夹路径";
            // 
            // lblFile
            // 
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.lblFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F);
            this.lblFile.Location = new System.Drawing.Point(355, 123);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(25, 20);
            this.lblFile.TabIndex = 56;
            this.lblFile.Text = "...";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFile.Click += new System.EventHandler(this.lblFile_Click);
            // 
            // lblFileMon
            // 
            this.lblFileMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileMon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.lblFileMon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFileMon.Font = new System.Drawing.Font("宋体", 9F);
            this.lblFileMon.Location = new System.Drawing.Point(355, 173);
            this.lblFileMon.Name = "lblFileMon";
            this.lblFileMon.Size = new System.Drawing.Size(25, 20);
            this.lblFileMon.TabIndex = 57;
            this.lblFileMon.Text = "...";
            this.lblFileMon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFileMon.Click += new System.EventHandler(this.lblFileMon_Click);
            // 
            // WAV2MP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblFileMon);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtMP3FilePath);
            this.Controls.Add(this.txtWAVFilePath);
            this.Controls.Add(this.lblEdt_Localport);
            this.Controls.Add(this.lblEdt_LoalIP);
            this.DoubleBuffered = true;
            this.Name = "WAV2MP3";
            this.Size = new System.Drawing.Size(405, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMP3FilePath;
        private System.Windows.Forms.TextBox txtWAVFilePath;
        private System.Windows.Forms.Label lblEdt_Localport;
        private System.Windows.Forms.Label lblEdt_LoalIP;
        private ControlAstro.Controls.LabelButton lblFile;
        private ControlAstro.Controls.LabelButton lblFileMon;
        private System.Windows.Forms.FolderBrowserDialog fileDialog;
    }
}
