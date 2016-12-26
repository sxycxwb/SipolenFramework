//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
    /// TableColumnsService
    /// 表字段结构服务层
	/// 
	/// 修改记录
	/// 
	///		2012-03-02 版本：1.0 EricHu 建立。
    ///		2013-03-01 EricHu 新增：GetAllTableScope与GetTableNameAndCode方法。
	///		
	/// 版本：2.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class TableColumnsService : System.MarshalByRefObject, ITableColumnsService
	{
		private readonly string serviceName = RDIFrameworkMessage.TableColumnsService;
		
        #region public string Add(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage) 新增数据
        /// <summary>
		/// 新增数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>主鍵</returns>
		public string Add(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage)
		{
			string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new TableColumnsManager(dbProvider, userInfo);
                returnValue = manager.AddEntity(entity);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 取得列表
        /// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <returns>数据表</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetDT(CiTableColumnsTable.FieldDeleteMark, 0, CiTableColumnsTable.FieldSortCode);
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetAllTableScope(UserInfo userInfo) 得到所有数据表（用于表字段权限的控制）
        /// <summary>
        /// 得到所有数据表（用于表字段权限的控制，主要针对PiTablePermissionScope数据表的数据）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetAllTableScope(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetAllTableScope);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetAllTableScope();
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetTableNameAndCode(UserInfo userInfo) 得到所有数据表（表的中文名称与英文名称）
        /// <summary>
        /// 得到所有数据表（表的中文名称与英文名称）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetTableNameAndCode(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetTableNameAndCode);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetTableNameAndCode();
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public CiTableColumnsEntity GetEntity(UserInfo userInfo, string id) 取得实体
        /// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
		/// <returns>实体</returns>
		public CiTableColumnsEntity GetEntity(UserInfo userInfo, string id)
		{
			CiTableColumnsEntity entity = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new TableColumnsManager(dbProvider, userInfo).GetEntity(id);
            });

			return entity;
		}
        #endregion

        #region public int Update(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage) 更新实体
        /// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>影响行数</returns>
		public int Update(UserInfo userInfo, CiTableColumnsEntity entity, out string statusCode, out string statusMessage)
		{
			var returnValue = 0;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new TableColumnsManager(dbProvider, userInfo);
                returnValue = manager.UpdateEntity(entity);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public DataTable GetDTByIds(UserInfo userInfo, string[] ids) 按主键数组获取数据列表
        /// <summary>
        /// 按主键数组获取数据列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主鍵</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
			var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetDTByIds);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetDT(CiTableColumnsTable.FieldId, ids, CiTableColumnsTable.FieldSortCode);
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values) 按条件获取数据列表
        /// <summary>
        /// 按条件获取数据列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="names">字段</param>
		/// <param name="values">值</param>
		/// <returns>資料表</returns>
		public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
		{
			var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetDTByValues);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetDT(names, values);
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public int BatchSave(UserInfo userInfo, List<CiTableColumnsEntity> entites) 批量保存数据
        /// <summary>
		/// 批量保存数据
		/// </summary>
		/// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
		/// <returns>影响行数</returns>
        public int BatchSave(UserInfo userInfo, DataTable dataTable)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_BatchSave);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).BatchSave(dataTable);
            });
			return returnValue;
		}
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 刪除資料
        /// <summary>
		/// 刪除資料
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
		/// <returns>資料表</returns>
		public int Delete(UserInfo userInfo, string id)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).Delete(id);
            });
			return returnValue;
		}
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量刪除数据
        /// <summary>
		/// 批量刪除数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_BatchDelete);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).BatchDelete(ids);

            });
			return returnValue;
		}
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string[] ids) 批次設置刪除标志
        /// <summary>
		/// 批次設置刪除标志
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响行数</returns>
		public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_SetDeleted);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).SetDeleted(ids);
            });
			return returnValue;
		}
        #endregion

        #region public DataTable GetSearchFields(UserInfo userInfo, string tableCode) 得到查询项
        /// <summary>
        /// 得到查询项
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableCode">表名称</param>
        /// <returns></returns>
        public DataTable GetSearchFields(UserInfo userInfo, string tableCode)
        {
            var dataTable = new DataTable(PiUserTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetSearchFields);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetSearchFields(tableCode);
                dataTable.TableName = PiUserTable.TableName;
            });

            return dataTable;
        }
        #endregion

        #region public string[] GetColumns(UserInfo userInfo, string tableCode, string permissionCode = "Column.Access") 获取用户的列权限
	    /// <summary>
	    /// 获取用户的列权限
	    /// </summary>
	    /// <param name="userInfo">用户</param>
	    /// <param name="tableCode">表名</param>
	    /// <param name="permissionCode">操作权限</param>
	    /// <returns>有权限的列数组</returns>
	    public string[] GetColumns(UserInfo userInfo, string tableCode, string permissionCode = "Column.Access")
        {
            string[] returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetColumns);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).GetColumns(userInfo.Id, tableCode, permissionCode);
            });

            return returnValue;
        }
        #endregion

        #region public DataTable GetDTByTable(UserInfo userInfo, string tableCode) 按表名获取字段列表
        /// <summary>
        /// 按表名获取字段列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableCode">表名</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByTable(UserInfo userInfo, string tableCode)
        {
            var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetDTByTable);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                string[] names = { CiTableColumnsTable.FieldTableCode, CiTableColumnsTable.FieldDeleteMark };
                Object[] values = { tableCode, 0 };
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetDT(names, values, CiTableColumnsTable.FieldSortCode);
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetTablePermissionScope(UserInfo userInfo) 得到所有可做表字段控制权限的数据
        /// <summary>
        /// 得到所有可做表字段控制权限的数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetTablePermissionScope(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetTablePermissionScope);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                string[] names = { PiTablePermissionScopeTable.FieldDeleteMark };
                Object[] values = { 0 };
                dataTable = new TablePermissionScopeManager(dbProvider, userInfo).GetDT(names, values, PiTablePermissionScopeTable.FieldSortCode);
                dataTable.TableName = PiTablePermissionScopeTable.TableName;
            });

            return dataTable;
        }
        #endregion

        #region public DataTable GetConstraintDT(UserInfo userInfo, string resourceCategory, string resourceId) 获取约束条件（所有的约束）
        /// <summary>
        /// 获取约束条件（所有的约束）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>数据表</returns>
        public DataTable GetConstraintDT(UserInfo userInfo, string resourceCategory, string resourceId)
        {
            var dataTable = new DataTable(CiTableColumnsTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetConstraintDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                dataTable = new TableColumnsManager(dbProvider, userInfo).GetConstraintDT(resourceCategory, resourceId);
                dataTable.TableName = CiTableColumnsTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public string GetUserConstraint(UserInfo userInfo, string tableName) 获取当前用户的件约束表达式
        /// <summary>
        /// 获取当前用户的件约束表达式
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">表名</param>
        /// <returns>主键</returns>
        public string GetUserConstraint(UserInfo userInfo, string tableName)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_GetUserConstraint);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).GetUserConstraint(tableName);
            });
            return returnValue;
        }
        #endregion

        #region public string SetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled = true) 设置约束条件
        /// <summary>
        /// 设置约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <param name="constraint">约束</param>
        /// <param name="enabled">有效</param>
        /// <returns>主键</returns>
        public string SetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled = true)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_SetConstraint);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).SetConstraint(resourceCategory, resourceId, tableName, permissionCode, constraint, enabled);
            });
            return returnValue;
        }
        #endregion

        #region public string GetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName) 获取约束条件
        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        public string GetConstraint(UserInfo userInfo, string resourceCategory, string resourceId, string tableName)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).GetConstraint(resourceCategory, resourceId, tableName);
            });
            return returnValue;
        }
        #endregion

        #region public PiPermissionScopeEntity GetConstraintEntity(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission") 获取约束条件
        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        public PiPermissionScopeEntity GetConstraintEntity(UserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
        {
            PiPermissionScopeEntity returnValue = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = new TableColumnsManager(dbProvider, userInfo).GetConstraintEntity(resourceCategory, resourceId, tableName, permissionCode);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDeleteConstraint(UserInfo userInfo, string[] ids) 批量删除约束条件
        /// <summary>
        /// 批量删除约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDeleteConstraint(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_BatchDeleteConstraint);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new PiPermissionScopeManager(dbProvider, userInfo).SetDeleted(ids);
            });
            return returnValue;
        }
        #endregion


        //==========================================================================================
        //===================================TablePermissionScope控制相关===========================
        //==========================================================================================

        #region public string AddTablePermissionScope(UserInfo userInfo, PiTablePermissionScopeEntity entity, out string statusCode, out string statusMessage) 增加可做表权限控制的数据表
        /// <summary>
        /// 增加可做表权限控制的数据表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        public string AddTablePermissionScope(UserInfo userInfo, PiTablePermissionScopeEntity entity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_AddTablePermissionScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new TablePermissionScopeManager(dbProvider, userInfo);
                returnValue = manager.Add(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }
        #endregion

        #region public int DeleteTablePermissionScope(UserInfo userInfo, string id) 删除表权限控制表中指定数据
        /// <summary>
        /// 删除表权限控制表中指定数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段列表</param>
        /// <param name="values">字段列表值</param>
        /// <returns>受影响的行数</returns>
        public int DeleteTablePermissionScope(UserInfo userInfo, string[] names,object[] values)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_DeleteTablePermissionScope);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new TablePermissionScopeManager(dbProvider, userInfo).Delete(names, values);
            });

            return returnValue;
        }
        #endregion

        #region public int SetTablePermissionScopeDeleted(UserInfo userInfo, string[] ids) 批量设置表权限控制数据表的刪除标志
        /// <summary>
        /// 批量设置表权限控制数据表的刪除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int SetTablePermissionScopeDeleted(UserInfo userInfo, string[] ids)
        {
            var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.TableColumnsService_SetTablePermissionScopeDeleted);

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                returnValue = new TablePermissionScopeManager(dbProvider, userInfo).SetDeleted(ids);
            });
            return returnValue;
        }
        #endregion

        #region public PiTablePermissionScopeEntity GetTablePermissionScopeEntity(UserInfo userInfo, string name, object value) 取得表权限控制数据表实体
        /// <summary>
        /// 取得表权限控制数据表实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="name">字段名称</param>
        /// <param name="value">字段值</param>
        /// <returns>实体</returns>
        public PiTablePermissionScopeEntity GetTablePermissionScopeEntity(UserInfo userInfo, string name, object value)
        {
            PiTablePermissionScopeEntity entity = null;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                entity = new TablePermissionScopeManager(dbProvider, userInfo).GetEntity(name, value);
            });
            return entity;
        }
        #endregion
    }
}
