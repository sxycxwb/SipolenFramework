using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowTemplateService
    {
        /// <summary>
        /// 增加任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务节点实体</param>
        /// <returns>增加成功返回实体主键</returns>
        public string InsertWorkTask(UserInfo userInfo, WorkTaskEntity entity)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_InsertWorkTask);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.InsertTask(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 修改任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务节点实体</param>
        /// <returns>大于0修改成功</returns>
        public int UpdateWorkTask(UserInfo userInfo, WorkTaskEntity entity)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_UpdateWorkTask);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.UpdateTask(entity);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除一个任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版Id</param>
        /// <param name="worktaskId">任务模板Id</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteWorkTask(UserInfo userInfo, string workflowId, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTask);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteTask(workflowId,worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定任务的所有处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteWorkTaskAllOperator(UserInfo userInfo, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskAllOperator);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteAllOperator(worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定任务的所有任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteWorkTaskAllTaskVar(UserInfo userInfo, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskAllTaskVar);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteAllTaskVar(worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定任务的所有任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteWorkTaskAllCommands(UserInfo userInfo, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskAllCommands);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteAllCommands(worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定任务的所有控制权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版id</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        public int DeleteWorkTaskAllPower(UserInfo userInfo, string workflowId, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskAllPower);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteAllPower(workflowId,worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 删除指定任务的所有表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskId">任务模板id</param>
        /// <returns>于0操作成功</returns>
        public int DeleteWorkTaskAllControls(UserInfo userInfo, string worktaskId)
        {
            var returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_DeleteWorkTaskAllControls);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.DeleteAllControls(worktaskId);
            });
            return returnValue;
        }
        
        /// <summary>
        /// 获得指定流程模版的任务列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版Id</param>
        /// <returns>任务模版列表</returns>
        public DataTable GetWorkTasks(UserInfo userInfo, string workflowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTasks);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetWorkTasks(workflowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务处理者列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务处理者列表</returns>
        public DataTable GetWorkTaskOperator(UserInfo userInfo, string workflowId, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskOperator);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskOperator(workflowId, workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务命令列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务命令列表</returns>
        public DataTable GetWorkTaskCommands(UserInfo userInfo, string workflowId, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskCommands);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskCommands(workflowId, workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得控制权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>控制权限列表</returns>
        public DataTable GetWorkTaskPower(UserInfo userInfo, string workflowId, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskPower);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskPower(workflowId, workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得开始任务节点列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>开始任务节点列表</returns>
        public DataTable GetStartTask(UserInfo userInfo, string workFlowId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetStartTask);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetStartTask(workFlowId);
            });
            return dataTable;
        }

        /// <summary>
        /// 判断节点是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>true:存在</returns>
        public bool ExistWorkTask(UserInfo userInfo, string workTaskId)
        {
            var returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_ExistWorkTask);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.ExistTask(workTaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得任务名称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns></returns>
        public string GetWorkTaskCaption(UserInfo userInfo, string workTaskId)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskCaption);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.GetTaskCaption(workTaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 获得任务模版列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模版列表</returns>
        public DataTable GetWorkTaskTable(UserInfo userInfo, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskTable);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskTable(workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得一个任务模板在流程实例中的所有任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版Id</param>
        /// <param name="workflowInsId">流程实例Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模板在流程实例中的所有任务实例列表</returns>
        public DataTable GetWorkTaskInstance(UserInfo userInfo, string workflowId, string workflowInsId, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskInstance);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskInstance(workflowId, workflowInsId, workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务变量列表</returns>
        public DataTable GetWorkTaskVar(UserInfo userInfo, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskVar);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskVar(workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 获得任务节点绑定的表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>表单列表</returns>
        public DataTable GetWorkTaskControls(UserInfo userInfo, string workTaskId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_GetWorkTaskControls);
            var dataTable = new DataTable(WorkTaskTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                dataTable = manager.GetTaskControls(workTaskId);
            });
            return dataTable;
        }

        /// <summary>
        /// 任务节点绑定表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userCtrlId">表单id</param>
        /// <param name="workflowid">流程模版Id</param>
        /// <param name="worktaskId">任务节点id</param>
        /// <returns>绑定成功返回主键</returns>
        public string SetWorkTaskUserCtrls(UserInfo userInfo, string userCtrlId, string workflowid, string worktaskId)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_SetWorkTaskUserCtrls);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.SetTaskUserCtrls(userCtrlId, workflowid, worktaskId);
            });
            return returnValue;
        }

        /// <summary>
        /// 设置任务节点的控制权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="powerName">权限名</param>
        /// <param name="workflowid">workflowid</param>
        /// <param name="worktaskId">worktaskId</param>
        /// <returns></returns>
        public string SetWorkTaskPower(UserInfo userInfo, string powerName, string workflowid, string worktaskId)
        {
            var returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowTemplateService_SetWorkTaskPower);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskManager(dbProvider, userInfo);
                returnValue = manager.SetTaskPower(powerName, workflowid, worktaskId);
            });
            return returnValue;
        }
    }
}
