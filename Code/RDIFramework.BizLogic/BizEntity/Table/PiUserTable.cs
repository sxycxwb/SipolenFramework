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
     ///        2016-01-30 版本：3.0 XuWangBin 新增离职相关的列。
     ///        2014-03-27 版本：2.8 XuWangBin 重新整理用户帐号表，分离登录信息部分列
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class PiUserTable
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

          ///<summary>
          /// 公司主键
          ///</summary>
          [NonSerialized]
          public static string FieldCompanyId = "COMPANYID";

          ///<summary>
          /// 公司名称
          ///</summary>
          [NonSerialized]
          public static string FieldCompanyName = "COMPANYNAME";

          ///<summary>
          /// 子公司（分支机构）主键
          ///</summary>
          [NonSerialized]
          public static string FieldSubCompanyId = "SUBCOMPANYID";

          ///<summary>
          /// 子公司（分支机构）名称
          ///</summary>
          [NonSerialized]
          public static string FieldSubCompanyName = "SUBCOMPANYNAME";

          ///<summary>
          /// 部门主键
          ///</summary>
          [NonSerialized]
          public static string FieldDepartmentId = "DEPARTMENTID";

          ///<summary>
          /// 部门名称
          ///</summary>
          [NonSerialized]
          public static string FieldDepartmentName = "DEPARTMENTNAME";

          ///<summary>
          /// 子部门主键
          ///</summary>
          [NonSerialized]
          public static string FieldSubDepartmentId = "SUBDEPARTMENTID";

          ///<summary>
          /// 子部门名称
          ///</summary>
          [NonSerialized]
          public static string FieldSubDepartmentName = "SUBDEPARTMENTNAME";

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

          /// <summary>
          /// 安全级别
          /// </summary>
          [NonSerialized]
          public static string FieldSecurityLevel = "SECURITYLEVEL";


          ///<summary>
          /// 工作行业
          ///</summary>
          [NonSerialized]
          public static string FieldWorkCategory = "WORKCATEGORY";

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
          /// QQ号码
          ///</summary>
          [NonSerialized]
          public static string FieldQICQ = "QICQ";

          ///<summary>
          /// 个性签名
          ///</summary>
          [NonSerialized]
          public static string FieldSignature = "SIGNATURE";

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
          /// 家庭住址
          ///</summary>
          [NonSerialized]
          public static string FieldHomeAddress = "HOMEADDRESS";

          ///<summary>
          /// 用户默认地址
          ///</summary>
          [NonSerialized]
          public static string FieldUserAddress = "USERADDRESS";

          ///<summary>
          /// 离职
          ///</summary>
          [NonSerialized]
          public static string FieldIsDimission = "ISDIMISSION";

          ///<summary>
          /// 离职日期
          ///</summary>
          [NonSerialized]
          public static string FieldDimissionDate = "DIMISSIONDATE";

          ///<summary>
          /// 离职原因
          ///</summary>
          [NonSerialized]
          public static string FieldDimissionCause = "DIMISSIONCAUSE";

          ///<summary>
          /// 离职去向
          ///</summary>
          [NonSerialized]
          public static string FieldDimissionWhither = "DIMISSIONWHITHER";

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
