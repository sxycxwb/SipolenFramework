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
    /// WorkFlowTemplateEntity
    /// 流程模版实体
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
    public partial class WorkFlowTemplateEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 所属类型编号，流程模板太多时，一般树形结构分类存放。对应流程分类表的主键WorkFlowClass.ClassId
        /// </summary>
        public String WFClassId { get; set; }

        /// <summary>
        /// 流程模版名称
        /// </summary>
        public String FlowCaption { get; set; }

        /// <summary>
        /// 版本号，同一个流程，在流程升级时保证原来的流程正常运行。
        /// </summary>
        public String Version { get; set; }
       
        /// <summary>
        /// 状态，是否有效，只有有效时才能使用
        ///    1有效
        ///    0无效   
        /// </summary>
        public String Status { get; set; }
     
        /// <summary>
        /// 签出状态，独占访问，正在编辑时不允许其他用户再编辑。
        /// 0未签出
        /// 1签出   
        /// </summary>
        public String IsSignOut { get; set; }

        /// <summary>
        /// 签出人主键
        /// </summary>
        public String SignOutUserId { get; set; }

        /// <summary>
        /// 关联日历编号，判断流程超时是依次为依据。
        /// </summary>
        public String WorkCalendarId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 流程管理界面对应URL
        /// </summary>
        public String MgrUrl { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

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
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkFlowTemplateEntity()
        {
            this.Status = "1";
            this.DeleteMark = 0;
            this.IsSignOut = "0";
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldWorkFlowId]);
            this.WFClassId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldWFClassId]);
            this.FlowCaption = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldFlowCaption]);
            this.Version = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldVersion]);
            this.Status = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldStatus]);
            this.IsSignOut = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldIsSignOut]);
            this.SignOutUserId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldSignOutUserId]);
            this.WorkCalendarId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldWorkCalendarId]);
            this.Description = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldDescription]);
            this.MgrUrl = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldMgrUrl]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[WorkFlowTemplateTable.FieldDeleteMark]);
            this.SortCode = BusinessLogic.ConvertToNullableInt(dataRow[WorkFlowTemplateTable.FieldSortCode]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkFlowTemplateTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[WorkFlowTemplateTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[WorkFlowTemplateTable.FieldModifiedBy]);
            return this;
        }
    }
}
