/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:53
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiRoleTable
     /// 系统角色表
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
     public partial class PiRoleTable
     {
          ///<summary>
          /// 系统角色表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIROLE";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 系统主键
          ///</summary>
          [NonSerialized]
          public static string FieldSystemId = "SYSTEMID";

          ///<summary>
          /// 组织机构主键
          ///</summary>
          [NonSerialized]
          public static string FieldOrganizeId = "ORGANIZEID";

          ///<summary>
          /// 角色分类
          ///</summary>
          [NonSerialized]
          public static string FieldCategory = "CATEGORY";

          ///<summary>
          /// 角色编号
          ///</summary>
          [NonSerialized]
          public static string FieldCode = "CODE";

          ///<summary>
          /// 角色名称
          ///</summary>
          [NonSerialized]
          public static string FieldRealName = "REALNAME";

          ///<summary>
          /// 允许编辑
          ///</summary>
          [NonSerialized]
          public static string FieldAllowEdit = "ALLOWEDIT";

          ///<summary>
          /// 允许删除
          ///</summary>
          [NonSerialized]
          public static string FieldAllowDelete = "ALLOWDELETE";

          ///<summary>
          /// 排序码
          ///</summary>
          [NonSerialized]
          public static string FieldSortCode = "SORTCODE";

          ///<summary>
          /// 删除标记
          ///</summary>
          [NonSerialized]
          public static string FieldDeleteMark = "DELETEMARK";

          ///<summary>
          /// 有效标志
          ///</summary>
          [NonSerialized]
          public static string FieldEnabled = "ENABLED";

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
