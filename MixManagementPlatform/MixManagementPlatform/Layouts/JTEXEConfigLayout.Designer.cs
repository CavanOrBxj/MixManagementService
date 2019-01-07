namespace MixManagementPlatform.Layouts
{
    partial class JTEXEConfigLayout
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
            this.separatorLineServerAddress = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineServer = new MixManagementPlatform.Controls.SeparatorLine();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.txtJTSQLIP = new System.Windows.Forms.TextBox();
            this.txtJTDataBase = new System.Windows.Forms.TextBox();
            this.lblLogID = new System.Windows.Forms.Label();
            this.lblLogPass = new System.Windows.Forms.Label();
            this.txtJTLogID = new System.Windows.Forms.TextBox();
            this.txtJTLogPass = new System.Windows.Forms.TextBox();
            this.txtJTPort = new System.Windows.Forms.TextBox();
            this.txtJTLocalHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // separatorLineServerAddress
            // 
            this.separatorLineServerAddress.Location = new System.Drawing.Point(18, 160);
            this.separatorLineServerAddress.Name = "separatorLineServerAddress";
            this.separatorLineServerAddress.Size = new System.Drawing.Size(354, 23);
            this.separatorLineServerAddress.TabIndex = 25;
            this.separatorLineServerAddress.Text = "服务器设置";
            this.separatorLineServerAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineServerAddress.TextPaddingLeft = 141;
            // 
            // separatorLineServer
            // 
            this.separatorLineServer.Location = new System.Drawing.Point(18, 10);
            this.separatorLineServer.Name = "separatorLineServer";
            this.separatorLineServer.Size = new System.Drawing.Size(354, 23);
            this.separatorLineServer.TabIndex = 24;
            this.separatorLineServer.Text = "数据库连接";
            this.separatorLineServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineServer.TextPaddingLeft = 135;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(52, 43);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(41, 12);
            this.lblServerName.TabIndex = 120;
            this.lblServerName.Text = "服务器";
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(52, 72);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(41, 12);
            this.lblDataBase.TabIndex = 121;
            this.lblDataBase.Text = "数据库";
            // 
            // txtJTSQLIP
            // 
            this.txtJTSQLIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTSQLIP.Location = new System.Drawing.Point(136, 39);
            this.txtJTSQLIP.Name = "txtJTSQLIP";
            this.txtJTSQLIP.Size = new System.Drawing.Size(196, 21);
            this.txtJTSQLIP.TabIndex = 116;
            this.txtJTSQLIP.Tag = "服务器";
            // 
            // txtJTDataBase
            // 
            this.txtJTDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTDataBase.Location = new System.Drawing.Point(136, 68);
            this.txtJTDataBase.Name = "txtJTDataBase";
            this.txtJTDataBase.Size = new System.Drawing.Size(196, 21);
            this.txtJTDataBase.TabIndex = 117;
            this.txtJTDataBase.Tag = "数据库";
            // 
            // lblLogID
            // 
            this.lblLogID.AutoSize = true;
            this.lblLogID.Location = new System.Drawing.Point(52, 101);
            this.lblLogID.Name = "lblLogID";
            this.lblLogID.Size = new System.Drawing.Size(41, 12);
            this.lblLogID.TabIndex = 122;
            this.lblLogID.Text = "用户名";
            // 
            // lblLogPass
            // 
            this.lblLogPass.AutoSize = true;
            this.lblLogPass.Location = new System.Drawing.Point(52, 130);
            this.lblLogPass.Name = "lblLogPass";
            this.lblLogPass.Size = new System.Drawing.Size(53, 12);
            this.lblLogPass.TabIndex = 123;
            this.lblLogPass.Text = "登陆密码";
            // 
            // txtJTLogID
            // 
            this.txtJTLogID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTLogID.Location = new System.Drawing.Point(136, 97);
            this.txtJTLogID.Name = "txtJTLogID";
            this.txtJTLogID.Size = new System.Drawing.Size(196, 21);
            this.txtJTLogID.TabIndex = 118;
            this.txtJTLogID.Tag = "用户名";
            // 
            // txtJTLogPass
            // 
            this.txtJTLogPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTLogPass.Location = new System.Drawing.Point(136, 126);
            this.txtJTLogPass.Name = "txtJTLogPass";
            this.txtJTLogPass.Size = new System.Drawing.Size(196, 21);
            this.txtJTLogPass.TabIndex = 119;
            this.txtJTLogPass.Tag = "登陆密码";
            // 
            // txtJTPort
            // 
            this.txtJTPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTPort.Location = new System.Drawing.Point(136, 220);
            this.txtJTPort.Name = "txtJTPort";
            this.txtJTPort.Size = new System.Drawing.Size(196, 21);
            this.txtJTPort.TabIndex = 167;
            this.txtJTPort.Tag = "";
            // 
            // txtJTLocalHost
            // 
            this.txtJTLocalHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJTLocalHost.Location = new System.Drawing.Point(136, 189);
            this.txtJTLocalHost.Name = "txtJTLocalHost";
            this.txtJTLocalHost.Size = new System.Drawing.Size(196, 21);
            this.txtJTLocalHost.TabIndex = 166;
            this.txtJTLocalHost.Tag = "本机IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 169;
            this.label1.Text = "端口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 168;
            this.label2.Text = "本机IP";
            // 
            // JTEXEConfigLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtJTPort);
            this.Controls.Add(this.txtJTLocalHost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblDataBase);
            this.Controls.Add(this.txtJTSQLIP);
            this.Controls.Add(this.txtJTDataBase);
            this.Controls.Add(this.lblLogID);
            this.Controls.Add(this.lblLogPass);
            this.Controls.Add(this.txtJTLogID);
            this.Controls.Add(this.txtJTLogPass);
            this.Controls.Add(this.separatorLineServerAddress);
            this.Controls.Add(this.separatorLineServer);
            this.DoubleBuffered = true;
            this.Name = "JTEXEConfigLayout";
            this.Size = new System.Drawing.Size(385, 274);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.SeparatorLine separatorLineServer;
        private Controls.SeparatorLine separatorLineServerAddress;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox txtJTSQLIP;
        private System.Windows.Forms.TextBox txtJTDataBase;
        private System.Windows.Forms.Label lblLogID;
        private System.Windows.Forms.Label lblLogPass;
        private System.Windows.Forms.TextBox txtJTLogID;
        private System.Windows.Forms.TextBox txtJTLogPass;
        private System.Windows.Forms.TextBox txtJTPort;
        private System.Windows.Forms.TextBox txtJTLocalHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
