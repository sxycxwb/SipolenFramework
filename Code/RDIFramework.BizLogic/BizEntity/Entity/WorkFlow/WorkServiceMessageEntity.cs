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
    /// WorkServiceMessageEntity
    /// 
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
    public partial class WorkServiceMessageEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String MessageId { get; set; }

        /// <summary>
        /// 流程模版Id
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 任务模版Id
        /// </summary>
        public String WorkTaskId { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public String WorkflowInsId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public String WorktaskInsId { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// SendTime1
        /// </summary>
        public DateTime? SendTime1 { get; set; }

        /// <summary>
        /// SendTime2
        /// </summary>
        public DateTime? SendTime2 { get; set; }

        /// <summary>
        /// SendTime3
        /// </summary>
        public DateTime? SendTime3 { get; set; }

        /// <summary>
        /// DoneFlag1
        /// </summary>
        public int? DoneFlag1 { get; set; }

        /// <summary>
        /// DoneFlag2
        /// </summary>
        public int? DoneFlag2 { get; set; }

        /// <summary>
        /// DoneFlag3
        /// </summary>
        public int? DoneFlag3 { get; set; }

        /// <summary>
        /// MsgType
        /// </summary>
        public String MsgType { get; set; }

        /// <summary>
        /// Users1
        /// </summary>
        public String Users1 { get; set; }

        /// <summary>
        /// Users2
        /// </summary>
        public String Users2 { get; set; }

        /// <summary>
        /// Users3
        /// </summary>
        public String Users3 { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkServiceMessageEntity()
        {
            this.DoneFlag1 = null;
            this.DoneFlag2 = null;
            this.DoneFlag3 = null;
            this.CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.MessageId = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldMessageId]);
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldWorkFlowId]);
            this.WorkTaskId = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldWorkTaskId]);
            this.WorkflowInsId = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldWorkflowInsId]);
            this.WorktaskInsId = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldWorktaskInsId]);
            this.Content = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldContent]);
            this.SendTime1 = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkServiceMessageTable.FieldSendTime1]);
            this.SendTime2 = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkServiceMessageTable.FieldSendTime2]);
            this.SendTime3 = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkServiceMessageTable.FieldSendTime3]);
            this.DoneFlag1 = BusinessLogic.ConvertToNullableInt(dataRow[WorkServiceMessageTable.FieldDoneFlag1]);
            this.DoneFlag2 = BusinessLogic.ConvertToNullableInt(dataRow[WorkServiceMessageTable.FieldDoneFlag2]);
            this.DoneFlag3 = BusinessLogic.ConvertToNullableInt(dataRow[WorkServiceMessageTable.FieldDoneFlag3]);
            this.MsgType = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldMsgType]);
            this.Users1 = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldUsers1]);
            this.Users2 = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldUsers2]);
            this.Users3 = BusinessLogic.ConvertToString(dataRow[WorkServiceMessageTable.FieldUsers3]);
            this.CreateTime = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkServiceMessageTable.FieldCreateTime]);
            return this;
        }
    }
}
