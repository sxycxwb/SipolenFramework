using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务命令实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkTaskCommands(UserInfo userInfo, WorkTaskCommandsEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkTaskCommands);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                returnValue = manager.InsertWorkTaskCommands(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务命令实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateWorkTaskCommands(UserInfo userInfo, WorkTaskCommandsEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkTaskCommands);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                returnValue = manager.UpdateWorkTaskCommands(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除一个任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteWorkTaskCommands(UserInfo userInfo, string commandId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskCommands);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                returnValue = manager.DeleteWorkTaskCommands(commandId);
            });
            return returnValue;
        }

        /// <summary>
        /// 得到指定流程模版的所有任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>任务命令列表</returns>
        public DataTable GetWorkFlowAllCommands(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkFlowAllCommands);
            var dataTable = new DataTable(WorkTaskCommandsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowAllCommands(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 通过指定任务命令主键得到任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">任务命令Id</param>
        /// <returns>任务命令列表</returns>
        public DataTable GetTaskCommandsTable(UserInfo userInfo, string commandId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetTaskCommandsTable);
            var dataTable = new DataTable(WorkTaskCommandsTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                dataTable = manager.GetTaskCommandsTable(commandId);
            });
            return dataTable;
        }

        /// <summary>
        /// 是否存在指定任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">任务命令Id</param>
        /// <returns>true存在</returns>
        public bool ExistsWorkTaskCommands(UserInfo userInfo, string commandId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_ExistsWorkTaskCommands);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskCommandsManager(dbProvider, userInfo);
                returnValue = manager.Exists(commandId);
            });
            return returnValue;
        }


    }
}
