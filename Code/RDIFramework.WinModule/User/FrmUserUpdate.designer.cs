/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserUpdate
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
            this.label19 = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cboRoleName = new RDIFramework.Controls.UcComboBoxEx();
            this.cboGender = new RDIFramework.Controls.UcComboBoxEx();
            this.txtBirthday = new RDIFramework.Controls.UcMaskTextBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtHomeAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.txtEmail = new RDIFramework.Controls.UcTextBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.txtQQ = new RDIFramework.Controls.UcTextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtTitle = new RDIFramework.Controls.UcTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtDuty = new RDIFramework.Controls.UcTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelphone = new RDIFramework.Controls.UcTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtMobile = new RDIFramework.Controls.UcTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ucOSWorkgroupName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSSubDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSSubCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.gbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(67, 418);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 14);
            this.label19.TabIndex = 35;
            this.label19.Text = "描述：";
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.ucOSWorkgroupName);
            this.gbDetail.Controls.Add(this.ucOSSubDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSDepartmentName);
            this.gbDetail.Controls.Add(this.ucOSSubCompanyName);
            this.gbDetail.Controls.Add(this.ucOSCompanyName);
            this.gbDetail.Controls.Add(this.label18);
            this.gbDetail.Controls.Add(this.label14);
            this.gbDetail.Controls.Add(this.chkEnabled);
            this.gbDetail.Controls.Add(this.cboRoleName);
            this.gbDetail.Controls.Add(this.cboGender);
            this.gbDetail.Controls.Add(this.txtBirthday);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.label19);
            this.gbDetail.Controls.Add(this.txtHomeAddress);
            this.gbDetail.Controls.Add(this.label17);
            this.gbDetail.Controls.Add(this.txtEmail);
            this.gbDetail.Controls.Add(this.label16);
            this.gbDetail.Controls.Add(this.txtQQ);
            this.gbDetail.Controls.Add(this.label15);
            this.gbDetail.Controls.Add(this.txtTitle);
            this.gbDetail.Controls.Add(this.label13);
            this.gbDetail.Controls.Add(this.txtDuty);
            this.gbDetail.Controls.Add(this.label12);
            this.gbDetail.Controls.Add(this.label11);
            this.gbDetail.Controls.Add(this.txtTelphone);
            this.gbDetail.Controls.Add(this.label10);
            this.gbDetail.Controls.Add(this.txtMobile);
            this.gbDetail.Controls.Add(this.label9);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.txtCode);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.txtRealName);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.txtUserName);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Location = new System.Drawing.Point(3, 3);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(562, 509);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "用户信息";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 337);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 14);
            this.label18.TabIndex = 38;
            this.label18.Text = "所在子部门：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 14);
            this.label14.TabIndex = 36;
            this.label14.Text = "所在子公司：";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(106, 478);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(54, 18);
            this.chkEnabled.TabIndex = 21;
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
            this.cboRoleName.Location = new System.Drawing.Point(106, 220);
            this.cboRoleName.Name = "cboRoleName";
            this.cboRoleName.Size = new System.Drawing.Size(427, 24);
            this.cboRoleName.TabIndex = 13;
            this.cboRoleName.Tag = "默认角色";
            // 
            // cboGender
            // 
            this.cboGender.AccessibleName = "EmptyValue|NotNull";
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(106, 102);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(170, 24);
            this.cboGender.TabIndex = 5;
            this.cboGender.Tag = "性别";
            // 
            // txtBirthday
            // 
            this.txtBirthday.AccessibleName = "EmptyValue";
            this.txtBirthday.BackColor = System.Drawing.Color.White;
            this.txtBirthday.Location = new System.Drawing.Point(106, 132);
            this.txtBirthday.Multiline = false;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Padding = new System.Windows.Forms.Padding(1);
            this.txtBirthday.ReadOnly = false;
            this.txtBirthday.Size = new System.Drawing.Size(170, 27);
            this.txtBirthday.TabIndex = 7;
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
            this.txtDescription.Location = new System.Drawing.Point(106, 415);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(427, 55);
            this.txtDescription.TabIndex = 20;
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
            this.txtHomeAddress.Location = new System.Drawing.Point(106, 387);
            this.txtHomeAddress.MaxLength = 150;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.SelectedValue = null;
            this.txtHomeAddress.Size = new System.Drawing.Size(427, 23);
            this.txtHomeAddress.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 391);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 32;
            this.label17.Text = "家庭住址：";
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
            this.txtEmail.Location = new System.Drawing.Point(363, 190);
            this.txtEmail.MaxLength = 25;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.SelectedValue = null;
            this.txtEmail.Size = new System.Drawing.Size(170, 23);
            this.txtEmail.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(296, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 30;
            this.label16.Text = "电子邮件：";
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
            this.txtQQ.Location = new System.Drawing.Point(363, 161);
            this.txtQQ.MaxLength = 15;
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.SelectedValue = null;
            this.txtQQ.Size = new System.Drawing.Size(170, 23);
            this.txtQQ.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(310, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "QQ号码：";
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
            this.txtTitle.Location = new System.Drawing.Point(106, 194);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.SelectedValue = null;
            this.txtTitle.Size = new System.Drawing.Size(170, 23);
            this.txtTitle.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 24;
            this.label13.Text = "职称：";
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
            this.txtDuty.Location = new System.Drawing.Point(106, 165);
            this.txtDuty.MaxLength = 50;
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.SelectedValue = null;
            this.txtDuty.Size = new System.Drawing.Size(170, 23);
            this.txtDuty.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 22;
            this.label12.Text = "岗位：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "出生日期：";
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
            this.txtTelphone.Location = new System.Drawing.Point(363, 132);
            this.txtTelphone.MaxLength = 20;
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.SelectedValue = null;
            this.txtTelphone.Size = new System.Drawing.Size(170, 23);
            this.txtTelphone.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "固定电话：";
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
            this.txtMobile.Location = new System.Drawing.Point(363, 102);
            this.txtMobile.MaxLength = 25;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.SelectedValue = null;
            this.txtMobile.Size = new System.Drawing.Size(170, 23);
            this.txtMobile.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "手机：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "性别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "所在工作组：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "所在部门：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "所在公司/单位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "默认角色：";
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
            this.txtCode.Location = new System.Drawing.Point(106, 73);
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(426, 23);
            this.txtCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "编号：";
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
            this.txtRealName.Location = new System.Drawing.Point(106, 44);
            this.txtRealName.MaxLength = 15;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(426, 23);
            this.txtRealName.TabIndex = 3;
            this.txtRealName.Tag = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(64, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
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
            this.txtUserName.Location = new System.Drawing.Point(106, 15);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(426, 23);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Tag = "登录用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录用户名：";
            // 
            // ucOSWorkgroupName
            // 
            this.ucOSWorkgroupName.AllowNull = true;
            this.ucOSWorkgroupName.AllowSelect = true;
            this.ucOSWorkgroupName.CheckMove = false;
            this.ucOSWorkgroupName.Location = new System.Drawing.Point(106, 360);
            this.ucOSWorkgroupName.MultiSelect = false;
            this.ucOSWorkgroupName.Name = "ucOSWorkgroupName";
            this.ucOSWorkgroupName.OpenId = "";
            this.ucOSWorkgroupName.PermissionScopeCode = "";
            this.ucOSWorkgroupName.SelectedFullName = "";
            this.ucOSWorkgroupName.SelectedId = null;
            this.ucOSWorkgroupName.Size = new System.Drawing.Size(426, 23);
            this.ucOSWorkgroupName.TabIndex = 18;
            // 
            // ucOSSubDepartmentName
            // 
            this.ucOSSubDepartmentName.AllowNull = true;
            this.ucOSSubDepartmentName.AllowSelect = true;
            this.ucOSSubDepartmentName.CheckMove = false;
            this.ucOSSubDepartmentName.Location = new System.Drawing.Point(106, 332);
            this.ucOSSubDepartmentName.MultiSelect = false;
            this.ucOSSubDepartmentName.Name = "ucOSSubDepartmentName";
            this.ucOSSubDepartmentName.OpenId = "";
            this.ucOSSubDepartmentName.PermissionScopeCode = "";
            this.ucOSSubDepartmentName.SelectedFullName = "";
            this.ucOSSubDepartmentName.SelectedId = null;
            this.ucOSSubDepartmentName.Size = new System.Drawing.Size(426, 23);
            this.ucOSSubDepartmentName.TabIndex = 17;
            // 
            // ucOSDepartmentName
            // 
            this.ucOSDepartmentName.AllowNull = true;
            this.ucOSDepartmentName.AllowSelect = true;
            this.ucOSDepartmentName.CheckMove = false;
            this.ucOSDepartmentName.Location = new System.Drawing.Point(106, 302);
            this.ucOSDepartmentName.MultiSelect = false;
            this.ucOSDepartmentName.Name = "ucOSDepartmentName";
            this.ucOSDepartmentName.OpenId = "";
            this.ucOSDepartmentName.PermissionScopeCode = "";
            this.ucOSDepartmentName.SelectedFullName = "";
            this.ucOSDepartmentName.SelectedId = null;
            this.ucOSDepartmentName.Size = new System.Drawing.Size(426, 23);
            this.ucOSDepartmentName.TabIndex = 16;
            // 
            // ucOSSubCompanyName
            // 
            this.ucOSSubCompanyName.AllowNull = true;
            this.ucOSSubCompanyName.AllowSelect = true;
            this.ucOSSubCompanyName.CheckMove = false;
            this.ucOSSubCompanyName.Location = new System.Drawing.Point(106, 275);
            this.ucOSSubCompanyName.MultiSelect = false;
            this.ucOSSubCompanyName.Name = "ucOSSubCompanyName";
            this.ucOSSubCompanyName.OpenId = "";
            this.ucOSSubCompanyName.PermissionScopeCode = "";
            this.ucOSSubCompanyName.SelectedFullName = "";
            this.ucOSSubCompanyName.SelectedId = null;
            this.ucOSSubCompanyName.Size = new System.Drawing.Size(426, 23);
            this.ucOSSubCompanyName.TabIndex = 15;
            // 
            // ucOSCompanyName
            // 
            this.ucOSCompanyName.AllowNull = true;
            this.ucOSCompanyName.AllowSelect = true;
            this.ucOSCompanyName.CheckMove = false;
            this.ucOSCompanyName.Location = new System.Drawing.Point(106, 248);
            this.ucOSCompanyName.MultiSelect = false;
            this.ucOSCompanyName.Name = "ucOSCompanyName";
            this.ucOSCompanyName.OpenId = "";
            this.ucOSCompanyName.PermissionScopeCode = "";
            this.ucOSCompanyName.SelectedFullName = "";
            this.ucOSCompanyName.SelectedId = null;
            this.ucOSCompanyName.Size = new System.Drawing.Size(426, 23);
            this.ucOSCompanyName.TabIndex = 14;
            // 
            // FrmUserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 559);
            this.Controls.Add(this.gbDetail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserUpdate";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Text = "编辑用户";
            this.Controls.SetChildIndex(this.gbDetail, 0);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gbDetail;
        private Controls.UcMaskTextBox txtBirthday;
        private Controls.UcTextBox txtHomeAddress;
        private System.Windows.Forms.Label label17;
        private Controls.UcTextBox txtEmail;
        private System.Windows.Forms.Label label16;
        private Controls.UcTextBox txtQQ;
        private System.Windows.Forms.Label label15;
        private Controls.UcTextBox txtTitle;
        private System.Windows.Forms.Label label13;
        private Controls.UcTextBox txtDuty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Controls.UcTextBox txtTelphone;
        private System.Windows.Forms.Label label10;
        private Controls.UcTextBox txtMobile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtRealName;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private Controls.UcTextBox txtDescription;
        private Controls.UcComboBoxEx cboGender;
        private Controls.UcComboBoxEx cboRoleName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private UcOrganizeSelect ucOSWorkgroupName;
        private UcOrganizeSelect ucOSSubDepartmentName;
        private UcOrganizeSelect ucOSDepartmentName;
        private UcOrganizeSelect ucOSSubCompanyName;
        private UcOrganizeSelect ucOSCompanyName;
    }
}