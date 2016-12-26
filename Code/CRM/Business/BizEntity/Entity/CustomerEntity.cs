//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CustomerEntity
    /// 客户信息
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
    public partial class CustomerEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 客户分类主键
        /// </summary>
        public int? CustomerClassID { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 客户等级
        /// </summary>
        public int? Lelvel { get; set; }

        /// <summary>
        /// 满意度（1至5），默认为3。
        /// </summary>
        public int? Satisfy { get; set; }

        /// <summary>
        /// 信用度（1至5），默认为3。
        /// </summary>
        public int? Credit { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司邮编
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// 公司传真
        /// </summary>
        public string CompanyFax { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string WebAddress { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime? EstablishDate { get; set; }

        /// <summary>
        /// 营业执照注册号
        /// </summary>
        public string LicenceNo { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string Chieftain { get; set; }

        /// <summary>
        /// 注册资金
        /// </summary>
        public int? Bankroll { get; set; }

        /// <summary>
        /// 营业额
        /// </summary>
        public int? Turnover { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// 地税登记号
        /// </summary>
        public string LocalTaxNo { get; set; }

        /// <summary>
        /// 国税登记号
        /// </summary>
        public string NationalTaxNo { get; set; }

        /// <summary>
        /// 客户状态：1-正常、2-流失、3-删除。
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 描述、补充说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除标志
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
        public CustomerEntity()
        {
            ModifiedOn = null;
            CreateOn = DateTime.Now;
            SortCode = null;
            DeleteMark = 0;
            Status = 1;
            Turnover = null;
            Bankroll = null;
            EstablishDate = null;
            Credit = 3;
            Satisfy = 3;
            Lelvel = null;
            CustomerClassID = null;
            Id = null;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldId]);
            this.Code = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCode]);
            this.CustomerClassID = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldCustomerClassID]);
            this.FullName = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldFullName]);
            this.ShortName = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldShortName]);
            this.CompanyName = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCompanyName]);
            this.Lelvel = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldLelvel]);
            this.Satisfy = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldSatisfy]);
            this.Credit = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldCredit]);
            this.CompanyAddress = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCompanyAddress]);
            this.PostalCode = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldPostalCode]);
            this.CompanyPhone = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCompanyPhone]);
            this.CompanyFax = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCompanyFax]);
            this.WebAddress = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldWebAddress]);
            this.EstablishDate = BusinessLogic.ConvertToDateTime(dataRow[CustomerTable.FieldEstablishDate]);
            this.LicenceNo = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldLicenceNo]);
            this.Chieftain = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldChieftain]);
            this.Bankroll = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldBankroll]);
            this.Turnover = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldTurnover]);
            this.Bank = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldBank]);
            this.BankAccount = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldBankAccount]);
            this.LocalTaxNo = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldLocalTaxNo]);
            this.NationalTaxNo = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldNationalTaxNo]);
            this.Status = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldStatus]);
            this.Description = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldDescription]);
            this.DeleteMark = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldDeleteMark]);
            this.SortCode = BusinessLogic.ConvertToInt(dataRow[CustomerTable.FieldSortCode]);
            this.CreateOn = BusinessLogic.ConvertToDateTime(dataRow[CustomerTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToDateTime(dataRow[CustomerTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[CustomerTable.FieldModifiedBy]);
            return this;
        }
    }
}
