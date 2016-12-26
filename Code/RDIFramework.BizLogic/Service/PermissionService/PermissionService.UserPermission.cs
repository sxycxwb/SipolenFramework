/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-10
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
    ///     2012-07-08 版本: 1.3 EricHu 新增用户对模块的授权范围控制部分。
    ///		2012-06-12 版本：1.0 EricHu 对权限服务进行重构。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-12</date>
    /// </author> 
    /// </summary>
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        #region public string[] GetUserPermissionItemIds(UserInfo userInfo, string userId) 获取指定用户操作权限主键数组
        /// <summary>
        /// 获取指定用户操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>操作权限主键数组</returns>
        public string[] GetUserPermissionItemIds(UserInfo userInfo, string userId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetUserPermissionItemIds);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);
                returnValue = userPermissionManager.GetPermissionItemIds(userId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetUserIdsByPermissionItemId(UserInfo userInfo, string permissionItemId) 获取用户主键数组通过指定操作权限
        /// <summary>
        /// 获取用户主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>用户主键数组</returns>
        public string[] GetUserIdsByPermissionItemId(UserInfo userInfo, string permissionItemId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetUserIdsByPermissionItemId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);
                returnValue = userPermissionManager.GetUserIds(permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantUserPermissions(UserInfo userInfo, string[] userIds, string[] grantPermissionItemIds) 批量授予用户操作权限
        /// <summary>
        /// 批量授予用户操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserPermissions(UserInfo userInfo, string[] userIds, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserPermissions);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);
                
                if (userIds != null && grantPermissionItemIds != null)
                {
                    returnValue += userPermissionManager.Grant(userIds, grantPermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantUserPermissionById(UserInfo userInfo, string userId, string grantPermissionItemId) 授予指定用户指定的操作权限
        /// <summary>
        /// 授予指定用户指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemId">授予操作权限主键</param>
        /// <returns>影响的行数</returns>
        public string GrantUserPermissionById(UserInfo userInfo, string userId, string grantPermissionItemId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserPermissionById);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);
                
                if (grantPermissionItemId != null)
                {
                    returnValue = userPermissionManager.Grant(userId, grantPermissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeUserPermissions(UserInfo userInfo, string[] userIds, string[] revokePermissionItemIds) 批量撤消用户的操作权限
        /// <summary>
        /// 批量撤消用户的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="revokePermissionItemIds">撤消的权限权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissions(UserInfo userInfo, string[] userIds, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserPermissions);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);
               
                if (userIds != null && revokePermissionItemIds != null)
                {
                    returnValue += userPermissionManager.Revoke(userIds, revokePermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeUserPermissionById(UserInfo userInfo, string userId, string revokePermissionItemId) 撤消指定用户指定的操作权限
        /// <summary>
        /// 撤消指定用户指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemId">撤消的操作权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissionById(UserInfo userInfo, string userId, string revokePermissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserPermissionById);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionManager = new UserPermissionManager(dbProvider, userInfo);

                if (revokePermissionItemId != null)
                {
                    returnValue += userPermissionManager.Revoke(userId, revokePermissionItemId);
                }
            });

            return returnValue;
        }
        #endregion

        #region public string[] GetScopeOrganizeIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode) 获取指定用户在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// <summary>
        /// 获取指定用户在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// 如：指定用户可访问或管理那些组织机构数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>组织机构主键数组</returns>
        public string[] GetScopeOrganizeIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeOrganizeIdsByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);
                returnValue = userPermissionScopeManager.GetOrganizeIds(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantUserOrganizeScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantOrganizeIds) 授予用户的某个权限域的组织机构授权范围
        /// <summary>
        /// 授予用户的某个权限域的组织机构授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantOrganizeIds">授予的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserOrganizeScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantOrganizeIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserOrganizeScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (grantOrganizeIds != null)
                {
                    returnValue += userPermissionScopeManager.GrantOrganizes(userId, permissionScopeItemCode, grantOrganizeIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeUserOrganizeScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeOrganizeIds) 撤消用户的某个权限域的组织组织授权范围
        /// <summary>
        /// 撤消用户的某个权限域的组织组织授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限代码</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserOrganizeScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeOrganizeIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserOrganizeScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (revokeOrganizeIds != null)
                {
                    returnValue += userPermissionScopeManager.RevokeOrganizes(userId, permissionScopeItemCode, revokeOrganizeIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetUserScopeUserIds(UserInfo userInfo, string userId, string permissionScopeItemId) 获取指定用户在某个权限域下所有用户主键数组
        /// <summary>
        /// 获取指定用户在某个权限域下所有用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>用户主键数组</returns>
        public string[] GetScopeUserIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeUserIdsByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);
                returnValue = userPermissionScopeManager.GetUserIds(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantUserUserScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantUserIds) 授予用户某个权限域的用户授权范围
        /// <summary>
        /// 授予用户某个权限域的用户授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantUserIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserUserScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantUserIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserUserScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (grantUserIds != null && grantUserIds.Length > 0)
                {
                    returnValue += userPermissionScopeManager.GrantUsers(userId, permissionScopeItemCode, grantUserIds);
                }
            });

            return returnValue;
        }
        #endregion

        #region public int RevokeUserUserScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeUserIds) 撤消用户某个权限域的用户授权范围
        /// <summary>
        /// 撤消用户某个权限域的用户授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserUserScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeUserIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserUserScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (revokeUserIds != null && revokeUserIds.Length > 0)
                {
                    returnValue += userPermissionScopeManager.RevokeUsers(userId, permissionScopeItemCode, revokeUserIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopeRoleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode) 获取指定用户在某个权限域下所有角色主键数组
        /// <summary>
        /// 获取指定用户在某个权限域下所有角色主键数组
        /// 指定用户对那些角色有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetScopeRoleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeRoleIdsByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);
                returnValue = userPermissionScopeManager.GetRoleIds(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantUserRoleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantRoleIds) 授予用户的某个权限域的角色授权范围
        /// <summary>
        /// 授予用户某个权限域的角色授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantRoleIds">授予的角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserRoleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantRoleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserRoleScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (grantRoleIds != null && grantRoleIds.Length > 0)
                {
                    returnValue += userPermissionScopeManager.GrantRoles(userId, permissionScopeItemCode, grantRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeUserRoleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeRoleIds) 撤消用户某个权限域的角色授权范围
        /// <summary>
        /// 撤消用户某个权限域的角色授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeRoleIds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserRoleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeRoleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserRoleScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (revokeRoleIds != null && revokeRoleIds.Length > 0)
                {
                    returnValue += userPermissionScopeManager.RevokeRoles(userId, permissionScopeItemCode, revokeRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopePermissionItemIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode) 获取指定用户在某个权限域下所有操作（功能）权限主键数组
        /// <summary>
        /// 获取指定用户在某个权限域下所有操作（功能）权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>操作权限主键数组</returns>
        public string[] GetScopePermissionItemIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopePermissionItemIdsByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionScope = new UserScopeManager(dbProvider, userInfo);
                returnValue = userPermissionScope.GetPermissionItemIds(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds) 授予用户某个权限域的操作权限授权范围
        /// <summary>
        /// 授予用户某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantPermissionItemIds">授予的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserPermissionItemScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScope = new UserScopeManager(dbProvider, userInfo);

                if (grantPermissionItemIds != null && grantPermissionItemIds.Length > 0)
                {
                    returnValue += userPermissionScope.GrantPermissionItemes(userId, permissionItemCode, grantPermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds) 撤消指定用户某个权限域的操作权限授权范围
        /// <summary>
        /// 撤消指定用户某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserPermissionItemScope(UserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserPermissionItemScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScope = new UserScopeManager(dbProvider, userInfo);

                if (revokePermissionItemIds != null && revokePermissionItemIds.Length > 0)
                {
                    returnValue += userPermissionScope.RevokePermissionItems(userId, permissionItemCode, revokePermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int ClearUserPermissionByUserId(UserInfo userInfo, string userId) 清除指定用户的所有权限
        /// <summary>
        /// 清除指定用户的所有权限
        /// 
        /// 1.清除用户的角色归属。
        /// 2.清除用户的模块权限。
        /// 3.清除用户的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>受影响的行数</returns>
        public int ClearUserPermissionByUserId(UserInfo userInfo, string userId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearUserPermissionByUserId);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new UserPermissionManager(dbProvider, userInfo).ClearUserPermissionByUserId(userId);
            });

            return returnValue;
        }
        #endregion

        #region public int ClearUserPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 清除指定用户所有权限范围
        /// <summary>
        /// 清除指定用户所有权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>受影响的行数</returns>
        public int ClearUserPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearUserPermissionScope);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new UserScopeManager(dbProvider, userInfo);
                returnValue = manager.ClearUserPermissionScope(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetModuleIdsByUserId(UserInfo userInfo, string userId) 获取用户有权限访问的模块
        /// <summary>
        /// 获取用户有权限访问的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>模块主键数组</returns>
        public string[] GetModuleIdsByUserId(UserInfo userInfo, string userId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetModuleDTByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                returnValue = userInfo.IsAdministrator ? moduleManager.GetIds(PiModuleTable.FieldDeleteMark, "0", PiModuleTable.FieldEnabled, "1", PiModuleTable.FieldId) : moduleManager.GetIDsByUser(userId);
            });

            return returnValue;
        }
        #endregion

        #region public DataTable GetModuleDT(UserInfo userInfo) 获得当前用户有权限访问的模块
        /// <summary>
        /// 获得当前用户有权限访问的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>模块数据表</returns>
        public DataTable GetModuleDT(UserInfo userInfo)
        {
            return GetModuleDTByUserId(userInfo, userInfo.Id);
        }
        #endregion

        #region public DataTable GetModuleDTByUserId(UserInfo userInfo, string userId) 获得指定用户有权限访问的模块
        /// <summary>
        /// 获得指定用户有权限访问的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>模块数据表</returns>
        public DataTable GetModuleDTByUserId(UserInfo userInfo, string userId)
        {
            var dataTable = new DataTable(PiModuleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetModuleDTByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var moduleManager = new PiModuleManager(dbProvider, userInfo);
                dataTable = userInfo.IsAdministrator ? moduleManager.GetDT(PiModuleTable.FieldDeleteMark, 0, PiModuleTable.FieldEnabled, 1, PiModuleTable.FieldSortCode) : moduleManager.GetDTByUser(userId);
                dataTable.TableName = PiModuleTable.TableName;

            });

            return dataTable;
        }
        #endregion

        #region public string[] GetScopeModuleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode) 获取指定用户在某个权限域下所有模块主键数组
        /// <summary>
        /// 获取指定用户在某个权限域下所有模块主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>模块主键数组</returns>
        public string[] GetScopeModuleIdsByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeModuleIdsByUserId);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);
                returnValue = userPermissionScopeManager.GetModuleIds(userId, permissionItemCode);
            });

            return returnValue;
        }
        #endregion

        #region public int GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds) 授予用户某个权限域的模块授权范围
        /// <summary>
        /// 授予用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserModuleScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (grantModuleIds != null && grantModuleIds.Length > 0)
                {
                    var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                    returnValue += userPermissionScopeManager.GrantModules(userId, permissionScopeItemCode, grantModuleIds);
                }
            });

            return returnValue;
        }
        #endregion

        #region public string GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId) 授予用户某个权限域的模块授权范围
        /// <summary>
        /// 授予用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        public string GrantUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantUserModuleScope, "用户主键：" + userId + "，模块主键：" + grantModuleId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (grantModuleId != null)
                {
                    returnValue = userPermissionScopeManager.GrantModule(userId, permissionScopeItemCode, grantModuleId);
                }
            });

            return returnValue;
        }
        #endregion

        #region public int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId) 撤消指定用户某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserModuleScope, "用户主键：" + userId + "，模块主键：" + revokeModuleId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (revokeModuleId != null)
                {
                    returnValue += userPermissionScopeManager.RevokeModule(userId, permissionScopeItemCode, revokeModuleId);
                }
            });

            return returnValue;
        }
        #endregion

        #region public int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds) 撤消指定用户某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定用户某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionScopeItemCode">操作权限编号</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeUserModuleScope(UserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeUserModuleScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userPermissionScopeManager = new UserScopeManager(dbProvider, userInfo);

                if (revokeModuleIds != null && revokeModuleIds.Length > 0)
                {
                    returnValue = userPermissionScopeManager.RevokeModules(userId, permissionScopeItemCode, revokeModuleIds);
                }
            });
            return returnValue;
        }
        #endregion

    }
}
