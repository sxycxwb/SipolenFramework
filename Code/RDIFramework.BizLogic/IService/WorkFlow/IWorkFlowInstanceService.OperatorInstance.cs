using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowInstanceService.OperatorInstance接口部分：处理者实例管理

    public partial interface IWorkFlowInstanceService
    {
        /// <summary>
        /// 创建处理者实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">创建处理者实例实体</param>
        /// <returns>主键</returns>
        [OperationContract]
        string CreateOperatorInstance(UserInfo userInfo, OperatorInstanceEntity entity);

        /// <summary>
        /// 获得一个要处理的信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetOperatorInstance(UserInfo userInfo, string operatorInsId);

        /// <summary>
        /// 设定处理者实例正常结束
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户Id</param>
        /// <param name="operatorInsId">操作者实例id</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int SetOperatorInstanceOver(UserInfo userInfo, string userId, string operatorInsId);
    }
}
