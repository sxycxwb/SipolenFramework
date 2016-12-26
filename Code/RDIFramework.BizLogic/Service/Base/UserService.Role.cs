using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	public partial class UserService
	{
        #region public DataTable GetDTByRole(UserInfo userInfo, string roleId)
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据权限</returns>
        public DataTable GetDTByRole(UserInfo userInfo, string roleId)
        {
            var dataTable = new DataTable(PiStaffTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDTByRole);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                dataTable = userManager.GetDTByRole(roleId);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public List<PiUserEntity> GetListByRole(UserInfo userInfo, string[] roleIds) 按角色获取用户列表
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色列表</param>
        /// <returns>用户列表</returns>
        public List<PiUserEntity> GetListByRole(UserInfo userInfo, string[] roleIds)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDTByRole);
            var entityList = new List<PiUserEntity>();
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entityList = new PiUserManager(dbProvider, userInfo).GetListByRole(roleIds);
            });
            return entityList;
        }
        #endregion

        #region public DataTable GetRoleDT(UserInfo userInfo) 获取角色列表
        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetRoleDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var roleManager = new PiRoleManager(dbProvider, userInfo);
                // 获取有效的，未必删除的数据，按排序码排序
                string[] names = { PiRoleTable.FieldDeleteMark, PiRoleTable.FieldEnabled };
                Object[] values = { 0, 1 };
                dataTable = roleManager.GetDT(names, values, PiRoleTable.FieldSortCode);
                // 不是超级管理员，不能添加超级管理员
                if (!userInfo.IsAdministrator)
                {
                    foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => dataRow[PiRoleTable.FieldCode].ToString().Equals(DefaultRole.Administrators.ToString())))
                    {
                        dataRow.Delete();
                    }
                    dataTable.AcceptChanges();
                }
                dataTable.TableName = PiUserTable.TableName;
                dataTable.DefaultView.Sort = PiUserTable.FieldSortCode;
            });
            return dataTable;
        }
        #endregion

        #region public bool UserInRole(UserInfo userInfo, string userId, string roleCode)
        /// <summary>
        /// 用户是否在某个角色里的判断
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleCode">角色编号</param>
        /// <returns>存在</returns>
        public bool UserInRole(UserInfo userInfo, string userId, string roleCode)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_UserInRole);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userRoleManager = new PiUserRoleManager(dbProvider, userInfo);
                returnValue = userRoleManager.UserInRole(userId, roleCode);
            });

            return returnValue;
        }
        #endregion

        #region public int SetDefaultRole(UserInfo userInfo, string userId, string roleId) 设置用户的默认角色
        /// <summary>
        /// 设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        public int SetDefaultRole(UserInfo userInfo, string userId, string roleId)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_SetDefaultRole, "用户主键：" + userId + ",角色主键:" + roleId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(roleId))
                {
                    roleId = null;
                }
                returnValue = userManager.SetProperty(userId, PiUserTable.FieldRoleId, roleId);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchSetDefaultRole(UserInfo userInfo, string[] userIds, string roleId) 批量设置默认角色
        /// <summary>
        /// 批量设置默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="roleId">默认角色主键</param>
        /// <returns>影响行数</returns>
        public int BatchSetDefaultRole(UserInfo userInfo, string[] userIds, string roleId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_BatchSetDefaultRole);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.SetProperty(userIds, PiUserTable.FieldRoleId, roleId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetUserRoleIds(UserInfo userInfo, string userId) 获取用户角色列表
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserRoleIds(UserInfo userInfo, string userId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userRoleManager = new PiUserRoleManager(dbProvider, userInfo);
                returnValue = userRoleManager.GetAllRoleIds(userId);
                // returnValue = userRoleManager.GetRoleIds(userId);
            });
            return returnValue;
        }
        #endregion

        #region public string[] GetAllUserRoleIds(UserInfo userInfo, string userId) 获取用户角色列表
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetAllUserRoleIds(UserInfo userInfo, string userId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiUserRoleManager(dbProvider, userInfo).GetAllRoleIds(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int AddUserToRole(UserInfo userInfo, string userId, string[] addRoleIds) 用户添加到角色
        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="addRoleIds">加入角色</param>
        /// <returns>影响的行数</returns>
        public int AddUserToRole(UserInfo userInfo, string userId, string[] addRoleIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_AddUserToRole, "用户主键：" + userId + ",加入角色：" + BusinessLogic.ArrayToList(addRoleIds));

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userRoleManager = new PiUserRoleManager(dbProvider, userInfo);
                if (addRoleIds != null)
                {
                    returnValue += userRoleManager.AddToRole(userId, addRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int RemoveUserFromRole(UserInfo userInfo, string userId, string[] removeRoleIds) 用户从角色中移除
        /// <summary>
        /// 用户从角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="removeRoleIds">移除角色</param>
        /// <returns></returns>
        public int RemoveUserFromRole(UserInfo userInfo, string userId, string[] removeRoleIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_RemoveUserFromRole);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                if (removeRoleIds != null)
                {
                    returnValue += new PiUserRoleManager(dbProvider, userInfo).RemoveFormRole(userId, removeRoleIds);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int ClearUserRole(UserInfo userInfo, string userId) 清除用户归属的角色
        /// <summary>
        /// 清除用户归属的角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int ClearUserRole(UserInfo userInfo, string userId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_ClearUserRole, "用户：" + userId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiUserRoleManager(dbProvider, userInfo).ClearUserRole(userId);
            });
            return returnValue;
        }
        #endregion
	}
}
