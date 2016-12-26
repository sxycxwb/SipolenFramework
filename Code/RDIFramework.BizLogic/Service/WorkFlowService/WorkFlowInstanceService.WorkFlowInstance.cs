using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class WorkFlowInstanceService
    {
        #region public string CreateWorkFlowInstance(UserInfo userInfo, WorkFlowInstanceEntity entity) 创建工作流实例
        /// <summary>
        /// 创建工作流实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程实例实体</param>
        /// <returns>主键</returns>
        public string CreateWorkFlowInstance(UserInfo userInfo, WorkFlowInstanceEntity entity)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_CreateWorkFlowInstance);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo); 
                // 调用方法，并且返回运行结果
                returnValue = manager.Create(entity);
            });
            return returnValue;
        }
        #endregion

        #region public DataTable GetToDoWorkTasks(UserInfo userInfo, string userId, int topsize) 待办任务，包括新任务和已认领任务
        /// <summary>
        /// 待办任务，包括新任务和已认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns></returns>
        public DataTable GetToDoWorkTasks(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetToDoWorkTasks);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetToDoWorkTasks(userId,topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable ClaimWorkTask(UserInfo userInfo, string userId, int topsize) 未认领的任务
        /// <summary>
        /// 未认领的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>未认领的任务列表</returns>
        public DataTable ClaimWorkTask(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_ClaimWorkTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.ClaimWorkTask(userId, topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetUnClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null) 未认领的任务(分页方式)
        /// <summary>
        /// 未认领的任务(分页方式)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>未认领的任务列表</returns>
        public DataTable GetUnClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetUnClaimedTaskByPage(userId, search, out myrecordCount, pageIndex, pageSize, order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable WorkCompleteWorkTask(UserInfo userInfo, string workflowInsId, string taskinscaption) 得到指定流程已完成的任务
        /// <summary>
        /// 得到指定流程已完成的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例id</param>
        /// <param name="taskInsCaption">工作任务实例名称</param>
        /// <returns>本流程中已完成的任务列表</returns>
        public DataTable WorkCompleteWorkTask(UserInfo userInfo, string workFlowInsId, string taskInsCaption)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkCompleteWorkTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkCompleteWorkTask(workFlowInsId, taskInsCaption);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowAllTask(UserInfo userInfo, string userId, int topsize) 我参与的任务
        /// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我参与的任务列表</returns>
        public DataTable WorkFlowAllTask(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkflowAllTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkflowAllTask(userId, topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowAllTaskByPage(UserInfo userInfo, string userId, out int recordCount, int pageIndex = 0, int pageSize = 100, string flag = "All", string search = "") 我参与的任务
        /// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="flag">标志，默认为"All”</param>
        /// <param name="search">条件表达式</param>
        /// <returns>我参与的任务列表</returns>
        public DataTable WorkFlowAllTaskByPage(UserInfo userInfo, string userId, out int recordCount, int pageIndex = 0, int pageSize = 100, string flag = "All", string search = "")
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkFlowAllTaskByPage);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkFlowAllTaskByPage(userId, out myrecordCount, pageIndex, pageSize, flag,search);
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowClaimedTask(UserInfo userInfo, string userId, int topsize) 我已认领的任务
        /// <summary>
        /// 我已认领的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我已认领的任务列表</returns>
        public DataTable WorkFlowClaimedTask(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkflowClaimedTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkflowClaimedTask(userId, topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null) 我已认领的任务(分页方式)
        /// <summary>
        /// 我已认领的任务(分页方式)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>已认领的任务列表</returns>
        public DataTable GetWorkFlowClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowClaimedTaskByPage(userId, search, out myrecordCount, pageIndex, pageSize, order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowInstanceRunning(UserInfo userInfo, int topsize) 正在运行的流程实例列表
        /// <summary>
        /// 正在运行的流程实例列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="topsize">显示条数</param>
        /// <returns>正在运行的流程实例列表</returns>
        public DataTable GetWorkFlowInstanceRunning(UserInfo userInfo, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowInstanceRunning);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowInstanceRunning(topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowInstanceComplete(UserInfo userInfo, int topsize) 已完成的流程实例
        /// <summary>
        /// 已完成的流程实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="topsize">显示条数</param>
        /// <returns>已完成的流程实例</returns>
        public DataTable GetWorkFlowInstanceComplete(UserInfo userInfo, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowInstanceComplete);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkFlowInstanceComplete(topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowInstanceDTByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null) 获得流程实例实例分页数据
        /// <summary>
        /// 获得流程实例实例分页数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetWorkFlowInstanceDTByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowInstanceDTByPage);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetDTByPage(out myrecordCount, pageIndex, pageSize, search, order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowCompletedTask(UserInfo userInfo, string userId, int topsize) 我已完成的任务
        /// <summary>
        /// 我已完成的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>我已完成的任务表</returns>
        public DataTable WorkFlowCompletedTask(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkFlowCompletedTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkflowCompletedTask(userId, topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowCompletedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null) 我已完成的任务（分页方式）
        /// <summary>
        /// 我已完成的任务（分页方式）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="search">查询</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable WorkFlowCompletedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null)
        {
            var parameter = ParameterUtil.CreateWithOutMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            int myrecordCount = 0;
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkFlowCompletedTaskByPage(userId, search,out myrecordCount,pageIndex,pageSize,order);
            });
            recordCount = myrecordCount;
            return dataTable;
        }
        #endregion

        #region public DataTable WorkFlowAbnormalTask(UserInfo userInfo, string userId, int topsize) 异常终止的任务
        /// <summary>
        /// 异常终止的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>异常终止的任务表</returns>
        public DataTable WorkFlowAbnormalTask(UserInfo userInfo, string userId, int topsize)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_WorkFlowAbnormalTask);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.WorkflowAbnormalTask(userId, topsize);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowInstance(UserInfo userInfo, string workflowInsId) 获得一个流程实例实例的信息
        /// <summary>
        /// 获得一个流程实例实例的信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">工作流程实例Id</param>
        /// <returns></returns>
        public DataTable GetWorkFlowInstance(UserInfo userInfo, string workflowInsId)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowInstance);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowInstance(workflowInsId);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowHistory(UserInfo userInfo, string workflowinsid) 流程历史
        /// <summary>
        /// 流程历史
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowinsid">工作流程实例Id</param>
        /// <returns>流程历史列表</returns>
        public DataTable GetWorkFlowHistory(UserInfo userInfo, string workflowinsid)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowHistory);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowHistory(workflowinsid);
            });
            return dataTable;
        }
        #endregion

        #region public DataTable GetWorkFlowBack(UserInfo userInfo, string workflowinsid) 加载退回原因
        /// <summary>
        /// 加载退回原因
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowinsid">工作流程实例Id</param>
        /// <returns>退回原因列表</returns>
        public DataTable GetWorkFlowBack(UserInfo userInfo, string workflowinsid)
        {
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetWorkFlowBack);
            var dataTable = new DataTable(WorkTaskInstanceTable.TableName);
            ServiceUtil.ProcessWorkFlowDb(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                dataTable = manager.GetWorkflowback(workflowinsid);
            });
            return dataTable;
        }
        #endregion

        #region public int SetWorkFlowInstanceOver(UserInfo userInfo, string workflowInsId) 设定流程实例正常结束
        /// <summary>
        /// 设定流程实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">工作流程实例Id</param>
        /// <returns></returns>
        public int SetWorkFlowInstanceOver(UserInfo userInfo, string workflowInsId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetWorkflowInstanceOver);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.SetWorkflowInstanceOver(workflowInsId);
            });
            return returnValue;
        }
        #endregion

        #region public int SetCurrTaskId(UserInfo userInfo, string workflowInsId, string nowtaskId) 设定流程实例的当前位置
        /// <summary>
        /// 设定流程实例的当前位置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">工作流程实例Id</param>
        /// <param name="nowtaskId"></param>
        /// <returns></returns>
        public int SetCurrTaskId(UserInfo userInfo, string workflowInsId, string nowtaskId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetCurrTaskId);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                // 调用方法，并且返回运行结果
                returnValue = manager.SetCurrTaskId(workflowInsId, nowtaskId);
            });
            return returnValue;
        }
        #endregion

        #region public string SetSuspend(UserInfo userInfo, string workflowInsId) 设定流程实例挂起
        /// <summary>
        /// 设定流程实例挂起
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">实例实例id</param>
        /// <returns></returns>
        public string SetSuspend(UserInfo userInfo, string workflowInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetSuspend);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.SetSuspend(workflowInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string SetResume(UserInfo userInfo, string workflowInsId) 设定流程实例取消挂起
        /// <summary>
        /// 设定流程实例取消挂起
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">实例实例id</param>
        /// <returns></returns>
        public string SetResume(UserInfo userInfo, string workflowInsId)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetResume);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.SetResume(workflowInsId);
            });
            return returnValue;
        }
        #endregion

        #region public string SetAbnormal(UserInfo userInfo, string workflowInsId, string userId, string msg) 设定流程实例异常终止
        /// <summary>
        /// 设定流程实例异常终止
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workflowInsId">实例实例id</param>
        /// <param name="userId">用户id</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public string SetAbnormal(UserInfo userInfo, string workflowInsId, string userId, string msg)
        {
            string returnValue = string.Empty;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_SetAbnormal);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.SetAbnormal(workflowInsId, userId, msg);
            });
            return returnValue;
        }
        #endregion

        #region public int GetClaimingTaskCount(UserInfo userInfo, string userId) 未认领任务的个数
        /// <summary>
        /// 未认领任务的个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户未认领任务数</returns>
        public int GetClaimingTaskCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetClaimingTaskCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetClaimingTaskCount(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int GetToDoTasksCount(UserInfo userInfo, string userId) 待办任务
        /// <summary>
        /// 待办任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户待办任务数</returns>
        public int GetToDoTasksCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetToDoTasksCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetToDoTasksCount(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int GetClaimedTaskCount(UserInfo userInfo, string userId) 已认领任务个数
        /// <summary>
        /// 已认领任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户已认领任务数</returns>
        public int GetClaimedTaskCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetClaimedTaskCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetClaimedTaskCount(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int GetAllTaskCount(UserInfo userInfo, string userId) 我参与的任务个数
        /// <summary>
        /// 我参与的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我参与的任务数</returns>
        public int GetAllTaskCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetAllTaskCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetAllTaskCount(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int GetCompletedTaskCount(UserInfo userInfo, string userId) 我完成的任务个数
        /// <summary>
        /// 我完成的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我完成的任务数</returns>
        public int GetCompletedTaskCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetCompletedTaskCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetCompletedTaskCount(userId);
            });
            return returnValue;
        }
        #endregion

        #region public int GetAbnormalTaskCount(UserInfo userInfo, string userId) 我异常终止的任务个数
        /// <summary>
        /// 我异常终止的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我异常终止的任务数</returns>
        public int GetAbnormalTaskCount(UserInfo userInfo, string userId)
        {
            int returnValue = -1;
            var parameter = ParameterUtil.CreateWithMessage(userInfo, MethodBase.GetCurrentMethod(), this.serviceName, RDIFrameworkMessage.WorkFlowInstanceService_GetAbnormalTaskCount);
            ServiceUtil.ProcessWorkFlowDbWithTransaction(userInfo, parameter, dbProvider =>
            {
                var manager = new WorkFlowInstanceManager(dbProvider, userInfo);
                returnValue = manager.GetAbnormalTaskCount(userId);
            });
            return returnValue;
        }
        #endregion
    }
}
