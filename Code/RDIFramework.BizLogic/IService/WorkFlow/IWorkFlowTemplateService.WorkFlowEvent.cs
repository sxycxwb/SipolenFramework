using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkFlowEvent接口部分：流程分类管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加事件通知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">事件通知实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertWorkFlowEvent(UserInfo userInfo, WorkFlowEventEntity entity);

        /// <summary>
        /// 更新事件通知
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">事件通知实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateWorkFlowEvent(UserInfo userInfo, WorkFlowEventEntity entity);

        /// <summary>
        /// 根据任务模版主键删除事件通知记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteWorkFlowEvent(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 获得指定任务模版事件通知列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>事件通知列表</returns>
        [OperationContract]
        DataTable GetWorkFlowEventTable(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 得到指定流程模版所有的事件通知列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>事件通知列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllEventTable(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 得到事件通知列表实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>事件通知列表实体</returns>
        [OperationContract]
        WorkFlowEventEntity GetWorkFlowEventInfo(UserInfo userInfo, string workTaskId);

    }
}
