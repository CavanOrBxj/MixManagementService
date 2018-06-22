namespace MixManagementPlatform
{
    partial class FormDataBaseConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataBaseConfig));
            this.textUser = new System.Windows.Forms.TextBox();
            this.textServerIp = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textUser
            // 
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUser.Location = new System.Drawing.Point(126, 90);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(264, 21);
            this.textUser.TabIndex = 21;
            this.textUser.Tag = "用户名";
            // 
            // textServerIp
            // 
            this.textServerIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textServerIp.Location = new System.Drawing.Point(126, 51);
            this.textServerIp.Name = "textServerIp";
            this.textServerIp.Size = new System.Drawing.Size(264, 21);
            this.textServerIp.TabIndex = 20;
            this.textServerIp.Tag = "数据库IP地址";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(38, 94);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(41, 12);
            this.lblUser.TabIndex = 23;
            this.lblUser.Text = "用户名";
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(38, 55);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(77, 12);
            this.lblServerIp.TabIndex = 22;
            this.lblServerIp.Text = "数据库IP地址";
            // 
            // textPwd
            // 
            this.textPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPwd.Location = new System.Drawing.Point(126, 132);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(264, 21);
            this.textPwd.TabIndex = 24;
            this.textPwd.Tag = "密码";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(38, 136);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(29, 12);
            this.lblPwd.TabIndex = 25;
            this.lblPwd.Text = "密码";
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 11F);
            this.btnYes.Location = new System.Drawing.Point(234, 190);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(156, 34);
            this.btnYes.TabIndex = 26;
            this.btnYes.Text = "确        定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(38, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "初次启动，请配置数据库信息！";
            // 
            // FormDataBaseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.textServerIp);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblServerIp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FormDataBaseConfig";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "数据库配置信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textServerIp;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Label lblPwd;
        private ControlAstro.Controls.CircleButton btnYes;
        private System.Windows.Forms.Label label1;
    }
}