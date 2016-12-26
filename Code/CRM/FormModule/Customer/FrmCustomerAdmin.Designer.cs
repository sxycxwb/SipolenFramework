namespace CRM
{
    partial class FrmCustomerAdmin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("客户信息", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("联系人信息", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tabCustomerClass = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvCustomerClass = new System.Windows.Forms.TreeView();
            this.cMnuCustomerClass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddSameLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddLowerLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRenameClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCustomerSearch = new RDIFramework.Controls.UcButton();
            this.rbCustomerLikeSearch = new System.Windows.Forms.RadioButton();
            this.rbCustomerExactSearch = new System.Windows.Forms.RadioButton();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.rbCustomerDescription = new System.Windows.Forms.RadioButton();
            this.rbCustomerWebAddress = new System.Windows.Forms.RadioButton();
            this.rbCustomerCompanyFax = new System.Windows.Forms.RadioButton();
            this.rbCustomerPostalCode = new System.Windows.Forms.RadioButton();
            this.rbCustomerCompanyAddress = new System.Windows.Forms.RadioButton();
            this.rbCustomerCompanyPhone = new System.Windows.Forms.RadioButton();
            this.rbCustomerCompanyName = new System.Windows.Forms.RadioButton();
            this.rbCustomerShortName = new System.Windows.Forms.RadioButton();
            this.rbCustomerAll = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCustomSearchValue = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUpLevel = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCustomer = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWebAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCustomerLinkInfo = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvCustomerInfo = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.lvSizeImage = new System.Windows.Forms.ImageList(this.components);
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.lblLinkManNumber = new System.Windows.Forms.Label();
            this.tabItemCustomerInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvLinkMain = new RDIFramework.Controls.UcDataGridView();
            this.colLinkManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMainLinkMan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobilePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOfficeFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMajor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEducationalBackground = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddLinkMain = new System.Windows.Forms.ToolStripButton();
            this.btnEditLinkMain = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteLinkMain = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportLinkMain = new System.Windows.Forms.ToolStripButton();
            this.btnExportLinkMain = new System.Windows.Forms.ToolStripButton();
            this.dropDownLinkManSaveAs = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnExportLinkManToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToWordpad = new System.Windows.Forms.ToolStripMenuItem();
            this.tabItemContactInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem5 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel10 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem8 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel9 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem7 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel8 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem6 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel7 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).BeginInit();
            this.tabCustomerClass.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.cMnuCustomerClass.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.expandablePanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerLinkInfo)).BeginInit();
            this.tabCustomerLinkInfo.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkMain)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabCustomerClass);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(198, 741);
            this.pnlLeft.TabIndex = 0;
            // 
            // tabCustomerClass
            // 
            this.tabCustomerClass.BackColor = System.Drawing.SystemColors.Window;
            this.tabCustomerClass.CanReorderTabs = true;
            this.tabCustomerClass.Controls.Add(this.tabControlPanel4);
            this.tabCustomerClass.Controls.Add(this.tabControlPanel3);
            this.tabCustomerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomerClass.Location = new System.Drawing.Point(0, 0);
            this.tabCustomerClass.Name = "tabCustomerClass";
            this.tabCustomerClass.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCustomerClass.SelectedTabIndex = 0;
            this.tabCustomerClass.Size = new System.Drawing.Size(198, 741);
            this.tabCustomerClass.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabCustomerClass.TabIndex = 2;
            this.tabCustomerClass.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabCustomerClass.Tabs.Add(this.tabItem4);
            this.tabCustomerClass.Tabs.Add(this.tabItem3);
            this.tabCustomerClass.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvCustomerClass);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(198, 714);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // tvCustomerClass
            // 
            this.tvCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvCustomerClass.ContextMenuStrip = this.cMnuCustomerClass;
            this.tvCustomerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCustomerClass.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvCustomerClass.ImageIndex = 0;
            this.tvCustomerClass.ImageList = this.imageList;
            this.tvCustomerClass.Location = new System.Drawing.Point(1, 1);
            this.tvCustomerClass.Name = "tvCustomerClass";
            this.tvCustomerClass.SelectedImageIndex = 1;
            this.tvCustomerClass.Size = new System.Drawing.Size(196, 712);
            this.tvCustomerClass.TabIndex = 0;
            this.tvCustomerClass.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvCustomerClass_BeforeLabelEdit);
            this.tvCustomerClass.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvCustomerClass_AfterLabelEdit);
            this.tvCustomerClass.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomerClass_AfterExpand);
            this.tvCustomerClass.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCustomerClass_BeforeSelect);
            this.tvCustomerClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomerClass_AfterSelect);
            this.tvCustomerClass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCustomerClass_MouseDown);
            // 
            // cMnuCustomerClass
            // 
            this.cMnuCustomerClass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSameLevel,
            this.mnuAddLowerLevel,
            this.toolStripMenuItem1,
            this.mnuDeleteCurrent,
            this.mnuRenameClass,
            this.toolStripMenuItem2,
            this.mnuUp,
            this.mnuDown});
            this.cMnuCustomerClass.Name = "cMnuCustomerClass";
            this.cMnuCustomerClass.Size = new System.Drawing.Size(149, 148);
            // 
            // mnuAddSameLevel
            // 
            this.mnuAddSameLevel.Image = global::CRM.Properties.Resources.add;
            this.mnuAddSameLevel.Name = "mnuAddSameLevel";
            this.mnuAddSameLevel.Size = new System.Drawing.Size(148, 22);
            this.mnuAddSameLevel.Text = "新增同级分类";
            this.mnuAddSameLevel.Click += new System.EventHandler(this.mnuAddSameLevel_Click);
            // 
            // mnuAddLowerLevel
            // 
            this.mnuAddLowerLevel.Image = global::CRM.Properties.Resources.add;
            this.mnuAddLowerLevel.Name = "mnuAddLowerLevel";
            this.mnuAddLowerLevel.Size = new System.Drawing.Size(148, 22);
            this.mnuAddLowerLevel.Text = "新增下级分类";
            this.mnuAddLowerLevel.Click += new System.EventHandler(this.mnuAddLowerLevel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuDeleteCurrent
            // 
            this.mnuDeleteCurrent.Image = global::CRM.Properties.Resources.del;
            this.mnuDeleteCurrent.Name = "mnuDeleteCurrent";
            this.mnuDeleteCurrent.Size = new System.Drawing.Size(148, 22);
            this.mnuDeleteCurrent.Text = "删除当前分类";
            this.mnuDeleteCurrent.Click += new System.EventHandler(this.mnuDeleteCurrent_Click);
            // 
            // mnuRenameClass
            // 
            this.mnuRenameClass.Image = global::CRM.Properties.Resources.rename;
            this.mnuRenameClass.Name = "mnuRenameClass";
            this.mnuRenameClass.Size = new System.Drawing.Size(148, 22);
            this.mnuRenameClass.Text = "重命名";
            this.mnuRenameClass.Click += new System.EventHandler(this.mnuRenameClass_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuUp
            // 
            this.mnuUp.Image = global::CRM.Properties.Resources.up;
            this.mnuUp.Name = "mnuUp";
            this.mnuUp.Size = new System.Drawing.Size(148, 22);
            this.mnuUp.Text = "向上移动";
            this.mnuUp.Click += new System.EventHandler(this.mnuUp_Click);
            // 
            // mnuDown
            // 
            this.mnuDown.Image = global::CRM.Properties.Resources.down;
            this.mnuDown.Name = "mnuDown";
            this.mnuDown.Size = new System.Drawing.Size(148, 22);
            this.mnuDown.Text = "向下移动";
            this.mnuDown.Click += new System.EventHandler(this.mnuDown_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.gif");
            this.imageList.Images.SetKeyName(1, "folderOpen.gif");
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "客户浏览";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 714);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.expandablePanel2);
            this.gbCustomSearch.Controls.Add(this.panel2);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 704);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "客户常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCustomerSearch);
            this.panel3.Controls.Add(this.rbCustomerLikeSearch);
            this.panel3.Controls.Add(this.rbCustomerExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 65);
            this.panel3.TabIndex = 4;
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCustomerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomerSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCustomerSearch.Image = global::CRM.Properties.Resources.find;
            this.btnCustomerSearch.Location = new System.Drawing.Point(84, 20);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCustomerSearch.TabIndex = 13;
            this.btnCustomerSearch.Text = "搜索";
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // rbCustomerLikeSearch
            // 
            this.rbCustomerLikeSearch.AutoSize = true;
            this.rbCustomerLikeSearch.Checked = true;
            this.rbCustomerLikeSearch.Location = new System.Drawing.Point(12, 36);
            this.rbCustomerLikeSearch.Name = "rbCustomerLikeSearch";
            this.rbCustomerLikeSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerLikeSearch.TabIndex = 12;
            this.rbCustomerLikeSearch.TabStop = true;
            this.rbCustomerLikeSearch.Text = "模糊";
            this.rbCustomerLikeSearch.UseVisualStyleBackColor = true;
            // 
            // rbCustomerExactSearch
            // 
            this.rbCustomerExactSearch.AutoSize = true;
            this.rbCustomerExactSearch.Location = new System.Drawing.Point(12, 12);
            this.rbCustomerExactSearch.Name = "rbCustomerExactSearch";
            this.rbCustomerExactSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerExactSearch.TabIndex = 11;
            this.rbCustomerExactSearch.Text = "精确";
            this.rbCustomerExactSearch.UseVisualStyleBackColor = true;
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.rbCustomerDescription);
            this.expandablePanel2.Controls.Add(this.rbCustomerWebAddress);
            this.expandablePanel2.Controls.Add(this.rbCustomerCompanyFax);
            this.expandablePanel2.Controls.Add(this.rbCustomerPostalCode);
            this.expandablePanel2.Controls.Add(this.rbCustomerCompanyAddress);
            this.expandablePanel2.Controls.Add(this.rbCustomerCompanyPhone);
            this.expandablePanel2.Controls.Add(this.rbCustomerCompanyName);
            this.expandablePanel2.Controls.Add(this.rbCustomerShortName);
            this.expandablePanel2.Controls.Add(this.rbCustomerAll);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel2.ExpandOnTitleClick = true;
            this.expandablePanel2.Location = new System.Drawing.Point(3, 75);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(182, 232);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 2;
            this.expandablePanel2.TabStop = true;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.TopLeft;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = " 选择搜索范围";
            // 
            // rbCustomerDescription
            // 
            this.rbCustomerDescription.AutoSize = true;
            this.rbCustomerDescription.Location = new System.Drawing.Point(16, 204);
            this.rbCustomerDescription.Name = "rbCustomerDescription";
            this.rbCustomerDescription.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerDescription.TabIndex = 10;
            this.rbCustomerDescription.Text = "备    注";
            this.rbCustomerDescription.UseVisualStyleBackColor = true;
            // 
            // rbCustomerWebAddress
            // 
            this.rbCustomerWebAddress.AutoSize = true;
            this.rbCustomerWebAddress.Location = new System.Drawing.Point(16, 183);
            this.rbCustomerWebAddress.Name = "rbCustomerWebAddress";
            this.rbCustomerWebAddress.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerWebAddress.TabIndex = 8;
            this.rbCustomerWebAddress.Text = "网    址";
            this.rbCustomerWebAddress.UseVisualStyleBackColor = true;
            // 
            // rbCustomerCompanyFax
            // 
            this.rbCustomerCompanyFax.AutoSize = true;
            this.rbCustomerCompanyFax.Location = new System.Drawing.Point(16, 162);
            this.rbCustomerCompanyFax.Name = "rbCustomerCompanyFax";
            this.rbCustomerCompanyFax.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerCompanyFax.TabIndex = 7;
            this.rbCustomerCompanyFax.Text = "公司传真";
            this.rbCustomerCompanyFax.UseVisualStyleBackColor = true;
            // 
            // rbCustomerPostalCode
            // 
            this.rbCustomerPostalCode.AutoSize = true;
            this.rbCustomerPostalCode.Location = new System.Drawing.Point(16, 141);
            this.rbCustomerPostalCode.Name = "rbCustomerPostalCode";
            this.rbCustomerPostalCode.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerPostalCode.TabIndex = 6;
            this.rbCustomerPostalCode.Text = "公司邮编";
            this.rbCustomerPostalCode.UseVisualStyleBackColor = true;
            // 
            // rbCustomerCompanyAddress
            // 
            this.rbCustomerCompanyAddress.AutoSize = true;
            this.rbCustomerCompanyAddress.Location = new System.Drawing.Point(16, 120);
            this.rbCustomerCompanyAddress.Name = "rbCustomerCompanyAddress";
            this.rbCustomerCompanyAddress.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerCompanyAddress.TabIndex = 5;
            this.rbCustomerCompanyAddress.Text = "公司地址";
            this.rbCustomerCompanyAddress.UseVisualStyleBackColor = true;
            // 
            // rbCustomerCompanyPhone
            // 
            this.rbCustomerCompanyPhone.AutoSize = true;
            this.rbCustomerCompanyPhone.Location = new System.Drawing.Point(16, 99);
            this.rbCustomerCompanyPhone.Name = "rbCustomerCompanyPhone";
            this.rbCustomerCompanyPhone.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerCompanyPhone.TabIndex = 4;
            this.rbCustomerCompanyPhone.Text = "公司电话";
            this.rbCustomerCompanyPhone.UseVisualStyleBackColor = true;
            // 
            // rbCustomerCompanyName
            // 
            this.rbCustomerCompanyName.AutoSize = true;
            this.rbCustomerCompanyName.Location = new System.Drawing.Point(16, 78);
            this.rbCustomerCompanyName.Name = "rbCustomerCompanyName";
            this.rbCustomerCompanyName.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerCompanyName.TabIndex = 3;
            this.rbCustomerCompanyName.Text = "公司名称";
            this.rbCustomerCompanyName.UseVisualStyleBackColor = true;
            // 
            // rbCustomerShortName
            // 
            this.rbCustomerShortName.AutoSize = true;
            this.rbCustomerShortName.Location = new System.Drawing.Point(16, 57);
            this.rbCustomerShortName.Name = "rbCustomerShortName";
            this.rbCustomerShortName.Size = new System.Drawing.Size(81, 18);
            this.rbCustomerShortName.TabIndex = 2;
            this.rbCustomerShortName.Text = "客户简称";
            this.rbCustomerShortName.UseVisualStyleBackColor = true;
            // 
            // rbCustomerAll
            // 
            this.rbCustomerAll.AutoSize = true;
            this.rbCustomerAll.Checked = true;
            this.rbCustomerAll.Location = new System.Drawing.Point(16, 36);
            this.rbCustomerAll.Name = "rbCustomerAll";
            this.rbCustomerAll.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerAll.TabIndex = 1;
            this.rbCustomerAll.TabStop = true;
            this.rbCustomerAll.Text = "所有";
            this.rbCustomerAll.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCustomSearchValue);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 56);
            this.panel2.TabIndex = 3;
            // 
            // txtCustomSearchValue
            // 
            // 
            // 
            // 
            this.txtCustomSearchValue.Border.Class = "TextBoxBorder";
            this.txtCustomSearchValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomSearchValue.FocusHighlightEnabled = true;
            this.txtCustomSearchValue.Location = new System.Drawing.Point(9, 22);
            this.txtCustomSearchValue.Name = "txtCustomSearchValue";
            this.txtCustomSearchValue.SelectedValue = ((object)(resources.GetObject("txtCustomSearchValue.SelectedValue")));
            this.txtCustomSearchValue.Size = new System.Drawing.Size(160, 23);
            this.txtCustomSearchValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "搜索内容：";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "搜索";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 741);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpLevel,
            this.btnAdd,
            this.btnEdit,
            this.btnCopy,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnEmail,
            this.toolStripSeparator2,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(203, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(662, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUpLevel
            // 
            this.btnUpLevel.Image = ((System.Drawing.Image)(resources.GetObject("btnUpLevel.Image")));
            this.btnUpLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpLevel.Name = "btnUpLevel";
            this.btnUpLevel.Size = new System.Drawing.Size(55, 22);
            this.btnUpLevel.Text = "上级";
            this.btnUpLevel.Click += new System.EventHandler(this.btnUpLevel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 22);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 22);
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(55, 22);
            this.btnCopy.Text = "复制";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 22);
            this.btnPrint.Text = "打印";
            // 
            // btnEmail
            // 
            this.btnEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.Image")));
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(55, 22);
            this.btnEmail.Text = "邮件";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
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
            this.btnClose.Size = new System.Drawing.Size(55, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(203, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabCustomerLinkInfo);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(662, 716);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToOrderColumns = true;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.ColumnHeadersHeight = 26;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.CustomerClassID,
            this.Id,
            this.colShortName,
            this.colCompany,
            this.colCompanyPhone,
            this.colPostalCode,
            this.colCompanyFax,
            this.colWebAddress,
            this.colCompanyAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.EnableHeadersVisualStyles = false;
            this.dgvCustomer.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomer.RowHeadersWidth = 30;
            this.dgvCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomer.RowTemplate.Height = 23;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(662, 417);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CurrentCellChanged += new System.EventHandler(this.dgvCustomer_CurrentCellChanged);
            this.dgvCustomer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomer_DataBindingComplete);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 45;
            // 
            // CustomerClassID
            // 
            this.CustomerClassID.DataPropertyName = "CustomerClassID";
            this.CustomerClassID.HeaderText = "CustomerClassID";
            this.CustomerClassID.Name = "CustomerClassID";
            this.CustomerClassID.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // colShortName
            // 
            this.colShortName.DataPropertyName = "ShortName";
            this.colShortName.HeaderText = "客户简称";
            this.colShortName.Name = "colShortName";
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "CompanyName";
            this.colCompany.HeaderText = "公司名称";
            this.colCompany.Name = "colCompany";
            this.colCompany.Width = 130;
            // 
            // colCompanyPhone
            // 
            this.colCompanyPhone.DataPropertyName = "CompanyPhone";
            this.colCompanyPhone.HeaderText = "公司电话";
            this.colCompanyPhone.Name = "colCompanyPhone";
            // 
            // colPostalCode
            // 
            this.colPostalCode.DataPropertyName = "PostalCode";
            this.colPostalCode.HeaderText = "公司邮编";
            this.colPostalCode.Name = "colPostalCode";
            // 
            // colCompanyFax
            // 
            this.colCompanyFax.DataPropertyName = "CompanyFax";
            this.colCompanyFax.HeaderText = "公司传真";
            this.colCompanyFax.Name = "colCompanyFax";
            // 
            // colWebAddress
            // 
            this.colWebAddress.DataPropertyName = "WebAddress";
            this.colWebAddress.HeaderText = "网址";
            this.colWebAddress.Name = "colWebAddress";
            // 
            // colCompanyAddress
            // 
            this.colCompanyAddress.DataPropertyName = "CompanyAddress";
            this.colCompanyAddress.HeaderText = "公司地址";
            this.colCompanyAddress.Name = "colCompanyAddress";
            this.colCompanyAddress.Width = 200;
            // 
            // tabCustomerLinkInfo
            // 
            this.tabCustomerLinkInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tabCustomerLinkInfo.CanReorderTabs = true;
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel1);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel2);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel5);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel10);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel9);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel8);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel7);
            this.tabCustomerLinkInfo.Controls.Add(this.tabControlPanel6);
            this.tabCustomerLinkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomerLinkInfo.Location = new System.Drawing.Point(0, 18);
            this.tabCustomerLinkInfo.Name = "tabCustomerLinkInfo";
            this.tabCustomerLinkInfo.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCustomerLinkInfo.SelectedTabIndex = 0;
            this.tabCustomerLinkInfo.Size = new System.Drawing.Size(662, 277);
            this.tabCustomerLinkInfo.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabCustomerLinkInfo.TabIndex = 1;
            this.tabCustomerLinkInfo.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineWithNavigationBox;
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItemCustomerInfo);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItemContactInfo);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem5);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem1);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem2);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem6);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem7);
            this.tabCustomerLinkInfo.Tabs.Add(this.tabItem8);
            this.tabCustomerLinkInfo.Text = "tabControl1";
            this.tabCustomerLinkInfo.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabCustomerLinkInfo_SelectedTabChanged);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lvCustomerInfo);
            this.tabControlPanel1.Controls.Add(this.expandablePanel1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemCustomerInfo;
            // 
            // lvCustomerInfo
            // 
            // 
            // 
            // 
            this.lvCustomerInfo.Border.Class = "ListViewBorder";
            this.lvCustomerInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomerInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvCustomerInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvCustomerInfo.FullRowSelect = true;
            this.lvCustomerInfo.GridLines = true;
            listViewGroup1.Header = "客户信息";
            listViewGroup1.Name = "lvGroupCustomerInfo";
            listViewGroup2.Header = "联系人信息";
            listViewGroup2.Name = "lvGroupContractInfo";
            this.lvCustomerInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvCustomerInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCustomerInfo.Location = new System.Drawing.Point(1, 1);
            this.lvCustomerInfo.MultiSelect = false;
            this.lvCustomerInfo.Name = "lvCustomerInfo";
            this.lvCustomerInfo.Size = new System.Drawing.Size(460, 248);
            this.lvCustomerInfo.SmallImageList = this.lvSizeImage;
            this.lvCustomerInfo.TabIndex = 1;
            this.lvCustomerInfo.UseCompatibleStateImageBehavior = false;
            this.lvCustomerInfo.View = System.Windows.Forms.View.Details;
            // 
            // lvSizeImage
            // 
            this.lvSizeImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.lvSizeImage.ImageSize = new System.Drawing.Size(1, 20);
            this.lvSizeImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.AutoScroll = true;
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.lblLinkManNumber);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Location = new System.Drawing.Point(461, 1);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(200, 248);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 2;
            this.expandablePanel1.TitleHeight = 30;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.Etched;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "数据统计";
            // 
            // lblLinkManNumber
            // 
            this.lblLinkManNumber.AutoSize = true;
            this.lblLinkManNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLinkManNumber.Location = new System.Drawing.Point(6, 37);
            this.lblLinkManNumber.Name = "lblLinkManNumber";
            this.lblLinkManNumber.Size = new System.Drawing.Size(143, 12);
            this.lblLinkManNumber.TabIndex = 1;
            this.lblLinkManNumber.Text = "【1、联 系 人】：共XX人";
            // 
            // tabItemCustomerInfo
            // 
            this.tabItemCustomerInfo.AttachedControl = this.tabControlPanel1;
            this.tabItemCustomerInfo.Name = "tabItemCustomerInfo";
            this.tabItemCustomerInfo.Text = "客户信息";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvLinkMain);
            this.tabControlPanel2.Controls.Add(this.toolStrip2);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItemContactInfo;
            // 
            // dgvLinkMain
            // 
            this.dgvLinkMain.AllowUserToAddRows = false;
            this.dgvLinkMain.AllowUserToDeleteRows = false;
            this.dgvLinkMain.AllowUserToOrderColumns = true;
            this.dgvLinkMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinkMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLinkMain.ColumnHeadersHeight = 26;
            this.dgvLinkMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLinkMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLinkManId,
            this.colMainLinkMan,
            this.colName,
            this.colSex,
            this.colDepartment,
            this.colPostion,
            this.colTelephone,
            this.colMobilePhone,
            this.colOfficeFax,
            this.colEmail,
            this.colQQ,
            this.colBirthday,
            this.colMajor,
            this.colEducationalBackground,
            this.colInterest,
            this.colDescription});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLinkMain.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLinkMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLinkMain.EnableHeadersVisualStyles = false;
            this.dgvLinkMain.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvLinkMain.Location = new System.Drawing.Point(1, 26);
            this.dgvLinkMain.Name = "dgvLinkMain";
            this.dgvLinkMain.ReadOnly = true;
            this.dgvLinkMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinkMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLinkMain.RowHeadersWidth = 30;
            this.dgvLinkMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLinkMain.RowTemplate.Height = 23;
            this.dgvLinkMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinkMain.Size = new System.Drawing.Size(660, 223);
            this.dgvLinkMain.TabIndex = 1;
            // 
            // colLinkManId
            // 
            this.colLinkManId.DataPropertyName = "Id";
            this.colLinkManId.Frozen = true;
            this.colLinkManId.HeaderText = "Id";
            this.colLinkManId.Name = "colLinkManId";
            this.colLinkManId.ReadOnly = true;
            this.colLinkManId.Visible = false;
            this.colLinkManId.Width = 75;
            // 
            // colMainLinkMan
            // 
            this.colMainLinkMan.DataPropertyName = "MainLinkMan";
            this.colMainLinkMan.Frozen = true;
            this.colMainLinkMan.HeaderText = "主联系人";
            this.colMainLinkMan.Name = "colMainLinkMan";
            this.colMainLinkMan.ReadOnly = true;
            this.colMainLinkMan.Width = 70;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.Frozen = true;
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colSex
            // 
            this.colSex.DataPropertyName = "Sex";
            this.colSex.Frozen = true;
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 50;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "Department";
            this.colDepartment.Frozen = true;
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 120;
            // 
            // colPostion
            // 
            this.colPostion.DataPropertyName = "Postion";
            this.colPostion.Frozen = true;
            this.colPostion.HeaderText = "职位";
            this.colPostion.Name = "colPostion";
            this.colPostion.ReadOnly = true;
            this.colPostion.Width = 120;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.Frozen = true;
            this.colTelephone.HeaderText = "办公电话";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            this.colTelephone.Width = 120;
            // 
            // colMobilePhone
            // 
            this.colMobilePhone.DataPropertyName = "MobilePhone";
            this.colMobilePhone.Frozen = true;
            this.colMobilePhone.HeaderText = "手机";
            this.colMobilePhone.Name = "colMobilePhone";
            this.colMobilePhone.ReadOnly = true;
            this.colMobilePhone.Width = 120;
            // 
            // colOfficeFax
            // 
            this.colOfficeFax.DataPropertyName = "OfficeFax";
            this.colOfficeFax.HeaderText = "传真";
            this.colOfficeFax.Name = "colOfficeFax";
            this.colOfficeFax.ReadOnly = true;
            this.colOfficeFax.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "邮箱";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 130;
            // 
            // colQQ
            // 
            this.colQQ.DataPropertyName = "QQ";
            this.colQQ.HeaderText = "QQ";
            this.colQQ.Name = "colQQ";
            this.colQQ.ReadOnly = true;
            // 
            // colBirthday
            // 
            this.colBirthday.DataPropertyName = "Birthday";
            this.colBirthday.HeaderText = "生日";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.ReadOnly = true;
            // 
            // colMajor
            // 
            this.colMajor.DataPropertyName = "Major";
            this.colMajor.HeaderText = "专业";
            this.colMajor.Name = "colMajor";
            this.colMajor.ReadOnly = true;
            this.colMajor.Width = 120;
            // 
            // colEducationalBackground
            // 
            this.colEducationalBackground.DataPropertyName = "EducationalBackground";
            this.colEducationalBackground.HeaderText = "学历";
            this.colEducationalBackground.Name = "colEducationalBackground";
            this.colEducationalBackground.ReadOnly = true;
            // 
            // colInterest
            // 
            this.colInterest.DataPropertyName = "Interest";
            this.colInterest.HeaderText = "兴趣";
            this.colInterest.Name = "colInterest";
            this.colInterest.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "备注/描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddLinkMain,
            this.btnEditLinkMain,
            this.btnDeleteLinkMain,
            this.toolStripSeparator3,
            this.btnImportLinkMain,
            this.btnExportLinkMain,
            this.dropDownLinkManSaveAs});
            this.toolStrip2.Location = new System.Drawing.Point(1, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(660, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddLinkMain
            // 
            this.btnAddLinkMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddLinkMain.Image = global::CRM.Properties.Resources.addCustomer;
            this.btnAddLinkMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLinkMain.Name = "btnAddLinkMain";
            this.btnAddLinkMain.Size = new System.Drawing.Size(23, 22);
            this.btnAddLinkMain.Text = "添加联系人信息";
            this.btnAddLinkMain.Click += new System.EventHandler(this.btnAddLinkMain_Click);
            // 
            // btnEditLinkMain
            // 
            this.btnEditLinkMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditLinkMain.Image = global::CRM.Properties.Resources.editCustomer;
            this.btnEditLinkMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditLinkMain.Name = "btnEditLinkMain";
            this.btnEditLinkMain.Size = new System.Drawing.Size(23, 22);
            this.btnEditLinkMain.Text = "编辑选择的联系人";
            this.btnEditLinkMain.Click += new System.EventHandler(this.btnEditLinkMain_Click);
            // 
            // btnDeleteLinkMain
            // 
            this.btnDeleteLinkMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteLinkMain.Image = global::CRM.Properties.Resources.deleteCustomer;
            this.btnDeleteLinkMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteLinkMain.Name = "btnDeleteLinkMain";
            this.btnDeleteLinkMain.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteLinkMain.Text = "删除所选联系人";
            this.btnDeleteLinkMain.Click += new System.EventHandler(this.btnDeleteLinkMain_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImportLinkMain
            // 
            this.btnImportLinkMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportLinkMain.Image = ((System.Drawing.Image)(resources.GetObject("btnImportLinkMain.Image")));
            this.btnImportLinkMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportLinkMain.Name = "btnImportLinkMain";
            this.btnImportLinkMain.Size = new System.Drawing.Size(23, 22);
            this.btnImportLinkMain.Text = "导入联系人信息";
            this.btnImportLinkMain.Click += new System.EventHandler(this.btnImportLinkMain_Click);
            // 
            // btnExportLinkMain
            // 
            this.btnExportLinkMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportLinkMain.Image = ((System.Drawing.Image)(resources.GetObject("btnExportLinkMain.Image")));
            this.btnExportLinkMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportLinkMain.Name = "btnExportLinkMain";
            this.btnExportLinkMain.Size = new System.Drawing.Size(23, 22);
            this.btnExportLinkMain.Text = "导出联系人信息";
            this.btnExportLinkMain.Click += new System.EventHandler(this.btnExportLinkMain_Click);
            // 
            // dropDownLinkManSaveAs
            // 
            this.dropDownLinkManSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dropDownLinkManSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportLinkManToExcel,
            this.btnExportLinkManToTxt,
            this.btnExportLinkManToCSV,
            this.btnExportLinkManToHTML,
            this.btnExportLinkManToWordpad});
            this.dropDownLinkManSaveAs.Image = global::CRM.Properties.Resources.saveAs;
            this.dropDownLinkManSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropDownLinkManSaveAs.Name = "dropDownLinkManSaveAs";
            this.dropDownLinkManSaveAs.Size = new System.Drawing.Size(29, 22);
            this.dropDownLinkManSaveAs.Text = "另存为";
            // 
            // btnExportLinkManToExcel
            // 
            this.btnExportLinkManToExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportLinkManToExcel.Name = "btnExportLinkManToExcel";
            this.btnExportLinkManToExcel.Size = new System.Drawing.Size(238, 22);
            this.btnExportLinkManToExcel.Text = "Microsoft Excel工作薄[1]";
            this.btnExportLinkManToExcel.Click += new System.EventHandler(this.btnExportLinkManToExcel_Click);
            // 
            // btnExportLinkManToTxt
            // 
            this.btnExportLinkManToTxt.Name = "btnExportLinkManToTxt";
            this.btnExportLinkManToTxt.Size = new System.Drawing.Size(238, 22);
            this.btnExportLinkManToTxt.Text = "文本文件[2]";
            this.btnExportLinkManToTxt.Click += new System.EventHandler(this.btnExportLinkManToTxt_Click);
            // 
            // btnExportLinkManToCSV
            // 
            this.btnExportLinkManToCSV.Name = "btnExportLinkManToCSV";
            this.btnExportLinkManToCSV.Size = new System.Drawing.Size(238, 22);
            this.btnExportLinkManToCSV.Text = "CSV格式文件[3]";
            this.btnExportLinkManToCSV.Click += new System.EventHandler(this.btnExportLinkManToExcel_Click);
            // 
            // btnExportLinkManToHTML
            // 
            this.btnExportLinkManToHTML.Name = "btnExportLinkManToHTML";
            this.btnExportLinkManToHTML.Size = new System.Drawing.Size(238, 22);
            this.btnExportLinkManToHTML.Text = "网页文件[4]";
            // 
            // btnExportLinkManToWordpad
            // 
            this.btnExportLinkManToWordpad.Name = "btnExportLinkManToWordpad";
            this.btnExportLinkManToWordpad.Size = new System.Drawing.Size(238, 22);
            this.btnExportLinkManToWordpad.Text = "写字板文件[5]";
            // 
            // tabItemContactInfo
            // 
            this.tabItemContactInfo.AttachedControl = this.tabControlPanel2;
            this.tabItemContactInfo.Name = "tabItemContactInfo";
            this.tabItemContactInfo.Text = "联系人";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 3;
            this.tabControlPanel5.TabItem = this.tabItem5;
            // 
            // tabItem5
            // 
            this.tabItem5.AttachedControl = this.tabControlPanel5;
            this.tabItem5.Name = "tabItem5";
            this.tabItem5.Text = "跟进人员";
            // 
            // tabControlPanel10
            // 
            this.tabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel10.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel10.Name = "tabControlPanel10";
            this.tabControlPanel10.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel10.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel10.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel10.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel10.Style.GradientAngle = 90;
            this.tabControlPanel10.TabIndex = 8;
            this.tabControlPanel10.TabItem = this.tabItem8;
            // 
            // tabItem8
            // 
            this.tabItem8.AttachedControl = this.tabControlPanel10;
            this.tabItem8.Name = "tabItem8";
            this.tabItem8.Text = "所属图片";
            // 
            // tabControlPanel9
            // 
            this.tabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel9.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel9.Name = "tabControlPanel9";
            this.tabControlPanel9.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel9.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel9.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel9.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel9.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel9.Style.GradientAngle = 90;
            this.tabControlPanel9.TabIndex = 7;
            this.tabControlPanel9.TabItem = this.tabItem7;
            // 
            // tabItem7
            // 
            this.tabItem7.AttachedControl = this.tabControlPanel9;
            this.tabItem7.Name = "tabItem7";
            this.tabItem7.Text = "相关文档";
            // 
            // tabControlPanel8
            // 
            this.tabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel8.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel8.Name = "tabControlPanel8";
            this.tabControlPanel8.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel8.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel8.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel8.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel8.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel8.Style.GradientAngle = 90;
            this.tabControlPanel8.TabIndex = 6;
            this.tabControlPanel8.TabItem = this.tabItem6;
            // 
            // tabItem6
            // 
            this.tabItem6.AttachedControl = this.tabControlPanel8;
            this.tabItem6.Name = "tabItem6";
            this.tabItem6.Text = "服务反馈";
            // 
            // tabControlPanel7
            // 
            this.tabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel7.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel7.Name = "tabControlPanel7";
            this.tabControlPanel7.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel7.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel7.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel7.Style.GradientAngle = 90;
            this.tabControlPanel7.TabIndex = 5;
            this.tabControlPanel7.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel7;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "相关事务";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(662, 250);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 4;
            this.tabControlPanel6.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel6;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "联系记录";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 18);
            this.panel1.TabIndex = 0;
            // 
            // FrmCustomerAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 741);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.DoubleBuffered = true;
            this.Name = "FrmCustomerAdmin";
            this.Text = "我的客户";
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).EndInit();
            this.tabCustomerClass.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.cMnuCustomerClass.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.expandablePanel2.ResumeLayout(false);
            this.expandablePanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerLinkInfo)).EndInit();
            this.tabCustomerLinkInfo.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkMain)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.TabControl tabCustomerLinkInfo;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItemCustomerInfo;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemContactInfo;
        private System.Windows.Forms.ToolStripButton btnUpLevel;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tabCustomerClass;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.Controls.ListViewEx lvCustomerInfo;
        private System.Windows.Forms.TreeView tvCustomerClass;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cMnuCustomerClass;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSameLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuAddLowerLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteCurrent;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameClass;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuUp;
        private System.Windows.Forms.ToolStripMenuItem mnuDown;
        private RDIFramework.Controls.UcDataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWebAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyAddress;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Label lblLinkManNumber;
        private System.Windows.Forms.ImageList lvSizeImage;
        private RDIFramework.Controls.UcDataGridView dgvLinkMain;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddLinkMain;
        private System.Windows.Forms.ToolStripButton btnEditLinkMain;
        private System.Windows.Forms.ToolStripButton btnDeleteLinkMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnImportLinkMain;
        private System.Windows.Forms.ToolStripButton btnExportLinkMain;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItem5;
        private System.Windows.Forms.ToolStripDropDownButton dropDownLinkManSaveAs;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToExcel;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToTxt;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToCSV;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToHTML;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToWordpad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkManId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMainLinkMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobilePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfficeFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMajor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEducationalBackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private System.Windows.Forms.Panel panel2;
        private RDIFramework.Controls.UcTextBox txtCustomSearchValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCustomerAll;
        private System.Windows.Forms.RadioButton rbCustomerWebAddress;
        private System.Windows.Forms.RadioButton rbCustomerCompanyFax;
        private System.Windows.Forms.RadioButton rbCustomerPostalCode;
        private System.Windows.Forms.RadioButton rbCustomerCompanyAddress;
        private System.Windows.Forms.RadioButton rbCustomerCompanyPhone;
        private System.Windows.Forms.RadioButton rbCustomerCompanyName;
        private System.Windows.Forms.RadioButton rbCustomerShortName;
        private System.Windows.Forms.RadioButton rbCustomerDescription;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbCustomerLikeSearch;
        private System.Windows.Forms.RadioButton rbCustomerExactSearch;
        private RDIFramework.Controls.UcButton btnCustomerSearch;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel10;
        private DevComponents.DotNetBar.TabItem tabItem8;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel9;
        private DevComponents.DotNetBar.TabItem tabItem7;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel8;
        private DevComponents.DotNetBar.TabItem tabItem6;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel7;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private DevComponents.DotNetBar.TabItem tabItem1;
    }
}

