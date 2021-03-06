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
    /// CiExceptionEntity
    /// 系统异常实体
    ///
    /// 修改纪录
    ///
    ///     2014-07-30 版本: 2.8 XuWangBin 以自动属性进行重新组织。
    ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
    ///
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class CiExceptionEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// EventID
        /// </summary>
        public String EventId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public String Category { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public String Priority { get; set; }

        /// <summary>
        /// Severity
        /// </summary>
        public String Severity { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public String Title { get; set; }
        
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// MachineName
        /// </summary>
        public String MachineName { get; set; }

        /// <summary>
        /// AppDomainName
        /// </summary>
        public String AppDomainName { get; set; }

        /// <summary>
        /// ProcessID
        /// </summary>
        public String ProcessId { get; set; }

        /// <summary>
        /// ProcessName
        /// </summary>
        public String ProcessName { get; set; }

        /// <summary>
        /// 导致错误的源
        /// </summary>
        public String ThreadName { get; set; }

        /// <summary>
        /// Win32ThreadId
        /// </summary>
        public String Win32ThreadId { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 字符串表示形式
        /// </summary>
        public String FormattedMessage { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldId]);
            this.EventId = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldEventId]);
            this.Category = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldCategory]);
            this.Priority = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldPriority]);
            this.Severity = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldSeverity]);
            this.Title = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldTitle]);
            this.Timestamp = BusinessLogic.ConvertToNullableDateTime(dataRow[CiExceptionTable.FieldTimestamp]);
            this.MachineName = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldMachineName]);
            this.AppDomainName = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldAppDomainName]);
            this.ProcessId = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldProcessId]);
            this.ProcessName = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldProcessName]);
            this.ThreadName = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldThreadName]);
            this.Win32ThreadId = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldWin32ThreadId]);
            this.Message = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldMessage]);
            this.FormattedMessage = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldFormattedMessage]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[CiExceptionTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[CiExceptionTable.FieldCreateBy]);
            return this;
        }
    }
}
