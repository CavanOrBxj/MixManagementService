namespace MixManagementPlatform
{
    partial class FormStartIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartIndex));
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvModule = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDown = new ControlAstro.Controls.LabelButton();
            this.btnUp = new ControlAstro.Controls.LabelButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYes.Location = new System.Drawing.Point(323, 408);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(169, 34);
            this.btnYes.TabIndex = 7;
            this.btnYes.Text = "确        定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.AutoSize = true;
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Location = new System.Drawing.Point(10, 418);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(125, 12);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "模块启动顺序自上而下";
            // 
            // dgvModule
            // 
            this.dgvModule.AllowUserToAddRows = false;
            this.dgvModule.AllowUserToDeleteRows = false;
            this.dgvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModule.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvModule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.ColumnHeadersVisible = false;
            this.dgvModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvModule.Location = new System.Drawing.Point(12, 39);
            this.dgvModule.MultiSelect = false;
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.ReadOnly = true;
            this.dgvModule.RowHeadersVisible = false;
            this.dgvModule.RowTemplate.Height = 26;
            this.dgvModule.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModule.Size = new System.Drawing.Size(480, 363);
            this.dgvModule.TabIndex = 9;
            this.dgvModule.SelectionChanged += new System.EventHandler(this.dgvModule_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "模块名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Path";
            this.Column2.HeaderText = "模块路径";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 378;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(498, 83);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(35, 35);
            this.btnDown.TabIndex = 2;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(498, 39);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 35);
            this.btnUp.TabIndex = 1;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // FormStartIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 453);
            this.Controls.Add(this.dgvModule);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FormStartIndex";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "配置自启动顺序";
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ControlAstro.Controls.LabelButton btnUp;
        private ControlAstro.Controls.LabelButton btnDown;
        private ControlAstro.Controls.CircleButton btnYes;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}