namespace RDIFramework.WinModule
{
    partial class FrmAddItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddItems));
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.cboCategory = new RDIFramework.Controls.UcComboBoxEx();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtParentId = new RDIFramework.WinModule.UcItemsSelect();
            this.lblParentId = new System.Windows.Forms.Label();
            this.tlsUserAdd.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 30);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.AccessibleName = "EmptyValue";
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DisplayMember = "Text";
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 17;
            this.cboCategory.Location = new System.Drawing.Point(90, 102);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(292, 23);
            this.cboCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoEllipsis = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 106);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(91, 14);
            this.lblCategory.TabIndex = 40;
            this.lblCategory.Text = "分类：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(393, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(391, 19);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 38;
            this.lblUserNameReq.Text = "*";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(90, 229);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(54, 18);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(90, 130);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(292, 85);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Tag = "描述";
            // 
            // txtFullName
            // 
            this.txtFullName.AccessibleName = "EmptyValue|NotNull";
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(90, 46);
            this.txtFullName.MaxLength = 30;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(292, 23);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Tag = "名称";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveContinue.Image")));
            this.btnSaveContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(57, 30);
            this.btnSaveContinue.Text = "继续";
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.AutoSize = false;
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveContinue,
            this.toolStripSeparator5,
            this.btnCancel,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(0, 0);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(422, 33);
            this.tlsUserAdd.TabIndex = 15;
            this.tlsUserAdd.Text = "toolStrip1";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCode
            // 
            this.txtCode.AccessibleName = "EmptyValue|NotNull";
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.FocusHighlightEnabled = true;
            this.txtCode.Location = new System.Drawing.Point(90, 17);
            this.txtCode.MaxLength = 25;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(292, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.Tag = "编号";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 135);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(91, 14);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.Location = new System.Drawing.Point(3, 50);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(91, 14);
            this.lblFullName.TabIndex = 7;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.Location = new System.Drawing.Point(3, 21);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(91, 14);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.txtParentId);
            this.pnlMain.Controls.Add(this.lblParentId);
            this.pnlMain.Controls.Add(this.cboCategory);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.lblUserNameReq);
            this.pnlMain.Controls.Add(this.chkEnabled);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.txtFullName);
            this.pnlMain.Controls.Add(this.txtCode);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.lblFullName);
            this.pnlMain.Controls.Add(this.lblCode);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 33);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(422, 253);
            this.pnlMain.TabIndex = 14;
            // 
            // txtParentId
            // 
            this.txtParentId.AccessibleName = "EmptyValue";
            this.txtParentId.AllowNull = true;
            this.txtParentId.AllowSelect = true;
            this.txtParentId.CheckMove = false;
            this.txtParentId.Location = new System.Drawing.Point(90, 73);
            this.txtParentId.MultiSelect = false;
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.OpenId = "";
            this.txtParentId.PermissionScopeCode = "";
            this.txtParentId.SelectedFullName = "";
            this.txtParentId.SelectedId = null;
            this.txtParentId.Size = new System.Drawing.Size(292, 24);
            this.txtParentId.TabIndex = 43;
            // 
            // lblParentId
            // 
            this.lblParentId.AutoEllipsis = true;
            this.lblParentId.Location = new System.Drawing.Point(3, 78);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(91, 14);
            this.lblParentId.TabIndex = 42;
            this.lblParentId.Text = "父节点：";
            this.lblParentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmAddItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 286);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsUserAdd);
            this.Name = "FrmAddItems";
            this.Text = "增加数据字典";
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnClose;
        private Controls.UcComboBoxEx cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.CheckBox chkEnabled;
        private Controls.UcTextBox txtDescription;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblParentId;
        private UcItemsSelect txtParentId;
    }
}