using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务变量实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertTaskVar(UserInfo userInfo, TaskVarEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_InsertTaskVar);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                returnValue = manager.InsertTaskVar(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务变量实体</param>
        /// <returns>大于0成功</returns>
        public int UpdateTaskVar(UserInfo userInfo, TaskVarEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_UpdateTaskVar);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                returnValue = manager.UpdateTaskVar(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">任务变量主键</param>
        /// <returns>大于0成功</returns>
        public int DeleteTaskVar(UserInfo userInfo, string taskVarId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowUserControlService_DeleteTaskVar);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                returnValue = manager.DeleteTaskVar(taskVarId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得任务变量信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">变量Id</param>
        /// <returns>任务变量信息</returns>
        public DataTable GetTaskVarTable(UserInfo userInfo, string taskVarId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                dataTable = manager.GetTaskVarTable(taskVarId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版Id</param>
        /// <returns>流程变量列表</returns>
        public DataTable GetWorkFlowVar(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowVar(workflowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskId">任务模板Id</param>
        /// <returns>任务变量列表</returns>
        public DataTable GetTaskVar(UserInfo userInfo, string taskId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                dataTable = manager.GetTaskVar(taskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="varName">变量名称</param>
        /// <returns>任务变量列表</returns>
        public DataTable GetTaskVarByName(UserInfo userInfo, string workflowId, string varName)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                dataTable = manager.GetTaskVarByName(workflowId,varName);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns>流程变量列表</returns>
        public DataTable GetWorkFlowAllVar(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(TaskVarTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowAllVar(workflowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 判断任务变量是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">任务变量Id</param>
        /// <returns>true存在</returns>
        public bool ExistsTaskVar(UserInfo userInfo, string taskVarId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new TaskVarManager(dbProvider, userInfo);
                returnValue = manager.Exists(taskVarId);
            });
            return returnValue;
        }
    }
}
