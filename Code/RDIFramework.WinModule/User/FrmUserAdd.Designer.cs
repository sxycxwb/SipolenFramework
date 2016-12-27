/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdd));
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.lblSubDepartmentName = new System.Windows.Forms.Label();
            this.lblSubCompanyName = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cboRoleName = new RDIFramework.Controls.UcComboBoxEx();
            this.cboGender = new RDIFramework.Controls.UcComboBoxEx();
            this.txtBirthday = new RDIFramework.Controls.UcMaskTextBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtHomeAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.txtEmail = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtQQ = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblQQ = new System.Windows.Forms.Label();
            this.txtUserPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.txtTitle = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDuty = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDuty = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtTelphone = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblTelphone = new System.Windows.Forms.Label();
            this.txtMobile = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblWorkgroupName = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRealName = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.ucOSWorkgroupName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSSubDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSSubCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.gbDetail.SuspendLayout();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.AutoSize = true;
            this.gbDetail.Controls.Add(this.ucOSWorkgroupName);
            this.gbDetail.Controls.Add(this.ucOSSubDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSSubCompanyName);
            this.gbDetail.Controls.Add(this.ucOSCompanyName);
            this.gbDetail.Controls.Add(this.lblSubDepartmentName);
            this.gbDetail.Controls.Add(this.lblSubCompanyName);
            this.gbDetail.Controls.Add(this.chkEnabled);
            this.gbDetail.Controls.Add(this.cboRoleName);
            this.gbDetail.Controls.Add(this.cboGender);
            this.gbDetail.Controls.Add(this.txtBirthday);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.lblDescription);
            this.gbDetail.Controls.Add(this.txtHomeAddress);
            this.gbDetail.Controls.Add(this.lblHomeAddress);
            this.gbDetail.Controls.Add(this.txtEmail);
            this.gbDetail.Controls.Add(this.lblEmail);
            this.gbDetail.Controls.Add(this.txtQQ);
            this.gbDetail.Controls.Add(this.lblQQ);
            this.gbDetail.Controls.Add(this.txtUserPassword);
            this.gbDetail.Controls.Add(this.lblUserPassword);
            this.gbDetail.Controls.Add(this.txtTitle);
            this.gbDetail.Controls.Add(this.lblTitle);
            this.gbDetail.Controls.Add(this.txtDuty);
            this.gbDetail.Controls.Add(this.lblDuty);
            this.gbDetail.Controls.Add(this.lblBirthday);
            this.gbDetail.Controls.Add(this.txtTelphone);
            this.gbDetail.Controls.Add(this.lblTelphone);
            this.gbDetail.Controls.Add(this.txtMobile);
            this.gbDetail.Controls.Add(this.lblMobile);
            this.gbDetail.Controls.Add(this.lblGender);
            this.gbDetail.Controls.Add(this.lblWorkgroupName);
            this.gbDetail.Controls.Add(this.lblDepartmentName);
            this.gbDetail.Controls.Add(this.lblCompanyName);
            this.gbDetail.Controls.Add(this.lblRoleName);
            this.gbDetail.Controls.Add(this.txtCode);
            this.gbDetail.Controls.Add(this.lblCode);
            this.gbDetail.Controls.Add(this.txtRealName);
            this.gbDetail.Controls.Add(this.lblRealName);
            this.gbDetail.Controls.Add(this.txtUserName);
            this.gbDetail.Controls.Add(this.lblUserName);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(3, 30);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.gbDetail.Size = new System.Drawing.Size(552, 515);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "用户信息";
            // 
            // lblSubDepartmentName
            // 
            this.lblSubDepartmentName.AutoEllipsis = true;
            this.lblSubDepartmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubDepartmentName.Location = new System.Drawing.Point(3, 340);
            this.lblSubDepartmentName.Name = "lblSubDepartmentName";
            this.lblSubDepartmentName.Size = new System.Drawing.Size(125, 14);
            this.lblSubDepartmentName.TabIndex = 42;
            this.lblSubDepartmentName.Text = "所在子部门：";
            this.lblSubDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubCompanyName
            // 
            this.lblSubCompanyName.AutoEllipsis = true;
            this.lblSubCompanyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubCompanyName.Location = new System.Drawing.Point(8, 283);
            this.lblSubCompanyName.Name = "lblSubCompanyName";
            this.lblSubCompanyName.Size = new System.Drawing.Size(120, 14);
            this.lblSubCompanyName.TabIndex = 40;
            this.lblSubCompanyName.Text = "所在子公司：";
            this.lblSubCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(126, 395);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(97, 19);
            this.chkEnabled.TabIndex = 20;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // cboRoleName
            // 
            this.cboRoleName.AccessibleName = "EmptyValue|NotNull";
            this.cboRoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleName.FormattingEnabled = true;
            this.cboRoleName.ItemHeight = 17;
            this.cboRoleName.Location = new System.Drawing.Point(126, 221);
            this.cboRoleName.Name = "cboRoleName";
            this.cboRoleName.Size = new System.Drawing.Size(414, 23);
            this.cboRoleName.TabIndex = 14;
            this.cboRoleName.Tag = "默认角色";
            // 
            // cboGender
            // 
            this.cboGender.AccessibleName = "EmptyValue|NotNull";
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.ItemHeight = 17;
            this.cboGender.Location = new System.Drawing.Point(382, 47);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(158, 23);
            this.cboGender.TabIndex = 3;
            this.cboGender.Tag = "性别";
            // 
            // txtBirthday
            // 
            this.txtBirthday.AccessibleName = "EmptyValue";
            this.txtBirthday.BackColor = System.Drawing.Color.White;
            this.txtBirthday.Location = new System.Drawing.Point(382, 77);
            this.txtBirthday.Multiline = false;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Padding = new System.Windows.Forms.Padding(1);
            this.txtBirthday.ReadOnly = false;
            this.txtBirthday.Size = new System.Drawing.Size(158, 27);
            this.txtBirthday.TabIndex = 6;
            this.txtBirthday.Text = "    -  -";
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
            this.txtDescription.Location = new System.Drawing.Point(126, 422);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(414, 78);
            this.txtDescription.TabIndex = 21;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 424);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(122, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.AccessibleName = "EmptyValue";
            this.txtHomeAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtHomeAddress.Border.Class = "TextBoxBorder";
            this.txtHomeAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHomeAddress.FocusHighlightEnabled = true;
            this.txtHomeAddress.Location = new System.Drawing.Point(126, 192);
            this.txtHomeAddress.MaxLength = 150;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.SelectedValue = null;
            this.txtHomeAddress.Size = new System.Drawing.Size(414, 23);
            this.txtHomeAddress.TabIndex = 13;
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.AutoEllipsis = true;
            this.lblHomeAddress.Location = new System.Drawing.Point(14, 196);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(114, 14);
            this.lblHomeAddress.TabIndex = 32;
            this.lblHomeAddress.Text = "家庭住址：";
            this.lblHomeAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.AccessibleName = "EmptyValue";
            this.txtEmail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.FocusHighlightEnabled = true;
            this.txtEmail.Location = new System.Drawing.Point(382, 163);
            this.txtEmail.MaxLength = 25;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.SelectedValue = null;
            this.txtEmail.Size = new System.Drawing.Size(158, 23);
            this.txtEmail.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoEllipsis = true;
            this.lblEmail.Location = new System.Drawing.Point(290, 167);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(96, 14);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "电子邮件：";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQQ
            // 
            this.txtQQ.AccessibleName = "EmptyValue";
            this.txtQQ.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQQ.Border.Class = "TextBoxBorder";
            this.txtQQ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQQ.FocusHighlightEnabled = true;
            this.txtQQ.Location = new System.Drawing.Point(126, 163);
            this.txtQQ.MaxLength = 15;
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.SelectedValue = null;
            this.txtQQ.Size = new System.Drawing.Size(158, 23);
            this.txtQQ.TabIndex = 11;
            // 
            // lblQQ
            // 
            this.lblQQ.AutoEllipsis = true;
            this.lblQQ.Location = new System.Drawing.Point(57, 166);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(71, 14);
            this.lblQQ.TabIndex = 28;
            this.lblQQ.Text = "QQ号码：";
            this.lblQQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.AccessibleName = "EmptyValue";
            this.txtUserPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUserPassword.Border.Class = "TextBoxBorder";
            this.txtUserPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserPassword.FocusHighlightEnabled = true;
            this.txtUserPassword.Location = new System.Drawing.Point(126, 77);
            this.txtUserPassword.MaxLength = 15;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.SelectedValue = null;
            this.txtUserPassword.Size = new System.Drawing.Size(158, 23);
            this.txtUserPassword.TabIndex = 5;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoEllipsis = true;
            this.lblUserPassword.Location = new System.Drawing.Point(11, 81);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(117, 14);
            this.lblUserPassword.TabIndex = 26;
            this.lblUserPassword.Text = "密码：";
            this.lblUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.AccessibleName = "EmptyValue";
            this.txtTitle.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTitle.Border.Class = "TextBoxBorder";
            this.txtTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTitle.FocusHighlightEnabled = true;
            this.txtTitle.Location = new System.Drawing.Point(382, 107);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.SelectedValue = null;
            this.txtTitle.Size = new System.Drawing.Size(158, 23);
            this.txtTitle.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(290, 111);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "职称：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuty
            // 
            this.txtDuty.AccessibleName = "EmptyValue";
            this.txtDuty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDuty.Border.Class = "TextBoxBorder";
            this.txtDuty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDuty.FocusHighlightEnabled = true;
            this.txtDuty.Location = new System.Drawing.Point(126, 107);
            this.txtDuty.MaxLength = 50;
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.SelectedValue = null;
            this.txtDuty.Size = new System.Drawing.Size(158, 23);
            this.txtDuty.TabIndex = 7;
            // 
            // lblDuty
            // 
            this.lblDuty.AutoEllipsis = true;
            this.lblDuty.Location = new System.Drawing.Point(11, 111);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(117, 14);
            this.lblDuty.TabIndex = 22;
            this.lblDuty.Text = "岗位：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoEllipsis = true;
            this.lblBirthday.Location = new System.Drawing.Point(290, 83);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(96, 14);
            this.lblBirthday.TabIndex = 20;
            this.lblBirthday.Text = "出生日期：";
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelphone
            // 
            this.txtTelphone.AccessibleName = "EmptyValue";
            this.txtTelphone.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTelphone.Border.Class = "TextBoxBorder";
            this.txtTelphone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTelphone.FocusHighlightEnabled = true;
            this.txtTelphone.Location = new System.Drawing.Point(382, 135);
            this.txtTelphone.MaxLength = 20;
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.SelectedValue = null;
            this.txtTelphone.Size = new System.Drawing.Size(158, 23);
            this.txtTelphone.TabIndex = 10;
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoEllipsis = true;
            this.lblTelphone.Location = new System.Drawing.Point(290, 140);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(96, 14);
            this.lblTelphone.TabIndex = 18;
            this.lblTelphone.Text = "固定电话：";
            this.lblTelphone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.AccessibleName = "EmptyValue";
            this.txtMobile.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMobile.Border.Class = "TextBoxBorder";
            this.txtMobile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMobile.FocusHighlightEnabled = true;
            this.txtMobile.Location = new System.Drawing.Point(126, 135);
            this.txtMobile.MaxLength = 25;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.SelectedValue = null;
            this.txtMobile.Size = new System.Drawing.Size(158, 23);
            this.txtMobile.TabIndex = 9;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoEllipsis = true;
            this.lblMobile.Location = new System.Drawing.Point(11, 139);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(117, 14);
            this.lblMobile.TabIndex = 16;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGender
            // 
            this.lblGender.AutoEllipsis = true;
            this.lblGender.Location = new System.Drawing.Point(290, 52);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(96, 14);
            this.lblGender.TabIndex = 15;
            this.lblGender.Text = "性别：";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkgroupName
            // 
            this.lblWorkgroupName.AutoEllipsis = true;
            this.lblWorkgroupName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkgroupName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorkgroupName.Location = new System.Drawing.Point(6, 370);
            this.lblWorkgroupName.Name = "lblWorkgroupName";
            this.lblWorkgroupName.Size = new System.Drawing.Size(122, 14);
            this.lblWorkgroupName.TabIndex = 13;
            this.lblWorkgroupName.Text = "所在工作组：";
            this.lblWorkgroupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoEllipsis = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDepartmentName.Location = new System.Drawing.Point(3, 311);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(125, 14);
            this.lblDepartmentName.TabIndex = 11;
            this.lblDepartmentName.Text = "所在部门：";
            this.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoEllipsis = true;
            this.lblCompanyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompanyName.Location = new System.Drawing.Point(8, 255);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(120, 14);
            this.lblCompanyName.TabIndex = 9;
            this.lblCompanyName.Text = "所在公司/单位：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoEllipsis = true;
            this.lblRoleName.Location = new System.Drawing.Point(14, 226);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(114, 14);
            this.lblRoleName.TabIndex = 7;
            this.lblRoleName.Text = "默认角色：";
            this.lblRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCode.Location = new System.Drawing.Point(126, 47);
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(158, 23);
            this.txtCode.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.Location = new System.Drawing.Point(11, 51);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(117, 14);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.AccessibleName = "EmptyValue|NotNull";
            this.txtRealName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRealName.Border.Class = "TextBoxBorder";
            this.txtRealName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealName.FocusHighlightEnabled = true;
            this.txtRealName.Location = new System.Drawing.Point(382, 18);
            this.txtRealName.MaxLength = 15;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(158, 23);
            this.txtRealName.TabIndex = 2;
            this.txtRealName.Tag = "姓名";
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRealName.Location = new System.Drawing.Point(287, 22);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(99, 14);
            this.lblRealName.TabIndex = 2;
            this.lblRealName.Text = "姓名：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleName = "EmptyValue|NotNull";
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(126, 18);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(158, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Tag = "登录用户名";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserName.Location = new System.Drawing.Point(23, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(105, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveContinue,
            this.toolStripSeparator5,
            this.btnCancel,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(3, 5);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(552, 25);
            this.tlsUserAdd.TabIndex = 1;
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
            this.btnCancel.Image = global::RDIFramework.WinModule.Properties.Resources.cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucOSWorkgroupName
            // 
            this.ucOSWorkgroupName.AllowNull = true;
            this.ucOSWorkgroupName.AllowSelect = true;
            this.ucOSWorkgroupName.CheckMove = false;
            this.ucOSWorkgroupName.Location = new System.Drawing.Point(126, 364);
            this.ucOSWorkgroupName.MultiSelect = false;
            this.ucOSWorkgroupName.Name = "ucOSWorkgroupName";
            this.ucOSWorkgroupName.OpenId = "";
            this.ucOSWorkgroupName.PermissionScopeCode = "";
            this.ucOSWorkgroupName.SelectedFullName = "";
            this.ucOSWorkgroupName.SelectedId = null;
            this.ucOSWorkgroupName.Size = new System.Drawing.Size(414, 24);
            this.ucOSWorkgroupName.TabIndex = 19;
            // 
            // ucOSSubDepartmentName
            // 
            this.ucOSSubDepartmentName.AllowNull = true;
            this.ucOSSubDepartmentName.AllowSelect = true;
            this.ucOSSubDepartmentName.CheckMove = false;
            this.ucOSSubDepartmentName.Location = new System.Drawing.Point(126, 335);
            this.ucOSSubDepartmentName.MultiSelect = false;
            this.ucOSSubDepartmentName.Name = "ucOSSubDepartmentName";
            this.ucOSSubDepartmentName.OpenId = "";
            this.ucOSSubDepartmentName.PermissionScopeCode = "";
            this.ucOSSubDepartmentName.SelectedFullName = "";
            this.ucOSSubDepartmentName.SelectedId = null;
            this.ucOSSubDepartmentName.Size = new System.Drawing.Size(414, 24);
            this.ucOSSubDepartmentName.TabIndex = 18;
            // 
            // ucOSDepartmentName
            // 
            this.ucOSDepartmentName.AllowNull = true;
            this.ucOSDepartmentName.AllowSelect = true;
            this.ucOSDepartmentName.CheckMove = false;
            this.ucOSDepartmentName.Location = new System.Drawing.Point(126, 307);
            this.ucOSDepartmentName.MultiSelect = false;
            this.ucOSDepartmentName.Name = "ucOSDepartmentName";
            this.ucOSDepartmentName.OpenId = "";
            this.ucOSDepartmentName.PermissionScopeCode = "";
            this.ucOSDepartmentName.SelectedFullName = "";
            this.ucOSDepartmentName.SelectedId = null;
            this.ucOSDepartmentName.Size = new System.Drawing.Size(414, 24);
            this.ucOSDepartmentName.TabIndex = 17;
            // 
            // ucOSSubCompanyName
            // 
            this.ucOSSubCompanyName.AllowNull = true;
            this.ucOSSubCompanyName.AllowSelect = true;
            this.ucOSSubCompanyName.CheckMove = false;
            this.ucOSSubCompanyName.Location = new System.Drawing.Point(126, 278);
            this.ucOSSubCompanyName.MultiSelect = false;
            this.ucOSSubCompanyName.Name = "ucOSSubCompanyName";
            this.ucOSSubCompanyName.OpenId = "";
            this.ucOSSubCompanyName.PermissionScopeCode = "";
            this.ucOSSubCompanyName.SelectedFullName = "";
            this.ucOSSubCompanyName.SelectedId = null;
            this.ucOSSubCompanyName.Size = new System.Drawing.Size(414, 24);
            this.ucOSSubCompanyName.TabIndex = 16;
            // 
            // ucOSCompanyName
            // 
            this.ucOSCompanyName.AllowNull = true;
            this.ucOSCompanyName.AllowSelect = true;
            this.ucOSCompanyName.CheckMove = false;
            this.ucOSCompanyName.Location = new System.Drawing.Point(126, 251);
            this.ucOSCompanyName.MultiSelect = false;
            this.ucOSCompanyName.Name = "ucOSCompanyName";
            this.ucOSCompanyName.OpenId = "";
            this.ucOSCompanyName.PermissionScopeCode = "";
            this.ucOSCompanyName.SelectedFullName = "";
            this.ucOSCompanyName.SelectedId = null;
            this.ucOSCompanyName.Size = new System.Drawing.Size(414, 24);
            this.ucOSCompanyName.TabIndex = 15;
            // 
            // FrmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 550);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.tlsUserAdd);
            this.DoubleBuffered = true;
            this.Name = "FrmUserAdd";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Text = "添加用户";
            this.gbDetail.ResumeLayout(false);
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtRealName;
        private System.Windows.Forms.Label lblRealName;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblWorkgroupName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblCompanyName;
        private Controls.UcTextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private Controls.UcTextBox txtDuty;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblBirthday;
        private Controls.UcTextBox txtTelphone;
        private System.Windows.Forms.Label lblTelphone;
        private Controls.UcTextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblGender;
        private Controls.UcTextBox txtUserPassword;
        private System.Windows.Forms.Label lblUserPassword;
        private Controls.UcTextBox txtHomeAddress;
        private System.Windows.Forms.Label lblHomeAddress;
        private Controls.UcTextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private Controls.UcTextBox txtQQ;
        private System.Windows.Forms.Label lblQQ;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcMaskTextBox txtBirthday;
        private Controls.UcComboBoxEx cboGender;
        private Controls.UcComboBoxEx cboRoleName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.Label lblSubDepartmentName;
        private System.Windows.Forms.Label lblSubCompanyName;
        private UcOrganizeSelect ucOSCompanyName;
        private UcOrganizeSelect ucOSWorkgroupName;
        private UcOrganizeSelect ucOSSubDepartmentName;
        private UcOrganizeSelect ucOSDepartmentName;
        private UcOrganizeSelect ucOSSubCompanyName;
    }
}