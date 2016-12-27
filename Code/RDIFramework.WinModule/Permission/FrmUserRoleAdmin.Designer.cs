/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:55:00
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserRoleAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserRoleAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuInvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUser = new RDIFramework.Controls.UcTextBox(this.components);
            this.cboRole = new RDIFramework.Controls.UcComboBoxEx();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDefaultRole = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnAddToRole = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.btnRolePermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.butSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCMenu
            // 
            this.dgvCMenu.Font = new System.Drawing.Font("宋体", 10F);
            this.dgvCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuSelectAll,
            this.cmnuInvertSelect});
            this.dgvCMenu.Name = "dgvCMenu";
            this.dgvCMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // cmnuSelectAll
            // 
            this.cmnuSelectAll.Image = global::RDIFramework.WinModule.Properties.Resources.全选;
            this.cmnuSelectAll.Name = "cmnuSelectAll";
            this.cmnuSelectAll.Size = new System.Drawing.Size(102, 22);
            this.cmnuSelectAll.Text = "全选";
            this.cmnuSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cmnuInvertSelect
            // 
            this.cmnuInvertSelect.Image = global::RDIFramework.WinModule.Properties.Resources.反选;
            this.cmnuInvertSelect.Name = "cmnuInvertSelect";
            this.cmnuInvertSelect.Size = new System.Drawing.Size(102, 22);
            this.cmnuInvertSelect.Text = "反选";
            this.cmnuInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.FocusHighlightEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(12, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.SelectedValue = ((object)(resources.GetObject("txtUser.SelectedValue")));
            this.txtUser.Size = new System.Drawing.Size(156, 23);
            this.txtUser.TabIndex = 44;
            // 
            // cboRole
            // 
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(12, 25);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(156, 24);
            this.cboRole.TabIndex = 45;
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
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 544);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 13;
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
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 517);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItemSearch;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel2);
            this.gbCustomSearch.Controls.Add(this.panel4);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 507);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "当前";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDefaultRole);
            this.panel2.Controls.Add(this.cboRole);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 56);
            this.panel2.TabIndex = 3;
            // 
            // lblDefaultRole
            // 
            this.lblDefaultRole.AutoSize = true;
            this.lblDefaultRole.Location = new System.Drawing.Point(9, 5);
            this.lblDefaultRole.Name = "lblDefaultRole";
            this.lblDefaultRole.Size = new System.Drawing.Size(98, 14);
            this.lblDefaultRole.TabIndex = 2;
            this.lblDefaultRole.Text = "默认角色(&R)：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblUser);
            this.panel4.Controls.Add(this.txtUser);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 65);
            this.panel4.TabIndex = 9;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(10, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(70, 14);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "用户(&U)：";
            // 
            // tabItemSearch
            // 
            this.tabItemSearch.AttachedControl = this.tabControlPanel3;
            this.tabItemSearch.Name = "tabItemSearch";
            this.tabItemSearch.Text = "常规信息";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 544);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddToRole,
            this.btnRemove,
            this.btnRolePermission,
            this.toolStripSeparator2,
            this.butSave,
            this.toolStripSeparator3,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(201, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(681, 25);
            this.tlsTool.TabIndex = 19;
            this.tlsTool.Text = "toolStrip1";
            // 
            // btnAddToRole
            // 
            this.btnAddToRole.Image = global::RDIFramework.WinModule.Properties.Resources.roleAdd;
            this.btnAddToRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddToRole.Name = "btnAddToRole";
            this.btnAddToRole.Size = new System.Drawing.Size(87, 22);
            this.btnAddToRole.Text = "添加角色";
            this.btnAddToRole.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::RDIFramework.WinModule.Properties.Resources.roleDelete;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(87, 22);
            this.btnRemove.Text = "移除角色";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRolePermission
            // 
            this.btnRolePermission.Image = global::RDIFramework.WinModule.Properties.Resources.role1;
            this.btnRolePermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRolePermission.Name = "btnRolePermission";
            this.btnRolePermission.Size = new System.Drawing.Size(117, 22);
            this.btnRolePermission.Text = "查看角色权限";
            this.btnRolePermission.Click += new System.EventHandler(this.btnRolePermission_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // butSave
            // 
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(57, 22);
            this.butSave.Text = "保存";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::RDIFramework.WinModule.Properties.Resources.copy;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(87, 22);
            this.btnCopy.Text = "复制角色";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Image = global::RDIFramework.WinModule.Properties.Resources.paste;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(87, 22);
            this.btnPaste.Text = "粘贴角色";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(201, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(681, 519);
            this.pnlMain.TabIndex = 48;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.colFullName,
            this.colDescription});
            this.dgvInfo.ContextMenuStrip = this.dgvCMenu;
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
            this.dgvInfo.RowHeadersWidth = 30;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(681, 519);
            this.dgvInfo.TabIndex = 48;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 45;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "RealName";
            this.colFullName.HeaderText = "名称";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 500;
            // 
            // FrmUserRoleAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 544);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsTool);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.MaximizeBox = false;
            this.Name = "FrmUserRoleAdmin";
            this.Text = "用户角色关联";
            this.dgvCMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcTextBox txtUser;
        private Controls.UcComboBoxEx cboRole;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDefaultRole;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnAddToRole;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripButton btnRolePermission;
        private System.Windows.Forms.ToolStripButton butSave;
        private System.Windows.Forms.ContextMenuStrip dgvCMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuInvertSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel pnlMain;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;


    }
}