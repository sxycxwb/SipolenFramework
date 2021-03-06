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
    /// CiMessageEntity
    /// 消息表
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
    public partial class CiMessageEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 父亲节点主键
        /// </summary>
        public String ParentId { get; set; }

        /// <summary>
        /// 功能分类代码，Send发送、Receiver接收
        /// </summary>
        public String FunctionCode { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public String CategoryCode { get; set; }

        /// <summary>
        /// 唯一识别主键
        /// </summary>
        public String ObjectId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String MSGContent { get; set; }

        /// <summary>
        /// 接收者主键
        /// </summary>
        public String ReceiverId { get; set; }

        /// <summary>
        /// 接收着姓名
        /// </summary>
        public String ReceiverRealName { get; set; }

        /// <summary>
        /// 是否新信息
        /// </summary>
        public int? IsNew { get; set; }

        /// <summary>
        /// 被阅读次数
        /// </summary>
        public int? ReadCount { get; set; }

        /// <summary>
        /// 阅读日期
        /// </summary>
        public DateTime? ReadDate { get; set; }

        /// <summary>
        /// 消息的指向网页页面
        /// </summary>
        public String TargetURL { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public String IPAddress { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

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
        public CiMessageEntity()
        {
            this.Id = BusinessLogic.NewGuid();
            this.ReadCount = 0;
            this.Enabled = 1;
            this.DeleteMark = 0;
            this.SortCode = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldId]);
            this.ParentId = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldParentId]);
            this.FunctionCode = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldFunctionCode]);
            this.CategoryCode = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldCategoryCode]);
            this.ObjectId = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldObjectId]);
            this.Title = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldTitle]);
            this.MSGContent = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldMSGContent]);
            this.ReceiverId = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldReceiverId]);
            this.ReceiverRealName = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldReceiverRealName]);
            this.IsNew = BusinessLogic.ConvertToNullableInt(dataRow[CiMessageTable.FieldIsNew]);
            this.ReadCount = BusinessLogic.ConvertToNullableInt(dataRow[CiMessageTable.FieldReadCount]);
            this.ReadDate = BusinessLogic.ConvertToNullableDateTime(dataRow[CiMessageTable.FieldReadDate]);
            this.TargetURL = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldTargetURL]);
            this.IPAddress = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldIPAddress]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[CiMessageTable.FieldDeleteMark]);
            this.Enabled = BusinessLogic.ConvertToNullableInt(dataRow[CiMessageTable.FieldEnabled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldDescription]);
            this.SortCode = BusinessLogic.ConvertToNullableInt(dataRow[CiMessageTable.FieldSortCode]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[CiMessageTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[CiMessageTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[CiMessageTable.FieldModifiedBy]);
            return this;
        }
    }
}
