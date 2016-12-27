/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:49
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiParameterTable
     /// 系统参数配置表
     ///
     /// 修改纪录
     ///    
     ///    2015-08-06 版本：3.0 XuWangBin 新增允许编辑、允许删除列。
     ///	2012-03-02 版本：1.0 XuWangBin 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>XuWangBin</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
     public partial class CiParameterTable
     {
          ///<summary>
          /// 系统参数配置表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CIPARAMETER";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 分类键值
          ///</summary>
          [NonSerialized]
          public static string FieldCategoryKey = "CATEGORYKEY";

          ///<summary>
          /// 参数主键
          ///</summary>
          [NonSerialized]
          public static string FieldParameterId = "PARAMETERID";

          ///<summary>
          /// 参数编号
          ///</summary>
          [NonSerialized]
          public static string FieldParameterCode = "PARAMETERCODE";

          ///<summary>
          /// 参数具体内容
          ///</summary>
          [NonSerialized]
          public static string FieldParameterContent = "PARAMETERCONTENT";

          ///<summary>
          /// 处理审核过
          ///</summary>
          [NonSerialized]
          public static string FieldWorked = "WORKED";

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
          /// 删除标志
          ///</summary>
          [NonSerialized]
          public static string FieldDeleteMark = "DELETEMARK";

          ///<summary>
          /// 描述
          ///</summary>
          [NonSerialized]
          public static string FieldDescription = "DESCRIPTION";

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
