namespace RDIFramework.WinModule
{
    partial class FrmParameterAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParameterAdd));
            this.txtCategoryKey = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtParameterContent = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParameterContent = new System.Windows.Forms.Label();
            this.lblCategoryKey = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtParameterCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.txtParameterId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParameterId = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.lblOptionSet = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblParameterCode = new System.Windows.Forms.Label();
            this.tlsTool.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCategoryKey
            // 
            this.txtCategoryKey.AccessibleName = "EmptyValue|NotNull";
            this.txtCategoryKey.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCategoryKey.Border.Class = "TextBoxBorder";
            this.txtCategoryKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCategoryKey.FocusHighlightEnabled = true;
            this.txtCategoryKey.Location = new System.Drawing.Point(95, 22);
            this.txtCategoryKey.MaxLength = 15;
            this.txtCategoryKey.Name = "txtCategoryKey";
            this.txtCategoryKey.SelectedValue = null;
            this.txtCategoryKey.Size = new System.Drawing.Size(356, 23);
            this.txtCategoryKey.TabIndex = 0;
            this.txtCategoryKey.Tag = "分类键值";
            // 
            // txtParameterContent
            // 
            this.txtParameterContent.AccessibleName = "EmptyValue";
            this.txtParameterContent.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParameterContent.Border.Class = "TextBoxBorder";
            this.txtParameterContent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParameterContent.FocusHighlightEnabled = true;
            this.txtParameterContent.Location = new System.Drawing.Point(95, 111);
            this.txtParameterContent.MaxLength = 15;
            this.txtParameterContent.Name = "txtParameterContent";
            this.txtParameterContent.SelectedValue = null;
            this.txtParameterContent.Size = new System.Drawing.Size(356, 23);
            this.txtParameterContent.TabIndex = 3;
            this.txtParameterContent.Tag = "参数内容";
            // 
            // lblParameterContent
            // 
            this.lblParameterContent.AutoEllipsis = true;
            this.lblParameterContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblParameterContent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblParameterContent.Location = new System.Drawing.Point(12, 114);
            this.lblParameterContent.Name = "lblParameterContent";
            this.lblParameterContent.Size = new System.Drawing.Size(89, 14);
            this.lblParameterContent.TabIndex = 51;
            this.lblParameterContent.Text = "参数内容：";
            this.lblParameterContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryKey
            // 
            this.lblCategoryKey.AutoEllipsis = true;
            this.lblCategoryKey.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCategoryKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCategoryKey.Location = new System.Drawing.Point(15, 23);
            this.lblCategoryKey.Name = "lblCategoryKey";
            this.lblCategoryKey.Size = new System.Drawing.Size(86, 14);
            this.lblCategoryKey.TabIndex = 47;
            this.lblCategoryKey.Text = "分类键值：";
            this.lblCategoryKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtDescription.Location = new System.Drawing.Point(95, 170);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(356, 86);
            this.txtDescription.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 173);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "描  述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParameterCode
            // 
            this.txtParameterCode.AccessibleName = "EmptyValue|NotNull";
            this.txtParameterCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParameterCode.Border.Class = "TextBoxBorder";
            this.txtParameterCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParameterCode.FocusHighlightEnabled = true;
            this.txtParameterCode.Location = new System.Drawing.Point(95, 81);
            this.txtParameterCode.MaxLength = 15;
            this.txtParameterCode.Name = "txtParameterCode";
            this.txtParameterCode.SelectedValue = null;
            this.txtParameterCode.Size = new System.Drawing.Size(356, 23);
            this.txtParameterCode.TabIndex = 2;
            this.txtParameterCode.Tag = "参数编号";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(463, 25);
            this.tlsTool.TabIndex = 3;
            this.tlsTool.Text = "toolStrip1";
            // 
            // txtParameterId
            // 
            this.txtParameterId.AccessibleName = "EmptyValue|NotNull";
            this.txtParameterId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParameterId.Border.Class = "TextBoxBorder";
            this.txtParameterId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParameterId.FocusHighlightEnabled = true;
            this.txtParameterId.Location = new System.Drawing.Point(95, 50);
            this.txtParameterId.Name = "txtParameterId";
            this.txtParameterId.SelectedValue = null;
            this.txtParameterId.Size = new System.Drawing.Size(356, 23);
            this.txtParameterId.TabIndex = 1;
            this.txtParameterId.Tag = "参数主键";
            // 
            // lblParameterId
            // 
            this.lblParameterId.AutoEllipsis = true;
            this.lblParameterId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblParameterId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblParameterId.Location = new System.Drawing.Point(12, 53);
            this.lblParameterId.Name = "lblParameterId";
            this.lblParameterId.Size = new System.Drawing.Size(89, 14);
            this.lblParameterId.TabIndex = 4;
            this.lblParameterId.Text = "参数主键：";
            this.lblParameterId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.chkAllowDelete);
            this.gbDetail.Controls.Add(this.chkAllowEdit);
            this.gbDetail.Controls.Add(this.lblOptionSet);
            this.gbDetail.Controls.Add(this.chkEnabled);
            this.gbDetail.Controls.Add(this.txtCategoryKey);
            this.gbDetail.Controls.Add(this.txtParameterContent);
            this.gbDetail.Controls.Add(this.lblParameterContent);
            this.gbDetail.Controls.Add(this.lblCategoryKey);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.lblDescription);
            this.gbDetail.Controls.Add(this.txtParameterId);
            this.gbDetail.Controls.Add(this.lblParameterId);
            this.gbDetail.Controls.Add(this.txtParameterCode);
            this.gbDetail.Controls.Add(this.lblParameterCode);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(0, 25);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(463, 266);
            this.gbDetail.TabIndex = 4;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "基本信息";
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AccessibleName = "EmptyValue";
            this.chkAllowDelete.Checked = true;
            this.chkAllowDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowDelete.Location = new System.Drawing.Point(283, 146);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(96, 18);
            this.chkAllowDelete.TabIndex = 6;
            this.chkAllowDelete.Tag = "允许删除";
            this.chkAllowDelete.Text = "允许删除";
            this.chkAllowDelete.UseVisualStyleBackColor = true;
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AccessibleName = "EmptyValue";
            this.chkAllowEdit.Checked = true;
            this.chkAllowEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowEdit.Location = new System.Drawing.Point(187, 146);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(93, 18);
            this.chkAllowEdit.TabIndex = 5;
            this.chkAllowEdit.Tag = "允许编辑";
            this.chkAllowEdit.Text = "允许编辑";
            this.chkAllowEdit.UseVisualStyleBackColor = true;
            // 
            // lblOptionSet
            // 
            this.lblOptionSet.AutoEllipsis = true;
            this.lblOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.lblOptionSet.Location = new System.Drawing.Point(-5, 146);
            this.lblOptionSet.Name = "lblOptionSet";
            this.lblOptionSet.Size = new System.Drawing.Size(106, 14);
            this.lblOptionSet.TabIndex = 79;
            this.lblOptionSet.Text = "选项设置：";
            this.lblOptionSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AccessibleName = "EmptyValue";
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(102, 146);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(93, 18);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblParameterCode
            // 
            this.lblParameterCode.AutoEllipsis = true;
            this.lblParameterCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblParameterCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblParameterCode.Location = new System.Drawing.Point(12, 84);
            this.lblParameterCode.Name = "lblParameterCode";
            this.lblParameterCode.Size = new System.Drawing.Size(89, 14);
            this.lblParameterCode.TabIndex = 2;
            this.lblParameterCode.Text = "参数编号：";
            this.lblParameterCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmParameterAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 291);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.Name = "FrmParameterAdd";
            this.Text = "新增参数";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcTextBox txtCategoryKey;
        private Controls.UcTextBox txtParameterContent;
        private System.Windows.Forms.Label lblParameterContent;
        private System.Windows.Forms.Label lblCategoryKey;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtParameterCode;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip tlsTool;
        private Controls.UcTextBox txtParameterId;
        private System.Windows.Forms.Label lblParameterId;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblParameterCode;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private System.Windows.Forms.CheckBox chkAllowEdit;
        private System.Windows.Forms.Label lblOptionSet;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}