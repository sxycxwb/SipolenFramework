//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CustomerClassEntity
    /// 客户分类
    /// 
    /// 修改纪录
    /// 
    /// 2016-01-08 版本：3.0 EricHu 针对3.0版本的基础业务实体BaseEntity重构。
    /// 2012-08-15 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class CustomerClassEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

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
        /// 修改用户主键
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomerClassEntity()
        {
            ModifiedOn = null;
            CreateOn = DateTime.Now;
            DeleteMark = 0;
            SortCode = null;
            ParentId = null;
            Id = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BusinessLogic.ConvertToInt(dataRow[CustomerClassTable.FieldId]);
            this.ParentId = BusinessLogic.ConvertToInt(dataRow[CustomerClassTable.FieldParentId]);
            this.ClassName = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldClassName]);
            this.ClassCode = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldClassCode]);
            this.Description = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldDescription]);
            this.SortCode = BusinessLogic.ConvertToInt(dataRow[CustomerClassTable.FieldSortCode]);
            this.DeleteMark = BusinessLogic.ConvertToInt(dataRow[CustomerClassTable.FieldDeleteMark]);
            this.CreateOn = BusinessLogic.ConvertToDateTime(dataRow[CustomerClassTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToDateTime(dataRow[CustomerClassTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[CustomerClassTable.FieldModifiedBy]);
            return this;
        }
    }
}
