using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    using DevComponents.DotNetBar;
    using RDIFramework.BizLogic;
    using RDIFramework.Controls;
    using RDIFramework.Utilities;

    /// <summary>
    /// BaseForm
    /// 
    /// 修改纪录
    /// 
    ///     2014-07-16 XuWangBin V2.8 增加鼠标忙与闲的统一控制。
    ///     2012-06-21 XuWangBin 修改分页绑定后，记录不能上下移动的情况。
    ///		2012.01.21 版本：1.0 XuWangBin 创建。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.01.21</date>
    /// </author> 
    /// </summary>
    public class BaseMainForm: Office2007Form, IBaseForm
    {       
        #region 变量、属性、事件、委托等定义区域
        /// <summary>
        /// 设置按钮的可用状态
        /// </summary>
        /// <param name="setTop">置顶</param>
        /// <param name="setUp">上移</param>
        /// <param name="setDown">下移</param>
        /// <param name="setBottom">置底</param>
        /// <param name="add">添加</param>
        /// <param name="edit">编辑</param>
        /// <param name="batchSave">批量保存</param>
        public delegate void SetControlStateEventHandler(bool setTop, bool setUp, bool setDown, bool setBottom, bool add, bool edit, bool batchSave);

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public ConnectStrings DbLinks = new ConnectStrings();

        /// <summary>
        /// 不同窗体之间待传递的参数(特殊用途)
        /// </summary>
        public List<string> Stringlist = new List<string>();

        /// <summary>
        /// 只按对话框方式显示窗体
        /// </summary>
        public bool ShowDialogOnly = false;

        /// <summary>
        /// 是否记录窗体日志
        /// </summary>
        public bool RecordFormLog = false;
        private StyleManager styleManager1;
        private System.ComponentModel.IContainer components;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;

        public DevComponents.DotNetBar.SuperTabControl MainTableControl { get; set; }

        /// <summary>
        /// 是否加在用户配置参数（表格）
        /// </summary>
        public bool LoadUserParameters       = true;

        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        public bool ExitApplication = false;

        /// <summary>
        /// 窗体已经加载完毕
        /// </summary>
        public bool FormLoaded = false;

        /// <summary>
        /// 是否忙碌状态
        /// </summary>
        public bool Busyness = false;

        /// <summary>
        /// 数据发生过变化
        /// </summary>
        public bool Changed = false;

        /// <summary>
        /// 当前日志主键
        /// </summary>
        public string LogId = string.Empty;

        PageData pageData                     = null;
        public static DataTable pageDataTable = null;

        string queryStatement = "DeleteMark = 0";
        /// <summary>
        /// 组合查询所需的条件表达式(默认为:DeleteMark = 0)
        /// </summary>
        public virtual string QueryStatement
        {
            get
            {
                return queryStatement;
            }
            set
            {
                queryStatement = value;
            }
        }

        private string entityId = string.Empty;
        /// <summary>
        /// 实体主键
        /// </summary>
        public virtual string EntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }

        /// <summary>
        /// 当前用户信息
        /// 这里表示是只读的
        /// </summary>
        public UserInfo UserInfo
        {
            get
            {
                return SystemInfo.UserInfo;
            }
        }
        #endregion

        #region 构造函数
        public BaseMainForm()
        {
            if (!this.DesignMode)
            {
                 //必须放在初始化组件之前
                 this.GetIcon(); 
            }
            InitializeComponent();
            StyleManager.ChangeStyle((eStyle) Enum.Parse(typeof (eStyle), SystemInfo.CurrentStyle),string.IsNullOrEmpty(SystemInfo.CurrentThemeColor)
                    ? Color.Empty
                    : ColorTranslator.FromHtml(SystemInfo.CurrentThemeColor));
        }

        public virtual void GetIcon()
        {
            if (File.Exists(SystemInfo.AppIco))
            {
                this.Icon = new Icon(SystemInfo.AppIco);
            }
        }
        #endregion

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseMainForm));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "comboItem1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "comboItem2";
            // 
            // BaseMainForm
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(616, 375);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BaseMainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基类窗口";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);

        }
        #endregion

        #region public virtual void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public virtual void FormOnLoad()
        {
        }

        public virtual void Form_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    if (!this.DesignMode)
                    {
                        // 是否记录访问日志
                        if (SystemInfo.EnableRecordLog && (SystemInfo.LogOned && this.RecordFormLog))
                        {
                            // 调用服务事件
                            //this.LogId = RDIFrameworkService.Instance.LogService.WriteLog(UserInfo, this.Name, this.Text, "FormLoad");
                            var platFormService = new RDIFrameworkService();
                            platFormService.LogService.WriteLog(UserInfo, this.Name, RDIFrameworkMessage.GetMessage(this.Name), "FormLoad", RDIFrameworkMessage.LoadWindow);
                            this.CloseCommunicationObject(platFormService.LogService);
                        }
                    }

                    // 必须放在初始化组件之前
                    this.GetIcon();
                    // 获得页面的权限
                    this.GetPermission();
                    // 加载窗体
                    this.FormOnLoad();
                    // 设置按钮状态
                    this.SetControlState();
                    if (SystemInfo.MultiLanguage)
                    {
                        try
                        {
                            // 多语言国际化加载
                            if (ResourceManagerWrapper.Instance.GetLanguages() != null)
                            {
                                this.Localization(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowErrorMsg(ex.Message);
                        }
                    }
                    if (this.LoadUserParameters)
                    {
                        // 客户端页面配置加载
                        this.LoadUserParameter(this);
                    }
                    // 设置帮助
                    this.SetHelp();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    this.FormLoaded = true;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion        

        #region private void FormOnClosed() 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void FormOnClosed()
        {
            if (!this.DesignMode)
            {
                // 是否记录访问日志，已经登录了系统了，才记录日志
                if (SystemInfo.EnableRecordLog && SystemInfo.LogOned)
                {
                    // 保存列宽
                    BasePageLogic.SaveDataGridViewColumnWidth(this);
                    // 调用服务事件
                    if (this.RecordFormLog)
                    {
                        var service = new RDIFrameworkService();
                        service.LogService.WriteExit(UserInfo, this.LogId);
                        this.CloseCommunicationObject(service.LogService);
                    }
                }
            }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.FormOnClosed();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion

        #region public virtual void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public virtual void GetPermission()
        {
        }
        #endregion

        #region public virtual void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public virtual void SetControlState()
        {
        }
        #endregion

        #region public virtual void SetControlState(bool enabled) 设置按钮状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="enabled">有效</param>
        public virtual void SetControlState(bool enabled)
        {
        }
        #endregion

        #region public virtual void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public virtual void SetHelp()
        {
        }
        #endregion

        #region public virtual void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public virtual void ShowEntity()
        {
        }
        #endregion

        #region public virtual void GetList() 获得列表数据
        /// <summary>
        /// 获得列表数据
        /// </summary>
        public virtual void GetList()
        {
        }
        #endregion

        #region public virtual bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public virtual bool CheckInput()
        {
            return true;
        }
        #endregion

        #region public virtual bool SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public virtual bool SaveEntity()
        {
            return true;
        }
        #endregion

        #region public virtual int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public virtual int BatchDelete()
        {
            return 0;
        }
        #endregion

        #region public virtual bool CheckInputDelete() 检查批量删除
        /// <summary>
        /// 检查批量删除
        /// </summary>
        /// <returns>允许删除</returns>
        public virtual bool CheckInputDelete()
        {
            return true;
        }
        #endregion

        #region public void WriteException(Exception ex):在本地记录异常
        /// <summary>
        /// 在本地记录异常
        /// </summary>
        /// <param name="ex">异常</param>
        public void WriteException(Exception ex)
        {
            FileHelper.WriteException(this.UserInfo, ex);
        }
        #endregion

        #region public void ProcessException(Exception ex):处理异常信息(呈现给用户)
        /// <summary>
        /// 处理异常信息(呈现给用户)
        /// </summary>
        /// <param name="ex">异常</param>
        public void ProcessException(Exception ex)
        {
            this.WriteException(ex);
            //显示异常页面
            var frmException = new FrmException(ex);
            frmException.ShowDialog();
        }
        #endregion

        #region public void Localization(Form form) 多语言国际化加载
        /// <summary>
        /// 多语言国际化加载
        /// </summary>
        public void Localization(Form form)
        {
            BasePageLogic.SetLanguageResource(form);
        }
        #endregion

        #region public void LoadUserParameter(Form form) 客户端页面配置加载
        /// <summary>
        /// 客户端页面配置加载
        /// </summary>
        public void LoadUserParameter(Form form)
        {
            BasePageLogic.LoadDataGridViewColumnWidth(form);
        }
        #endregion

        #region public virtual void Form_KeyDown(object sender, KeyEventArgs e):窗体按键事件代码（F5：刷新窗体数据；回车键：光标移到下一个控件）
        public virtual void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 按键事件
            if (e.KeyCode == Keys.F5)
            {
                // F5刷新，重新加载窗体
                this.FormOnLoad();
            }
            else
            {
                // 按了回车按钮处理光标焦点
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    if ((this.ActiveControl is TextBox) || (this.ActiveControl is ComboBox) || (this.ActiveControl is CheckBox))
                    {
                        if ((this.ActiveControl is TextBox) && ((TextBox)this.ActiveControl).Multiline)
                        {
                            return;
                        }
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }
        #endregion

        #region public void CloseCommunicationObject(object o) 通信对象从其当前状态转换到关闭状态
        /// <summary>
        /// 使WCF通信对象从其当前状态转换到关闭状态。
        /// </summary>
        /// <param name="o"></param>
        public void CloseCommunicationObject(object o)
        {
            var communicationObject = o as ICommunicationObject;
            if (communicationObject != null)
            {
                communicationObject.Close();
            }
        }
        #endregion

        #region 权限控制区域代码（GetOrganizeScope、GetUserScope、GetRoleScope、GetModuleScope、GetPermissionItemScop）
        /// <summary>
        /// 获取组织机构权限域数据
        /// </summary>
        public DataTable GetOrganizeScope(string permissionItemScopeCode = "Resource.ManagePermission", bool isInnerOrganize= true)
        {
            // 获取部门数据，不启用权限域
            var dataTable = new DataTable(PiOrganizeTable.TableName);
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                dataTable = ClientCache.Instance.GetOrganizeDT(UserInfo).Copy();
                if (isInnerOrganize)
                {
                    BusinessLogic.SetFilter(dataTable, PiOrganizeTable.FieldIsInnerOrganize, "1");
                    BasePageLogic.CheckTreeParentId(dataTable, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
                }
                dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            }
            else
            {
                var platFormService = new RDIFrameworkService();
                dataTable = platFormService.PermissionService.GetOrganizeDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                this.CloseCommunicationObject(platFormService.PermissionService);
                if (isInnerOrganize)
                {
                    BusinessLogic.SetFilter(dataTable, PiOrganizeTable.FieldIsInnerOrganize, "1");
                    BasePageLogic.CheckTreeParentId(dataTable, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
                }
                dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            }
            return dataTable;
        }

        /// <summary>
        /// 获取用户权限域数据
        /// </summary>
        public DataTable GetUserScope(string permissionItemScopeCode)
        {
            // 是否有用户管理权限，若有用户管理权限就有所有的用户类表，这个应该是内置的操作权限
            var userAdmin = false;
            //userAdmin = this.IsAuthorized("UserAdmin"); //V2.8 版 暂时取消（用户可根据自己需要，只要登录用户可以访问用户表，就可以看到所有的用户，这儿就取消注释）

            //用户授权范围，不仅包含设置给用户的可管理用户范围，还包含用户可管理的组织机构范围下对应的用户。
            var tmpUserDT = new DataTable(PiUserTable.TableName);
            // 获取用户数据
            var platFormService = new RDIFrameworkService();

            if (userAdmin || this.UserInfo.IsAdministrator || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                tmpUserDT = platFormService.UserService.GetDT(UserInfo);
                this.CloseCommunicationObject(platFormService.UserService);
            }
            else
            {
                tmpUserDT = platFormService.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                this.CloseCommunicationObject(platFormService.PermissionService);
            }
            return tmpUserDT;
        }

        /// <summary>
        /// 获取角色权限域数据
        /// </summary>
        public DataTable GetRoleScope(string permissionItemScopeCode)
        {
            // 获取角色数据
            var dtTmpRole = new DataTable(PiRoleTable.TableName);
            var platFormService = new RDIFrameworkService();
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                dtTmpRole = platFormService.RoleService.GetDT(UserInfo);
                this.CloseCommunicationObject(platFormService.RoleService);
            }
            else
            {
                dtTmpRole = platFormService.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                this.CloseCommunicationObject(platFormService.PermissionService);
            }
            return dtTmpRole;
        }

        /// <summary>
        /// 获取模块菜单限域数据
        /// </summary>
        public DataTable GetModuleScope(string permissionItemScopeCode)
        {
            var platFormService = new RDIFrameworkService();

            // 获取部门数据
            if ((UserInfo.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                var dtModule = platFormService.ModuleService.GetDT(UserInfo);
                this.CloseCommunicationObject(platFormService.ModuleService);
             
                // 这里需要只把有效的模块显示出来
                // BusinessLogic.SetFilter(dtModule, PiModuleTable.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BusinessLogic.SetFilter(dtModule, PiModuleTable.FieldDeleteMark, "0");
                return dtModule;
            }

            var dataTable = platFormService.PermissionService.GetModuleDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
            this.CloseCommunicationObject(platFormService.PermissionService);
            BasePageLogic.CheckTreeParentId(dataTable, PiModuleTable.FieldId, PiModuleTable.FieldParentId);
            return dataTable;
        }

        /// <summary>
        /// 获取授权范围数据 （按道理，应该是在某个数据区域上起作用）
        /// </summary>
        public DataTable GetPermissionItemScop(string permissionItemScopeCode)
        {
            // 获取部门数据
            var dtPermissionItem = new DataTable(PiPermissionItemTable.TableName);
            var platFormService = new RDIFrameworkService();
            if (UserInfo.IsAdministrator || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                dtPermissionItem = platFormService.PermissionItemService.GetDT(UserInfo);
                this.CloseCommunicationObject(platFormService.PermissionItemService);
                // 这里需要只把有效的模块显示出来
                // BusinessLogic.SetFilter(dtPermissionItem, BasePermissionItemEntity.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BusinessLogic.SetFilter(dtPermissionItem, BasePermissionItemEntity.FieldDeleteMark, "0");

            }
            else
            {
                dtPermissionItem = platFormService.PermissionService.GetPermissionItemDTByPermissionScope(UserInfo, UserInfo.Id, permissionItemScopeCode);
                this.CloseCommunicationObject(platFormService.PermissionService);
                BasePageLogic.CheckTreeParentId(dtPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId);
            }
            return dtPermissionItem;
        }

        #endregion

        #region public bool ModuleIsVisible(string moduleCode) 模块是否可见
        /// <summary>
        /// 模块是否可见
        /// </summary>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>有权限</returns>
        public bool ModuleIsVisible(string moduleCode)
        {
            //模块是否可见;
            return (from DataRow dataRow in ClientCache.Instance.DTMoule.Rows where dataRow[PiModuleTable.FieldCode].ToString().Equals(moduleCode) select dataRow[PiModuleTable.FieldEnabled].ToString().Equals("1")).FirstOrDefault();
        }
        #endregion

        #region public bool IsModuleAuthorized(string moduleCode) 模块是否有权限访问
        /// <summary>
        /// 模块是否有权限访问
        /// </summary>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>有权限</returns>
        public bool IsModuleAuthorized(string moduleCode)
        {
            // 1：超级管理员模块都是能访问的
            if (this.UserInfo.IsAdministrator)
            {
                return true;
            }

            // 2：是否已经设置为公开？公开的模块谁都可以访问的
            var returnValue = ClientCache.Instance.DTMoule.Rows.Cast<DataRow>()
                .Where(dataRow => dataRow[PiModuleTable.FieldCode].ToString().Equals(moduleCode))
                .Select(dataRow => dataRow[PiModuleTable.FieldIsPublic].ToString().Equals("1"))
                .FirstOrDefault();

            // 3：当前用户是否有模块访问权限？（已包含用户的、角色的模块访问权限）
            if (!returnValue)
            {
                if (ClientCache.Instance.DTUserMoule.Rows.Cast<DataRow>().Any(dataRow => dataRow[PiModuleTable.FieldCode].ToString().Equals(moduleCode)))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        #endregion

        #region public bool IsAuthorized(string permissionItemCode, string permissionItemName = string.Empty) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>有权限</returns>
        public bool IsAuthorized(string permissionItemCode, string permissionItemName = null)
        {
            var returnValue = false;
            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
            if (UserInfo.IsAdministrator)
            {
                return true;
            }
            #endif

            // 若不使用操作权限项定义，那就所有操作权限都是不用生效了
            if (!SystemInfo.EnablePermissionItem)
            {
                return true;
            }

            /*
            //法一：本地缓存权限判断法：
            // 这里是判断本地缓存操作权限
            if (ClientCache.Instance.DTPermission == null)
            {
                // return false;
                // 重新读取本地缓存里的操作权限
                ClientCache.Instance.GetPermission(this.UserInfo);
            }            
            // 直接判断是否有相应的操作权限
            returnValue = BusinessLogic.IsAuthorized(ClientCache.Instance.DTPermission, permissionItemCode);
            if (returnValue)
            {
                return true;
            } */

            //法二：直接服务上进行权限判断，也可法一与法二结合。
            // 在服务器上进行权限判断（及时性高，但效率会低一些）
            if (!returnValue)
            {
                var platFormService = new RDIFrameworkService();
                returnValue = platFormService.PermissionService.IsAuthorizedByUserId(this.UserInfo, this.UserInfo.Id, permissionItemCode, permissionItemName);
                this.CloseCommunicationObject(platFormService.PermissionService);
            }
            return returnValue;
        }
        #endregion

        #region private bool FileExist(string fileName) 检查文件是否存在
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>是否存在</returns>
        private bool FileExist(string fileName)
        {
            if (!File.Exists(fileName)) return false;
            var targetFileName = Path.GetFileName(fileName);
            if (MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0236, targetFileName)) == DialogResult.Yes)
            {
                File.Delete(fileName);
            }
            else
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private void ExportToExcel(DataGridView dataGridView, DataView dataView, string directory, string fileName) 导出Excel
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dataGridView">表格控件</param>
        /// <param name="dataView">数据表格</param>
        /// <param name="directory">目录</param>
        /// <param name="fileName">文件名</param>
        public void ExportToExcel(DataGridView dataGridView, DataView dataView, string directory, string fileName)
        {
            var directoryName = SystemInfo.StartupPath + directory;
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            // 这里显示选择文件的对话框，可以取消导出可以确认导出，可以修改文件名。
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            fileName = SystemInfo.StartupPath + directory + fileName;
            saveFileDialog.InitialDirectory = directoryName;
            saveFileDialog.Filter = "导出数据文件(*.csv)|*.csv|所有文件|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出数据文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;   
                fileName = saveFileDialog.FileName;
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }                
                ExportCSVHelper.ExportCSV(dataView.Table, fileName);
                // 已经忙完了
                this.Cursor = holdCursor;
                Process.Start(fileName);
            }
        }

        /// <summary>
        /// 导出DataGridView数据到Excel
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public void ExportToExcel(DataGridView dataGridView, string directory, string fileName)
        {
            ExportToExcel(dataGridView, (DataView)(dataGridView.DataSource), directory, fileName);
        }

        /// <summary>
        /// 导出DataGridView数据到Text
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public void ExportToText(DataGridView dataGridView, string directory, string fileName)
        {
            var directoryName = SystemInfo.StartupPath + directory;
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            // 这里显示选择文件的对话框，可以取消导出可以确认导出，可以修改文件名。
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            fileName = SystemInfo.StartupPath + directory + fileName;
            saveFileDialog.InitialDirectory = directoryName;
            saveFileDialog.Filter = "导出数据文件(*.txt)|*.txt";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出数据文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                fileName = saveFileDialog.FileName;
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                using (var sw = File.CreateText(fileName))
                {
                    var strLine = "";

                    //写标题
                    for (var i = 0; i <= dataGridView.Columns.Count - 1; i++)
                    {
                        strLine += dataGridView.Columns[i].HeaderText + "       ";
                    }
                    sw.WriteLine(strLine);
                    sw.WriteLine("----------------------------------------------------------------------------------------------");

                    //写入数据
                    var dt = (DataTable)dataGridView.DataSource;
                    for (var i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        strLine = "";
                        for (var j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            strLine += dt.Rows[i][j].ToString() + "       ";
                        }
                        sw.WriteLine(strLine);
                    }
                    //写页脚
                    sw.WriteLine("---------------------------------------------------------------------------------------------");
                    sw.WriteLine("导出时间：" + DateTime.Now.ToString());
                    sw.Flush();    //之前写入的是缓冲区，现在更新到文件中去                
                }
                // 已经忙完了
                this.Cursor = holdCursor;
                Process.Start(fileName);
            }           
        }
        #endregion       

        #region private void DataGridViewOnLoad(object sender, DataGridViewRowPostPaintEventArgs e) dgv加载
        /// <summary>
        /// DataGridView加载
        /// </summary>
        public void DataGridViewOnLoad(DataGridView grd)
        {
            grd.RowPostPaint += this.DataGridView_RowPostPaint;
        }

        public void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号右对齐
            //Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            //    e.RowBounds.Location.Y,
            //    (sender as DataGridView).RowHeadersWidth - 4,
            //    e.RowBounds.Height);

            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            //    (sender as DataGridView).RowHeadersDefaultCellStyle.Font,
            //    rectangle,
            //    (sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor,
            //    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

            //序号居中
            //定义一个画笔，颜色用行标题的前景色填充
            var solidBrush = new SolidBrush((sender as DataGridView).RowHeadersDefaultCellStyle.ForeColor);
            //得到当前行的行号
            var rowIndex = e.RowIndex + 1;
            //DataGridView的RowHeadersWidth 为了算中间位置
            var rowHeadersWidth = (sender as DataGridView).RowHeadersWidth;
            //根据宽度与显示的字符数计算中间位置
            var rowHeadersX = (rowHeadersWidth - rowIndex.ToString().Length * 6) / 2;
            var rowHeadersY = e.RowBounds.Location.Y + 4;
            e.Graphics.DrawString((rowIndex).ToString(System.Globalization.CultureInfo.CurrentUICulture), (sender as DataGridView).DefaultCellStyle.Font, solidBrush, rowHeadersX, rowHeadersY);
        }
        #endregion       

        #region public virtual void RefreshForm():刷新窗体
        /// <summary>
        /// 刷新窗体
        /// </summary>
        public virtual void RefreshForm()
        {
            
        }
        #endregion

        #region public virtual void AddCheckBoxColumn(DataGridView dgvInfo):在DataGridView中插入CheckBoxColumn列
        /// <summary>
        /// 在DataGridView中插入CheckBoxColumn列
        /// <param name="dgvInfo">指定DataGridView</param>
        /// </summary>
        public virtual void AddCheckBoxColumn(DataGridView dgvInfo)
        {
            if (dgvInfo.Columns.Contains("colSelected"))
            {
                return;
            }

            var chkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "colSelected",
                HeaderText = "选择",
                DisplayIndex = 0,
                TrueValue = true,
                FalseValue = false,
                ReadOnly = false,
                Width = 50,
                Frozen = true,
                ThreeState = false
            };
            dgvInfo.Columns.Insert(0, chkColumn);
        }

        public virtual DataTable AddCheckColumn(DataTable dtInfo)
        {
            var dataColumn = new DataColumn("colSelected", typeof(System.Boolean));
            dataColumn.DefaultValue = false;
            dataColumn.AllowDBNull = false;
            dtInfo.Columns.Add(dataColumn);
            return dtInfo;
        }
        #endregion

        /// <summary>
        /// 设置鼠标繁忙状态，并保留原先的状态
        /// </summary>
        /// <returns></returns>
        protected Cursor BeginWait()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            return holdCursor;
        }

        /// <summary>
        /// 设置鼠标默认状态，原来的光标状态
        /// </summary>
        /// <param name="holdCursor"></param>
        protected void EndWait(Cursor holdCursor)
        {
            this.Cursor = holdCursor;
        }

        /// <summary>
        /// 得到分页数据，同时把绑定到DataGridView控件中。
        /// </summary>
        /// <param name="dataControl">显示分页数据的控件(一般为DataGridView)</param>
        /// <param name="pageControl">分页控件名称</param>
        /// <param name="tableName">表名</param>
        /// <param name="pageDbType">数据库类型</param>
        /// <param name="connstring">数据库连接字符串</param>
        /// <returns></returns>
        public int BindPageData(UcDataGridView dataControl, UcPageControl pageControl, string tableName, CurrentDbType pageDbType, string connstring)
        {
            return this.BindPageData(dataControl, pageControl, tableName, pageDbType, BusinessLogic.FieldId, BusinessLogic.FieldId, "DELETEMARK = 0", "*", connstring);
        }

        #region public virtual int BindPageData(UcDataGridView dataControl, UcPageControl pageControl, string tableName, CurrentDbType pageDbType, string primaryKey = "ID", string orderField = "ID", string whereConditional = "DELETEMARK = 0", string queryFields = "*", string connstring = ""):得到分页数据，同时把绑定到DataGridView控件中。
        /// <summary>
        /// 得到分页数据，同时把绑定到DataGridView控件中。
        /// </summary>
        /// <param name="dataControl">显示分页数据的控件(一般为DataGridView)</param>
        /// <param name="pageControl">分页控件名称</param>
        /// <param name="tableName">表名</param>
        /// <param name="pageDbType">数据库类型</param>
        /// <param name="primaryKey">主键名</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="whereConditional">Where条件</param>
        /// <param name="queryFields">结果字段列表</param>
        /// <param name="connstring">数据库连接字符串</param>
        /// <returns></returns>
        public int BindPageData(UcDataGridView dataControl, UcPageControl pageControl, string tableName, CurrentDbType pageDbType
            , string primaryKey = "ID", string orderField = "ID", string whereConditional = "DELETEMARK = 0"
            , string queryFields = "*", string connstring = "")
        {
            pageData = null;
            pageDataTable = null;
            pageData = new PageData();
            pageDataTable = new DataTable();
            pageData.TableName = tableName;
            pageData.PrimaryKey = primaryKey;
            pageData.OrderStr = orderField;
            pageData.PageIndex = pageControl.PageCurrent;
            pageData.PageSize = SystemInfo.PageSize; //指定分页大小(注：此句一定不能省略)
            pageControl.PageSize = pageData.PageSize; //指定此页面的分页大小(注：此句一定不能省略)
            pageData.QueryCondition = whereConditional;
            pageData.QueryFieldName = queryFields;
            pageData.PageDbType = pageDbType;
            pageDataTable = pageData.QueryDataTable(!string.IsNullOrEmpty(connstring.Trim()) ? connstring : SystemInfo.RDIFrameworkDbConection);
            pageControl.bindingSource.DataSource = pageDataTable;
            pageControl.bindingNavigator.BindingSource = pageControl.bindingSource;
            //((DataGridView)dataControl).DataSource = null;            
            //((DataGridView)dataControl).AutoGenerateColumns = false;
            //((DataGridView)dataControl).DataSource = ((DataTable)pageControl.bindingSource.DataSource).DefaultView;
            //this.AddCheckBoxColumn(((DataGridView)dataControl));
            dataControl.DataSource = null;
            dataControl.AutoGenerateColumns = false;
            dataControl.DataSource = pageControl.bindingSource;
            this.AddCheckBoxColumn(dataControl);
            pageControl.PageCount = pageData.TotalCount;
            return pageData.TotalCount;
        }
        #endregion


        /// <summary>
        /// 业务数据库部分
        /// </summary>
        private IDbProvider dbProvider = null;

        /// <summary>
        /// 业务数据库部分
        /// </summary>
        protected IDbProvider DbProvider
        {
            get {
                return dbProvider ?? (dbProvider =DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnection));
            }
        }

        /// <summary>
        /// 框架数据库部分
        /// </summary>
        private IDbProvider rdidbProvider = null;

        /// <summary>
        /// 框架数据库部分
        /// </summary>
        protected IDbProvider RDIFrameworkDbProvider
        {
            get {
                return rdidbProvider ?? (rdidbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection));
            }
        }

        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        private IDbProvider workFlowdbProvider = null;
        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        protected IDbProvider WorkFlowDbProvider
        {
            get {
                return workFlowdbProvider ??(workFlowdbProvider =DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnection));
            }
        }
       
    }
}