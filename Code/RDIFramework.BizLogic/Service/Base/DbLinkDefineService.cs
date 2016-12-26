//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
	/// CiDbLinkDefineService
	/// 服务层
	/// 
	/// 修改记录
	/// 
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
	public class DbLinkDefineService : System.MarshalByRefObject, IDbLinkDefineService
	{
		private readonly string serviceName = RDIFrameworkMessage.DbLinkDefineService;

		/// <summary>
		/// 新增数据库连接
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>主键</returns>
		public string Add(UserInfo userInfo, CiDbLinkDefineEntity entity, out string statusCode, out string statusMessage)
		{		
			string returnValue = string.Empty;           
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                returnValue = manager.Add(entity, out returnCode);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}

		/// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiDbLinkDefineTable.TableName);
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                dataTable = manager.GetDT(CiDbLinkDefineTable.FieldDeleteMark, 0, CiDbLinkDefineTable.FieldSortCode);
                dataTable.TableName = CiDbLinkDefineTable.TableName;
              
            });

            return dataTable;
        }

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
	    public List<CiDbLinkDefineEntity> GetList(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);     
            var list = new List<CiDbLinkDefineEntity>();
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(CiDbLinkDefineTable.FieldDeleteMark, 0)
                };
                list = manager.GetList<CiDbLinkDefineEntity>(parameters, CiDbLinkDefineTable.FieldSortCode);
            });

            return list;
        }

        /// <summary>
        /// 通过连接名称得到数据库连接定义
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="linkName">数据库连接定义名称</param>
        /// <returns>数据库连接定义实体</returns>
        public CiDbLinkDefineEntity GetEntityByLinkName(UserInfo userInfo, string linkName)
        {
            CiDbLinkDefineEntity entity = null;
            
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);

                var names = new string[3];
                var values = new object[3];
                names[0] = CiDbLinkDefineTable.FieldLinkName;
                names[1] = CiDbLinkDefineTable.FieldEnabled;
                names[2] = CiDbLinkDefineTable.FieldDeleteMark;
                values[0] = linkName;
                values[1] = 1;
                values[2] = 0;
                var dtTemp = manager.GetDT(names, values);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    entity = BaseEntity.Create<CiDbLinkDefineEntity>(dtTemp); 
                }
            });
            return entity;
        }

		/// <summary>
		/// 取得实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主键</param>
		/// <returns>实体</returns>
		public CiDbLinkDefineEntity GetEntity(UserInfo userInfo, string id)
		{
			CiDbLinkDefineEntity entity = null;
            
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                entity = manager.GetEntity(id);
            });
			return entity;
		}

		/// <summary>
		/// 更新实体
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="entity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <param name="statusMessage">返回状态信息</param>
		/// <returns>影响行数</returns>
		public int Update(UserInfo userInfo, CiDbLinkDefineEntity entity, out string statusCode, out string statusMessage)
		{
            var returnValue = 0;
            string returnCode = string.Empty;
			string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);		            
		        returnValue = manager.Update(entity, out returnCode);
		        returnMessage = manager.GetStateMessage(returnCode);
            });
            
            statusCode = returnCode;
			statusMessage = returnMessage;
            return returnValue;
		}

		/// <summary>
		/// 根据主键值取得数据库连接定义
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByIds(UserInfo userInfo, string[] ids)
		{
			var dataTable = new DataTable(CiDbLinkDefineTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
				dataTable = manager.GetDT(CiDbLinkDefineTable.FieldId, ids, CiDbLinkDefineTable.FieldSortCode);
				dataTable.TableName = CiDbLinkDefineTable.TableName;
            });
			return dataTable;
		}
		
		/// <summary>
		/// 根据条件取得数据库连接数据表
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="names">字段</param>
		/// <param name="values">值</param>
		/// <returns>数据表</returns>
		public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
		{
			var dataTable = new DataTable(CiDbLinkDefineTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                dataTable = manager.GetDT(names, values);
                dataTable.TableName = CiDbLinkDefineTable.TableName;
            });
			
			return dataTable;
		}			
		
		/// <summary>
		/// 刪除資料
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主键</param>
		/// <returns>数据表</returns>
		public int Delete(UserInfo userInfo, string id)
		{			
			var returnValue = 0;	
		    var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                returnValue = manager.Delete(id);
            });
			
			return returnValue;
		}
		
		/// <summary>
		/// 批量刪除数据
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键陣列</param>
		/// <returns>影响行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{	
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            
            
            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                returnValue = manager.Delete(ids);
            });
			return returnValue;
		}

		/// <summary>
		/// 批量设置删除标志
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="ids">主键陣列</param>
		/// <returns>影响行数</returns>
		public int SetDeleted(UserInfo userInfo, string[] ids)
		{
			var returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new CiDbLinkDefineManager(dbProvider, userInfo);
                returnValue = manager.SetDeleted(ids);
            });

			return returnValue;
		}
	}
}
