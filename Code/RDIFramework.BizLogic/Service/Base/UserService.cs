//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
	/// UserService
	/// 用户服务层
	/// 
	/// 修改记录
	///     2016-04-06 EricHu V3.0 删除用户一并删除用户所拥有的角色、权限等。
    ///     2015-12-09 EricHu V3.0 新增GetCompanyUser、GetDepartmentUser服务。
    ///     2015-06-08 EricHu V3.0 增加两个List<PiUserEntity>接口服务。
    ///     2014-05-30 EricHu V2.8 增加 GetUserPageDTByDepartment 根据部门查询用户分页列表。
	///     2014-04-02 EricHu V2.8 全面重构。
    ///     2013-05-18 版本: 2.5 EricHu 修改“GetDT”方法，由原来的只得到有效用户，修改为现在的可得到逻辑删除外的用户。
    ///		2012-03-02 版本：1.0 EricHu 建立UserService。
	///		
	/// 版本：3.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public partial class UserService : System.MarshalByRefObject, IUserService
	{
        private readonly string serviceName = RDIFrameworkMessage.UserService;

        #region public bool Exists(UserInfo userInfo, string[] fieldNames, object[] fieldValues)
        /// <summary>
        /// 用户名是否重复
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fieldNames">字段名</param>
        /// <param name="fieldValues">字段值</param>
        /// <returns>已存在</returns>
        public bool Exists(UserInfo userInfo, string[] fieldNames, object[] fieldValues)
        {
            bool returnValue = false;

            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider);
                returnValue = userManager.Exists(fieldNames, fieldValues);   
            });
            return returnValue;
        }
        #endregion

        #region public string AddUser(IDbProvider dbProvider, UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddUser(IDbProvider dbProvider, UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            var userManager = new PiUserManager(dbProvider, userInfo);
            returnValue = userManager.Add(userEntity, out statusCode);
            statusMessage = userManager.GetStateMessage(statusCode);

            LogManager.Instance.Add(dbProvider, userInfo, this.serviceName, RDIFrameworkMessage.UserService_AddUser, MethodBase.GetCurrentMethod());

            // 自己不用给自己发提示信息，这个提示信息是为了提高工作效率的，还是需要审核通过的，否则垃圾信息太多了
            if (userEntity.Enabled == 0 && statusCode.Equals(StatusCode.OKAdd.ToString()))
            {
                // 不是系统管理员添加
                if (!userInfo.IsAdministrator)
                {
                    // 给超级管理员群组发信息
                    var roleManager = new PiRoleManager(dbProvider, userInfo);
                    string[] roleIds = roleManager.GetIds(PiRoleTable.FieldCode, "Administrators", PiRoleTable.FieldId);
                    string[] userIds = userManager.GetIds(PiUserTable.FieldCode, "Administrator", PiUserTable.FieldId);
                    // 发送请求审核的信息
                    var messageEntity = new CiMessageEntity
                    {
                        Id = BusinessLogic.NewGuid(),
                        FunctionCode = MessageFunction.WaitForAudit.ToString(),
                        ReceiverId = DefaultRole.Administrator.ToString(),
                        MSGContent =userInfo.RealName + "(" + userInfo.IPAddress + ")" + RDIFrameworkMessage.UserService_Application + userEntity.RealName + RDIFrameworkMessage.UserService_Check,
                        IsNew = 1,
                        ReadCount = 0,
                        Enabled = 1,
                        DeleteMark = 0
                    };

                    var messageManager = new CiMessageManager(dbProvider, userInfo);
                    messageManager.BatchSend(userIds, null, roleIds, messageEntity, false);
                }
            }
            return returnValue;
        }
        #endregion

        #region public string AddUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string AddUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_AddUser);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = AddUser(dbProvider, userInfo, userEntity, out returnCode, out returnMessage);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public PiUserEntity GetEntity(UserInfo userInfo, string id)
        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public PiUserEntity GetEntity(UserInfo userInfo, string id)
        {
            PiUserEntity userEntity = null;
            //var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetEntity);
            //使用频率比较高，不用每次都做日志记录，提供效率
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                userEntity = new PiUserManager(dbProvider, userInfo).GetEntity(id);
                if (!string.IsNullOrEmpty(userEntity.RoleId))
                {
                    userEntity.RoleName = new PiRoleManager(dbProvider, userInfo).GetEntity(userEntity.RoleId).RealName;
                }
            });

            return userEntity;
        }
        #endregion

        #region public PiUserEntity GetEntityByUserName(UserInfo userInfo, string userName) 根据用户名获取用户实体
        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名称</param>
        /// <returns>用户实体</returns>
        public PiUserEntity GetEntityByUserName(UserInfo userInfo, string userName)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetEntity);
            PiUserEntity userEntity = null;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                userEntity = new PiUserManager(dbProvider, userInfo).GetEntityByUserName(userName);
            });
            return userEntity;
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                string[] names = { PiUserTable.FieldDeleteMark };
                Object[] values = { 0 };
                dataTable = new PiUserManager(dbProvider, userInfo).GetDT(names, values, PiUserTable.FieldSortCode);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo, string searchValue, string departmentId, string roleId,out int recordCount, int pageIndex = 0, int pageSize = 50, string sort = null) 获取用户分页列表
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(UserInfo userInfo, string searchValue, string departmentId, string roleId, out int recordCount, int pageIndex = 0, int pageSize = 50, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_Search);
            int myrecordCount = 0;
            var dt = new DataTable(PiUserTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbHelper) =>
            {
                var userManager = new PiUserManager(dbHelper, userInfo);
                dt = userManager.GetDTByPage(searchValue, departmentId, roleId, out myrecordCount, pageIndex, pageSize, order);
                dt.TableName = PiUserTable.TableName;
            });
            recordCount = myrecordCount;
            return dt;
        }
        #endregion

        #region public List<PiUserEntity> GetList(UserInfo userInfo) 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public List<PiUserEntity> GetList(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_Search);
            List<PiUserEntity> entityList = new List<PiUserEntity>();
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbHelper) =>
            {
                var userManager = new PiUserManager(dbHelper, userInfo);
                // 获取允许登录列表
                var parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0)
                };
                entityList = userManager.GetList<PiUserEntity>(parameters, PiUserTable.FieldSortCode);
            });
            return entityList;
        }
        #endregion

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids) 获取用户列表
        /// <summary>
        /// 按主键获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDTByIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                dataTable = userManager.GetDT(PiUserTable.FieldId, ids, PiUserTable.FieldSortCode);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public List<PiUserEntity> GetListByIds(UserInfo userInfo, string[] ids) 获取用户列表
        /// <summary>
        /// 按主键获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        public List<PiUserEntity> GetListByIds(UserInfo userInfo, string[] ids)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDTByIds);
            var entityList = new List<PiUserEntity>();
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbHelper) =>
            {
                var userManager = new PiUserManager(dbHelper, userInfo);
                entityList = userManager.GetList<PiUserEntity>(PiUserTable.FieldId, ids, PiUserTable.FieldSortCode);
            });
            return entityList;
        }
        #endregion

        #region public int UpdateUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int UpdateUser(UserInfo userInfo, PiUserEntity userEntity, out string statusCode, out string statusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_UpdateUser);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.Update(userEntity, out returnCode);
                returnMessage = userManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable Search(UserInfo userInfo, string searchValue, string auditStates, string[] roleIds) 查询用户
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="searchValue">查询</param>
        /// <param name="auditStates">有效</param>
        /// <param name="roleIds">用户角色</param>
        /// <returns>数据表</returns>
        public DataTable Search(UserInfo userInfo, string searchValue, string auditStates, string[] roleIds)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiUserManager(dbProvider, userInfo).Search(string.Empty, searchValue, roleIds, null, auditStates, string.Empty);
                dataTable.TableName = PiUserTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int SetUserAuditStates(UserInfo userInfo, string[] ids, AuditStatus auditStates) 设置用户审核状态
        /// <summary>
        /// 设置用户审核状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="auditStates">审核状态</param>
        /// <returns>影响行数</returns>
        public int SetUserAuditStates(UserInfo userInfo, string[] ids, AuditStatus auditStates)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_SetUserAuditStates);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.SetProperty(ids, PiUserTable.FieldAuditStatus, auditStates.ToString());
                // 被审核通过
                if (auditStates == AuditStatus.AuditPass)
                {
                    returnValue = userManager.SetProperty(ids, PiUserTable.FieldEnabled, 1);
                    // returnValue = userManager.SetProperty(ids, BaseUserEntity.FieldAuditStatus, StatusCode.UserIsActivate.ToString());
                }
                // 被退回
                if (auditStates == AuditStatus.AuditReject)
                {
                    returnValue = userManager.SetProperty(ids, PiUserTable.FieldEnabled, 0);
                    returnValue = userManager.SetProperty(ids, PiUserTable.FieldAuditStatus, StatusCode.UserLocked.ToString());
                }
            });
            return returnValue;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 单个删除
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_Delete, "主键：" + id);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.Delete(id);
                //已经被删除的用户的UserId设置为Null
                userManager.CheckUserStaff();
                returnValue += new UserPermissionManager(dbProvider, userInfo).ClearUserPermissionByUserId(id);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_BatchDelete, "主键数组：" + BusinessLogic.ArrayToList(ids));

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.Delete(ids);
                // 用户已经被删除的用户的UserId设置为Null，说白了，是需要整理数据
                userManager.CheckUserStaff();
                if (ids != null && ids.Length > 0)
                {
                    returnValue += ids.Sum(userId => new UserPermissionManager(dbProvider, userInfo).ClearUserPermissionByUserId(userId));
                }
            });
            return returnValue;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批量打删除标志
        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_SetDeleted);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiUserManager(dbProvider, userInfo).SetDeleted(ids);
                if (ids != null && ids.Length > 0)
                {
                    returnValue += ids.Sum(userId => new UserPermissionManager(dbProvider, userInfo).ClearUserPermissionByUserId(userId));
                }
            });
            return returnValue;
        }
        #endregion

        #region public int BatchSave(UserInfo userInfo, var dataTable) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var userManager = new PiUserManager(dbProvider, userInfo);
                returnValue = userManager.BatchSave(dataTable);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetCompanyUser(UserInfo userInfo) 得到当前用户所在公司的用户列表
        /// <summary>
        /// 得到当前用户所在公司的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        public DataTable GetCompanyUser(UserInfo userInfo)
        {
            DataTable result = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetCompanyUser);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(dbProvider, userInfo);
                string commandText = "SELECT " + PiUserTable.FieldId + "," + PiUserTable.FieldRealName + "," + PiUserTable.FieldCompanyName + "," + PiUserTable.FieldDepartmentName + "  FROM " + PiUserTable.TableName + " WHERE " + PiUserTable.FieldCompanyName + " = '" + userInfo.CompanyName + "' AND " + PiUserTable.FieldDeleteMark + " = 0  AND " + PiUserTable.FieldEnabled + " = 1   AND " + PiUserTable.FieldIsVisible + " = 1  ORDER BY " + PiUserTable.FieldSortCode;
                result = manager.Fill(commandText);
                result.TableName = PiUserTable.TableName;
            });
            return result;
        }
        #endregion

        #region public DataTable GetDepartmentUser(UserInfo userInfo) 得到当前用户所在部门的用户列表
        /// <summary>
        /// 得到当前用户所在部门的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDepartmentUser(UserInfo userInfo)
        {
            DataTable result = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDepartmentUser);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(dbProvider, userInfo);
                string commandText = "SELECT " + PiUserTable.FieldId + "," + PiUserTable.FieldRealName + "," + PiUserTable.FieldCompanyName + "," + PiUserTable.FieldDepartmentName + "  FROM " + PiUserTable.TableName + " WHERE " + PiUserTable.FieldCompanyName + " = '" + userInfo.CompanyName + "' AND " + PiUserTable.FieldDepartmentName + " = '" + userInfo.DepartmentName + "' AND " + PiUserTable.FieldDeleteMark + " = 0  AND " + PiUserTable.FieldEnabled + " = 1   AND " + PiUserTable.FieldIsVisible + " = 1  ORDER BY " + PiUserTable.FieldSortCode;
                result = manager.Fill(commandText);
                result.TableName = PiUserTable.TableName;
            });
            return result;
        }
        #endregion

        #region public DataTable GetDepartmentUser(UserInfo userInfo, string departmentId, bool containChildren) 得到指定部门包含的用户列表
        /// <summary>
        /// 得到指定部门包含的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">是否包含子部门</param>
        /// <returns>数据表</returns>
        public DataTable GetDepartmentUser(UserInfo userInfo, string departmentId, bool containChildren)
        {
            var result = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDepartmentUser);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(departmentId))
                {
                    result = manager.GetDT(new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0), 200, PiUserTable.FieldSortCode);
                }
                else if (containChildren)
                {
                    result = manager.GetChildrenUsers(departmentId);
                }
                else
                {
                    result = manager.GetDataTableByDepartment(departmentId);
                }

            });
            return result;
        }
        #endregion

        #region  public List<PiUserEntity> GetListByDepartment(UserInfo userInfo, string departmentId, bool containChildren) 得到指定部门包含的用户列表
        /// <summary>
        /// 得到指定部门包含的用户列表
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">是否包含子部门</param>
        /// <returns>数据表</returns>
        public List<PiUserEntity> GetListByDepartment(UserInfo userInfo, string departmentId, bool containChildren)
        {
            List<PiUserEntity> entityList = new List<PiUserEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.UserService_GetDepartmentUser);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiUserManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(departmentId))
                {
                    entityList = manager.GetList<PiUserEntity>(new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0), 200, PiUserTable.FieldSortCode);
                }
                else if (containChildren)
                {
                    entityList = manager.GetChildrenUserList(departmentId);
                }
                else
                {
                    entityList = manager.GetListByDepartment(departmentId);
                }
            });
            return entityList;
        }
        #endregion

    }
}
