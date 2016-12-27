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
    /// WorkTaskInstanceEntity
    /// 任务实例
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
    public partial class WorkTaskInstanceEntity : BaseEntity
    {
        /// <summary>
        /// 任务实例主键
        /// </summary>
        public String WorkTaskInsId { get; set; }

        /// <summary>
        /// 所属流程模版
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 任务模版主键
        /// </summary>
        public String WorkTaskId { get; set; }

        /// 所属流程实例
        /// </summary>
        public String WorkFlowInsId { get; set; }

        /// <summary>
        /// 前一任务实例Id，即该任务是从哪个任务提交过来的。启动节点时而且非子流程时，该值为空。
        /// </summary>
        public String PreviousTaskId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public String TaskInsCaption { get; set; }

        /// <summary>
        /// 任务节点开始时间。
        /// YYYY-MM-DD HH:MM
        /// 从岗位任务或我的任务以“我来处理”为本时刻。   
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 任务节点结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 值域：
        /// 0、保留
        /// 1、未执行
        /// 2、执行中（被人认领，约定：如果“放弃处理”，则Status还置为1）
        /// 3、正常执行完毕。（任务完成提交）
        /// 4、异常终止
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// 处理者的描述信息，表示该任务处理的情况，任务处理后引擎自动会写该值。如果该任务经过多次处理(如:回退又提交) ，此信息叠加。
        /// </summary>
        public String OperatedDes { get; set; }

        /// <summary>
        /// 处理者实例Id
        /// </summary>
        public String OperatorInsId { get; set; }

        /// <summary>
        /// 任务提交成功时回写该字段。
        /// </summary>
        public String SuccessMsg { get; set; }

        /// <summary>
        /// 是否任务超时提醒
        /// </summary>
        public int? OutTimeed { get; set; }

        /// <summary>
        /// 是否任务到达提醒
        /// </summary>
        public int? Reminded { get; set; }

        /// <summary>
        /// 指派时回写该字段
        /// </summary>
        public String TaskInsDescription { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkTaskInstanceEntity()
        {
            this.StartTime = DateTime.Now;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.WorkTaskInsId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldWorkTaskInsId]);
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldWorkFlowId]);
            this.WorkTaskId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldWorkTaskId]);
            this.WorkFlowInsId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldWorkFlowInsId]);
            this.PreviousTaskId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldPreviousTaskId]);
            this.TaskInsCaption = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldTaskInsCaption]);
            this.StartTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkTaskInstanceTable.FieldStartTime]);
            this.EndTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkTaskInstanceTable.FieldEndTime]);
            this.Status = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldStatus]);
            this.OperatedDes = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldOperatedDes]);
            this.OperatorInsId = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldOperatorInsId]);
            this.SuccessMsg = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldSuccessMsg]);
            this.OutTimeed = BusinessLogic.ConvertToNullableInt(dataRow[WorkTaskInstanceTable.FieldOutTimeed]);
            this.Reminded = BusinessLogic.ConvertToNullableInt(dataRow[WorkTaskInstanceTable.FieldReminded]);
            this.TaskInsDescription = BusinessLogic.ConvertToString(dataRow[WorkTaskInstanceTable.FieldTaskInsDescription]);
            return this;
        }
    }
}