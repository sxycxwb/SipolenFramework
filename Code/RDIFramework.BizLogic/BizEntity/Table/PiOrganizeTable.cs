/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:51
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiOrganizeTable
     /// 组织机构、部门表
     ///
     /// 修改纪录
     ///    
    ///         2014-06-11 版本: 2.8 EricHu 增加主负责人主键与副负责人主键。
     ///	    2012-03-02 版本：1.0 EricHu 创建主键。
     ///
     /// 版本：2.8
     ///
     /// <author>
     ///		<name>EricHu</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class PiOrganizeTable
     {
          ///<summary>
          /// 组织机构、部门表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIORGANIZE";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 父级主键
          ///</summary>
          [NonSerialized]
          public static string FieldParentId = "PARENTID";

          ///<summary>
          /// 编号
          ///</summary>
          [NonSerialized]
          public static string FieldCode = "CODE";

          ///<summary>
          /// 简称
          ///</summary>
          [NonSerialized]
          public static string FieldShortName = "SHORTNAME";

          ///<summary>
          /// 名称
          ///</summary>
          [NonSerialized]
          public static string FieldFullName = "FULLNAME";

          ///<summary>
          /// 分类
          ///</summary>
          [NonSerialized]
          public static string FieldCategory = "CATEGORY";

          ///<summary>
          /// 外线电话
          ///</summary>
          [NonSerialized]
          public static string FieldOuterPhone = "OUTERPHONE";

          ///<summary>
          /// 内线电话
          ///</summary>
          [NonSerialized]
          public static string FieldInnerPhone = "INNERPHONE";

          ///<summary>
          /// 传真
          ///</summary>
          [NonSerialized]
          public static string FieldFax = "FAX";

          ///<summary>
          /// 邮编
          ///</summary>
          [NonSerialized]
          public static string FieldPostalcode = "POSTALCODE";

          ///<summary>
          /// 地址
          ///</summary>
          [NonSerialized]
          public static string FieldAddress = "ADDRESS";

          ///<summary>
          /// 网址
          ///</summary>
          [NonSerialized]
          public static string FieldWeb = "WEB";

          ///<summary>
          /// 主负责人主键
          ///</summary>
          [NonSerialized]
          public static string FieldManagerId = "MANAGERID";

          ///<summary>
          /// 主负责人
          ///</summary>
          [NonSerialized]
          public static string FieldManager = "MANAGER";

          ///<summary>
          /// 层
          ///</summary>
          [NonSerialized]
          public static string FieldLayer = "LAYER";

          ///<summary>
          /// 副负责人主键
          ///</summary>
          [NonSerialized]
          public static string FieldAssistantManagerId = "ASSISTANTMANAGERID";

          ///<summary>
          /// 副负责人
          ///</summary>
          [NonSerialized]
          public static string FieldAssistantManager = "ASSISTANTMANAGER";

          ///<summary>
          /// 内部组织机构
          ///</summary>
          [NonSerialized]
          public static string FieldIsInnerOrganize = "ISINNERORGANIZE";

          ///<summary>
          /// 开户行
          ///</summary>
          [NonSerialized]
          public static string FieldBank = "BANK";

          ///<summary>
          /// 银行帐号
          ///</summary>
          [NonSerialized]
          public static string FieldBankAccount = "BANKACCOUNT";

          ///<summary>
          /// 删除标记
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
