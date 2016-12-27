/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-02-08 12:57:46
 ******************************************************************************/
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RDIFramework.NET
{
    using DevComponents.DotNetBar;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    
    /// <summary>
    /// FrmRDIFrameworkTree
    /// RDIFramework.NET框架主界面(Tree格式)
    /// 
    /// 修改记录
    /// 
    ///     2014-02-28 XuWangBin V2.8 增加企业通，修改退出代码对企业通退出的支持。
    ///     2014.01.17 XuWangBin V2.7 增加RDIFramework.NET框架主界面(Tree格式)。
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014.01.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmRDIFrameworkTree : BaseMainForm,IBaseMainForm
    {       
        #region 变量、属性定义
        /// <summary>
        /// 允许打开相同的Tab页
        /// </summary>
        public bool AllowSamePage = false;
        Timer timerOnLine = new Timer();
        System.Threading.Thread threadOnLineCheck = null;
        //IFileService fileService = RDIFrameworkService.Instance.FileService;
        #endregion

        #region public FrmRDIFramework() 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmRDIFrameworkTree()
        {
            InitializeComponent();
            timerOnLine.Enabled = SystemInfo.CheckOnLine;
            timerOnLine.Interval = 60 * 1000; //每一分钟执行一次。
            timerOnLine.Tick += timerOnLine_Tick;
        }
        #endregion

        #region public override void FormOnLoad() 窗体加载
        public override void FormOnLoad()
        {
            if (SystemInfo.LogOned)
                return;

            tabStartPage.Image = ImageHelper.Scale(tabStartPage.Image, new Size(16, 16));
            this.MainTableControl = tabControlMain;
            ReMoveAllTabs();
            // 加载系统界面信息
            LoadFormInfo();
           
            // 这里需要隐藏主窗体
            this.Hide();
            // 这里显示登录窗体
            var logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }
        #endregion

        #region public void InitForm() 初始化窗体(IBaseMainForm接口)
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void InitForm()
        {
            biOption.Visible = UserInfo.IsAdministrator;
            // 获取用户的权限
            ClientCache.Instance.GetUserPermission(UserInfo);
            // 加载底部信息栏
            LoadlblInfo();
            GetAllDbLinks();
            this.CallMsg(false);
            ucStartPage1.LoadStartPageData();
            this.Hide();
        }
        #endregion

        #region private void LoadlblInfo() 加载底部标签信息
        /// <summary>
        /// 加载底部标签信息
        /// </summary>
        private void LoadlblInfo()
        {
            if (!string.IsNullOrEmpty(UserInfo.CompanyName))
            {
                lblCompany.Visible = true;
                lblCompany.Text = "公司：[" + UserInfo.CompanyName + "]";
            }
            else
            {
                lblCompany.Visible = false;
            }

            if (!string.IsNullOrEmpty(UserInfo.DepartmentName))
            {
                labelItem1.Visible = true;
                labelItem1.Text = "部门：[" + UserInfo.DepartmentName + "]";
            }
            else
            {
                labelItem1.Visible = false;
            }

            lblUser.Text = "当前用户：" + UserInfo.RealName + "(" + UserInfo.UserName + ")";

            var calendarHelper = new LunarCalendarHelper(DateTime.Now);
            lblDateTime.Text = "当前日期：" + calendarHelper.DateString.Replace("公元", "") 
                             + calendarHelper.WeekDayStr + " " 
                             + "农历" + calendarHelper.GanZhiDayString 
                             + "[" + calendarHelper.AnimalString + "]" 
                             + calendarHelper.ChineseMonthString 
                             + calendarHelper.ChineseDayString;
        }
        #endregion

        #region public void InitService() 初始化服务(IBaseMainForm接口)
        /// <summary>
        /// 初始化服务
        /// </summary>
        public void InitService()
        {
            AppStart.InitService(UserInfo);
        }
        #endregion

        #region public void CheckMenu() 获得的菜单(IBaseMainForm接口)
        /// <summary>
        /// 获得的菜单
        /// </summary>
        public void CheckMenu()
        {
            //清空左侧功能栏信息
            tvModules.Nodes.Clear();       
            //加载各个子系统
            LoadSubSystem();
            // 加载左侧功能栏项
            LoadSildeBar();
            this.WindowState = FormWindowState.Maximized;
        }

        private Dictionary<string, string> dicSubSystem = new Dictionary<string, string>();
        private void LoadSubSystem()
        {
            cboCurrentSystem.Items.Clear();
            dicSubSystem.Clear();
            this.barMenu.Items.Clear();
            foreach (var dr in from DataRow dr in ClientCache.Instance.DTUserMoule.Rows 
                                   let moduleType = BusinessLogic.ConvertToNullableInt(dr[PiModuleTable.FieldModuleType]) 
                                   let loadModule = (moduleType == null || moduleType == 1 || moduleType == 3) ? true : false 
                                   where (dr[PiModuleTable.FieldParentId] == DBNull.Value || dr[PiModuleTable.FieldParentId] == null|| string.IsNullOrEmpty(dr[PiModuleTable.FieldParentId].ToString())) && loadModule select dr)
            {
                dicSubSystem.Add(dr[PiModuleTable.FieldFullName].ToString().Trim(), dr[PiModuleTable.FieldId].ToString());
                cboCurrentSystem.Items.Add(dr[PiModuleTable.FieldFullName].ToString().Trim());

                //增加横向菜单
                var buttonItem1 = new DevComponents.DotNetBar.ButtonItem
                {
                    Name = dr[PiModuleTable.FieldId].ToString(),
                    Text = dr[PiModuleTable.FieldFullName].ToString().Trim()
                };
                buttonItem1.Click += this.menuItem_Click;
                this.barMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {buttonItem1});
            }

            if (cboCurrentSystem.Items.Count > 0)
            {
                cboCurrentSystem.SelectedIndex = 0;
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //清空左侧功能栏信息
                tvModules.Nodes.Clear();
                var currentid = ((ButtonItem) sender).Name;
                lblItemCurrentSystem.Text = ((ButtonItem)sender).Text;
                //cboCurrentSystem.SelectedText = ((ButtonItem)sender).Text;
                var treeNode = new TreeNode();
                tmpImageList.Images.Clear();
                this.LoadTreeNodes(ClientCache.Instance.DTUserMoule, PiModuleTable.FieldId, PiModuleTable.FieldParentId,PiModuleTable.FieldFullName, tvModules, treeNode, true, 1, null, 2, true, true, currentid);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboCurrentSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSildeBar();
        }

        /// <summary>
        /// 加载左侧功能栏项
        /// </summary>
        public void LoadSildeBar()
        {
            //清空左侧功能栏信息
            tvModules.Nodes.Clear();
            var currentid = dicSubSystem[cboCurrentSystem.Text.Trim()];
            lblItemCurrentSystem.Text = cboCurrentSystem.Text.Trim();
            var treeNode = new TreeNode();
            tmpImageList.Images.Clear();
            this.LoadTreeNodes(ClientCache.Instance.DTUserMoule, PiModuleTable.FieldId, PiModuleTable.FieldParentId,PiModuleTable.FieldFullName, tvModules, treeNode, true, 1, null, 2, true, true, currentid);
            
        }

        #region private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 0, string fieldToolTipText = null, int isloadTreeNum = 1, bool userSettingExpand = false, bool checkEnabledNode = false)
        /// <summary>
        /// 加载树型结构
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键</param>
        /// <param name="fieldParentId">上级字段</param>
        /// <param name="fieldFullName">全称</param>
        /// <param name="treeView">TreeView控件</param>
        /// <param name="treeNode">当前树结点</param>
        /// <param name="loadTree">是否加载树</param>
        /// <param name="expandLevel">展开层数，默认不展开</param>
        /// <param name="fieldToolTipText"></param>
        /// <param name="isloadTreeNum"></param>
        /// <param name="userSettingExpand">是否按用户配置展开</param>
        /// <param name="checkEnabledNode">是否选中启用的节点</param>
        private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 0, string fieldToolTipText = null, int isloadTreeNum = 1, bool userSettingExpand = false, bool checkEnabledNode = false, string currentParnetId = "0")
        {
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                    || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                    || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + " = " + currentParnetId);
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + " = '" + currentParnetId + "'");
                }
            }
            else
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                   || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                   || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + "=" + (treeNode.Tag as DataRow)[fieldId].ToString() + "", dataTable.DefaultView.Sort);
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + "='" + (treeNode.Tag as DataRow)[fieldId].ToString() + "'", dataTable.DefaultView.Sort);
                }
            }
            
            foreach (var dataRow in dataRows)
            {
                //只加载模块类型为1（WinForm类型）或3（WinForm与WebForm相结合）的
                var moduleType = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldModuleType]);
                if (moduleType != null && moduleType != 1 && moduleType != 3)
                {
                    continue;
                }

                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[fieldId] != null) && ((treeNode.Tag as DataRow)[fieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[fieldId].ToString().Equals(dataRow[fieldParentId].ToString())))
                {
                    continue;
                }

                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(fieldParentId) || (dataRow[fieldParentId].ToString() == "0") || (dataRow[fieldParentId].ToString().Length >0) || (((treeNode.Tag != null) && (treeNode.Tag as DataRow)[fieldId] != null) || (treeNode.Tag != null) && (treeNode.Tag as DataRow)[fieldId].Equals(dataRow[fieldParentId].ToString())))
                {
                    var newTreeNode = new TreeNode
                    {
                        Text = dataRow[fieldFullName].ToString(),
                        Tag = dataRow
                    };
                    if (SystemInfo.MultiLanguage)
                    {
                        if (SystemInfo.CurrentLanguage.Equals("zh-TW", StringComparison.OrdinalIgnoreCase))
                        {
                            newTreeNode.Text = ChineseStringHelper.StringConvert(newTreeNode.Text, 1);
                        }

                        if (SystemInfo.CurrentLanguage.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                        {
                            string code = dataRow[PiModuleTable.FieldCode].ToString();
                            newTreeNode.Text =code.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? code.Remove(0, 3) : code;
                        }
                    }

                    if (dataRow[PiModuleTable.FieldImageIndex] != null && !string.IsNullOrEmpty(dataRow[PiModuleTable.FieldImageIndex].ToString().Trim()))
                    {
                        var buffer = RDIFrameworkService.Instance.FileService.Download(this.UserInfo, dataRow[PiModuleTable.FieldImageIndex].ToString().Trim());
                        tmpImageList.Images.Add(buffer != null && buffer.Length > 0 ? BusinessLogic.byteArrayToImage(buffer) : imageListMain.Images[0]);
                        newTreeNode.ImageIndex = tmpImageList.Images.Count - 1;
                    }

                    if (!string.IsNullOrEmpty(fieldToolTipText))
                    {
                        newTreeNode.ToolTipText = dataRow[fieldToolTipText].ToString();
                    }

                    // 是否选中启用的节点 
                    if (checkEnabledNode)
                    {
                        newTreeNode.Checked = ((newTreeNode.Tag as DataRow)["Enabled"].ToString().Equals("1"));
                    }

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[fieldId] == null) || ((treeNode.Tag as DataRow)[fieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        treeView.Nodes.Add(newTreeNode);

                        // 是否按用户配置展开 
                        if (userSettingExpand)
                        {
                            if (((DataRow)newTreeNode.Tag)["Expand"].ToString() == "1")
                            {
                                newTreeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > newTreeNode.Level)
                            {
                                newTreeNode.Expand();
                            }
                        }
                    }
                    else
                    {
                        // 节点的子节点加载，第一层节点需要展开                        
                        treeNode.Nodes.Add(newTreeNode);
                        // 是否按用户配置展开
                        if (userSettingExpand)
                        {
                            if ((treeNode.Tag as DataRow)["Expand"].ToString() == "1")
                            {
                                treeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > treeNode.Level)
                            {
                                treeNode.Expand();
                            }
                        }
                    }

                    if (loadTree)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 1, userSettingExpand, checkEnabledNode, currentParnetId);
                    }
                    else if (isloadTreeNum == 1)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 2, userSettingExpand, checkEnabledNode, currentParnetId);
                    }
                }
            }
        }
        #endregion

        private void tvModules_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var dataRow = e.Node.Tag as DataRow;
                if (dataRow == null || string.IsNullOrEmpty(dataRow[PiModuleTable.FiledFormName].ToString()))
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                string code = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCode].ToString());
                string assembly = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledAssemblyName].ToString());
                string formName = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledFormName].ToString());
                OpenForm(code, assembly, formName,e.Node.ImageIndex);
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <param name="code">编辑（如：FrmModuleAdmin）</param>
        /// <param name="assembly">程序集名称（如：RDIFramework.WinModule.dll）</param>
        /// <param name="formName">窗体名称（如：RDIFramework.WinModule.FrmModuleAdmin）</param>
        /// <param name="imgIndex">图标索引</param>
        private void OpenForm(string code, string assembly, string formName, int imgIndex = 0)
        {
            if (string.IsNullOrEmpty(formName) || string.IsNullOrEmpty(assembly) || string.IsNullOrEmpty(formName))
            {
                return;
            }
            if (assembly.ToLower().Contains(".dll"))
            {
                assembly = assembly.Substring(0, assembly.LastIndexOf('.'));
            }
            // 通过数据库的值获得要打开的模块对应的窗体类型。
            var type = System.Type.GetType(formName.Trim() + "," + assembly);
            if (type == null)
            {
                MessageBoxHelper.ShowStopMsg(RDIFrameworkMessage.MSG1000);
                return;
            }
            var obj = (object) Activator.CreateInstance(type, null);
            var mdiForm = obj as BaseForm;
            mdiForm.Stringlist = base.Stringlist;
            mdiForm.DbLinks = base.DbLinks;
            if (mdiForm.ShowDialogOnly)
            {
                mdiForm.HelpButton = false;
                mdiForm.ShowInTaskbar = false;
                mdiForm.MinimizeBox = false;
                mdiForm.ShowDialog(this);
                return;
            }

            if (!AllowSamePage && TabIsExist(code))
            {
                return;
            }

            var tabItemNew = new SuperTabItem();
            var tabControlPanelNew = new SuperTabControlPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                Name = code,
                TabItem = tabItemNew
            };
            tabItemNew.AttachedControl = tabControlPanelNew;
            tabItemNew.Name = code;
            mdiForm.FormClosed += RemoveSelectedTab;
            mdiForm.FormBorderStyle = FormBorderStyle.None;
            mdiForm.TopLevel = false;
            mdiForm.Parent = tabControlPanelNew;
            mdiForm.Dock = DockStyle.Fill;
            tabControlPanelNew.Controls.Add(mdiForm);
            mdiForm.Show();
            mdiForm.AutoSize = true;
            tabItemNew.Text = mdiForm.Text;
            tabItemNew.Image = tmpImageList.Images.Count > imgIndex & imgIndex > 0 ? tmpImageList.Images[imgIndex] : imageListMain.Images[0];
            tabControlMain.Controls.Add(tabControlPanelNew);
            tabControlMain.Tabs.Add(tabItemNew);
            tabControlMain.Refresh();
            tabControlMain.SelectedTab = tabItemNew;
        }

        /// <summary>
        /// 关闭选中分页
        /// </summary>
        private void RemoveSelectedTab(object sender, FormClosedEventArgs e)
        {
            if (tabControlMain.SelectedTabIndex <= 0)
            {
                return;
            }

            tabControlMain.Tabs.Remove(tabControlMain.SelectedTab);
        }

        /// <summary>
        /// 判断是否允许打开相同的Tab页
        /// </summary>
        private bool TabIsExist(string tabItemName)
        {
            foreach (var item in tabControlMain.Tabs.Cast<SuperTabItem>().Where(item => item.Name == tabItemName))
            {
                tabControlMain.SelectedTab = item;
                return true;
            }
            return false;
        }

        #endregion                

        #region private void SendOnLineState() 向服务端发送心跳数据（每一分钟心跳一次，以示当前用户在线）。
        private void SendOnLineState()
        {
            //防止用户打开登录界面后一直不登录，此时系统会自动取其ID值为本机的IP地址，此时不应该记录登录状态，其用户主键为数据型的。
            if (!MathHelper.IsInteger(UserInfo.Id))
            {
                return;
            }
            var rdiFrameworkService = new RDIFrameworkService();            
            rdiFrameworkService.LogOnService.OnLine(UserInfo, 1);
            this.CloseCommunicationObject(rdiFrameworkService.LogOnService);
        }

        private void timerOnLine_Tick(object sender, EventArgs e)
        {
            threadOnLineCheck = new System.Threading.Thread(SendOnLineState);
            threadOnLineCheck.Start();
        }
        #endregion

        #region private void GetAllDbLinks():得到所有的数据库连接
        private void GetAllDbLinks()
        {
            var dtDbLinks = RDIFrameworkService.Instance.DbLinkDefineService.GetDT(this.UserInfo);
            if (dtDbLinks == null || dtDbLinks.Rows.Count <= 0) return;
            
            foreach (DataRow dataRow in dtDbLinks.Rows)
            {
                var connStr = new ConnectString
                {
                    LinkName = dataRow[CiDbLinkDefineTable.FieldLinkName].ToString(),
                    DbLink = dataRow[CiDbLinkDefineTable.FieldLinkData].ToString()
                };
                var dbType = dataRow[CiDbLinkDefineTable.FieldLinkType].ToString();
                switch (dbType.ToUpper())
                {
                    case "ACCESS":
                        connStr.DbType = CurrentDbType.Access;
                        break;
                    case "ORACLE":
                        connStr.DbType = CurrentDbType.Oracle;
                        break;
                    case "MYSQL":
                        connStr.DbType = CurrentDbType.MySql;
                        break;
                    case "SQLLITE":
                        connStr.DbType = CurrentDbType.SQLite;
                        break;
                    case "DB2":
                        connStr.DbType = CurrentDbType.DB2;
                        break;
                    default:
                        connStr.DbType = CurrentDbType.SqlServer;
                        break;

                }
                DbLinks.Add(connStr);
            }
        }
        #endregion

        #region private void LoadFormInfo() 加载系统界面信息
        private void LoadFormInfo()
        {
            this.biOption.Visible = this.UserInfo.IsAdministrator; //只有超级管理员用户进来才能看到选项菜单。
            //加载功能栏位置
            //LoadAllBar();
            //加载界面文本信息
            LoadFormTextInfo();
        }       

        /// <summary>
        /// 加载界面文本信息
        /// </summary>
        private void LoadFormTextInfo()
        {
            //this.Text = SystemInfo.SoftFullName + " " + SystemInfo.Version;
            var ApplicationVersion = new Version(Application.ProductVersion);
            this.Text = SystemInfo.SoftFullName + " V" + string.Format("{0}.{1}", ApplicationVersion.Major.ToString(), ApplicationVersion.Minor.ToString());     
        }
        #endregion

        #region 重新登录、退出系统按钮事件代码
        private void lblReLogOn_Click(object sender, EventArgs e)
        {
            this.ReMoveAllTabs();
            RDIFrameworkService.Instance.LogOnService.OnExit(UserInfo);
            var logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);            
        }

        /// <summary>
        /// 移除除了主Tab的所有Tabs页
        /// </summary>
        private void ReMoveAllTabs()
        {
            var i = 1;
            while (tabControlMain.Tabs.Count > 1)
            {
                var tabName = tabControlMain.Tabs[i].Name;
                if (tabName.Equals("tabStartPage"))
                {
                    continue;
                }
                tabControlMain.Tabs.Remove(tabName);
            }
        }

        private void lblExipApplication_Click(object sender, EventArgs e)
        {
            this.ExitApp();
        }
        #endregion      

        #region 主题样式相关事件代码
        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            var source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                SystemInfo.CurrentStyle = source.CommandParameter.ToString();
                var style = (eStyle)Enum.Parse(typeof(eStyle), SystemInfo.CurrentStyle);
                StyleManager.ChangeStyle(style, Color.Empty);
                UserConfigHelper.SaveConfig();
            }
            else if (source.CommandParameter is Color)
            {
                StyleManager.ColorTint = (Color)source.CommandParameter;
            }
        }

        private void buttonStyleCustom_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            StyleManager.ColorTint = e.Color;
        }

        private bool m_ColorSelected = false;
        private eStyle m_BaseStyle = eStyle.Office2010Silver;

        private void buttonStyleCustom_ExpandChange(object sender, EventArgs e)
        {
            if (buttonStyleCustom.Expanded)
            {
                // Remember the starting color scheme to apply if no color is selected during live-preview
                m_ColorSelected = false;
                m_BaseStyle = StyleManager.Style;
            }
            else
            {
                if (!m_ColorSelected)
                {
                    StyleManager.ChangeStyle(m_BaseStyle, Color.Empty);
                }
            }
        }

        private void buttonStyleCustom_SelectedColorChanged(object sender, EventArgs e)
        {
            m_ColorSelected = true; // Indicate that color was selected for buttonStyleCustom_ExpandChange method
            buttonStyleCustom.CommandParameter = buttonStyleCustom.SelectedColor;

            SystemInfo.CurrentThemeColor = System.Drawing.ColorTranslator.ToHtml(buttonStyleCustom.SelectedColor);
            UserConfigHelper.SaveConfig();
        }
        #endregion

        #region 各功能菜单事件代码
        //选项
        private void biOption_Click(object sender, EventArgs e)
        {
            var frmOption = new FrmOption();
            frmOption.ShowDialog();
        }

        //全屏显示
        private void biFullScreen_Click(object sender, EventArgs e)
        {
            expandableSplitter.Expanded = !expandableSplitter.Expanded;
            pnlTop.Visible = !pnlTop.Visible;
        }   

        //关于
        private void biAbout_Click(object sender, EventArgs e)
        {
            var assembly = new AssemblyInformation(Assembly.GetEntryAssembly());
            var frmAbout = new FrmAbout(assembly, "XuWangBin", "http://www.cnblogs.com/huyong/");
            frmAbout.ShowDialog();
        }

        //提意见
        private void biComments_Click(object sender, EventArgs e)
        {
            var frmFeedback = new FrmFeedback();
            frmFeedback.Show();
        }

        //问题反馈
        private void biFeedback_Click(object sender, EventArgs e)
        {
            var frmFeedback = new FrmFeedback();
            frmFeedback.Show();
        }

        //修改密码
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var assemblyName = @"RDIFramework.WinModule";
            var formName = @"FrmChangePassword";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmUserChangePassword = (Form)Activator.CreateInstance(assemblyType);
            frmUserChangePassword.ShowDialog(this);
        }

        //查看我的权限
        private void btnViewMyPermission_Click(object sender, EventArgs e)
        {
            var assemblyName = @"RDIFramework.WinModule";
            var formName = @"FrmViewUserPermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void tabControlMain_ControlBox_CloseBox_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab != null && tabControlMain.SelectedTab.Name.Equals("tabStartPage"))
            {
                return;
            }

            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0252) == DialogResult.Yes)
            {
                tabControlMain.Tabs.Remove(tabControlMain.SelectedTab);
            }
        }

        private void FrmRDIFramework_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0204) == DialogResult.Yes)
            {
                this.ExitApplication = true;
                if (SystemInfo.LogOned)
                {
                    if (AppStart.frmMsg != null)
                    {
                        AppStart.frmMsg.ExitApplication = true;
                        AppStart.frmMsg.Close();
                        AppStart.frmMsg.Dispose();
                    }
                    // 退出应用程序
                    var serviceInstance = new RDIFrameworkService();
                    serviceInstance.LogOnService.OnExit(UserInfo);
                    this.CloseCommunicationObject(serviceInstance.LogOnService);
                }
                e.Cancel = false;  //点击OK
            }
            else
            {
                e.Cancel = true;
            }  
        }

        private void FrmRDIFrameworkTree_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void biExitApplication_Click(object sender, EventArgs e)
        {
            this.ExitApp();
        }

        private void biReLogOn_Click(object sender, EventArgs e)
        {
            this.ReMoveAllTabs();
            RDIFrameworkService.Instance.LogOnService.OnExit(UserInfo);
            var logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }

        #endregion    

        private void ExitApp()
        {
            this.Close();
        }

        /// <summary>
        ///  企业通
        /// </summary>
        /// <param name="show">显示</param>
        public void CallMsg(bool show)
        {
            // 若还没登录，就应该退出了。
            if (!SystemInfo.LogOned)
            {
                return;
            }
            if (AppStart.frmMsg == null)
            {
                AppStart.frmMsg = new FrmMsg();
            }
            if (show)
            {
                AppStart.frmMsg.Visible = true;
                // AppStart.frmMsg.ShowInTaskbar = true;
                AppStart.frmMsg.Show();
                AppStart.frmMsg.WindowState = FormWindowState.Normal;
                AppStart.frmMsg.Activate();
            }
            else
            {
                // 加载窗体
                // AppStart.frmMsg.WindowState = FormWindowState.Minimized;
                AppStart.frmMsg.Show();
                AppStart.frmMsg.Hide();
            }
        }

        public void CallMsg()
        {
            this.CallMsg(true);
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            CallMsg();
        }

        private void btnRuler_Click(object sender, EventArgs e)
        {
            var frmRuler = new FrmRuler();
            frmRuler.Show();
        }

        private void btnRegex_Click(object sender, EventArgs e)
        {
            var frmReg = new FrmRegexTester();
            frmReg.Show();
        }

        private void tsMenuItemCloseThis_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab != null)
            {
                this.tabControlMain.SelectedTab.Close();
            }
        }

        private void tsMenuItemCloseOther_Click(object sender, EventArgs e)
        {
            CloseOthers();
        }

        private void tsMenuItemCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        public void CloseAllDocuments()
        {
            for (var i = tabControlMain.Tabs.Count - 1; i >= 0; i--)
            {
                var tabitem = tabControlMain.Tabs[i] as SuperTabItem;
                if (tabitem != null)
                {
                    tabitem.Close();
                }
            }
        }

        public void CloseOthers()
        {
            if (tabControlMain.Tabs == null || tabControlMain.Tabs.Count <= 0 || tabControlMain.SelectedTab == null)
                return;
            
            var tabName = tabControlMain.SelectedTab.Name;
            var objList = new System.Collections.Generic.List<string>();
            for (var index = 0; index < tabControlMain.Tabs.Count; index++)
            {
                if (tabControlMain.Tabs[index].Name != tabName)
                {
                    objList.Add(tabControlMain.Tabs[index].Name);
                }
            }

            if (objList.Count > 0)
            {
                foreach (var name in objList)
                {
                    tabControlMain.Tabs.Remove(name);
                }                                   
            }
        }

        private void ucStartPage1_OnMoreClicked(object sender, EventArgs e)
        {
            switch (ucStartPage1.PageArea)
            {
                case StartPageArea.UnClaimedTask:
                    OpenForm("FrmUnClaimedTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmUnClaimedTask", 0);
                    break;
                case StartPageArea.ToDoList:
                    OpenForm("FrmToDoTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmToDoTask", 0);
                    break;
                case StartPageArea.BeDownList:
                    OpenForm("FrmBeDoneTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmBeDoneTask", 0);
                    break;
                case StartPageArea.WorkFlowMonitor:
                    OpenForm("FrmWorkFlowMonitor", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmWorkFlowMonitor", 0);
                    break;
            }
        }
    }
}
