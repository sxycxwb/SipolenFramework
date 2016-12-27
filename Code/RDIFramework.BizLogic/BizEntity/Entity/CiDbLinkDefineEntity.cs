/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:47
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CiDbLinkDefineEntity
    /// 数据库连接定义
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
    public partial class CiDbLinkDefineEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 数据库字符串连接的名称，程序中主要用这个名称来得到相应的连接字符串。
        /// </summary>
        public String LinkName { get; set; }

        /// <summary>
        /// 数据库连接的类型（如连接类型为：sqlserver、oracle、db2、mysql、access等）
        /// </summary>
        public String LinkType { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public String LinkData { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Description { get; set; }

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
        public CiDbLinkDefineEntity()
        {
            this.Enabled = 0;
            this.DeleteMark = 0;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldId]);
            this.LinkName = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldLinkName]);
            this.LinkType = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldLinkType]);
            this.LinkData = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldLinkData]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[CiDbLinkDefineTable.FieldDeleteMark]);
            this.SortCode = BusinessLogic.ConvertToNullableInt(dataRow[CiDbLinkDefineTable.FieldSortCode]);
            this.Enabled = BusinessLogic.ConvertToNullableInt(dataRow[CiDbLinkDefineTable.FieldEnabled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldDescription]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[CiDbLinkDefineTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[CiDbLinkDefineTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[CiDbLinkDefineTable.FieldModifiedBy]);
            return this;
        }
    }
}
