/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:55
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiUserTable
     /// 用户账户表
     ///
     /// 修改纪录
     ///
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：1.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class PiUserTable_V27
     {
          ///<summary>
          /// 用户账户表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIUSER";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 编号
          ///</summary>
          [NonSerialized]
          public static string FieldCode = "CODE";

          ///<summary>
          /// 登录名
          ///</summary>
          [NonSerialized]
          public static string FieldUserName = "USERNAME";

          ///<summary>
          /// 姓名
          ///</summary>
          [NonSerialized]
          public static string FieldRealName = "REALNAME";

         /// <summary>
         /// 昵称
         /// </summary>
         [NonSerialized]
         public static string FieldNickName = "NICKNAME";

         /// <summary>
         /// 快速查询码
         /// </summary>
         [NonSerialized]
         public static string FieldQuickQuery = "QUICKQUERY";
          ///<summary>
          /// 默认角色主键
          ///</summary>
          [NonSerialized]
          public static string FieldRoleId = "ROLEID";

          /// <summary>
          /// 安全级别
          /// </summary>
          [NonSerialized]
          public static string FieldSecurityLevel = "SECURITYLEVEL";

          ///<summary>
          /// 用户来源
          ///</summary>
          [NonSerialized]
          public static string FieldUserFrom = "USERFROM";

          ///<summary>
          /// 工作行业
          ///</summary>
          [NonSerialized]
          public static string FieldWorkCategory = "WORKCATEGORY";

          ///<summary>
          /// 公司代码
          ///</summary>
          [NonSerialized]
          public static string FieldCompanyId = "COMPANYID";

          ///<summary>
          /// 公司名称
          ///</summary>
          [NonSerialized]
          public static string FieldCompanyName = "COMPANYNAME";

          ///<summary>
          /// 部门代码
          ///</summary>
          [NonSerialized]
          public static string FieldDepartmentId = "DEPARTMENTID";

          ///<summary>
          /// 部门名称
          ///</summary>
          [NonSerialized]
          public static string FieldDepartmentName = "DEPARTMENTNAME";

          ///<summary>
          /// 工作组代码
          ///</summary>
          [NonSerialized]
          public static string FieldWorkgroupId = "WORKGROUPID";

          ///<summary>
          /// 工作组名称
          ///</summary>
          [NonSerialized]
          public static string FieldWorkgroupName = "WORKGROUPNAME";

          ///<summary>
          /// 性别
          ///</summary>
          [NonSerialized]
          public static string FieldGender = "GENDER";

          ///<summary>
          /// 手机
          ///</summary>
          [NonSerialized]
          public static string FieldMobile = "MOBILE";

          ///<summary>
          /// 固定电话
          ///</summary>
          [NonSerialized]
          public static string FieldTelephone = "TELEPHONE";

          ///<summary>
          /// 出生日期
          ///</summary>
          [NonSerialized]
          public static string FieldBirthday = "BIRTHDAY";

          ///<summary>
          /// 岗位
          ///</summary>
          [NonSerialized]
          public static string FieldDuty = "DUTY";

          ///<summary>
          /// 职称
          ///</summary>
          [NonSerialized]
          public static string FieldTitle = "TITLE";

          ///<summary>
          /// 用户密码
          ///</summary>
          [NonSerialized]
          public static string FieldUserPassword = "USERPASSWORD";

          ///<summary>
          /// 改变密码时间
          ///</summary>
          [NonSerialized]
          public static string FieldChangePasswordDate = "CHANGEPASSWORDDATE";

          ///<summary>
          /// QQ号码
          ///</summary>
          [NonSerialized]
          public static string FieldQICQ = "QICQ";

          ///<summary>
          /// 电子邮件
          ///</summary>
          [NonSerialized]
          public static string FieldEmail = "EMAIL";

          ///<summary>
          /// 系统语言选择
          ///</summary>
          [NonSerialized]
          public static string FieldLang = "LANG";

          ///<summary>
          /// 系统样式选择
          ///</summary>
          [NonSerialized]
          public static string FieldTheme = "THEME";

          ///<summary>
          /// 允许登录开始时间
          ///</summary>
          [NonSerialized]
          public static string FieldAllowStartTime = "ALLOWSTARTTIME";

          ///<summary>
          /// 允许登录结束时间
          ///</summary>
          [NonSerialized]
          public static string FieldAllowEndTime = "ALLOWENDTIME";

          ///<summary>
          /// 暂停登录开始时间
          ///</summary>
          [NonSerialized]
          public static string FieldLockStartDate = "LOCKSTARTDATE";

          ///<summary>
          /// 暂停登录结束时间
          ///</summary>
          [NonSerialized]
          public static string FieldLockEndDate = "LOCKENDDATE";

          ///<summary>
          /// 第一次登录时间
          ///</summary>
          [NonSerialized]
          public static string FieldFirstVisit = "FIRSTVISIT";

          ///<summary>
          /// 上一次登录时间
          ///</summary>
          [NonSerialized]
          public static string FieldPreviousVisit = "PREVIOUSVISIT";

          ///<summary>
          /// 最后登录时间
          ///</summary>
          [NonSerialized]
          public static string FieldLastVisit = "LASTVISIT";

          ///<summary>
          /// 登录次数
          ///</summary>
          [NonSerialized]
          public static string FieldLogOnCount = "LOGONCOUNT";

          ///<summary>
          /// 是否职员
          ///</summary>
          [NonSerialized]
          public static string FieldIsStaff = "ISSTAFF";

          ///<summary>
          /// 审核状态
          ///</summary>
          [NonSerialized]
          public static string FieldAuditStatus = "AUDITSTATUS";

          ///<summary>
          /// 是否显示
          ///</summary>
          [NonSerialized]
          public static string FieldIsVisible = "ISVISIBLE";

          ///<summary>
          /// 在线状态
          ///</summary>
          [NonSerialized]
          public static string FieldUserOnLine = "USERONLINE";

          ///<summary>
          /// IP地址
          ///</summary>
          [NonSerialized]
          public static string FieldIPAddress = "IPADDRESS";

          ///<summary>
          /// MAC地址
          ///</summary>
          [NonSerialized]
          public static string FieldMACAddress = "MACADDRESS";

          ///<summary>
          /// 家庭住址
          ///</summary>
          [NonSerialized]
          public static string FieldHomeAddress = "HOMEADDRESS";

          ///<summary>
          /// 单点登录标识
          ///</summary>
          [NonSerialized]
          public static string FieldOpenId = "OPENID";

          ///<summary>
          /// 密码提示问题代码
          ///</summary>
          [NonSerialized]
          public static string FieldQuestion = "QUESTION";

          ///<summary>
          /// 密码提示答案
          ///</summary>
          [NonSerialized]
          public static string FieldAnswerQuestion = "ANSWERQUESTION";

          ///<summary>
          /// 用户默认地址
          ///</summary>
          [NonSerialized]
          public static string FieldUserAddress = "USERADDRESS";

          ///<summary>
          /// 删除标志
          ///</summary>
          [NonSerialized]
          public static string FieldDeleteMark = "DELETEMARK";

          ///<summary>
          /// 有效
          ///</summary>
          [NonSerialized]
          public static string FieldEnabled = "ENABLED";

          ///<summary>
          /// 排序码
          ///</summary>
          [NonSerialized]
          public static string FieldSortCode = "SORTCODE";

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
