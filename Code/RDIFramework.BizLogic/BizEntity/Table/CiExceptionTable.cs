/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:47
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiExceptionTable
     /// 系统异常表
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
     public partial class CiExceptionTable
     {
          ///<summary>
          /// 系统异常表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CIEXCEPTION";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// EventID
          ///</summary>
          [NonSerialized]
          public static string FieldEventId = "EVENTID";

          ///<summary>
          /// Category
          ///</summary>
          [NonSerialized]
          public static string FieldCategory = "CATEGORY";

          ///<summary>
          /// Priority
          ///</summary>
          [NonSerialized]
          public static string FieldPriority = "PRIORITY";

          ///<summary>
          /// Severity
          ///</summary>
          [NonSerialized]
          public static string FieldSeverity = "SEVERITY";

          ///<summary>
          /// Title
          ///</summary>
          [NonSerialized]
          public static string FieldTitle = "TITLE";

          ///<summary>
          /// Timestamp
          ///</summary>
          [NonSerialized]
          public static string FieldTimestamp = "TIMESTAMP";

          ///<summary>
          /// MachineName
          ///</summary>
          [NonSerialized]
          public static string FieldMachineName = "MACHINENAME";

          ///<summary>
          /// AppDomainName
          ///</summary>
          [NonSerialized]
          public static string FieldAppDomainName = "APPDOMAINNAME";

          ///<summary>
          /// ProcessID
          ///</summary>
          [NonSerialized]
          public static string FieldProcessId = "PROCESSID";

          ///<summary>
          /// ProcessName
          ///</summary>
          [NonSerialized]
          public static string FieldProcessName = "PROCESSNAME";

          ///<summary>
          /// 导致错误的源
          ///</summary>
          [NonSerialized]
          public static string FieldThreadName = "THREADNAME";

          ///<summary>
          /// Win32ThreadId
          ///</summary>
          [NonSerialized]
          public static string FieldWin32ThreadId = "WIN32THREADID";

          ///<summary>
          /// 异常消息
          ///</summary>
          [NonSerialized]
          public static string FieldMessage = "MESSAGE";

          ///<summary>
          /// 字符串表示形式
          ///</summary>
          [NonSerialized]
          public static string FieldFormattedMessage = "FORMATTEDMESSAGE";

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
      }
}
