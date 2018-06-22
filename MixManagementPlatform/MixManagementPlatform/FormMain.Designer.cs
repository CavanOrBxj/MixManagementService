namespace MixManagementPlatform
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dgvMix = new System.Windows.Forms.DataGridView();
            this.ColumnModuleConfig = new MixManagementPlatform.Controls.DataGridViewDisableButtonColumn();
            this.ColumnEdit = new MixManagementPlatform.Controls.DataGridViewStateColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStartIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLoaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArguments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemModule = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewStateColumn1 = new MixManagementPlatform.Controls.DataGridViewStateColumn();
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.btnYes = new ControlAstro.Controls.CircleButton();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.textBoxArguments = new ControlAstro.Controls.TextBoxWatermark();
            this.lblDelay = new System.Windows.Forms.Label();
            this.textBoxDelay = new ControlAstro.Controls.TextBoxWatermark();
            this.lblFile = new ControlAstro.Controls.LabelButton();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLoaction = new System.Windows.Forms.Label();
            this.btnDel = new ControlAstro.Controls.CircleButton();
            this.btnAdd = new ControlAstro.Controls.CircleButton();
            this.btnAutoStart = new ControlAstro.Controls.CircleButton();
            this.lblError = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMix)).BeginInit();
            this.menuStripDgv.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBoxEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMix
            // 
            this.dgvMix.AllowUserToAddRows = false;
            this.dgvMix.AllowUserToDeleteRows = false;
            this.dgvMix.AllowUserToResizeRows = false;
            this.dgvMix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMix.BackgroundColor = System.Drawing.Color.White;
            this.dgvMix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnModuleConfig,
            this.ColumnEdit,
            this.ColumnState,
            this.ColumnStartIndex,
            this.ColumnName,
            this.ColumnLoaction,
            this.ColumnArguments});
            this.dgvMix.ContextMenuStrip = this.menuStripDgv;
            this.dgvMix.Location = new System.Drawing.Point(11, 64);
            this.dgvMix.MultiSelect = false;
            this.dgvMix.Name = "dgvMix";
            this.dgvMix.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMix.RowHeadersWidth = 39;
            this.dgvMix.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMix.RowTemplate.Height = 25;
            this.dgvMix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMix.Size = new System.Drawing.Size(734, 560);
            this.dgvMix.TabIndex = 0;
            this.dgvMix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMix_CellContentClick);
            this.dgvMix.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMix_CellContentDoubleClick);
            this.dgvMix.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMix_CellFormatting);
            this.dgvMix.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMix_RowPostPaint);
            this.dgvMix.SelectionChanged += new System.EventHandler(this.dgvMix_SelectionChanged);
            // 
            // ColumnModuleConfig
            // 
            this.ColumnModuleConfig.Frozen = true;
            this.ColumnModuleConfig.HeaderText = "参数配置";
            this.ColumnModuleConfig.Name = "ColumnModuleConfig";
            this.ColumnModuleConfig.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnModuleConfig.Text = "编辑配置";
            this.ColumnModuleConfig.UseColumnTextForButtonValue = true;
            this.ColumnModuleConfig.Width = 80;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.DataPropertyName = "state";
            this.ColumnEdit.Frozen = true;
            this.ColumnEdit.HeaderText = "操作";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnState
            // 
            this.ColumnState.DataPropertyName = "state";
            this.ColumnState.Frozen = true;
            this.ColumnState.HeaderText = "运行状态";
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            this.ColumnState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnStartIndex
            // 
            this.ColumnStartIndex.DataPropertyName = "Startindex";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnStartIndex.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnStartIndex.HeaderText = "启动顺序";
            this.ColumnStartIndex.Name = "ColumnStartIndex";
            this.ColumnStartIndex.ReadOnly = true;
            this.ColumnStartIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnStartIndex.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.HeaderText = "模块名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 127;
            // 
            // ColumnLoaction
            // 
            this.ColumnLoaction.DataPropertyName = "path";
            this.ColumnLoaction.HeaderText = "模块路径";
            this.ColumnLoaction.Name = "ColumnLoaction";
            this.ColumnLoaction.ReadOnly = true;
            this.ColumnLoaction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLoaction.Width = 127;
            // 
            // ColumnArguments
            // 
            this.ColumnArguments.DataPropertyName = "arguments";
            this.ColumnArguments.HeaderText = "参数信息";
            this.ColumnArguments.Name = "ColumnArguments";
            this.ColumnArguments.ReadOnly = true;
            this.ColumnArguments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuStripDgv
            // 
            this.menuStripDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemInfo,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDel,
            this.toolStripMenuItemEditConfig});
            this.menuStripDgv.Name = "menuStripTitle";
            this.menuStripDgv.Size = new System.Drawing.Size(125, 114);
            this.menuStripDgv.Opening += new System.ComponentModel.CancelEventHandler(this.menuStripDgv_Opening);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemAdd.Text = "添加";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemInfo
            // 
            this.toolStripMenuItemInfo.Name = "toolStripMenuItemInfo";
            this.toolStripMenuItemInfo.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemInfo.Text = "查看";
            this.toolStripMenuItemInfo.Click += new System.EventHandler(this.toolStripMenuItemInfo_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemEdit.Text = "更新";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemDel.Text = "删除";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.toolStripMenuItemDel_Click);
            // 
            // toolStripMenuItemEditConfig
            // 
            this.toolStripMenuItemEditConfig.Name = "toolStripMenuItemEditConfig";
            this.toolStripMenuItemEditConfig.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemEditConfig.Text = "编辑配置";
            this.toolStripMenuItemEditConfig.Click += new System.EventHandler(this.toolStripMenuItemEditConfig_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemModule,
            this.ToolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(1, 37);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip.Size = new System.Drawing.Size(202, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // ToolStripMenuItemModule
            // 
            this.ToolStripMenuItemModule.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripMenuItemModule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRefresh,
            this.ToolStripMenuItemAutoStart});
            this.ToolStripMenuItemModule.Name = "ToolStripMenuItemModule";
            this.ToolStripMenuItemModule.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.ToolStripMenuItemModule.Size = new System.Drawing.Size(44, 24);
            this.ToolStripMenuItemModule.Text = "模块";
            this.ToolStripMenuItemModule.Visible = false;
            // 
            // ToolStripMenuItemRefresh
            // 
            this.ToolStripMenuItemRefresh.Name = "ToolStripMenuItemRefresh";
            this.ToolStripMenuItemRefresh.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemRefresh.Text = "刷新";
            this.ToolStripMenuItemRefresh.Visible = false;
            // 
            // ToolStripMenuItemAutoStart
            // 
            this.ToolStripMenuItemAutoStart.BackColor = System.Drawing.Color.Azure;
            this.ToolStripMenuItemAutoStart.Name = "ToolStripMenuItemAutoStart";
            this.ToolStripMenuItemAutoStart.Size = new System.Drawing.Size(172, 22);
            this.ToolStripMenuItemAutoStart.Text = "配置模块启动顺序";
            this.ToolStripMenuItemAutoStart.Click += new System.EventHandler(this.ToolStripMenuItemAutoStart_Click);
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(44, 24);
            this.ToolStripMenuItemAbout.Text = "关于";
            this.ToolStripMenuItemAbout.Visible = false;
            // 
            // dataGridViewStateColumn1
            // 
            this.dataGridViewStateColumn1.DataPropertyName = "state";
            this.dataGridViewStateColumn1.Frozen = true;
            this.dataGridViewStateColumn1.HeaderText = "运行状态";
            this.dataGridViewStateColumn1.Name = "dataGridViewStateColumn1";
            this.dataGridViewStateColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStateColumn1.Width = 126;
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdit.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEdit.Controls.Add(this.btnYes);
            this.groupBoxEdit.Controls.Add(this.checkBoxAutoStart);
            this.groupBoxEdit.Controls.Add(this.textBoxArguments);
            this.groupBoxEdit.Controls.Add(this.lblDelay);
            this.groupBoxEdit.Controls.Add(this.textBoxDelay);
            this.groupBoxEdit.Controls.Add(this.lblFile);
            this.groupBoxEdit.Controls.Add(this.textBoxLocation);
            this.groupBoxEdit.Controls.Add(this.textBoxName);
            this.groupBoxEdit.Controls.Add(this.lblName);
            this.groupBoxEdit.Controls.Add(this.lblLoaction);
            this.groupBoxEdit.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBoxEdit.Location = new System.Drawing.Point(750, 202);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(272, 314);
            this.groupBoxEdit.TabIndex = 14;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "模块信息编辑";
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.BackColor = System.Drawing.Color.Azure;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnYes.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYes.Location = new System.Drawing.Point(10, 269);
            this.btnYes.Name = "btnYes";
            this.btnYes.Radius = 2;
            this.btnYes.Size = new System.Drawing.Size(256, 34);
            this.btnYes.TabIndex = 31;
            this.btnYes.Text = "更  新  选  中  模  块";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoStart.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxAutoStart.Location = new System.Drawing.Point(36, 156);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(101, 19);
            this.checkBoxAutoStart.TabIndex = 30;
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
            this.textBoxArguments.Location = new System.Drawing.Point(10, 230);
            this.textBoxArguments.Name = "textBoxArguments";
            this.textBoxArguments.NumberOnly = false;
            this.textBoxArguments.Size = new System.Drawing.Size(256, 26);
            this.textBoxArguments.TabIndex = 29;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDelay.Location = new System.Drawing.Point(8, 193);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(113, 15);
            this.lblDelay.TabIndex = 28;
            this.lblDelay.Text = "延迟启动(秒)：";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDelay.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxDelay.HintFont = new System.Drawing.Font("宋体", 11F);
            this.textBoxDelay.HintText = "非自启时无效";
            this.textBoxDelay.LetterOnly = false;
            this.textBoxDelay.Location = new System.Drawing.Point(125, 187);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.NumberOnly = true;
            this.textBoxDelay.Size = new System.Drawing.Size(141, 26);
            this.textBoxDelay.TabIndex = 27;
            // 
            // lblFile
            // 
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.lblFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F);
            this.lblFile.Location = new System.Drawing.Point(241, 85);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(25, 20);
            this.lblFile.TabIndex = 26;
            this.lblFile.Text = "...";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFile.Click += new System.EventHandler(this.lblFileOpen_Click);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLocation.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxLocation.Location = new System.Drawing.Point(10, 115);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.ReadOnly = true;
            this.textBoxLocation.Size = new System.Drawing.Size(256, 26);
            this.textBoxLocation.TabIndex = 25;
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxName.Location = new System.Drawing.Point(10, 47);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(256, 26);
            this.textBoxName.TabIndex = 23;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(10, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 15);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "模块名称：";
            // 
            // lblLoaction
            // 
            this.lblLoaction.AutoSize = true;
            this.lblLoaction.Location = new System.Drawing.Point(10, 89);
            this.lblLoaction.Name = "lblLoaction";
            this.lblLoaction.Size = new System.Drawing.Size(82, 15);
            this.lblLoaction.TabIndex = 24;
            this.lblLoaction.Text = "模块路径：";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Azure;
            this.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDel.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(760, 150);
            this.btnDel.Name = "btnDel";
            this.btnDel.Radius = 2;
            this.btnDel.Size = new System.Drawing.Size(256, 34);
            this.btnDel.TabIndex = 33;
            this.btnDel.Text = "删  除  模  块";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Azure;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(760, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 2;
            this.btnAdd.Size = new System.Drawing.Size(256, 34);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "添  加  模  块";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoStart.BackColor = System.Drawing.Color.Azure;
            this.btnAutoStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAutoStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAutoStart.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoStart.Location = new System.Drawing.Point(760, 65);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Radius = 2;
            this.btnAutoStart.Size = new System.Drawing.Size(256, 34);
            this.btnAutoStart.TabIndex = 35;
            this.btnAutoStart.Text = "配 置 模 块 自 启 顺 序";
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(758, 515);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(256, 33);
            this.lblError.TabIndex = 32;
            this.lblError.Text = "模块信息不能为空";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Location = new System.Drawing.Point(982, 620);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(41, 12);
            this.lblVersion.TabIndex = 36;
            this.lblVersion.Text = "版本号";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 636);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnAutoStart);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.groupBoxEdit);
            this.Controls.Add(this.dgvMix);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 555);
            this.Name = "FormMain";
            this.Text = "融合平台管理工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMix)).EndInit();
            this.menuStripDgv.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMix;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemModule;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAutoStart;
        private System.Windows.Forms.ContextMenuStrip menuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private Controls.DataGridViewStateColumn dataGridViewStateColumn1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.GroupBox groupBoxEdit;
        private ControlAstro.Controls.CircleButton btnYes;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private ControlAstro.Controls.TextBoxWatermark textBoxArguments;
        private System.Windows.Forms.Label lblDelay;
        private ControlAstro.Controls.TextBoxWatermark textBoxDelay;
        private ControlAstro.Controls.LabelButton lblFile;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLoaction;
        private ControlAstro.Controls.CircleButton btnDel;
        private ControlAstro.Controls.CircleButton btnAdd;
        private ControlAstro.Controls.CircleButton btnAutoStart;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditConfig;
        private Controls.DataGridViewDisableButtonColumn ColumnModuleConfig;
        private Controls.DataGridViewStateColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStartIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLoaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArguments;
        private System.Windows.Forms.Label lblVersion;
    }
}

