﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//	RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//	RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
// 官方博客：http://www.cnblogs.com/huyong
//           http://blog.csdn.net/chinahuyong
//    Email：80368704@qq.com
//       QQ：80368704
//------------------------------------------------------------------------------
// <auto-generated>
//	此代码由RDIFramework.NET平台代码生成工具自动生成。
//	运行时版本:4.0.30319.1
//
//	对此文件的更改可能会导致不正确的行为，并且如果
//	重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// PiUserLogOnTable
    /// 用户登录信息表
    ///
    /// 修改纪录
    ///
    ///		2014-03-25 版本：2.8 XuWangBin 创建。
    ///
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-03-25</date>
    /// </author>
    /// </summary>
    public  class PiUserLogOnTable
    {
        ///<summary>
        /// 用户登录信息表
        ///</summary>
        [NonSerialized]
        public static string TableName = "PIUSERLOGON";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 用户来源
        ///</summary>
        [NonSerialized]
        public static string FieldUserFrom = "USERFROM";

        ///<summary>
        /// 用户密码
        ///</summary>
        [NonSerialized]
        public static string FieldUserPassword = "USERPASSWORD";

        ///<summary>
        /// 当点登录标示
        ///</summary>
        [NonSerialized]
        public static string FieldOpenId = "OPENID";

        ///<summary>
        /// 允许登录时间开始
        ///</summary>
        [NonSerialized]
        public static string FieldAllowStartTime = "ALLOWSTARTTIME";

        ///<summary>
        /// 允许登录时间结束
        ///</summary>
        [NonSerialized]
        public static string FieldAllowEndTime = "ALLOWENDTIME";

        ///<summary>
        /// 暂停用户开始日期
        ///</summary>
        [NonSerialized]
        public static string FieldLockStartDate = "LOCKSTARTDATE";

        ///<summary>
        /// 暂停用户结束日期
        ///</summary>
        [NonSerialized]
        public static string FieldLockEndDate = "LOCKENDDATE";

        ///<summary>
        /// 第一次访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldFirstVisit = "FIRSTVISIT";

        ///<summary>
        /// 上一次访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldPreviousVisit = "PREVIOUSVISIT";

        ///<summary>
        /// 最后访问时间
        ///</summary>
        [NonSerialized]
        public static string FieldLastVisit = "LASTVISIT";

        ///<summary>
        /// 最后修改密码日期
        ///</summary>
        [NonSerialized]
        public static string FieldChangePasswordDate = "CHANGEPASSWORDDATE";

        ///<summary>
        /// 允许同时有多用户登录
        ///</summary>
        [NonSerialized]
        public static string FieldMultiUserLogin = "MULTIUSERLOGIN";

        ///<summary>
        /// 登录次数
        ///</summary>
        [NonSerialized]
        public static string FieldLogOnCount = "LOGONCOUNT";

        ///<summary>
        /// 密码连续错误次数
        ///</summary>
        [NonSerialized]
        public static string FieldPasswordErrorCount = "PASSWORDERRORCOUNT";

        ///<summary>
        /// 在线状态
        ///</summary>
        [NonSerialized]
        public static string FieldUserOnLine = "USERONLINE";

        ///<summary>
        /// IP访问限制
        ///</summary>
        [NonSerialized]
        public static string FieldCheckIPAddress = "CHECKIPADDRESS";

        ///<summary>
        /// 登录IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPADDRESS";

        ///<summary>
        /// 登录MAC地址
        ///</summary>
        [NonSerialized]
        public static string FieldMACAddress = "MACADDRESS";

        ///<summary>
        /// 密码提示问题
        ///</summary>
        [NonSerialized]
        public static string FieldQuestion = "QUESTION";

        ///<summary>
        /// 密码提示答案
        ///</summary>
        [NonSerialized]
        public static string FieldAnswerQuestion = "ANSWERQUESTION";

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
