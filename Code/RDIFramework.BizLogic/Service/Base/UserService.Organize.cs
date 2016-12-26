using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	public partial class UserService
	{
        #region public DataTable GetDTByDepartment(UserInfo userInfo, string departmentId, bool containChildren) 按部门获取部门用户
        /// <summary>
        /// 按部门获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByDepartment(UserInfo userInfo, string departmentId, bool containChildren)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDTByDepartment);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(departmentId))
                {
                    dataTable = userManager.GetDT(PiUserTable.FieldDeleteMark, 0, PiUserTable.FieldSortCode);
                }
                else
                {
                    dataTable = containChildren? userManager.GetChildrenUsers(departmentId) : userManager.GetDTByDepartment(departmentId);
                }
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetUserPageDTByDepartment(UserInfo userInfo, string permissionScopeCode, string searchValue, bool? enabled, string auditStates, string[] roleIds, bool showRole, bool userAllInformation, out int recordCount, int pageIndex = 0, int pageSize = 100, string sort = null, string departmentId = null) 
        /// <summary>
        /// 根据部门查询用户分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionScopeCode">权限代码</param>
        /// <param name="searchValue">查询</param>
        /// <param name="enabled">有效</param>
        /// <param name="auditStates">审核状态</param>
        /// <param name="roleIds">用户角色</param>
        /// <param name="showRole">是否显示角色信息</param>
        /// <param name="departmentId">部门主键</param>
        /// <returns></returns>
        public DataTable GetUserPageDTByDepartment(UserInfo userInfo, string permissionScopeCode, string searchValue, bool? enabled, string auditStates, string[] roleIds, bool showRole, bool userAllInformation, out int recordCount, int pageIndex = 0, int pageSize = 100, string sort = null, string departmentId = null)
        {
            if (departmentId == null) departmentId = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_Search);
            int myrecordCount = 0;
            var dt = new DataTable(PiUserTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                dt = userManager.SearchByPage(permissionScopeCode, searchValue, roleIds, enabled, auditStates, departmentId, showRole, userAllInformation, out myrecordCount, pageIndex, pageSize, sort);
                dt.TableName = PiUserTable.TableName;
                // 是否显示角色信息
                if (showRole)
                {
                    // 这里是获取角色列表
                    PiRoleManager roleManager = new PiRoleManager(dbProvider, userInfo);
                    DataTable dataTableRole = roleManager.GetDT();
                    if (!dt.Columns.Contains("RoleName"))
                    {
                        dt.Columns.Add("RoleName");
                    }
                    // 友善的显示属于多个角色的功能
                    string roleName = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        roleName = string.Empty;
                        // 获取所在角色
                        roleIds = userManager.GetRoleIds(dr[PiUserTable.FieldId].ToString());
                        if (roleIds != null)
                        {
                            for (int i = 0; i < roleIds.Length; i++)
                            {
                                roleName = roleName + BusinessLogic.GetProperty(dataTableRole, roleIds[i], PiRoleTable.FieldRealName) + ", ";
                            }
                        }
                        // 设置角色的名称
                        if (!string.IsNullOrEmpty(roleName))
                        {
                            roleName = roleName.Substring(0, roleName.Length - 2);
                            dr["RoleName"] = roleName;
                        }
                    }
                    dt.AcceptChanges();
                }
            });
            recordCount = myrecordCount;
            return dt;
        }
        #endregion

        #region public DataTable GetUserOrganizeDT(UserInfo userInfo, string userId) 获得用户的组织机构兼职情况
        /// <summary>
        /// 获得用户的组织机构兼职情况
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetUserOrganizeDT(UserInfo userInfo, string userId)
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiUserOrganizeManager(dbProvider, userInfo).GetUserOrganizeDT(userId);
                dataTable.TableName = PiUserOrganizeTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string AddUserToOrganize(UserInfo userInfo, BaseUserOrganizeEntity userOrganizeEntity, out string statusCode, out string statusMessage) 把用户添加到组织机构
        /// <summary>
        /// 把用户添加到组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userOrganizeEntity">用户组织机构关系</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddUserToOrganize(UserInfo userInfo, PiUserOrganizeEntity userOrganizeEntity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userOrganizeManager = new PiUserOrganizeManager(dbProvider, userInfo);
                returnValue = userOrganizeManager.Add(userOrganizeEntity, out returnCode);
                returnMessage = userOrganizeManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int BatchDeleteUserOrganize(UserInfo userInfo, string[] ids) 批量删除用户组织机构关联
        /// <summary>
        /// 批量删除用户组织机构关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDeleteUserOrganize(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_BatchDeleteUserOrganize, "主键数组：" + BusinessLogic.ArrayToList(ids));

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiUserOrganizeManager(dbProvider, userInfo).Delete(ids);
            });
            return returnValue;
        }
        #endregion

        #region public bool UserIsInOrganize(UserInfo userInfo, string userId, string organizeName) 用户是否在某个组织架构里的判断
        /// <summary>
        /// 用户是否在某个组织架构里的判断
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        public bool UserIsInOrganize(UserInfo userInfo, string userId, string organizeName)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_UserIsInOrganize);
            bool result = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                result = userManager.IsInOrganize(userId, organizeName);
            });
            return result;
        }
        #endregion
	}
}
