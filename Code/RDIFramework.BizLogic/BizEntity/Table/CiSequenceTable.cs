/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:50
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiSequenceTable
     /// 序列产生器表
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
     public partial class CiSequenceTable
     {
          ///<summary>
          /// 序列产生器表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CISEQUENCE";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 名称
          ///</summary>
          [NonSerialized]
          public static string FieldFullName = "FULLNAME";

          ///<summary>
          /// 序列号前缀
          ///</summary>
          [NonSerialized]
          public static string FieldPrefix = "PREFIX";

          ///<summary>
          /// 序列号分隔符
          ///</summary>
          [NonSerialized]
          public static string FieldSeparate = "SEPARATE";

          ///<summary>
          /// 升序序列
          ///</summary>
          [NonSerialized]
          public static string FieldSequence = "SEQUENCE";

          ///<summary>
          /// 倒序序列
          ///</summary>
          [NonSerialized]
          public static string FieldReduction = "REDUCTION";

          ///<summary>
          /// 步骤
          ///</summary>
          [NonSerialized]
          public static string FieldStep = "STEP";

          ///<summary>
          /// 删除标志
          ///</summary>
          [NonSerialized]
          public static string FieldDeleteMark = "DELETEMARK";

          ///<summary>
          /// 创建日期
          ///</summary>
          [NonSerialized]
          public static string FieldCreateOn = "CREATEON";

          ///<summary>
          /// 描述
          ///</summary>
          [NonSerialized]
          public static string FieldDescription = "DESCRIPTION";
      }
}
