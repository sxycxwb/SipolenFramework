using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;


    //IWorkFlowInstanceService.WorkFlowInstance接口部分：工作流实例管理

    public partial interface IWorkFlowInstanceService
    {
        /// <summary>
        /// 创建工作流实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程实例实体</param>
        /// <returns>主键</returns>
        [OperationContract]
        string CreateWorkFlowInstance(UserInfo userInfo, WorkFlowInstanceEntity entity);

        /// <summary>
        /// 待办任务，包括新任务和已认领任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetToDoWorkTasks(UserInfo userInfo, string userId, int topSize);

        /// <summary>
        /// 未认领的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns>未认领的任务列表</returns>
        [OperationContract]
        DataTable ClaimWorkTask(UserInfo userInfo, string userId, int topSize);

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
        [OperationContract]
        DataTable GetUnClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount,int pageIndex = 0, int pageSize = 100, string order = null);

        /// <summary>
        /// 返回本流程中已完成的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例id</param>
        /// <param name="taskInsCaption">工作任务实例名称</param>
        /// <returns>本流程中已完成的任务列表</returns>
        [OperationContract]
        DataTable WorkCompleteWorkTask(UserInfo userInfo, string workFlowInsId, string taskInsCaption);

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
        [OperationContract]
        DataTable WorkFlowCompletedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount, int pageIndex = 0, int pageSize = 100, string order = null);

        /// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns>我参与的任务列表</returns>
        [OperationContract]
        DataTable WorkFlowAllTask(UserInfo userInfo, string userId, int topSize);

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
        [OperationContract]
        DataTable WorkFlowAllTaskByPage(UserInfo userInfo, string userId, out int recordCount, int pageIndex = 0, int pageSize = 100, string flag = "All", string search = "");

        /// <summary>
        /// 我已认领的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns>我已认领的任务列表</returns>
        [OperationContract]
        DataTable WorkFlowClaimedTask(UserInfo userInfo, string userId, int topSize);

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
        [OperationContract]
        DataTable GetWorkFlowClaimedTaskByPage(UserInfo userInfo, string userId, string search, out int recordCount,int pageIndex = 0, int pageSize = 100, string order = null);

        /// <summary>
        /// 正在运行的流程实例列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="topSize">显示条数</param>
        /// <returns>正在运行的流程实例列表</returns>
        [OperationContract]
        DataTable GetWorkFlowInstanceRunning(UserInfo userInfo, int topSize);

        /// <summary>
        /// 已完成的流程实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="topSize">显示条数</param>
        /// <returns>已完成的流程实例</returns>
        [OperationContract]
        DataTable GetWorkFlowInstanceComplete(UserInfo userInfo, int topSize);

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
        [OperationContract]
        DataTable GetWorkFlowInstanceDTByPage(UserInfo userInfo, string search, out int recordCount, int pageIndex = 0,int pageSize = 100, string order = null);


        /// <summary>
        /// 我已完成的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns>我已完成的任务表</returns>
        [OperationContract]
        DataTable WorkFlowCompletedTask(UserInfo userInfo, string userId, int topSize);

        /// <summary>
        /// 异常终止的任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="topSize">返回的的记录条数</param>
        /// <returns>异常终止的任务表</returns>
        [OperationContract]
        DataTable WorkFlowAbnormalTask(UserInfo userInfo, string userId, int topSize);

        /// <summary>
        /// 获得一个流程实例实例的信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例Id</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetWorkFlowInstance(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 流程历史
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例Id</param>
        /// <returns>流程历史列表</returns>
        [OperationContract]
        DataTable GetWorkFlowHistory(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 加载退回原因
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例Id</param>
        /// <returns>退回原因列表</returns>
        [OperationContract]
        DataTable GetWorkFlowBack(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 设定流程实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例Id</param>
        /// <returns></returns>
        [OperationContract]
        int SetWorkFlowInstanceOver(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 设定流程实例的当前位置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">工作流程实例Id</param>
        /// <param name="nowTaskId"></param>
        /// <returns></returns>
        [OperationContract]
        int SetCurrTaskId(UserInfo userInfo, string workFlowInsId, string nowTaskId);

        /// <summary>
        /// 设定流程实例挂起
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">实例实例id</param>
        /// <returns></returns>
        [OperationContract]
        string SetSuspend(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 设定流程实例取消挂起
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">实例实例id</param>
        /// <returns></returns>
        [OperationContract]
        string SetResume(UserInfo userInfo, string workFlowInsId);

        /// <summary>
        /// 设定流程实例异常终止
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowInsId">实例实例id</param>
        /// <param name="userId">用户id</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        [OperationContract]
        string SetAbnormal(UserInfo userInfo, string workFlowInsId, string userId, string msg);

        /// <summary>
        /// 未认领任务的个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户未认领任务数</returns>
        [OperationContract]
        int GetClaimingTaskCount(UserInfo userInfo, string userId);

        /// <summary>
        /// 待办任务
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户待办任务数</returns>
        [OperationContract]
        int GetToDoTasksCount(UserInfo userInfo, string userId);

        /// <summary>
        /// 已认领任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>指定用户已认领任务数</returns>
        [OperationContract]
        int GetClaimedTaskCount(UserInfo userInfo, string userId);

        /// <summary>
        /// 我参与的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我参与的任务数</returns>
        [OperationContract]
        int GetAllTaskCount(UserInfo userInfo, string userId);

        /// <summary>
        /// 我完成的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我完成的任务数</returns>
        [OperationContract]
        int GetCompletedTaskCount(UserInfo userInfo, string userId);

        /// <summary>
        /// 我异常终止的任务个数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户id</param>
        /// <returns>我异常终止的任务数</returns>
        [OperationContract]
        int GetAbnormalTaskCount(UserInfo userInfo, string userId);
    }
}
