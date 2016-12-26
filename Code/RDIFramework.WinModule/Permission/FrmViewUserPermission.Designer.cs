namespace RDIFramework.WinModule
{
    partial class FrmViewUserPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewUserPermission));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHintDetail = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbHaveRole = new System.Windows.Forms.GroupBox();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnShowRolePermission = new RDIFramework.Controls.UcButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRole = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtRealName = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDefaultRole = new System.Windows.Forms.Label();
            this.lblRealName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tabItemCurrentUser = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemPermissionItemPermission = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabItemModulePermission = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.gbHaveRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControlPanel6.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblHintDetail);
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 53);
            this.panel1.TabIndex = 0;
            // 
            // lblHintDetail
            // 
            this.lblHintDetail.AutoSize = true;
            this.lblHintDetail.Location = new System.Drawing.Point(54, 20);
            this.lblHintDetail.Name = "lblHintDetail";
            this.lblHintDetail.Size = new System.Drawing.Size(511, 14);
            this.lblHintDetail.TabIndex = 1;
            this.lblHintDetail.Text = "显示当前用户所拥有的所有可用权限（角色、模块访问权限、分配的操作权限）。";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHint.Location = new System.Drawing.Point(12, 20);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(52, 14);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "提示：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 597);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 48);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(590, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tcUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 544);
            this.panel3.TabIndex = 2;
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel6);
            this.tcUser.Controls.Add(this.tabControlPanel5);
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(688, 544);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.Office2003;
            this.tcUser.TabIndex = 20;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemCurrentUser);
            this.tcUser.Tabs.Add(this.tabItemModulePermission);
            this.tcUser.Tabs.Add(this.tabItemPermissionItemPermission);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.gbHaveRole);
            this.tabControlPanel2.Controls.Add(this.panel7);
            this.tabControlPanel2.Controls.Add(this.splitter2);
            this.tabControlPanel2.Controls.Add(this.panel4);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel2.Size = new System.Drawing.Size(688, 517);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.Highlight;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemCurrentUser;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // gbHaveRole
            // 
            this.gbHaveRole.BackColor = System.Drawing.Color.White;
            this.gbHaveRole.Controls.Add(this.dgvInfo);
            this.gbHaveRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHaveRole.Location = new System.Drawing.Point(5, 150);
            this.gbHaveRole.Name = "gbHaveRole";
            this.gbHaveRole.Size = new System.Drawing.Size(678, 312);
            this.gbHaveRole.TabIndex = 1;
            this.gbHaveRole.TabStop = false;
            this.gbHaveRole.Text = "拥有的角色";
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
            this.colFullName,
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
            this.dgvInfo.Location = new System.Drawing.Point(3, 19);
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
            this.dgvInfo.Size = new System.Drawing.Size(672, 290);
            this.dgvInfo.TabIndex = 47;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.btnShowRolePermission);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(5, 462);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(678, 50);
            this.panel7.TabIndex = 5;
            // 
            // btnShowRolePermission
            // 
            this.btnShowRolePermission.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowRolePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRolePermission.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowRolePermission.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShowRolePermission.Location = new System.Drawing.Point(500, 11);
            this.btnShowRolePermission.Name = "btnShowRolePermission";
            this.btnShowRolePermission.Size = new System.Drawing.Size(161, 29);
            this.btnShowRolePermission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowRolePermission.TabIndex = 1;
            this.btnShowRolePermission.Text = "查看角色权限";
            this.btnShowRolePermission.Click += new System.EventHandler(this.btnShowRolePermission_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Green;
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(5, 149);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(678, 1);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtRole);
            this.panel4.Controls.Add(this.txtRealName);
            this.panel4.Controls.Add(this.txtUserName);
            this.panel4.Controls.Add(this.lblDefaultRole);
            this.panel4.Controls.Add(this.lblRealName);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(678, 144);
            this.panel4.TabIndex = 0;
            // 
            // txtRole
            // 
            // 
            // 
            // 
            this.txtRole.Border.Class = "TextBoxBorder";
            this.txtRole.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRole.FocusHighlightEnabled = true;
            this.txtRole.Location = new System.Drawing.Point(122, 94);
            this.txtRole.Name = "txtRole";
            this.txtRole.SelectedValue = null;
            this.txtRole.Size = new System.Drawing.Size(340, 23);
            this.txtRole.TabIndex = 5;
            // 
            // txtRealName
            // 
            // 
            // 
            // 
            this.txtRealName.Border.Class = "TextBoxBorder";
            this.txtRealName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealName.FocusHighlightEnabled = true;
            this.txtRealName.Location = new System.Drawing.Point(122, 60);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.SelectedValue = null;
            this.txtRealName.Size = new System.Drawing.Size(340, 23);
            this.txtRealName.TabIndex = 4;
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(122, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(340, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // lblDefaultRole
            // 
            this.lblDefaultRole.AutoEllipsis = true;
            this.lblDefaultRole.Location = new System.Drawing.Point(8, 95);
            this.lblDefaultRole.Name = "lblDefaultRole";
            this.lblDefaultRole.Size = new System.Drawing.Size(118, 14);
            this.lblDefaultRole.TabIndex = 2;
            this.lblDefaultRole.Text = "默认角色：";
            this.lblDefaultRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRealName
            // 
            this.lblRealName.AutoEllipsis = true;
            this.lblRealName.Location = new System.Drawing.Point(8, 62);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(118, 14);
            this.lblRealName.TabIndex = 1;
            this.lblRealName.Text = "姓名：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Location = new System.Drawing.Point(8, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(118, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemCurrentUser
            // 
            this.tabItemCurrentUser.AttachedControl = this.tabControlPanel2;
            this.tabItemCurrentUser.BackColor = System.Drawing.Color.White;
            this.tabItemCurrentUser.Image = global::RDIFramework.WinModule.Properties.Resources.user;
            this.tabItemCurrentUser.Name = "tabItemCurrentUser";
            this.tabItemCurrentUser.Text = "当前用户";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Controls.Add(this.panel6);
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel6.Size = new System.Drawing.Size(688, 517);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.SystemColors.Highlight;
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 5;
            this.tabControlPanel6.TabItem = this.tabItemPermissionItemPermission;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tvPermissionItem);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(5, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(678, 507);
            this.panel6.TabIndex = 0;
            // 
            // tvPermissionItem
            // 
            this.tvPermissionItem.AllowDrop = true;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imgList;
            this.tvPermissionItem.Location = new System.Drawing.Point(0, 0);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 1;
            this.tvPermissionItem.Size = new System.Drawing.Size(678, 507);
            this.tvPermissionItem.TabIndex = 4;
            this.tvPermissionItem.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPermissionItem_BeforeCheck);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "button.png");
            this.imgList.Images.SetKeyName(1, "ok.png");
            // 
            // tabItemPermissionItemPermission
            // 
            this.tabItemPermissionItemPermission.AttachedControl = this.tabControlPanel6;
            this.tabItemPermissionItemPermission.Image = global::RDIFramework.WinModule.Properties.Resources.PermissionItem;
            this.tabItemPermissionItemPermission.Name = "tabItemPermissionItemPermission";
            this.tabItemPermissionItemPermission.Text = "分配的操作（功能）权限";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.panel5);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel5.Size = new System.Drawing.Size(688, 517);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.SystemColors.Highlight;
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 4;
            this.tabControlPanel5.TabItem = this.tabItemModulePermission;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tvModule);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(678, 507);
            this.panel5.TabIndex = 5;
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.CheckBoxes = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageList1;
            this.tvModule.Location = new System.Drawing.Point(3, 3);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 1;
            this.tvModule.Size = new System.Drawing.Size(672, 501);
            this.tvModule.TabIndex = 3;
            this.tvModule.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvModule_BeforeCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "menu1.png");
            this.imageList1.Images.SetKeyName(1, "menu2.png");
            // 
            // tabItemModulePermission
            // 
            this.tabItemModulePermission.AttachedControl = this.tabControlPanel5;
            this.tabItemModulePermission.Image = global::RDIFramework.WinModule.Properties.Resources.MenuOrModule;
            this.tabItemModulePermission.Name = "tabItemModulePermission";
            this.tabItemModulePermission.Text = "所拥有的模块（菜单）";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Green;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(688, 1);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "RealName";
            this.colFullName.HeaderText = "角色名称";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 450;
            // 
            // FrmViewUserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(688, 645);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewUserPermission";
            this.Text = "用户权限";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.gbHaveRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControlPanel6.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private DevComponents.DotNetBar.TabItem tabItemPermissionItemPermission;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItemModulePermission;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemCurrentUser;
        private System.Windows.Forms.GroupBox gbHaveRole;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Label lblDefaultRole;
        private Controls.UcTextBox txtRole;
        private Controls.UcTextBox txtRealName;
        private Controls.UcTextBox txtUserName;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.TreeView tvModule;
        private Controls.UcButton btnClose;
        private System.Windows.Forms.Panel panel7;
        private Controls.UcButton btnShowRolePermission;
        private System.Windows.Forms.Label lblHintDetail;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}