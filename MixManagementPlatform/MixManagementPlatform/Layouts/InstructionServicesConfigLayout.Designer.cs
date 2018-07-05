namespace MixManagementPlatform.Layouts
{
    partial class InstructionServicesConfigLayout
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
            this.panel = new System.Windows.Forms.Panel();
            this.separatorLineSys = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineLocal = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineDataBase = new MixManagementPlatform.Controls.SeparatorLine();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.cbBoxProtocol = new System.Windows.Forms.ComboBox();
            this.textDataBase = new System.Windows.Forms.TextBox();
            this.lblLogID = new System.Windows.Forms.Label();
            this.lblLogPass = new System.Windows.Forms.Label();
            this.textLogID = new System.Windows.Forms.TextBox();
            this.textLogPass = new System.Windows.Forms.TextBox();
            this.lblMICROMODE = new System.Windows.Forms.Label();
            this.textMQServerTopicName = new System.Windows.Forms.TextBox();
            this.lblMicroPORT = new System.Windows.Forms.Label();
            this.textMQServerPORT = new System.Windows.Forms.TextBox();
            this.textMQServerIP = new System.Windows.Forms.TextBox();
            this.lblPORT = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.separatorLineSys);
            this.panel.Controls.Add(this.separatorLineLocal);
            this.panel.Controls.Add(this.separatorLineDataBase);
            this.panel.Controls.Add(this.lblServerName);
            this.panel.Controls.Add(this.lblDataBase);
            this.panel.Controls.Add(this.textServerName);
            this.panel.Controls.Add(this.cbBoxProtocol);
            this.panel.Controls.Add(this.textDataBase);
            this.panel.Controls.Add(this.lblLogID);
            this.panel.Controls.Add(this.lblLogPass);
            this.panel.Controls.Add(this.textLogID);
            this.panel.Controls.Add(this.textLogPass);
            this.panel.Controls.Add(this.lblMICROMODE);
            this.panel.Controls.Add(this.textMQServerTopicName);
            this.panel.Controls.Add(this.lblMicroPORT);
            this.panel.Controls.Add(this.textMQServerPORT);
            this.panel.Controls.Add(this.textMQServerIP);
            this.panel.Controls.Add(this.lblPORT);
            this.panel.Controls.Add(this.lblIP);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(396, 423);
            this.panel.TabIndex = 0;
            // 
            // separatorLineSys
            // 
            this.separatorLineSys.LineColor = System.Drawing.Color.Gray;
            this.separatorLineSys.Location = new System.Drawing.Point(15, 315);
            this.separatorLineSys.Name = "separatorLineSys";
            this.separatorLineSys.Size = new System.Drawing.Size(379, 23);
            this.separatorLineSys.TabIndex = 160;
            this.separatorLineSys.Text = "协议设置";
            this.separatorLineSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineSys.TextPaddingLeft = 160;
            // 
            // separatorLineLocal
            // 
            this.separatorLineLocal.LineColor = System.Drawing.Color.Gray;
            this.separatorLineLocal.Location = new System.Drawing.Point(15, 182);
            this.separatorLineLocal.Name = "separatorLineLocal";
            this.separatorLineLocal.Size = new System.Drawing.Size(379, 23);
            this.separatorLineLocal.TabIndex = 158;
            this.separatorLineLocal.Text = "MQ设置";
            this.separatorLineLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineLocal.TextPaddingLeft = 148;
            // 
            // separatorLineDataBase
            // 
            this.separatorLineDataBase.LineColor = System.Drawing.Color.Gray;
            this.separatorLineDataBase.Location = new System.Drawing.Point(15, 8);
            this.separatorLineDataBase.Name = "separatorLineDataBase";
            this.separatorLineDataBase.Size = new System.Drawing.Size(379, 23);
            this.separatorLineDataBase.TabIndex = 157;
            this.separatorLineDataBase.Text = "数据库";
            this.separatorLineDataBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineDataBase.TextPaddingLeft = 166;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(34, 41);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(41, 12);
            this.lblServerName.TabIndex = 112;
            this.lblServerName.Text = "服务器";
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(34, 72);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(41, 12);
            this.lblDataBase.TabIndex = 113;
            this.lblDataBase.Text = "数据库";
            // 
            // textServerName
            // 
            this.textServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textServerName.Location = new System.Drawing.Point(118, 37);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(196, 21);
            this.textServerName.TabIndex = 93;
            this.textServerName.Tag = "服务器";
            // 
            // cbBoxProtocol
            // 
            this.cbBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxProtocol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBoxProtocol.FormattingEnabled = true;
            this.cbBoxProtocol.Location = new System.Drawing.Point(118, 354);
            this.cbBoxProtocol.Name = "cbBoxProtocol";
            this.cbBoxProtocol.Size = new System.Drawing.Size(195, 20);
            this.cbBoxProtocol.TabIndex = 156;
            // 
            // textDataBase
            // 
            this.textDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDataBase.Location = new System.Drawing.Point(118, 68);
            this.textDataBase.Name = "textDataBase";
            this.textDataBase.Size = new System.Drawing.Size(196, 21);
            this.textDataBase.TabIndex = 94;
            this.textDataBase.Tag = "数据库";
            // 
            // lblLogID
            // 
            this.lblLogID.AutoSize = true;
            this.lblLogID.Location = new System.Drawing.Point(34, 103);
            this.lblLogID.Name = "lblLogID";
            this.lblLogID.Size = new System.Drawing.Size(41, 12);
            this.lblLogID.TabIndex = 114;
            this.lblLogID.Text = "用户名";
            // 
            // lblLogPass
            // 
            this.lblLogPass.AutoSize = true;
            this.lblLogPass.Location = new System.Drawing.Point(34, 136);
            this.lblLogPass.Name = "lblLogPass";
            this.lblLogPass.Size = new System.Drawing.Size(53, 12);
            this.lblLogPass.TabIndex = 115;
            this.lblLogPass.Text = "登陆密码";
            // 
            // textLogID
            // 
            this.textLogID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLogID.Location = new System.Drawing.Point(118, 99);
            this.textLogID.Name = "textLogID";
            this.textLogID.Size = new System.Drawing.Size(196, 21);
            this.textLogID.TabIndex = 95;
            this.textLogID.Tag = "用户名";
            // 
            // textLogPass
            // 
            this.textLogPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLogPass.Location = new System.Drawing.Point(118, 132);
            this.textLogPass.Name = "textLogPass";
            this.textLogPass.Size = new System.Drawing.Size(196, 21);
            this.textLogPass.TabIndex = 96;
            this.textLogPass.Tag = "登陆密码";
            // 
            // lblMICROMODE
            // 
            this.lblMICROMODE.AutoSize = true;
            this.lblMICROMODE.Location = new System.Drawing.Point(34, 359);
            this.lblMICROMODE.Name = "lblMICROMODE";
            this.lblMICROMODE.Size = new System.Drawing.Size(53, 12);
            this.lblMICROMODE.TabIndex = 140;
            this.lblMICROMODE.Text = "协议类型";
            // 
            // textMQServerTopicName
            // 
            this.textMQServerTopicName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQServerTopicName.Location = new System.Drawing.Point(118, 278);
            this.textMQServerTopicName.Name = "textMQServerTopicName";
            this.textMQServerTopicName.Size = new System.Drawing.Size(196, 21);
            this.textMQServerTopicName.TabIndex = 99;
            this.textMQServerTopicName.Tag = "插播服务端口";
            // 
            // lblMicroPORT
            // 
            this.lblMicroPORT.AutoSize = true;
            this.lblMicroPORT.Location = new System.Drawing.Point(34, 282);
            this.lblMicroPORT.Name = "lblMicroPORT";
            this.lblMicroPORT.Size = new System.Drawing.Size(59, 12);
            this.lblMicroPORT.TabIndex = 118;
            this.lblMicroPORT.Text = "TopicName";
            // 
            // textMQServerPORT
            // 
            this.textMQServerPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQServerPORT.Location = new System.Drawing.Point(118, 243);
            this.textMQServerPORT.Name = "textMQServerPORT";
            this.textMQServerPORT.Size = new System.Drawing.Size(196, 21);
            this.textMQServerPORT.TabIndex = 98;
            this.textMQServerPORT.Tag = "电话服务端口";
            // 
            // textMQServerIP
            // 
            this.textMQServerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQServerIP.Location = new System.Drawing.Point(118, 212);
            this.textMQServerIP.Name = "textMQServerIP";
            this.textMQServerIP.Size = new System.Drawing.Size(196, 21);
            this.textMQServerIP.TabIndex = 97;
            this.textMQServerIP.Tag = "本机IP";
            // 
            // lblPORT
            // 
            this.lblPORT.AutoSize = true;
            this.lblPORT.Location = new System.Drawing.Point(34, 247);
            this.lblPORT.Name = "lblPORT";
            this.lblPORT.Size = new System.Drawing.Size(41, 12);
            this.lblPORT.TabIndex = 117;
            this.lblPORT.Text = "MQ端口";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(34, 216);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(29, 12);
            this.lblIP.TabIndex = 116;
            this.lblIP.Text = "MQIP";
            // 
            // InstructionServicesConfigLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "InstructionServicesConfigLayout";
            this.Size = new System.Drawing.Size(396, 423);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private Controls.SeparatorLine separatorLineSys;
        private Controls.SeparatorLine separatorLineLocal;
        private Controls.SeparatorLine separatorLineDataBase;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.ComboBox cbBoxProtocol;
        private System.Windows.Forms.TextBox textDataBase;
        private System.Windows.Forms.Label lblLogID;
        private System.Windows.Forms.Label lblLogPass;
        private System.Windows.Forms.TextBox textLogID;
        private System.Windows.Forms.TextBox textLogPass;
        private System.Windows.Forms.Label lblMICROMODE;
        private System.Windows.Forms.TextBox textMQServerTopicName;
        private System.Windows.Forms.Label lblMicroPORT;
        private System.Windows.Forms.TextBox textMQServerPORT;
        private System.Windows.Forms.TextBox textMQServerIP;
        private System.Windows.Forms.Label lblPORT;
        private System.Windows.Forms.Label lblIP;
    }
}
