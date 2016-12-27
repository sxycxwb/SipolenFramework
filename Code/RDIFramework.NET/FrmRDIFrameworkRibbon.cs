using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using DevComponents.DotNetBar;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmRDIFrameworkRibbon : BaseRibbonForm, IBaseMainForm
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

        public FrmRDIFrameworkRibbon()
        {
            InitializeComponent();
            timerOnLine.Enabled = SystemInfo.CheckOnLine;
            timerOnLine.Interval = 60 * 1000; //每一分钟执行一次。
            timerOnLine.Tick += timerOnLine_Tick;
        }

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
            Form logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);

        }
        #endregion

        #region private void LoadFormInfo() 加载底部标签信息
        /// <summary>
        /// 加载底部标签信息
        /// </summary>
        private void LoadlblInfo()
        {
            lblCompany.Visible  = !string.IsNullOrEmpty(UserInfo.CompanyName);
            lblDept.Visible     = !string.IsNullOrEmpty(UserInfo.DepartmentName);
            if (!string.IsNullOrEmpty(UserInfo.CompanyName))
            {
                lblCompany.Text = "公司：[" + UserInfo.CompanyName + "]";
            }
            if (!string.IsNullOrEmpty(UserInfo.DepartmentName))
            {
                lblDept.Text = "部门：[" + UserInfo.DepartmentName + "]";
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

        #region private void LoadFormInfo() 加载系统界面信息
        private void LoadFormInfo()
        {
            //加载界面文本信息
            LoadFormTextInfo();
        }

        /// <summary>
        /// 加载界面文本信息
        /// </summary>
        private void LoadFormTextInfo()
        {
            var ApplicationVersion = new Version(Application.ProductVersion);
            this.Text = SystemInfo.SoftFullName + " V" + string.Format("{0}.{1}", ApplicationVersion.Major.ToString(), ApplicationVersion.Minor.ToString());
        }
        #endregion

        #region public void InitForm() 初始化窗体(IBaseMainForm接口)
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void InitForm()
        {
            btnItemOption.Visible = UserInfo.IsAdministrator;
            LoadlblInfo();
            // 获取用户的权限
            ClientCache.Instance.GetUserPermission(UserInfo);
            //得到所有的数据库连接
            GetAllDbLinks();
            this.CallMsg(false);
            ucStartPage1.LoadStartPageData();
            // 隐藏本窗口
            this.Hide();
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
            //加载各个子系统
            LoadSubSystem();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private Dictionary<string, string> dicSubSystem = new Dictionary<string, string>();
        private void LoadSubSystem()
        {
            cboCurrentSystem.Items.Clear();
            dicSubSystem.Clear();
            foreach (var dr in from DataRow dr in ClientCache.Instance.DTUserMoule.Rows
                               let moduleType = BusinessLogic.ConvertToNullableInt(dr[PiModuleTable.FieldModuleType])
                               let loadModule = (moduleType == null || moduleType == 1 || moduleType == 3) ? true : false
                               where (dr[PiModuleTable.FieldParentId] == DBNull.Value || dr[PiModuleTable.FieldParentId] == null || string.IsNullOrEmpty(dr[PiModuleTable.FieldParentId].ToString())) && loadModule
                               select dr)
            {
                dicSubSystem.Add(dr[PiModuleTable.FieldFullName].ToString().Trim(), dr[PiModuleTable.FieldId].ToString());
                cboCurrentSystem.Items.Add(dr[PiModuleTable.FieldFullName].ToString().Trim());
            }

            if (cboCurrentSystem.Items.Count > 0)
            {
                cboCurrentSystem.SelectedIndex = 0;
            }
        }


        private void cboCurrentSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SplashForm.StartSplash();
            //清空功能按钮
            if (this.ribbonControlMain.Items != null && this.ribbonControlMain.Items.Count > 0)
            {
                this.ribbonControlMain.Items.Clear();
            }

            if (this.ribbonControlMain.Items != null && this.ribbonControlMain.Items.Count > 0)
            {
                this.ribbonControlMain.Items.Clear();
            }
          
            LoadSildeBar(dicSubSystem[cboCurrentSystem.Text.Trim()]);
            SplashForm.CloseSplash();
        }

        /// <summary>
        /// 加载左侧功能栏项
        /// </summary>
        public void LoadSildeBar(string moduleId)
        {
            var currentid = moduleId;
            DataRow[] drows = ClientCache.Instance.DTUserMoule.Select(PiModuleTable.FieldParentId + " = '" + currentid + "'", PiModuleTable.FieldSortCode);
            if (drows.Length <= 0)
            {
                return;
            }
            bool isSelected = false;
            foreach (DataRow dr in drows)
            {
                //只加载模块类型为1（WinForm类型）或3（WinForm与WebForm相结合）的
                var moduleType = BusinessLogic.ConvertToNullableInt(dr[PiModuleTable.FieldModuleType]);

                if (moduleType != null && moduleType != 1 && moduleType != 3)
                {
                    continue;
                }
                //RibbonTabItem>RibbonPanel>RibbonBar>ButtonItem
                RibbonTabItem ribbonTabItem = new RibbonTabItem { Text = dr[PiModuleTable.FieldFullName].ToString().Trim() };
                RibbonPanel ribbonPanel = new RibbonPanel { Text = dr[PiModuleTable.FieldFullName].ToString().Trim() };

                if (SystemInfo.MultiLanguage)
                {
                    if (SystemInfo.CurrentLanguage.Equals("zh-TW", StringComparison.OrdinalIgnoreCase))
                    {
                        ribbonTabItem.Text = ChineseStringHelper.StringConvert(ribbonTabItem.Text, 1);
                        ribbonPanel.Text = ChineseStringHelper.StringConvert(ribbonPanel.Text, 1);
                    }

                    if (SystemInfo.CurrentLanguage.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                    {
                        string code = dr[PiModuleTable.FieldCode].ToString();
                        ribbonTabItem.Text = code.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? code.Remove(0, 3) : code;
                        ribbonPanel.Text = code.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? code.Remove(0, 3) : code;
                    }
                }

                ribbonTabItem.Panel = ribbonPanel;
                ribbonPanel.Dock = DockStyle.Fill;
                if (!isSelected)
                {
                    isSelected = true;
                    ribbonTabItem.Select();
                }
                this.ribbonControlMain.Controls.Add(ribbonPanel);
                this.ribbonControlMain.Items.Add(ribbonTabItem);

                DataRow[] subDrows = ClientCache.Instance.DTUserMoule.Select(PiModuleTable.FieldParentId + " = '" + dr[PiModuleTable.FieldId].ToString() + "'", PiModuleTable.FieldSortCode);
                if (subDrows.Length > 0)
                {
                    RibbonBar rb = new RibbonBar();
                    this.LoadSubItems(subDrows, rb, dr[PiModuleTable.FieldId].ToString());
                    ribbonPanel.Controls.Add(rb);
                }
            }
        }

        private void LoadSubItems(DataRow[] dataRows, RibbonBar rb, string moduleId)
        {
            if (dataRows.Length <= 0) return;

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
                    buttomItem.Image = buffer != null && buffer.Length > 0 ? BusinessLogic.byteArrayToImage(buffer) : imageListMain.Images[0];
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
                        buttomItem.Text = ChineseStringHelper.StringConvert(dataRow[PiModuleTable.FieldFullName].ToString(),1);
                    }

                    if (SystemInfo.CurrentLanguage.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                    {
                        buttomItem.Text = buttomItem.Name.StartsWith("Frm", StringComparison.OrdinalIgnoreCase) ? buttomItem.Name.Remove(0, 3) : buttomItem.Name;
                    }
                }
                
                buttomItem.Tag = dataRow;
                buttomItem.Click += this.sideBarItem_Click;
                rb.Items.Add(buttomItem);
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
        /// <param name="pageImage">图标</param>
        private void OpenForm(string code,string assembly,string formName,Image pageImage)
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
            mdiForm.FormClosed += new FormClosedEventHandler(RemoveSelectedTab);
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
            if (rdiFrameworkService.LogOnService is ICommunicationObject)
            {
                ((ICommunicationObject)rdiFrameworkService.LogOnService).Close();
            }
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
        //关于
        private void btnItemAbout_Click(object sender, EventArgs e)
        {
            var assembly = new AssemblyInformation(Assembly.GetEntryAssembly());
            FrmAbout frmAbout = new FrmAbout(assembly, "XuWangBin", "http://www.cnblogs.com/huyong/");
            frmAbout.ShowDialog();
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

        private void btnItemMsg_Click(object sender, EventArgs e)
        {
            CallMsg();
        }

        //问题反馈
        private void btnItemFeedback_Click(object sender, EventArgs e)
        {
            FrmFeedback frmFeedback = new FrmFeedback();
            frmFeedback.Show();
        }

        //修改密码
        private void btnItemChangePassword_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmChangePassword";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserChangePassword = (Form)Activator.CreateInstance(assemblyType);
            frmUserChangePassword.ShowDialog(this);
        }

        // 我的权限
        private void btnItemViewMyPermission_Click(object sender, EventArgs e)
        {
            var assemblyName = @"RDIFramework.WinModule";
            var formName = @"FrmViewUserPermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnItemOption_Click(object sender, EventArgs e)
        {
            var frmOption = new FrmOption();
            frmOption.ShowDialog();
        }

        private void FrmRDIFrameworkRibbon_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FrmRDIFrameworkRibbon_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnItemReLogOn_Click(object sender, EventArgs e)
        {
            this.ReMoveAllTabs();
            RDIFrameworkService.Instance.LogOnService.OnExit(UserInfo);
            Form logOnForm = CacheManager.Instance.GetForm(SystemInfo.LogOnAssembly, SystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }

        private void btnItemExitSystem_Click(object sender, EventArgs e)
        {
            this.ExitApp();
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
        #endregion

        private void ExitApp()
        {
            this.Close();
        }

        private void ucStartPage1_OnMoreClicked(object sender, EventArgs e)
        {
            switch (ucStartPage1.PageArea)
            {
                case  StartPageArea.UnClaimedTask:
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
