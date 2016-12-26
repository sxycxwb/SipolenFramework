using System;

namespace RDIFramework.WebApp
{
    /// <summary>
    /// CASE_PRODUCTIN_MAINTable
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
    public partial class CASE_PRODUCTIN_MAINTable
    {
        ///<summary>
        /// 
        ///</summary>
        [NonSerialized]
        public static string TableName = "CASE_PRODUCTIN_MAIN";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldID = "ID";

        ///<summary>
        /// 入库单编码
        ///</summary>
        [NonSerialized]
        public static string FieldCODE = "CODE";

        ///<summary>
        /// 入库日期
        ///</summary>
        [NonSerialized]
        public static string FieldINDATE = "INDATE";

        ///<summary>
        /// 入库类型
        ///</summary>
        [NonSerialized]
        public static string FieldINTYPE = "INTYPE";

        ///<summary>
        /// 库房
        ///</summary>
        [NonSerialized]
        public static string FieldDEPOT = "DEPOT";

        ///<summary>
        /// 保管员
        ///</summary>
        [NonSerialized]
        public static string FieldCUSTODIAN = "CUSTODIAN";

        ///<summary>
        /// 供货商名称
        ///</summary>
        [NonSerialized]
        public static string FieldSUPPLIERNAME = "SUPPLIERNAME";

        ///<summary>
        /// 描述
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