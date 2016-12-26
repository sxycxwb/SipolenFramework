using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.Operator 接口部分：处理者管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">处理者实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertOperator(UserInfo userInfo, OperatorEntity entity);

        /// <summary>
        /// 修改处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">处理者实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateOperator(UserInfo userInfo, OperatorEntity entity);

        /// <summary>
        /// 删除处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteOperator(UserInfo userInfo, string operatorId);

        /// <summary>
        /// 获得处理者信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operId">处理者主键</param>
        /// <returns>处理者信息</returns>
        [OperationContract]
        DataTable GetOperatorTable(UserInfo userInfo, string operId);

        /// <summary>
        /// 得到指定流程模版所有的处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>指定流程模版所有的处理者列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllOperator(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 获得模板中的处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>处理者</returns>
        [OperationContract]
        string GetOperContent(UserInfo userInfo, string operatorId);

        /// <summary>
        /// 获得指定处理者策略
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>处理者策略</returns>
        [OperationContract]
        string GetOperRelation(UserInfo userInfo, string operatorId);

        /// <summary>
        /// 是否存在指定处理者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorId">处理者Id</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsOperator(UserInfo userInfo, string operatorId);
    }
}
