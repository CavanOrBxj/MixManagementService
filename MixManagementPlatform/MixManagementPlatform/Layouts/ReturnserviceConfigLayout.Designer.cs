namespace MixManagementPlatform.Layouts
{
    partial class ReturnserviceConfigLayout
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
            this.textMQTopicName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textMQServerPORT = new System.Windows.Forms.TextBox();
            this.textMQServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.separatorLineSend = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineLocal = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineDataBase = new MixManagementPlatform.Controls.SeparatorLine();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.textDataBase = new System.Windows.Forms.TextBox();
            this.lblLogID = new System.Windows.Forms.Label();
            this.lblLogPass = new System.Windows.Forms.Label();
            this.textLogID = new System.Windows.Forms.TextBox();
            this.textLogPass = new System.Windows.Forms.TextBox();
            this.textTCPPORT = new System.Windows.Forms.TextBox();
            this.lblMicroPORT = new System.Windows.Forms.Label();
            this.textUDPPORT = new System.Windows.Forms.TextBox();
            this.textIP = new System.Windows.Forms.TextBox();
            this.lblPORT = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.textMQTopicName);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.textMQServerPORT);
            this.panel.Controls.Add(this.textMQServer);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.separatorLineSend);
            this.panel.Controls.Add(this.separatorLineLocal);
            this.panel.Controls.Add(this.separatorLineDataBase);
            this.panel.Controls.Add(this.lblServerName);
            this.panel.Controls.Add(this.lblDataBase);
            this.panel.Controls.Add(this.textServerName);
            this.panel.Controls.Add(this.textDataBase);
            this.panel.Controls.Add(this.lblLogID);
            this.panel.Controls.Add(this.lblLogPass);
            this.panel.Controls.Add(this.textLogID);
            this.panel.Controls.Add(this.textLogPass);
            this.panel.Controls.Add(this.textTCPPORT);
            this.panel.Controls.Add(this.lblMicroPORT);
            this.panel.Controls.Add(this.textUDPPORT);
            this.panel.Controls.Add(this.textIP);
            this.panel.Controls.Add(this.lblPORT);
            this.panel.Controls.Add(this.lblIP);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(396, 423);
            this.panel.TabIndex = 0;
            // 
            // textMQTopicName
            // 
            this.textMQTopicName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQTopicName.Location = new System.Drawing.Point(118, 391);
            this.textMQTopicName.Name = "textMQTopicName";
            this.textMQTopicName.Size = new System.Drawing.Size(215, 21);
            this.textMQTopicName.TabIndex = 162;
            this.textMQTopicName.Tag = "TopicName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 165;
            this.label1.Text = "TopicName";
            // 
            // textMQServerPORT
            // 
            this.textMQServerPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQServerPORT.Location = new System.Drawing.Point(118, 356);
            this.textMQServerPORT.Name = "textMQServerPORT";
            this.textMQServerPORT.Size = new System.Drawing.Size(215, 21);
            this.textMQServerPORT.TabIndex = 161;
            this.textMQServerPORT.Tag = "UDP端口";
            // 
            // textMQServer
            // 
            this.textMQServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMQServer.Location = new System.Drawing.Point(118, 325);
            this.textMQServer.Name = "textMQServer";
            this.textMQServer.Size = new System.Drawing.Size(215, 21);
            this.textMQServer.TabIndex = 160;
            this.textMQServer.Tag = "本机IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 164;
            this.label2.Text = "MQ端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 163;
            this.label3.Text = "MQ服务IP";
            // 
            // separatorLineSend
            // 
            this.separatorLineSend.LineColor = System.Drawing.Color.Gray;
            this.separatorLineSend.Location = new System.Drawing.Point(15, 298);
            this.separatorLineSend.Name = "separatorLineSend";
            this.separatorLineSend.Size = new System.Drawing.Size(379, 23);
            this.separatorLineSend.TabIndex = 159;
            this.separatorLineSend.Text = "MQ设置";
            this.separatorLineSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineSend.TextPaddingLeft = 160;
            // 
            // separatorLineLocal
            // 
            this.separatorLineLocal.LineColor = System.Drawing.Color.Gray;
            this.separatorLineLocal.Location = new System.Drawing.Point(15, 168);
            this.separatorLineLocal.Name = "separatorLineLocal";
            this.separatorLineLocal.Size = new System.Drawing.Size(379, 23);
            this.separatorLineLocal.TabIndex = 158;
            this.separatorLineLocal.Text = "本机地址设置";
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
            this.textServerName.Size = new System.Drawing.Size(215, 21);
            this.textServerName.TabIndex = 93;
            this.textServerName.Tag = "服务器";
            // 
            // textDataBase
            // 
            this.textDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDataBase.Location = new System.Drawing.Point(118, 68);
            this.textDataBase.Name = "textDataBase";
            this.textDataBase.Size = new System.Drawing.Size(215, 21);
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
            this.textLogID.Size = new System.Drawing.Size(215, 21);
            this.textLogID.TabIndex = 95;
            this.textLogID.Tag = "用户名";
            // 
            // textLogPass
            // 
            this.textLogPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLogPass.Location = new System.Drawing.Point(118, 132);
            this.textLogPass.Name = "textLogPass";
            this.textLogPass.Size = new System.Drawing.Size(215, 21);
            this.textLogPass.TabIndex = 96;
            this.textLogPass.Tag = "登陆密码";
            // 
            // textTCPPORT
            // 
            this.textTCPPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTCPPORT.Location = new System.Drawing.Point(118, 264);
            this.textTCPPORT.Name = "textTCPPORT";
            this.textTCPPORT.Size = new System.Drawing.Size(215, 21);
            this.textTCPPORT.TabIndex = 99;
            this.textTCPPORT.Tag = "TCP端口";
            // 
            // lblMicroPORT
            // 
            this.lblMicroPORT.AutoSize = true;
            this.lblMicroPORT.Location = new System.Drawing.Point(34, 268);
            this.lblMicroPORT.Name = "lblMicroPORT";
            this.lblMicroPORT.Size = new System.Drawing.Size(47, 12);
            this.lblMicroPORT.TabIndex = 118;
            this.lblMicroPORT.Text = "TCP端口";
            // 
            // textUDPPORT
            // 
            this.textUDPPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUDPPORT.Location = new System.Drawing.Point(118, 229);
            this.textUDPPORT.Name = "textUDPPORT";
            this.textUDPPORT.Size = new System.Drawing.Size(215, 21);
            this.textUDPPORT.TabIndex = 98;
            this.textUDPPORT.Tag = "UDP端口";
            // 
            // textIP
            // 
            this.textIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textIP.Location = new System.Drawing.Point(118, 198);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(215, 21);
            this.textIP.TabIndex = 97;
            this.textIP.Tag = "本机IP";
            // 
            // lblPORT
            // 
            this.lblPORT.AutoSize = true;
            this.lblPORT.Location = new System.Drawing.Point(34, 233);
            this.lblPORT.Name = "lblPORT";
            this.lblPORT.Size = new System.Drawing.Size(47, 12);
            this.lblPORT.TabIndex = 117;
            this.lblPORT.Text = "UDP端口";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(34, 202);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(41, 12);
            this.lblIP.TabIndex = 116;
            this.lblIP.Text = "本机IP";
            // 
            // ReturnserviceConfigLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "ReturnserviceConfigLayout";
            this.Size = new System.Drawing.Size(396, 423);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private Controls.SeparatorLine separatorLineSend;
        private Controls.SeparatorLine separatorLineLocal;
        private Controls.SeparatorLine separatorLineDataBase;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.TextBox textDataBase;
        private System.Windows.Forms.Label lblLogID;
        private System.Windows.Forms.Label lblLogPass;
        private System.Windows.Forms.TextBox textLogID;
        private System.Windows.Forms.TextBox textLogPass;
        private System.Windows.Forms.TextBox textTCPPORT;
        private System.Windows.Forms.Label lblMicroPORT;
        private System.Windows.Forms.TextBox textUDPPORT;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label lblPORT;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox textMQTopicName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMQServerPORT;
        private System.Windows.Forms.TextBox textMQServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
