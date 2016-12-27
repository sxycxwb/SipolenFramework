using System;
using Newtonsoft.Json;

namespace RDIFramework.WebApp
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTINFOEntity
    /// 
    /// 
    /// 修改纪录
    ///     2016-03-08 XuWangBin 修改继承自BaseEntity
    ///     2013-12-18 版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2013-12-18</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class CASE_PRODUCTINFOEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string PRODUCTCODE { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string PRODUCTNAME { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string PRODUCTMODEL { get; set; }

        /// <summary>
        /// 产品规格
        /// </summary>
        public string PRODUCTSTANDARD { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public string PRODUCTCATEGORY { get; set; }

        /// <summary>
        /// 产品单位
        /// </summary>
        public string PRODUCTUNIT { get; set; }

        /// <summary>
        /// 产品描述、备注
        /// </summary>
        public string PRODUCTDESCRIPTION { get; set; }

        /// <summary>
        /// 产品基准价
        /// </summary>
        public decimal MIDDLERATE { get; set; }

        /// <summary>
        /// 产品基准系数
        /// </summary>
        public decimal REFERENCECOEFFICIENT { get; set; }

        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal PRODUCTPRICE { get; set; }

        /// <summary>
        /// 产品批发价
        /// </summary>
        public decimal WHOLESALEPRICE { get; set; }

        /// <summary>
        /// 产品促销价
        /// </summary>
        public decimal PROMOTIONPRICE { get; set; }

        /// <summary>
        /// 产品内部价
        /// </summary>
        public decimal INTERNALPRICE { get; set; }

        /// <summary>
        /// 产品特别价
        /// </summary>
        public decimal SPECIALPRICE { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        public int ENABLED { get; set; }

        /// <summary>
        /// 产品功能描述
        /// </summary>
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int DELETEMARK { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [JsonIgnore]
        public DateTime? CREATEON { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [JsonIgnore]
        public string CREATEUSERID { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [JsonIgnore]
        public string CREATEBY { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [JsonIgnore]
        public DateTime? MODIFIEDON { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        [JsonIgnore]
        public string MODIFIEDUSERID { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [JsonIgnore]
        public string MODIFIEDBY { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CASE_PRODUCTINFOEntity()
        {
            DELETEMARK = 0;
            ENABLED = 0;
            SPECIALPRICE = 0;
            INTERNALPRICE = 0;
            PROMOTIONPRICE = 0;
            WHOLESALEPRICE = 0;
            PRODUCTPRICE = 0;
            REFERENCECOEFFICIENT = 0;
            MIDDLERATE = 0;
            PRODUCTCODE = BusinessLogic.NewGuid();
            ID = BusinessLogic.NewGuid();
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.ID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldID]);
            this.PRODUCTCODE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTCODE]);
            this.PRODUCTNAME = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTNAME]);
            this.PRODUCTMODEL = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTMODEL]);
            this.PRODUCTSTANDARD = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTSTANDARD]);
            this.PRODUCTCATEGORY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTCATEGORY]);
            this.PRODUCTUNIT = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTUNIT]);
            this.PRODUCTDESCRIPTION = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTDESCRIPTION]);
            this.MIDDLERATE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldMIDDLERATE]);
            this.REFERENCECOEFFICIENT = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldREFERENCECOEFFICIENT]);
            this.PRODUCTPRICE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldPRODUCTPRICE]);
            this.WHOLESALEPRICE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldWHOLESALEPRICE]);
            this.PROMOTIONPRICE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldPROMOTIONPRICE]);
            this.INTERNALPRICE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldINTERNALPRICE]);
            this.SPECIALPRICE = BusinessLogic.ConvertToDecimal(dataRow[CASE_PRODUCTINFOTable.FieldSPECIALPRICE]);
            this.ENABLED = BusinessLogic.ConvertToInt(dataRow[CASE_PRODUCTINFOTable.FieldENABLED]);
            this.DESCRIPTION = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldDESCRIPTION]);
            this.DELETEMARK = BusinessLogic.ConvertToInt(dataRow[CASE_PRODUCTINFOTable.FieldDELETEMARK]);
            this.CREATEON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTINFOTable.FieldCREATEON]);
            this.CREATEUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldCREATEUSERID]);
            this.CREATEBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldCREATEBY]);
            this.MODIFIEDON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTINFOTable.FieldMODIFIEDON]);
            this.MODIFIEDUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldMODIFIEDUSERID]);
            this.MODIFIEDBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTINFOTable.FieldMODIFIEDBY]);
            
            return this;
        }
    }
}