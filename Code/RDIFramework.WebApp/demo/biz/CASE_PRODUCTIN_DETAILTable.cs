using System;

namespace RDIFramework.WebApp
{
    /// <summary>
    /// CASE_PRODUCTIN_DETAILTable
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
    public partial class CASE_PRODUCTIN_DETAILTable
    {
        ///<summary>
        /// 
        ///</summary>
        [NonSerialized]
        public static string TableName = "CASE_PRODUCTIN_DETAIL";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldID = "ID";

        ///<summary>
        /// 入库单主表主键
        ///</summary>
        [NonSerialized]
        public static string FieldCASE_PRODUCTIN_MAIN_ID = "CASE_PRODUCTIN_MAIN_ID";

        ///<summary>
        /// 序号
        ///</summary>
        [NonSerialized]
        public static string FieldSEQUENCE = "SEQUENCE";

        ///<summary>
        /// 类型
        ///</summary>
        [NonSerialized]
        public static string FieldCATEGORY = "CATEGORY";

        ///<summary>
        /// 编码
        ///</summary>
        [NonSerialized]
        public static string FieldCODE = "CODE";

        ///<summary>
        /// 品名
        ///</summary>
        [NonSerialized]
        public static string FieldFULLNAME = "FULLNAME";

        ///<summary>
        /// 型号
        ///</summary>
        [NonSerialized]
        public static string FieldMODEL = "MODEL";

        ///<summary>
        /// 规格
        ///</summary>
        [NonSerialized]
        public static string FieldFORMAT = "FORMAT";

        ///<summary>
        /// 单位
        ///</summary>
        [NonSerialized]
        public static string FieldUNIT = "UNIT";

        ///<summary>
        /// 数量
        ///</summary>
        [NonSerialized]
        public static string FieldAMOUNT = "AMOUNT";

        ///<summary>
        /// 单价
        ///</summary>
        [NonSerialized]
        public static string FieldUNITPRICE = "UNITPRICE";

        ///<summary>
        /// 金额
        ///</summary>
        [NonSerialized]
        public static string FieldTOTALSUM = "TOTALSUM";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDELETEMARK = "DELETEMARK";

        ///<summary>
        /// 入库状态
        ///</summary>
        [NonSerialized]
        public static string FieldSTATE = "STATE";

        ///<summary>
        /// 负责人
        ///</summary>
        [NonSerialized]
        public static string FieldPEOPLE = "PEOPLE";

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