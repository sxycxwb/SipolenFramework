//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;

    /// <summary>
    /// ProductInfoEntity
    /// 产品信息
    /// 
    /// 修改纪录
    /// 
    ///     2016-03-08 EricHu 修改继承自BaseEntity
    ///     2012-08-29 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-29</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class ProductInfoEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProductModel { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        public string ProductStandard { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        /// 产品单位
        /// </summary>
        public string ProductUnit { get; set; }

        /// <summary>
        /// 产品描述、备注
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// 产品基准价
        /// </summary>
        public decimal? MiddleRate { get; set; }

        /// <summary>
        /// 产品基准系数
        /// </summary>
        public decimal? ReferenceCoefficient { get; set; }

        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal? ProductPrice { get; set; }

        /// <summary>
        /// 产品批发价
        /// </summary>
        public decimal? WholesalePrice { get; set; }

        /// <summary>
        /// 产品促销价
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// 产品内部价
        /// </summary>
        public decimal? InternalPrice { get; set; }

        /// <summary>
        /// 产品特别价
        /// </summary>
        public decimal? SpecialPrice { get; set; }

        /// <summary>
        /// 可用标志
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 产品功能描述
        /// </summary>
        public string Description { get; set; }

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
        /// 修改用户
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductInfoEntity()
        {
            Id = BusinessLogic.NewGuid();
            MiddleRate = 0;
            ReferenceCoefficient = 0;
            ProductPrice = 0;
            WholesalePrice = 0;
            PromotionPrice = 0;
            InternalPrice = 0;
            SpecialPrice = 0;
            Enabled = 1;
            DeleteMark = 0;
            CreateOn = DateTime.Now;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldId]);
            this.ProductCode = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductCode]);
            this.ProductName = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductName]);
            this.ProductModel = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductModel]);
            this.ProductStandard = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductStandard]);
            this.ProductCategory = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductCategory]);
            this.ProductUnit = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductUnit]);
            this.ProductDescription = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldProductDescription]);
            this.MiddleRate = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldMiddleRate]);
            this.ReferenceCoefficient = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldReferenceCoefficient]);
            this.ProductPrice = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldProductPrice]);
            this.WholesalePrice = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldWholesalePrice]);
            this.PromotionPrice = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldPromotionPrice]);
            this.InternalPrice = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldInternalPrice]);
            this.SpecialPrice = BusinessLogic.ConvertToNullableDecimal(dataRow[ProductInfoTable.FieldSpecialPrice]);
            this.Enabled = BusinessLogic.ConvertToNullableInt(dataRow[ProductInfoTable.FieldEnabled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldDescription]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[ProductInfoTable.FieldDeleteMark]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[ProductInfoTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[ProductInfoTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[ProductInfoTable.FieldModifiedBy]);
            return this;
        }
    }
}
