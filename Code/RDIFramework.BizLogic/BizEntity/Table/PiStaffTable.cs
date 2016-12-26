/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:54
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiStaffTable
     /// 员工（职员）表
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
     public partial class PiStaffTable
     {
          ///<summary>
          /// 员工（职员）表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PISTAFF";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 编号,工号
          ///</summary>
          [NonSerialized]
          public static string FieldCode = "CODE";

          ///<summary>
          /// 用户主键
          ///</summary>
          [NonSerialized]
          public static string FieldUserId = "USERID";

          ///<summary>
          /// 用户名(登录用)
          ///</summary>
          [NonSerialized]
          public static string FieldUserName = "USERNAME";

          ///<summary>
          /// 姓名
          ///</summary>
          [NonSerialized]
          public static string FieldRealName = "REALNAME";
      

          ///<summary>
          /// 职位代码
          ///</summary>
          [NonSerialized]
          public static string FieldDutyId = "DUTYID";

          ///<summary>
          /// 性别
          ///</summary>
          [NonSerialized]
          public static string FieldGender = "GENDER";

          ///<summary>
          /// 出生日期
          ///</summary>
          [NonSerialized]
          public static string FieldBirthday = "BIRTHDAY";

          ///<summary>
          /// 年龄
          ///</summary>
          [NonSerialized]
          public static string FieldAge = "AGE";

          ///<summary>
          /// 唯一身份Id
          ///</summary>
          [NonSerialized]
          public static string FieldIdentificationCode = "IDENTIFICATIONCODE";

          ///<summary>
          /// 身份证号码
          ///</summary>
          [NonSerialized]
          public static string FieldIDCard = "IDCARD";

          ///<summary>
          /// 银行卡号
          ///</summary>
          [NonSerialized]
          public static string FieldBankCode = "BANKCODE";

          ///<summary>
          /// 电子邮件
          ///</summary>
          [NonSerialized]
          public static string FieldEmail = "EMAIL";

          ///<summary>
          /// 手机
          ///</summary>
          [NonSerialized]
          public static string FieldMobile = "MOBILE";

          ///<summary>
          /// 短号
          ///</summary>
          [NonSerialized]
          public static string FieldShortNumber = "SHORTNUMBER";

          ///<summary>
          /// 电话
          ///</summary>
          [NonSerialized]
          public static string FieldTelephone = "TELEPHONE";

          ///<summary>
          /// QQ号码
          ///</summary>
          [NonSerialized]
          public static string FieldQICQ = "QICQ";

          ///<summary>
          /// 办公电话
          ///</summary>
          [NonSerialized]
          public static string FieldOfficePhone = "OFFICEPHONE";

          ///<summary>
          /// 办公邮编
          ///</summary>
          [NonSerialized]
          public static string FieldOfficeZipCode = "OFFICEZIPCODE";

          ///<summary>
          /// 办公地址
          ///</summary>
          [NonSerialized]
          public static string FieldOfficeAddress = "OFFICEADDRESS";

          ///<summary>
          /// 办公传真
          ///</summary>
          [NonSerialized]
          public static string FieldOfficeFax = "OFFICEFAX";

          ///<summary>
          /// 住宅电话
          ///</summary>
          [NonSerialized]
          public static string FieldHomePhone = "HOMEPHONE";

          ///<summary>
          /// 最高学历
          ///</summary>
          [NonSerialized]
          public static string FieldEducation = "EDUCATION";

          ///<summary>
          /// 毕业院校
          ///</summary>
          [NonSerialized]
          public static string FieldSchool = "SCHOOL";

          ///<summary>
          /// 最高学位
          ///</summary>
          [NonSerialized]
          public static string FieldDegree = "DEGREE";

          ///<summary>
          /// 职称
          ///</summary>
          [NonSerialized]
          public static string FieldTitle = "TITLE";

          ///<summary>
          /// 职称评定日期
          ///</summary>
          [NonSerialized]
          public static string FieldTitleDate = "TITLEDATE";

          ///<summary>
          /// 职称等级
          ///</summary>
          [NonSerialized]
          public static string FieldTitleLevel = "TITLELEVEL";

          ///<summary>
          /// 工作时间
          ///</summary>
          [NonSerialized]
          public static string FieldWorkingDate = "WORKINGDATE";

          ///<summary>
          /// 加入本单位时间
          ///</summary>
          [NonSerialized]
          public static string FieldJoinInDate = "JOININDATE";

          ///<summary>
          /// 家庭住址邮编
          ///</summary>
          [NonSerialized]
          public static string FieldHomeZipCode = "HOMEZIPCODE";

          ///<summary>
          /// 家庭住址
          ///</summary>
          [NonSerialized]
          public static string FieldHomeAddress = "HOMEADDRESS";

          ///<summary>
          /// 家庭传真
          ///</summary>
          [NonSerialized]
          public static string FieldHomeFax = "HOMEFAX";

          ///<summary>
          /// 籍贯
          ///</summary>
          [NonSerialized]
          public static string FieldNativePlace = "NATIVEPLACE";

          ///<summary>
          /// 政治面貌
          ///</summary>
          [NonSerialized]
          public static string FieldParty = "PARTY";

          ///<summary>
          /// 国籍
          ///</summary>
          [NonSerialized]
          public static string FieldNation = "NATION";

          ///<summary>
          /// 民族
          ///</summary>
          [NonSerialized]
          public static string FieldNationality = "NATIONALITY";

          ///<summary>
          /// 专业
          ///</summary>
          [NonSerialized]
          public static string FieldMajor = "MAJOR";

          ///<summary>
          /// 工作性质
          ///</summary>
          [NonSerialized]
          public static string FieldWorkingProperty = "WORKINGPROPERTY";

          ///<summary>
          /// 职业资格
          ///</summary>
          [NonSerialized]
          public static string FieldCompetency = "COMPETENCY";

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
          /// 有效
          ///</summary>
          [NonSerialized]
          public static string FieldEnabled = "ENABLED";

          ///<summary>
          /// 删除标记
          ///</summary>
          [NonSerialized]
          public static string FieldDeleteMark = "DELETEMARK";

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
