/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 9:24:14
 ******************************************************************************/

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
    ///		2012-03-02 版本：1.0 XuWangBin 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 03、角色权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 03.01 获取指定角色操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRolePermissionItemIds(UserInfo userInfo, string roleId);

        /// <summary>
        /// 03.02 获取角色主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleIdsByPermissionItemId(UserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 03.03 批量授予角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRolePermissions(UserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 03.04 授予指定角色指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="grantPermissionItemCode">授予操作权限编号</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantRolePermission(UserInfo userInfo, string roleName, string grantPermissionItemCode);

        /// <summary>
        /// 03.05 授予指定角色特定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantPermissionItemId">授予操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantRolePermissionById(UserInfo userInfo, string roleId, string grantPermissionItemId);

        /// <summary>
        /// 03.06 批量撤消指定角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissions(UserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds);

        /// <summary>
        /// 03.07 撤消指定角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="revokePermissionItemCode">撤消的操作权限编号</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermission(UserInfo userInfo, string roleName, string revokePermissionItemCode);

        /// <summary>
        /// 03.08 撤消指定角色的指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemId">撤消的操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissionById(UserInfo userInfo, string roleId, string revokePermissionItemId);

        /// <summary>
        /// 03.09 获取指定角色在某个权限域(或操作权限编号)下所拥有的用户主键数组
        /// 得到角色对那些用户有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>用户主键数组</returns>
        [OperationContract]
        string[] GetScopeUserIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 03.10 获取指定角色在某个权限域(或操作权限编号)下所拥有的角色主键数组
        /// 得到角色对那些角色有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>角色主键数组</returns>
        [OperationContract]
        string[] GetScopeRoleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 03.11 获取指定角色在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// 指定角色对那些组织机构有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>组织机构主键数组</returns>
        [OperationContract]
        string[] GetScopeOrganizeIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 03.12 授予角色某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantUserIds">授予用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleUserScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantUserIds);

        /// <summary>
        /// 03.13 撤消角色的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleUserScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeUserIds);

        /// <summary>
        /// 03.14 授予角色的某个权限域的角色范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantRoleIds">授予角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantRoleIds);

        /// <summary>
        /// 03.15 撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeRoleIds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeRoleIds);

        /// <summary>
        /// 03.16 授予角色的某个权限域的组织机构范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantOrganizeIds">授予组织机构主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantOrganizeIds);

        /// <summary>
        /// 03.17 撤消角色的某个权限域的组织机构范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeOrganizeIds);

        /// <summary>
        /// 03.18 获取指定角色在某个权限域下所有操作（功能）权限主键数组
        /// 指定角色对那些操作（功能）权限有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>操作权限主键数组</returns>
        [OperationContract]
        string[] GetScopePermissionItemIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 03.19 授予角色某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantPermissionItemIds">授予的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRolePermissionItemScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantPermissionItemIds);

        /// <summary>
        /// 03.20 撤消指定角色某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissionItemScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds);

        /// <summary>
        ///03.21 清除指定角色的所有权限
        ///清除角色的用户归属、清除角色的模块权限、清除角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int ClearRolePermissionByRoleId(UserInfo userInfo, string roleId);

        /// <summary>
        /// 清除指定角色所有权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int ClearRolePermissionScope(UserInfo userInfo, string roleId, string permissionItemCode);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 角色模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 03.22 获取指定角色在某个权限域下所有模块主键数组
        /// 指定角色对那些模块有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>模块主键数组</returns>
        [OperationContract]
        string[] GetScopeModuleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 03.23 授予角色某个权限域的模块授权范围  
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantRoleModuleScope2")]
        int GrantRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantModuleIds);

        /// <summary>
        /// 03.24 授予角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantRoleModuleScope1")]
        string GrantRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId);

        /// <summary>
        /// 03.25 撤消指定角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeRoleModuleScope2")]
        int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds);

        /// <summary>
        /// 03.26 撤消指定角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeRoleModuleScope1")]
        int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId);
    }
}
