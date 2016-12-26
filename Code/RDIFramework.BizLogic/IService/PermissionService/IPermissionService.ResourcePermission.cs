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
        /// 05、资源权限设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 05.01 获取资源权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>操作权限主键数组</returns>
        [OperationContract]
        string[] GetResourcePermissionItemIds(UserInfo userInfo, string resourceCategory, string resourceId);

        /// <summary>
        /// 05.02 授予资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="grantPermissionItemIds">操作权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds);

        /// <summary>
        /// 05.03 撤消资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="revokePermissionItemIds">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds);



        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 资源权限范围设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 05.04 获取资源权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>目标资源主键数组</returns>
        [OperationContract]
        string[] GetPermissionScopeTargetIds(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode);

        /// <summary>
        /// 05.05 获取数据权限目标主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="targetResourceId">目标资源主键</param>
        /// <param name="targetResourceCategory">目标资源类别</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>资源主键数组</returns>
        [OperationContract]
        string[] GetPermissionScopeResourceIds(UserInfo userInfo, string resourceCategory, string targetResourceId, string targetResourceCategory, string permissionItemCode);

        /// <summary>
        /// 05.06 授予资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="grantTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantPermissionScopeTargets(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId);

        /// <summary>
        /// 05.07 授予数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceIds">资源主键数组</param>
        /// <param name="targetCategory">目标资源类别</param>
        /// <param name="grantTargetId">目标资源主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int GrantPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId);

        /// <summary>
        /// 05.08 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokePermissionScopeTargets(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId);

        /// <summary>
        /// 05.09 撤销数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceIds">资源主键数组</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="revokeTargetId">目标主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int RevokePermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId);

        /// <summary>
        /// 05.10 清除数据权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId);

        /// <summary>
        /// 05.11 获取用户的某个资源的权限范围(列表资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode);

        /// <summary>
        /// 05.12 获取用户的某个资源的权限范围(树型资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetTreeResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens);
    }
}
