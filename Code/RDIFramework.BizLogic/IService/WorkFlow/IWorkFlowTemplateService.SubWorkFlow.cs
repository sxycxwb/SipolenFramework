using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.SubWorkFlow 接口部分：子流程节点配置管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子流程节点配置实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertSubWorkFlow(UserInfo userInfo, SubWorkFlowEntity entity);

        /// <summary>
        /// 修改子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">子流程节点配置实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateSubWorkFlow(UserInfo userInfo, SubWorkFlowEntity entity);

        /// <summary>
        /// 删除子流程节点配置
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteSubWorkFlow(UserInfo userInfo, string workFlowId, string taskId);

        /// <summary>
        /// 获得子流程配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>子流程配置信息</returns>
        [OperationContract]
        DataTable GetSubWorkflowTable(UserInfo userInfo, string workFlowId, string taskId);

        /// <summary>
        /// 获得流程的所有子流程
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>指定流程的所有子流程列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllSub(UserInfo userInfo, string workFlowId);
        /// <summary>
        /// 判断子流程配置信息是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="workFlowId">流程模版主键</param>
        /// <param name="taskId">任务模版主键</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsSubWorkFlow(UserInfo userInfo, string workFlowId, string taskId);

        /// <summary>
        /// 判断子流程配置信息是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        ///<param name="subId">子流程主键</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsSubWorkFlowBySubId(UserInfo userInfo, string subId);

    }
}
