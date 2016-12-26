/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:49
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiLogTable
     /// 系统日志表
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
    public partial class CiLogTable
    {
        ///<summary>
        /// 系统日志表
        ///</summary>
        [NonSerialized]
        public static string TableName = "CILOG";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 服务
        ///</summary>
        [NonSerialized]
        public static string FieldProcessId = "PROCESSID";

        ///<summary>
        /// 服务名称
        ///</summary>
        [NonSerialized]
        public static string FieldProcessName = "PROCESSNAME";

        ///<summary>
        /// 操作英文名称
        ///</summary>
        [NonSerialized]
        public static string FieldMethodEngName = "METHODENGNAME";


        ///<summary>
        /// 操作名称
        ///</summary>
        [NonSerialized]
        public static string FieldMethodName = "METHODNAME";

        ///<summary>
        /// 操作参数
        ///</summary>
        [NonSerialized]
        public static string FieldParameters = "PARAMETERS";


        /// <summary>
        /// 用户名
        /// </summary>
        [NonSerialized]
        public static string FieldUserRealName = "USERREALNAME";

        ///<summary>
        /// IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPADDRESS";

        ///<summary>
        /// 网址
        ///</summary>
        [NonSerialized]
        public static string FieldWebUrl = "WEBURL";

        ///<summary>
        /// 描述
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
    }
}
