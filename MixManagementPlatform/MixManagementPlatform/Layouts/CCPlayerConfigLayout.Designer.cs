namespace MixManagementPlatform.Layouts
{
    partial class CCPlayerConfigLayout
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
            this.txtCCplayerPort = new System.Windows.Forms.TextBox();
            this.txtCCplayerIP = new System.Windows.Forms.TextBox();
            this.lblConsumer = new System.Windows.Forms.Label();
            this.lblUri = new System.Windows.Forms.Label();
            this.txtCCplayerServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.separatorLineServer = new MixManagementPlatform.Controls.SeparatorLine();
            this.SuspendLayout();
            // 
            // txtCCplayerPort
            // 
            this.txtCCplayerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCplayerPort.Location = new System.Drawing.Point(100, 78);
            this.txtCCplayerPort.Name = "txtCCplayerPort";
            this.txtCCplayerPort.Size = new System.Drawing.Size(264, 21);
            this.txtCCplayerPort.TabIndex = 1;
            this.txtCCplayerPort.Tag = "消费者";
            // 
            // txtCCplayerIP
            // 
            this.txtCCplayerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCplayerIP.Location = new System.Drawing.Point(100, 47);
            this.txtCCplayerIP.Name = "txtCCplayerIP";
            this.txtCCplayerIP.Size = new System.Drawing.Size(264, 21);
            this.txtCCplayerIP.TabIndex = 0;
            this.txtCCplayerIP.Tag = "URI";
            // 
            // lblConsumer
            // 
            this.lblConsumer.AutoSize = true;
            this.lblConsumer.Location = new System.Drawing.Point(20, 82);
            this.lblConsumer.Name = "lblConsumer";
            this.lblConsumer.Size = new System.Drawing.Size(65, 12);
            this.lblConsumer.TabIndex = 19;
            this.lblConsumer.Text = "服务器端口";
            // 
            // lblUri
            // 
            this.lblUri.AutoSize = true;
            this.lblUri.Location = new System.Drawing.Point(20, 51);
            this.lblUri.Name = "lblUri";
            this.lblUri.Size = new System.Drawing.Size(53, 12);
            this.lblUri.TabIndex = 18;
            this.lblUri.Text = "服务器IP";
            // 
            // txtCCplayerServer
            // 
            this.txtCCplayerServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCplayerServer.Location = new System.Drawing.Point(100, 110);
            this.txtCCplayerServer.Name = "txtCCplayerServer";
            this.txtCCplayerServer.Size = new System.Drawing.Size(264, 21);
            this.txtCCplayerServer.TabIndex = 20;
            this.txtCCplayerServer.Tag = "IP";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(20, 114);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(77, 12);
            this.lblServer.TabIndex = 22;
            this.lblServer.Text = "调度服务地址";
            // 
            // separatorLineServer
            // 
            this.separatorLineServer.Location = new System.Drawing.Point(18, 10);
            this.separatorLineServer.Name = "separatorLineServer";
            this.separatorLineServer.Size = new System.Drawing.Size(354, 23);
            this.separatorLineServer.TabIndex = 24;
            this.separatorLineServer.Text = "服务管理连接";
            this.separatorLineServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineServer.TextPaddingLeft = 135;
            // 
            // CCPlayerConfigLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.separatorLineServer);
            this.Controls.Add(this.txtCCplayerServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtCCplayerPort);
            this.Controls.Add(this.txtCCplayerIP);
            this.Controls.Add(this.lblConsumer);
            this.Controls.Add(this.lblUri);
            this.DoubleBuffered = true;
            this.Name = "CCPlayerConfigLayout";
            this.Size = new System.Drawing.Size(385, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCCplayerPort;
        private System.Windows.Forms.TextBox txtCCplayerIP;
        private System.Windows.Forms.Label lblConsumer;
        private System.Windows.Forms.Label lblUri;
        private System.Windows.Forms.TextBox txtCCplayerServer;
        private System.Windows.Forms.Label lblServer;
        private Controls.SeparatorLine separatorLineServer;
    }
}
