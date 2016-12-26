
namespace RDIFramework.Utilities
{
    //2014年新增，针对工作流部分
    public partial class RDIFrameworkMessage
    {
        //1、WorkFlowInstanceService
        //1.1、WorkTaskInstance
        public static string WorkFlowInstanceService = "WorkFlowInstanceService";
        public static string WorkFlowInstanceService_CreateWorkTaskInstance = "创建新任务实例";
        public static string WorkFlowInstanceService_CreateWorkTaskInsNextOper = "动态指定新的任务实例处理人";
        public static string WorkFlowInstanceService_WorkTaskInstanceExist = "是否存在指定任务实例";
        public static string WorkFlowInstanceService_SetWorkTaskInstanceOver = "设定任务实例正常结束";
        public static string WorkFlowInstanceService_SetSuccessMsg = "设定任务实例成功提交信息";
        public static string WorkFlowInstanceService_GetTaskToWhoMsg = "获得任务实例成功提交信息";
        public static string WorkFlowInstanceService_GetTaskDoneWhoMsg = "获得任务被谁处理";
        public static string WorkFlowInstanceService_WorkTaskpd = "判断任务是否是由当前用户操作";
        public static string WorkFlowInstanceService_GetResultMsg = "获得任务实例提交后返回信息";
        public static string WorkFlowInstanceService_WorkTaskClaim = "认领任务";
        public static string WorkFlowInstanceService_WorkTaskUnClaim = "放弃认领任务";
        public static string WorkFlowInstanceService_WorkTaskAssign = "指派任务";
        public static string WorkFlowInstanceService_WorkTaskBack = "任务退回";
        public static string WorkFlowInstanceService_WorkTaskBackry = "任务任意退回";
        public static string WorkFlowInstanceService_WorkTaskRevoke = "任务撤回";
        public static string WorkFlowInstanceService_GetTaskInsTable = "获得任务实例列表";
        public static string WorkFlowInstanceService_GetTaskInsNextOperTable = "获得加签处理人";

        //1.2、WorkFlowInstance
        public static string WorkFlowInstanceService_CreateWorkFlowInstance = "创建工作流实例";
        public static string WorkFlowInstanceService_GetToDoWorkTasks = "待办任务，包括新任务和已认领任务";
        public static string WorkFlowInstanceService_ClaimWorkTask = "未认领的任务";
        public static string WorkFlowInstanceService_WorkCompleteWorkTask = "返回本流程中已完成的任务";
        public static string WorkFlowInstanceService_WorkflowAllTask = "我参与的任务";
        public static string WorkFlowInstanceService_WorkFlowAllTaskByPage = "按分页方式得到我参与的任务";
        public static string WorkFlowInstanceService_WorkflowClaimedTask = "我已认领的任务";
        public static string WorkFlowInstanceService_GetWorkFlowInstanceRunning = "正在运行的流程实例列表";
        public static string WorkFlowInstanceService_GetWorkFlowInstanceComplete = "已完成的流程实例";
        public static string WorkFlowInstanceService_WorkFlowCompletedTask = "我已完成的任务";
        public static string WorkFlowInstanceService_WorkFlowAbnormalTask = "异常终止的任务";
        public static string WorkFlowInstanceService_GetWorkFlowInstance = "获得一个流程实例实例的信息";
        public static string WorkFlowInstanceService_GetWorkFlowInstanceDTByPage = "获得流程实例实例分页数据";
        public static string WorkFlowInstanceService_GetWorkFlowHistory = "流程历史";
        public static string WorkFlowInstanceService_GetWorkFlowBack = "加载退回原因";
        public static string WorkFlowInstanceService_SetWorkflowInstanceOver = "设定流程实例正常结束";
        public static string WorkFlowInstanceService_SetCurrTaskId = "设定流程实例的当前位置";
        public static string WorkFlowInstanceService_SetSuspend = "设定流程实例挂起";
        public static string WorkFlowInstanceService_SetResume = "设定流程实例取消挂起";
        public static string WorkFlowInstanceService_SetAbnormal = "设定流程实例异常终止";
        public static string WorkFlowInstanceService_GetClaimingTaskCount = "未认领任务的个数";
        public static string WorkFlowInstanceService_GetToDoTasksCount = "待办任务";
        public static string WorkFlowInstanceService_GetClaimedTaskCount = "已认领任务个数";
        public static string WorkFlowInstanceService_GetAllTaskCount = "我参与的任务个数";
        public static string WorkFlowInstanceService_GetCompletedTaskCount = "我完成的任务个数";
        public static string WorkFlowInstanceService_GetAbnormalTaskCount = "我异常终止的任务个数";


        //1.3、OperatorInstance

        public static string WorkFlowInstanceService_CreateOperatorInstance = "创建处理者实例";
        public static string WorkFlowInstanceService_GetOperatorInstance = "获得一个要处理的信息";
        public static string WorkFlowInstanceService_SetOperatorInstanceOver = "设定处理者实例正常结束";


        //2、WorkFlowTemplateService
        //2.1、WorkFlowTemplate
        public static string WorkFlowTemplateService = "WorkFlowTemplateService";
        public static string WorkFlowTemplateService_InsertWorkFlow = "新建一个流程模板";
        public static string WorkFlowTemplateService_UpdateWorkFlow = "修改一个流程模板";
        public static string WorkFlowTemplateService_DeleteWorkFlow = "删除一个流程模板";
        public static string WorkFlowTemplateService_GetWorkFlowTable = "获得工作流模板信息";
        public static string WorkFlowTemplateService_GetWorkFlowAllControlsTable = "得到指定工作流程所有的任务表单";
        public static string WorkFlowTemplateService_GetWorkFlowInfo = "得到流程模板实体";
        public static string WorkFlowTemplateService_GetAllowsStartWorkFlows = "获得有权限启动的流程";
        public static string WorkFlowTemplateService_GetWorkFlowsByCaption = "依据流程模版名称获得流程模板列表";
        public static string WorkFlowTemplateService_WorkFlowExists = "是否存在指定流程模版";
        public static string WorkFlowTemplateService_SetWorkFlowStatus = "设置工作流模板状态";
        public static string WorkFlowTemplateService_SetWorkFlowClass = "设置流程模版分类";

        //2.2、WorkTask
        public static string WorkFlowTemplateService_InsertWorkTask = "增加任务节点";
        public static string WorkFlowTemplateService_UpdateWorkTask = "修改任务节点";
        public static string WorkFlowTemplateService_DeleteWorkTask = "删除一个任务节点";
        public static string WorkFlowTemplateService_DeleteWorkTaskAllOperator = "删除指定任务的所有处理人";
        public static string WorkFlowTemplateService_DeleteWorkTaskAllTaskVar = "删除指定任务的所有任务变量";
        public static string WorkFlowTemplateService_DeleteWorkTaskAllCommands = "删除指定任务的所有任务命令";
        public static string WorkFlowTemplateService_DeleteWorkTaskAllPower = "删除指定任务的所有控制权限";
        public static string WorkFlowTemplateService_DeleteWorkTaskAllControls = "删除指定任务的所有表单";
        public static string WorkFlowTemplateService_GetWorkTasks = "获得任务列表";
        public static string WorkFlowTemplateService_GetWorkTaskOperator = "获得任务处理者列表";
        public static string WorkFlowTemplateService_GetWorkTaskCommands = "获得任务命令列表";
        public static string WorkFlowTemplateService_GetWorkTaskPower = "获得控制权限";
        public static string WorkFlowTemplateService_GetStartTask = "获得开始任务节点";
        public static string WorkFlowTemplateService_ExistWorkTask = "判断节点是否存在";
        public static string WorkFlowTemplateService_GetWorkTaskCaption = "获得任务名称";
        public static string WorkFlowTemplateService_GetWorkTaskTable = "获得任务列表";
        public static string WorkFlowTemplateService_GetWorkTaskInstance = "获得一个任务模板在流程实例中的所有任务实例";
        public static string WorkFlowTemplateService_GetWorkTaskVar = "获得任务变量列表";
        public static string WorkFlowTemplateService_GetWorkTaskControls = "获得任务节点绑定的表单列表";
        public static string WorkFlowTemplateService_SetWorkTaskUserCtrls = "任务节点绑定表单";
        public static string WorkFlowTemplateService_SetWorkTaskPower = "设置任务节点的控制权限";

        //2.3、WorkTaskCommands
        public static string WorkFlowTemplateService_InsertWorkTaskCommands = "增加任务命令";
        public static string WorkFlowTemplateService_UpdateWorkTaskCommands = "修改任务命令";
        public static string WorkFlowTemplateService_DeleteWorkTaskCommands = "删除一个任务命令";
        public static string WorkFlowTemplateService_GetWorkFlowAllCommands = "得到指定流程模版的所有任务命令";
        public static string WorkFlowTemplateService_GetTaskCommandsTable = "通过指定任务命令主键得到任务命令";
        public static string WorkFlowTemplateService_ExistsWorkTaskCommands = "是否存在指定任务命令";

        //2.4、WorkLink
        public static string WorkFlowTemplateService_InsertWorkLink = "增加流程连线";
        public static string WorkFlowTemplateService_UpdateWorkLink = "更新流程连线";
        public static string WorkFlowTemplateService_DeleteWorkLine = "删除流程连线";
        public static string WorkFlowTemplateService_GetWorkLinks = "获得流程连线";
        public static string WorkFlowTemplateService_ExistsWorkLink = "判断流程连线是否存在";

        //2.5、WorkFlowClass
        public static string WorkFlowTemplateService_InsertWorkFlowClass = "新建一个流程分类";
        public static string WorkFlowTemplateService_UpdateWorkFlowClass = "修改一个流程分类";
        public static string WorkFlowTemplateService_DeleteWorkFlowClass = "删除指定流程分类";
        public static string WorkFlowTemplateService_GetChildWorkFlowClass = "获得流程分类的所有子分类列表";
        public static string WorkFlowTemplateService_GetWorkFlowsByClassId = "获得流程分类下的所有流程列表";
        public static string WorkFlowTemplateService_GetWorkFlowClassInfo = "获得流程分类实体";

        //2.6、WorkFlowEvent
        public static string WorkFlowTemplateService_InsertWorkFlowEvent = "增加事件通知";
        public static string WorkFlowTemplateService_UpdateWorkFlowEvent = "更新事件通知";
        public static string WorkFlowTemplateService_DeleteWorkFlowEvent = "根据任务模版主键删除事件通知记录";
        public static string WorkFlowTemplateService_GetWorkFlowEventTable = "获得指定任务模版事件通知列表";
        public static string WorkFlowTemplateService_GetWorkFlowAllEventTable = "得到指定流程模版所有的事件通知列表";
        public static string WorkFlowTemplateService_GetWorkFlowEventInfo = "得到事件通知列表实体";

        //2.7、WorkOutTime
        public static string WorkFlowTemplateService_InsertWorkOutTime = "增加工作任务超时设置";
        public static string WorkFlowTemplateService_UpdateWorkOutTime = "更新工作任务超时设置";
        public static string WorkFlowTemplateService_DeleteWorkOutTime = "根据工作任务模版主键删除超时设置记录";
        public static string WorkFlowTemplateService_GetWorkOutTimeTable = "依据工作任务模版Id获得超时设置列表";
        public static string WorkFlowTemplateService_GetWorkFlowAllOutTimeTable = "得到指定流程模版所有的超时设置列表";
        public static string WorkFlowTemplateService_GetWorkOutTimeInfo = "得到超时设置实体";

        //3、WorkFlowUserControlService
        //3.1、WorkFlowTemplate
        public static string WorkFlowUserControlService = "WorkFlowUserControlService";

        //3.2、MainUserCtrl
        public static string WorkFlowUserControlService_InsertMainUserCtrl = "增加主表单";
        public static string WorkFlowUserControlService_UpdateMainUserCtrl = "修改一个主表单";
        public static string WorkFlowUserControlService_GetMainUserControl = "获得一个主表单";
        public static string WorkFlowUserControlService_GetMainUserControlByPage = "获得主表单分页列表";
        public static string WorkFlowUserControlService_GetMainUserControlByFullName = "根据表单名称获得一个主表单";
        public static string WorkFlowUserControlService_DeleteMainUserCtrl = "物理删除主表单";
        public static string WorkFlowUserControlService_SetDeletedMainUserCtrl = "逻辑删除主表单";
        public static string WorkFlowUserControlService_GetAllChildUserControlsById = "获得主表单的所有子表单列表";
        public static string WorkFlowUserControlService_GetAllMainUserControls = "获得所有主表单";
        public static string WorkFlowUserControlService_AddUserControls = "增加子表单";
        public static string WorkFlowUserControlService_MoveUserControls = "移除子表单";
        public static string WorkFlowUserControlService_EditMainUserControlsState = "修改主表单下指定子表单的状态";
        public static string WorkFlowUserControlService_MoveUserControlsOfMain = "移除所有子表单";
        public static string WorkFlowUserControlService_GetWorkFlowAllControlsLink = "得到工作流所有的工作任务表单";
        public static string WorkFlowUserControlService_GetWorkFlowAllMainControls = "得到指定工作流所有的主表单";
        public static string WorkFlowUserControlService_GetWorkFlowAllControls = "得到指定流程所有的子表单列表";

        //3.3、UserControl
        public static string WorkFlowUserControlService_InsertUserControl = "新增子表单";
        public static string WorkFlowUserControlService_UpdateUserControl = "修改一个子表单";
        public static string WorkFlowUserControlService_DeleteUserControl = "删除一个子表单";
        public static string WorkFlowUserControlService_SetDeletedUserControl = "逻辑删除一个子表单";
        public static string WorkFlowUserControlService_DeleteMainCtrlsOfUser = "删除子表单隶属的组关系";
        public static string WorkFlowUserControlService_GetChildUserControl = "获得指定子表单";

        //3.4、TaskVar
        public static string WorkFlowUserControlService_InsertTaskVar = "新增任务变量";
        public static string WorkFlowUserControlService_UpdateTaskVar = "修改任务变量";
        public static string WorkFlowUserControlService_DeleteTaskVar = "删除一个任务变量";

        //3.5、Operator
        public static string WorkFlowUserControlService_InsertOperator = "增加处理者";
        public static string WorkFlowUserControlService_UpdateOperator = "修改处理者";
        public static string WorkFlowUserControlService_DeleteOperator = "删除处理者";

        //3.6、SubWorkFlow
        public static string WorkFlowUserControlService_InsertSubWorkFlow = "增加子流程节点配置";
        public static string WorkFlowUserControlService_UpdateSubWorkFlow = "修改子流程节点配置";
        public static string WorkFlowUserControlService_DeleteSubWorkFlow = "删除子流程节点配置";

    }
}
