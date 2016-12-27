using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
    /// LogService
    /// 服务层
	/// 
	/// 修改记录
	/// 
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
    public class LogService : System.MarshalByRefObject, ILogService
	{
        private readonly string serviceName = RDIFrameworkMessage.LogService;

        #region public void WriteLog(UserInfo userInfo, string processId, string processName, string methodId, string methodName) 写入日志
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processId">服务</param>
        /// <param name="processName">服务名称</param>
        /// <param name="methodId">操作</param>
        /// <param name="methodName">操作名称</param>
        public void WriteLog(UserInfo userInfo, string processId, string processName, string methodId, string methodName)
        {
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider => LogManager.Instance.Add(userInfo, processName, methodName, processId, methodId, string.Empty));
        }
        #endregion

        #region public void WriteExit(UserInfo userInfo, string logId) 离开时的日志记录
        /// <summary>
        /// 离开时的日志记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="logId">日志主键</param>
        public void WriteExit(UserInfo userInfo, string logId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, string.Empty);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var sqlBuilder = new SQLBuilder(dbProvider);
                sqlBuilder.BeginUpdate(CiLogTable.TableName);
                sqlBuilder.SetWhere(CiLogTable.FieldId, logId);
                sqlBuilder.EndUpdate();
            });
        }
        #endregion

        #region public DataTable GetLogGeneral(UserInfo userInfo) 获取用户访问情况日志
        /// <summary>
        /// 获取用户访问情况日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetLogGeneral(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiLogTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetLogGeneral);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var userManager = new LogManager(dbProvider, userInfo);
                //if (userInfo.IsAdministrator)
                //{
                    dataTable = userManager.GetDT();
                //}
                //else
                //{
                //    PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                //    string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                //    dataTable = userManager.GetDTByIds(userIds);
                //}
                dataTable.TableName = CiLogTable.TableName;
            });

            return dataTable;
        }
        #endregion       

        #region public DataTable GetDTByDate(UserInfo userInfo, string beginDate, string endDate, string userId, string moduleId) 按日期获取日志
        /// <summary>
	    /// 按日期获取日志
	    /// </summary>
	    /// <param name="userInfo">用户</param>
	    /// <param name="beginDate">开始时间</param>
	    /// <param name="endDate">结束时间</param>
	    /// <param name="userId">用户主键</param>
	    /// <param name="moduleId">模块主键</param>
	    /// <returns>数据表</returns>
	    public DataTable GetDTByDate(UserInfo userInfo, string beginDate, string endDate, string userId, string moduleId)
        {
            var dataTable = new DataTable(CiLogTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetDTByDate);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var logManager = new LogManager(dbProvider, userInfo);
                if (!string.IsNullOrEmpty(userId))
                {
                    dataTable = logManager.GetDTByDateByUserIds(new[] { userId }, CiLogTable.FieldProcessId, moduleId, beginDate, endDate);
                }
                else
                {
                    if (userInfo.IsAdministrator)
                    {
                        dataTable = logManager.GetDTByDate(CiLogTable.FieldProcessId, moduleId, beginDate, endDate);
                    }
                    else
                    {
                        var piPermissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                        string[] userIds = piPermissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                        dataTable = logManager.GetDTByDateByUserIds(userIds, CiLogTable.FieldProcessId, moduleId, beginDate, endDate);
                    }
                }
                dataTable.TableName = CiLogTable.TableName;
            });
           
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByModule(UserInfo userInfo, string processId, string beginDate,string endDate) 按模块获取日志
        /// <summary>
        /// 按模块获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processId">服务名称</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByModule(UserInfo userInfo, string processId, string beginDate, string endDate)
        {
            var dataTable = new DataTable(CiLogTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetDTByModule);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var logManager = new LogManager(dbProvider, userInfo);
                if (userInfo.IsAdministrator)
                {
                    dataTable = logManager.GetDTByDate(CiLogTable.FieldProcessId, processId, beginDate, endDate);
                }
                else
                {
                    var permissionScopeManager = new PiPermissionScopeManager(dbProvider, userInfo);
                    string[] userIds = permissionScopeManager.GetUserIds(userInfo.Id, "Resource.ManagePermission");
                    dataTable = logManager.GetDTByDateByUserIds(userIds, CiLogTable.FieldProcessId, processId, beginDate, endDate);
                }
                dataTable.TableName = CiLogTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByUser(UserInfo userInfo, string userId, string beginDate, string endDate) 按用户获取日志
        /// <summary>
        /// 按用户获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByUser(UserInfo userInfo, string userId, string beginDate, string endDate)
        {
            var dataTable = new DataTable(CiLogTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetDTByUser);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var logManager = new LogManager(dbProvider, userInfo);
                dataTable = logManager.GetDTByDate(CiLogTable.FieldCreateUserId, userId, beginDate, endDate);
                dataTable.TableName = CiLogTable.TableName;
            });   
            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取系统操作日志分页列表
        /// <summary>
        /// 获取系统操作日志分页列表
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
            int returnRecordCount = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetDTByPage);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new LogManager(dbProvider, userInfo);
                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = CiLogTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 删除日志
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_Delete, "主键：" + id);

            ServiceUtil.ProcessRDIWriteDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new LogManager(dbProvider, userInfo).Delete(CiLogTable.FieldId, id);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除日志
        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new LogManager(dbProvider, userInfo).Delete(CiLogTable.FieldId, ids);
            });

            return returnValue;
        }
        #endregion

        #region public void Truncate(UserInfo userInfo) 全部清除日志
        /// <summary>
        /// 全部清除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public void Truncate(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_Truncate);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider => new LogManager(dbProvider, userInfo).Truncate());
        }
        #endregion

        #region public DataTable GetDTApplicationByDate(UserInfo userInfo, string beginDate, string endDate) 按日期获取日志（业务）
        /// <summary>
        /// 按日期获取日志（业务）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDTApplicationByDate(UserInfo userInfo, string beginDate, string endDate)
        {
            var dataTable = new DataTable(CiLogTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_GetDTApplicationByDate);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var logManager = new LogManager(dbProvider, userInfo);
                dataTable = logManager.GetDTByDate(string.Empty, string.Empty, beginDate, endDate);
                dataTable.TableName = CiLogTable.TableName;
            });
            return dataTable;
        }
        #endregion

        #region public int BatchDeleteApplication(UserInfo userInfo, string[] ids) 批量删除日志(业务)
        /// <summary>
        /// 批量删除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDeleteApplication(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_BatchDeleteApplication);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new LogManager(dbProvider, userInfo).Delete(CiLogTable.FieldId, ids);
            });
            return returnValue;
        }
        #endregion

        #region public void TruncateApplication(UserInfo userInfo) 全部清除日志(业务)
        /// <summary>
        /// 全部清除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public void TruncateApplication(UserInfo userInfo)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.LogService_TruncateApplication);
            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider => new LogManager(dbProvider, userInfo).Truncate());
        }
        #endregion	
	}
}
