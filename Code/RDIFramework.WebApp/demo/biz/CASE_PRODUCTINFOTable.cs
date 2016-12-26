using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDIFramework.WebApp
{
    /// <summary>
    /// CASE_PRODUCTINFOTable
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2013-12-18 版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2013-12-18</date>
    /// </author>
    /// </summary>
    public partial class CASE_PRODUCTINFOTable
    {
        ///<summary>
        /// 
        ///</summary>
        [NonSerialized]
        public static string TableName = "CASE_PRODUCTINFO";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldID = "ID";

        ///<summary>
        /// 产品编码
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTCODE = "PRODUCTCODE";

        ///<summary>
        /// 产品名称
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTNAME = "PRODUCTNAME";

        ///<summary>
        /// 产品型号
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTMODEL = "PRODUCTMODEL";

        ///<summary>
        /// 产品规格
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTSTANDARD = "PRODUCTSTANDARD";

        ///<summary>
        /// 产品类别
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTCATEGORY = "PRODUCTCATEGORY";

        ///<summary>
        /// 产品单位
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTUNIT = "PRODUCTUNIT";

        ///<summary>
        /// 产品描述、备注
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTDESCRIPTION = "PRODUCTDESCRIPTION";

        ///<summary>
        /// 产品基准价
        ///</summary>
        [NonSerialized]
        public static string FieldMIDDLERATE = "MIDDLERATE";

        ///<summary>
        /// 产品基准系数
        ///</summary>
        [NonSerialized]
        public static string FieldREFERENCECOEFFICIENT = "REFERENCECOEFFICIENT";

        ///<summary>
        /// 产品单价
        ///</summary>
        [NonSerialized]
        public static string FieldPRODUCTPRICE = "PRODUCTPRICE";

        ///<summary>
        /// 产品批发价
        ///</summary>
        [NonSerialized]
        public static string FieldWHOLESALEPRICE = "WHOLESALEPRICE";

        ///<summary>
        /// 产品促销价
        ///</summary>
        [NonSerialized]
        public static string FieldPROMOTIONPRICE = "PROMOTIONPRICE";

        ///<summary>
        /// 产品内部价
        ///</summary>
        [NonSerialized]
        public static string FieldINTERNALPRICE = "INTERNALPRICE";

        ///<summary>
        /// 产品特别价
        ///</summary>
        [NonSerialized]
        public static string FieldSPECIALPRICE = "SPECIALPRICE";

        ///<summary>
        /// 作废标志
        ///</summary>
        [NonSerialized]
        public static string FieldENABLED = "ENABLED";

        ///<summary>
        /// 产品功能描述
        ///</summary>
        [NonSerialized]
        public static string FieldDESCRIPTION = "DESCRIPTION";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDELETEMARK = "DELETEMARK";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCREATEON = "CREATEON";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCREATEUSERID = "CREATEUSERID";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCREATEBY = "CREATEBY";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldMODIFIEDON = "MODIFIEDON";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldMODIFIEDUSERID = "MODIFIEDUSERID";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldMODIFIEDBY = "MODIFIEDBY";
    }
}