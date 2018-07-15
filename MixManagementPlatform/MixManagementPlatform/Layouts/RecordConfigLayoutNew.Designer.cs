namespace MixManagementPlatform.Layouts
{
    partial class RecordConfigLayoutNew
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
            this.txtMonBasePath = new System.Windows.Forms.TextBox();
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.lblEdt_Localport = new System.Windows.Forms.Label();
            this.lblEdt_LoalIP = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lblEdt_ServerPort = new System.Windows.Forms.Label();
            this.lblEdt_SeverIP = new System.Windows.Forms.Label();
            this.txtSliceTime = new System.Windows.Forms.TextBox();
            this.txtSliceCount = new System.Windows.Forms.TextBox();
            this.lblEdt_InputPort = new System.Windows.Forms.Label();
            this.lblEdt_InputIP = new System.Windows.Forms.Label();
            this.txtFTPPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtFTPPwd = new System.Windows.Forms.TextBox();
            this.txtFTPUserName = new System.Windows.Forms.TextBox();
            this.lblWatchWord = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFile = new ControlAstro.Controls.LabelButton();
            this.lblFileMon = new ControlAstro.Controls.LabelButton();
            this.textServerIp = new IPAddressControlLib.IPAddressControl();
            this.txtFTPHost = new IPAddressControlLib.IPAddressControl();
            this.fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtMonBasePath
            // 
            this.txtMonBasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonBasePath.Location = new System.Drawing.Point(138, 173);
            this.txtMonBasePath.Name = "txtMonBasePath";
            this.txtMonBasePath.Size = new System.Drawing.Size(211, 21);
            this.txtMonBasePath.TabIndex = 45;
            this.txtMonBasePath.Tag = "网卡端口";
            // 
            // txtBasePath
            // 
            this.txtBasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBasePath.Location = new System.Drawing.Point(138, 144);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(211, 21);
            this.txtBasePath.TabIndex = 44;
            this.txtBasePath.Tag = "网卡地址";
            // 
            // lblEdt_Localport
            // 
            this.lblEdt_Localport.AutoSize = true;
            this.lblEdt_Localport.Location = new System.Drawing.Point(31, 177);
            this.lblEdt_Localport.Name = "lblEdt_Localport";
            this.lblEdt_Localport.Size = new System.Drawing.Size(77, 12);
            this.lblEdt_Localport.TabIndex = 47;
            this.lblEdt_Localport.Text = "监听基础路径";
            // 
            // lblEdt_LoalIP
            // 
            this.lblEdt_LoalIP.AutoSize = true;
            this.lblEdt_LoalIP.Location = new System.Drawing.Point(31, 148);
            this.lblEdt_LoalIP.Name = "lblEdt_LoalIP";
            this.lblEdt_LoalIP.Size = new System.Drawing.Size(77, 12);
            this.lblEdt_LoalIP.TabIndex = 46;
            this.lblEdt_LoalIP.Text = "录音基础路径";
            // 
            // txtServerPort
            // 
            this.txtServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerPort.Location = new System.Drawing.Point(138, 111);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(211, 21);
            this.txtServerPort.TabIndex = 40;
            this.txtServerPort.Tag = "服务器地址";
            this.txtServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServerPort_KeyPress);
            // 
            // lblEdt_ServerPort
            // 
            this.lblEdt_ServerPort.AutoSize = true;
            this.lblEdt_ServerPort.Location = new System.Drawing.Point(31, 115);
            this.lblEdt_ServerPort.Name = "lblEdt_ServerPort";
            this.lblEdt_ServerPort.Size = new System.Drawing.Size(65, 12);
            this.lblEdt_ServerPort.TabIndex = 43;
            this.lblEdt_ServerPort.Text = "服务器端口";
            // 
            // lblEdt_SeverIP
            // 
            this.lblEdt_SeverIP.AutoSize = true;
            this.lblEdt_SeverIP.Location = new System.Drawing.Point(31, 85);
            this.lblEdt_SeverIP.Name = "lblEdt_SeverIP";
            this.lblEdt_SeverIP.Size = new System.Drawing.Size(65, 12);
            this.lblEdt_SeverIP.TabIndex = 42;
            this.lblEdt_SeverIP.Text = "服务器地址";
            // 
            // txtSliceTime
            // 
            this.txtSliceTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSliceTime.Location = new System.Drawing.Point(138, 49);
            this.txtSliceTime.Name = "txtSliceTime";
            this.txtSliceTime.Size = new System.Drawing.Size(211, 21);
            this.txtSliceTime.TabIndex = 37;
            this.txtSliceTime.Tag = "组播流端口";
            this.txtSliceTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSliceTime_KeyPress);
            // 
            // txtSliceCount
            // 
            this.txtSliceCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSliceCount.Location = new System.Drawing.Point(138, 21);
            this.txtSliceCount.Name = "txtSliceCount";
            this.txtSliceCount.Size = new System.Drawing.Size(211, 21);
            this.txtSliceCount.TabIndex = 36;
            this.txtSliceCount.Tag = "组播流地址";
            this.txtSliceCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSliceCount_KeyPress);
            // 
            // lblEdt_InputPort
            // 
            this.lblEdt_InputPort.AutoSize = true;
            this.lblEdt_InputPort.Location = new System.Drawing.Point(31, 53);
            this.lblEdt_InputPort.Name = "lblEdt_InputPort";
            this.lblEdt_InputPort.Size = new System.Drawing.Size(53, 12);
            this.lblEdt_InputPort.TabIndex = 39;
            this.lblEdt_InputPort.Text = "切片时间";
            // 
            // lblEdt_InputIP
            // 
            this.lblEdt_InputIP.AutoSize = true;
            this.lblEdt_InputIP.Location = new System.Drawing.Point(31, 25);
            this.lblEdt_InputIP.Name = "lblEdt_InputIP";
            this.lblEdt_InputIP.Size = new System.Drawing.Size(53, 12);
            this.lblEdt_InputIP.TabIndex = 38;
            this.lblEdt_InputIP.Text = "切片数量";
            // 
            // txtFTPPort
            // 
            this.txtFTPPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTPPort.Location = new System.Drawing.Point(138, 250);
            this.txtFTPPort.Name = "txtFTPPort";
            this.txtFTPPort.Size = new System.Drawing.Size(211, 21);
            this.txtFTPPort.TabIndex = 49;
            this.txtFTPPort.Tag = "端口";
            this.txtFTPPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFTPPort_KeyPress);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(31, 254);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(47, 12);
            this.lblPort.TabIndex = 51;
            this.lblPort.Text = "FTP端口";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(31, 225);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(47, 12);
            this.lblHost.TabIndex = 50;
            this.lblHost.Text = "FTP地址";
            // 
            // txtFTPPwd
            // 
            this.txtFTPPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTPPwd.Location = new System.Drawing.Point(138, 310);
            this.txtFTPPwd.Name = "txtFTPPwd";
            this.txtFTPPwd.PasswordChar = '*';
            this.txtFTPPwd.Size = new System.Drawing.Size(211, 21);
            this.txtFTPPwd.TabIndex = 53;
            this.txtFTPPwd.Tag = "密码";
            // 
            // txtFTPUserName
            // 
            this.txtFTPUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFTPUserName.Location = new System.Drawing.Point(138, 281);
            this.txtFTPUserName.Name = "txtFTPUserName";
            this.txtFTPUserName.Size = new System.Drawing.Size(211, 21);
            this.txtFTPUserName.TabIndex = 52;
            this.txtFTPUserName.Tag = "用户名";
            // 
            // lblWatchWord
            // 
            this.lblWatchWord.AutoSize = true;
            this.lblWatchWord.Location = new System.Drawing.Point(31, 314);
            this.lblWatchWord.Name = "lblWatchWord";
            this.lblWatchWord.Size = new System.Drawing.Size(29, 12);
            this.lblWatchWord.TabIndex = 55;
            this.lblWatchWord.Text = "密码";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(31, 285);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 12);
            this.lblUserName.TabIndex = 54;
            this.lblUserName.Text = "用户名";
            // 
            // lblFile
            // 
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.lblFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F);
            this.lblFile.Location = new System.Drawing.Point(355, 144);
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
            // textServerIp
            // 
            this.textServerIp.BackColor = System.Drawing.SystemColors.Window;
            this.textServerIp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textServerIp.Location = new System.Drawing.Point(138, 80);
            this.textServerIp.Name = "textServerIp";
            this.textServerIp.ReadOnly = false;
            this.textServerIp.Size = new System.Drawing.Size(211, 23);
            this.textServerIp.TabIndex = 58;
            // 
            // txtFTPHost
            // 
            this.txtFTPHost.BackColor = System.Drawing.SystemColors.Window;
            this.txtFTPHost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtFTPHost.Location = new System.Drawing.Point(138, 220);
            this.txtFTPHost.Name = "txtFTPHost";
            this.txtFTPHost.ReadOnly = false;
            this.txtFTPHost.Size = new System.Drawing.Size(211, 23);
            this.txtFTPHost.TabIndex = 59;
            // 
            // RecordConfigLayoutNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtFTPHost);
            this.Controls.Add(this.textServerIp);
            this.Controls.Add(this.lblFileMon);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFTPPwd);
            this.Controls.Add(this.txtFTPUserName);
            this.Controls.Add(this.lblWatchWord);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtFTPPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txtMonBasePath);
            this.Controls.Add(this.txtBasePath);
            this.Controls.Add(this.lblEdt_Localport);
            this.Controls.Add(this.lblEdt_LoalIP);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.lblEdt_ServerPort);
            this.Controls.Add(this.lblEdt_SeverIP);
            this.Controls.Add(this.txtSliceTime);
            this.Controls.Add(this.txtSliceCount);
            this.Controls.Add(this.lblEdt_InputPort);
            this.Controls.Add(this.lblEdt_InputIP);
            this.DoubleBuffered = true;
            this.Name = "RecordConfigLayoutNew";
            this.Size = new System.Drawing.Size(405, 378);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonBasePath;
        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Label lblEdt_Localport;
        private System.Windows.Forms.Label lblEdt_LoalIP;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lblEdt_ServerPort;
        private System.Windows.Forms.Label lblEdt_SeverIP;
        private System.Windows.Forms.TextBox txtSliceTime;
        private System.Windows.Forms.TextBox txtSliceCount;
        private System.Windows.Forms.Label lblEdt_InputPort;
        private System.Windows.Forms.Label lblEdt_InputIP;
        private System.Windows.Forms.TextBox txtFTPPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtFTPPwd;
        private System.Windows.Forms.TextBox txtFTPUserName;
        private System.Windows.Forms.Label lblWatchWord;
        private System.Windows.Forms.Label lblUserName;
        private ControlAstro.Controls.LabelButton lblFile;
        private ControlAstro.Controls.LabelButton lblFileMon;
        public IPAddressControlLib.IPAddressControl textServerIp;
        public IPAddressControlLib.IPAddressControl txtFTPHost;
        private System.Windows.Forms.FolderBrowserDialog fileDialog;
    }
}
