/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:48
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiItemsTable
     /// 数据字典主表
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
     public partial class CiItemsTable
     {
          ///<summary>
          /// 数据字典主表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CIITEMS";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 父节点主键
          ///</summary>
          [NonSerialized]
          public static string FieldParentId = "PARENTID";

          ///<summary>
          /// 编号
          ///</summary>
          [NonSerialized]
          public static string FieldCode = "CODE";

          ///<summary>
          /// 名称
          ///</summary>
          [NonSerialized]
          public static string FieldFullName = "FULLNAME";

          /// <summary>
          /// 数据字典分类
          /// </summary>
          [NonSerialized]
          public static string FieldCategory = "CATEGORY";

          ///<summary>
          /// 目标存储表
          ///</summary>
          [NonSerialized]
          public static string FieldTargetTable = "TARGETTABLE";

          ///<summary>
          /// 树型结构
          ///</summary>
          [NonSerialized]
          public static string FieldIsTree = "ISTREE";

          ///<summary>
          /// 编号字段对应值
          ///</summary>
          [NonSerialized]
          public static string FieldUseItemCode = "USEITEMCODE";

          ///<summary>
          /// 名称字段对应值
          ///</summary>
          [NonSerialized]
          public static string FieldUseItemName = "USEITEMNAME";

          ///<summary>
          /// 值字段对应值
          ///</summary>
          [NonSerialized]
          public static string FieldUseItemValue = "USEITEMVALUE";

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
