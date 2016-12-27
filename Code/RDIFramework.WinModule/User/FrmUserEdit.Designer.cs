/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserEdit));
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.lblSubDepartmentName = new System.Windows.Forms.Label();
            this.lblSubCompanyName = new System.Windows.Forms.Label();
            this.lblWorkgroupName = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.ucOSWorkgroupName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.ucOSSubDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSSubCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.cboRoleName = new RDIFramework.Controls.UcComboBoxEx();
            this.cboGender = new RDIFramework.Controls.UcComboBoxEx();
            this.txtBirthday = new RDIFramework.Controls.UcMaskTextBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtHomeAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.txtEmail = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtQQ = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblQQ = new System.Windows.Forms.Label();
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
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRealName = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbDetail.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 408);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(129, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.lblSubDepartmentName);
            this.gbDetail.Controls.Add(this.lblSubCompanyName);
            this.gbDetail.Controls.Add(this.lblWorkgroupName);
            this.gbDetail.Controls.Add(this.lblDepartmentName);
            this.gbDetail.Controls.Add(this.lblCompanyName);
            this.gbDetail.Controls.Add(this.ucOSWorkgroupName);
            this.gbDetail.Controls.Add(this.chkEnabled);
            this.gbDetail.Controls.Add(this.ucOSSubDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSSubCompanyName);
            this.gbDetail.Controls.Add(this.ucOSCompanyName);
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
            this.gbDetail.Size = new System.Drawing.Size(566, 525);
            this.gbDetail.TabIndex = 3;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "用户信息";
            // 
            // lblSubDepartmentName
            // 
            this.lblSubDepartmentName.AutoEllipsis = true;
            this.lblSubDepartmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubDepartmentName.Location = new System.Drawing.Point(9, 325);
            this.lblSubDepartmentName.Name = "lblSubDepartmentName";
            this.lblSubDepartmentName.Size = new System.Drawing.Size(129, 14);
            this.lblSubDepartmentName.TabIndex = 51;
            this.lblSubDepartmentName.Text = "所在子部门：";
            this.lblSubDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubCompanyName
            // 
            this.lblSubCompanyName.AutoEllipsis = true;
            this.lblSubCompanyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSubCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubCompanyName.Location = new System.Drawing.Point(9, 269);
            this.lblSubCompanyName.Name = "lblSubCompanyName";
            this.lblSubCompanyName.Size = new System.Drawing.Size(129, 14);
            this.lblSubCompanyName.TabIndex = 50;
            this.lblSubCompanyName.Text = "所在子公司：";
            this.lblSubCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkgroupName
            // 
            this.lblWorkgroupName.AutoEllipsis = true;
            this.lblWorkgroupName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkgroupName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorkgroupName.Location = new System.Drawing.Point(9, 353);
            this.lblWorkgroupName.Name = "lblWorkgroupName";
            this.lblWorkgroupName.Size = new System.Drawing.Size(129, 14);
            this.lblWorkgroupName.TabIndex = 49;
            this.lblWorkgroupName.Text = "所在工作组：";
            this.lblWorkgroupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoEllipsis = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDepartmentName.Location = new System.Drawing.Point(12, 298);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(126, 14);
            this.lblDepartmentName.TabIndex = 48;
            this.lblDepartmentName.Text = "所在部门：";
            this.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoEllipsis = true;
            this.lblCompanyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompanyName.Location = new System.Drawing.Point(2, 242);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(136, 14);
            this.lblCompanyName.TabIndex = 47;
            this.lblCompanyName.Text = "所在公司/单位：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucOSWorkgroupName
            // 
            this.ucOSWorkgroupName.AllowNull = true;
            this.ucOSWorkgroupName.AllowSelect = true;
            this.ucOSWorkgroupName.CheckMove = false;
            this.ucOSWorkgroupName.Location = new System.Drawing.Point(138, 349);
            this.ucOSWorkgroupName.MultiSelect = false;
            this.ucOSWorkgroupName.Name = "ucOSWorkgroupName";
            this.ucOSWorkgroupName.OpenId = "";
            this.ucOSWorkgroupName.PermissionScopeCode = "";
            this.ucOSWorkgroupName.SelectedFullName = "";
            this.ucOSWorkgroupName.SelectedId = null;
            this.ucOSWorkgroupName.Size = new System.Drawing.Size(408, 24);
            this.ucOSWorkgroupName.TabIndex = 16;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Location = new System.Drawing.Point(138, 497);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(115, 18);
            this.chkEnabled.TabIndex = 19;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // ucOSSubDepartmentName
            // 
            this.ucOSSubDepartmentName.AllowNull = true;
            this.ucOSSubDepartmentName.AllowSelect = true;
            this.ucOSSubDepartmentName.CheckMove = false;
            this.ucOSSubDepartmentName.Location = new System.Drawing.Point(138, 321);
            this.ucOSSubDepartmentName.MultiSelect = false;
            this.ucOSSubDepartmentName.Name = "ucOSSubDepartmentName";
            this.ucOSSubDepartmentName.OpenId = "";
            this.ucOSSubDepartmentName.PermissionScopeCode = "";
            this.ucOSSubDepartmentName.SelectedFullName = "";
            this.ucOSSubDepartmentName.SelectedId = null;
            this.ucOSSubDepartmentName.Size = new System.Drawing.Size(408, 24);
            this.ucOSSubDepartmentName.TabIndex = 15;
            // 
            // ucOSDepartmentName
            // 
            this.ucOSDepartmentName.AllowNull = true;
            this.ucOSDepartmentName.AllowSelect = true;
            this.ucOSDepartmentName.CheckMove = false;
            this.ucOSDepartmentName.Location = new System.Drawing.Point(138, 293);
            this.ucOSDepartmentName.MultiSelect = false;
            this.ucOSDepartmentName.Name = "ucOSDepartmentName";
            this.ucOSDepartmentName.OpenId = "";
            this.ucOSDepartmentName.PermissionScopeCode = "";
            this.ucOSDepartmentName.SelectedFullName = "";
            this.ucOSDepartmentName.SelectedId = null;
            this.ucOSDepartmentName.Size = new System.Drawing.Size(408, 24);
            this.ucOSDepartmentName.TabIndex = 14;
            // 
            // ucOSSubCompanyName
            // 
            this.ucOSSubCompanyName.AllowNull = true;
            this.ucOSSubCompanyName.AllowSelect = true;
            this.ucOSSubCompanyName.CheckMove = false;
            this.ucOSSubCompanyName.Location = new System.Drawing.Point(138, 264);
            this.ucOSSubCompanyName.MultiSelect = false;
            this.ucOSSubCompanyName.Name = "ucOSSubCompanyName";
            this.ucOSSubCompanyName.OpenId = "";
            this.ucOSSubCompanyName.PermissionScopeCode = "";
            this.ucOSSubCompanyName.SelectedFullName = "";
            this.ucOSSubCompanyName.SelectedId = null;
            this.ucOSSubCompanyName.Size = new System.Drawing.Size(408, 24);
            this.ucOSSubCompanyName.TabIndex = 13;
            // 
            // ucOSCompanyName
            // 
            this.ucOSCompanyName.AllowNull = true;
            this.ucOSCompanyName.AllowSelect = true;
            this.ucOSCompanyName.CheckMove = false;
            this.ucOSCompanyName.Location = new System.Drawing.Point(138, 236);
            this.ucOSCompanyName.MultiSelect = false;
            this.ucOSCompanyName.Name = "ucOSCompanyName";
            this.ucOSCompanyName.OpenId = "";
            this.ucOSCompanyName.PermissionScopeCode = "";
            this.ucOSCompanyName.SelectedFullName = "";
            this.ucOSCompanyName.SelectedId = null;
            this.ucOSCompanyName.Size = new System.Drawing.Size(408, 24);
            this.ucOSCompanyName.TabIndex = 12;
            // 
            // cboRoleName
            // 
            this.cboRoleName.AccessibleName = "EmptyValue|NotNull";
            this.cboRoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleName.FormattingEnabled = true;
            this.cboRoleName.Location = new System.Drawing.Point(138, 208);
            this.cboRoleName.Name = "cboRoleName";
            this.cboRoleName.Size = new System.Drawing.Size(408, 24);
            this.cboRoleName.TabIndex = 11;
            this.cboRoleName.Tag = "默认角色";
            // 
            // cboGender
            // 
            this.cboGender.AccessibleName = "EmptyValue|NotNull";
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(138, 96);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(140, 24);
            this.cboGender.TabIndex = 3;
            this.cboGender.Tag = "性别";
            // 
            // txtBirthday
            // 
            this.txtBirthday.AccessibleName = "EmptyValue";
            this.txtBirthday.BackColor = System.Drawing.Color.White;
            this.txtBirthday.Location = new System.Drawing.Point(138, 122);
            this.txtBirthday.Multiline = false;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Padding = new System.Windows.Forms.Padding(1);
            this.txtBirthday.ReadOnly = false;
            this.txtBirthday.Size = new System.Drawing.Size(139, 27);
            this.txtBirthday.TabIndex = 5;
            this.txtBirthday.Tag = "出生日期";
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
            this.txtDescription.Location = new System.Drawing.Point(138, 405);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(408, 86);
            this.txtDescription.TabIndex = 18;
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
            this.txtHomeAddress.Location = new System.Drawing.Point(138, 378);
            this.txtHomeAddress.MaxLength = 150;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.SelectedValue = null;
            this.txtHomeAddress.Size = new System.Drawing.Size(408, 23);
            this.txtHomeAddress.TabIndex = 17;
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.AutoEllipsis = true;
            this.lblHomeAddress.Location = new System.Drawing.Point(9, 380);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(129, 14);
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
            this.txtEmail.Location = new System.Drawing.Point(382, 179);
            this.txtEmail.MaxLength = 25;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.SelectedValue = null;
            this.txtEmail.Size = new System.Drawing.Size(159, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoEllipsis = true;
            this.lblEmail.Location = new System.Drawing.Point(286, 184);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(101, 14);
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
            this.txtQQ.Location = new System.Drawing.Point(382, 151);
            this.txtQQ.MaxLength = 15;
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.SelectedValue = null;
            this.txtQQ.Size = new System.Drawing.Size(159, 23);
            this.txtQQ.TabIndex = 8;
            // 
            // lblQQ
            // 
            this.lblQQ.AutoEllipsis = true;
            this.lblQQ.Location = new System.Drawing.Point(288, 157);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(99, 14);
            this.lblQQ.TabIndex = 28;
            this.lblQQ.Text = "QQ号码：";
            this.lblQQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtTitle.Location = new System.Drawing.Point(138, 179);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.SelectedValue = null;
            this.txtTitle.Size = new System.Drawing.Size(139, 23);
            this.txtTitle.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 185);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 14);
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
            this.txtDuty.Location = new System.Drawing.Point(138, 153);
            this.txtDuty.MaxLength = 50;
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.SelectedValue = null;
            this.txtDuty.Size = new System.Drawing.Size(139, 23);
            this.txtDuty.TabIndex = 7;
            // 
            // lblDuty
            // 
            this.lblDuty.AutoEllipsis = true;
            this.lblDuty.Location = new System.Drawing.Point(9, 157);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(129, 14);
            this.lblDuty.TabIndex = 22;
            this.lblDuty.Text = "岗位：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoEllipsis = true;
            this.lblBirthday.Location = new System.Drawing.Point(6, 129);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(132, 14);
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
            this.txtTelphone.Location = new System.Drawing.Point(382, 122);
            this.txtTelphone.MaxLength = 20;
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.SelectedValue = null;
            this.txtTelphone.Size = new System.Drawing.Size(159, 23);
            this.txtTelphone.TabIndex = 6;
            // 
            // lblTelphone
            // 
            this.lblTelphone.AutoEllipsis = true;
            this.lblTelphone.Location = new System.Drawing.Point(283, 127);
            this.lblTelphone.Name = "lblTelphone";
            this.lblTelphone.Size = new System.Drawing.Size(104, 14);
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
            this.txtMobile.Location = new System.Drawing.Point(382, 96);
            this.txtMobile.MaxLength = 25;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.SelectedValue = null;
            this.txtMobile.Size = new System.Drawing.Size(159, 23);
            this.txtMobile.TabIndex = 4;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoEllipsis = true;
            this.lblMobile.Location = new System.Drawing.Point(302, 101);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(85, 14);
            this.lblMobile.TabIndex = 16;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGender
            // 
            this.lblGender.AutoEllipsis = true;
            this.lblGender.Location = new System.Drawing.Point(9, 100);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(129, 14);
            this.lblGender.TabIndex = 15;
            this.lblGender.Text = "性别：";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoEllipsis = true;
            this.lblRoleName.Location = new System.Drawing.Point(9, 213);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(129, 14);
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
            this.txtCode.Location = new System.Drawing.Point(138, 69);
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(405, 23);
            this.txtCode.TabIndex = 2;
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.Location = new System.Drawing.Point(9, 74);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(129, 14);
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
            this.txtRealName.Location = new System.Drawing.Point(138, 42);
            this.txtRealName.MaxLength = 15;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(405, 23);
            this.txtRealName.TabIndex = 1;
            this.txtRealName.Tag = "姓名";
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRealName.Location = new System.Drawing.Point(6, 46);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(132, 14);
            this.lblRealName.TabIndex = 2;
            this.lblRealName.Text = "姓名：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleName = "EmptyValue|NotNull";
            this.txtUserName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(138, 16);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(405, 23);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Tag = "登录用户名";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserName.Location = new System.Drawing.Point(17, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(121, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator5,
            this.btnCancel,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(3, 5);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(566, 25);
            this.tlsTool.TabIndex = 41;
            this.tlsTool.Text = "toolStrip1";
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 560);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserEdit";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Text = "编辑用户";
            this.gbDetail.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbDetail;
        private Controls.UcMaskTextBox txtBirthday;
        private Controls.UcTextBox txtHomeAddress;
        private System.Windows.Forms.Label lblHomeAddress;
        private Controls.UcTextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private Controls.UcTextBox txtQQ;
        private System.Windows.Forms.Label lblQQ;
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
        private System.Windows.Forms.Label lblRoleName;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtRealName;
        private System.Windows.Forms.Label lblRealName;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private Controls.UcTextBox txtDescription;
        private Controls.UcComboBoxEx cboGender;
        private Controls.UcComboBoxEx cboRoleName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private UcOrganizeSelect ucOSWorkgroupName;
        private UcOrganizeSelect ucOSSubDepartmentName;
        private UcOrganizeSelect ucOSDepartmentName;
        private UcOrganizeSelect ucOSSubCompanyName;
        private UcOrganizeSelect ucOSCompanyName;
        private System.Windows.Forms.Label lblSubDepartmentName;
        private System.Windows.Forms.Label lblSubCompanyName;
        private System.Windows.Forms.Label lblWorkgroupName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblCompanyName;
    }
}