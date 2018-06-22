namespace MixManagementPlatform
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textServerIp = new IPAddressControlLib.IPAddressControl();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDeskttopClient = new System.Windows.Forms.RadioButton();
            this.rdbWindowsServer = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 11F);
            this.btnYes.Location = new System.Drawing.Point(204, 343);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(120, 34);
            this.btnYes.TabIndex = 26;
            this.btnYes.Text = "确  定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textServerIp);
            this.groupBox2.Controls.Add(this.textPwd);
            this.groupBox2.Controls.Add(this.lblPwd);
            this.groupBox2.Controls.Add(this.textUser);
            this.groupBox2.Controls.Add(this.lblUser);
            this.groupBox2.Controls.Add(this.lblServerIp);
            this.groupBox2.Location = new System.Drawing.Point(32, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 164);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL设置";
            // 
            // textServerIp
            // 
            this.textServerIp.BackColor = System.Drawing.SystemColors.Window;
            this.textServerIp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textServerIp.Location = new System.Drawing.Point(175, 32);
            this.textServerIp.Name = "textServerIp";
            this.textServerIp.ReadOnly = false;
            this.textServerIp.Size = new System.Drawing.Size(120, 23);
            this.textServerIp.TabIndex = 32;
            // 
            // textPwd
            // 
            this.textPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPwd.Location = new System.Drawing.Point(175, 112);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(120, 21);
            this.textPwd.TabIndex = 30;
            this.textPwd.Tag = "密码";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(52, 116);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(29, 12);
            this.lblPwd.TabIndex = 31;
            this.lblPwd.Text = "密码";
            // 
            // textUser
            // 
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUser.Location = new System.Drawing.Point(175, 70);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(120, 21);
            this.textUser.TabIndex = 27;
            this.textUser.Tag = "用户名";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(52, 74);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(41, 12);
            this.lblUser.TabIndex = 29;
            this.lblUser.Text = "用户名";
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(52, 35);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(77, 12);
            this.lblServerIp.TabIndex = 28;
            this.lblServerIp.Text = "数据库IP地址";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDeskttopClient);
            this.groupBox1.Controls.Add(this.rdbWindowsServer);
            this.groupBox1.Location = new System.Drawing.Point(32, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 100);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "启动方式";
            // 
            // rdbDeskttopClient
            // 
            this.rdbDeskttopClient.AutoSize = true;
            this.rdbDeskttopClient.Location = new System.Drawing.Point(208, 48);
            this.rdbDeskttopClient.Name = "rdbDeskttopClient";
            this.rdbDeskttopClient.Size = new System.Drawing.Size(83, 16);
            this.rdbDeskttopClient.TabIndex = 1;
            this.rdbDeskttopClient.TabStop = true;
            this.rdbDeskttopClient.Text = "桌面客户端";
            this.rdbDeskttopClient.UseVisualStyleBackColor = true;
            // 
            // rdbWindowsServer
            // 
            this.rdbWindowsServer.AutoSize = true;
            this.rdbWindowsServer.Location = new System.Drawing.Point(53, 48);
            this.rdbWindowsServer.Name = "rdbWindowsServer";
            this.rdbWindowsServer.Size = new System.Drawing.Size(89, 16);
            this.rdbWindowsServer.TabIndex = 0;
            this.rdbWindowsServer.TabStop = true;
            this.rdbWindowsServer.Text = "Windows服务";
            this.rdbWindowsServer.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 391);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "启动界面";
         //   this.Load += new System.EventHandler(this.StartForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAstro.Controls.CircleButton btnYes;
        private System.Windows.Forms.GroupBox groupBox2;
        public IPAddressControlLib.IPAddressControl textServerIp;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDeskttopClient;
        private System.Windows.Forms.RadioButton rdbWindowsServer;
    }
}