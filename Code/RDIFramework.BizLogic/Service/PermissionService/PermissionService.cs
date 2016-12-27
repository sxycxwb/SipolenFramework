/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-12 10:15:58
 ******************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	/// <summary>
    /// PermissionService
    /// 权限判断服务
	/// 
	/// 修改记录
	/// 
    ///     2013-11-28 版本: 2.7 XuWangBin 取消权限判断时的日志记录，提高效率。 
	///		2012-05-12 版本：1.0 XuWangBin 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2012-05-12</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public partial class PermissionService : System.MarshalByRefObject, IPermissionService
	{
        private readonly string serviceName = RDIFrameworkMessage.PermissionService;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限判断相关(需要实现对外调用)
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public bool IsInRole(UserInfo userInfo, string userId, string roleName) 指定用户是否在指定的角色里
        /// <summary>
        /// 指定用户是否在指定的角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleName">角色名称</param>
        /// <returns>指定用户是否在指定角色里，true：是，false：否</returns>
        public bool IsInRole(UserInfo userInfo, string userId, string roleName)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_IsInRole);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 先获得角色主键
                string roleCode = new PiRoleManager(dbProvider, userInfo).GetProperty(PiRoleTable.FieldRealName, roleName, PiRoleTable.FieldCode);
                // 判断用户的默认角色
                if (!string.IsNullOrEmpty(roleCode))
                {
                    returnValue = new PiUserRoleManager(dbProvider, userInfo).UserInRole(userId, roleCode);
                }
            });

            return returnValue;
        }
        #endregion

        #region public bool IsAuthorized(UserInfo userInfo, string permissionItemCode, string permissionItemName = null) 当前用户是否有相应的权限
        /// <summary>
        /// 当前用户是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        public bool IsAuthorized(UserInfo userInfo, string permissionItemCode, string permissionItemName = null)
        {
            return IsAuthorizedByUserId(userInfo, userInfo.Id, permissionItemCode, permissionItemName);
        }
        #endregion

        #region public bool IsAuthorizedByUserId(UserInfo userInfo, string userId, string permissionItemCode, string permissionItemName = null) 指定用户是否有相应的操作权限
        /// <summary>
        /// 指定用户是否有相应的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        public bool IsAuthorizedByUserId(UserInfo userInfo, string userId, string permissionItemCode, string permissionItemName = null)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                if (string.IsNullOrEmpty(userId))
                {
                    userId = userInfo.Id;
                }

                #if (!DEBUG)
                // 是超级管理员,就不用继续判断权限了
                returnValue = new PiUserManager(dbProvider, userInfo).IsAdministrator(userId);
                #endif
                if (!returnValue)
                {
                    returnValue = new PiPermissionManager(dbProvider, userInfo).CheckPermissionByUser(userId, permissionItemCode, permissionItemName);
                }
            });
            return returnValue;
        }
        #endregion

        #region public bool IsAuthorizedByRoleId(UserInfo userInfo, string roleId, string permissionItemCode) 指定角色是否有相应的权限
        /// <summary>
        /// 指定角色是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        public bool IsAuthorizedByRoleId(UserInfo userInfo, string roleId, string permissionItemCode)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_IsAuthorizedByRoleId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 是超级管理员,就不用继续判断权限了
                returnValue = roleId.Equals("Administrators");
                if (!returnValue)
                {
                    returnValue = new PiPermissionManager(dbProvider, userInfo).CheckPermissionByRole(roleId, permissionItemCode);
                }
            });
            return returnValue;
        }
        #endregion

        #region public bool IsAdministrator(UserInfo userInfo) 当前用户是否超级管理员
        /// <summary>
        /// 当前用户是否超级管理员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>当前用户是否为超级管理员，true：是，false：否</returns>
        public bool IsAdministrator(UserInfo userInfo)
        {
            return IsAdministratorByUserId(userInfo, userInfo.Id);
        }
        #endregion

        #region public bool IsAdministratorByUserId(UserInfo userInfo, string userId) 指定用户是否超级管理员
        /// <summary>
        /// 指定用户是否超级管理员
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>是否超级管理员，true：是，false：否</returns>
        public bool IsAdministratorByUserId(UserInfo userInfo, string userId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_IsAdministratorByUserId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiUserManager(dbProvider, userInfo).IsAdministrator(userId);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetPermissionDT(UserInfo userInfo) 获得当前用户的所有权限列表
        /// <summary>
        /// 获得当前用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>权限数据表</returns>
        public DataTable GetPermissionDT(UserInfo userInfo)
        {
            return GetPermissionDTByUserId(userInfo, userInfo.Id);
        }
        #endregion

        #region public DataTable GetPermissionDTByUserId(UserInfo userInfo, string userId) 获得指定用户的所有权限列表
        /// <summary>
        /// 获得指定用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>权限数据表</returns>
        public DataTable GetPermissionDTByUserId(UserInfo userInfo, string userId)
        {
            var dataTable = new DataTable(PiPermissionItemTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetPermissionDTByUserId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 是否超级管理员
                dataTable = new PiUserManager(dbProvider, userInfo).IsAdministrator(userId) ? new PiPermissionItemManager(dbProvider, userInfo).GetDT() : new PiPermissionManager(dbProvider).GetPermissionByUser(userId);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion     

        #region public bool IsModuleAuthorized(UserInfo userInfo, string moduleCode) 当前用户是否对某个模块有相应的权限
        /// <summary>
        /// 当前用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        public bool IsModuleAuthorized(UserInfo userInfo, string moduleCode)
        {
            return IsModuleAuthorizedByUserId(userInfo, userInfo.Id, moduleCode);
        }
        #endregion

        #region public bool IsModuleAuthorizedByUserId(UserInfo userInfo, string userId, string moduleCode) 指定用户是否对某个模块有相应的权限
        /// <summary>
        /// 指定用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限，true：是，false：否</returns>
        public bool IsModuleAuthorizedByUserId(UserInfo userInfo, string userId, string moduleCode)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_IsModuleAuthorizedByUserId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 是否超级管理员
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.IsAdministrator(userId);
                if (!returnValue)
                {
                    var dataTable = new PiModuleManager(dbProvider, userInfo).GetDTByUser(userId);
                    if (dataTable.Rows.Cast<DataRow>().Any(dataRow => dataRow[PiModuleTable.FieldCode].ToString().Equals(moduleCode,StringComparison.OrdinalIgnoreCase)))
                    {
                        returnValue = true;
                    }
                }
            });
            return returnValue;
        }
        #endregion

        #region public bool IsModuleAuthorizedByUserId(UserInfo userInfo, string userId, string moduleCode, string permissionItemCode) 某个用户是否对某个模块有相应的权限

	    /// <summary>
	    /// 某个用户是否对某个模块有相应的权限
	    /// </summary>
	    /// <param name="userInfo">用户</param>
	    /// <param name="userId">用户主键</param>
	    /// <param name="moduleCode">模块编号</param>
	    /// <param name="permissionItemCode"></param>
	    /// <returns>是否有权限，true：是，false：否</returns>
	    public bool IsModuleAuthorizedByUserId(UserInfo userInfo, string userId, string moduleCode, string permissionItemCode)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_IsModuleAuthorizedByUserId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 是否超级管理员
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.IsAdministrator(userId);
                if (!returnValue)
                {
                    returnValue = new PiPermissionScopeManager(dbProvider).IsModuleAuthorized(userId, moduleCode, permissionItemCode);
                }
            });
            return returnValue;
        }
        #endregion

        #region public PermissionScope GetPermissionScopeByUserId(UserInfo userInfo, string userId, string permissionItemCode) 获得指定用户的数据权限范围
        /// <summary>
        /// 获得指定用户的数据权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">数据权限编号</param>
        /// <returns>数据权限范围</returns>
        public PermissionScope GetPermissionScopeByUserId(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var returnValue = PermissionScope.None;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetPermissionScopeByUserId);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GetUserPermissionScope(userId, permissionItemCode);
            });
            return returnValue;
        }
        #endregion
	}
}
