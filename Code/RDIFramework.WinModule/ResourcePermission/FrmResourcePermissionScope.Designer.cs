namespace RDIFramework.WinModule
{
    partial class FrmResourcePermissionScope
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResourcePermissionScope));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvRole = new RDIFramework.Controls.UcDataGridView();
            this.colRoleSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuInvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tcItemRole = new DevComponents.DotNetBar.TabItem(this.components);
            this.tcResource = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvUser = new RDIFramework.Controls.UcDataGridView();
            this.colUserSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcItemUser = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.lblTargetResourceName = new System.Windows.Forms.Label();
            this.lblPermissionItem = new System.Windows.Forms.Label();
            this.lblTargetResource = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
            this.dgvCMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcResource)).BeginInit();
            this.tcResource.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvRole);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(619, 432);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tcItemRole;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // dgvRole
            // 
            this.dgvRole.AllowUserToAddRows = false;
            this.dgvRole.AllowUserToDeleteRows = false;
            this.dgvRole.AllowUserToOrderColumns = true;
            this.dgvRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRole.ColumnHeadersHeight = 26;
            this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoleSelected,
            this.colRoleRealName,
            this.colRoleDescription});
            this.dgvRole.ContextMenuStrip = this.dgvCMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRole.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRole.EnableHeadersVisualStyles = false;
            this.dgvRole.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvRole.Location = new System.Drawing.Point(1, 1);
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRole.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRole.RowHeadersWidth = 40;
            this.dgvRole.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRole.RowTemplate.Height = 23;
            this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRole.Size = new System.Drawing.Size(617, 430);
            this.dgvRole.TabIndex = 4;
            // 
            // colRoleSelected
            // 
            this.colRoleSelected.DataPropertyName = "Selected";
            this.colRoleSelected.Frozen = true;
            this.colRoleSelected.HeaderText = "选择";
            this.colRoleSelected.Name = "colRoleSelected";
            this.colRoleSelected.Width = 50;
            // 
            // colRoleRealName
            // 
            this.colRoleRealName.DataPropertyName = "RealName";
            this.colRoleRealName.HeaderText = "名称";
            this.colRoleRealName.Name = "colRoleRealName";
            this.colRoleRealName.Width = 200;
            // 
            // colRoleDescription
            // 
            this.colRoleDescription.DataPropertyName = "Description";
            this.colRoleDescription.HeaderText = "描述";
            this.colRoleDescription.Name = "colRoleDescription";
            this.colRoleDescription.Width = 205;
            // 
            // dgvCMenu
            // 
            this.dgvCMenu.Font = new System.Drawing.Font("宋体", 10F);
            this.dgvCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuSelectAll,
            this.cmnuInvertSelect});
            this.dgvCMenu.Name = "dgvCMenu";
            this.dgvCMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // cmnuSelectAll
            // 
            this.cmnuSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("cmnuSelectAll.Image")));
            this.cmnuSelectAll.Name = "cmnuSelectAll";
            this.cmnuSelectAll.Size = new System.Drawing.Size(152, 22);
            this.cmnuSelectAll.Text = "全选";
            this.cmnuSelectAll.Click += new System.EventHandler(this.cmnuSelectAll_Click);
            // 
            // cmnuInvertSelect
            // 
            this.cmnuInvertSelect.Image = ((System.Drawing.Image)(resources.GetObject("cmnuInvertSelect.Image")));
            this.cmnuInvertSelect.Name = "cmnuInvertSelect";
            this.cmnuInvertSelect.Size = new System.Drawing.Size(152, 22);
            this.cmnuInvertSelect.Text = "反选";
            this.cmnuInvertSelect.Click += new System.EventHandler(this.cmnuInvertSelect_Click);
            // 
            // tcItemRole
            // 
            this.tcItemRole.AttachedControl = this.tabControlPanel1;
            this.tcItemRole.Image = ((System.Drawing.Image)(resources.GetObject("tcItemRole.Image")));
            this.tcItemRole.Name = "tcItemRole";
            this.tcItemRole.Text = "角色";
            // 
            // tcResource
            // 
            this.tcResource.BackColor = System.Drawing.SystemColors.Window;
            this.tcResource.CanReorderTabs = true;
            this.tcResource.Controls.Add(this.tabControlPanel2);
            this.tcResource.Controls.Add(this.tabControlPanel1);
            this.tcResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcResource.Location = new System.Drawing.Point(0, 0);
            this.tcResource.Name = "tcResource";
            this.tcResource.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcResource.SelectedTabIndex = 0;
            this.tcResource.Size = new System.Drawing.Size(619, 459);
            this.tcResource.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcResource.TabIndex = 23;
            this.tcResource.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcResource.Tabs.Add(this.tcItemUser);
            this.tcResource.Tabs.Add(this.tcItemRole);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvUser);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(619, 432);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tcItemUser;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUser.ColumnHeadersHeight = 26;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserSelected,
            this.colUserUserName,
            this.colUserRealName,
            this.colUserDescription});
            this.dgvUser.ContextMenuStrip = this.dgvCMenu;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvUser.Location = new System.Drawing.Point(1, 1);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUser.RowHeadersWidth = 40;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(617, 430);
            this.dgvUser.TabIndex = 5;
            // 
            // colUserSelected
            // 
            this.colUserSelected.DataPropertyName = "Selected";
            this.colUserSelected.Frozen = true;
            this.colUserSelected.HeaderText = "选择";
            this.colUserSelected.Name = "colUserSelected";
            this.colUserSelected.Width = 50;
            // 
            // colUserUserName
            // 
            this.colUserUserName.DataPropertyName = "UserName";
            this.colUserUserName.HeaderText = "用户";
            this.colUserUserName.Name = "colUserUserName";
            this.colUserUserName.ReadOnly = true;
            this.colUserUserName.Width = 150;
            // 
            // colUserRealName
            // 
            this.colUserRealName.DataPropertyName = "RealName";
            this.colUserRealName.HeaderText = "姓名";
            this.colUserRealName.Name = "colUserRealName";
            this.colUserRealName.ReadOnly = true;
            this.colUserRealName.Width = 150;
            // 
            // colUserDescription
            // 
            this.colUserDescription.DataPropertyName = "Description";
            this.colUserDescription.HeaderText = "描述";
            this.colUserDescription.Name = "colUserDescription";
            this.colUserDescription.Width = 200;
            // 
            // tcItemUser
            // 
            this.tcItemUser.AttachedControl = this.tabControlPanel2;
            this.tcItemUser.Image = ((System.Drawing.Image)(resources.GetObject("tcItemUser.Image")));
            this.tcItemUser.Name = "tcItemUser";
            this.tcItemUser.Text = "用户";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblPermissionItemName);
            this.splitContainer1.Panel1.Controls.Add(this.lblTargetResourceName);
            this.splitContainer1.Panel1.Controls.Add(this.lblPermissionItem);
            this.splitContainer1.Panel1.Controls.Add(this.lblTargetResource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcResource);
            this.splitContainer1.Size = new System.Drawing.Size(619, 548);
            this.splitContainer1.SplitterDistance = 85;
            this.splitContainer1.TabIndex = 32;
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPermissionItemName.ForeColor = System.Drawing.Color.Green;
            this.lblPermissionItemName.Location = new System.Drawing.Point(122, 49);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(97, 14);
            this.lblPermissionItemName.TabIndex = 7;
            this.lblPermissionItemName.Text = "资源管理权限";
            this.lblPermissionItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTargetResourceName
            // 
            this.lblTargetResourceName.AutoSize = true;
            this.lblTargetResourceName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTargetResourceName.ForeColor = System.Drawing.Color.Green;
            this.lblTargetResourceName.Location = new System.Drawing.Point(122, 18);
            this.lblTargetResourceName.Name = "lblTargetResourceName";
            this.lblTargetResourceName.Size = new System.Drawing.Size(45, 14);
            this.lblTargetResourceName.TabIndex = 5;
            this.lblTargetResourceName.Text = "资源A";
            this.lblTargetResourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPermissionItem
            // 
            this.lblPermissionItem.AutoEllipsis = true;
            this.lblPermissionItem.Location = new System.Drawing.Point(12, 49);
            this.lblPermissionItem.Name = "lblPermissionItem";
            this.lblPermissionItem.Size = new System.Drawing.Size(117, 14);
            this.lblPermissionItem.TabIndex = 6;
            this.lblPermissionItem.Text = "操作权限：";
            this.lblPermissionItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPermissionItem.Click += new System.EventHandler(this.lblPermissionItem_Click);
            // 
            // lblTargetResource
            // 
            this.lblTargetResource.AutoEllipsis = true;
            this.lblTargetResource.Location = new System.Drawing.Point(12, 18);
            this.lblTargetResource.Name = "lblTargetResource";
            this.lblTargetResource.Size = new System.Drawing.Size(117, 14);
            this.lblTargetResource.TabIndex = 4;
            this.lblTargetResource.Text = "当前资源：";
            this.lblTargetResource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 5);
            this.panel2.TabIndex = 34;
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(619, 25);
            this.tlsTool.TabIndex = 33;
            this.tlsTool.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmResourcePermissionScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmResourcePermissionScope";
            this.Text = "资源权限设置";
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
            this.dgvCMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcResource)).EndInit();
            this.tcResource.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private Controls.UcDataGridView dgvRole;
        private System.Windows.Forms.ContextMenuStrip dgvCMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuInvertSelect;
        private DevComponents.DotNetBar.TabItem tcItemRole;
        private DevComponents.DotNetBar.TabControl tcResource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label lblPermissionItemName;
        private System.Windows.Forms.Label lblTargetResourceName;
        private System.Windows.Forms.Label lblPermissionItem;
        private System.Windows.Forms.Label lblTargetResource;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tcItemUser;
        private Controls.UcDataGridView dgvUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRoleSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserDescription;
    }
}