using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// 工作流程自定义事件
    /// </summary>
    public class WorkFlowEventArgs : EventArgs
    {
        /// <summary>
        /// 流程模版主键
        /// </summary>
        public readonly string WorkFlowId = "";

        /// <summary>
        /// 流程实例主键
        /// </summary>
        public readonly string WorkFlowInsId = "";

        /// <summary>
        /// 工作任务主键
        /// </summary>
        public readonly string WorkTaskId = "";

        /// <summary>
        /// 工作任务实例主键
        /// </summary>
        public readonly string WorkTaskInsId = "";

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ResultMsg = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workflowRuntime">WorkFlowRuntime</param>
        public WorkFlowEventArgs(WorkFlowRuntime workflowRuntime)
        {
            if (workflowRuntime == null) return;
            this.WorkFlowId = workflowRuntime.WorkFlowId;
            this.WorkFlowInsId = workflowRuntime.WorkFlowInstanceId;
            this.WorkTaskId = workflowRuntime.WorkTaskId;
            this.WorkTaskInsId = workflowRuntime.WorkTaskInstanceId;
        }
    }
}
