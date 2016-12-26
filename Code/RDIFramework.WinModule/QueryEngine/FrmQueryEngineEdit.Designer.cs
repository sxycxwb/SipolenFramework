namespace RDIFramework.WinModule
{
    partial class FrmQueryEngineEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueryEngineEdit));
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtParentId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParent = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.gbMain = new System.Windows.Forms.GroupBox();
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
            this.lblParentReq.Location = new System.Drawing.Point(436, 38);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(14, 14);
            this.lblParentReq.TabIndex = 63;
            this.lblParentReq.Text = "*";
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AccessibleName = "EmptyValue";
            this.chkAllowDelete.AutoEllipsis = true;
            this.chkAllowDelete.Location = new System.Drawing.Point(287, 147);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(105, 19);
            this.chkAllowDelete.TabIndex = 5;
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
            this.txtDescription.Location = new System.Drawing.Point(94, 174);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(337, 77);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(2, 177);
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
            this.chkAllowEdit.Location = new System.Drawing.Point(187, 147);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(101, 18);
            this.chkAllowEdit.TabIndex = 4;
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
            this.chkEnabled.Location = new System.Drawing.Point(94, 147);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(95, 18);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(436, 107);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 57;
            this.lblUserNameReq.Text = "*";
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
            this.tlsTool.Size = new System.Drawing.Size(462, 25);
            this.tlsTool.TabIndex = 18;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(2, 105);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(92, 14);
            this.lblFullName.TabIndex = 48;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentId
            // 
            this.txtParentId.AccessibleName = "EmptyValue|NotNull";
            this.txtParentId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParentId.Border.Class = "TextBoxBorder";
            this.txtParentId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParentId.FocusHighlightEnabled = true;
            this.txtParentId.Location = new System.Drawing.Point(94, 34);
            this.txtParentId.MaxLength = 15;
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.ReadOnly = true;
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Size = new System.Drawing.Size(337, 23);
            this.txtParentId.TabIndex = 0;
            this.txtParentId.Tag = "父节点";
            // 
            // lblParent
            // 
            this.lblParent.AutoEllipsis = true;
            this.lblParent.BackColor = System.Drawing.Color.Transparent;
            this.lblParent.Location = new System.Drawing.Point(3, 39);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(91, 14);
            this.lblParent.TabIndex = 42;
            this.lblParent.Text = "父节点：";
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
            this.txtFullName.Location = new System.Drawing.Point(94, 102);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(337, 23);
            this.txtFullName.TabIndex = 2;
            this.txtFullName.Tag = "名称";
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.txtCode);
            this.gbMain.Controls.Add(this.lblCode);
            this.gbMain.Controls.Add(this.lblParentReq);
            this.gbMain.Controls.Add(this.chkAllowDelete);
            this.gbMain.Controls.Add(this.txtDescription);
            this.gbMain.Controls.Add(this.lblDescription);
            this.gbMain.Controls.Add(this.chkAllowEdit);
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.lblUserNameReq);
            this.gbMain.Controls.Add(this.lblFullName);
            this.gbMain.Controls.Add(this.txtFullName);
            this.gbMain.Controls.Add(this.txtParentId);
            this.gbMain.Controls.Add(this.lblParent);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(462, 263);
            this.gbMain.TabIndex = 17;
            this.gbMain.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(436, 70);
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
            this.txtCode.Size = new System.Drawing.Size(337, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Tag = "编号";
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(2, 71);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(92, 14);
            this.lblCode.TabIndex = 65;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmQueryEngineEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 263);
            this.Controls.Add(this.tlsTool);
            this.Controls.Add(this.gbMain);
            this.Name = "FrmQueryEngineEdit";
            this.Text = "编辑查询引擎";
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
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtParentId;
        private System.Windows.Forms.Label lblParent;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblCode;
    }
}