//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace RDIFramework.Test
{
    /// <summary>
    /// ProductInfoTable
    /// 产品信息
    /// 
    /// 修改纪录
    /// 
    /// 2012-08-29 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-29</date>
    /// </author>
    /// </summary>
    public partial class ProductInfoTable
    {
        ///<summary>
        /// 产品信息
        ///</summary>
        [NonSerialized]
        public static string TableName = "CASE_PRODUCTINFO";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 产品编码
        ///</summary>
        [NonSerialized]
        public static string FieldProductCode = "PRODUCTCODE";

        ///<summary>
        /// 产品名称
        ///</summary>
        [NonSerialized]
        public static string FieldProductName = "PRODUCTNAME";

        ///<summary>
        /// 产品型号
        ///</summary>
        [NonSerialized]
        public static string FieldProductModel = "PRODUCTMODEL";

        ///<summary>
        /// 产品规格
        ///</summary>
        [NonSerialized]
        public static string FieldProductStandard = "PRODUCTSTANDARD";

        ///<summary>
        /// 产品类别
        ///</summary>
        [NonSerialized]
        public static string FieldProductCategory = "PRODUCTCATEGORY";

        ///<summary>
        /// 产品单位
        ///</summary>
        [NonSerialized]
        public static string FieldProductUnit = "PRODUCTUNIT";

        ///<summary>
        /// 产品描述、备注
        ///</summary>
        [NonSerialized]
        public static string FieldProductDescription = "PRODUCTDESCRIPTION";

        ///<summary>
        /// 产品基准价
        ///</summary>
        [NonSerialized]
        public static string FieldMiddleRate = "MIDDLERATE";

        ///<summary>
        /// 产品基准系数
        ///</summary>
        [NonSerialized]
        public static string FieldReferenceCoefficient = "REFERENCECOEFFICIENT";

        ///<summary>
        /// 产品单价
        ///</summary>
        [NonSerialized]
        public static string FieldProductPrice = "PRODUCTPRICE";

        ///<summary>
        /// 产品批发价
        ///</summary>
        [NonSerialized]
        public static string FieldWholesalePrice = "WHOLESALEPRICE";

        ///<summary>
        /// 产品促销价
        ///</summary>
        [NonSerialized]
        public static string FieldPromotionPrice = "PROMOTIONPRICE";

        ///<summary>
        /// 产品内部价
        ///</summary>
        [NonSerialized]
        public static string FieldInternalPrice = "INTERNALPRICE";

        ///<summary>
        /// 产品特别价
        ///</summary>
        [NonSerialized]
        public static string FieldSpecialPrice = "SPECIALPRICE";

        ///<summary>
        /// 可用标志
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "ENABLED";

        ///<summary>
        /// 产品功能描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "DESCRIPTION";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeleteMark = "DELETEMARK";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CREATEON";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CREATEUSERID";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CREATEBY";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "MODIFIEDON";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "MODIFIEDUSERID";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "MODIFIEDBY";
    }
}