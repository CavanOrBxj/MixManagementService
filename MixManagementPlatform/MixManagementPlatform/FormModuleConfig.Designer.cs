namespace MixManagementPlatform
{
    partial class FormModuleConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModuleConfig));
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 11F);
            this.btnYes.Location = new System.Drawing.Point(241, 321);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(196, 34);
            this.btnYes.TabIndex = 20;
            this.btnYes.Text = "确        定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // FormModuleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 371);
            this.Controls.Add(this.btnYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FormModuleConfig";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "模块参数配置";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAstro.Controls.CircleButton btnYes;
    }
}