using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowInstanceService
    {
        #region public string CreateWorkTaskInstance(UserInfo userInfo, WorkTaskInstanceEntity entity) 创建新任务实例
        /// <summary>
        /// 创建新任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务实例实体</param>
        /// <returns>主键</returns>
        public string CreateWorkTaskInstance(UserInfo userInfo, WorkTaskInstanceEntity entity)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_CreateWorkTaskInstance);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.Create(entity);              
            });          
            return returnValue;
        }
        #endregion

        #region public string CreateWorkTaskInsNextOper(UserInfo userInfo, WorkTaskInsNextOperEntity entity) 动态指定新的任务实例处理人
        /// <summary>
        /// 动态指定新的任务实例处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体-加签处理人、下一处理人（一般用于动态指定）</param>
        /// <returns>主键</returns>
        public string CreateWorkTaskInsNextOper(UserInfo userInfo, WorkTaskInsNextOperEntity entity)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_CreateWorkTaskInsNextOper);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInsNextOperManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.AddEntity(entity);
            });
            return returnValue;
        }
        #endregion

        #region public bool WorkTaskInstanceExist(UserInfo userInfo, string worktaskInsId) 是否存在指定任务实例
        /// <summary>
        /// 是否存在指定任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public bool WorkTaskInstanceExist(UserInfo userInfo, string worktaskInsId)
        {
            bool returnValue  = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskInstanceExist);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.Exists(worktaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public int SetWorkTaskInstanceOver(UserInfo userInfo, string operatedDes, string worktaskInsId) 设定任务实例正常结束
        /// <summary>
        /// 设定任务实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatedDes">处理说明</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public int SetWorkTaskInstanceOver(UserInfo userInfo, string operatedDes, string worktaskInsId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetWorkTaskInstanceOver);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.SetWorkTaskInstanceOver(operatedDes, worktaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public int SetWorkTaskInstanceSuccessMsg(UserInfo userInfo, string successMsg, string worktaskInsId) 设定任务实例成功提交信息
        /// <summary>
        /// 设定任务实例成功提交信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="successMsg">任务提交成功信息</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public int SetWorkTaskInstanceSuccessMsg(UserInfo userInfo, string successMsg, string worktaskInsId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetSuccessMsg);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.SetSuccessMsg(successMsg, worktaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string GetTaskToWhoMsg(UserInfo userInfo, string worktaskInsId) 获得任务实例成功提交信息
        /// <summary>
        /// 获得任务实例成功提交信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public string GetTaskToWhoMsg(UserInfo userInfo, string worktaskInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetTaskToWhoMsg);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.GetTaskToWhoMsg(worktaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string GetTaskDoneWhoMsg(UserInfo userInfo, string worktaskId, string workflowInsId) 获得任务被谁处理
        /// <summary>
        /// 获得任务被谁处理
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskId">任务id</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <returns></returns>
        public string GetTaskDoneWhoMsg(UserInfo userInfo, string worktaskId, string workflowInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetTaskDoneWhoMsg);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.GetTaskDoneWhoMsg(worktaskId, workflowInsId);
            });
            return returnValue;
        }
        #endregion

        #region public bool WorkTaskpd(UserInfo userInfo, string worktaskInsid, string userId) 判断任务是否是由当前用户操作
        /// <summary>
        /// 判断任务是否是由当前用户操作
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsid">任务实例id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public bool WorkTaskpd(UserInfo userInfo, string worktaskInsid, string userId)
        {
            bool returnValue = false;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskpd);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskpd(worktaskInsid, userId);
            });
            return returnValue;
        }
        #endregion 

        #region public string GetResultMsg(UserInfo userInfo, string worktaskInsId) 获得任务实例提交后返回信息
        /// <summary>
        /// 获得任务实例提交后返回信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public string GetResultMsg(UserInfo userInfo, string worktaskInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetResultMsg);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.GetResultMsg(worktaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskClaim(UserInfo userInfo, string userId, string operatorInsId) 认领任务
        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">认领的任务Id</param>
        /// <returns></returns>
        public string WorkTaskClaim(UserInfo userInfo, string userId, string operatorInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskClaim);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskClaim(userId, operatorInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskUnClaim(UserInfo userInfo, string userId, string operatorInsId) 放弃认领任务
        /// <summary>
        /// 放弃认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        public string WorkTaskUnClaim(UserInfo userInfo, string userId, string operatorInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskUnClaim);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskUnClaim(userId, operatorInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskAssign(UserInfo userInfo, string userId, string assignUserId, string operatorInsId) 指派任务
        /// <summary>
        /// 指派任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="assignUserId">指派人的Id</param>
        /// <param name="operatorInsId">处理人实例Id</param>
        /// <returns></returns>
        public string WorkTaskAssign(UserInfo userInfo, string userId, string assignUserId, string operatorInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskAssign);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskAssign(userId, assignUserId, operatorInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskBack(UserInfo userInfo, string userId, string operatorInsId, string backyy) 任务退回
        /// <summary>
        /// 任务退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <returns></returns>
        public string WorkTaskBack(UserInfo userInfo, string userId, string operatorInsId, string backyy)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskBack);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskBack(userId, operatorInsId, backyy);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskBackry(UserInfo userInfo, string userId, string operatorInsId, string backyy, string workflowInsId) 任务任意退回
        /// <summary>
        /// 任务任意退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <param name="workflowInsId">上级</param>
        /// <returns></returns>
        public string WorkTaskBackry(UserInfo userInfo, string userId, string operatorInsId, string backyy, string workflowInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskBackry);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskBackry(userId, operatorInsId, backyy, workflowInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string WorkTaskRevoke(UserInfo userInfo, string userId, string workTaskInsId) 任务撤回
        /// <summary>
        /// 任务撤回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        public string WorkTaskRevoke(UserInfo userInfo, string userId, string workTaskInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkTaskRevoke);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.WorkTaskRevoke(userId, workTaskInsId);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetTaskInsTable(UserInfo userInfo, string worktaskInsId) 获得任务实例列表
        /// <summary>
        /// 获得任务实例列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="worktaskInsId">任务实例Id</param>
        /// <returns></returns>
        public DataTable GetTaskInsTable(UserInfo userInfo, string worktaskInsId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetTaskInsTable);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetTaskInsTable(worktaskInsId);                
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetTaskInsNextOperTable(UserInfo userInfo, string workflowId, string worktaskId, string workflowInsId, string worktaskInsId)
        /// <summary>
        /// 获得加签处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowId">流程模版id</param>
        /// <param name="worktaskId">任务模版id<</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <param name="worktaskInsId">任务实例id</param>
        /// <returns></returns>
        public DataTable GetTaskInsNextOperTable(UserInfo userInfo, string workflowId, string worktaskId, string workflowInsId, string worktaskInsId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetTaskInsNextOperTable);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkTaskInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetTaskInsNextOperTable(workflowId,worktaskId,workflowInsId,worktaskInsId);
            });
            return dataTable;
        }
        #endregion
    }
}
