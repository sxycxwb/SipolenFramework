/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-10
 ******************************************************************************/

using System;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PermissionService
    /// 权限判断服务
    /// 
    /// 修改记录
    ///     2014-03-19 XuWangBin V2.8 重构。
    ///		2012-06-12 版本：1.0 XuWangBin 对权限服务进行重构。
    ///		2012-05-12 版本：1.0 XuWangBin 建立。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-05-12</date>
    /// </author> 
    /// </summary>
    public partial class PermissionService : System.MarshalByRefObject, IPermissionService
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 角色权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetRolePermissionItemIds(UserInfo userInfo, string roleId) 获取指定角色操作权限主键数组
        /// <summary>
        /// 获取指定角色操作权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键数组</returns>
        public string[] GetRolePermissionItemIds(UserInfo userInfo, string roleId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetRolePermissionItemIds);           
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RolePermissionManager(dbProvider, userInfo).GetPermissionItemIds(roleId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetRoleIdsByPermissionItemId(UserInfo userInfo, string permissionItemId) 获取角色主键数组通过指定操作权限
        /// <summary>
        /// 获取角色主键数组通过指定操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIdsByPermissionItemId(UserInfo userInfo, string permissionItemId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetRoleIdsByPermissionItemId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
               returnValue = new RolePermissionManager(dbProvider, userInfo).GetRoleIds(permissionItemId);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRolePermissions(UserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds) 批量授予角色的操作权限
        /// <summary>
        /// 批量授予角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRolePermissions(UserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRolePermissions);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (roleIds != null && grantPermissionItemIds != null)
                {
                    returnValue += new RolePermissionManager(dbProvider, userInfo).Grant(roleIds, grantPermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode) 授予指定角色指定的操作权限
        /// <summary>
        /// 授予指定角色指定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键</returns>
        public string GrantRolePermission(UserInfo userInfo, string roleName, string permissionItemCode)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var roleManager = new PiRoleManager(dbProvider, userInfo);
                var roleId = roleManager.GetId(PiRoleTable.FieldRealName, roleName);
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                var permissionItemId = permissionItemManager.GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
                if (!String.IsNullOrEmpty(roleId) && !String.IsNullOrEmpty(permissionItemId))
                {
                    var rolePermissionManager = new RolePermissionManager(dbProvider, userInfo);
                    returnValue = rolePermissionManager.Grant(roleId, permissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantRolePermissionById(UserInfo userInfo, string roleId, string grantPermissionItemId) 授予指定角色特定的操作权限
        /// <summary>
        /// 授予指定角色特定的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantPermissionItemId">授予权限数组</param>
        /// <returns>影响的行数</returns>
        public string GrantRolePermissionById(UserInfo userInfo, string roleId, string grantPermissionItemId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRolePermissionById);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantPermissionItemId != null)
                {
                    returnValue = new RolePermissionManager(dbProvider, userInfo).Grant(roleId, grantPermissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRolePermissions(UserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds) 批量撤消指定角色的操作权限
        /// <summary>
        /// 批量撤消指定角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissions(UserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRolePermissions);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (roleIds != null && revokePermissionItemIds != null)
                {
                    returnValue += new RolePermissionManager(dbProvider, userInfo).Revoke(roleIds, revokePermissionItemIds);
                }
            });

            return returnValue;
        }
        #endregion

        #region public int RevokeRolePermission(BaseUserInfo userInfo, string roleName, string permissionItemCode) 撤消指定角色的操作权限
        /// <summary>
        /// 撤消指定角色的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionItemCode">撤消的操作权限编号</param>
        /// <returns>主键</returns>
        public int RevokeRolePermission(UserInfo userInfo, string roleName, string permissionItemCode)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);           
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var roleId = new PiRoleManager(dbProvider, userInfo).GetId(PiRoleTable.FieldRealName, roleName);
                var permissionItemId = new PiPermissionItemManager(dbProvider, userInfo).GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
                if (!String.IsNullOrEmpty(roleId) && !String.IsNullOrEmpty(permissionItemId))
                {
                    returnValue = new RolePermissionManager(dbProvider, userInfo).Revoke(roleId, permissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRolePermissionById(UserInfo userInfo, string roleId, string revokePermissionItemId) 撤消指定角色的指定操作权限
        /// <summary>
        /// 撤消指定角色的指定操作权限 
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemId">撤消的操作权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissionById(UserInfo userInfo, string roleId, string revokePermissionItemId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRolePermissionById);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokePermissionItemId != null)
                {
                    returnValue += new RolePermissionManager(dbProvider, userInfo).Revoke(roleId, revokePermissionItemId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopeUserIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 获取指定角色在某个权限域(或操作权限编号)下所拥有的用户主键数组
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的用户主键数组 
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>用户主键数组</returns>
        public string[] GetScopeUserIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeUserIdsByRoleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).GetUserIds(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopeRoleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 获取指定角色在某个权限域(或操作权限编号)下所拥有的角色主键数组
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>角色主键数组</returns>
        public string[] GetScopeRoleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeRoleIdsByRoleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).GetRoleIds(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopeOrganizeIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 获取指定角色在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>组织机构主键数组</returns>
        public string[] GetScopeOrganizeIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeOrganizeIdsByRoleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).GetOrganizeIds(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRoleUserScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantUserIds) 授予角色某个权限域的用户范围
        /// <summary>
        /// 授予角色某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantUserIds">授予用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleUserScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantUserIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRoleUserScope);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantUserIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).GrantUsers(roleId, permissionItemCode, grantUserIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRoleUserScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeUserIds) 撤消角色的某个权限域的用户范围
        /// <summary>
        /// 撤消角色的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleUserScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeUserIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRoleUserScope, "角色主键：" + roleId + ",撤消的用户主键数组:" + BusinessLogic.ArrayToList(revokeUserIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokeUserIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeUsers(roleId, permissionItemId, revokeUserIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemId, string[] grantRoleIds) 授予角色的某个权限域的角色范围
        /// <summary>
        /// 授予角色的某个权限域的角色范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantRoleIds">授予角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantRoleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRoleRoleScope, "角色主键：" + roleId + ",授予角色主键数组:" + BusinessLogic.ArrayToList(grantRoleIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantRoleIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).GrantRoles(roleId, permissionItemCode, grantRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeRoleIds) 撤消角色的某个权限域的角色范围
        /// <summary>
        /// 撤消角色的某个权限域的角色范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <param name="revokeRoleIds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleRoleScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeRoleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRoleRoleScope, "角色主键：" + roleId + ",撤消的角色主键数组:" + BusinessLogic.ArrayToList(revokeRoleIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokeRoleIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeRoles(roleId, permissionItemId, revokeRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantOrganizeIds) 授予角色的某个权限域的组织范围
        /// <summary>
        /// 授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限代码</param>
        /// <param name="grantOrganizeIds">授予组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantOrganizeIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRoleOrganizeScope, "角色主键：" + roleId + ",授予组织主键数组:" + BusinessLogic.ArrayToList(grantOrganizeIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantOrganizeIds != null && grantOrganizeIds.Length > 0)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).GrantOrganizes(roleId, permissionItemCode, grantOrganizeIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeOrganizeIds) 撤消角色的某个权限域的组织范围
        /// <summary>
        /// 撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleOrganizeScope(UserInfo userInfo, string roleId, string permissionItemId, string[] revokeOrganizeIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRoleOrganizeScope, "角色主键：" + roleId + ",撤消的组织主键数组:" + BusinessLogic.ArrayToList(revokeOrganizeIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokeOrganizeIds != null && revokeOrganizeIds.Length > 0)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeOrganizes(roleId, permissionItemId, revokeOrganizeIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetScopePermissionItemIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 获取指定角色在某个权限域下所有操作（功能）权限主键数组
        /// <summary>
        /// 获取指定角色在某个权限域下所有操作（功能）权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>操作权限主键数组</returns>
        public string[] GetScopePermissionItemIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopePermissionItemIdsByRoleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).GetPermissionItemIds(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRolePermissionItemScope(UserInfo userInfo, string roleId, string[] grantPermissionItemIds) 授予角色某个权限域的操作权限授权范围
        /// <summary>
        /// 授予角色某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantPermissionItemIds">授予的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRolePermissionItemScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantPermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRolePermissionItemScope, "角色主键：" + roleId + ",授予的操作权限主键数组:" + BusinessLogic.ArrayToList(grantPermissionItemIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantPermissionItemIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).GrantPermissionItemes(roleId, permissionItemCode, grantPermissionItemIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRolePermissionItemScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds) 撤消指定角色某个权限域的操作权限授权范围
        /// <summary>
        /// 撤消指定角色某个权限域的操作权限授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokePermissionItemIds">撤消的操作权限主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRolePermissionItemScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRolePermissionItemScope, "角色主键：" + roleId + ",撤消的操作权限主键数组:" + BusinessLogic.ArrayToList(revokePermissionItemIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokePermissionItemIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokePermissionItems(roleId, permissionItemCode, revokePermissionItemIds);
                }
            });

            return returnValue;
        }
        #endregion

        #region public int ClearRolePermissionScope(UserInfo userInfo, string roleId, string permissionItemCode) 清除指定角色所有权限范围
        /// <summary>
        /// 清除指定角色所有权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>影响的行数</returns>
        public int ClearRolePermissionScope(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearRolePermissionScope, "角色主键：" + roleId);            
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).ClearRolePermissionScope(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int ClearRolePermission(UserInfo userInfo, string id) 清除指定角色的所有权限
        /// <summary>
        /// 清除指定角色的所有权限
        /// 
        /// 1.清除角色的用户归属。
        /// 2.清除角色的模块权限。
        /// 3.清除角色的操作权限。
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        public int ClearRolePermissionByRoleId(UserInfo userInfo, string roleId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_ClearRolePermissionByRoleId, "角色主键：" + roleId);            
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue += new PiUserRoleManager(dbProvider, userInfo).EliminateRoleUser(roleId);
                returnValue += new RolePermissionManager(dbProvider, userInfo).RevokeAll(roleId);
                returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeAll(roleId);
            });
            return returnValue;
        }
        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 角色模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public string[] GetScopeModuleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 获取指定角色在某个权限域下所有模块主键数组
        /// <summary>
        /// 获取指定角色在某个权限域下所有模块主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>模块主键数组</returns>
        public string[] GetScopeModuleIdsByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetScopeModuleIdsByRoleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new RoleScopeManager(dbProvider, userInfo).GetModuleIds(roleId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion

        #region public int GrantRoleModuleScope(UserInfo userInfo, string roleId, string[] grantModuleIds) 授予角色某个权限域的模块授权范围
        /// <summary>
        /// 授予角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int GrantRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] grantModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRoleModuleScope, "角色主键：" + roleId + ",授予模块主键数组:" + BusinessLogic.ArrayToList(grantModuleIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantModuleIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).GrantModules(roleId, permissionItemCode, grantModuleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public string GrantRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId) 授予角色某个权限域的模块授权范围
        /// <summary>
        /// 授予角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        public string GrantRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GrantRoleModuleScope, "角色主键：" + roleId + "，模块主键：" + grantModuleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (grantModuleId != null)
                {
                    returnValue = new RoleScopeManager(dbProvider, userInfo).GrantModule(roleId, permissionItemCode, grantModuleId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds) 撤消指定角色某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRoleModuleScope, "角色主键：" + roleId + ",撤消模块主键数组:" + BusinessLogic.ArrayToList(revokeModuleIds));            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokeModuleIds != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeModules(roleId, permissionItemCode, revokeModuleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId) 撤消指定角色某个权限域的模块授权范围
        /// <summary>
        /// 撤消指定角色某个权限域的模块授权范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        public int RevokeRoleModuleScope(UserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_RevokeRoleModuleScope, "角色主键：" + roleId + "，模块主键：" + revokeModuleId);            
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (revokeModuleId != null)
                {
                    returnValue += new RoleScopeManager(dbProvider, userInfo).RevokeModule(roleId, permissionItemCode, revokeModuleId);
                }
            });
            return returnValue;
        }
        #endregion

    }
}
