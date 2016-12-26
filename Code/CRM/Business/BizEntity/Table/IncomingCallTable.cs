//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace CRM
{
    /// <summary>
    /// IncomingCallTable
    /// 来电处理
    /// 
    /// 修改纪录
    /// 
    /// 2012-09-03 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-09-03</date>
    /// </author>
    /// </summary>
    public partial class IncomingCallTable
    {
        ///<summary>
        /// 来电处理
        ///</summary>
        [NonSerialized]
        public static string TableName = "IncomingCall";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 客户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCustomerId = "CustomerId";

        ///<summary>
        /// 客户名称
        ///</summary>
        [NonSerialized]
        public static string FieldCustomerName = "CustomerName";

        ///<summary>
        /// 来电分类
        ///</summary>
        [NonSerialized]
        public static string FieldCallType = "CallType";

        ///<summary>
        /// 来电记录
        ///</summary>
        [NonSerialized]
        public static string FieldCallRecord = "CallRecord";

        ///<summary>
        /// 来电号码
        ///</summary>
        [NonSerialized]
        public static string FieldCallNumber = "CallNumber";

        ///<summary>
        /// 电来时间
        ///</summary>
        [NonSerialized]
        public static string FieldCallDate = "CallDate";

        ///<summary>
        /// 是否处理
        ///</summary>
        [NonSerialized]
        public static string FieldHandled = "Handled";

        ///<summary>
        /// 描述、备注
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeleteMark = "DeleteMark";

        ///<summary>
        /// 有效标志
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

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