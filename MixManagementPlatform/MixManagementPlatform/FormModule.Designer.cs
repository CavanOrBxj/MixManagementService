namespace MixManagementPlatform
{
    partial class FormModule
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModule));
            this.panel = new System.Windows.Forms.Panel();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.textBoxArguments = new ControlAstro.Controls.TextBoxWatermark();
            this.lblDelay = new System.Windows.Forms.Label();
            this.textBoxDelay = new ControlAstro.Controls.TextBoxWatermark();
            this.lblFile = new ControlAstro.Controls.LabelButton();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLoaction = new System.Windows.Forms.Label();
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbBoxType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.checkBoxAutoStart);
            this.panel.Controls.Add(this.textBoxArguments);
            this.panel.Controls.Add(this.lblDelay);
            this.panel.Controls.Add(this.textBoxDelay);
            this.panel.Controls.Add(this.lblFile);
            this.panel.Controls.Add(this.textBoxLocation);
            this.panel.Controls.Add(this.textBoxName);
            this.panel.Controls.Add(this.lblName);
            this.panel.Controls.Add(this.lblLoaction);
            this.panel.Font = new System.Drawing.Font("宋体", 11F);
            this.panel.Location = new System.Drawing.Point(23, 119);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel.Size = new System.Drawing.Size(323, 294);
            this.panel.TabIndex = 14;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(40, 153);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(101, 19);
            this.checkBoxAutoStart.TabIndex = 22;
            this.checkBoxAutoStart.Text = "是否自启：";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // textBoxArguments
            // 
            this.textBoxArguments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxArguments.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxArguments.HintFont = new System.Drawing.Font("宋体", 11F);
            this.textBoxArguments.HintText = "启动参数(可不填)";
            this.textBoxArguments.LetterOnly = false;
            this.textBoxArguments.Location = new System.Drawing.Point(8, 247);
            this.textBoxArguments.Name = "textBoxArguments";
            this.textBoxArguments.NumberOnly = false;
            this.textBoxArguments.Size = new System.Drawing.Size(305, 26);
            this.textBoxArguments.TabIndex = 5;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(8, 202);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(113, 15);
            this.lblDelay.TabIndex = 19;
            this.lblDelay.Text = "延迟启动(秒)：";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDelay.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxDelay.HintFont = new System.Drawing.Font("宋体", 11F);
            this.textBoxDelay.HintText = "延迟时间";
            this.textBoxDelay.LetterOnly = false;
            this.textBoxDelay.Location = new System.Drawing.Point(127, 199);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.NumberOnly = true;
            this.textBoxDelay.Size = new System.Drawing.Size(185, 26);
            this.textBoxDelay.TabIndex = 4;
            // 
            // lblFile
            // 
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.lblFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F);
            this.lblFile.Location = new System.Drawing.Point(287, 79);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 20);
            this.lblFile.TabIndex = 14;
            this.lblFile.Text = "...";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFile.Click += new System.EventHandler(this.lblFileOpen_Click);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLocation.Location = new System.Drawing.Point(8, 103);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(305, 24);
            this.textBoxLocation.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Location = new System.Drawing.Point(8, 33);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(305, 24);
            this.textBoxName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 15);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "模块名称：";
            // 
            // lblLoaction
            // 
            this.lblLoaction.AutoSize = true;
            this.lblLoaction.Location = new System.Drawing.Point(8, 77);
            this.lblLoaction.Name = "lblLoaction";
            this.lblLoaction.Size = new System.Drawing.Size(82, 15);
            this.lblLoaction.TabIndex = 7;
            this.lblLoaction.Text = "模块路径：";
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 11F);
            this.btnYes.Location = new System.Drawing.Point(31, 434);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(305, 34);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "确        定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // cbBoxType
            // 
            this.cbBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoxType.Font = new System.Drawing.Font("宋体", 11F);
            this.cbBoxType.FormattingEnabled = true;
            this.cbBoxType.Location = new System.Drawing.Point(31, 75);
            this.cbBoxType.Name = "cbBoxType";
            this.cbBoxType.Size = new System.Drawing.Size(304, 23);
            this.cbBoxType.TabIndex = 15;
            this.cbBoxType.SelectedIndexChanged += new System.EventHandler(this.cbBoxType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("宋体", 11F);
            this.lblType.Location = new System.Drawing.Point(32, 47);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(142, 15);
            this.lblType.TabIndex = 16;
            this.lblType.Text = "选择模块模板类型：";
            // 
            // FormModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 482);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbBoxType);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FormModule";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "FormModule";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private ControlAstro.Controls.TextBoxWatermark textBoxArguments;
        private System.Windows.Forms.Label lblDelay;
        private ControlAstro.Controls.TextBoxWatermark textBoxDelay;
        private ControlAstro.Controls.LabelButton lblFile;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLoaction;
        private ControlAstro.Controls.CircleButton btnYes;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.ComboBox cbBoxType;
        private System.Windows.Forms.Label lblType;
    }
}