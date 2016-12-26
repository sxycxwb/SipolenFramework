/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
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
        /// 02、用户权限范围判断相关
        /// 按某个权限范围获取特定用户可访问的特定资源（这个权限范围主要指数据权限【如：资源管理权限、资源访问权限等】）
        //////////////////////////////////////////////////////////////////////////////////////////////////////
       
        /// <summary>
        /// 02.01 按某个权限范围获取特定用户可访问的用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.02 按某个权限范围获取特定用户可访问的用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.03 按某个权限范围获取特定用户可访问的取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetRoleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.04 按某个权限范围获取特定用户可访问的角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);        

        /// <summary>
        /// 02.05 按某个权限范围获取特定用户可访问的模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetModuleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.06 按某个权限范围获取特定用户可访问的操作权限列表(有授权权限的权限列表)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionItemDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.07 按某个权限范围获取特定用户可访问的组织机构列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetOrganizeDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 02.08 按某个权限范围获取特定用户可访问的组织机构主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizeIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode);

    }
}
