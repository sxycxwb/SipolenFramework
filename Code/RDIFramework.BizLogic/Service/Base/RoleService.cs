//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	/// <summary>
	/// RoleService
	/// 角色管理服务层
	/// 
	/// 修改记录
	/// 
    ///     2012-06-08 EricHu 重新组织RoleService
	///		2012-03-02 版本：1.0 EricHu 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class RoleService : System.MarshalByRefObject, IRoleService
	{
		private readonly string serviceName = RDIFrameworkMessage.RoleService;

        #region public string Add(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage):新增实体
        /// <summary>
		/// 新增实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>受影响的行数</returns>
		public string Add(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage)
		{
            var returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiRoleManager(dbProvider, userInfo);
                returnValue = manager.Add(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public int Update(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage):更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响的行数</returns>
        public int Update(UserInfo userInfo, PiRoleEntity entity, out string statusCode, out string statusMessage)
        {
            int returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_Update);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new PiRoleManager(dbProvider, userInfo);
                returnValue = manager.UpdateEntity(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo):取得角色列表
        /// <summary>
        /// 取得角色列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <returns>数据表</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiRoleManager(dbProvider, userInfo).GetDT(PiRoleTable.FieldDeleteMark, 0, PiRoleTable.FieldSortCode);
                dataTable.TableName = PiRoleTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public List<PiRoleEntity> GetList(UserInfo userInfo):取得角色列表
        /// <summary>
        /// 取得角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public List<PiRoleEntity> GetList(UserInfo userInfo)
        {
            List<PiRoleEntity> list = new List<PiRoleEntity>();
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
                };
                list = new PiRoleManager(dbProvider, userInfo).GetList<PiRoleEntity>(parameters, PiRoleTable.FieldSortCode);
            });
            return list;
        }
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取角色分页列表
        /// <summary>
        /// 获取角色分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">所有角色数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "")
        {
            var dataTable = new DataTable(PiRoleTable.TableName);
            var returnRecordCount = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new PiRoleManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional = PiRoleTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    whereConditional += " AND " + PiRoleTable.FieldDeleteMark + " = 0 ";
                }

                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = PiRoleTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public PiRoleEntity GetEntity(UserInfo userInfo, string id):取得实体
        /// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主键</param>
		/// <returns>实体</returns>
		public PiRoleEntity GetEntity(UserInfo userInfo, string id)
		{
            PiRoleEntity entity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new PiRoleManager(dbProvider, userInfo).GetEntity(id);
            });
			return entity;
		}
        #endregion

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids):根据主键数组得到角色信息
        /// <summary>
		/// 根据主键数组得到角色信息
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
			var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetRoleUserIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiRoleManager(dbProvider, userInfo).GetDT(PiRoleTable.FieldId, ids, PiRoleTable.FieldSortCode);
                dataTable.TableName = PiRoleTable.TableName;
            });
          
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values):根据条件获得角色列表
	    /// <summary>
	    /// 根据条件获得角色列表
	    /// </summary>
	    /// <param name="userInfo">用户</param>
	    /// <param name="names">字段</param>
	    /// <param name="values">值</param>
	    /// <returns>数据表</returns>
	    public DataTable GetDTByValues(UserInfo userInfo, string[] names, string[] values)
		{
			var dataTable = new DataTable(PiRoleTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDTByValues);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new PiRoleManager(dbProvider, userInfo).GetDT(names, values);
                dataTable.TableName = PiRoleTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool showUser = true) 按组织机构获取角色列表
        /// <summary>
        /// 按组织机构获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="showUser">显示用户</param>
        /// <returns>角色列表</returns>
	    public DataTable GetDTByOrganize(UserInfo userInfo, string organizeId, bool showUser = true)
	    {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetDTByOrganize);
            var dtRole = new DataTable(PiRoleTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                // 获得角色列表
                var manager = new PiRoleManager(dbProvider, userInfo);
                dtRole = manager.GetDTByOrganize(organizeId);
                PiUserManager userManager = new PiUserManager(dbProvider, userInfo);
                if (showUser)
                {
                    DataTable dataTableUser = userManager.GetDT();
                    if (!dtRole.Columns.Contains("Users"))
                    {
                        dtRole.Columns.Add("Users");
                    }
                    // 友善的显示属于多个角色的功能
                    string userName = string.Empty;
                    foreach (DataRow dr in dtRole.Rows)
                    {
                        userName = string.Empty;
                        // 获取所在用户
                        string[] userIds = userManager.GetUserIdsInRole(dr[PiRoleTable.FieldId].ToString());
                        if (userIds != null)
                        {
                            userName = userIds.Aggregate(userName, (current, t) => current + BusinessLogic.GetProperty(dataTableUser, t, PiRoleTable.FieldRealName) + ", ");
                        }
                        if (!string.IsNullOrEmpty(userName))
                        {
                            userName = userName.Substring(0, userName.Length - 2);
                            // 设置用户的名称
                            dr["Users"] = userName;
                        }
                    }
                    dtRole.AcceptChanges();
                }
                dtRole.TableName = PiRoleTable.TableName;
            });
            return dtRole;
	    }
        #endregion

        #region public DataTable GetApplicationRole(UserInfo userInfo) 获取业务角色列表
        /// <summary>
        /// 获取业务角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>业务角色列表</returns>
        public DataTable GetApplicationRole(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo
                , MethodBase.GetCurrentMethod()
                , this.serviceName
                , RDIFrameworkMessage.RoleService_GetDT);
            var dt = new DataTable(PiRoleTable.TableName);
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, (dbProvider) =>
            {
                // 获得角色列表
                var manager = new PiRoleManager(dbProvider, userInfo, PiRoleTable.TableName);
                var parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiRoleTable.FieldCategory, "ApplicationRole"),
                    new KeyValuePair<string, object>(PiRoleTable.FieldDeleteMark, 0)
                };
                dt = manager.GetDT(parameters, PiRoleTable.FieldSortCode);
                dt.TableName = PiRoleTable.TableName;
            });
            return dt;
        }
        #endregion

        #region public int BatchSave(UserInfo userInfo, List<PiRoleEntity> entites):批量保存角色数据
        /// <summary>
		/// 批量保存角色数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entites">实体列表</param>
		/// <returns>影响的行数</returns>
		public int BatchSave(UserInfo userInfo, List<PiRoleEntity> entites)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_BatchSave);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiRoleManager(dbProvider, userInfo).BatchSave(entites);
            });

			return returnValue;
		}
        #endregion

        #region public int Delete(UserInfo userInfo, string id):物理刪除角色
        /// <summary>
        /// 物理刪除角色
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主键</param>
		/// <returns>受影响的行数</returns>
		public int Delete(UserInfo userInfo, string id)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_Delete, "主键：" + id);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiRoleManager(dbProvider, userInfo).Delete(id);
            });

			return returnValue;
		}
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids):批量物理删除角色
        /// <summary>
		/// 批量物理删除角色
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响的行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_BatchDelete);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiRoleManager(dbProvider, userInfo).BatchDelete(ids);    
            });
			return returnValue;
		}
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids):批量逻辑删除角色
        /// <summary>
        ///  批量逻辑删除角色
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响的行数</returns>
		public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_SetDeleted);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                //TODO:此处还应该把角色相应的权限，所拥有的用户等也做统一处理。
                returnValue = new PiRoleManager(dbProvider, userInfo).SetDeleted(ids);
            });

			return returnValue;
		}
        #endregion

        #region public int EliminateRoleUser(UserInfo userInfo, string roleId):移除角色用户关联
        /// <summary>
        /// 移除角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int EliminateRoleUser(UserInfo userInfo, string roleId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_EliminateRoleUser, "角色主键：" + roleId);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiUserRoleManager(dbProvider, userInfo).EliminateRoleUser(roleId);
            });

            return returnValue;
        }
        #endregion

        #region public string[] GetRoleUserIds(UserInfo userInfo, string roleId):获得角色中的用户主键
        /// <summary>
        /// 获得角色中的用户主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>用户主键</returns>
        public string[] GetRoleUserIds(UserInfo userInfo, string roleId)
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_GetRoleUserIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiUserRoleManager(dbProvider, userInfo).GetUserIds(roleId);
            });

            return returnValue;
        }
        #endregion

        #region ublic int AddUserToRole(UserInfo userInfo, string roleId, string[] addUserIds):用户添加到角色
        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="addUserIds">用户主键数组</param>
        /// <returns>影响行数</returns>
        public int AddUserToRole(UserInfo userInfo, string roleId, string[] addUserIds)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_AddUserToRole);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (addUserIds != null)
                {
                    returnValue += new PiUserRoleManager(dbProvider, userInfo).AddToRole(addUserIds, roleId);
                }
            });

            return returnValue;
        }
        #endregion

        #region  public int RemoveUserFromRole(UserInfo userInfo, string roleId, string[] userIds):将用户从角色中移除
        /// <summary>
        /// 将用户从角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="userIds">用户主键</param>
        /// <returns>影响行数</returns>
        public int RemoveUserFromRole(UserInfo userInfo, string roleId, string[] userIds)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_RemoveUserFromRole);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                if (userIds != null)
                {
                    returnValue += new PiUserRoleManager(dbProvider, userInfo).RemoveFormRole(userIds, roleId);
                }
            });
            return returnValue;
        }
        #endregion

        #region public int ClearRoleUser(UserInfo userInfo, string roleId) 清除角色用户关联
        /// <summary>
        /// 清除角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int ClearRoleUser(UserInfo userInfo, string roleId)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_ClearRoleUser, "角色主键：" + roleId);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new PiUserRoleManager(dbProvider, userInfo).ClearRoleUser(roleId);
            });
            return returnValue;
        }
        #endregion

        #region public int SetUsersToRole(UserInfo userInfo, string roleId, string[] userIds) 设置角色中的用户
        /// <summary>
        /// 设置角色中的用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色</param>
        /// <param name="userIds">用户主键数组</param>
        /// <returns>影响行数</returns>
        public int SetUsersToRole(UserInfo userInfo, string roleId, string[] userIds)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_SetUsersToRole);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, (dbProvider) =>
            {
                var manager = new PiUserManager(dbProvider, userInfo);
                result = manager.ClearUser(roleId);
                // 小心异常，检查一下参数的有效性
                if (userIds != null)
                {
                    result += manager.AddToRole(userIds, roleId);
                }
            });
            return result;
        }
        #endregion

        #region public int ResetSortCode(UserInfo userInfo, string organizeId) 重置角色排序码
        /// <summary>
        /// 重置角色排序码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        public int ResetSortCode(UserInfo userInfo, string organizeId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.RoleService_ResetSortCode);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, (dbProvider) =>
            {
                var manager = new PiRoleManager(dbProvider, userInfo, PiRoleTable.TableName);
                result = manager.ResetSortCode(organizeId);
            });
            return result;
        }
        #endregion

        #region public int MoveTo(UserInfo userInfo, string id, string targetOrganizeId) 移动角色数据
        /// <summary>
        /// 移动角色数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="targetOrganizeId">目标组织机构主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(UserInfo userInfo, string id, string targetOrganizeId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo , MethodBase.GetCurrentMethod(), this.serviceName , RDIFrameworkMessage.RoleService_MoveTo);
            int result = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, (dbProvider) =>
            {
                var manager = new PiRoleManager(dbProvider, userInfo, PiRoleTable.TableName);
                result = manager.MoveTo(id, targetOrganizeId);
            });
            return result;
        }
        #endregion
    }
}
