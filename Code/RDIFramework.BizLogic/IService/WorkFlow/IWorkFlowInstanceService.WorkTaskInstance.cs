using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowInstanceService.WorkTaskInstance接口部分：流程任务实例管理

    public partial interface IWorkFlowInstanceService
    {
        /// <summary>
        /// 创建新任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务实例实体</param>
        /// <returns>主键</returns>
        [OperationContract]
        string CreateWorkTaskInstance(UserInfo userInfo, WorkTaskInstanceEntity entity);

        /// <summary>
        /// 动态指定新的任务实例处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">实体-加签处理人、下一处理人（一般用于动态指定）</param>
        /// <returns>主键</returns>
        [OperationContract]
        string CreateWorkTaskInsNextOper(UserInfo userInfo, WorkTaskInsNextOperEntity entity);

        /// <summary>
        /// 是否存在指定任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        bool WorkTaskInstanceExist(UserInfo userInfo, string workTaskInsId);

        /// <summary>
        /// 设定任务实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatedDes">处理说明</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        int SetWorkTaskInstanceOver(UserInfo userInfo, string operatedDes, string workTaskInsId);

        /// <summary>
        /// 设定任务实例成功提交信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="successMsg">任务提交成功信息</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        int SetWorkTaskInstanceSuccessMsg(UserInfo userInfo, string successMsg, string workTaskInsId);

        /// <summary>
        /// 获得任务实例成功提交信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        string GetTaskToWhoMsg(UserInfo userInfo, string workTaskInsId);

        /// <summary>
        /// 获得任务被谁处理
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务id</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <returns></returns>
        [OperationContract]
        string GetTaskDoneWhoMsg(UserInfo userInfo, string workTaskId, string workflowInsId);

        /// <summary>
        /// 判断任务是否是由当前用户操作
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [OperationContract]
        bool WorkTaskpd(UserInfo userInfo, string workTaskInsId, string userId);

        /// <summary>
        /// 获得任务实例提交后返回信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        string GetResultMsg(UserInfo userInfo, string workTaskInsId);

        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">认领的任务Id</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskClaim(UserInfo userInfo, string userId, string operatorInsId);

        /// <summary>
        /// 放弃认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskUnClaim(UserInfo userInfo, string userId, string operatorInsId);

        /// <summary>
        /// 指派任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="assignUserId">指派人的Id</param>
        /// <param name="operatorInsId">处理人实例Id</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskAssign(UserInfo userInfo, string userId, string assignUserId, string operatorInsId);

        /// <summary>
        /// 任务退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskBack(UserInfo userInfo, string userId, string operatorInsId, string backyy);

        /// <summary>
        /// 任务任意退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">退回的处理实例Id</param>
        /// <param name="backyy">退回原因</param>
        /// <param name="workflowInsId">上级</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskBackry(UserInfo userInfo, string userId, string operatorInsId, string backyy, string workflowInsId);

        /// <summary>
        /// 任务撤回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        string WorkTaskRevoke(UserInfo userInfo, string userId, string workTaskInsId);

        /// <summary>
        /// 获得任务实例列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskInsId">任务实例Id</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetTaskInsTable(UserInfo userInfo, string workTaskInsId);

        /// <summary>
        /// 获得加签处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <param name="workTaskId">任务模版id<</param>
        /// <param name="workflowInsId">流程实例id</param>
        /// <param name="workTaskInsId">任务实例id</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetTaskInsNextOperTable(UserInfo userInfo, string workFlowId, string workTaskId, string workflowInsId, string workTaskInsId);
    }
}
