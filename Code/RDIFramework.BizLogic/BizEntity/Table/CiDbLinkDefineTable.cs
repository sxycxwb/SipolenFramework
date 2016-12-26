/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:34
 ******************************************************************************/
using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// CiDbLinkDefineTable
    /// 数据库连接定义
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 EricHu 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class CiDbLinkDefineTable
    {
        ///<summary>
        /// 数据库连接定义
        ///</summary>
        [NonSerialized]
        public static string TableName = "CIDBLINKDEFINE";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 数据库字符串连接的名称，程序中主要用这个名称来得到相应的连接字符串。
        ///</summary>
        [NonSerialized]
        public static string FieldLinkName = "LINKNAME";

        ///<summary>
        /// 数据库连接的类型（如连接类型为：sqlserver、oracle、db2、mysql、access等）
        ///</summary>
        [NonSerialized]
        public static string FieldLinkType = "LINKTYPE";

        ///<summary>
        /// 连接字符串
        ///</summary>
        [NonSerialized]
        public static string FieldLinkData = "LINKDATA";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeleteMark = "DELETEMARK";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SORTCODE";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "ENABLED";

        ///<summary>
        /// 备注
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "DESCRIPTION";

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
