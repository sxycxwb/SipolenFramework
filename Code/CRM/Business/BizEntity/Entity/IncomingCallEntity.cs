//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// IncomingCallEntity
    /// 来电处理
    /// 
    /// 修改纪录
    /// 
    /// 2016-01-08 版本：3.0 XuWangBin 针对3.0版本的基础业务实体BaseEntity重构。
    /// 2012-09-03 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-09-03</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class IncomingCallEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 客户主键
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 来电分类
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// 来电记录
        /// </summary>
        public string CallRecord { get; set; }

        /// <summary>
        /// 来电号码
        /// </summary>
        public string CallNumber { get; set; }

        /// <summary>
        /// 电来时间
        /// </summary>
        public DateTime? CallDate { get; set; }

        /// <summary>
        /// 是否处理
        /// </summary>
        public int? Handled { get; set; }

        /// <summary>
        /// 描述、备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public int? Enabled { get; set; }

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
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public IncomingCallEntity()
        {
            ModifiedOn = null;
            CreateOn = DateTime.Now;
            SortCode = null;
            Enabled = 1;
            DeleteMark = 0;
            Handled = null;
            CallDate = DateTime.Now;
            CustomerId = null;
            Id = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldId]);
            this.CustomerId = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldCustomerId]);
            this.CustomerName = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCustomerName]);
            this.CallType = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCallType]);
            this.CallRecord = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCallRecord]);
            this.CallNumber = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCallNumber]);
            this.CallDate = BusinessLogic.ConvertToDateTime(dataRow[IncomingCallTable.FieldCallDate]);
            this.Handled = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldHandled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldDescription]);
            this.DeleteMark = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldDeleteMark]);
            this.Enabled = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldEnabled]);
            this.SortCode = BusinessLogic.ConvertToInt(dataRow[IncomingCallTable.FieldSortCode]);
            this.CreateOn = BusinessLogic.ConvertToDateTime(dataRow[IncomingCallTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToDateTime(dataRow[IncomingCallTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[IncomingCallTable.FieldModifiedBy]);
            return this;
        }
    }
}