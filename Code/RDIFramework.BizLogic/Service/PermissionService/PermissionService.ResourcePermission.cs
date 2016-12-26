/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-12 10:15:58
 ******************************************************************************/
using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PermissionService
    /// 权限判断服务
    /// 
    /// 修改记录
    /// 
    ///		2012-06-12 版本：1.0 EricHu 对权限服务进行重构。
    ///		2012-05-12 版本：1.0 EricHu 建立。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-12</date>
    /// </author> 
    /// </summary>
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 资源权限设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetResourcePermissionItemIds(UserInfo userInfo, string resourceCategory, string resourceId) 获取资源权限主键数组
        /// <summary>
        /// 获取资源权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>操作权限主键数组</returns>
        public string[] GetResourcePermissionItemIds(UserInfo userInfo, string resourceCategory, string resourceId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetResourcePermissionItemIds);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var names = new string[2];
                var values = new string[2];
                names[0] = PiPermissionTable.FieldResourceCategory;
                values[0] = resourceCategory;
                names[1] = PiPermissionTable.FieldResourceId;
                values[1] = resourceId;
                DataTable dataTable = DbCommonLibary.GetDT(dbProvider, PiPermissionTable.TableName, names, values);
                returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionTable.FieldPermissionId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds) 授予资源的权限
        /// <summary>
        /// 授予资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="grantPermissionItemIds">操作权限主键</param>
        /// <returns>影响的行数</returns>
        public int GrantResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantResourcePermission);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantPermissionItemIds != null)
                {
                    var permissionManager = new PiPermissionManager(dbProvider, userInfo);
                    for (int i = 0; i < grantPermissionItemIds.Length; i++)
                    {
                        var resourcePermissionEntity = new PiPermissionEntity
                        {
                            ResourceCategory = resourceCategory,
                            ResourceId = resourceId,
                            PermissionId = grantPermissionItemIds[i],
                            Enabled = 1,
                            DeleteMark = 0
                        };
                        permissionManager.Add(resourcePermissionEntity);
                        returnValue++;
                    }
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds) 撤消资源的权限
        /// <summary>
        /// 撤消资源的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="revokePermissionItemIds">操作权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermission(UserInfo userInfo, string resourceCategory, string resourceId, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeResourcePermission);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokePermissionItemIds != null)
                {
                    var permissionManager = new PiPermissionManager(dbProvider, userInfo);
                    string[] names = new string[3];
                    string[] values = new string[3];
                    names[0] = PiPermissionTable.FieldResourceCategory;
                    values[0] = resourceCategory;
                    names[1] = PiPermissionTable.FieldResourceId;
                    values[1] = resourceId;
                    names[2] = PiPermissionTable.FieldPermissionId;
                    for (int i = 0; i < revokePermissionItemIds.Length; i++)
                    {
                        values[2] = revokePermissionItemIds[i];
                        // returnValue += permissionManager.SetDeleted(names, values);
                        returnValue += permissionManager.Delete(names, values);
                    }
                }
            });
            return returnValue;
        }
        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 资源权限范围设定关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetPermissionScopeTargetIds(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode) 获取资源权限范围主键数组
        /// <summary>
        /// 获取资源权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>目标资源主键数组</returns>
        public string[] GetPermissionScopeTargetIds(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetPermissionScopeTargetIds);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                var permissionItemId = permissionItemManager.GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
                var names = new string[6];
                var values = new object[6];
                names[0] = PiPermissionScopeTable.FieldResourceCategory;
                values[0] = resourceCategory;
                names[1] = PiPermissionScopeTable.FieldResourceId;
                values[1] = resourceId;
                names[2] = PiPermissionScopeTable.FieldPermissionId;
                values[2] = permissionItemId;
                names[3] = PiPermissionScopeTable.FieldTargetCategory;
                values[3] = targetCategory;
                names[4] = PiPermissionScopeTable.FieldDeleteMark;
                values[4] = 0;
                names[5] = PiPermissionScopeTable.FieldEnabled;
                values[5] = 1;
                returnValue = DbCommonLibary.GetIds(dbProvider, PiPermissionScopeTable.TableName, names, values, PiPermissionScopeTable.FieldTargetId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetPermissionScopeResourceIds(UserInfo userInfo, string resourceCategory, string targetId, string targetResourceCategory, string permissionItemCode) 获取数据权限目标主键
        /// <summary>
        /// 获取数据权限目标主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="targetId">目标资源主键</param>
        /// <param name="targetResourceCategory">目标资源类别</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>资源主键数组</returns>
        public string[] GetPermissionScopeResourceIds(UserInfo userInfo, string resourceCategory, string targetId, string targetResourceCategory, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                var permissionItemId = permissionItemManager.GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
                var names = new string[6];
                var values = new object[6];
                names[0] = PiPermissionScopeTable.FieldResourceCategory;
                values[0] = resourceCategory;
                names[1] = PiPermissionScopeTable.FieldTargetId;
                values[1] = targetId;
                names[2] = PiPermissionScopeTable.FieldPermissionId;
                values[2] = permissionItemId;
                names[3] = PiPermissionScopeTable.FieldTargetCategory;
                values[3] = targetResourceCategory;
                names[4] = PiPermissionScopeTable.FieldDeleteMark;
                values[4] = 0;
                names[5] = PiPermissionScopeTable.FieldEnabled;
                values[5] = 1;
                returnValue = DbCommonLibary.GetIds(dbProvider, PiPermissionScopeTable.TableName, names, values, PiPermissionScopeTable.FieldResourceId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId) 授予资源的权限范围
        /// <summary>
        /// 授予资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="grantTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int GrantPermissionScopeTargets(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GrantResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, grantTargetIds, permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId) 授予资源的权限范围
        /// <summary>
        /// 授予资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceIds">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="grantTargetId">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int GrantPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GrantResourcePermissionScopeTarget(resourceCategory, resourceIds, targetCategory, grantTargetId, permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int RevokePermissionScopeTargets(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId) 撤消资源的权限范围
        /// <summary>
        /// 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokePermissionScopeTargets(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).RevokeResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, revokeTargetIds, permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int RevokePermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId) 移除权限范围
        /// <summary>
        /// 移除权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceIds">资源主键</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="revokeTargetId">目标主键</param>
        /// <param name="permissionItemId">操作权限项</param>
        /// <returns>影响行数</returns>
        public int RevokePermissionScopeTarget(UserInfo userInfo, string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).RevokeResourcePermissionScopeTarget(resourceCategory, resourceIds, targetCategory, revokeTargetId, permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int ClearPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId) 撤消资源的权限范围
        /// <summary>
        /// 撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int ClearPermissionScopeTarget(UserInfo userInfo, string resourceCategory, string resourceId, string targetCategory, string permissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearPermissionScopeTarget);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).RevokeResourcePermissionScopeTarget(resourceCategory, resourceId, targetCategory, permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode) 获取用户的某个资源的权限范围
        /// <summary>
        /// 获取用户的某个资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GetResourceScopeIds(userId, targetCategory, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetTreeResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens) 获取用户的某个资源的权限范围(树型资源)
        /// <summary>
        /// 获取用户的某个资源的权限范围(树型资源)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        public string[] GetTreeResourceScopeIds(UserInfo userInfo, string userId, string targetCategory, string permissionItemCode, bool childrens)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GetTreeResourceScopeIds(userId, targetCategory, permissionItemCode, childrens);
            });
            return returnValue;
        }
        #endregion
    }
}
