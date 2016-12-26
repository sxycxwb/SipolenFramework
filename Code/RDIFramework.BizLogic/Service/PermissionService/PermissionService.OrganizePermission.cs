/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-12 10:15:58
 ******************************************************************************/
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
        /// 组织机构模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetScopeModuleIdsByOrganizeId(UserInfo userInfo, string organizeId, string permissionItemCode) 获取指定组织机构在某个权限域下所有模块主键数组
        /// <summary>
        /// 获取指定组织机构在某个权限域下所有模块主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>组织机构主键数组</returns>
        public string[] GetScopeModuleIdsByOrganizeId(UserInfo userInfo, string organizeId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new OrganizeScopeManage(dbProvider, userInfo, PiPermissionScopeTable.TableName).GetModuleIds(organizeId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] grantModuleIds) 授予组织机构某个权限域的模块授权范围
        /// <summary>
        /// 授予组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] grantModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (grantModuleIds != null)
                {
                    returnValue += new OrganizeScopeManage(dbProvider, userInfo).GrantModules(organizeId, permissionItemCode, grantModuleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId) 授予组织机构某个权限域的模块授权范围
        /// <summary>
        /// 授予组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        public string GrantOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (grantModuleId != null)
                {
                    returnValue = new OrganizeScopeManage(dbProvider, userInfo).GrantModule(organizeId, permissionItemCode, grantModuleId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds) 撤消指定组织机构某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编码</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (revokeModuleIds != null)
                {
                    returnValue += new OrganizeScopeManage(dbProvider, userInfo).RevokeModules(organizeId, permissionItemCode, revokeModuleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId) 撤消指定组织机构某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定组织机构某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizeModuleScope(UserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (revokeModuleId != null)
                {
                    returnValue += new OrganizeScopeManage(dbProvider, userInfo, PiPermissionScopeTable.TableName).RevokeModule(organizeId, permissionItemCode, revokeModuleId);
                }
            });
            return returnValue;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 组织机构权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetOrganizePermissionItemIds(UserInfo userInfo, string organizeId) 获取指定组织机构操作权限主键数组
        /// <summary>
        /// 获取指定组织机构操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>操作权限主键数组</returns>
        public string[] GetOrganizePermissionItemIds(UserInfo userInfo, string organizeId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).GetPermissionItemIds(organizeId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetOrganizeIdsByPermissionItemId(UserInfo userInfo, string permissionItemId) 获取组织机构主键数组通过指定操作权限
        /// <summary>
        /// 获取组织机构主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByPermissionItemId(UserInfo userInfo, string permissionItemId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).GetOrganizeIds(permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds) 授予组织机构操作权限
        /// <summary>
        /// 授予组织机构操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (organizeIds != null && grantPermissionItemIds != null)
                {
                    returnValue += new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).Grant(organizeIds, grantPermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantOrganizePermissionById(UserInfo userInfo, string organizeId, string grantPermissionItemId) 授予指定组织机构指定的操作权限
        /// <summary>
        /// 授予指定组织机构指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantPermissionItemId">授予操作权限主键</param>
        /// <returns>影响的行数</returns>
        public string GrantOrganizePermissionById(UserInfo userInfo, string organizeId, string grantPermissionItemId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantPermissionItemId != null)
                {
                    returnValue = new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).Grant(organizeId, grantPermissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] revokePermissionItemIds) 撤消组织机构操作权限
        /// <summary>
        /// 撤消组织机构操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="revokePermissionItemIds">撤消操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizePermissions(UserInfo userInfo, string[] organizeIds, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (organizeIds != null && revokePermissionItemIds != null)
                {
                    returnValue += new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).Revoke(organizeIds, revokePermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int ClearOrganizePermission(UserInfo userInfo, string id) 清除组织机构权限（清除组织机构的用户归属、模块权限、操作权限）
        /// <summary>
        /// 清除组织机构权限
        /// 
        /// 1.清除组织机构的用户归属。
        /// 2.清除组织机构的模块权限。
        /// 3.清除组织机构的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响的行数</returns>
        public int ClearOrganizePermission(UserInfo userInfo, string organizeId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearOrganizePermission);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue += new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).RevokeAll(organizeId);
                returnValue += new OrganizeScopeManage(dbProvider, userInfo, PiPermissionScopeTable.TableName).RevokeAll(organizeId);
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeOrganizePermissionById(UserInfo userInfo, string organizeId, string revokePermissionItemId) 撤消指定组织机构指定的操作权限
        /// <summary>
        /// 撤消指定组织机构指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokePermissionItemId">撤消操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeOrganizePermissionById(UserInfo userInfo, string organizeId, string revokePermissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeOrganizePermissionById, "组织机构主键：" + organizeId + ",撤消操作权限主键数组:" + revokePermissionItemId);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokePermissionItemId != null)
                {
                    returnValue += new OrganizePermissionManager(dbProvider, userInfo, PiPermissionTable.TableName).Revoke(organizeId, revokePermissionItemId);
                }
            });
            return returnValue;
        }
        #endregion
    }
}
