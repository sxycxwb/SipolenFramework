namespace RDIFramework.WinModule
{
    sealed partial class FrmPostRoleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPostRoleAdd));
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblOrganize = new System.Windows.Forms.Label();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.ucOrganize = new RDIFramework.WinModule.UcOrganizeSelect();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.ucUserSelect = new RDIFramework.WinModule.UcUserSelect();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRealName = new System.Windows.Forms.Label();
            this.tlsTool.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsers
            // 
            this.lblUsers.AutoEllipsis = true;
            this.lblUsers.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsers.Location = new System.Drawing.Point(9, 117);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(86, 14);
            this.lblUsers.TabIndex = 49;
            this.lblUsers.Text = "成  员：";
            this.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrganize
            // 
            this.lblOrganize.AutoEllipsis = true;
            this.lblOrganize.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrganize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrganize.Location = new System.Drawing.Point(7, 26);
            this.lblOrganize.Name = "lblOrganize";
            this.lblOrganize.Size = new System.Drawing.Size(86, 14);
            this.lblOrganize.TabIndex = 47;
            this.lblOrganize.Text = "机  构：";
            this.lblOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(5, 1);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(506, 25);
            this.tlsTool.TabIndex = 0;
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
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Location = new System.Drawing.Point(95, 139);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(94, 18);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = false;
            this.ucOrganize.AllowSelect = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(93, 21);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = null;
            this.ucOrganize.Size = new System.Drawing.Size(393, 24);
            this.ucOrganize.TabIndex = 0;
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
            this.txtDescription.Location = new System.Drawing.Point(93, 160);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(396, 86);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 165);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "描  述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.ucUserSelect);
            this.gbDetail.Controls.Add(this.lblUsers);
            this.gbDetail.Controls.Add(this.lblOrganize);
            this.gbDetail.Controls.Add(this.chkEnabled);
            this.gbDetail.Controls.Add(this.ucOrganize);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.lblDescription);
            this.gbDetail.Controls.Add(this.txtCode);
            this.gbDetail.Controls.Add(this.lblCode);
            this.gbDetail.Controls.Add(this.txtRealName);
            this.gbDetail.Controls.Add(this.lblRealName);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(5, 26);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(506, 255);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "岗位信息";
            // 
            // ucUserSelect
            // 
            this.ucUserSelect.AllowNull = true;
            this.ucUserSelect.AllowSelect = true;
            this.ucUserSelect.Location = new System.Drawing.Point(93, 111);
            this.ucUserSelect.MultiSelect = true;
            this.ucUserSelect.Name = "ucUserSelect";
            this.ucUserSelect.OrganizeId = "";
            this.ucUserSelect.PermissionScopeCode = "";
            this.ucUserSelect.RemoveIds = null;
            this.ucUserSelect.RoleId = "";
            this.ucUserSelect.SelectedFullName = "";
            this.ucUserSelect.SelectedId = null;
            this.ucUserSelect.SelectedIds = null;
            this.ucUserSelect.SetSelectedIds = null;
            this.ucUserSelect.Size = new System.Drawing.Size(392, 24);
            this.ucUserSelect.TabIndex = 3;
            this.ucUserSelect.UserIds = null;
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
            this.txtCode.Location = new System.Drawing.Point(93, 50);
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(393, 23);
            this.txtCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCode.Location = new System.Drawing.Point(6, 55);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(89, 14);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "编  号：";
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
            this.txtRealName.Location = new System.Drawing.Point(93, 81);
            this.txtRealName.MaxLength = 15;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(393, 23);
            this.txtRealName.TabIndex = 2;
            this.txtRealName.Tag = "姓名";
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRealName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRealName.Location = new System.Drawing.Point(6, 86);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(89, 14);
            this.lblRealName.TabIndex = 2;
            this.lblRealName.Text = "名  称：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmPostRoleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 286);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmPostRoleAdd";
            this.Padding = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.Text = "添加岗位";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblOrganize;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.CheckBox chkEnabled;
        private UcOrganizeSelect ucOrganize;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtRealName;
        private System.Windows.Forms.Label lblRealName;
        private Controls.UcTextBox txtCode;
        private UcUserSelect ucUserSelect;
    }
}