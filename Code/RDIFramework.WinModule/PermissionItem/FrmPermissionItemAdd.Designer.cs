/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:56:12
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmPermissionItemAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissionItemAdd));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.chkIsScope = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetEmpty = new RDIFramework.Controls.UcButton();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.btnSelect = new RDIFramework.Controls.UcButton();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtParentId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParent = new System.Windows.Forms.Label();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain.SuspendLayout();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.lblParentReq);
            this.gbMain.Controls.Add(this.chkIsScope);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.btnSetEmpty);
            this.gbMain.Controls.Add(this.txtDescription);
            this.gbMain.Controls.Add(this.lblDescription);
            this.gbMain.Controls.Add(this.chkIsPublic);
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.lblUserNameReq);
            this.gbMain.Controls.Add(this.btnSelect);
            this.gbMain.Controls.Add(this.txtCode);
            this.gbMain.Controls.Add(this.lblFullName);
            this.gbMain.Controls.Add(this.txtFullName);
            this.gbMain.Controls.Add(this.lblCode);
            this.gbMain.Controls.Add(this.txtParentId);
            this.gbMain.Controls.Add(this.lblParent);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(521, 263);
            this.gbMain.TabIndex = 11;
            this.gbMain.TabStop = false;
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(351, 27);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(14, 14);
            this.lblParentReq.TabIndex = 63;
            this.lblParentReq.Text = "*";
            // 
            // chkIsScope
            // 
            this.chkIsScope.AccessibleName = "EmptyValue";
            this.chkIsScope.AutoEllipsis = true;
            this.chkIsScope.Location = new System.Drawing.Point(295, 134);
            this.chkIsScope.Name = "chkIsScope";
            this.chkIsScope.Size = new System.Drawing.Size(127, 19);
            this.chkIsScope.TabIndex = 5;
            this.chkIsScope.Tag = "数据权限";
            this.chkIsScope.Text = "数据权限";
            this.chkIsScope.UseVisualStyleBackColor = true;
            this.chkIsScope.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(495, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 62;
            this.label5.Text = "*";
            // 
            // btnSetEmpty
            // 
            this.btnSetEmpty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSetEmpty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetEmpty.Location = new System.Drawing.Point(435, 24);
            this.btnSetEmpty.Name = "btnSetEmpty";
            this.btnSetEmpty.Padding = new System.Windows.Forms.Padding(1);
            this.btnSetEmpty.Size = new System.Drawing.Size(67, 26);
            this.btnSetEmpty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetEmpty.TabIndex = 2;
            this.btnSetEmpty.Text = "置空";
            this.btnSetEmpty.Click += new System.EventHandler(this.btnSetEmpty_Click);
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
            this.txtDescription.Location = new System.Drawing.Point(91, 164);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(404, 77);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(8, 166);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 14);
            this.lblDescription.TabIndex = 60;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AccessibleName = "EmptyValue";
            this.chkIsPublic.AutoEllipsis = true;
            this.chkIsPublic.Location = new System.Drawing.Point(189, 134);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(102, 19);
            this.chkIsPublic.TabIndex = 7;
            this.chkIsPublic.Tag = "公开";
            this.chkIsPublic.Text = "公开";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AccessibleName = "EmptyValue";
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(91, 134);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(93, 19);
            this.chkEnabled.TabIndex = 6;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(495, 68);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 57;
            this.lblUserNameReq.Text = "*";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(366, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelect.Size = new System.Drawing.Size(66, 26);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
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
            this.txtCode.Location = new System.Drawing.Point(91, 101);
            this.txtCode.MaxLength = 45;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(403, 23);
            this.txtCode.TabIndex = 4;
            this.txtCode.Tag = "编号";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(4, 66);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(87, 14);
            this.lblFullName.TabIndex = 48;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtFullName.Location = new System.Drawing.Point(91, 62);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(403, 23);
            this.txtFullName.TabIndex = 3;
            this.txtFullName.Tag = "名称";
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(8, 105);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(87, 14);
            this.lblCode.TabIndex = 45;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtParentId.Location = new System.Drawing.Point(91, 24);
            this.txtParentId.MaxLength = 15;
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.ReadOnly = true;
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Size = new System.Drawing.Size(256, 23);
            this.txtParentId.TabIndex = 0;
            this.txtParentId.Tag = "父节点";
            // 
            // lblParent
            // 
            this.lblParent.AutoEllipsis = true;
            this.lblParent.BackColor = System.Drawing.Color.Transparent;
            this.lblParent.Location = new System.Drawing.Point(13, 27);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(82, 14);
            this.lblParent.TabIndex = 42;
            this.lblParent.Text = "父节点：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tlsUserAdd.Size = new System.Drawing.Size(521, 25);
            this.tlsUserAdd.TabIndex = 12;
            this.tlsUserAdd.Text = "toolStrip1";
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
            // btnSaveContinue
            // 
            this.btnSaveContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveContinue.Image")));
            this.btnSaveContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(57, 22);
            this.btnSaveContinue.Text = "继续";
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // FrmPermissionItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 288);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsUserAdd);
            this.MaximizeBox = false;
            this.Name = "FrmPermissionItemAdd";
            this.Text = "增加操作权限";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private Controls.UcButton btnSetEmpty;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblUserNameReq;
        private Controls.UcButton btnSelect;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtParentId;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsScope;
        private System.Windows.Forms.Label lblParentReq;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}