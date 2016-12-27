/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:51
 ******************************************************************************/
using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiPermissionItemTable
     /// 操作权限项定义
     ///
     /// 修改纪录
    ///         2015-06-18 版本：3.0 XuWangBin 新增MODULEID
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class PiPermissionItemTable
     {
          ///<summary>
          /// 操作权限项定义
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIPERMISSIONITEM";

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
          /// 模块主键
          ///</summary>
          [NonSerialized]
          public static string FieldModuleId = "MODULEID";

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

          ///<summary>
          /// 什么类型
          ///</summary>
          [NonSerialized]
          public static string FieldCategoryCode = "CATEGORYCODE";

          ///<summary>
          /// JS事件
          ///</summary>
          [NonSerialized]
          public static string FieldJsEvent = "JSEVENT";

          ///<summary>
          /// 是否分割
          ///</summary>
          [NonSerialized]
          public static string FieldIsSplit = "ISSPLIT";

          ///<summary>
          /// 权限域
          ///</summary>
          [NonSerialized]
          public static string FieldIsScope = "ISSCOPE";

          ///<summary>
          /// 是公开
          ///</summary>
          [NonSerialized]
          public static string FieldIsPublic = "ISPUBLIC";

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
          /// 最后被调用日期
          ///</summary>
          [NonSerialized]
          public static string FieldLastCall = "LASTCALL";

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
