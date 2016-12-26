namespace RDIFramework.CodeMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mitemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemRecovery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemGotoLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemOutPut = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemTool = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemGenerateByDb = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemGenerateByPD = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemTypeMatch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemProjectProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemPBDesignerView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemStartPage = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemOnlineHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCut = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExecSql = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tscboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolComboBox_DB = new System.Windows.Forms.ToolStripComboBox();
            this.toolComboBox_Table = new System.Windows.Forms.ToolStripComboBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tslblSystemMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblPromptInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new Crownwood.Magic.Controls.TabControl();
            this.leftViewImgs = new System.Windows.Forms.ImageList(this.components);
            this.mnuMain.SuspendLayout();
            this.tsTool.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemFile,
            this.mitemEdit,
            this.mitemOutPut,
            this.mitemTool,
            this.mitemWindow,
            this.mitemHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(747, 25);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mitemFile
            // 
            this.mitemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemNew,
            this.mitemOpen,
            this.toolStripMenuItem1,
            this.mitemSaveAs,
            this.toolStripMenuItem2,
            this.mitemExit});
            this.mitemFile.Name = "mitemFile";
            this.mitemFile.Size = new System.Drawing.Size(74, 21);
            this.mitemFile.Text = "文件（&F）";
            this.mitemFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mitemFile_DropDownItemClicked);
            // 
            // mitemNew
            // 
            this.mitemNew.Image = ((System.Drawing.Image)(resources.GetObject("mitemNew.Image")));
            this.mitemNew.Name = "mitemNew";
            this.mitemNew.Size = new System.Drawing.Size(153, 22);
            this.mitemNew.Text = "新建";
            // 
            // mitemOpen
            // 
            this.mitemOpen.Image = global::RDIFramework.CodeMaker.Properties.Resources.folderopen;
            this.mitemOpen.Name = "mitemOpen";
            this.mitemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.mitemOpen.Size = new System.Drawing.Size(153, 22);
            this.mitemOpen.Text = "打开...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // mitemSaveAs
            // 
            this.mitemSaveAs.Image = global::RDIFramework.CodeMaker.Properties.Resources.saveas;
            this.mitemSaveAs.Name = "mitemSaveAs";
            this.mitemSaveAs.Size = new System.Drawing.Size(153, 22);
            this.mitemSaveAs.Text = "另存为...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // mitemExit
            // 
            this.mitemExit.Image = ((System.Drawing.Image)(resources.GetObject("mitemExit.Image")));
            this.mitemExit.Name = "mitemExit";
            this.mitemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mitemExit.Size = new System.Drawing.Size(153, 22);
            this.mitemExit.Text = "退出";
            // 
            // mitemEdit
            // 
            this.mitemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemRecovery,
            this.toolStripMenuItem3,
            this.mitemCut,
            this.mitemCopy,
            this.mitemPaste,
            this.mitemDelete,
            this.toolStripMenuItem4,
            this.mitemSelectAll,
            this.toolStripMenuItem5,
            this.mitemFind,
            this.mitemFindNext,
            this.mitemReplace,
            this.mitemGotoLine});
            this.mitemEdit.Name = "mitemEdit";
            this.mitemEdit.Size = new System.Drawing.Size(75, 21);
            this.mitemEdit.Text = "编辑（&E）";
            this.mitemEdit.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mitemEdit_DropDownItemClicked);
            // 
            // mitemRecovery
            // 
            this.mitemRecovery.Image = global::RDIFramework.CodeMaker.Properties.Resources.cancel;
            this.mitemRecovery.Name = "mitemRecovery";
            this.mitemRecovery.Size = new System.Drawing.Size(136, 22);
            this.mitemRecovery.Text = "恢复（&Z）";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
            // 
            // mitemCut
            // 
            this.mitemCut.Image = global::RDIFramework.CodeMaker.Properties.Resources.cut;
            this.mitemCut.Name = "mitemCut";
            this.mitemCut.Size = new System.Drawing.Size(136, 22);
            this.mitemCut.Text = "剪切(&X)";
            // 
            // mitemCopy
            // 
            this.mitemCopy.Image = global::RDIFramework.CodeMaker.Properties.Resources.copy;
            this.mitemCopy.Name = "mitemCopy";
            this.mitemCopy.Size = new System.Drawing.Size(136, 22);
            this.mitemCopy.Text = "复制(&C)";
            // 
            // mitemPaste
            // 
            this.mitemPaste.Image = global::RDIFramework.CodeMaker.Properties.Resources.paste;
            this.mitemPaste.Name = "mitemPaste";
            this.mitemPaste.Size = new System.Drawing.Size(136, 22);
            this.mitemPaste.Text = "粘贴(&V)";
            // 
            // mitemDelete
            // 
            this.mitemDelete.Name = "mitemDelete";
            this.mitemDelete.Size = new System.Drawing.Size(136, 22);
            this.mitemDelete.Text = "删除（&D）";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(133, 6);
            // 
            // mitemSelectAll
            // 
            this.mitemSelectAll.Name = "mitemSelectAll";
            this.mitemSelectAll.Size = new System.Drawing.Size(136, 22);
            this.mitemSelectAll.Text = "全选(&A)";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(133, 6);
            // 
            // mitemFind
            // 
            this.mitemFind.Name = "mitemFind";
            this.mitemFind.Size = new System.Drawing.Size(136, 22);
            this.mitemFind.Text = "查找...";
            // 
            // mitemFindNext
            // 
            this.mitemFindNext.Name = "mitemFindNext";
            this.mitemFindNext.Size = new System.Drawing.Size(136, 22);
            this.mitemFindNext.Text = "查找下一个";
            // 
            // mitemReplace
            // 
            this.mitemReplace.Name = "mitemReplace";
            this.mitemReplace.Size = new System.Drawing.Size(136, 22);
            this.mitemReplace.Text = "替换";
            // 
            // mitemGotoLine
            // 
            this.mitemGotoLine.Name = "mitemGotoLine";
            this.mitemGotoLine.Size = new System.Drawing.Size(136, 22);
            this.mitemGotoLine.Text = "转到行...";
            // 
            // mitemOutPut
            // 
            this.mitemOutPut.Name = "mitemOutPut";
            this.mitemOutPut.Size = new System.Drawing.Size(78, 21);
            this.mitemOutPut.Text = "输出（&O）";
            // 
            // mitemTool
            // 
            this.mitemTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemGenerateByDb,
            this.mitemGenerateByPD,
            this.toolStripMenuItem6,
            this.mitemTypeMatch,
            this.toolStripMenuItem7,
            this.mitemProjectProperty});
            this.mitemTool.Name = "mitemTool";
            this.mitemTool.Size = new System.Drawing.Size(75, 21);
            this.mitemTool.Text = "工具（&T）";
            this.mitemTool.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mitemTool_DropDownItemClicked);
            // 
            // mitemGenerateByDb
            // 
            this.mitemGenerateByDb.Image = global::RDIFramework.CodeMaker.Properties.Resources.db;
            this.mitemGenerateByDb.Name = "mitemGenerateByDb";
            this.mitemGenerateByDb.Size = new System.Drawing.Size(160, 22);
            this.mitemGenerateByDb.Text = "从数据库生成";
            // 
            // mitemGenerateByPD
            // 
            this.mitemGenerateByPD.Name = "mitemGenerateByPD";
            this.mitemGenerateByPD.Size = new System.Drawing.Size(160, 22);
            this.mitemGenerateByPD.Text = "从设计文档生成";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(157, 6);
            // 
            // mitemTypeMatch
            // 
            this.mitemTypeMatch.Name = "mitemTypeMatch";
            this.mitemTypeMatch.Size = new System.Drawing.Size(160, 22);
            this.mitemTypeMatch.Text = "类型匹配";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(157, 6);
            // 
            // mitemProjectProperty
            // 
            this.mitemProjectProperty.Image = global::RDIFramework.CodeMaker.Properties.Resources.propery;
            this.mitemProjectProperty.Name = "mitemProjectProperty";
            this.mitemProjectProperty.Size = new System.Drawing.Size(160, 22);
            this.mitemProjectProperty.Text = "项目属性设置";
            // 
            // mitemWindow
            // 
            this.mitemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemDBView,
            this.mitemPBDesignerView,
            this.toolStripMenuItem8,
            this.mitemStartPage});
            this.mitemWindow.Name = "mitemWindow";
            this.mitemWindow.Size = new System.Drawing.Size(76, 21);
            this.mitemWindow.Text = "视图（&V）";
            this.mitemWindow.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mitemWindow_DropDownItemClicked);
            // 
            // mitemDBView
            // 
            this.mitemDBView.Checked = true;
            this.mitemDBView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mitemDBView.Image = global::RDIFramework.CodeMaker.Properties.Resources.db;
            this.mitemDBView.Name = "mitemDBView";
            this.mitemDBView.Size = new System.Drawing.Size(163, 22);
            this.mitemDBView.Text = "数据库视图";
            // 
            // mitemPBDesignerView
            // 
            this.mitemPBDesignerView.Checked = true;
            this.mitemPBDesignerView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mitemPBDesignerView.Image = global::RDIFramework.CodeMaker.Properties.Resources.pd;
            this.mitemPBDesignerView.Name = "mitemPBDesignerView";
            this.mitemPBDesignerView.Size = new System.Drawing.Size(163, 22);
            this.mitemPBDesignerView.Text = "PB设计文档视图";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(160, 6);
            // 
            // mitemStartPage
            // 
            this.mitemStartPage.BackColor = System.Drawing.SystemColors.Info;
            this.mitemStartPage.Image = global::RDIFramework.CodeMaker.Properties.Resources.startPage;
            this.mitemStartPage.Name = "mitemStartPage";
            this.mitemStartPage.Size = new System.Drawing.Size(163, 22);
            this.mitemStartPage.Text = "起始页";
            // 
            // mitemHelp
            // 
            this.mitemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemOnlineHelp,
            this.mitemAbout});
            this.mitemHelp.Name = "mitemHelp";
            this.mitemHelp.Size = new System.Drawing.Size(77, 21);
            this.mitemHelp.Text = "帮助（&H）";
            this.mitemHelp.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mitemHelp_DropDownItemClicked);
            // 
            // mitemOnlineHelp
            // 
            this.mitemOnlineHelp.Image = global::RDIFramework.CodeMaker.Properties.Resources.help;
            this.mitemOnlineHelp.Name = "mitemOnlineHelp";
            this.mitemOnlineHelp.Size = new System.Drawing.Size(152, 22);
            this.mitemOnlineHelp.Text = "在线帮助";
            // 
            // mitemAbout
            // 
            this.mitemAbout.Name = "mitemAbout";
            this.mitemAbout.Size = new System.Drawing.Size(152, 22);
            this.mitemAbout.Text = "关于本软件...";
            // 
            // tsTool
            // 
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnOpen,
            this.tsbtnSave,
            this.toolStripSeparator1,
            this.tsbtnCut,
            this.tsbtnCopy,
            this.tsbtnPaste,
            this.toolStripSeparator2,
            this.tsbtnExecSql,
            this.tsbtnZoomIn,
            this.tsbtnZoomOut,
            this.tscboFontSize,
            this.toolStripSeparator3,
            this.tsbtnExit,
            this.toolStripSeparator4,
            this.toolComboBox_DB,
            this.toolComboBox_Table});
            this.tsTool.Location = new System.Drawing.Point(0, 25);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(747, 25);
            this.tsTool.TabIndex = 1;
            this.tsTool.Text = "toolStrip1";
            this.tsTool.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsTool_ItemClicked);
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNew.Text = "新建";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpen.Text = "打开";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::RDIFramework.CodeMaker.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnCut
            // 
            this.tsbtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCut.Image = global::RDIFramework.CodeMaker.Properties.Resources.cut;
            this.tsbtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCut.Name = "tsbtnCut";
            this.tsbtnCut.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCut.Text = "剪切";
            // 
            // tsbtnCopy
            // 
            this.tsbtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCopy.Image = global::RDIFramework.CodeMaker.Properties.Resources.copy;
            this.tsbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCopy.Name = "tsbtnCopy";
            this.tsbtnCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCopy.Text = "复制";
            // 
            // tsbtnPaste
            // 
            this.tsbtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPaste.Image = global::RDIFramework.CodeMaker.Properties.Resources.paste;
            this.tsbtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPaste.Name = "tsbtnPaste";
            this.tsbtnPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPaste.Text = "粘贴";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnExecSql
            // 
            this.tsbtnExecSql.Image = global::RDIFramework.CodeMaker.Properties.Resources.exclamation;
            this.tsbtnExecSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExecSql.Name = "tsbtnExecSql";
            this.tsbtnExecSql.Size = new System.Drawing.Size(83, 22);
            this.tsbtnExecSql.Text = " 执行SQL ";
            this.tsbtnExecSql.Visible = false;
            // 
            // tsbtnZoomIn
            // 
            this.tsbtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnZoomIn.Image = global::RDIFramework.CodeMaker.Properties.Resources.zoomin;
            this.tsbtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomIn.Name = "tsbtnZoomIn";
            this.tsbtnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsbtnZoomIn.Text = "放大";
            // 
            // tsbtnZoomOut
            // 
            this.tsbtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnZoomOut.Image = global::RDIFramework.CodeMaker.Properties.Resources.zoomout;
            this.tsbtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomOut.Name = "tsbtnZoomOut";
            this.tsbtnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsbtnZoomOut.Text = "缩小";
            // 
            // tscboFontSize
            // 
            this.tscboFontSize.Items.AddRange(new object[] {
            "5",
            "5.5",
            "6.5",
            "7.5",
            "8",
            "9",
            "10",
            "10.5",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.tscboFontSize.Name = "tscboFontSize";
            this.tscboFontSize.Size = new System.Drawing.Size(80, 25);
            this.tscboFontSize.SelectedIndexChanged += new System.EventHandler(this.tscboFontSize_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(23, 22);
            this.tsbtnExit.Text = "退出系统";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolComboBox_DB
            // 
            this.toolComboBox_DB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolComboBox_DB.Name = "toolComboBox_DB";
            this.toolComboBox_DB.Size = new System.Drawing.Size(121, 25);
            this.toolComboBox_DB.Visible = false;
            // 
            // toolComboBox_Table
            // 
            this.toolComboBox_Table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolComboBox_Table.Name = "toolComboBox_Table";
            this.toolComboBox_Table.Size = new System.Drawing.Size(160, 25);
            this.toolComboBox_Table.Visible = false;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblSystemMessage,
            this.tslblPromptInfo,
            this.tslblCopyright});
            this.statusBar.Location = new System.Drawing.Point(0, 429);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(747, 26);
            this.statusBar.TabIndex = 2;
            // 
            // tslblSystemMessage
            // 
            this.tslblSystemMessage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslblSystemMessage.Image = global::RDIFramework.CodeMaker.Properties.Resources.msg;
            this.tslblSystemMessage.Name = "tslblSystemMessage";
            this.tslblSystemMessage.Size = new System.Drawing.Size(76, 21);
            this.tslblSystemMessage.Text = "系统消息";
            // 
            // tslblPromptInfo
            // 
            this.tslblPromptInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslblPromptInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslblPromptInfo.LinkVisited = true;
            this.tslblPromptInfo.Name = "tslblPromptInfo";
            this.tslblPromptInfo.Size = new System.Drawing.Size(455, 21);
            this.tslblPromptInfo.Spring = true;
            this.tslblPromptInfo.Text = "准备就绪...";
            this.tslblPromptInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tslblCopyright
            // 
            this.tslblCopyright.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tslblCopyright.ForeColor = System.Drawing.Color.Blue;
            this.tslblCopyright.IsLink = true;
            this.tslblCopyright.Name = "tslblCopyright";
            this.tslblCopyright.Size = new System.Drawing.Size(201, 21);
            this.tslblCopyright.Text = "http://www.rdiframework.net/";
            this.tslblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tslblCopyright.Click += new System.EventHandler(this.tslblCopyright_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControlMain.Location = new System.Drawing.Point(0, 50);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.PositionTop = true;
            this.tabControlMain.ShowArrows = true;
            this.tabControlMain.ShowClose = true;
            this.tabControlMain.Size = new System.Drawing.Size(747, 379);
            this.tabControlMain.TabIndex = 3;
            // 
            // leftViewImgs
            // 
            this.leftViewImgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("leftViewImgs.ImageStream")));
            this.leftViewImgs.TransparentColor = System.Drawing.Color.Transparent;
            this.leftViewImgs.Images.SetKeyName(0, "serverlist.gif");
            this.leftViewImgs.Images.SetKeyName(1, "temp.ico");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 455);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tsTool);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDIFramework.NET 平台代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mitemFile;
        private System.Windows.Forms.ToolStripMenuItem mitemEdit;
        private System.Windows.Forms.ToolStripMenuItem mitemOutPut;
        private System.Windows.Forms.ToolStripMenuItem mitemTool;
        private System.Windows.Forms.ToolStripMenuItem mitemWindow;
        private System.Windows.Forms.ToolStripMenuItem mitemHelp;
        private System.Windows.Forms.ToolStripMenuItem mitemNew;
        private System.Windows.Forms.ToolStripMenuItem mitemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mitemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mitemExit;
        private System.Windows.Forms.ToolStripMenuItem mitemRecovery;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mitemCut;
        private System.Windows.Forms.ToolStripMenuItem mitemCopy;
        private System.Windows.Forms.ToolStripMenuItem mitemPaste;
        private System.Windows.Forms.ToolStripMenuItem mitemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mitemSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mitemFind;
        private System.Windows.Forms.ToolStripMenuItem mitemFindNext;
        private System.Windows.Forms.ToolStripMenuItem mitemReplace;
        private System.Windows.Forms.ToolStripMenuItem mitemGotoLine;
        private System.Windows.Forms.ToolStripMenuItem mitemGenerateByDb;
        private System.Windows.Forms.ToolStripMenuItem mitemGenerateByPD;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mitemTypeMatch;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mitemProjectProperty;
        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripButton tsbtnCut;
        private System.Windows.Forms.ToolStripButton tsbtnCopy;
        private System.Windows.Forms.ToolStripButton tsbtnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnZoomIn;
        private System.Windows.Forms.ToolStripButton tsbtnZoomOut;
        private System.Windows.Forms.ToolStripComboBox tscboFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        public Crownwood.Magic.Controls.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripStatusLabel tslblSystemMessage;
        private System.Windows.Forms.ToolStripStatusLabel tslblCopyright;
        private System.Windows.Forms.ImageList leftViewImgs;
        public System.Windows.Forms.ToolStripStatusLabel tslblPromptInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripComboBox toolComboBox_DB;
        public System.Windows.Forms.ToolStripComboBox toolComboBox_Table;
        private System.Windows.Forms.ToolStripMenuItem mitemAbout;
        public System.Windows.Forms.ToolStripButton tsbtnExecSql;
        private System.Windows.Forms.ToolStripMenuItem mitemOnlineHelp;
        private System.Windows.Forms.ToolStripMenuItem mitemDBView;
        private System.Windows.Forms.ToolStripMenuItem mitemPBDesignerView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mitemStartPage;
    }
}

