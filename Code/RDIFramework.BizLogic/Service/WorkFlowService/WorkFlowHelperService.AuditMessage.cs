using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowHelperService
    {
        #region public string InsertAuditMessage(UserInfo userInfo, AuditMessageEntity entity) 增加审批信息
        /// <summary>
        /// 增加审批信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>增加成功后的主键</returns>
        public string InsertAuditMessage(UserInfo userInfo, AuditMessageEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AuditMessageManager(dbProvider, userInfo);
                returnValue = manager.AddEntity(entity);
            });
            return returnValue;
        }
        #endregion

        #region public int UpdateAuditMessage(UserInfo userInfo, AuditMessageEntity entity) 修改审批信息
        /// <summary>
        /// 修改审批信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateAuditMessage(UserInfo userInfo, AuditMessageEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new AuditMessageManager(dbProvider, userInfo);
                returnValue = manager.UpdateEntity(entity);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetAuditMessageTableByOper(UserInfo userInfo, string operatorInsId) 获得操作实例审批列表
        /// <summary>
        /// 获得操作实例审批列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorInsId">操作实例Id</param>
        /// <returns>审批列表</returns>
        public DataTable GetAuditMessageTableByOper(UserInfo userInfo, string operatorInsId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AuditMessageTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AuditMessageManager(dbProvider, userInfo);
                dataTable = manager.GetDT(AuditMessageTable.FieldOperatorInsId, operatorInsId, AuditMessageTable.FieldAuditTime);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetAuditMessageTableByFlow(UserInfo userInfo, string workflowInsId) 获得流程实例的审批列表
        /// <summary>
        /// 获得流程实例的审批列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">流程实例Id</param>
        /// <returns>审批列表</returns>
        public DataTable GetAuditMessageTableByFlow(UserInfo userInfo, string workflowInsId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(AuditMessageTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new AuditMessageManager(dbProvider, userInfo);
                dataTable = manager.GetDT(AuditMessageTable.FieldWorkflowInsId, workflowInsId,AuditMessageTable.FieldAuditTime + " DESC ");
            });
            return dataTable;
        }
        #endregion
    }
}
