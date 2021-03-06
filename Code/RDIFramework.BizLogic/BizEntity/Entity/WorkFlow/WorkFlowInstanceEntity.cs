﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//     RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//     RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
//	框架官网：http://www.rdiframework.net/
//	框架博客：http://blog.rdiframework.net/
//	交流QQ：406590790 
//	邮件交流：406590790@qq.com
//	其他博客：
//    http://www.cnblogs.com/huyong 
//    http://blog.csdn.net/chinahuyong
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由RDIFramework.NET平台代码生成工具自动生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowInstanceEntity
    /// 流程实例
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class WorkFlowInstanceEntity : BaseEntity
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public String WorkFlowInsId { get; set; }

        /// <summary>
        /// 流程模版Id
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 流程处理编号
        /// </summary>
        public String WorkFlowNo { get; set; }

        /// <summary>
        /// 由用户输入
        /// </summary>
        public String FlowInsCaption { get; set; }

        /// <summary>
        /// 流程说明
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 必选项。
        ///    1普通
        ///    2紧急
        ///    3特急
        /// </summary>
        public String Priority { get; set; }
     
        /// <summary>
        /// 值域：
        ///    1、未执行。
        ///    2、执行中。
        ///    3、正常执行完毕。
        ///    4.、废弃。
        ///    5、挂起
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// 当Status == 1时
        ///    本域标题 ==null 
        ///    当Status == 2时
        ///    本域标题 == 当前任务节点
        ///    当Status == 3时
        ///    本域标题 == 完成任务节点。
        ///    当Status == 4时
        ///    本域标题 == 终止流程任务节点。   
        /// </summary>
        public String NowTaskId { get; set; }
       
        /// <summary>
        /// 业务流程实例开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 业务流程实例结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 上次的挂起时间，流程挂起时不计算执行时间，不会超时。取消挂起时，再开始计算超时。
        /// </summary>
        public DateTime? SuspendTime { get; set; }

        /// <summary>
        /// 挂起前流程实例的状态，供恢复关起时使用。
        /// </summary>
        public String SuspendStaus { get; set; }
       
        /// <summary>
        /// 挂起的总秒钟数
        /// </summary>
        public int? SuspendTotalSeconds { get; set; }
       
        /// <summary>
        /// 是否子流程
        /// </summary>
        public int? IsSubWorkflow { get; set; }

        /// <summary>
        /// 主流程实例Id
        /// </summary>
        public String MainWorkflowInsId { get; set; }

        /// <summary>
        /// 主任务实例Id
        /// </summary>
        public String MainWorktaskInsId { get; set; }

        /// <summary>
        /// 主任务模版Id
        /// </summary>
        public String MainWorktaskId { get; set; }

        /// <summary>
        /// 主流程模板Id
        /// </summary>
        public String MainWorkflowId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkFlowInstanceEntity()
        {
            this.Status = "2";
            this.StartTime = DateTime.Now;
            this.SuspendTotalSeconds = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.WorkFlowInsId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldWorkFlowInsId]);
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldWorkFlowId]);
            this.WorkFlowNo = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldWorkFlowNo]);
            this.FlowInsCaption = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldFlowInsCaption]);
            this.Description = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldDescription]);
            this.Priority = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldPriority]);
            this.Status = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldStatus]);
            this.NowTaskId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldNowTaskId]);
            this.StartTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkFlowInstanceTable.FieldStartTime]);
            this.EndTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkFlowInstanceTable.FieldEndTime]);
            this.SuspendTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkFlowInstanceTable.FieldSuspendTime]);
            this.SuspendStaus = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldSuspendStaus]);
            this.SuspendTotalSeconds = BusinessLogic.ConvertToNullableInt(dataRow[WorkFlowInstanceTable.FieldSuspendTotalSeconds]);
            this.IsSubWorkflow = BusinessLogic.ConvertToNullableInt(dataRow[WorkFlowInstanceTable.FieldIsSubWorkflow]);
            this.MainWorkflowInsId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldMainWorkflowInsId]);
            this.MainWorktaskInsId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldMainWorktaskInsId]);
            this.MainWorktaskId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldMainWorktaskId]);
            this.MainWorkflowId = BusinessLogic.ConvertToString(dataRow[WorkFlowInstanceTable.FieldMainWorkflowId]);
            return this;
        }
    }
}
