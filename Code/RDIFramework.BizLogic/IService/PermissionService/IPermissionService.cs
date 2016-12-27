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
    [ServiceContract]
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 01、用户权限判断相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 01.01 指定用户是否在指定的角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleName">角色名称</param>
        /// <returns>指定用户是否在指定角色里，true：是，false：否</returns>
        [OperationContract]
        bool IsInRole(UserInfo userInfo, string userId, string roleName);

        /// <summary>
        /// 01.02 当前用户是否有相应的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        [OperationContract]
        bool IsAuthorized(UserInfo userInfo, string permissionItemCode, string permissionItemName);

        /// <summary>
        /// 01.03 指定用户是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        [OperationContract]
        bool IsAuthorizedByUserId(UserInfo userInfo, string userId, string permissionItemCode, string permissionItemName);

        /// <summary>
        /// 01.04 指定角色是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        [OperationContract]
        bool IsAuthorizedByRoleId(UserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 01.05 当前用户是否为超级管理员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>当前用户是否为超级管理员，true：是，false：否</returns>
        [OperationContract]
        bool IsAdministrator(UserInfo userInfo);

        /// <summary>
        /// 01.06 指定用户是否超级管理员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>是否超级管理员，true：是，false：否</returns>
        [OperationContract]
        bool IsAdministratorByUserId(UserInfo userInfo, string userId);

        /// <summary>
        /// 01.07 获得当前用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>权限数据表</returns>
        [OperationContract]
        DataTable GetPermissionDT(UserInfo userInfo);

        /// <summary>
        /// 01.08 获得指定用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>权限数据表</returns>
        [OperationContract]
        DataTable GetPermissionDTByUserId(UserInfo userInfo, string userId);

        /// <summary>
        /// 01.09 当前用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        [OperationContract]
        bool IsModuleAuthorized(UserInfo userInfo, string moduleCode);

        /// <summary>
        /// 01.10 指定用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        [OperationContract]
        bool IsModuleAuthorizedByUserId(UserInfo userInfo, string userId, string moduleCode);

        /// <summary>
        /// 01.11 获得指定用户的数据权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>数据权限范围</returns>
        [OperationContract]
        PermissionScope GetPermissionScopeByUserId(UserInfo userInfo, string userId, string permissionItemCode);
     }
}
