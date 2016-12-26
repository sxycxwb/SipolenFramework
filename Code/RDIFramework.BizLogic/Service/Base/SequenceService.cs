using System;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
	

	/// <summary>
	/// SequenceService
	/// 服务层
	/// 
	/// 修改记录
	///     2015-08-05 版本：3.0 EricHu 新增分页显示、逻辑删除。
	///		2012-03-02 版本：1.0 EricHu 建立。
	///		
	/// 版本：3.0
	///
	/// <author>
	///		<name>EricHu</name>
	///		<date>2012-03-02</date>
	/// </author> 
	/// </summary>
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public class SequenceService : System.MarshalByRefObject, ISequenceService
	{
        private readonly string serviceName = RDIFrameworkMessage.SequenceService;

        /// <summary>
        /// 多用户并发处理用
        /// </summary>
        private static readonly Object Lock = new Object();

        /// <summary>
        /// .NET快速开发整合框架（RDIFramework.NET）数据库连接
        /// </summary>
        private readonly string RDIFrameworkDbConection = SystemInfo.RDIFrameworkDbConection;

        /// <summary>
        /// 添加序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="sequenceEntity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        public string Add(UserInfo userInfo, CiSequenceEntity sequenceEntity, out string statusCode, out string statusMessage)
        {
            string returnValue = string.Empty;
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_Add);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                 var sequenceManager = new CiSequenceManager(dbProvider, userInfo);
                 returnValue = sequenceManager.Add(sequenceEntity, out returnCode);
                 returnMessage = sequenceManager.GetStateMessage(returnCode);
            });
            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }

        #region public string Add(UserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 添加编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public string Add(UserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            var sequenceEntity = BaseEntity.Create<CiSequenceEntity>(dataTable);
            return this.Add(userInfo, sequenceEntity, out statusCode, out statusMessage);
        }
        #endregion

        #region public DataTable GetDT(UserInfo userInfo) 获取序列号列表
        /// <summary>
        /// 获取序列号列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDT(UserInfo userInfo)
        {
            var dataTable = new DataTable(CiSequenceTable.TableName);
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var sequenceManager = new CiSequenceManager(dbProvider);
                dataTable = sequenceManager.GetDT();
                dataTable.TableName = CiSequenceTable.TableName;
            });

            return dataTable;
        }
        #endregion

        #region public DataTable GetDTByPage(UserInfo userInfo,out int recordCount,int pageIndex=1,int pageSize=20,string whereConditional = "",string order = "") 获取序列分页列表
        /// <summary>
        /// 获取序列分页列表
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
            var dataTable = new DataTable(CiSequenceTable.TableName);
            var returnRecordCount = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_GetDT);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                var manager = new CiSequenceManager(dbProvider, userInfo);
                if (string.IsNullOrEmpty(whereConditional))
                {
                    whereConditional = CiSequenceTable.FieldDeleteMark + " = 0 ";
                }
                else
                {
                    whereConditional += " AND " + CiSequenceTable.FieldDeleteMark + " = 0 ";
                }

                dataTable = manager.GetDTByPage(out returnRecordCount, pageIndex, pageSize, whereConditional, order);
                dataTable.TableName = CiSequenceTable.TableName;
            });
            recordCount = returnRecordCount;
            return dataTable;
        }
        #endregion

        #region public CiSequenceEntity GetEntity(UserInfo userInfo, string id)
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiSequenceEntity GetEntity(UserInfo userInfo, string id)
        {    
            CiSequenceEntity sequenceEntity = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_GetEntity);

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                sequenceEntity = new CiSequenceManager(dbProvider, userInfo).GetEntity(id);
            });

            return sequenceEntity;
        }
        #endregion

        /// <summary>
        /// 更新序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        public int Update(UserInfo userInfo, CiSequenceEntity entity, out string statusCode, out string statusMessage)
        {
            string returnCode = string.Empty;
            string returnMessage = string.Empty;
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_Update);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                var sequenceManager = new CiSequenceManager(dbProvider, userInfo);
                returnValue = sequenceManager.Update(entity, out returnCode);
                returnMessage = sequenceManager.GetStateMessage(returnCode);
            });

            statusCode = returnCode;
            statusMessage = returnMessage;
            return returnValue;
        }

        #region public int Update(UserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        /// <summary>
        /// 更新编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        public int Update(UserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage)
        {
            var entity = BaseEntity.Create<CiSequenceEntity>(dataTable);
            return this.Update(userInfo, entity, out statusCode, out statusMessage);
        }
        #endregion

        #region public string GetSequence(UserInfo userInfo, string fullName) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(UserInfo userInfo, string fullName)
        {
            string returnValue = string.Empty;

            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter,Lock, dbProvider =>
            {
                returnValue = this.GetSequence(dbProvider, userInfo, fullName);
            });

            return returnValue;
        }
        #endregion

        #region public string GetSequence(IDbProvider dbProvider, UserInfo userInfo, string fullName) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(IDbProvider dbProvider, UserInfo userInfo, string fullName)
        {
            var sequenceManager = new CiSequenceManager(dbProvider);
            return sequenceManager.GetSequence(fullName);
        }
        #endregion

        #region public string GetOldSequence(UserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取原序列号
        /// <summary>
        /// 获取原序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(UserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            var parameter = ParameterUtil.CreateWithLog(userInfo
                , MethodBase.GetCurrentMethod());
            string result = string.Empty;
            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter, Lock, dbProvider =>
            {
                var sequenceManager = new CiSequenceManager(dbProvider);
                result = sequenceManager.GetOldSequence(fullName, defaultSequence, sequenceLength, fillZeroPrefix);
            });
            return result;
        }
        #endregion

        #region public string GetNewSequence(UserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取原序列号
        /// <summary>
        /// 获取新序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetNewSequence(UserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());
         
            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter, Lock, dbProvider =>
            {
                returnValue = new CiSequenceManager(dbProvider).GetSequence(fullName, defaultSequence, sequenceLength, fillZeroPrefix);
            });
            return returnValue;
        }
        #endregion


        #region public string[] GetBatchSequence(UserInfo userInfo, string fullName, int count) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="count">个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(UserInfo userInfo, string fullName, int count)
        {
            var returnValue = new string[0];

            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIReadDb(userInfo, parameter, dbProvider =>
            {
                returnValue = this.GetBatchSequence(dbProvider, userInfo, fullName, count);
            });

            return returnValue;
        }
        #endregion

        #region public string[] GetBatchSequence(IDbProvider dbProvider, UserInfo userInfo, string fullName, count) 获取序列号
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="count">个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(IDbProvider dbProvider, UserInfo userInfo, string fullName, int count)
        {
            var sequenceManager = new CiSequenceManager(dbProvider);
            return sequenceManager.GetBatchSequence(fullName, count);
        }
        #endregion

        #region public string GetReduction(UserInfo userInfo, string fullName) 获取倒序序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(UserInfo userInfo, string fullName)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithLog(userInfo, MethodBase.GetCurrentMethod());

            ServiceUtil.ProcessRDIWriteDbWithLock(userInfo, parameter, Lock, dbProvider =>
            {
                returnValue = this.GetReduction(dbProvider, userInfo, fullName);
            });
            return returnValue;
        }
        #endregion

        #region public string GetReduction(IDbProvider dbProvider, UserInfo userInfo, string fullName)
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(IDbProvider dbProvider, UserInfo userInfo, string fullName)
        {
            var sequenceManager = new CiSequenceManager(dbProvider);
            return sequenceManager.GetReduction(fullName);
        }
        #endregion

        #region public int Reset(UserInfo userInfo, string[] ids) 批量重置
        /// <summary>
        /// 批量重置序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int Reset(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_Reset);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiSequenceManager(dbProvider).Reset(ids);
            });
            return returnValue;
        }
        #endregion

        #region public int Delete(UserInfo userInfo, string id) 删除序列
        /// <summary>
        /// 删除序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiSequenceManager(dbProvider).Delete(id);
            });
            return returnValue;
        }
        #endregion

        #region public int SetDeleted(UserInfo userInfo, string id) 逻辑删除序列
        /// <summary>
        /// 逻辑删除序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int SetDeleted(UserInfo userInfo, string id)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_Delete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiSequenceManager(dbProvider).SetDeleted(id);
            });
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(UserInfo userInfo, string[] ids) 批量删除序列
        /// <summary>
        /// 批量删除序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        public int BatchDelete(UserInfo userInfo, string[] ids)
        {
            int returnValue = 0;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.SequenceService_BatchDelete);

            ServiceUtil.ProcessRDIReadDb(userInfo,parameter, dbProvider =>
            {
                returnValue = new CiSequenceManager(dbProvider).Delete(ids);
            });

            return returnValue;
        }
        #endregion
	}
}
