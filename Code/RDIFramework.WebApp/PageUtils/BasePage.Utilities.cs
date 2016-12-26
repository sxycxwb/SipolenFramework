using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using RDIFramework.Utilities;
using RDIFramework.BizLogic;

public partial class BasePage:System.Web.UI.Page
{
    /// <summary>
    /// 访问权限
    /// </summary>
    protected bool permissionAccess = true;

    /// <summary>
    /// 新增权限
    /// </summary>
    protected bool permissionAdd = true;

    /// <summary>
    /// 编辑权限
    /// </summary>
    protected bool permissionEdit = true;

    /// <summary>
    /// 删除权限
    /// </summary>
    protected bool permissionDelete = true;

    /// <summary>
    /// 查询权限
    /// </summary>
    protected bool permissionSearch = true;

    /// <summary>
    /// 管理权限
    /// </summary>
    protected bool permissionAdmin = false;

    /// <summary>
    /// 导出权限
    /// </summary>
    protected bool permissionExport = true;

    // 操作权限

    #region public bool IsAuthorized(string permissionItemCode, string permissionItemName = null) 是否有相应的权限

    /// <summary>
    /// 是否有相应的权限
    /// </summary>
    /// <param name="permissionItemCode">权限编号</param>
    /// <param name="permissionItemName">权限名称</param>
    /// <returns>是否有权限</returns>
    public bool IsAuthorized(string permissionItemCode, string permissionItemName = null)
    {
        if (this.UserInfo == null)
        {
            Response.Write("<script>top.location.href='../login.htm'</script>");
            return false;
        }

        return RDIFrameworkService.Instance.PermissionService.IsAuthorizedByUserId(this.UserInfo, this.UserInfo.Id, permissionItemCode, permissionItemName);
    }
    #endregion

    #region public void Authorized(string permissionItemCode) 是否有相应权限
    /// <summary>
    /// 是否有相应权限
    /// </summary>
    /// <param name="permissionItemCode">权限编号</param>
    public void Authorized(string permissionItemCode)
    {
        // 若没有相应的权限，那就跳转到没有权限的页面里
        if (!Utils.UserIsLogOn() || !IsAuthorized(permissionItemCode))
        {
            HttpContext.Current.Response.Redirect(Utils.AccessDenyPage + "?Code=" + permissionItemCode);
        }
    }
    #endregion

    #region public bool UserCanSystemAdmin() 判断用户是否是管理员
    /// <summary>
    /// 判断用户是否是管理员
    /// </summary>
    /// <returns></returns>
    public bool UserCanSystemAdmin()
    {
        // 1.先判断是否已登录
        if (Utils.CheckIsLogOn(string.Empty))
        {
            // 2.有没有管理员审核的权限？
            if (IsAuthorized("SystemAdmin")) {return true;}
            //HttpContext.Current.Response.Redirect(Utils.UserNotLogOn);
            Response.Write("<script>window.top.location.href='" + Utils.UserNotLogOn + "'</script>");
            return false;
        }
        return false;
    }

    #endregion


    // 模块菜单权限

    #region public bool IsModuleAuthorized(string moduleCode) 是否有相应的模块权限
    /// <summary>
    /// 是否有相应的模块权限
    /// </summary>
    /// <param name="moduleCode">模块编号</param>
    /// <returns>是否有权限</returns>
    public bool IsModuleAuthorized(string moduleCode)
    {
        return this.UserInfo.IsAdministrator || BusinessLogic.Exists(this.DTModule, PiModuleTable.FieldCode, moduleCode);
    }

    #endregion

    #region protected DataTable DTModule 获取模块数据表
    /// <summary>
    /// 获取模块数据表
    /// </summary>
    protected DataTable DTModule
    {
        get
        {
            // 判断是否有数据，若没数据自动读取一次
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["_DTModule"] == null)
            {
                // 这里进行了菜单优化，出错问题
                bool openDB = false;
                if (this.RDIFrameworkDbProvider.GetDbConnection() == null)
                {
                    RDIFrameworkDbProvider.Open();
                    openDB = true;
                }
                GetModuleDT();
                if (openDB)
                {
                    RDIFrameworkDbProvider.Close();
                }
            }
            return Utils.GetFromSession("_DTModule") as DataTable;
        }
        set
        {
            Utils.AddSession("_DTModule", value);
        }
    }
    #endregion

    #region protected void GetModuleDT() 获模块列表
    /// <summary>
    /// 获模块列表
    /// </summary>
    protected void GetModuleDT()
    {
        lock (BasePage.UserLock)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["_DTModule"] == null)
            {
                var moduleManager = new PiModuleManager(this.RDIFrameworkDbProvider, this.UserInfo, PiModuleTable.TableName);
                if (this.UserInfo.IsAdministrator)
                {
                    var parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>(PiModuleTable.FieldEnabled, 1),
                        new KeyValuePair<string, object>(PiModuleTable.FieldDeleteMark, 0)
                    };
                    DTModule = moduleManager.GetDT(parameters, PiModuleTable.FieldSortCode);
                }
                else
                {
                    //DTModule = moduleManager.GetDTByUser(this.UserInfo.Id);
                    DTModule = RDIFrameworkService.Instance.PermissionService.GetModuleDTByUserId(userInfo, userInfo.Id);
                }
                // 按有效的模块进行过滤
                BusinessLogic.SetFilter(DTModule, PiModuleTable.FieldEnabled, "1");
                BusinessLogic.SetFilter(DTModule, PiModuleTable.FieldDeleteMark, "0");
                DTModule.DefaultView.Sort = PiModuleTable.FieldSortCode;
            }
        }
    }
    #endregion


    // 用户是否在某个角色里（按编号，按名称的）

    #region public bool UserIsInRole(string roleCode)
    /// <summary>
    /// 用户是否在某个角色里
    /// </summary>
    /// <param name="roleCode">角色编号</param>
    /// <returns>是否在某个角色里</returns>
    public bool UserIsInRole(string roleCode)
    {
        var userManager = new PiUserManager(this.RDIFrameworkDbProvider, userInfo);
        return userManager.IsInRoleByCode(this.UserInfo.Id, roleCode);
    }
    #endregion


    // 用户是否在某个部门（按编号，按名称的，按简称的)

    #region public bool UserIsInOrganize(string organizeName)
    /// <summary>
    /// 用户是否在某个组织架构里的判断
    /// </summary>
    /// <param name="organizeName">角色编号</param>
    /// <returns>是否在某个角色里</returns>
    public bool UserIsInOrganize(string organizeName)
    {
        var userManager = new PiUserManager(this.RDIFrameworkDbProvider, userInfo);
        return userManager.IsInOrganize(this.UserInfo.Id, organizeName);
    }
    #endregion


    // 获得部门列表(按权限范围)

    #region protected void GetDepartment()
    /// <summary>
    /// 获取部门列表
    /// </summary>
    protected System.Data.DataTable GetDepartment()
    {
        var manager = new PiOrganizeManager(this.RDIFrameworkDbProvider, this.UserInfo);
        return manager.GetDepartmentDT();
    }
    #endregion

    #region protected System.Data.DataTable GetDepartmentByPermissionScope(bool userDepartment = false, string permissionItemCode = "Resource.ManagePermission")
    /// <summary>
    /// 按权限范围获取部门列表
    /// </summary>
    /// <param name="userDepartment">若没数据库至少显示用户自己的部门</param>
    /// <param name="permissionItemCode">操作权限项</param>
    protected System.Data.DataTable GetDepartmentByPermissionScope(bool userDepartment = false, string permissionItemCode = "Resource.ManagePermission")
    {
        DataTable dtDepartment = null;

        var manager = new PiOrganizeManager(this.RDIFrameworkDbProvider, this.UserInfo);
        dtDepartment = this.UserInfo.IsAdministrator ? manager.GetDT(PiOrganizeTable.FieldDeleteMark, 0) : RDIFrameworkService.Instance.PermissionService.GetOrganizeDTByPermissionScope(userInfo, userInfo.Id, permissionItemCode);
        // 至少要列出自己的部门的
        if (!userDepartment) return dtDepartment;
        if (!string.IsNullOrEmpty(this.UserInfo.DepartmentId.ToString()) && !BusinessLogic.Exists(dtDepartment, PiOrganizeTable.FieldId, this.UserInfo.DepartmentId.ToString()))
        {
            dtDepartment.Merge(manager.GetDTById(this.UserInfo.DepartmentId.ToString()));
        }
        return dtDepartment;
    }
    #endregion

    /// <summary>
    /// 获取组织机构权限域数据
    /// </summary>
    protected DataTable GetOrganizeScope(string permissionItemScopeCode, bool isInnerOrganize)
    {
        // 获取部门数据，不启用权限域
        var dataTable = new DataTable(PiOrganizeTable.TableName);
        dataTable = (UserInfo.IsAdministrator) ||(String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope))
                    ? RDIFrameworkService.Instance.OrganizeService.GetDT(userInfo)
                    : RDIFrameworkService.Instance.PermissionService.GetOrganizeDTByPermissionScope(UserInfo, UserInfo.Id,permissionItemScopeCode);

        if (isInnerOrganize)
        {
            BusinessLogic.SetFilter(dataTable, PiOrganizeTable.FieldIsInnerOrganize, "1");
        }
        dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
        return dataTable;
    }

    // 获得用户列表(按权限范围)

    /// <summary>
    /// 获取用户权限域数据
    /// </summary>
    public DataTable GetUserScope(string permissionItemScopeCode)
    {
        //// 是否有用户管理权限，若有用户管理权限就有所有的用户类表，这个应该是内置的操作权限
        bool userAdmin = false;
        userAdmin = this.IsAuthorized("UserAdmin");
        var returnValue = new DataTable(PiUserTable.TableName);
        // 获取用户数据
        if (!userAdmin) return returnValue;
        returnValue = this.UserInfo.IsAdministrator ||(String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope))
                    ? RDIFrameworkService.Instance.UserService.GetDT(UserInfo)
                    : RDIFrameworkService.Instance.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id,permissionItemScopeCode);
        return returnValue;
    }

    /// <summary>
    /// 获取角色权限域数据
    /// </summary>
    public DataTable GetRoleScope(string permissionItemScopeCode)
    {
        // 获取部门数据
        var returnValue = new DataTable(PiRoleTable.TableName);
        returnValue = (UserInfo.IsAdministrator) ||(String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope))
                    ? RDIFrameworkService.Instance.RoleService.GetDT(UserInfo)
                    : RDIFrameworkService.Instance.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id,permissionItemScopeCode);
        return returnValue;
    }

    #region protected void GetUserByPermissionScope(DropDownList ddlUser, string organizeId = null, bool insertBlank = false, string permissionItemCode = "Resource.ManagePermission")
    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="ddlUser">用户选项</param>
    /// <param name="organizeId">部门主键</param>
    /// <param name="insertBlank">插入空行</param>
    protected void GetUserByPermissionScope(DropDownList ddlUser, string organizeId = null, bool insertBlank = false, string permissionItemCode = "Resource.ManagePermission")
    {
        var manager = new PiUserManager(this.RDIFrameworkDbProvider, this.UserInfo);
        DataTable dtUser = null;
        if (string.IsNullOrEmpty(organizeId))
        {
            if (this.UserInfo.IsAdministrator)
            {
                dtUser = manager.GetDT();
            }
            else
            {
                dtUser = RDIFrameworkService.Instance.PermissionService.GetUserDTByPermissionScope(userInfo, userInfo.Id, permissionItemCode);
                if (!string.IsNullOrEmpty(organizeId))
                {
                    BusinessLogic.SetFilter(dtUser, PiUserTable.FieldDepartmentId, organizeId);
                }
                // 至少要把自己显示出来，否则难控制权限了
                if (dtUser == null || dtUser.Rows.Count == 0)
                {
                    var userManager = new PiUserManager(userInfo);
                    dtUser = userManager.GetDTById(this.UserInfo.Id);
                }
            }
        }
        else
        {
            dtUser = manager.GetDataTableByOrganizes(new string[] { organizeId });
        }
        ddlUser.SelectedValue = null;
        ddlUser.DataValueField = PiUserTable.FieldId;
        ddlUser.DataTextField = PiUserTable.FieldRealName;
        ddlUser.DataSource = dtUser;
        ddlUser.DataBind();
        if (this.UserInfo.IsAdministrator || insertBlank)
        {
            ddlUser.Items.Insert(0, new ListItem());
        }
    }
    #endregion

    #region protected void GetUser(DropDownList ddlUser, string organizeId = null, bool insertBlank = true, int? securityLevel = null)
    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="ddlUser">用户选项</param>
    /// <param name="organizeId">部门主键</param>
    /// <param name="insertBlank">插入空行</param>
    protected void GetUser(DropDownList ddlUser, string organizeId = null, bool insertBlank = true, bool containSelf = true)
    {
        ddlUser.SelectedValue = null;
        ddlUser.DataValueField = PiUserTable.FieldId;
        ddlUser.DataTextField = PiUserTable.FieldRealName;
        ddlUser.DataSource = GetUser(organizeId, containSelf);
        ddlUser.DataBind();
        if (insertBlank)
        {
            ddlUser.Items.Insert(0, new ListItem());
        }
        if (containSelf)
        {
            ddlUser.SelectedValue = this.UserInfo.Id;
        }
    }

    protected DataTable GetUser(string organizeId = null, bool containSelf = true)
    {
        DataTable dtUser = null;
        var manager = new PiUserManager(this.RDIFrameworkDbProvider, this.UserInfo);

        string sqlQuery = string.Empty;
        sqlQuery = " SELECT * "
                + "   FROM " + PiUserTable.TableName
                + "  WHERE (" + PiUserTable.FieldDeleteMark + " = 0 "
                + "       AND " + PiUserTable.FieldEnabled + " = 1 "
                + "       AND " + PiUserTable.FieldIsVisible + " = 1 ";

        if (!string.IsNullOrEmpty(organizeId))
        {
            sqlQuery += " AND " + PiUserTable.FieldDepartmentId + " = '" + organizeId + "' ";
        }
        sqlQuery += " ) ";
        if (containSelf)
        {
            sqlQuery += " OR ( " + PiUserTable.FieldId + "='" + this.UserInfo.Id + "')";
        }

        sqlQuery += " ORDER BY " + PiUserTable.FieldSortCode;

        dtUser = manager.Fill(sqlQuery);
        dtUser.TableName = PiUserTable.TableName;
        return dtUser;
    }
    #endregion
}
