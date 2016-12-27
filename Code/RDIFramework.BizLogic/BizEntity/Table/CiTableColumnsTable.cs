/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:50
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiTableColumnsTable
     /// 表字段结构定义说明
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
     public partial class CiTableColumnsTable
     {
         ///<summary>
         /// 表字段结构定义说明
         ///</summary>
         [NonSerialized]
         public static string TableName = "CITABLECOLUMNS";

         ///<summary>
         /// 主键
         ///</summary>
         [NonSerialized]
         public static string FieldId = "ID";

         ///<summary>
         /// 表
         ///</summary>
         [NonSerialized]
         public static string FieldTableCode = "TABLECODE";

         ///<summary>
         /// 表名
         ///</summary>
         [NonSerialized]
         public static string FieldTableName = "TABLENAME";

         ///<summary>
         /// 表
         ///</summary>
         [NonSerialized]
         public static string FieldColumnCode = "COLUMNCODE";

         ///<summary>
         /// 表名
         ///</summary>
         [NonSerialized]
         public static string FieldColumnName = "COLUMNNAME";

         ///<summary>
         /// 是公开
         ///</summary>
         [NonSerialized]
         public static string FieldIsPublic = "ISPUBLIC";

         ///<summary>
         /// 列可访问
         ///</summary>
         [NonSerialized]
         public static string FieldColumnAccess = "COLUMNACCESS";

         ///<summary>
         /// 列可修改
         ///</summary>
         [NonSerialized]
         public static string FieldColumnEdit = "COLUMNEDIT";

         ///<summary>
         /// 限制访问
         ///</summary>
         [NonSerialized]
         public static string FieldColumnDeney = "COLUMNDENEY";

         ///<summary>
         /// 使用约束
         ///</summary>
         [NonSerialized]
         public static string FieldUseConstraint = "USECONSTRAINT";

         ///<summary>
         /// 数据类型
         ///</summary>
         [NonSerialized]
         public static string FieldDataType = "DATATYPE";

         ///<summary>
         /// 目标表
         ///</summary>
         [NonSerialized]
         public static string FieldTargetTable = "TARGETTABLE";

         ///<summary>
         /// 是否是查询列
         ///</summary>
         [NonSerialized]
         public static string FieldIsSearchColumn = "ISSEARCHCOLUMN";
           
         /// <summary>
         /// 是否是展示列
         /// </summary>
         [NonSerialized]
         public static string FieldIsExhibitColumn = "ISEXHIBITCOLUMN";

         ///<summary>
         /// 有效
         ///</summary>
         [NonSerialized]
         public static string FieldEnabled = "ENABLED";

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
