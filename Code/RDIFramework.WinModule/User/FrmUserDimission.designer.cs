/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserDimission
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRealName = new System.Windows.Forms.Label();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.txtDuty = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new RDIFramework.Controls.UcTextBox(this.components);
            this.cboRoleName = new RDIFramework.Controls.UcComboBoxEx();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.ucOSCompanyName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.ucOSDepartmentName = new RDIFramework.WinModule.UcOrganizeSelect();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDimissionDate = new System.Windows.Forms.Label();
            this.dtDimissionDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirm = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.lblDimissionCause = new System.Windows.Forms.Label();
            this.txtDimissionCause = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDimissionWhither = new System.Windows.Forms.Label();
            this.txtDimissionWhither = new RDIFramework.Controls.UcTextBox(this.components);
            this.chkIsDimission = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucOSDepartmentName);
            this.panel1.Controls.Add(this.ucOSCompanyName);
            this.panel1.Controls.Add(this.lblDepartmentName);
            this.panel1.Controls.Add(this.lblCompanyName);
            this.panel1.Controls.Add(this.cboRoleName);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.txtDuty);
            this.panel1.Controls.Add(this.lblDuty);
            this.panel1.Controls.Add(this.lblRoleName);
            this.panel1.Controls.Add(this.txtRealName);
            this.panel1.Controls.Add(this.lblRealName);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 209);
            this.panel1.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserName.Location = new System.Drawing.Point(20, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(121, 14);
            this.lblUserName.TabIndex = 69;
            this.lblUserName.Text = "登录用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtUserName.Location = new System.Drawing.Point(141, 6);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(296, 23);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Tag = "登录用户名";
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRealName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRealName.Location = new System.Drawing.Point(9, 35);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(132, 14);
            this.lblRealName.TabIndex = 72;
            this.lblRealName.Text = "姓名：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtRealName.Location = new System.Drawing.Point(141, 34);
            this.txtRealName.MaxLength = 15;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(296, 23);
            this.txtRealName.TabIndex = 1;
            this.txtRealName.Tag = "姓名";
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoEllipsis = true;
            this.lblRoleName.Location = new System.Drawing.Point(12, 120);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(129, 14);
            this.lblRoleName.TabIndex = 73;
            this.lblRoleName.Text = "默认角色：";
            this.lblRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuty
            // 
            this.lblDuty.AutoEllipsis = true;
            this.lblDuty.Location = new System.Drawing.Point(12, 65);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(129, 14);
            this.lblDuty.TabIndex = 82;
            this.lblDuty.Text = "岗位：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtDuty.Location = new System.Drawing.Point(141, 62);
            this.txtDuty.MaxLength = 50;
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.SelectedValue = null;
            this.txtDuty.Size = new System.Drawing.Size(296, 23);
            this.txtDuty.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 92);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 14);
            this.lblTitle.TabIndex = 83;
            this.lblTitle.Text = "职称：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtTitle.Location = new System.Drawing.Point(141, 88);
            this.txtTitle.MaxLength = 25;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.SelectedValue = null;
            this.txtTitle.Size = new System.Drawing.Size(296, 23);
            this.txtTitle.TabIndex = 3;
            // 
            // cboRoleName
            // 
            this.cboRoleName.AccessibleName = "EmptyValue|NotNull";
            this.cboRoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleName.FormattingEnabled = true;
            this.cboRoleName.ItemHeight = 17;
            this.cboRoleName.Location = new System.Drawing.Point(141, 117);
            this.cboRoleName.Name = "cboRoleName";
            this.cboRoleName.Size = new System.Drawing.Size(299, 23);
            this.cboRoleName.TabIndex = 4;
            this.cboRoleName.Tag = "默认角色";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoEllipsis = true;
            this.lblCompanyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompanyName.Location = new System.Drawing.Point(5, 151);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(136, 14);
            this.lblCompanyName.TabIndex = 87;
            this.lblCompanyName.Text = "所在公司/单位：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoEllipsis = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDepartmentName.Location = new System.Drawing.Point(15, 183);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(126, 14);
            this.lblDepartmentName.TabIndex = 88;
            this.lblDepartmentName.Text = "所在部门：";
            this.lblDepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucOSCompanyName
            // 
            this.ucOSCompanyName.AllowNull = true;
            this.ucOSCompanyName.AllowSelect = true;
            this.ucOSCompanyName.CheckMove = false;
            this.ucOSCompanyName.Location = new System.Drawing.Point(140, 150);
            this.ucOSCompanyName.MultiSelect = false;
            this.ucOSCompanyName.Name = "ucOSCompanyName";
            this.ucOSCompanyName.OpenId = "";
            this.ucOSCompanyName.PermissionScopeCode = "";
            this.ucOSCompanyName.SelectedFullName = "";
            this.ucOSCompanyName.SelectedId = null;
            this.ucOSCompanyName.Size = new System.Drawing.Size(300, 23);
            this.ucOSCompanyName.TabIndex = 5;
            // 
            // ucOSDepartmentName
            // 
            this.ucOSDepartmentName.AllowNull = true;
            this.ucOSDepartmentName.AllowSelect = true;
            this.ucOSDepartmentName.CheckMove = false;
            this.ucOSDepartmentName.Location = new System.Drawing.Point(140, 179);
            this.ucOSDepartmentName.MultiSelect = false;
            this.ucOSDepartmentName.Name = "ucOSDepartmentName";
            this.ucOSDepartmentName.OpenId = "";
            this.ucOSDepartmentName.PermissionScopeCode = "";
            this.ucOSDepartmentName.SelectedFullName = "";
            this.ucOSDepartmentName.SelectedId = null;
            this.ucOSDepartmentName.Size = new System.Drawing.Size(300, 23);
            this.ucOSDepartmentName.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 233);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // lblDimissionDate
            // 
            this.lblDimissionDate.AutoEllipsis = true;
            this.lblDimissionDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDimissionDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDimissionDate.Location = new System.Drawing.Point(9, 257);
            this.lblDimissionDate.Name = "lblDimissionDate";
            this.lblDimissionDate.Size = new System.Drawing.Size(136, 14);
            this.lblDimissionDate.TabIndex = 88;
            this.lblDimissionDate.Text = "离职日期：";
            this.lblDimissionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtDimissionDate
            // 
            this.dtDimissionDate.Location = new System.Drawing.Point(146, 254);
            this.dtDimissionDate.Name = "dtDimissionDate";
            this.dtDimissionDate.Size = new System.Drawing.Size(133, 23);
            this.dtDimissionDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(7, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 1);
            this.label3.TabIndex = 93;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(271, 390);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 94;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(359, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDimissionCause
            // 
            this.lblDimissionCause.AutoEllipsis = true;
            this.lblDimissionCause.Location = new System.Drawing.Point(16, 287);
            this.lblDimissionCause.Name = "lblDimissionCause";
            this.lblDimissionCause.Size = new System.Drawing.Size(129, 14);
            this.lblDimissionCause.TabIndex = 97;
            this.lblDimissionCause.Text = "离职原因：";
            this.lblDimissionCause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDimissionCause
            // 
            this.txtDimissionCause.AccessibleName = "EmptyValue";
            this.txtDimissionCause.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDimissionCause.Border.Class = "TextBoxBorder";
            this.txtDimissionCause.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDimissionCause.FocusHighlightEnabled = true;
            this.txtDimissionCause.Location = new System.Drawing.Point(144, 282);
            this.txtDimissionCause.MaxLength = 200;
            this.txtDimissionCause.Multiline = true;
            this.txtDimissionCause.Name = "txtDimissionCause";
            this.txtDimissionCause.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDimissionCause.SelectedValue = null;
            this.txtDimissionCause.Size = new System.Drawing.Size(299, 35);
            this.txtDimissionCause.TabIndex = 1;
            // 
            // lblDimissionWhither
            // 
            this.lblDimissionWhither.AutoEllipsis = true;
            this.lblDimissionWhither.Location = new System.Drawing.Point(16, 330);
            this.lblDimissionWhither.Name = "lblDimissionWhither";
            this.lblDimissionWhither.Size = new System.Drawing.Size(129, 14);
            this.lblDimissionWhither.TabIndex = 99;
            this.lblDimissionWhither.Text = "离职去向：";
            this.lblDimissionWhither.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDimissionWhither
            // 
            this.txtDimissionWhither.AccessibleName = "EmptyValue";
            this.txtDimissionWhither.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDimissionWhither.Border.Class = "TextBoxBorder";
            this.txtDimissionWhither.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDimissionWhither.FocusHighlightEnabled = true;
            this.txtDimissionWhither.Location = new System.Drawing.Point(144, 325);
            this.txtDimissionWhither.MaxLength = 200;
            this.txtDimissionWhither.Multiline = true;
            this.txtDimissionWhither.Name = "txtDimissionWhither";
            this.txtDimissionWhither.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDimissionWhither.SelectedValue = null;
            this.txtDimissionWhither.Size = new System.Drawing.Size(299, 35);
            this.txtDimissionWhither.TabIndex = 2;
            // 
            // chkIsDimission
            // 
            this.chkIsDimission.AutoSize = true;
            this.chkIsDimission.Location = new System.Drawing.Point(296, 256);
            this.chkIsDimission.Name = "chkIsDimission";
            this.chkIsDimission.Size = new System.Drawing.Size(82, 18);
            this.chkIsDimission.TabIndex = 100;
            this.chkIsDimission.Text = "是否离职";
            this.chkIsDimission.UseVisualStyleBackColor = true;
            // 
            // FrmUserDimission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 425);
            this.Controls.Add(this.chkIsDimission);
            this.Controls.Add(this.txtDimissionWhither);
            this.Controls.Add(this.lblDimissionWhither);
            this.Controls.Add(this.txtDimissionCause);
            this.Controls.Add(this.lblDimissionCause);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtDimissionDate);
            this.Controls.Add(this.lblDimissionDate);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserDimission";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.Text = "用户离职管理";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UcOrganizeSelect ucOSDepartmentName;
        private UcOrganizeSelect ucOSCompanyName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblCompanyName;
        private Controls.UcComboBoxEx cboRoleName;
        private Controls.UcTextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private Controls.UcTextBox txtDuty;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblRoleName;
        private Controls.UcTextBox txtRealName;
        private System.Windows.Forms.Label lblRealName;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDimissionDate;
        private System.Windows.Forms.DateTimePicker dtDimissionDate;
        private System.Windows.Forms.Label label3;
        private Controls.UcButton btnConfirm;
        private Controls.UcButton btnCancel;
        private System.Windows.Forms.Label lblDimissionCause;
        private Controls.UcTextBox txtDimissionCause;
        private System.Windows.Forms.Label lblDimissionWhither;
        private Controls.UcTextBox txtDimissionWhither;
        private System.Windows.Forms.CheckBox chkIsDimission;



    }
}