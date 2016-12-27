using System;
using System.Collections.Generic;
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 通用工作流信息控制基类
    /// 
    /// 修改记录
    ///		2014.06.05 XuWangBin 2.8 建立WorkFlowConst.cs。
    ///	
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014.06.05</date>
    /// </author> 
    /// </summary>
    public class WorkFlowConst
    {

        //变量存储类型
        public const string Access_WorkFlow = "1";//流程变量
        public const string Access_WorkTask = "2";//任务变量

        //        
        public const string SYS_VarFlag       = "System_";//系统变量名 标识符
        public const string SYSVarType_int    = "int";
        public const string SYSVarType_float  = "float";
        public const string SYSVarType_double = "double";
        public const string SYSVarType_string = "string";
        public const string SYSVarType_bool   = "bool";

        //消息
        public const string SuccessMsg                = "任务已成功执行";
        public const string StartWorkflowInstance     = "启动流程:{0}。";
        public const string NoFoundOperatorMsg        = "创建处理者实例出错,引擎没有找到处理者,请检查是否配置处理者。TaskId={0}";
        public const string NoFoundTaskMsg            = "创建next任务实例时,未找到workTaskId={0} commandName={1},的后续任务节点。";
        public const string WorkflowOverMsg           = "流程正常结束";
        public const string ExpressErrorMsg           = "判断表达式是否通过错误,condition={0},error={1}";
        public const string CreateNextTaskInstanceMsg = "创建next任务实例NowWorkTaskId={0} commandName={1}";
        public const string NextTaskCountMsg          = "需要判断n={0}个任务节点是否符合条件。";
        public const string CreateSubWorkflowInsMsg   = "Create子流程实例痕迹。";
        public const string CallingSubWorkflowInsMsg  = "Calling 子流程实例。";
        public const string IntoSubWorkflowInsMsg     = "Into 子流程。";
        public const string ExitSubWorkflowMsg        = "Quit 子流程,重新进入主流程。";
        public const string RunAlterTaskMsg           = "Run 交互节点,共享处理operRule == {0}。";
        public const string CreateAlterTaskInsMsg     = "Create 交互节点的实例,EndTaskId={0}";
        public const string ChenkingCtrlTaskMsg       = "Checking 控制节点taskId={0},是否通过。";
        public const string ChenkedCtrlTaskMsg        = "Checked每个实例，其中检查结果如下StartTaskId:{0},allPass={1}";
        public const string ResultCtrlTaskMsg         = "isPass判断节点是否通过:allPass={0}节点类型:{1}";
        public const string RunViewTaskMsg            = "Run 查看节点,共享处理operRule == {0}。";
        public const string CreateViewTaskInsMsg      = "Create 查看节点的实例,EndTaskId={0}";
        public const string EngineErrorMsg            = "引擎执行流程错误:{0}";
        public const string WriteLineMsg              = "-----------------";
        public const string TaskBackMsg               = "退回至提交人!";//此处与存储过程对应WorkTaskSubmitBackPro
        public const int TaskMaxCount = 9999;//最大可接受任务的个数

        //错误代码
        public const string SuccessCode              = "000000";//操作成功
        public const string OtherErrorCode           = "111111";//其他错误
        public const string ExpressErrorCode         = "100000";//表达式判断错误
        public const string InstanceIsCompletedCode  = "100001";//流程实例已完成
        public const string TaskAssignErrorCode      = "100002";//任务指派错误
        public const string TaskClaimErrorCode       = "100003";//任务认领错误
        public const string TaskUnClaimErrorCode     = "100004";//放弃任务认领错误
        public const string TaskBackErrorCode        = "100005";//任务退回错误
        public const string TaskAccreditErrorCode    = "100006";//任务授权错误
        public const string WorkFlowSuspendErrorCode = "100007";//流程挂起错误
        public const string WorkFlowResumeErrorCode  = "100008";//流程取消挂起错误 
        public const string WorkFlowAbnormalErrorCode= "100009";//流程异常结束错误 
        public const string NoFoundOperatorCode      = "000001";//没有配置处理者
        public const string NoFoundTaskCode          = "000002";//没有配置后续任务
        public const string NoFoundInstanceCode      = "000003";//没有找到实例
        public const string IsNullUserIdCode         = "200000";//用户Id为空
        public const string IsNullWorkFlowIdCode     = "200001";//流程Id为空
        public const string IsNullWorkTaskIdCode     = "200002";//任务Id为空
        public const string IsNullCommandNameCode    = "200003";//命令为空
        public const string IsNullWorkflowInsCaption = "200004";//流程实例名称为空
        public const string IsNullWorkFlowNoCode     = "200005";//流程实例编号为空
        public const string IsNullOperatorInsIdCode  = "200006";//流程处理者Id为空
        public const string IsNullWorkFlowInsIdCode  = "200007";//流程实例Id为空
        public const string IsNullWorkTaskInsIdCode  = "200008";//任务实例Id为空
        public const string IsNullUser               = "200009";//用户为空
    }
}
