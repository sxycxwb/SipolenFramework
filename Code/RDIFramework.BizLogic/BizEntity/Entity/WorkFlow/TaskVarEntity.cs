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
    /// TaskVarEntity
    /// 任务变量
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
    public partial class TaskVarEntity : BaseEntity
    {
        /// <summary>
        /// 任务变量主键
        /// </summary>
        public String TaskVarId { get; set; }

        /// <summary>
        /// 工作流程主键
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 工作任务主键
        /// </summary>
        public String WorkTaskId { get; set; }

        /// <summary>
        /// 变量名称，同一个流程模板中的变量名称不允许重复，不能包含‘SYS’字符。SYS作为系统变量的前缀。
        /// </summary>
        public String VarName { get; set; }

        /// <summary>
        /// 变量类型
        ///    1．int
        ///    2．float；
        ///    3．double；
        ///    4．String；
        ///    5．DataTime;
        ///    6．Bool;   
        /// </summary>
        public String VarType { get; set; }
    
        /// <summary>
        /// 变量模式
        ///   值域(下拉框选择)：
        ///   IN；（默认）
        ///   OUT   
        /// </summary>
        public String VarModule { get; set; }
        
        /// <summary>
        /// 数据库名称
        /// </summary>
        public String DataBaseName { get; set; }

        /// <summary>
        /// 数据库表名映射
        /// </summary>
        public String TableName { get; set; }

        /// <summary>
        /// 表字段映射
        /// </summary>
        public String TableField { get; set; }

        /// <summary>
        /// 排序字段映射
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// 初始值
        /// </summary>
        public String InitValue { get; set; }
      
        /// <summary>
        /// 值域：
        ///    1、流程变量；Public
        ///    2、任务内变量。Private（默认）
        /// </summary>
        public String AccessType { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskVarEntity()
        {
            this.VarModule = "IN";
            this.AccessType = "Private";
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.TaskVarId = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldTaskVarId]);
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldWorkFlowId]);
            this.WorkTaskId = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldWorkTaskId]);
            this.VarName = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldVarName]);
            this.VarType = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldVarType]);
            this.VarModule = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldVarModule]);
            this.DataBaseName = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldDataBaseName]);
            this.TableName = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldTableName]);
            this.TableField = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldTableField]);
            this.SortField = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldSortField]);
            this.InitValue = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldInitValue]);
            this.AccessType = BusinessLogic.ConvertToString(dataRow[TaskVarTable.FieldAccessType]);
            return this;
        }
    }
}
