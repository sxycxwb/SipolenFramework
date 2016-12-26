namespace RDIFramework.WinModule
{
    partial class FrmAddUserToOrganize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUserToOrganize));
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRealName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.gbOrganizeInfo = new System.Windows.Forms.GroupBox();
            this.txtWorkGroup = new RDIFramework.WinModule.UcOrganizeSelect();
            this.txtSubDepartment = new RDIFramework.WinModule.UcOrganizeSelect();
            this.txtDepartment = new RDIFramework.WinModule.UcOrganizeSelect();
            this.txtSubCompany = new RDIFramework.WinModule.UcOrganizeSelect();
            this.txtCompany = new RDIFramework.WinModule.UcOrganizeSelect();
            this.lblWorkGroup = new System.Windows.Forms.Label();
            this.lblSubDepartment = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSubCompany = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.gbOtherInfo = new System.Windows.Forms.GroupBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.btnSubmit = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.gbUserInfo.SuspendLayout();
            this.gbOrganizeInfo.SuspendLayout();
            this.gbOtherInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.txtRealName);
            this.gbUserInfo.Controls.Add(this.txtUserName);
            this.gbUserInfo.Controls.Add(this.lblRealName);
            this.gbUserInfo.Controls.Add(this.lblUserName);
            this.gbUserInfo.Location = new System.Drawing.Point(12, 12);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(412, 89);
            this.gbUserInfo.TabIndex = 0;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "用户信息";
            // 
            // txtRealName
            // 
            // 
            // 
            // 
            this.txtRealName.Border.Class = "TextBoxBorder";
            this.txtRealName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealName.FocusHighlightEnabled = true;
            this.txtRealName.Location = new System.Drawing.Point(123, 53);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = ((object)(resources.GetObject("txtRealName.SelectedValue")));
            this.txtRealName.Size = new System.Drawing.Size(283, 23);
            this.txtRealName.TabIndex = 2;
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(123, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = ((object)(resources.GetObject("txtUserName.SelectedValue")));
            this.txtUserName.Size = new System.Drawing.Size(283, 23);
            this.txtUserName.TabIndex = 1;
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Location = new System.Drawing.Point(9, 54);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(117, 14);
            this.lblRealName.TabIndex = 1;
            this.lblRealName.Text = "姓  名：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Location = new System.Drawing.Point(9, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(117, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbOrganizeInfo
            // 
            this.gbOrganizeInfo.Controls.Add(this.txtWorkGroup);
            this.gbOrganizeInfo.Controls.Add(this.txtSubDepartment);
            this.gbOrganizeInfo.Controls.Add(this.txtDepartment);
            this.gbOrganizeInfo.Controls.Add(this.txtSubCompany);
            this.gbOrganizeInfo.Controls.Add(this.txtCompany);
            this.gbOrganizeInfo.Controls.Add(this.lblWorkGroup);
            this.gbOrganizeInfo.Controls.Add(this.lblSubDepartment);
            this.gbOrganizeInfo.Controls.Add(this.lblDepartment);
            this.gbOrganizeInfo.Controls.Add(this.lblSubCompany);
            this.gbOrganizeInfo.Controls.Add(this.lblCompany);
            this.gbOrganizeInfo.Location = new System.Drawing.Point(12, 107);
            this.gbOrganizeInfo.Name = "gbOrganizeInfo";
            this.gbOrganizeInfo.Size = new System.Drawing.Size(412, 178);
            this.gbOrganizeInfo.TabIndex = 1;
            this.gbOrganizeInfo.TabStop = false;
            this.gbOrganizeInfo.Text = "组织机构信息";
            // 
            // txtWorkGroup
            // 
            this.txtWorkGroup.AllowNull = true;
            this.txtWorkGroup.AllowSelect = true;
            this.txtWorkGroup.CheckMove = false;
            this.txtWorkGroup.Location = new System.Drawing.Point(123, 142);
            this.txtWorkGroup.MultiSelect = false;
            this.txtWorkGroup.Name = "txtWorkGroup";
            this.txtWorkGroup.OpenId = "";
            this.txtWorkGroup.PermissionScopeCode = "";
            this.txtWorkGroup.SelectedFullName = "";
            this.txtWorkGroup.SelectedId = null;
            this.txtWorkGroup.Size = new System.Drawing.Size(283, 24);
            this.txtWorkGroup.TabIndex = 4;
            // 
            // txtSubDepartment
            // 
            this.txtSubDepartment.AllowNull = true;
            this.txtSubDepartment.AllowSelect = true;
            this.txtSubDepartment.CheckMove = false;
            this.txtSubDepartment.Location = new System.Drawing.Point(123, 111);
            this.txtSubDepartment.MultiSelect = false;
            this.txtSubDepartment.Name = "txtSubDepartment";
            this.txtSubDepartment.OpenId = "";
            this.txtSubDepartment.PermissionScopeCode = "";
            this.txtSubDepartment.SelectedFullName = "";
            this.txtSubDepartment.SelectedId = null;
            this.txtSubDepartment.Size = new System.Drawing.Size(283, 24);
            this.txtSubDepartment.TabIndex = 3;
            // 
            // txtDepartment
            // 
            this.txtDepartment.AllowNull = true;
            this.txtDepartment.AllowSelect = true;
            this.txtDepartment.CheckMove = false;
            this.txtDepartment.Location = new System.Drawing.Point(123, 79);
            this.txtDepartment.MultiSelect = false;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.OpenId = "";
            this.txtDepartment.PermissionScopeCode = "";
            this.txtDepartment.SelectedFullName = "";
            this.txtDepartment.SelectedId = null;
            this.txtDepartment.Size = new System.Drawing.Size(283, 24);
            this.txtDepartment.TabIndex = 2;
            // 
            // txtSubCompany
            // 
            this.txtSubCompany.AllowNull = true;
            this.txtSubCompany.AllowSelect = true;
            this.txtSubCompany.CheckMove = false;
            this.txtSubCompany.Location = new System.Drawing.Point(123, 49);
            this.txtSubCompany.MultiSelect = false;
            this.txtSubCompany.Name = "txtSubCompany";
            this.txtSubCompany.OpenId = "";
            this.txtSubCompany.PermissionScopeCode = "";
            this.txtSubCompany.SelectedFullName = "";
            this.txtSubCompany.SelectedId = null;
            this.txtSubCompany.Size = new System.Drawing.Size(283, 24);
            this.txtSubCompany.TabIndex = 1;
            // 
            // txtCompany
            // 
            this.txtCompany.AllowNull = true;
            this.txtCompany.AllowSelect = true;
            this.txtCompany.CheckMove = false;
            this.txtCompany.Location = new System.Drawing.Point(123, 20);
            this.txtCompany.MultiSelect = false;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.OpenId = "";
            this.txtCompany.PermissionScopeCode = "";
            this.txtCompany.SelectedFullName = "";
            this.txtCompany.SelectedId = null;
            this.txtCompany.Size = new System.Drawing.Size(283, 24);
            this.txtCompany.TabIndex = 0;
            // 
            // lblWorkGroup
            // 
            this.lblWorkGroup.AutoEllipsis = true;
            this.lblWorkGroup.Location = new System.Drawing.Point(6, 147);
            this.lblWorkGroup.Name = "lblWorkGroup";
            this.lblWorkGroup.Size = new System.Drawing.Size(120, 14);
            this.lblWorkGroup.TabIndex = 6;
            this.lblWorkGroup.Text = "所在工作组：";
            this.lblWorkGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubDepartment
            // 
            this.lblSubDepartment.AutoEllipsis = true;
            this.lblSubDepartment.Location = new System.Drawing.Point(6, 115);
            this.lblSubDepartment.Name = "lblSubDepartment";
            this.lblSubDepartment.Size = new System.Drawing.Size(120, 14);
            this.lblSubDepartment.TabIndex = 5;
            this.lblSubDepartment.Text = "所在子部门：";
            this.lblSubDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoEllipsis = true;
            this.lblDepartment.Location = new System.Drawing.Point(6, 83);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(120, 14);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "所在部门：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubCompany
            // 
            this.lblSubCompany.AutoEllipsis = true;
            this.lblSubCompany.Location = new System.Drawing.Point(6, 52);
            this.lblSubCompany.Name = "lblSubCompany";
            this.lblSubCompany.Size = new System.Drawing.Size(120, 14);
            this.lblSubCompany.TabIndex = 3;
            this.lblSubCompany.Text = "分支机构：";
            this.lblSubCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoEllipsis = true;
            this.lblCompany.Location = new System.Drawing.Point(6, 24);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(120, 14);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "所在单位：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbOtherInfo
            // 
            this.gbOtherInfo.Controls.Add(this.txtDescription);
            this.gbOtherInfo.Controls.Add(this.chkEnabled);
            this.gbOtherInfo.Controls.Add(this.lblDescription);
            this.gbOtherInfo.Controls.Add(this.lblEnabled);
            this.gbOtherInfo.Location = new System.Drawing.Point(12, 298);
            this.gbOtherInfo.Name = "gbOtherInfo";
            this.gbOtherInfo.Size = new System.Drawing.Size(412, 140);
            this.gbOtherInfo.TabIndex = 2;
            this.gbOtherInfo.TabStop = false;
            this.gbOtherInfo.Text = "辅助信息";
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(123, 51);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(283, 74);
            this.txtDescription.TabIndex = 1;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Location = new System.Drawing.Point(123, 26);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(76, 18);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 14);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "描  述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoEllipsis = true;
            this.lblEnabled.Location = new System.Drawing.Point(6, 27);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(120, 14);
            this.lblEnabled.TabIndex = 1;
            this.lblEnabled.Text = "属  性：";
            this.lblEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSubmit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSubmit.Location = new System.Drawing.Point(267, 461);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(349, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddUserToOrganize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 496);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbOtherInfo);
            this.Controls.Add(this.gbOrganizeInfo);
            this.Controls.Add(this.gbUserInfo);
            this.Name = "FrmAddUserToOrganize";
            this.Text = "添加用户到组织机构";
            this.gbUserInfo.ResumeLayout(false);
            this.gbOrganizeInfo.ResumeLayout(false);
            this.gbOtherInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.GroupBox gbOrganizeInfo;
        private System.Windows.Forms.GroupBox gbOtherInfo;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Label lblUserName;
        private Controls.UcTextBox txtRealName;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label lblWorkGroup;
        private System.Windows.Forms.Label lblSubDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblSubCompany;
        private System.Windows.Forms.Label lblCompany;
        private UcOrganizeSelect txtWorkGroup;
        private UcOrganizeSelect txtSubDepartment;
        private UcOrganizeSelect txtDepartment;
        private UcOrganizeSelect txtSubCompany;
        private UcOrganizeSelect txtCompany;
        private System.Windows.Forms.Label lblEnabled;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private Controls.UcTextBox txtDescription;
        private Controls.UcButton btnSubmit;
        private Controls.UcButton btnCancel;
    }
}