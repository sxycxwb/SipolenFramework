namespace RDIFramework.WinModule
{
    partial class FrmQueryEngineDefineAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueryEngineDefineAdd));
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtQueryEngineId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParent = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.cboDataSourceType = new RDIFramework.Controls.UcComboBoxEx();
            this.cboDataBaseLinkName = new RDIFramework.Controls.UcComboBoxEx();
            this.txtOrderByField = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblOrderByField = new System.Windows.Forms.Label();
            this.txtSelectedField = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSelectedField = new System.Windows.Forms.Label();
            this.txtQueryString = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblQueryString = new System.Windows.Forms.Label();
            this.txtDataSourceName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDataSourceName = new System.Windows.Forms.Label();
            this.lblQueryStringKey = new System.Windows.Forms.Label();
            this.txtQueryStringKey = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDataBaseLinkName = new System.Windows.Forms.Label();
            this.lblDataSourceType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.tlsTool.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(584, 38);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(14, 14);
            this.lblParentReq.TabIndex = 63;
            this.lblParentReq.Text = "*";
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AccessibleName = "EmptyValue";
            this.chkAllowDelete.AutoEllipsis = true;
            this.chkAllowDelete.Location = new System.Drawing.Point(287, 414);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(105, 19);
            this.chkAllowDelete.TabIndex = 12;
            this.chkAllowDelete.Tag = "允许删除";
            this.chkAllowDelete.Text = "允许删除";
            this.chkAllowDelete.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(94, 441);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(484, 39);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(2, 444);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 14);
            this.lblDescription.TabIndex = 60;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AccessibleName = "EmptyValue";
            this.chkAllowEdit.AutoEllipsis = true;
            this.chkAllowEdit.Location = new System.Drawing.Point(187, 414);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(101, 18);
            this.chkAllowEdit.TabIndex = 11;
            this.chkAllowEdit.Tag = "允许编辑";
            this.chkAllowEdit.Text = "允许编辑";
            this.chkAllowEdit.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AccessibleName = "EmptyValue";
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(94, 414);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(95, 18);
            this.chkEnabled.TabIndex = 10;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator5,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(610, 25);
            this.tlsTool.TabIndex = 18;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(313, 75);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(74, 14);
            this.lblFullName.TabIndex = 48;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQueryEngineId
            // 
            this.txtQueryEngineId.AccessibleName = "EmptyValue|NotNull";
            this.txtQueryEngineId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQueryEngineId.Border.Class = "TextBoxBorder";
            this.txtQueryEngineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQueryEngineId.FocusHighlightEnabled = true;
            this.txtQueryEngineId.Location = new System.Drawing.Point(94, 34);
            this.txtQueryEngineId.MaxLength = 15;
            this.txtQueryEngineId.Name = "txtQueryEngineId";
            this.txtQueryEngineId.ReadOnly = true;
            this.txtQueryEngineId.SelectedValue = null;
            this.txtQueryEngineId.Size = new System.Drawing.Size(484, 23);
            this.txtQueryEngineId.TabIndex = 0;
            this.txtQueryEngineId.Tag = "父节点";
            // 
            // lblParent
            // 
            this.lblParent.AutoEllipsis = true;
            this.lblParent.BackColor = System.Drawing.Color.Transparent;
            this.lblParent.Location = new System.Drawing.Point(3, 39);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(91, 14);
            this.lblParent.TabIndex = 42;
            this.lblParent.Text = "查询引擎：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.AccessibleName = "EmptyValue|NotNull";
            this.txtFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(387, 71);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(191, 23);
            this.txtFullName.TabIndex = 2;
            this.txtFullName.Tag = "名称";
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.cboDataSourceType);
            this.gbMain.Controls.Add(this.cboDataBaseLinkName);
            this.gbMain.Controls.Add(this.txtOrderByField);
            this.gbMain.Controls.Add(this.lblOrderByField);
            this.gbMain.Controls.Add(this.txtSelectedField);
            this.gbMain.Controls.Add(this.lblSelectedField);
            this.gbMain.Controls.Add(this.txtQueryString);
            this.gbMain.Controls.Add(this.lblQueryString);
            this.gbMain.Controls.Add(this.txtDataSourceName);
            this.gbMain.Controls.Add(this.lblDataSourceName);
            this.gbMain.Controls.Add(this.lblQueryStringKey);
            this.gbMain.Controls.Add(this.txtQueryStringKey);
            this.gbMain.Controls.Add(this.lblDataBaseLinkName);
            this.gbMain.Controls.Add(this.lblDataSourceType);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.txtCode);
            this.gbMain.Controls.Add(this.lblCode);
            this.gbMain.Controls.Add(this.lblParentReq);
            this.gbMain.Controls.Add(this.chkAllowDelete);
            this.gbMain.Controls.Add(this.txtDescription);
            this.gbMain.Controls.Add(this.lblDescription);
            this.gbMain.Controls.Add(this.chkAllowEdit);
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.lblFullName);
            this.gbMain.Controls.Add(this.txtFullName);
            this.gbMain.Controls.Add(this.txtQueryEngineId);
            this.gbMain.Controls.Add(this.lblParent);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(610, 492);
            this.gbMain.TabIndex = 17;
            this.gbMain.TabStop = false;
            // 
            // cboDataSourceType
            // 
            this.cboDataSourceType.AccessibleName = "EmptyValue";
            this.cboDataSourceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDataSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSourceType.FormattingEnabled = true;
            this.cboDataSourceType.Location = new System.Drawing.Point(387, 100);
            this.cboDataSourceType.Name = "cboDataSourceType";
            this.cboDataSourceType.Size = new System.Drawing.Size(191, 24);
            this.cboDataSourceType.TabIndex = 4;
            // 
            // cboDataBaseLinkName
            // 
            this.cboDataBaseLinkName.AccessibleName = "EmptyValue";
            this.cboDataBaseLinkName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDataBaseLinkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBaseLinkName.FormattingEnabled = true;
            this.cboDataBaseLinkName.Location = new System.Drawing.Point(94, 100);
            this.cboDataBaseLinkName.Name = "cboDataBaseLinkName";
            this.cboDataBaseLinkName.Size = new System.Drawing.Size(213, 24);
            this.cboDataBaseLinkName.TabIndex = 3;
            // 
            // txtOrderByField
            // 
            this.txtOrderByField.AccessibleName = "EmptyValue";
            this.txtOrderByField.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOrderByField.Border.Class = "TextBoxBorder";
            this.txtOrderByField.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderByField.FocusHighlightEnabled = true;
            this.txtOrderByField.Location = new System.Drawing.Point(94, 383);
            this.txtOrderByField.MaxLength = 45;
            this.txtOrderByField.Name = "txtOrderByField";
            this.txtOrderByField.SelectedValue = null;
            this.txtOrderByField.Size = new System.Drawing.Size(484, 23);
            this.txtOrderByField.TabIndex = 9;
            this.txtOrderByField.Tag = "编号";
            // 
            // lblOrderByField
            // 
            this.lblOrderByField.AutoEllipsis = true;
            this.lblOrderByField.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderByField.Location = new System.Drawing.Point(2, 388);
            this.lblOrderByField.Name = "lblOrderByField";
            this.lblOrderByField.Size = new System.Drawing.Size(92, 14);
            this.lblOrderByField.TabIndex = 80;
            this.lblOrderByField.Text = "排序字段：";
            this.lblOrderByField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSelectedField
            // 
            this.txtSelectedField.AccessibleName = "EmptyValue";
            this.txtSelectedField.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSelectedField.Border.Class = "TextBoxBorder";
            this.txtSelectedField.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSelectedField.FocusHighlightEnabled = true;
            this.txtSelectedField.Location = new System.Drawing.Point(94, 326);
            this.txtSelectedField.MaxLength = 800;
            this.txtSelectedField.Multiline = true;
            this.txtSelectedField.Name = "txtSelectedField";
            this.txtSelectedField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedField.SelectedValue = null;
            this.txtSelectedField.Size = new System.Drawing.Size(484, 51);
            this.txtSelectedField.TabIndex = 8;
            this.txtSelectedField.Tag = "描述";
            // 
            // lblSelectedField
            // 
            this.lblSelectedField.AutoEllipsis = true;
            this.lblSelectedField.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedField.Location = new System.Drawing.Point(2, 329);
            this.lblSelectedField.Name = "lblSelectedField";
            this.lblSelectedField.Size = new System.Drawing.Size(92, 14);
            this.lblSelectedField.TabIndex = 78;
            this.lblSelectedField.Text = "字段列表：";
            this.lblSelectedField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQueryString
            // 
            this.txtQueryString.AccessibleName = "EmptyValue";
            this.txtQueryString.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQueryString.Border.Class = "TextBoxBorder";
            this.txtQueryString.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQueryString.FocusHighlightEnabled = true;
            this.txtQueryString.Location = new System.Drawing.Point(94, 159);
            this.txtQueryString.MaxLength = 800;
            this.txtQueryString.Multiline = true;
            this.txtQueryString.Name = "txtQueryString";
            this.txtQueryString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQueryString.SelectedValue = null;
            this.txtQueryString.Size = new System.Drawing.Size(484, 161);
            this.txtQueryString.TabIndex = 7;
            this.txtQueryString.Tag = "描述";
            // 
            // lblQueryString
            // 
            this.lblQueryString.AutoEllipsis = true;
            this.lblQueryString.BackColor = System.Drawing.Color.Transparent;
            this.lblQueryString.Location = new System.Drawing.Point(2, 162);
            this.lblQueryString.Name = "lblQueryString";
            this.lblQueryString.Size = new System.Drawing.Size(92, 14);
            this.lblQueryString.TabIndex = 76;
            this.lblQueryString.Text = "查询语句：";
            this.lblQueryString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataSourceName
            // 
            this.txtDataSourceName.AccessibleName = "EmptyValue|NotNull";
            this.txtDataSourceName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataSourceName.Border.Class = "TextBoxBorder";
            this.txtDataSourceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataSourceName.FocusHighlightEnabled = true;
            this.txtDataSourceName.Location = new System.Drawing.Point(94, 130);
            this.txtDataSourceName.MaxLength = 45;
            this.txtDataSourceName.Name = "txtDataSourceName";
            this.txtDataSourceName.SelectedValue = null;
            this.txtDataSourceName.Size = new System.Drawing.Size(213, 23);
            this.txtDataSourceName.TabIndex = 5;
            this.txtDataSourceName.Tag = "编号";
            // 
            // lblDataSourceName
            // 
            this.lblDataSourceName.AutoEllipsis = true;
            this.lblDataSourceName.BackColor = System.Drawing.Color.Transparent;
            this.lblDataSourceName.Location = new System.Drawing.Point(2, 135);
            this.lblDataSourceName.Name = "lblDataSourceName";
            this.lblDataSourceName.Size = new System.Drawing.Size(92, 14);
            this.lblDataSourceName.TabIndex = 74;
            this.lblDataSourceName.Text = "数据表名称：";
            this.lblDataSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQueryStringKey
            // 
            this.lblQueryStringKey.AutoEllipsis = true;
            this.lblQueryStringKey.BackColor = System.Drawing.Color.Transparent;
            this.lblQueryStringKey.Location = new System.Drawing.Point(302, 134);
            this.lblQueryStringKey.Name = "lblQueryStringKey";
            this.lblQueryStringKey.Size = new System.Drawing.Size(85, 14);
            this.lblQueryStringKey.TabIndex = 73;
            this.lblQueryStringKey.Text = "查询主键：";
            this.lblQueryStringKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQueryStringKey
            // 
            this.txtQueryStringKey.AccessibleName = "EmptyValue|NotNull";
            this.txtQueryStringKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQueryStringKey.Border.Class = "TextBoxBorder";
            this.txtQueryStringKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQueryStringKey.FocusHighlightEnabled = true;
            this.txtQueryStringKey.Location = new System.Drawing.Point(387, 130);
            this.txtQueryStringKey.MaxLength = 150;
            this.txtQueryStringKey.Name = "txtQueryStringKey";
            this.txtQueryStringKey.SelectedValue = null;
            this.txtQueryStringKey.Size = new System.Drawing.Size(191, 23);
            this.txtQueryStringKey.TabIndex = 6;
            this.txtQueryStringKey.Tag = "名称";
            // 
            // lblDataBaseLinkName
            // 
            this.lblDataBaseLinkName.AutoEllipsis = true;
            this.lblDataBaseLinkName.BackColor = System.Drawing.Color.Transparent;
            this.lblDataBaseLinkName.Location = new System.Drawing.Point(2, 102);
            this.lblDataBaseLinkName.Name = "lblDataBaseLinkName";
            this.lblDataBaseLinkName.Size = new System.Drawing.Size(92, 14);
            this.lblDataBaseLinkName.TabIndex = 70;
            this.lblDataBaseLinkName.Text = "连接名称：";
            this.lblDataBaseLinkName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataSourceType
            // 
            this.lblDataSourceType.AutoEllipsis = true;
            this.lblDataSourceType.BackColor = System.Drawing.Color.Transparent;
            this.lblDataSourceType.Location = new System.Drawing.Point(313, 104);
            this.lblDataSourceType.Name = "lblDataSourceType";
            this.lblDataSourceType.Size = new System.Drawing.Size(74, 14);
            this.lblDataSourceType.TabIndex = 69;
            this.lblDataSourceType.Text = "取值：";
            this.lblDataSourceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(584, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 66;
            this.label5.Text = "*";
            // 
            // txtCode
            // 
            this.txtCode.AccessibleName = "EmptyValue|NotNull";
            this.txtCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.FocusHighlightEnabled = true;
            this.txtCode.Location = new System.Drawing.Point(94, 68);
            this.txtCode.MaxLength = 45;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(213, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Tag = "编号";
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(2, 73);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(92, 14);
            this.lblCode.TabIndex = 65;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmQueryEngineDefineAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 492);
            this.Controls.Add(this.tlsTool);
            this.Controls.Add(this.gbMain);
            this.DoubleBuffered = true;
            this.Name = "FrmQueryEngineDefineAdd";
            this.Text = "添加查询引擎定义";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkAllowEdit;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtQueryEngineId;
        private System.Windows.Forms.Label lblParent;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDataBaseLinkName;
        private System.Windows.Forms.Label lblDataSourceType;
        private Controls.UcTextBox txtDataSourceName;
        private System.Windows.Forms.Label lblDataSourceName;
        private System.Windows.Forms.Label lblQueryStringKey;
        private Controls.UcTextBox txtQueryStringKey;
        private Controls.UcTextBox txtQueryString;
        private System.Windows.Forms.Label lblQueryString;
        private Controls.UcTextBox txtSelectedField;
        private System.Windows.Forms.Label lblSelectedField;
        private Controls.UcTextBox txtOrderByField;
        private System.Windows.Forms.Label lblOrderByField;
        private Controls.UcComboBoxEx cboDataBaseLinkName;
        private Controls.UcComboBoxEx cboDataSourceType;
    }
}