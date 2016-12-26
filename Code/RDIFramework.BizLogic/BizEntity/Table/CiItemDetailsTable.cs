/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:48
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiItemDetailsTable
     /// 数据字典明细表
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
     public partial class CiItemDetailsTable
     {
          ///<summary>
          /// 数据字典明细表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CIITEMDETAILS";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 数据字典主表主键
          ///</summary>
          [NonSerialized]
          public static string FieldItemId = "ITEMID";

          ///<summary>
          /// 父节点主键
          ///</summary>
          [NonSerialized]
          public static string FieldParentId = "PARENTID";

          ///<summary>
          /// 资源编号
          ///</summary>
          [NonSerialized]
          public static string FieldItemCode = "ITEMCODE";

          ///<summary>
          /// 资源名称
          ///</summary>
          [NonSerialized]
          public static string FieldItemName = "ITEMNAME";

          ///<summary>
          /// 资源值
          ///</summary>
          [NonSerialized]
          public static string FieldItemValue = "ITEMVALUE";

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
          /// 是公开
          ///</summary>
          [NonSerialized]
          public static string FieldIsPublic = "ISPUBLIC";

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
