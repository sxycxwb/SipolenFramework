using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkOutTime接口部分：超时设置管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加工作任务超时设置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertWorkOutTime(UserInfo userInfo, WorkOutTimeEntity entity);

        /// <summary>
        /// 更新工作任务超时设置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">工作任务超时实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateWorkOutTime(UserInfo userInfo, WorkOutTimeEntity entity);

        /// <summary>
        /// 根据工作任务模版主键删除超时设置记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteWorkOutTime(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 依据工作任务模版Id获得超时设置列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>超时设置列表</returns>
        [OperationContract]
        DataTable GetWorkOutTimeTable(UserInfo userInfo, string workTaskId);
        /// <summary>
        /// 得到指定流程模版所有的超时设置列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>超时设置列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllOutTimeTable(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 依据工作任务主键得到超时设置实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">工作任务Id</param>
        /// <returns>超时设置实体</returns>
        [OperationContract]
        WorkOutTimeEntity GetWorkOutTimeInfo(UserInfo userInfo, string workTaskId);

    }
}
