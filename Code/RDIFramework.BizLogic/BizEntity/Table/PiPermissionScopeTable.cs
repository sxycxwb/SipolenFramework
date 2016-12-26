/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:51
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiPermissionScopeTable
     /// 数据集权限存储表
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
     public partial class PiPermissionScopeTable
     {
          ///<summary>
          /// 数据集权限存储表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIPERMISSIONSCOPE";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 什么类型的
          ///</summary>
          [NonSerialized]
          public static string FieldResourceCategory = "RESOURCECATEGORY";

          ///<summary>
          /// 什么资源
          ///</summary>
          [NonSerialized]
          public static string FieldResourceId = "RESOURCEID";

          ///<summary>
          /// 对什么类型的
          ///</summary>
          [NonSerialized]
          public static string FieldTargetCategory = "TARGETCATEGORY";

          ///<summary>
          /// 对什么资源
          ///</summary>
          [NonSerialized]
          public static string FieldTargetId = "TARGETID";

          ///<summary>
          /// 有什么权限
          ///</summary>
          [NonSerialized]
          public static string FieldPermissionId = "PERMISSIONID";

          ///<summary>
          /// 权限约束
          ///</summary>
          [NonSerialized]
          public static string FieldPermissionConstraint = "PERMISSIONCONSTRAINT";

          ///<summary>
          /// 开始生效日期
          ///</summary>
          [NonSerialized]
          public static string FieldStartDate = "STARTDATE";

          ///<summary>
          /// 结束生效日期
          ///</summary>
          [NonSerialized]
          public static string FieldEndDate = "ENDDATE";

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
