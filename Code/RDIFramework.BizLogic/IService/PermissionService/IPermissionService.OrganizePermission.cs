/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-18 9:24:14
 ******************************************************************************/

using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// IPermissionService
    /// 与权限判断等相关的接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：1.0 EricHu 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 06、组织机构模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 06.01 获取指定组织机构在某个权限域下所有模块主键数组
        /// 指定组织机构对那些模块有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>模块主键数组</returns>
        [OperationContract]
        string[] GetScopeModuleIdsByOrganizeId(UserInfo userInfo, string organizeId, string permissionItemCode);

        /// <summary>
        /// 06.02 授予组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantOrganizeModuleScope2")]
        int GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] grantModuleIds);

        /// <summary>
        /// 06.03 授予组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "GrantOrganizeModuleScope1")]
        string GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId);

        /// <summary>
        /// 06.04 撤消指定组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeOrganizeModuleScope2")]
        int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds);

        /// <summary>
        /// 06.05 撤消指定组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract(Name = "RevokeOrganizeModuleScope1")]
        int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 组织机构权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 06.06 获取指定组织机构操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>组织机构主键数组</returns>
        [OperationContract]
        string[] GetOrganizePermissionItemIds(UserInfo userInfo, string organizeId);

        /// <summary>
        /// 06.07 获取组织机构主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizeIdsByPermissionItemId(UserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 06.08 授予指定组织机构指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantPermissionItemId">授予操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantOrganizePermissionById(UserInfo userInfo, string organizeId, string grantPermissionItemId);

        /// <summary>
        /// 06.09 授予组织机构权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 06.10 撤消组织机构权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="revokePermissionItemIds">撤消操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] revokePermissionItemIds);

        /// <summary>
        /// 06.11 撤消指定组织机构指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokePermissionItemId">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizePermissionById(UserInfo userInfo, string organizeId, string revokePermissionItemId);

        /// <summary>
        /// 06.12 清除组织机构权限（清除组织机构的用户归属、模块权限、操作权限）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int ClearOrganizePermission(UserInfo userInfo, string organizeId);
    }
}
