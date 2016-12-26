namespace RDIFramework.WorkFlow
{
    partial class FrmUserControlAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserControlAdmin));
            this.cmUserControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewUctoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyUcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmenuOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmMainUserControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newmucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifymucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delmucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvcmUserControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvnewUctoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvModifyUctoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvDelUctoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvcmMainUserControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvNewMuctoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvModifyMuctoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lvDelMuctoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnOper = new System.Windows.Forms.ToolStripButton();
            this.tbtnLook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnVisable = new System.Windows.Forms.ToolStripButton();
            this.tbtnRefrush = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnLargeIcon = new System.Windows.Forms.ToolStripButton();
            this.tbtnSmallIcon = new System.Windows.Forms.ToolStripButton();
            this.tbtnListIcon = new System.Windows.Forms.ToolStripButton();
            this.tbtnDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAttribute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnExit = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvUserControl = new System.Windows.Forms.TreeView();
            this.tabItemUserControlList = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvClient = new System.Windows.Forms.ListView();
            this.cmUserControl.SuspendLayout();
            this.cmenuOperation.SuspendLayout();
            this.cmMainUserControl.SuspendLayout();
            this.lvcmUserControl.SuspendLayout();
            this.lvcmMainUserControl.SuspendLayout();
            this.cmenuView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmUserControl
            // 
            this.cmUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewUctoolStripMenuItem2,
            this.ModifyUcToolStripMenuItem,
            this.delucToolStripMenuItem});
            this.cmUserControl.Name = "contextMenuStrip1";
            this.cmUserControl.Size = new System.Drawing.Size(131, 70);
            // 
            // NewUctoolStripMenuItem2
            // 
            this.NewUctoolStripMenuItem2.Name = "NewUctoolStripMenuItem2";
            this.NewUctoolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.NewUctoolStripMenuItem2.Text = "新建子表单";
            this.NewUctoolStripMenuItem2.Click += new System.EventHandler(this.NewUctoolStripMenuItem2_Click);
            // 
            // ModifyUcToolStripMenuItem
            // 
            this.ModifyUcToolStripMenuItem.Name = "ModifyUcToolStripMenuItem";
            this.ModifyUcToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ModifyUcToolStripMenuItem.Text = "修改子表单";
            this.ModifyUcToolStripMenuItem.Click += new System.EventHandler(this.ModifyUcToolStripMenuItem_Click);
            // 
            // delucToolStripMenuItem
            // 
            this.delucToolStripMenuItem.Name = "delucToolStripMenuItem";
            this.delucToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.delucToolStripMenuItem.Text = "删除子表单";
            this.delucToolStripMenuItem.Click += new System.EventHandler(this.delucToolStripMenuItem_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "表单.bmp");
            this.imgList.Images.SetKeyName(1, "03972.ico");
            this.imgList.Images.SetKeyName(2, "00586.ico");
            this.imgList.Images.SetKeyName(3, "sel表单.bmp");
            // 
            // cmenuOperation
            // 
            this.cmenuOperation.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmenuOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.cmenuOperation.Name = "cmenuOperation";
            this.cmenuOperation.Size = new System.Drawing.Size(113, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.tbtnExit_Click);
            // 
            // cmMainUserControl
            // 
            this.cmMainUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newmucToolStripMenuItem,
            this.modifymucToolStripMenuItem,
            this.delmucToolStripMenuItem});
            this.cmMainUserControl.Name = "contextMenuStrip1";
            this.cmMainUserControl.Size = new System.Drawing.Size(131, 70);
            // 
            // newmucToolStripMenuItem
            // 
            this.newmucToolStripMenuItem.Name = "newmucToolStripMenuItem";
            this.newmucToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.newmucToolStripMenuItem.Text = "新建主表单";
            this.newmucToolStripMenuItem.Click += new System.EventHandler(this.newmucToolStripMenuItem_Click);
            // 
            // modifymucToolStripMenuItem
            // 
            this.modifymucToolStripMenuItem.Name = "modifymucToolStripMenuItem";
            this.modifymucToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.modifymucToolStripMenuItem.Text = "修改主表单";
            this.modifymucToolStripMenuItem.Click += new System.EventHandler(this.modifymucToolStripMenuItem_Click);
            // 
            // delmucToolStripMenuItem
            // 
            this.delmucToolStripMenuItem.Name = "delmucToolStripMenuItem";
            this.delmucToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.delmucToolStripMenuItem.Text = "删除主表单";
            this.delmucToolStripMenuItem.Click += new System.EventHandler(this.delmucToolStripMenuItem_Click);
            // 
            // lvcmUserControl
            // 
            this.lvcmUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvnewUctoolStripMenuItem1,
            this.lvModifyUctoolStripMenuItem2,
            this.lvDelUctoolStripMenuItem3});
            this.lvcmUserControl.Name = "contextMenuStrip1";
            this.lvcmUserControl.Size = new System.Drawing.Size(131, 70);
            // 
            // lvnewUctoolStripMenuItem1
            // 
            this.lvnewUctoolStripMenuItem1.Name = "lvnewUctoolStripMenuItem1";
            this.lvnewUctoolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.lvnewUctoolStripMenuItem1.Text = "新建子表单";
            this.lvnewUctoolStripMenuItem1.Click += new System.EventHandler(this.lvnewUctoolStripMenuItem1_Click);
            // 
            // lvModifyUctoolStripMenuItem2
            // 
            this.lvModifyUctoolStripMenuItem2.Name = "lvModifyUctoolStripMenuItem2";
            this.lvModifyUctoolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.lvModifyUctoolStripMenuItem2.Text = "修改子表单";
            this.lvModifyUctoolStripMenuItem2.Click += new System.EventHandler(this.lvModifyUctoolStripMenuItem2_Click);
            // 
            // lvDelUctoolStripMenuItem3
            // 
            this.lvDelUctoolStripMenuItem3.Name = "lvDelUctoolStripMenuItem3";
            this.lvDelUctoolStripMenuItem3.Size = new System.Drawing.Size(130, 22);
            this.lvDelUctoolStripMenuItem3.Text = "删除子表单";
            this.lvDelUctoolStripMenuItem3.Click += new System.EventHandler(this.lvDelUctoolStripMenuItem3_Click);
            // 
            // lvcmMainUserControl
            // 
            this.lvcmMainUserControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvNewMuctoolStripMenuItem1,
            this.lvModifyMuctoolStripMenuItem2,
            this.lvDelMuctoolStripMenuItem3});
            this.lvcmMainUserControl.Name = "contextMenuStrip1";
            this.lvcmMainUserControl.Size = new System.Drawing.Size(131, 70);
            // 
            // lvNewMuctoolStripMenuItem1
            // 
            this.lvNewMuctoolStripMenuItem1.Name = "lvNewMuctoolStripMenuItem1";
            this.lvNewMuctoolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.lvNewMuctoolStripMenuItem1.Text = "新建主表单";
            this.lvNewMuctoolStripMenuItem1.Click += new System.EventHandler(this.lvNewMuctoolStripMenuItem1_Click);
            // 
            // lvModifyMuctoolStripMenuItem2
            // 
            this.lvModifyMuctoolStripMenuItem2.Name = "lvModifyMuctoolStripMenuItem2";
            this.lvModifyMuctoolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
            this.lvModifyMuctoolStripMenuItem2.Text = "修改主表单";
            this.lvModifyMuctoolStripMenuItem2.Click += new System.EventHandler(this.lvModifyMuctoolStripMenuItem2_Click);
            // 
            // lvDelMuctoolStripMenuItem3
            // 
            this.lvDelMuctoolStripMenuItem3.Name = "lvDelMuctoolStripMenuItem3";
            this.lvDelMuctoolStripMenuItem3.Size = new System.Drawing.Size(130, 22);
            this.lvDelMuctoolStripMenuItem3.Text = "删除主表单";
            this.lvDelMuctoolStripMenuItem3.Click += new System.EventHandler(this.lvDelMuctoolStripMenuItem3_Click);
            // 
            // cmenuView
            // 
            this.cmenuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeToolStripMenuItem,
            this.smallToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.cmenuView.Name = "cmenuView";
            this.cmenuView.Size = new System.Drawing.Size(137, 92);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.largeToolStripMenuItem.Text = "大图标(&G)";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.smallToolStripMenuItem.Text = "小图标(&M)";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.listToolStripMenuItem.Text = "列表(&L)";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.detailsToolStripMenuItem.Text = "详细信息(&D)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnOper,
            this.tbtnLook,
            this.toolStripSeparator1,
            this.tbtnAdd,
            this.tbtnDelete,
            this.toolStripSeparator2,
            this.tbtnVisable,
            this.tbtnRefrush,
            this.toolStripSeparator3,
            this.tbtnLargeIcon,
            this.tbtnSmallIcon,
            this.tbtnListIcon,
            this.tbtnDetails,
            this.toolStripSeparator4,
            this.tbtnAttribute,
            this.toolStripSeparator5,
            this.tbtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(863, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnOper
            // 
            this.tbtnOper.Image = ((System.Drawing.Image)(resources.GetObject("tbtnOper.Image")));
            this.tbtnOper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOper.Name = "tbtnOper";
            this.tbtnOper.Size = new System.Drawing.Size(76, 22);
            this.tbtnOper.Text = "操作(&A)";
            this.tbtnOper.Click += new System.EventHandler(this.tbtnOper_Click);
            // 
            // tbtnLook
            // 
            this.tbtnLook.Image = ((System.Drawing.Image)(resources.GetObject("tbtnLook.Image")));
            this.tbtnLook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnLook.Name = "tbtnLook";
            this.tbtnLook.Size = new System.Drawing.Size(76, 22);
            this.tbtnLook.Text = "查看(&V)";
            this.tbtnLook.Click += new System.EventHandler(this.tbtnLook_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnAdd
            // 
            this.tbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAdd.Image")));
            this.tbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAdd.Name = "tbtnAdd";
            this.tbtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tbtnAdd.Text = "添加";
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDelete.Image")));
            this.tbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tbtnDelete.Text = "删除";
            this.tbtnDelete.Click += new System.EventHandler(this.tbtnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnVisable
            // 
            this.tbtnVisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnVisable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnVisable.Image")));
            this.tbtnVisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnVisable.Name = "tbtnVisable";
            this.tbtnVisable.Size = new System.Drawing.Size(23, 22);
            this.tbtnVisable.Text = "显示/关闭";
            this.tbtnVisable.Click += new System.EventHandler(this.tbtnVisable_Click);
            // 
            // tbtnRefrush
            // 
            this.tbtnRefrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRefrush.Image = ((System.Drawing.Image)(resources.GetObject("tbtnRefrush.Image")));
            this.tbtnRefrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnRefrush.Name = "tbtnRefrush";
            this.tbtnRefrush.Size = new System.Drawing.Size(23, 22);
            this.tbtnRefrush.Text = "刷新";
            this.tbtnRefrush.Click += new System.EventHandler(this.tbtnRefrush_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnLargeIcon
            // 
            this.tbtnLargeIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnLargeIcon.Image = ((System.Drawing.Image)(resources.GetObject("tbtnLargeIcon.Image")));
            this.tbtnLargeIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnLargeIcon.Name = "tbtnLargeIcon";
            this.tbtnLargeIcon.Size = new System.Drawing.Size(23, 22);
            this.tbtnLargeIcon.Text = "大图标";
            this.tbtnLargeIcon.Click += new System.EventHandler(this.tbtnLargeIcon_Click);
            // 
            // tbtnSmallIcon
            // 
            this.tbtnSmallIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSmallIcon.Image = ((System.Drawing.Image)(resources.GetObject("tbtnSmallIcon.Image")));
            this.tbtnSmallIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSmallIcon.Name = "tbtnSmallIcon";
            this.tbtnSmallIcon.Size = new System.Drawing.Size(23, 22);
            this.tbtnSmallIcon.Text = "小图标";
            this.tbtnSmallIcon.Click += new System.EventHandler(this.tbtnSmallIcon_Click);
            // 
            // tbtnListIcon
            // 
            this.tbtnListIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnListIcon.Image = ((System.Drawing.Image)(resources.GetObject("tbtnListIcon.Image")));
            this.tbtnListIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnListIcon.Name = "tbtnListIcon";
            this.tbtnListIcon.Size = new System.Drawing.Size(23, 22);
            this.tbtnListIcon.Text = "列表";
            this.tbtnListIcon.Click += new System.EventHandler(this.tbtnListIcon_Click);
            // 
            // tbtnDetails
            // 
            this.tbtnDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDetails.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDetails.Image")));
            this.tbtnDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDetails.Name = "tbtnDetails";
            this.tbtnDetails.Size = new System.Drawing.Size(23, 22);
            this.tbtnDetails.Text = "详细信息";
            this.tbtnDetails.Click += new System.EventHandler(this.tbtnDetails_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnAttribute
            // 
            this.tbtnAttribute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAttribute.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAttribute.Image")));
            this.tbtnAttribute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAttribute.Name = "tbtnAttribute";
            this.tbtnAttribute.Size = new System.Drawing.Size(23, 22);
            this.tbtnAttribute.Text = "属性";
            this.tbtnAttribute.Click += new System.EventHandler(this.tbtnAttribute_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnExit
            // 
            this.tbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tbtnExit.Image")));
            this.tbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnExit.Name = "tbtnExit";
            this.tbtnExit.Size = new System.Drawing.Size(23, 22);
            this.tbtnExit.Text = "关闭";
            this.tbtnExit.Click += new System.EventHandler(this.tbtnExit_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(288, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 511);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcUser.Location = new System.Drawing.Point(0, 25);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(288, 511);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 23;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemUserControlList);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.tvUserControl);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(288, 484);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemUserControlList;
            // 
            // tvUserControl
            // 
            this.tvUserControl.ContextMenuStrip = this.cmUserControl;
            this.tvUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUserControl.ImageIndex = 2;
            this.tvUserControl.ImageList = this.imgList;
            this.tvUserControl.Location = new System.Drawing.Point(1, 1);
            this.tvUserControl.Name = "tvUserControl";
            this.tvUserControl.SelectedImageIndex = 2;
            this.tvUserControl.Size = new System.Drawing.Size(286, 482);
            this.tvUserControl.TabIndex = 1;
            this.tvUserControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUserControl_AfterSelect);
            // 
            // tabItemUserControlList
            // 
            this.tabItemUserControlList.AttachedControl = this.tabControlPanel2;
            this.tabItemUserControlList.Name = "tabItemUserControlList";
            this.tabItemUserControlList.Text = "表单列表树";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvClient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(291, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 511);
            this.panel1.TabIndex = 24;
            // 
            // lvClient
            // 
            this.lvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClient.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvClient.LargeImageList = this.imgList;
            this.lvClient.Location = new System.Drawing.Point(0, 0);
            this.lvClient.MultiSelect = false;
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(572, 511);
            this.lvClient.SmallImageList = this.imgList;
            this.lvClient.StateImageList = this.imgList;
            this.lvClient.TabIndex = 1;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvClient_DrawColumnHeader);
            this.lvClient.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvClient_DrawSubItem);
            this.lvClient.SelectedIndexChanged += new System.EventHandler(this.lvClient_SelectedIndexChanged);
            // 
            // FrmUserControlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 536);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tcUser);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmUserControlAdmin";
            this.Text = "用户表单(控件)维护";
            this.cmUserControl.ResumeLayout(false);
            this.cmenuOperation.ResumeLayout(false);
            this.cmMainUserControl.ResumeLayout(false);
            this.lvcmUserControl.ResumeLayout(false);
            this.lvcmMainUserControl.ResumeLayout(false);
            this.cmenuView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmUserControl;
        private System.Windows.Forms.ToolStripMenuItem NewUctoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ModifyUcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delucToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmenuOperation;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmMainUserControl;
        private System.Windows.Forms.ToolStripMenuItem newmucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifymucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delmucToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip lvcmUserControl;
        private System.Windows.Forms.ToolStripMenuItem lvnewUctoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lvModifyUctoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lvDelUctoolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip lvcmMainUserControl;
        private System.Windows.Forms.ToolStripMenuItem lvNewMuctoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lvModifyMuctoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lvDelMuctoolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip cmenuView;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnOper;
        private System.Windows.Forms.ToolStripButton tbtnLook;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnAdd;
        private System.Windows.Forms.ToolStripButton tbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnVisable;
        private System.Windows.Forms.ToolStripButton tbtnRefrush;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbtnLargeIcon;
        private System.Windows.Forms.ToolStripButton tbtnSmallIcon;
        private System.Windows.Forms.ToolStripButton tbtnListIcon;
        private System.Windows.Forms.ToolStripButton tbtnDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbtnAttribute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbtnExit;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemUserControlList;
        private System.Windows.Forms.TreeView tvUserControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvClient;
    }
}