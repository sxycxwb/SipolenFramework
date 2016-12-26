using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkLink接口部分：流程连线配置管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程连线实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertWorkLink(UserInfo userInfo, WorkLinkEntity entity);

        /// <summary>
        /// 更新流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">流程连线实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateWorkLink(UserInfo userInfo, WorkLinkEntity entity);

        /// <summary>
        /// 删除流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workLinkId">流程连线Id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteWorkLine(UserInfo userInfo, string workFlowId, string workLinkId);

        /// <summary>
        /// 获得流程连线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>流程连线列表</returns>
        [OperationContract]
        DataTable GetWorkLinks(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 判断流程连线是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="linkId">流程连线Id</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsWorkLink(UserInfo userInfo, string linkId);

    }
}
