/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:53:11
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmEditOrganize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditOrganize));
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.txtShortName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkIsInnerOrganize = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtWeb = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblWebSite = new System.Windows.Forms.Label();
            this.txtPostalcode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.txtFax = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFax = new System.Windows.Forms.Label();
            this.txtInnerPhone = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblInnerPhone = new System.Windows.Forms.Label();
            this.txtOuterPhone = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.btnDeputySupervisor = new RDIFramework.Controls.UcButton();
            this.btnExecutiveDirector = new RDIFramework.Controls.UcButton();
            this.txtAssistantManager = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtManager = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblAssistantManager = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.cboCategory = new RDIFramework.Controls.UcComboBoxEx();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtParentId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParentId = new System.Windows.Forms.Label();
            this.tlsUserAdd.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
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
            this.tlsUserAdd.Size = new System.Drawing.Size(565, 25);
            this.tlsUserAdd.TabIndex = 11;
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
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.lblShortName);
            this.gbMain.Controls.Add(this.txtShortName);
            this.gbMain.Controls.Add(this.lblUserNameReq);
            this.gbMain.Controls.Add(this.txtDescription);
            this.gbMain.Controls.Add(this.lblDescription);
            this.gbMain.Controls.Add(this.chkIsInnerOrganize);
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.txtAddress);
            this.gbMain.Controls.Add(this.lblAddress);
            this.gbMain.Controls.Add(this.txtWeb);
            this.gbMain.Controls.Add(this.lblWebSite);
            this.gbMain.Controls.Add(this.txtPostalcode);
            this.gbMain.Controls.Add(this.lblPostalcode);
            this.gbMain.Controls.Add(this.txtFax);
            this.gbMain.Controls.Add(this.lblFax);
            this.gbMain.Controls.Add(this.txtInnerPhone);
            this.gbMain.Controls.Add(this.lblInnerPhone);
            this.gbMain.Controls.Add(this.txtOuterPhone);
            this.gbMain.Controls.Add(this.lblOuterPhone);
            this.gbMain.Controls.Add(this.btnDeputySupervisor);
            this.gbMain.Controls.Add(this.btnExecutiveDirector);
            this.gbMain.Controls.Add(this.txtAssistantManager);
            this.gbMain.Controls.Add(this.txtManager);
            this.gbMain.Controls.Add(this.lblAssistantManager);
            this.gbMain.Controls.Add(this.lblManager);
            this.gbMain.Controls.Add(this.cboCategory);
            this.gbMain.Controls.Add(this.lblCategory);
            this.gbMain.Controls.Add(this.txtCode);
            this.gbMain.Controls.Add(this.lblFullName);
            this.gbMain.Controls.Add(this.txtFullName);
            this.gbMain.Controls.Add(this.lblCode);
            this.gbMain.Controls.Add(this.txtParentId);
            this.gbMain.Controls.Add(this.lblParentId);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(565, 510);
            this.gbMain.TabIndex = 12;
            this.gbMain.TabStop = false;
            // 
            // lblShortName
            // 
            this.lblShortName.AutoEllipsis = true;
            this.lblShortName.BackColor = System.Drawing.Color.Transparent;
            this.lblShortName.Location = new System.Drawing.Point(6, 99);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(103, 14);
            this.lblShortName.TabIndex = 74;
            this.lblShortName.Text = "简称：";
            this.lblShortName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShortName
            // 
            this.txtShortName.AccessibleName = "EmptyValue";
            this.txtShortName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtShortName.Border.Class = "TextBoxBorder";
            this.txtShortName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtShortName.FocusHighlightEnabled = true;
            this.txtShortName.Location = new System.Drawing.Point(109, 96);
            this.txtShortName.MaxLength = 150;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.SelectedValue = null;
            this.txtShortName.Size = new System.Drawing.Size(422, 23);
            this.txtShortName.TabIndex = 46;
            this.txtShortName.Tag = "简称";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(537, 67);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 73;
            this.lblUserNameReq.Text = "*";
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
            this.txtDescription.Location = new System.Drawing.Point(109, 385);
            this.txtDescription.MaxLength = 600;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(422, 98);
            this.txtDescription.TabIndex = 68;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(6, 390);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(103, 14);
            this.lblDescription.TabIndex = 72;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsInnerOrganize
            // 
            this.chkIsInnerOrganize.AccessibleName = "EmptyValue|NotNull";
            this.chkIsInnerOrganize.AutoSize = true;
            this.chkIsInnerOrganize.Checked = true;
            this.chkIsInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsInnerOrganize.Location = new System.Drawing.Point(244, 360);
            this.chkIsInnerOrganize.Name = "chkIsInnerOrganize";
            this.chkIsInnerOrganize.Size = new System.Drawing.Size(82, 18);
            this.chkIsInnerOrganize.TabIndex = 66;
            this.chkIsInnerOrganize.Tag = "内部组织";
            this.chkIsInnerOrganize.Text = "内部组织";
            this.chkIsInnerOrganize.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AccessibleName = "EmptyValue|NotNull";
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(109, 359);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(54, 18);
            this.chkEnabled.TabIndex = 64;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleName = "EmptyValue";
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.FocusHighlightEnabled = true;
            this.txtAddress.Location = new System.Drawing.Point(109, 326);
            this.txtAddress.MaxLength = 180;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.SelectedValue = null;
            this.txtAddress.Size = new System.Drawing.Size(422, 23);
            this.txtAddress.TabIndex = 63;
            this.txtAddress.Tag = "地址";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoEllipsis = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Location = new System.Drawing.Point(6, 330);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(103, 14);
            this.lblAddress.TabIndex = 71;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.AccessibleName = "EmptyValue";
            this.txtWeb.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtWeb.Border.Class = "TextBoxBorder";
            this.txtWeb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWeb.FocusHighlightEnabled = true;
            this.txtWeb.Location = new System.Drawing.Point(109, 292);
            this.txtWeb.MaxLength = 180;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.SelectedValue = null;
            this.txtWeb.Size = new System.Drawing.Size(422, 23);
            this.txtWeb.TabIndex = 61;
            this.txtWeb.Tag = "网址";
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoEllipsis = true;
            this.lblWebSite.BackColor = System.Drawing.Color.Transparent;
            this.lblWebSite.Location = new System.Drawing.Point(6, 297);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(103, 14);
            this.lblWebSite.TabIndex = 70;
            this.lblWebSite.Text = "网址：";
            this.lblWebSite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.AccessibleName = "EmptyValue";
            this.txtPostalcode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPostalcode.Border.Class = "TextBoxBorder";
            this.txtPostalcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPostalcode.FocusHighlightEnabled = true;
            this.txtPostalcode.Location = new System.Drawing.Point(346, 257);
            this.txtPostalcode.MaxLength = 30;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.SelectedValue = null;
            this.txtPostalcode.Size = new System.Drawing.Size(185, 23);
            this.txtPostalcode.TabIndex = 60;
            this.txtPostalcode.Tag = "邮编";
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.AutoEllipsis = true;
            this.lblPostalcode.BackColor = System.Drawing.Color.Transparent;
            this.lblPostalcode.Location = new System.Drawing.Point(256, 262);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(95, 14);
            this.lblPostalcode.TabIndex = 69;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFax
            // 
            this.txtFax.AccessibleName = "EmptyValue";
            this.txtFax.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFax.Border.Class = "TextBoxBorder";
            this.txtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFax.FocusHighlightEnabled = true;
            this.txtFax.Location = new System.Drawing.Point(109, 257);
            this.txtFax.MaxLength = 30;
            this.txtFax.Name = "txtFax";
            this.txtFax.SelectedValue = null;
            this.txtFax.Size = new System.Drawing.Size(140, 23);
            this.txtFax.TabIndex = 59;
            this.txtFax.Tag = "传真";
            // 
            // lblFax
            // 
            this.lblFax.AutoEllipsis = true;
            this.lblFax.BackColor = System.Drawing.Color.Transparent;
            this.lblFax.Location = new System.Drawing.Point(6, 261);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(103, 14);
            this.lblFax.TabIndex = 67;
            this.lblFax.Text = "传真：";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInnerPhone
            // 
            this.txtInnerPhone.AccessibleName = "EmptyValue";
            this.txtInnerPhone.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtInnerPhone.Border.Class = "TextBoxBorder";
            this.txtInnerPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInnerPhone.FocusHighlightEnabled = true;
            this.txtInnerPhone.Location = new System.Drawing.Point(346, 225);
            this.txtInnerPhone.MaxLength = 30;
            this.txtInnerPhone.Name = "txtInnerPhone";
            this.txtInnerPhone.SelectedValue = null;
            this.txtInnerPhone.Size = new System.Drawing.Size(185, 23);
            this.txtInnerPhone.TabIndex = 58;
            this.txtInnerPhone.Tag = "内线";
            // 
            // lblInnerPhone
            // 
            this.lblInnerPhone.AutoEllipsis = true;
            this.lblInnerPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblInnerPhone.Location = new System.Drawing.Point(256, 229);
            this.lblInnerPhone.Name = "lblInnerPhone";
            this.lblInnerPhone.Size = new System.Drawing.Size(95, 14);
            this.lblInnerPhone.TabIndex = 65;
            this.lblInnerPhone.Text = "内线：";
            this.lblInnerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOuterPhone
            // 
            this.txtOuterPhone.AccessibleName = "EmptyValue";
            this.txtOuterPhone.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOuterPhone.Border.Class = "TextBoxBorder";
            this.txtOuterPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOuterPhone.FocusHighlightEnabled = true;
            this.txtOuterPhone.Location = new System.Drawing.Point(109, 221);
            this.txtOuterPhone.MaxLength = 30;
            this.txtOuterPhone.Name = "txtOuterPhone";
            this.txtOuterPhone.SelectedValue = null;
            this.txtOuterPhone.Size = new System.Drawing.Size(141, 23);
            this.txtOuterPhone.TabIndex = 57;
            this.txtOuterPhone.Tag = "电话";
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.AutoEllipsis = true;
            this.lblOuterPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblOuterPhone.Location = new System.Drawing.Point(6, 225);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(103, 14);
            this.lblOuterPhone.TabIndex = 62;
            this.lblOuterPhone.Text = "电话：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeputySupervisor
            // 
            this.btnDeputySupervisor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeputySupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeputySupervisor.AutoSize = true;
            this.btnDeputySupervisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnDeputySupervisor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeputySupervisor.Location = new System.Drawing.Point(461, 192);
            this.btnDeputySupervisor.Name = "btnDeputySupervisor";
            this.btnDeputySupervisor.Padding = new System.Windows.Forms.Padding(1);
            this.btnDeputySupervisor.Size = new System.Drawing.Size(70, 26);
            this.btnDeputySupervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeputySupervisor.TabIndex = 55;
            this.btnDeputySupervisor.Text = "选择";
            this.btnDeputySupervisor.Click += new System.EventHandler(this.btnDeputySupervisor_Click);
            // 
            // btnExecutiveDirector
            // 
            this.btnExecutiveDirector.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExecutiveDirector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutiveDirector.AutoSize = true;
            this.btnExecutiveDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnExecutiveDirector.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExecutiveDirector.Location = new System.Drawing.Point(461, 159);
            this.btnExecutiveDirector.Name = "btnExecutiveDirector";
            this.btnExecutiveDirector.Padding = new System.Windows.Forms.Padding(1);
            this.btnExecutiveDirector.Size = new System.Drawing.Size(70, 26);
            this.btnExecutiveDirector.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExecutiveDirector.TabIndex = 52;
            this.btnExecutiveDirector.Text = "选择";
            this.btnExecutiveDirector.Click += new System.EventHandler(this.btnExecutiveDirector_Click);
            // 
            // txtAssistantManager
            // 
            this.txtAssistantManager.AccessibleName = "EmptyValue";
            this.txtAssistantManager.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAssistantManager.Border.Class = "TextBoxBorder";
            this.txtAssistantManager.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAssistantManager.FocusHighlightEnabled = true;
            this.txtAssistantManager.Location = new System.Drawing.Point(109, 190);
            this.txtAssistantManager.MaxLength = 45;
            this.txtAssistantManager.Name = "txtAssistantManager";
            this.txtAssistantManager.SelectedValue = null;
            this.txtAssistantManager.Size = new System.Drawing.Size(346, 23);
            this.txtAssistantManager.TabIndex = 53;
            this.txtAssistantManager.Tag = "副主管";
            // 
            // txtManager
            // 
            this.txtManager.AccessibleName = "EmptyValue";
            this.txtManager.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtManager.Border.Class = "TextBoxBorder";
            this.txtManager.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtManager.FocusHighlightEnabled = true;
            this.txtManager.Location = new System.Drawing.Point(109, 159);
            this.txtManager.MaxLength = 45;
            this.txtManager.Name = "txtManager";
            this.txtManager.SelectedValue = null;
            this.txtManager.Size = new System.Drawing.Size(346, 23);
            this.txtManager.TabIndex = 50;
            this.txtManager.Tag = "主负责人";
            // 
            // lblAssistantManager
            // 
            this.lblAssistantManager.AutoEllipsis = true;
            this.lblAssistantManager.BackColor = System.Drawing.Color.Transparent;
            this.lblAssistantManager.Location = new System.Drawing.Point(6, 195);
            this.lblAssistantManager.Name = "lblAssistantManager";
            this.lblAssistantManager.Size = new System.Drawing.Size(103, 14);
            this.lblAssistantManager.TabIndex = 56;
            this.lblAssistantManager.Text = "副主管：";
            this.lblAssistantManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblManager
            // 
            this.lblManager.AutoEllipsis = true;
            this.lblManager.BackColor = System.Drawing.Color.Transparent;
            this.lblManager.Location = new System.Drawing.Point(6, 163);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(103, 14);
            this.lblManager.TabIndex = 54;
            this.lblManager.Text = "主负责人：";
            this.lblManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCategory
            // 
            this.cboCategory.AccessibleName = "";
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(346, 129);
            this.cboCategory.MaxLength = 45;
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(185, 24);
            this.cboCategory.TabIndex = 49;
            this.cboCategory.Tag = "分类";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoEllipsis = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Location = new System.Drawing.Point(258, 133);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(93, 14);
            this.lblCategory.TabIndex = 51;
            this.lblCategory.Text = "分类：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.AccessibleName = "EmptyValue";
            this.txtCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.FocusHighlightEnabled = true;
            this.txtCode.Location = new System.Drawing.Point(109, 130);
            this.txtCode.MaxLength = 45;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(141, 23);
            this.txtCode.TabIndex = 47;
            this.txtCode.Tag = "编号";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(6, 65);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(103, 14);
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
            this.txtFullName.Location = new System.Drawing.Point(109, 61);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(422, 23);
            this.txtFullName.TabIndex = 44;
            this.txtFullName.Tag = "名称";
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(6, 134);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(103, 14);
            this.lblCode.TabIndex = 45;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentId
            // 
            this.txtParentId.AccessibleName = "";
            this.txtParentId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParentId.Border.Class = "TextBoxBorder";
            this.txtParentId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParentId.FocusHighlightEnabled = true;
            this.txtParentId.Location = new System.Drawing.Point(109, 28);
            this.txtParentId.MaxLength = 15;
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Size = new System.Drawing.Size(422, 23);
            this.txtParentId.TabIndex = 43;
            this.txtParentId.Tag = "父节点";
            // 
            // lblParentId
            // 
            this.lblParentId.AutoEllipsis = true;
            this.lblParentId.BackColor = System.Drawing.Color.Transparent;
            this.lblParentId.Location = new System.Drawing.Point(6, 33);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(103, 14);
            this.lblParentId.TabIndex = 42;
            this.lblParentId.Text = "父节点：";
            this.lblParentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmEditOrganize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 535);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsUserAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditOrganize";
            this.Text = "添加组织机构";
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label lblShortName;
        private Controls.UcTextBox txtShortName;
        private System.Windows.Forms.Label lblUserNameReq;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkIsInnerOrganize;
        private System.Windows.Forms.CheckBox chkEnabled;
        private Controls.UcTextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private Controls.UcTextBox txtWeb;
        private System.Windows.Forms.Label lblWebSite;
        private Controls.UcTextBox txtPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private Controls.UcTextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private Controls.UcTextBox txtInnerPhone;
        private System.Windows.Forms.Label lblInnerPhone;
        private Controls.UcTextBox txtOuterPhone;
        private System.Windows.Forms.Label lblOuterPhone;
        private Controls.UcButton btnDeputySupervisor;
        private Controls.UcButton btnExecutiveDirector;
        private Controls.UcTextBox txtAssistantManager;
        private Controls.UcTextBox txtManager;
        private System.Windows.Forms.Label lblAssistantManager;
        private System.Windows.Forms.Label lblManager;
        private Controls.UcComboBoxEx cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtParentId;
        private System.Windows.Forms.Label lblParentId;
    }
}