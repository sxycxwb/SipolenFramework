namespace RDIFramework.WinModule
{
    partial class FrmLogByGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogByGeneral));
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuery = new RDIFramework.Controls.UcButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucUserSelect = new RDIFramework.WinModule.UcUserSelect();
            this.lblUserName = new System.Windows.Forms.Label();
            this.ucOrganizeSelect = new RDIFramework.WinModule.UcOrganizeSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCheckIPAddress = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMultiUserLogin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserOnLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFirstVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreviousVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogOnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMACAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPagerEx = new RDIFramework.Controls.UcPagerEx();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnVisitDetail = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel3);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 454);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 21;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 427);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItemSearch;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.panel4);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 417);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 43);
            this.panel3.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.CommandParameter = "Query";
            this.btnQuery.Location = new System.Drawing.Point(90, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucUserSelect);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Controls.Add(this.ucOrganizeSelect);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 116);
            this.panel4.TabIndex = 9;
            // 
            // ucUserSelect
            // 
            this.ucUserSelect.AllowNull = true;
            this.ucUserSelect.AllowSelect = true;
            this.ucUserSelect.Location = new System.Drawing.Point(9, 82);
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
            this.ucUserSelect.Size = new System.Drawing.Size(157, 28);
            this.ucUserSelect.TabIndex = 23;
            this.ucUserSelect.UserIds = null;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 59);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 14);
            this.lblUserName.TabIndex = 22;
            this.lblUserName.Text = "用户名称：";
            // 
            // ucOrganizeSelect
            // 
            this.ucOrganizeSelect.AllowNull = true;
            this.ucOrganizeSelect.AllowSelect = true;
            this.ucOrganizeSelect.CheckMove = false;
            this.ucOrganizeSelect.Location = new System.Drawing.Point(10, 25);
            this.ucOrganizeSelect.MultiSelect = false;
            this.ucOrganizeSelect.Name = "ucOrganizeSelect";
            this.ucOrganizeSelect.OpenId = "";
            this.ucOrganizeSelect.PermissionScopeCode = "";
            this.ucOrganizeSelect.SelectedFullName = "";
            this.ucOrganizeSelect.SelectedId = null;
            this.ucOrganizeSelect.Size = new System.Drawing.Size(156, 28);
            this.ucOrganizeSelect.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "组织机构：";
            // 
            // tabItemSearch
            // 
            this.tabItemSearch.AttachedControl = this.tabControlPanel3;
            this.tabItemSearch.Name = "tabItemSearch";
            this.tabItemSearch.Text = "搜索";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 454);
            this.splitter1.TabIndex = 22;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvInfo);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(201, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(780, 429);
            this.panel5.TabIndex = 23;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInfo.CheckboxFieldName = "colSelected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.ColumnHeadersHeight = 26;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colUserName,
            this.colRealName,
            this.colDepartmentName,
            this.colIsVisible,
            this.colEnabled,
            this.colCheckIPAddress,
            this.colMultiUserLogin,
            this.colUserOnLine,
            this.colFirstVisit,
            this.colPreviousVisit,
            this.colLastVisit,
            this.colLogOnCount,
            this.colIPAddress,
            this.colMACAddress,
            this.colDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.RowHeadersWidth = 40;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(780, 397);
            this.dgvInfo.TabIndex = 10;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 43;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.HeaderText = "用户名";
            this.colUserName.Name = "colUserName";
            this.colUserName.Width = 120;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "姓名";
            this.colRealName.Name = "colRealName";
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Width = 120;
            // 
            // colIsVisible
            // 
            this.colIsVisible.DataPropertyName = "IsVisible";
            this.colIsVisible.HeaderText = "可见";
            this.colIsVisible.Name = "colIsVisible";
            this.colIsVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsVisible.Width = 60;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "可用";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 60;
            // 
            // colCheckIPAddress
            // 
            this.colCheckIPAddress.DataPropertyName = "CheckIPAddress";
            this.colCheckIPAddress.HeaderText = "限制IP";
            this.colCheckIPAddress.Name = "colCheckIPAddress";
            this.colCheckIPAddress.Width = 70;
            // 
            // colMultiUserLogin
            // 
            this.colMultiUserLogin.DataPropertyName = "MultiUserLogin";
            this.colMultiUserLogin.HeaderText = "多点登录";
            this.colMultiUserLogin.Name = "colMultiUserLogin";
            this.colMultiUserLogin.Width = 80;
            // 
            // colUserOnLine
            // 
            this.colUserOnLine.DataPropertyName = "UserOnLine";
            this.colUserOnLine.HeaderText = "在线";
            this.colUserOnLine.Name = "colUserOnLine";
            this.colUserOnLine.Width = 60;
            // 
            // colFirstVisit
            // 
            this.colFirstVisit.DataPropertyName = "FirstVisit";
            this.colFirstVisit.HeaderText = "首次访问";
            this.colFirstVisit.Name = "colFirstVisit";
            this.colFirstVisit.Width = 120;
            // 
            // colPreviousVisit
            // 
            this.colPreviousVisit.DataPropertyName = "PreviousVisit";
            this.colPreviousVisit.HeaderText = "上次访问";
            this.colPreviousVisit.Name = "colPreviousVisit";
            this.colPreviousVisit.Width = 120;
            // 
            // colLastVisit
            // 
            this.colLastVisit.DataPropertyName = "LastVisit";
            this.colLastVisit.HeaderText = "最后访问";
            this.colLastVisit.Name = "colLastVisit";
            this.colLastVisit.Width = 120;
            // 
            // colLogOnCount
            // 
            this.colLogOnCount.DataPropertyName = "LogOnCount";
            this.colLogOnCount.HeaderText = "登录次数";
            this.colLogOnCount.Name = "colLogOnCount";
            this.colLogOnCount.Width = 70;
            // 
            // colIPAddress
            // 
            this.colIPAddress.DataPropertyName = "IPAddress";
            this.colIPAddress.HeaderText = "IP地址";
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.Width = 120;
            // 
            // colMACAddress
            // 
            this.colMACAddress.DataPropertyName = "MACAddress";
            this.colMACAddress.HeaderText = "MAC地址";
            this.colMACAddress.Name = "colMACAddress";
            this.colMACAddress.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 230;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucPagerEx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 32);
            this.panel1.TabIndex = 9;
            // 
            // ucPagerEx
            // 
            this.ucPagerEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPagerEx.Location = new System.Drawing.Point(266, 3);
            this.ucPagerEx.Name = "ucPagerEx";
            this.ucPagerEx.PageIndex = 1;
            this.ucPagerEx.PageSize = 50;
            this.ucPagerEx.RecordCount = 0;
            this.ucPagerEx.Size = new System.Drawing.Size(514, 27);
            this.ucPagerEx.TabIndex = 9;
            this.ucPagerEx.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPagerEx_PageChanged);
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.AutoSize = false;
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVisitDetail,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(201, 0);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(780, 25);
            this.tlsUserAdd.TabIndex = 24;
            this.tlsUserAdd.Text = "toolStrip1";
            // 
            // btnVisitDetail
            // 
            this.btnVisitDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnVisitDetail.Image")));
            this.btnVisitDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVisitDetail.Name = "btnVisitDetail";
            this.btnVisitDetail.Size = new System.Drawing.Size(135, 22);
            this.btnVisitDetail.Text = "访问详情(&V)...";
            this.btnVisitDetail.Click += new System.EventHandler(this.btnVisitDetail_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 22);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // FrmLogByGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(981, 454);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tlsUserAdd);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.DoubleBuffered = true;
            this.Name = "FrmLogByGeneral";
            this.Text = "用户访问情况";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel3;
        private Controls.UcButton btnQuery;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private UcUserSelect ucUserSelect;
        private System.Windows.Forms.Label lblUserName;
        private UcOrganizeSelect ucOrganizeSelect;
        private System.Windows.Forms.Label label1;
        private Controls.UcPagerEx ucPagerEx;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckIPAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMultiUserLogin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreviousVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogOnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMACAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripButton btnVisitDetail;

    }
}