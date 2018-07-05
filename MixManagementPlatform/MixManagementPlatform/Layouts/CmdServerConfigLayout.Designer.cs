namespace MixManagementPlatform.Layouts
{
    partial class CmdServerConfigLayout
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
            this.textConsumer = new System.Windows.Forms.TextBox();
            this.textUri = new System.Windows.Forms.TextBox();
            this.lblConsumer = new System.Windows.Forms.Label();
            this.lblUri = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textServer = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.separatorLineServerAddress = new MixManagementPlatform.Controls.SeparatorLine();
            this.separatorLineServer = new MixManagementPlatform.Controls.SeparatorLine();
            this.SuspendLayout();
            // 
            // textConsumer
            // 
            this.textConsumer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textConsumer.Location = new System.Drawing.Point(100, 78);
            this.textConsumer.Name = "textConsumer";
            this.textConsumer.Size = new System.Drawing.Size(264, 21);
            this.textConsumer.TabIndex = 1;
            this.textConsumer.Tag = "消费者";
            // 
            // textUri
            // 
            this.textUri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUri.Location = new System.Drawing.Point(100, 47);
            this.textUri.Name = "textUri";
            this.textUri.Size = new System.Drawing.Size(264, 21);
            this.textUri.TabIndex = 0;
            this.textUri.Tag = "URI";
            // 
            // lblConsumer
            // 
            this.lblConsumer.AutoSize = true;
            this.lblConsumer.Location = new System.Drawing.Point(36, 82);
            this.lblConsumer.Name = "lblConsumer";
            this.lblConsumer.Size = new System.Drawing.Size(41, 12);
            this.lblConsumer.TabIndex = 19;
            this.lblConsumer.Text = "消费者";
            // 
            // lblUri
            // 
            this.lblUri.AutoSize = true;
            this.lblUri.Location = new System.Drawing.Point(36, 51);
            this.lblUri.Name = "lblUri";
            this.lblUri.Size = new System.Drawing.Size(23, 12);
            this.lblUri.TabIndex = 18;
            this.lblUri.Text = "URI";
            // 
            // textPort
            // 
            this.textPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPort.Location = new System.Drawing.Point(100, 190);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(264, 21);
            this.textPort.TabIndex = 21;
            this.textPort.Tag = "端口";
            // 
            // textServer
            // 
            this.textServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textServer.Location = new System.Drawing.Point(100, 157);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(264, 21);
            this.textServer.TabIndex = 20;
            this.textServer.Tag = "IP";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(36, 194);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 12);
            this.lblPort.TabIndex = 23;
            this.lblPort.Text = "端口";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(36, 161);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(17, 12);
            this.lblServer.TabIndex = 22;
            this.lblServer.Text = "IP";
            // 
            // separatorLineServerAddress
            // 
            this.separatorLineServerAddress.Location = new System.Drawing.Point(18, 124);
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
            this.separatorLineServer.Text = "服务管理连接";
            this.separatorLineServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.separatorLineServer.TextPaddingLeft = 135;
            // 
            // CmdServerConfigLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.separatorLineServerAddress);
            this.Controls.Add(this.separatorLineServer);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textServer);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.textConsumer);
            this.Controls.Add(this.textUri);
            this.Controls.Add(this.lblConsumer);
            this.Controls.Add(this.lblUri);
            this.DoubleBuffered = true;
            this.Name = "CmdServerConfigLayout";
            this.Size = new System.Drawing.Size(385, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textConsumer;
        private System.Windows.Forms.TextBox textUri;
        private System.Windows.Forms.Label lblConsumer;
        private System.Windows.Forms.Label lblUri;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblServer;
        private Controls.SeparatorLine separatorLineServer;
        private Controls.SeparatorLine separatorLineServerAddress;
    }
}
