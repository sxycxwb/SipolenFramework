using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.TaskVar 接口部分：任务变量管理

    public partial interface IWorkFlowTemplateService
    {
        /// <summary>
        /// 增加任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务变量实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
        string InsertTaskVar(UserInfo userInfo, TaskVarEntity entity);

        /// <summary>
        /// 修改任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务变量实体</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int UpdateTaskVar(UserInfo userInfo, TaskVarEntity entity);

        /// <summary>
        /// 删除任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">任务变量主键</param>
        /// <returns>大于0成功</returns>
        [OperationContract]
        int DeleteTaskVar(UserInfo userInfo, string taskVarId);

        /// <summary>
        /// 获得任务变量信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">变量Id</param>
        /// <returns>任务变量信息</returns>
        [OperationContract]
        DataTable GetTaskVarTable(UserInfo userInfo, string taskVarId);

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>流程变量列表</returns>
        [OperationContract]
        DataTable GetWorkFlowVar(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskId">任务模板Id</param>
        /// <returns>任务变量列表</returns>
        [OperationContract]
        DataTable GetTaskVar(UserInfo userInfo, string taskId);

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="varName">变量名称</param>
        /// <returns>任务变量列表</returns>
        [OperationContract]
        DataTable GetTaskVarByName(UserInfo userInfo, string workFlowId, string varName);

        /// <summary>
        /// 获得流程变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>流程变量列表</returns>
        [OperationContract]
        DataTable GetWorkFlowAllVar(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 判断任务变量是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="taskVarId">任务变量Id</param>
        /// <returns>true存在</returns>
        [OperationContract]
        bool ExistsTaskVar(UserInfo userInfo, string taskVarId);

    }
}
