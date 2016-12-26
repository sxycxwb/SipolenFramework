namespace RDIFramework.WinModule
{
    partial class FrmUserOrganize
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserOrganize));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcTargetResource = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvTargetResource = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabItemUserOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnRemove = new RDIFramework.Controls.UcButton();
            this.btnAddToOrganize = new RDIFramework.Controls.UcButton();
            this.btnInvertSelect = new RDIFramework.Controls.UcButton();
            this.btnSelectAll = new RDIFramework.Controls.UcButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcTargetResource)).BeginInit();
            this.tcTargetResource.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetResource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcTargetResource);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 417);
            this.panel1.TabIndex = 0;
            // 
            // tcTargetResource
            // 
            this.tcTargetResource.BackColor = System.Drawing.SystemColors.Window;
            this.tcTargetResource.CanReorderTabs = true;
            this.tcTargetResource.Controls.Add(this.tabControlPanel1);
            this.tcTargetResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTargetResource.Location = new System.Drawing.Point(0, 42);
            this.tcTargetResource.Name = "tcTargetResource";
            this.tcTargetResource.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcTargetResource.SelectedTabIndex = 0;
            this.tcTargetResource.Size = new System.Drawing.Size(774, 375);
            this.tcTargetResource.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcTargetResource.TabIndex = 26;
            this.tcTargetResource.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcTargetResource.Tabs.Add(this.tabItemUserOrganize);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvTargetResource);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(774, 348);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemUserOrganize;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // dgvTargetResource
            // 
            this.dgvTargetResource.AllowUserToAddRows = false;
            this.dgvTargetResource.AllowUserToDeleteRows = false;
            this.dgvTargetResource.AllowUserToOrderColumns = true;
            this.dgvTargetResource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTargetResource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTargetResource.ColumnHeadersHeight = 26;
            this.dgvTargetResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTargetResource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCompanyName,
            this.colSubCompanyName,
            this.colDepartmentName,
            this.colSubDepartment,
            this.colWorkGroupName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTargetResource.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTargetResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTargetResource.EnableHeadersVisualStyles = false;
            this.dgvTargetResource.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTargetResource.Location = new System.Drawing.Point(1, 1);
            this.dgvTargetResource.Name = "dgvTargetResource";
            this.dgvTargetResource.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTargetResource.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTargetResource.RowHeadersWidth = 40;
            this.dgvTargetResource.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTargetResource.RowTemplate.Height = 23;
            this.dgvTargetResource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTargetResource.Size = new System.Drawing.Size(772, 346);
            this.dgvTargetResource.TabIndex = 4;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCompanyName
            // 
            this.colCompanyName.DataPropertyName = "CompanyName";
            this.colCompanyName.HeaderText = "公司";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Width = 150;
            // 
            // colSubCompanyName
            // 
            this.colSubCompanyName.DataPropertyName = "SubCompanyName";
            this.colSubCompanyName.HeaderText = "分公司";
            this.colSubCompanyName.Name = "colSubCompanyName";
            this.colSubCompanyName.Width = 150;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Width = 150;
            // 
            // colSubDepartment
            // 
            this.colSubDepartment.DataPropertyName = "SubDepartmentName";
            this.colSubDepartment.HeaderText = "子部门";
            this.colSubDepartment.Name = "colSubDepartment";
            this.colSubDepartment.Width = 150;
            // 
            // colWorkGroupName
            // 
            this.colWorkGroupName.DataPropertyName = "WorkGroupName";
            this.colWorkGroupName.HeaderText = "工作组";
            this.colWorkGroupName.Name = "colWorkGroupName";
            this.colWorkGroupName.Width = 150;
            // 
            // tabItemUserOrganize
            // 
            this.tabItemUserOrganize.AttachedControl = this.tabControlPanel1;
            this.tabItemUserOrganize.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItemUserOrganize.Icon")));
            this.tabItemUserOrganize.Name = "tabItemUserOrganize";
            this.tabItemUserOrganize.Text = "用户兼职组织机构";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.lblResourceName);
            this.panel3.Controls.Add(this.lblResource);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 42);
            this.panel3.TabIndex = 0;
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Font = new System.Drawing.Font("宋体", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResourceName.ForeColor = System.Drawing.Color.Green;
            this.lblResourceName.Location = new System.Drawing.Point(85, 14);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(37, 14);
            this.lblResourceName.TabIndex = 7;
            this.lblResourceName.Text = "用户";
            this.lblResourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(16, 14);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(77, 14);
            this.lblResource.TabIndex = 6;
            this.lblResource.Text = "当前用户：";
            this.lblResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnAddToOrganize);
            this.panel2.Controls.Add(this.btnInvertSelect);
            this.panel2.Controls.Add(this.btnSelectAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 421);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(701, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(601, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(91, 23);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "移除(&R)";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddToOrganize
            // 
            this.btnAddToOrganize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddToOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToOrganize.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddToOrganize.Location = new System.Drawing.Point(431, 12);
            this.btnAddToOrganize.Name = "btnAddToOrganize";
            this.btnAddToOrganize.Size = new System.Drawing.Size(164, 23);
            this.btnAddToOrganize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddToOrganize.TabIndex = 2;
            this.btnAddToOrganize.Text = "添加兼职组织(&D)...";
            this.btnAddToOrganize.Click += new System.EventHandler(this.btnAddToOrganize_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInvertSelect.Location = new System.Drawing.Point(91, 12);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(99, 23);
            this.btnInvertSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInvertSelect.TabIndex = 1;
            this.btnInvertSelect.Text = "反选";
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 12);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(82, 23);
            this.btnSelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // FrmUserOrganize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmUserOrganize";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "用户兼职组织机构";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcTargetResource)).EndInit();
            this.tcTargetResource.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetResource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label lblResource;
        private DevComponents.DotNetBar.TabControl tcTargetResource;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private Controls.UcDataGridView dgvTargetResource;
        private DevComponents.DotNetBar.TabItem tabItemUserOrganize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkGroupName;
        private Controls.UcButton btnSelectAll;
        private Controls.UcButton btnInvertSelect;
        private Controls.UcButton btnRemove;
        private Controls.UcButton btnAddToOrganize;
        private Controls.UcButton btnClose;
    }
}