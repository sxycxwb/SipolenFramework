/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:50
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// PiModuleTable
     /// 模块（菜单）表
     ///
     /// 修改纪录
    ///         2015-06-18 版本：3.0 XuWangBin 新增MVCNAVIGATEURL
     ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class PiModuleTable
     {
          ///<summary>
          /// 模块（菜单）表
          ///</summary>
          [NonSerialized]
          public static string TableName = "PIMODULE";

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

          ///<summary>
          /// 菜单分类
          ///</summary>
          [NonSerialized]
          public static string FieldCategory = "CATEGORY";

          /// <summary>
          /// 模块类型
          /// </summary>
          public static string FieldModuleType = "MODULETYPE";

          ///<summary>
          /// 图标编号
          ///</summary>
          [NonSerialized]
          public static string FieldImageIndex = "IMAGEINDEX";

          ///<summary>
          /// 选中状态图标编号
          ///</summary>
          [NonSerialized]
          public static string FieldSelectedImageIndex = "SELECTEDIMAGEINDEX";

          /// <summary>
          /// 一个CSS样式来显示一个16*16 的ICON（针对WebForm结构）
          /// </summary>
          public static string FieldIconCss = "ICONCSS";

          /// <summary>
          /// 图标地址（针对WebForm结构）
          /// </summary>
          [NonSerialized]
          public static string FieldIconUrl = "ICONURL";

          ///<summary>
          /// 导航地址（针对WebForm结构）
          ///</summary>
          [NonSerialized]
          public static string FieldNavigateUrl = "NAVIGATEURL";

          ///<summary>
          /// MVC导航地址（针对MVC结构）
          ///</summary>
          [NonSerialized]
          public static string FieldMvcNavigateUrl = "MVCNAVIGATEURL";
         
          ///<summary>
          /// 目标（针对WebForm结构）
          ///</summary>
          [NonSerialized]
          public static string FieldTarget = "TARGET";

          /// <summary>
          /// 窗体名称（针对WinForm结构）
          /// </summary>
          [NonSerialized]
          public static string FiledFormName = "FORMNAME";

          /// <summary>
          /// 程序集名称（针对WinForm结构）
          /// </summary>
          [NonSerialized]
          public static string FiledAssemblyName = "ASSEMBLYNAME";
          ///<summary>
          /// 操作权限编号(数据权限范围)
          ///</summary>
          [NonSerialized]
          public static string FieldPermissionItemCode = "PERMISSIONITEMCODE";

          ///<summary>
          /// 需要数据权限过滤的表(,符号分割)
          ///</summary>
          [NonSerialized]
          public static string FieldPermissionScopeTables = "PERMISSIONSCOPETABLES";

          ///<summary>
          /// 是公开
          ///</summary>
          [NonSerialized]
          public static string FieldIsPublic = "ISPUBLIC";

          ///<summary>
          /// 是菜单
          ///</summary>
          [NonSerialized]
          public static string FieldIsMenu = "ISMENU";

          ///<summary>
          /// 展开状态
          ///</summary>
          [NonSerialized]
          public static string FieldExpand = "EXPAND";

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
