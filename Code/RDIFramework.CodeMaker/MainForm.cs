using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TextEditor.Editor;
using TabPage = Crownwood.Magic.Controls.TabPage;

namespace RDIFramework.CodeMaker
{
    using Crownwood.Magic.Common;
    using Crownwood.Magic.Docking;

    public partial class MainForm : Form
    {
        public Mutex mutex;
        string cmcfgfile = Application.StartupPath + @"\Config\cmcfg.ini";
        IniFileHelper cfgfile;
        delegate void SetStatusEventHandler(string text);
        delegate void AddNewTabPageEventHandler(Control control, string Title);

        #region 定义Docking Manager对象

        private DockingManager dockManager;
        Content DBViewContent;
        Content DesignObjectContent;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            mutex = new Mutex(false, "SINGLE_RDIFramework.CodeMaker");
            if (!mutex.WaitOne(0, false))
            {
                mutex.Close();
                mutex = null;
            }

            Version ApplicationVersion = new Version(Application.ProductVersion);
            this.Text = "RDIFramework.NET 平台代码生成器 V" + string.Format("{0}.{1}", ApplicationVersion.Major.ToString(), ApplicationVersion.Minor.ToString());

            #region 左侧视图

            dockManager = new DockingManager(this, VisualStyle.IDE)
            {
                OuterControl = statusBar,
                InnerControl = tabControlMain
            };

            //定义对象OuterControl，Docking Manager不会关注该对象以后生成的对象的窗口区域
            //对象InnerControl，Docking Manager不会关注在该对象生成以前的对象的窗口区域


            //数据库视图
            DBViewContent = new Content(dockManager)
            {
                Control = new DbView(this),
                Title = "数据库视图",
                FullTitle = "数据库视图",
                ImageList = leftViewImgs,
                ImageIndex = 0
            };

            var DBViewSize = DBViewContent.Control.Size;

            DBViewContent.AutoHideSize = DBViewSize;
            DBViewContent.DisplaySize = DBViewSize;

            //设计文档对象视图
            DesignObjectContent = new Content(dockManager)
            {
                Control = new PDObjectView(this),
                Title = "PD对象管理",
                FullTitle = "PowerDesigner Objects",
                ImageList = leftViewImgs,
                ImageIndex = 1
            };
            var DesignObjectSize = DesignObjectContent.Control.Size;
            //PowerDesigner对象管理
            DesignObjectContent.AutoHideSize = DesignObjectSize;
            DesignObjectContent.DisplaySize = DesignObjectSize;


            //将浮动窗口和具体在浮动窗口中被包含的面板联系起来
            dockManager.Contents.Add(DBViewContent);
            WindowContent wcdb = dockManager.AddContentWithState(DBViewContent, State.DockLeft);

            dockManager.Contents.Add(DesignObjectContent);
            dockManager.AddContentWithState(DesignObjectContent, State.DockRight);
            //dockManager.AddContentToWindowContent(DesignObjectContent, wcdb);

            #endregion

            LoadStartPage();

            #region 起始页

            /*
            appsettings = LTP.CmConfig.AppConfig.GetSettings();
            switch (appsettings.AppStart)
            {
                case "startuppage"://显示起始页
                    {
                        #region //启动起始页
                        try
                        {
                            LoadStartPage();
                        }
                        catch (System.Exception ex)
                        {
                            LogHelper.WriteException(ex);
                        }
                        #endregion
                    }
                    break;
                case "blank"://显示空环境
                    {
                    }
                    break;
                case "homepage": //打开主页
                    {
                        #region
                        string selstr = "首页";
                        string link = "http://www.cnblogs.com/huyong/";
                        if (appsettings.HomePage != null && appsettings.HomePage != "")
                        {
                            link = appsettings.HomePage;
                        }
                        //起始页
                        Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage();
                        page.Title = selstr;
                        page.Control = new IEView(this, link);
                        tabControlMain.TabPages.Add(page);
                        tabControlMain.SelectedTab = page;

                        #endregion
                    }
                    break;
            }
            
            */
            #endregion

            this.tabControlMain.MouseUp += new MouseEventHandler(OnMouseUpTabPage);
        }

        #region  引导起始页
        void LoadStartPage()
        {
            var RssPath = "http://blog.csdn.net/chinahuyong/rss/list";
            SetStatusText("正在加载起始页...");
            AddSinglePage(new StartPageForm(this, RssPath), "起始页");
            SetStatusText("完成");
        }
        #endregion

        #region 界面控件操作相关（异步）
        /// <summary>
        /// 发送信息到主界面的状态栏（异步）
        /// </summary>
        /// <param name="info">待发送的信息</param>
        public void InvokeSendStatusMessage(string info)
        {         
            this.Invoke(new MethodInvoker(() => { this.tslblPromptInfo.Text = info; }));
            Application.DoEvents();
        }
        #endregion

        #region 公用方法

        public void SetStatusText(string text)
        {
            this.tslblPromptInfo.Text = text;
        }

        //是否已经存在该窗体页
        private bool ExistPage(string ctrName)
        {
            var exist = false;
            if (tabControlMain.Visible == false)
            {
                tabControlMain.Visible = true;
            }
            foreach (var page in from TabPage page in tabControlMain.TabPages 
                                     let str = page.Control.Name 
                                     where page.Control.Name == ctrName select page)
            {
                exist = true;
            }
            return exist;
        }

        public void AddNewTabPage(Control control, string title)
        {
            if (this.tabControlMain.InvokeRequired)
            {
                var onAddNewTabPage = new AddNewTabPageEventHandler(AddNewTabPage);
                this.Invoke(onAddNewTabPage, new object[] { control, title });
            }
            else
            {
                var page = new TabPage {Title = title, Control = control};
                tabControlMain.TabPages.Add(page);
                tabControlMain.SelectedTab = page;
            }
        }

        // 增加TabPage
        public void AddTabPage(string pageTitle, Control ctrForm)
        {
            if (tabControlMain.Visible == false)
            {
                tabControlMain.Visible = true;
            }
            var page = new TabPage {Title = pageTitle, Control = ctrForm};
            tabControlMain.TabPages.Add(page);
            tabControlMain.SelectedTab = page;
        }


        // 创建新的唯一窗体页（不允许重复的）
        public void AddSinglePage(Control control, string title)
        {
            if (tabControlMain.Visible == false)
            {
                tabControlMain.Visible = true;
            }
            var showed = false;
            TabPage currPage = null;
            foreach (var page in tabControlMain.TabPages.Cast<TabPage>().Where(page => page.Control.Name == control.Name))
            {
                showed = true;
                currPage = page;
            }
            if (!showed)//不存在
            {
                AddNewTabPage(control, title);
            }
            else
            {
                tabControlMain.SelectedTab = currPage;
            }
        }

        /// <summary>
        /// 是否已经检查过最新版本
        /// </summary>
        /// <returns></returns>
        private bool IsHasChecked()
        {
            if (!File.Exists(cmcfgfile)) return false;
            cfgfile = new IniFileHelper(cmcfgfile);
            var contents = cfgfile.ReadString("update", "today", System.DateTime.Now.ToString("yyyyMMdd"));
            return contents == DateTime.Today.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 标记今天已经做了版本检测
        /// </summary>
        private void CheckMarker()
        {
            cfgfile.ReadString("update", "today", DateTime.Today.ToString("yyyyMMdd"));
        }

        #endregion

        #region  tabControlMain窗口中央的多页面板

        /// <summary>
        /// 在TabControl的右键中加入菜单
        /// </summary>
        protected void OnMouseUpTabPage(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.tabControlMain.TabPages.Count > 0 && e.Button == MouseButtons.Right && this.tabControlMain.SelectedTab.Selected)
            {
                var muMenu = new Crownwood.Magic.Menus.MenuControl();
                var menu1 = new Crownwood.Magic.Menus.MenuCommand("保存(&S)", new EventHandler(OnSaveSelected));
                var menu2 = new Crownwood.Magic.Menus.MenuCommand("关闭(&C)", new EventHandler(OnColseSelected));
                var menu3 = new Crownwood.Magic.Menus.MenuCommand("除此之外全部关闭(&A)", new EventHandler(OnColseUnSelected));

                var pm = new Crownwood.Magic.Menus.PopupMenu();
                pm.MenuCommands.AddRange(new Crownwood.Magic.Menus.MenuCommand[] { menu1, menu2, menu3 });
                pm.TrackPopup(this.tabControlMain.PointToScreen(new Point(e.X, e.Y)));
            }

            if (this.tabControlMain.TabPages.Count > 0 && e.Button == MouseButtons.Left && this.tabControlMain.SelectedTab.Selected)
            {
                tsbtnExecSql.Visible = false;
                switch (this.tabControlMain.SelectedTab.Control.Name)
                {
                    case "DbQuery":
                        {
                            tsbtnExecSql.Visible = true;                           
                        }
                        break;
                    case "DbBrowser":
                        {

                        }
                        break;
                    case "StartPageForm":
                        {

                        }
                        break;                 
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 关闭TabControl的已选择TabPage
        /// </summary>
        protected void OnColseSelected(object sender, EventArgs e)
        {
            if (tabControlMain.TabPages.Count > 0)
            {
                if (tabControlMain.SelectedTab.Title == "起始页")
                {
                    return;
                }
                OnCloseTabPage(tabControlMain.SelectedTab);
                tabControlMain.TabPages.Remove(tabControlMain.SelectedTab);
                if (tabControlMain.TabPages.Count == 0)
                {
                    tabControlMain.Visible = false;
                }
            }
        }

        /// <summary>
        /// 保存TabControl的已选择TabPage
        /// </summary>
        protected void OnSaveSelected(object sender, EventArgs e)
        {
            //tabControlMain.SelectedTab.Controls; 
        }
        /// <summary>
        /// 关闭TabControl的未选择的所有TabPage
        /// </summary>
        protected void OnColseUnSelected(object sender, EventArgs e)
        {
            if (tabControlMain.TabPages.Count <= 0) return;
            var pagelist = new ArrayList();
            foreach (var tabpage in tabControlMain.TabPages.Cast<TabPage>().Where(tabpage => tabpage != tabControlMain.SelectedTab))
            {
                pagelist.Add(tabpage);
            }
            foreach (TabPage tabpage in pagelist)
            {
                tabControlMain.TabPages.Remove(tabpage);
            }
            if (tabControlMain.TabPages.Count == 0)
            {
                tabControlMain.Visible = false;
            }
        }

        //关闭某页时作的处理
        private void OnCloseTabPage(TabPage page)
        {
            switch (page.Control.Name)
            {
                case "DbQuery":
                    {
                        tsbtnExecSql.Visible = false;                        
                    }
                    break;
                case "StartPageForm":
                    {

                    }
                    break;             
                default:
                    break;
            }
            page.Control.Dispose();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //文件菜单下拉各子菜单代码集合
        private void mitemFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mitemNew": //新建
                    NewFile();
                    break;
                case "mitemOpen": //打开
                    break;
                case "mitemSaveAs": //保存
                    SaveScript();
                    break;
                case "mitemExit": //退出系统
                    Application.Exit();
                    break;
            }
        }

        private void NewFile()
        {
            var tempfile = Application.StartupPath + @"\Templates\Class1.cs";
            if (!File.Exists(tempfile))
            {
                var sw = new StreamWriter(tempfile, false, Encoding.Default);//,false);
                sw.Write("");
                sw.Flush();
                sw.Close();
            }
            this.AddTabPage("Class1.cs", new CodeEditor(tempfile, "cs"));
        }

        private void SaveScript()
        {
            if (ActiveDbQuery == null) return;
            var dlgSaveSql = new SaveFileDialog
            {
                Title = "保存当前查询",
                Filter = "SQL 文件(*.sql)|*.sql|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
            };
            var dlgresult = dlgSaveSql.ShowDialog(this);
            if (dlgresult == DialogResult.OK)
            {
                string filename = dlgSaveSql.FileName;
                string text = ActiveDbQuery.txtContent.Text;
                using (var sw = new StreamWriter(filename, false, Encoding.Default))
                {
                    sw.Write(text);
                    sw.Flush();//从缓冲区写入基础流（文件）
                    sw.Close();
                }
            }
        }

        #region 得到当前焦点所在的窗体（Sql查询窗体、代码窗体等）
        /// <summary>
        /// 当前焦点的SQL查询窗体
        /// </summary>
        private DbQuery ActiveDbQuery
        {
            get
            {
                return (from TabPage page in tabControlMain.TabPages 
                        where page.Selected 
                        where page.Control.Name == "DbQuery" 
                        where page.Control.Controls.Cast<Control>().Any(ctr => (ctr.Name == "txtContent")) 
                        select (DbQuery) page.Control).FirstOrDefault();
                //V2.5版本时的代码：
/*
                foreach (TabPage page in tabControlMain.TabPages)
                {
                    if (!page.Selected) continue;
                    if (page.Control.Name == "DbQuery")
                    {
                        if (page.Control.Controls.Cast<Control>().Any(ctr => (ctr.Name == "txtContent")))
                        {
                            return (DbQuery)page.Control;
                        }
                    }
                }
                return null;
*/
            }
            set
            {
                ActiveDbQuery = value;
            }
        }
        #endregion

        //编辑菜单下拉各子菜单代码集合
        private void mitemEdit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (ActiveDbQuery == null)
            {
                return;
            }

            switch (e.ClickedItem.Name)
            {
                case "mitemRecovery": //恢复
                    ActiveDbQuery.Undo();
                    break;
                case "mitemCut": //剪切
                    ActiveDbQuery.Cut();
                    break;
                case "mitemCopy": //复制
                    ActiveDbQuery.Copy();
                    break;
                case "mitemPaste": //粘贴
                    ActiveDbQuery.Paste();
                    break;
                case "mitemDelete": //删除
                    ActiveDbQuery.Cut();
                    break;
                case "mitemSelectAll": //全选
                    SelectAll();     
                    break;
            }
        }

        #region private void SelectAll() 全选
        private void SelectAll()
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (!page.Selected) continue;
                if (page.Control.Name == "DbQuery")
                {
                    foreach (var txtContent in page.Control.Controls.Cast<Control>().Where(ctr => (ctr.Name == "txtContent")).Cast<TextEditorControlWrapper>())
                    {
                        txtContent.Select(0, txtContent.Text.Length);
                    }
                }
            }
        }
        #endregion

        private void mitemTool_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mitemProjectProperty":
                    new ProjectProperty().ShowDialog();
                    break;
            }
        }

        //工具栏各按钮单击事件
        private void tsTool_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbtnNew": //新建
                    NewFile();
                    break;
                case "tsbtnOpen": //打开
                    break;
                case "tsbtnExecSql": //执行SQL
                    if (tabControlMain.SelectedTab.Control.Name == "DbQuery")
                    {
                        var dqfrm = (DbQuery)tabControlMain.SelectedTab.Control;
                        dqfrm.RunCurrentQuery();
                    }
                    break;
                case "tsbtnExit": //退出 
                    Application.Exit();
                    break;
            }

            if (ActiveDbQuery == null)
            {
                return;
            }

            switch (e.ClickedItem.Name)
            {               
                case "tsbtnSave": //保存
                    this.SaveScript();
                    break;
                case "tsbtnCut":  //剪切
                    ActiveDbQuery.Cut();
                    break;
                case "tsbtnCopy":  //复制
                    ActiveDbQuery.Copy();
                    break;
                case "tsbtnPaste":  //粘贴
                    ActiveDbQuery.Paste();
                    break;
                case "tsbtnZoomIn": //放大                    
                    ZoomInOrOut("ZoomIn",2);
                    break;
                case "tsbtnZoomOut": //缩小
                    ZoomInOrOut("",2);
                    break;                
            }
        }

        private void tscboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomInOrOut("Fix",float.Parse(tscboFontSize.Text.Trim()));
        }

        #region private void ZoomInOrOut(string zoomStyle) 放大或缩小
        private void ZoomInOrOut(string zoomStyle,float Size)
        { 
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (!page.Selected) continue;
                if (page.Control.Name == "DbQuery")
                {
                    foreach (Control ctr in page.Control.Controls)
                    {
                        if ((ctr.Name != "txtContent")) continue;
                        var txtContent = (TextEditor.Editor.TextEditorControlWrapper)ctr;
                        switch (zoomStyle)
                        {
                            case "ZoomIn":
                                txtContent.Font = new Font(txtContent.Font.Name, txtContent.Font.Size + Size);
                                break;
                            case "Fix":
                                txtContent.Font = new Font(txtContent.Font.Name, Size);
                                break;
                            default:
                                if (txtContent.Font.Size > 2)
                                {
                                    txtContent.Font = new Font(txtContent.Font.Name, txtContent.Font.Size - Size);
                                }
                                break;
                        }
                    }
                }
            }
        }
        #endregion 

        private void mitemHelp_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mitemAbout": //关于本软件
                    var assembly = new AssemblyInformation(Assembly.GetEntryAssembly());
                    var frmAbout = new FrmAbout(assembly, "EricHu", "http://www.rdiframework.net/");
                    frmAbout.ShowDialog();
                    break;
                case "mitemOnlineHelp": //在线帮助
                    this.AddTabPage("在线帮助", new IEView(this, "http://www.rdiframework.net/"));
                    break;
            }
        }

        private void mitemWindow_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mitemDBView":
                    this.SetMnuChecked("数据库视图", mitemDBView);
                    break;
                case "mitemPBDesignerView": //PD对象管理
                    this.SetMnuChecked("PD对象管理", mitemDBView);
                    break;
                case "mitemStartPage": //起始页
                    this.AddSinglePage(new StartPageForm(this,string.Empty), "起始页");                    
                    break;
            }
        }

        private void SetMnuChecked(string dockObjectName, ToolStripMenuItem mnuItem)
        {
            var content = dockManager.Contents[dockObjectName];
            if (mnuItem.Checked)
            {
                dockManager.HideContent(content);
                mnuItem.Checked = false;
            }
            else
            {
                dockManager.ShowContent(content);
                mnuItem.Checked = true;
            }
        }

        private void tslblCopyright_Click(object sender, EventArgs e)
        {
            this.AddTabPage("在线帮助", new IEView(this, tslblCopyright.Text));
        }
    }
}
