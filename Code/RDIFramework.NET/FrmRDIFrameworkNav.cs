/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-02-08 12:57:46
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using DevComponents.DotNetBar;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
    
    /// <summary>
    /// FrmRDIFramework
    /// 平台主界面
    /// 
    /// 修改记录
    /// 
    ///     2014-02-28 EricHu V2.8 增加企业通，修改退出代码对企业通退出的支持。
    ///     2013-11-08 EricHu V2.7 增加针对模块类型自动只加载WinForm类型的模块。
    ///     2013-02-21 EricHu 新增向服务端发送心跳数据（每一分钟心跳一次，以示当前用户在线）。
    ///     2013-01-20 EricHu 修改为子系统显示形式。
    ///     2013-01-14 EricHu 新增全屏显示功能。
    ///     2012-06-04 EricHu 增加换肤功能。
    ///     2012-06-15 EricHu 修改窗体名称后的版本以两位数据显示。
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.08</date>
    /// </author> 
    /// </summary>
    public partial class FrmRDIFrameworkNav : BaseMainForm,IBaseMainForm
    {       
        #region 变量、属性定义
        /// <summary>
        /// 允许打开相同的Tab页
        /// </summary>
        public bool AllowSamePage = false;
        Timer timerOnLine = new Timer();
        System.Threading.Thread threadOnLineCheck = null;
        IFileService fileService = RDIFrameworkService.Instance.FileService;
        #endregion

        #region public FrmRDIFramework() 构造函数
        public FrmRDIFrameworkNav()
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
            if (SystemInfo.LogOned) { return; }
            this.MainTableControl = tabControlMain;
            tabStartPage.Image = ImageHelper.Scale(tabStartPage.Image, new Size(16, 16));
            ReMoveAllTabs();
            // 加载系统界面信息
            LoadFormInfo();
            // 这里需要隐藏主窗体
            this.Hide();
            // 这里显示登录窗体
            Form logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
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
            //得到所有的数据库连接
            GetAllDbLinks();

            this.CallMsg(false);

            ucStartPage1.LoadStartPageData();
            // 隐藏本窗口
            this.Hide();
        }
        #endregion

        #region private void LoadlblInfo() 加载底部标签信息
        /// <summary>
        /// 加载底部标签信息
        /// </summary>
        private void LoadlblInfo()
        {
            lblCompany.Visible = !string.IsNullOrEmpty(UserInfo.CompanyName);
            labelItem1.Visible = !string.IsNullOrEmpty(UserInfo.DepartmentName);
            if (!string.IsNullOrEmpty(UserInfo.CompanyName))
            {
                lblCompany.Text = "公司：[" + UserInfo.CompanyName + "]";
            }
            if (!string.IsNullOrEmpty(UserInfo.DepartmentName))
            {
                labelItem1.Text = "部门：[" + UserInfo.DepartmentName + "]";
            }
            
            lblUser.Text = "当前用户：" + UserInfo.RealName + "(" + UserInfo.UserName + ")";

            LunarCalendarHelper calendarHelper = new LunarCalendarHelper(DateTime.Now);
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
            sideBarMain.Panels.Clear(); 
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
                this.barMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] { buttonItem1 });
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
                sideBarMain.Panels.Clear();
                Application.DoEvents();
                var currentid = ((ButtonItem)sender).Name;
                lblItemCurrentSystem.Text = ((ButtonItem)sender).Text;
                LoadNavMeun(currentid);
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
            SplashForm.StartSplash();
            LoadSildeBar();
            SplashForm.CloseSplash();
        }

        /// <summary>
        /// 加载左侧功能栏项
        /// </summary>
        public void LoadSildeBar()
        {
            //清空左侧功能栏信息
            sideBarMain.Panels.Clear();
            Application.DoEvents();
            var currentid = dicSubSystem[cboCurrentSystem.Text.Trim()];
            lblItemCurrentSystem.Text = cboCurrentSystem.Text;
            LoadNavMeun(currentid);

        }

        private void LoadNavMeun(string currentid)
        {
            foreach (DataRow dr in ClientCache.Instance.DTUserMoule.Rows)
            {
                string parentId = dr[PiModuleTable.FieldParentId].ToString();
                //~这部分可以单独调优,只是为了把左侧功能栏项加载好，要新增项只需修改判断条件。
                //if ((dr[PiModuleTable.FieldParentId].ToString() != "1"))
                if (string.IsNullOrEmpty(parentId.Trim()) || parentId != currentid)
                {
                    continue;
                }

                //只加载模块类型为1（WinForm类型）或3（WinForm与WebForm相结合）的
                var moduleType = BusinessLogic.ConvertToNullableInt(dr[PiModuleTable.FieldModuleType]);
                if (moduleType != null && moduleType != 1 && moduleType != 3)
                {
                    continue;
                }

                var dataRows = ClientCache.Instance.DTUserMoule.Select(PiModuleTable.FieldParentId + " = '" + dr[PiModuleTable.FieldId].ToString() + "' AND (" + PiModuleTable.FieldModuleType + " IS NULL OR " + PiModuleTable.FieldModuleType + "=1 OR " + PiModuleTable.FieldModuleType + "=3)", PiModuleTable.FieldSortCode);
                if (dataRows.Length <= 0)
                {
                    continue;
                }

                var sideBarPanelItem = new SideBarPanelItem
                {
                    Name = dr[PiModuleTable.FieldCode].ToString(),
                    Text = dr[PiModuleTable.FieldFullName].ToString(),
                    Tag = dr
                };
                if (SystemInfo.MultiLanguage)
                {
                    if (SystemInfo.CurrentLanguage.Equals("zh-TW", StringComparison.OrdinalIgnoreCase))
                    {
                        sideBarPanelItem.Text = ChineseStringHelper.StringConvert(sideBarPanelItem.Text, 1);
                    }

                    if (SystemInfo.CurrentLanguage.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                    {
                        sideBarPanelItem.Text = sideBarPanelItem.Name.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? sideBarPanelItem.Name.Remove(0, 3) : sideBarPanelItem.Name;
                    }
                }

                if (dr[PiModuleTable.FieldImageIndex] != null && !string.IsNullOrEmpty(dr[PiModuleTable.FieldImageIndex].ToString().Trim()))
                {
                    byte[] buffer = fileService.Download(this.UserInfo, dr[PiModuleTable.FieldImageIndex].ToString().Trim());
                    if (buffer != null && buffer.Length > 0)
                    {
                        sideBarPanelItem.ItemImageSize = eBarImageSize.Default;
                        sideBarPanelItem.Image = BusinessLogic.byteArrayToImage(buffer);
                    }
                }
                this.AddButtonItem(dataRows, sideBarPanelItem);
                sideBarMain.Panels.Add(sideBarPanelItem);
            }
        }

        private void AddButtonItem(DataRow[] dataRows,SideBarPanelItem sidebarPItem)
        {
            if (dataRows.Length <= 0) { return; }
            foreach (DataRow dataRow in dataRows)
            {
                //只加载模块类型为1（WinForm类型）或3（WinForm与WebForm相结合）的
                var moduleType = BusinessLogic.ConvertToNullableInt(dataRow[PiModuleTable.FieldModuleType]);

                if (moduleType != null && moduleType != 1 && moduleType != 3)
                {
                    continue;
                }

                var buttomItem = new ButtonItem
                {
                    ButtonStyle = eButtonStyle.ImageAndText,
                    ImagePosition = eImagePosition.Top,
                    ItemAlignment = eItemAlignment.Center
                };
                if (dataRow[PiModuleTable.FieldImageIndex] != null && !string.IsNullOrEmpty(dataRow[PiModuleTable.FieldImageIndex].ToString().Trim()))
                {
                    byte[] buffer = fileService.Download(this.UserInfo, dataRow[PiModuleTable.FieldImageIndex].ToString().Trim());
                    buttomItem.Image = buffer != null && buffer.Length > 0
                        ? BusinessLogic.byteArrayToImage(buffer)
                        : imageListMain.Images[0];
                }
                else //取默认图标
                {
                    buttomItem.Image = imageListMain.Images[0];
                }

                buttomItem.Name = dataRow[PiModuleTable.FieldCode].ToString();
                buttomItem.Text = dataRow[PiModuleTable.FieldFullName].ToString();
                if (SystemInfo.MultiLanguage)
                {
                    if (SystemInfo.CurrentLanguage.Equals("zh-TW", StringComparison.OrdinalIgnoreCase))
                    {
                        buttomItem.Text = ChineseStringHelper.StringConvert(buttomItem.Text, 1);
                    }

                    if (SystemInfo.CurrentLanguage.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                    {
                        buttomItem.Text = buttomItem.Name.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? buttomItem.Name.Remove(0, 3) : buttomItem.Name;
                    }
                }
                buttomItem.Tag = dataRow;
                buttomItem.Click += this.sideBarItem_Click;
                sidebarPItem.SubItems.Add(buttomItem);
            }
        }

        /// <summary>
        /// 左侧的SildeBar点击事件
        /// </summary>
        private void sideBarItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ButtonItem bItem = sender as ButtonItem;
                if (bItem != null)
                {
                    var dataRow = bItem.Tag as DataRow;
                    string code = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FieldCode].ToString());
                    string assembly = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledAssemblyName].ToString());
                    string formName = BusinessLogic.ConvertToString(dataRow[PiModuleTable.FiledFormName].ToString());
                    OpenForm(code, assembly, formName, bItem.Image);
                }        
            }
            catch(Exception ex)
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
        /// <param name="pageImage">图标</param>
        private void OpenForm(string code, string assembly, string formName, Image pageImage)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(assembly) || string.IsNullOrEmpty(formName))
            {
                return;
            }
            if (assembly.ToLower().Contains(".dll"))
            {
                assembly = assembly.Substring(0, assembly.LastIndexOf('.'));
            }
            // 通过数据库的值获得要打开的模块对应的窗体类型。
            System.Type type = System.Type.GetType(formName.Trim() + "," + assembly);
            if (type == null)
            {
                MessageBoxHelper.ShowStopMsg(RDIFrameworkMessage.MSG1000);
                return;
            }
            object obj = (object)Activator.CreateInstance(type, null);
            BaseForm mdiForm = obj as BaseForm;
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

            AddToTab(mdiForm, code, pageImage);
        }

        public void AddToTab(BaseForm mdiForm, string code, Image pageImage)
        {
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
            //tabItemNew.Image = buttomItem.Image;
            if (pageImage != null)
            {
                tabItemNew.Image = ImageHelper.Scale(pageImage, new Size(24, 24)); //把图标缩放到24*24的尺寸
            }
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
            foreach (SuperTabItem item in tabControlMain.Tabs.Cast<SuperTabItem>().Where(item => item.Name == tabItemName))
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
                string dbType = dataRow[CiDbLinkDefineTable.FieldLinkType].ToString();
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
            Form logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);            
        }

        /// <summary>
        /// 移除除了主Tab的所有Tabs页
        /// </summary>
        private void ReMoveAllTabs()
        {
            
            int i = 1;
            while (tabControlMain.Tabs.Count > 1)
            {
                string tabName = tabControlMain.Tabs[i].Name;
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
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                SystemInfo.CurrentStyle = source.CommandParameter.ToString();
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), SystemInfo.CurrentStyle);
                // Using StyleManager change the style and color tinting
                StyleManager.ChangeStyle(style, Color.Empty);
                //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                //    buttonFile.BackstageTabEnabled = false;
                //else
                //    buttonFile.BackstageTabEnabled = true;
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
            FrmOption frmOption = new FrmOption();
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
            FrmAbout frmAbout = new FrmAbout(assembly, "EricHu", "http://www.cnblogs.com/huyong/");
            frmAbout.ShowDialog();
        }

        //提意见
        private void biComments_Click(object sender, EventArgs e)
        {
            FrmFeedback frmFeedback = new FrmFeedback();
            frmFeedback.Show();
        }

        //问题反馈
        private void biFeedback_Click(object sender, EventArgs e)
        {
            FrmFeedback frmFeedback = new FrmFeedback();
            frmFeedback.Show();
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

        //修改密码
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmChangePassword";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserChangePassword = (Form)Activator.CreateInstance(assemblyType);
            frmUserChangePassword.ShowDialog(this);
        }

        //查看我的权限
        private void btnViewMyPermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmViewUserPermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void tabControlMain_ControlBox_CloseBox_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab != null && tabControlMain.SelectedTab.Name.Equals("tabStartPage"))
            {
                return;
            }

            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0252) == System.Windows.Forms.DialogResult.Yes)
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

        private void FrmRDIFramework_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void biExitApplication_Click(object sender, EventArgs e)
        {
            this.ExitApp();
        }

        #endregion    

        private void ExitApp()
        {
            this.Close();
        }

        private void btnRuler_Click(object sender, EventArgs e)
        {
            //FrmRuler frmRuler = new FrmRuler();
            //frmRuler.Show();
        }

        private void btnRegex_Click(object sender, EventArgs e)
        {
            FrmRegexTester frmReg = new FrmRegexTester();
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
            for (int i = tabControlMain.Tabs.Count - 1; i >= 0; i--)
            {
                SuperTabItem tabitem = tabControlMain.Tabs[i] as SuperTabItem;
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
            
            string tabName = tabControlMain.SelectedTab.Name;
            var objList = new System.Collections.Generic.List<string>();
            for (int index = 0; index < tabControlMain.Tabs.Count; index++)
            {
                if (tabControlMain.Tabs[index].Name != tabName)
                {
                    objList.Add(tabControlMain.Tabs[index].Name);
                }
            }

            if (objList.Count > 0)
            {
                foreach (string name in objList)
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
                    OpenForm("FrmUnClaimedTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmUnClaimedTask", null);
                    break;
                case StartPageArea.ToDoList:
                    OpenForm("FrmToDoTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmToDoTask", null);
                    break;
                case StartPageArea.BeDownList:
                    OpenForm("FrmBeDoneTask", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmBeDoneTask", null);
                    break;
                case StartPageArea.WorkFlowMonitor:
                    OpenForm("FrmWorkFlowMonitor", "RDIFramework.WorkFlow.dll", "RDIFramework.WorkFlow.FrmWorkFlowMonitor", null);
                    break;
            }
        }
    }
}
