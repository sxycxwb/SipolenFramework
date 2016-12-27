//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
	/// ExceptionService
	/// 服务层
	/// 
	/// 修改记录
	/// 
    ///     2013-08-13 版本：2.5 XuWangBin 增加“GetDTByPage”按分页获取数据，满足Web分页的要求。
	///		2012-03-02 版本：1.0 XuWangBin 建立。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class ExceptionService : System.MarshalByRefObject, IExceptionService
	{
        private string serviceName = RDIFrameworkMessage.ExceptionService;

        #region public string Add(UserInfo userInfo, CiExceptionEntity entity, out string statusCode, out string statusMessage):添加异常数据
        /// <summary>
        /// 添加异常数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
		public string Add(UserInfo userInfo, CiExceptionEntity entity, out string statusCode, out string statusMessage)
		{
			string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                returnValue = manager.AddEntity(entity);
                returnMessage = manager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
			return returnValue;
		}
        #endregion

        #region public DataTable GetDT(UserInfo userInfo):取得列表
        /// <summary>
		/// 取得列表
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <returns>資料表</returns>
		public DataTable GetDT(UserInfo userInfo)
		{
			var dataTable = new DataTable(CiExceptionTable.TableName);			
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ExceptionService_GetDT);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                dataTable = manager.GetDT();
                dataTable.TableName = CiExceptionTable.TableName;
            });
			return dataTable;
		}
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取系统异常分页列表
        /// <summary>
        /// 获取系统异常分页列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小（默认20条）</param>
        /// <param name="whereConditional">条件表达式</param>
        /// <param name="order">排序字段</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(UserInfo userInfo, out int recordCount, int pageIndex = 1, int pageSize = 20, string whereConditional = "", string order = "")
        {
            var dataTable = new DataTable(CiExceptionTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ExceptionService_GetDTByPage);
            int returnRecordCount = 0;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = CiExceptionTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public CiExceptionEntity GetEntity(UserInfo userInfo, string id):获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
		public CiExceptionEntity GetEntity(UserInfo userInfo, string id)
		{
			CiExceptionEntity entity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);            

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                entity = manager.GetEntity(id);
            });
            
			return entity;
		}
        #endregion

        #region public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values):按条件获取数据列表
        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="names">字段</param>
        /// <param name="values">值</param>
        /// <returns>数据表</returns>
		public DataTable GetDTByValues(UserInfo userInfo, string[] names, object[] values)
		{
			var dataTable = new DataTable(CiExceptionTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);
            parameter.IsAddLog = false;
            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                dataTable = manager.GetDT(names, values);
                dataTable.TableName = CiExceptionTable.TableName;
            });
            
			return dataTable;
		}
        #endregion

        #region public int Delete(UserInfo userInfo, string id):删除异常
        /// <summary>
        /// 删除异常
		/// </summary>
		/// <param name="userInfo">用户</param>
		/// <param name="id">主鍵</param>
		/// <returns>受影响的行数</returns>
		public int Delete(UserInfo userInfo, string id)
		{
			int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ExceptionService_Delete);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                returnValue = manager.Delete(id);
            });
			return returnValue;
		}
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids):批量删除数据
        /// <summary>
        /// 批量删除数据
		/// </summary>
		/// <param name="userInfo">使用者</param>
		/// <param name="ids">主键数组</param>
		/// <returns>影响行数</returns>
		public int BatchDelete(UserInfo userInfo, string[] ids)
		{
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ExceptionService_BatchDelete);            

            ServiceUtil.ProcessRDIWriteDbWithTran(userInfo, parameter, dbProvider =>
            {
                var manager = new CiExceptionManager(dbProvider, userInfo);
                returnValue = manager.Delete(ids);			
            });
			return returnValue;
		}
        #endregion

        #region public void Truncate(UserInfo userInfo) 全部清除异常
        /// <summary>
        /// 全部清除异常
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public void Truncate(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.ExceptionService_Truncate);            

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var exceptionManager = new CiExceptionManager(dbProvider, userInfo);
                exceptionManager.Truncate();
            });
        }
        #endregion
	}
}
