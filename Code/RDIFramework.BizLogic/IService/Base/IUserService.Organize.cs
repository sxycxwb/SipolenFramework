using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial interface IUserService
    {
        /// <summary>
        /// 按<c>部门</c>获取部门用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDTByDepartment(UserInfo userInfo, string departmentId, bool containChildren);

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
        [OperationContract]
        DataTable GetUserPageDTByDepartment(UserInfo userInfo, string permissionScopeCode, string searchValue, bool? enabled, string auditStates, string[] roleIds, bool showRole, bool userAllInformation, out int recordCount, int pageIndex = 0, int pageSize = 100, string sort = null, string departmentId = null);

        /// <summary>
        /// 获得用户的组织机构兼职情况
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserOrganizeDT(UserInfo userInfo, string userId);

        /// <summary>
        /// 用户帐户添加到组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userOrganizeEntity">用户组织关系</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddUserToOrganize(UserInfo userInfo,PiUserOrganizeEntity userOrganizeEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 批量删除用户组织机构关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteUserOrganize(UserInfo userInfo, string[] ids);

        /// <summary>
        /// 用户是否在某个组织架构里的判断
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        [OperationContract]
        bool UserIsInOrganize(UserInfo userInfo, string userId, string organizeName);
    }
}
