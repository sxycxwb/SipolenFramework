/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-10
 ******************************************************************************/
using System;
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
    ///		2012-06-12 版本：1.0 XuWangBin 对权限服务进行重构。
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
        /// 用户权限范围判断相关
        /// 按某个权限范围获取特定用户可访问的特定资源（这个权限范围主要指数据权限【如：资源管理权限、资源访问权限等】）
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        #region public DataTable GetUserDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的用户列表
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetUserDTByPermissionScope);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                if (!String.IsNullOrEmpty(permissionItemCode))
                {
                    dataTable = permissionScopeManager.GetUserDT(userInfo.Id, permissionItemCode);
                }
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string[] GetUserIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的用户主键数组
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetUserIdsByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 若权限是空的，直接返回所有数据
                if (!String.IsNullOrEmpty(permissionItemCode))
                {
                    var permissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                    returnValue = permissionScopeManager.GetUserIds(userId, permissionItemCode);
                }
              
            });
            return returnValue;
        }
        #endregion
        
        #region public DataTable GetRoleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的取角色列表
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetRoleDTByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 若权限是空的，直接返回所有数据
                dataTable = userInfo.IsAdministrator || String.IsNullOrEmpty(permissionItemCode)
                    ? new PiRoleManager(dbProvider, userInfo).GetDT(PiRoleTable.FieldDeleteMark, 0,PiRoleTable.FieldSortCode)
                    : new PiPermissionScopeManager(dbProvider, userInfo).GetRoleDT(userInfo.Id, permissionItemCode);
                dataTable.TableName = PiRoleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string[] GetRoleIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的角色主键数组
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetRoleIdsByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                if (!String.IsNullOrEmpty(permissionItemCode))
                {
                    returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GetRoleIds(userId, permissionItemCode);
                }
            });
            return returnValue;
        }
        #endregion
   
        #region public DataTable GetModuleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的模块列表
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        public DataTable GetModuleDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var dataTable = new DataTable(PiModuleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetModuleDTByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiModuleManager(dbProvider, userInfo).GetDTByPermission(userId, permissionItemCode);
                dataTable.TableName = PiModuleTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetPermissionItemDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的操作权限列表(有授权权限的权限列表)
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的操作权限列表(有授权权限的权限列表)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        public DataTable GetPermissionItemDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var dataTable = new DataTable(PiPermissionItemTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetPermissionItemDTByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var permissionItemManager = new PiPermissionItemManager(dbProvider, userInfo);
                var permissionItemId = permissionItemManager.GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
                // 数据库里没有设置可授权的权限项，系统自动增加一个权限配置项
                if (String.IsNullOrEmpty(permissionItemId) && permissionItemCode.Equals("Resource.ManagePermission"))
                {
                    var permissionItemEntity = new PiPermissionItemEntity
                    {
                        Code = "Resource.ManagePermission",
                        FullName = "资源管理范围权限（系统默认）",
                        IsScope = 1,
                        Enabled = 1,
                        AllowDelete = 0
                    };
                    permissionItemManager.AddEntity(permissionItemEntity);
                }
                dataTable = permissionItemManager.GetDTByUser(userId, permissionItemCode);
                dataTable.TableName = PiPermissionItemTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetOrganizeDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的组织机构列表
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的组织机构列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetOrganizeDTByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            var dataTable = new DataTable(PiOrganizeTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetOrganizeDTByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                // 若权限是空的，直接返回所有数据
                if (String.IsNullOrEmpty(permissionItemCode))
                {
                    dataTable = new PiOrganizeManager(dbProvider, userInfo).GetDT();
                    dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
                }
                else
                {
                    //获得组织机构列表
                    dataTable = new PiPermissionScopeManager(dbProvider, userInfo).GetOrganizeDT(string.IsNullOrEmpty(userId) ? userInfo.Id : userId, permissionItemCode);
                    dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
                }
                dataTable.TableName = PiOrganizeTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string[] GetOrganizeIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode) 按某个权限范围获取特定用户可访问的组织机构主键数组
        /// <summary>
        /// 按某个权限范围获取特定用户可访问的组织机构主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIdsByPermissionScope(UserInfo userInfo, string userId, string permissionItemCode)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.PermissionService_GetOrganizeIdsByPermissionScope);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                if (!String.IsNullOrEmpty(permissionItemCode))
                {
                    returnValue = new PiPermissionScopeManager(dbProvider, userInfo).GetOrganizeIds(userId, permissionItemCode);
                }
            });
            return returnValue;
        }
        #endregion

    }
}
