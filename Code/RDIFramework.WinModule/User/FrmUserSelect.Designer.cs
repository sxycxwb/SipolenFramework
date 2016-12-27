/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:57
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.line1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboRole = new RDIFramework.Controls.UcComboBoxEx();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.txtSearch = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSearch = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvUser = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSelectAll = new RDIFramework.Controls.UcButton();
            this.btnInvertSelect = new RDIFramework.Controls.UcButton();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSetNull = new RDIFramework.Controls.UcButton();
            this.btnSelect = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.DimGray;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(3, 3);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(883, 2);
            this.line1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboRole);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 31);
            this.panel1.TabIndex = 7;
            // 
            // cboRole
            // 
            this.cboRole.DisplayMember = "Text";
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.ItemHeight = 17;
            this.cboRole.Location = new System.Drawing.Point(398, 5);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(242, 23);
            this.cboRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRole.TabIndex = 4;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(352, 9);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(49, 14);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "角色：";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(262, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&F)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.FocusHighlightEnabled = true;
            this.txtSearch.Location = new System.Drawing.Point(81, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.SelectedValue = ((object)(resources.GetObject("txtSearch.SelectedValue")));
            this.txtSearch.Size = new System.Drawing.Size(175, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoEllipsis = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(69, 14);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "查询：";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvUser);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 507);
            this.panel2.TabIndex = 8;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeight = 26;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colUserName,
            this.colRealName,
            this.colGender,
            this.colDepartmentName,
            this.colDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.RowHeadersWidth = 20;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(883, 467);
            this.dgvUser.TabIndex = 8;
            this.dgvUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellDoubleClick);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 48;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            this.colCode.Width = 150;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "登录名";
            this.colUserName.Name = "colUserName";
            this.colUserName.Width = 150;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "用户名";
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 120;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "性别";
            this.colGender.Name = "colGender";
            this.colGender.Width = 70;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DEPARTMENTNAME";
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "DESCRIPTION";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 200;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.btnSelectAll);
            this.panel4.Controls.Add(this.btnInvertSelect);
            this.panel4.Controls.Add(this.ucPager);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 467);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(883, 40);
            this.panel4.TabIndex = 9;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectAll.Location = new System.Drawing.Point(10, 7);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelectAll.Size = new System.Drawing.Size(71, 26);
            this.btnSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectAll.TabIndex = 13;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnInvertSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInvertSelect.Location = new System.Drawing.Point(87, 7);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Padding = new System.Windows.Forms.Padding(1);
            this.btnInvertSelect.Size = new System.Drawing.Size(95, 26);
            this.btnInvertSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInvertSelect.TabIndex = 12;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(356, 7);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(523, 27);
            this.ucPager.TabIndex = 11;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSetNull);
            this.panel3.Controls.Add(this.btnSelect);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 543);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 40);
            this.panel3.TabIndex = 9;
            // 
            // btnSetNull
            // 
            this.btnSetNull.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetNull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetNull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSetNull.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetNull.Location = new System.Drawing.Point(632, 8);
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Padding = new System.Windows.Forms.Padding(1);
            this.btnSetNull.Size = new System.Drawing.Size(70, 26);
            this.btnSetNull.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetNull.TabIndex = 7;
            this.btnSetNull.Text = "置空(&N)";
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(717, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelect.Size = new System.Drawing.Size(70, 26);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(798, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btnCancel.Size = new System.Drawing.Size(63, 26);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmUserSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 586);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.line1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserSelect";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "用户选择";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label line1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Controls.UcButton btnSelect;
        private Controls.UcButton btnCancel;
        private Controls.UcDataGridView dgvUser;
        private System.Windows.Forms.Panel panel4;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.Label lblSearch;
        private Controls.UcTextBox txtSearch;
        private Controls.UcButton btnSearch;
        private System.Windows.Forms.Label lblRole;
        private Controls.UcComboBoxEx cboRole;
        private Controls.UcButton btnSetNull;
        private Controls.UcButton btnSelectAll;
        private Controls.UcButton btnInvertSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

    }
}