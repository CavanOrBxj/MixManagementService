namespace MixManagementPlatform
{
    partial class FrmServiceSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServiceSetup));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnServerSet = new System.Windows.Forms.Button();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.btnStartOrEnd = new System.Windows.Forms.Button();
            this.btnInstallOrUninstall = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.btnServerSet);
            this.gbMain.Controls.Add(this.btnGetStatus);
            this.gbMain.Controls.Add(this.btnStartOrEnd);
            this.gbMain.Controls.Add(this.btnInstallOrUninstall);
            this.gbMain.Controls.Add(this.lblMsg);
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.lblServiceName);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Location = new System.Drawing.Point(36, 63);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(493, 259);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "融合平台工具管理服务";
            // 
            // btnServerSet
            // 
            this.btnServerSet.Location = new System.Drawing.Point(373, 133);
            this.btnServerSet.Name = "btnServerSet";
            this.btnServerSet.Size = new System.Drawing.Size(75, 23);
            this.btnServerSet.TabIndex = 8;
            this.btnServerSet.Text = "服务设置";
            this.btnServerSet.UseVisualStyleBackColor = true;
            this.btnServerSet.Click += new System.EventHandler(this.btnServerSet_Click);
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(268, 133);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(75, 23);
            this.btnGetStatus.TabIndex = 6;
            this.btnGetStatus.Text = "获取状态";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // btnStartOrEnd
            // 
            this.btnStartOrEnd.Location = new System.Drawing.Point(159, 133);
            this.btnStartOrEnd.Name = "btnStartOrEnd";
            this.btnStartOrEnd.Size = new System.Drawing.Size(75, 23);
            this.btnStartOrEnd.TabIndex = 5;
            this.btnStartOrEnd.Text = "启动服务";
            this.btnStartOrEnd.UseVisualStyleBackColor = true;
            this.btnStartOrEnd.Click += new System.EventHandler(this.btnStartOrEnd_Click);
            // 
            // btnInstallOrUninstall
            // 
            this.btnInstallOrUninstall.Location = new System.Drawing.Point(50, 133);
            this.btnInstallOrUninstall.Name = "btnInstallOrUninstall";
            this.btnInstallOrUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstallOrUninstall.TabIndex = 4;
            this.btnInstallOrUninstall.Text = "安装服务";
            this.btnInstallOrUninstall.UseVisualStyleBackColor = true;
            this.btnInstallOrUninstall.Click += new System.EventHandler(this.btnInstallOrUninstall_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(148, 206);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务状态:";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblServiceName.Location = new System.Drawing.Point(130, 60);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(125, 12);
            this.lblServiceName.TabIndex = 1;
            this.lblServiceName.Text = "MixManagementService";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务名称:";
            // 
            // FrmServiceSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 350);
            this.Controls.Add(this.gbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FrmServiceSetup";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "服务设置";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnServerSet;
        private System.Windows.Forms.Button btnGetStatus;
        private System.Windows.Forms.Button btnStartOrEnd;
        private System.Windows.Forms.Button btnInstallOrUninstall;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label label1;

    }
}