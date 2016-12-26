using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加工作任务超时设置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkOutTime(UserInfo userInfo, WorkOutTimeEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkOutTime);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                returnValue = manager.InsertWorkOutTime(entity);
            });
            return returnValue;
        }
        
        /// <summary>
        /// 更新工作任务超时设置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkOutTime(UserInfo userInfo, WorkOutTimeEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkOutTime);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                returnValue = manager.UpdateWorkOutTime(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 根据工作任务模版主键删除超时设置记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkOutTime(UserInfo userInfo, string workTaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkOutTime);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                returnValue = manager.DeleteWorkOutTime(workTaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 依据工作任务模版Id获得超时设置列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>超时设置列表</returns>
        public DataTable GetWorkOutTimeTable(UserInfo userInfo, string worktaskid)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkOutTimeTable);
            var dataTable = new DataTable(WorkOutTimeTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                dataTable = manager.GetWorkOutTimeTable(worktaskid);
            });
            return dataTable;
        }

        /// <summary>
        /// 得到指定流程模版所有的超时设置列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>超时设置列表</returns>
        public DataTable GetWorkFlowAllOutTimeTable(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowAllOutTimeTable);
            var dataTable = new DataTable(WorkOutTimeTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllOutTimeTable(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 依据工作任务主键得到超时设置实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskid">工作任务Id</param>
        /// <returns>超时设置实体</returns>
        public WorkOutTimeEntity GetWorkOutTimeInfo(UserInfo userInfo, string worktaskid)
        {
            WorkOutTimeEntity returnValue = null;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkOutTimeInfo);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkOutTimeManager(dbProvider, userInfo);
                returnValue = manager.GetWorkOutTimeInfo(worktaskid);
            });
            return returnValue;
        }
    }
}
