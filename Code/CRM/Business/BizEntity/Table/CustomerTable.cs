//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    /// <summary>
    /// CustomerTable
    /// 客户信息
    /// 
    /// 修改纪录
    /// 
    /// 2012-08-15 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-15</date>
    /// </author>
    /// </summary>
    public partial class CustomerTable
    {
        ///<summary>
        /// 客户信息
        ///</summary>
        [NonSerialized]
        public static string TableName = "Customer";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 客户编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 客户分类主键
        ///</summary>
        [NonSerialized]
        public static string FieldCustomerClassID = "CustomerClassID";

        ///<summary>
        /// 客户全称
        ///</summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        ///<summary>
        /// 客户简称
        ///</summary>
        [NonSerialized]
        public static string FieldShortName = "ShortName";

        ///<summary>
        /// 公司名称
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyName = "CompanyName";

        ///<summary>
        /// 客户等级
        ///</summary>
        [NonSerialized]
        public static string FieldLelvel = "Lelvel";

        ///<summary>
        /// 满意度（1至5），默认为3。
        ///</summary>
        [NonSerialized]
        public static string FieldSatisfy = "Satisfy";

        ///<summary>
        /// 信用度（1至5），默认为3。
        ///</summary>
        [NonSerialized]
        public static string FieldCredit = "Credit";

        ///<summary>
        /// 公司地址
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyAddress = "CompanyAddress";

        ///<summary>
        /// 公司邮编
        ///</summary>
        [NonSerialized]
        public static string FieldPostalCode = "PostalCode";

        ///<summary>
        /// 公司电话
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyPhone = "CompanyPhone";

        ///<summary>
        /// 公司传真
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyFax = "CompanyFax";

        ///<summary>
        /// 网址
        ///</summary>
        [NonSerialized]
        public static string FieldWebAddress = "WebAddress";

        ///<summary>
        /// 成立日期
        ///</summary>
        [NonSerialized]
        public static string FieldEstablishDate = "EstablishDate";

        ///<summary>
        /// 营业执照注册号
        ///</summary>
        [NonSerialized]
        public static string FieldLicenceNo = "LicenceNo";

        ///<summary>
        /// 法人
        ///</summary>
        [NonSerialized]
        public static string FieldChieftain = "Chieftain";

        ///<summary>
        /// 注册资金
        ///</summary>
        [NonSerialized]
        public static string FieldBankroll = "Bankroll";

        ///<summary>
        /// 营业额
        ///</summary>
        [NonSerialized]
        public static string FieldTurnover = "Turnover";

        ///<summary>
        /// 开户银行
        ///</summary>
        [NonSerialized]
        public static string FieldBank = "Bank";

        ///<summary>
        /// 银行账号
        ///</summary>
        [NonSerialized]
        public static string FieldBankAccount = "BankAccount";

        ///<summary>
        /// 地税登记号
        ///</summary>
        [NonSerialized]
        public static string FieldLocalTaxNo = "LocalTaxNo";

        ///<summary>
        /// 国税登记号
        ///</summary>
        [NonSerialized]
        public static string FieldNationalTaxNo = "NationalTaxNo";

        ///<summary>
        /// 客户状态：1-正常、2-流失、3-删除。
        ///</summary>
        [NonSerialized]
        public static string FieldStatus = "Status";

        ///<summary>
        /// 描述、补充说明
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeleteMark = "DeleteMark";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
