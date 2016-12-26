using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加事件通知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">事件通知实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkFlowEvent(UserInfo userInfo, WorkFlowEventEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkFlowEvent);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                returnValue = manager.Insert(entity);
            });
            return returnValue;
        }
        
        /// <summary>
        /// 更新事件通知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">事件通知实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkFlowEvent(UserInfo userInfo, WorkFlowEventEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkFlowEvent);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                returnValue = manager.UpdateWorkFlowEvent(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 根据任务模版主键删除事件通知记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkFlowEvent(UserInfo userInfo, string worktaskid)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkFlowEvent);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                returnValue = manager.DeleteWorkFlowEvent(worktaskid);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得指定任务模版事件通知列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>事件通知列表</returns>
        public DataTable GetWorkFlowEventTable(UserInfo userInfo, string worktaskid)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowEventTable);
            var dataTable = new DataTable(WorkFlowEventTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowEventTable(worktaskid);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定流程模版所有的事件通知列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>事件通知列表</returns>
        public DataTable GetWorkFlowAllEventTable(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowAllEventTable);
            var dataTable = new DataTable(WorkFlowEventTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllEventTable(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到事件通知列表实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>事件通知列表实体</returns>
        public WorkFlowEventEntity GetWorkFlowEventInfo(UserInfo userInfo, string worktaskid)
        {
            WorkFlowEventEntity returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowEventInfo);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowEventManager(dbProvider, userInfo);
                returnValue = manager.GetWorkFlowEventInfo(worktaskid);
            });
            return returnValue;
        }
    }
}
