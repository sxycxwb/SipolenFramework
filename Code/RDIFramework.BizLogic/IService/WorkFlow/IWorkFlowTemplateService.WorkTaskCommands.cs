using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkTaskCommands接口部分：工作任务命令管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务命令实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertWorkTaskCommands(UserInfo userInfo, WorkTaskCommandsEntity entity);

        /// <summary>
        /// 修改任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务命令实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateWorkTaskCommands(UserInfo userInfo, WorkTaskCommandsEntity entity);

        /// <summary>
        /// 删除一个任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteWorkTaskCommands(UserInfo userInfo, string commandId);

        /// <summary>
        /// 得到指定流程模版的所有任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <returns>任务命令列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllCommands(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 通过指定任务命令主键得到任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">任务命令Id</param>
        /// <returns>任务命令列表</returns>
        [OperationContract]
        DataTable GetTaskCommandsTable(UserInfo userInfo, string commandId);

        /// <summary>
        /// 是否存在指定任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="commandId">任务命令Id</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsWorkTaskCommands(UserInfo userInfo, string commandId);
    }
}
