using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    //IWorkFlowTemplateService.WorkTask接口部分：流程任务管理

    public partial interface IWorkFlowTemplateService
    {
		/// <summary>
        /// 增加任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务节点实体</param>
        /// <returns>增加成功返回实体主键</returns>
        [OperationContract]
		string InsertWorkTask(UserInfo userInfo, WorkTaskEntity entity);

        /// <summary>
        /// 修改任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="entity">任务节点实体</param>
        /// <returns>大于0修改成功</returns>
        [OperationContract]
		int UpdateWorkTask(UserInfo userInfo, WorkTaskEntity entity);

        /// <summary>
        /// 删除一个任务节点
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTask(UserInfo userInfo, string workFlowId, string workTaskId);

        /// <summary>
        /// 删除指定任务的所有处理人
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTaskAllOperator(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 删除指定任务的所有任务变量
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTaskAllTaskVar(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 删除指定任务的所有任务命令
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTaskAllCommands(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 删除指定任务的所有控制权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版id</param>
        /// <param name="workTaskId">任务模板id</param>
        /// <returns>大于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTaskAllPower(UserInfo userInfo, string workFlowId, string workTaskId);

        /// <summary>
        /// 删除指定任务的所有表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板id</param>
        /// <returns>于0操作成功</returns>
        [OperationContract]
		int DeleteWorkTaskAllControls(UserInfo userInfo, string workTaskId);
        
        /// <summary>
        /// 获得指定流程模版的任务列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <returns>任务模版列表</returns>
        [OperationContract]
		DataTable GetWorkTasks(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 获得任务处理者列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务处理者列表</returns>
        [OperationContract]
		DataTable GetWorkTaskOperator(UserInfo userInfo, string workFlowId, string workTaskId);

        /// <summary>
        /// 获得任务命令列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务命令列表</returns>
        [OperationContract]
		DataTable GetWorkTaskCommands(UserInfo userInfo, string workFlowId, string workTaskId);

        /// <summary>
        /// 获得控制权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>控制权限列表</returns>
        [OperationContract]
		DataTable GetWorkTaskPower(UserInfo userInfo, string workFlowId, string workTaskId);

        /// <summary>
        /// 获得开始任务节点列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <returns>开始任务节点列表</returns>
        [OperationContract]
		DataTable GetStartTask(UserInfo userInfo, string workFlowId);

        /// <summary>
        /// 判断节点是否存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>true:存在</returns>
        [OperationContract]
		bool ExistWorkTask(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 获得任务名称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns></returns>
        [OperationContract]
		string GetWorkTaskCaption(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 获得任务模版列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模版列表</returns>
        [OperationContract]
		DataTable GetWorkTaskTable(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 获得一个任务模板在流程实例中的所有任务实例
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workflowInsId">流程实例Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务模板在流程实例中的所有任务实例列表</returns>
        [OperationContract]
		DataTable GetWorkTaskInstance(UserInfo userInfo, string workFlowId, string workflowInsId, string workTaskId);

        /// <summary>
        /// 获得任务变量列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>任务变量列表</returns>
        [OperationContract]
		DataTable GetWorkTaskVar(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 获得任务节点绑定的表单列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <returns>表单列表</returns>
        [OperationContract]
		DataTable GetWorkTaskControls(UserInfo userInfo, string workTaskId);

        /// <summary>
        /// 任务节点绑定表单
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userCtrlId">表单id</param>
        /// <param name="workFlowId">流程模版Id</param>
        /// <param name="workTaskId">任务节点id</param>
        /// <returns>绑定成功返回主键</returns>
        [OperationContract]
		string SetWorkTaskUserCtrls(UserInfo userInfo, string userCtrlId, string workFlowId, string workTaskId);

        /// <summary>
        /// 设置任务节点的控制权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="powerName">权限名</param>
        /// <param name="workFlowId">workFlowId</param>
        /// <param name="workTaskId">workTaskId</param>
        /// <returns></returns>
        [OperationContract]
		string SetWorkTaskPower(UserInfo userInfo, string powerName, string workFlowId, string workTaskId);

    }
}
