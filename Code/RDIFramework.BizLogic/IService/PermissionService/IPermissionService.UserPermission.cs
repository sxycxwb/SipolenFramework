/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 9:24:14
 ******************************************************************************/

using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IPermissionService
    /// 权限服务层接口
    /// 
    /// 修改纪录
    /// 
    ///     2012-07-08 版本: 1.3 XuWangBin 新增用户对模块的授权范围控制部分。
    ///		2012-03-02 版本：1.0 XuWangBin 创建文件。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 04、用户权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 04.01 获取指定用户操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>操作权限主键数组</returns>
        [OperationContract]
        string[] GetUserPermissionItemIds(UserInfo userInfo, string userId);

        /// <summary>
        /// 04.02 获取用户主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>用户主键数组</returns>
        [OperationContract]
        string[] GetUserIdsByPermissionItemId(UserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 04.03 批量授予用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserPermissions(UserInfo userInfo, string[] userIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 04.04 授予指定用户指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemId">授予的操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantUserPermissionById(UserInfo userInfo, string userId, string grantPermissionItemId);

        /// <summary>
        /// 04.05 批量撤消用户的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="revokePermissionItemIds">撤消的权限权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissions(UserInfo userInfo, string[] userIds, string[] revokePermissionItemIds);

        /// <summary>
        /// 04.06 撤消指定用户指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemId">撤消的操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissionById(UserInfo userInfo, string userId, string revokePermissionItemId);

        /// <summary>
        /// 04.07 获取指定用户在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// 指定用户对那些组织机构有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>组织机构主键数组</returns>
        [OperationContract]
        string[] GetScopeOrganizeIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 04.08 授予用户某个权限域的组织机构授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantOrganizeIds">授予的组织机构主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserOrganizeScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantOrganizeIds);

        /// <summary>
        /// 04.09 撤消用户某个权限域的组织组织授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限代码</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserOrganizeScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokeOrganizeIds);

        /// <summary>
        /// 04.10 获取指定用户在某个权限域下所有用户主键数组
        /// 指定用户对那些用户有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>用户主键数组</returns>
        [OperationContract]
        string[] GetScopeUserIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 04.11 授予用户某个权限域的用户授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantUserIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserUserScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantUserIds);

        /// <summary>
        /// 04.12 撤消用户某个权限域的用户授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserUserScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokeUserIds);

        /// <summary>
        /// 04.13 获取指定用户在某个权限域下所有角色主键数组
        /// 指定用户对那些角色有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>角色主键数组</returns>
        [OperationContract]
        string[] GetScopeRoleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 04.14 授予用户某个权限域的角色授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantRoleIds">授予的角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserRoleScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantRoleIds);

        /// <summary>
        /// 04.15 撤消用户某个权限域的角色授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeRoleds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserRoleScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokeRoleds);

        /// <summary>
        /// 04.16 获取指定用户在某个权限域下所有操作（功能）权限主键数组
        /// 指定用户对那些操作（功能）权限有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>操作权限主键数组</returns>
        [OperationContract]
        string[] GetScopePermissionItemIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 04.17 授予用户某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantPermissionItemIds">授予的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds);

        /// <summary>
        /// 04.18 撤消指定用户某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds);

        /// <summary>
        /// 04.19 清除指定用户的所有权限
        /// 清除角色归属、清除模块权限、清除操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int ClearUserPermissionByUserId(UserInfo userInfo, string userId);

        /// <summary>
        /// 04.20 清除指定用户所有权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>受影响的行数</returns>
        [OperationContract]
        int ClearUserPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户关联模块关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 04.21 获得当前用户有访问权限的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>模块数据表</returns>
        [OperationContract]
        DataTable GetModuleDT(UserInfo userInfo);

        /// <summary>
        /// 04.22 获取指定用户有权限访问的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetModuleIdsByUserId(UserInfo userInfo, string userId);

        /// <summary>
        /// 04.23 获得指定用户有权限访问的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>模块数据表</returns>
        [OperationContract]
        DataTable GetModuleDTByUserId(UserInfo userInfo, string userId);

        /// <summary>
        /// 04.24 获取指定用户在某个权限域下所有模块主键数组
        /// 指定用户对那些模块有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>模块主键数组</returns>
        [OperationContract]
        string[] GetScopeModuleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 04.25 授予用户某个权限域的模块授权范围  
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantUserModuleScope1")]
        string GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId);

        /// <summary>
        /// 04.26 授予用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantUserModuleScope2")]
        int GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds);

        /// <summary>
        /// 04.27 撤消指定用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeUserModuleScope1")]
        int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId);

        /// <summary>
        /// 04.28 撤消指定用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeUserModuleScope2")]
        int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds);
    }
}
