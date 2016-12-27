/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-20 16:35:49
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
     /// <summary>
     /// CiMessageTable
     /// 消息表
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
     public partial class CiMessageTable
     {
          ///<summary>
          /// 消息表
          ///</summary>
          [NonSerialized]
          public static string TableName = "CIMESSAGE";

          ///<summary>
          /// 主键
          ///</summary>
          [NonSerialized]
          public static string FieldId = "ID";

          ///<summary>
          /// 父亲节点主键
          ///</summary>
          [NonSerialized]
          public static string FieldParentId = "PARENTID";

          ///<summary>
          /// 功能分类代码，Send发送、Receiver接收
          ///</summary>
          [NonSerialized]
          public static string FieldFunctionCode = "FUNCTIONCODE";

          ///<summary>
          /// 分类代码
          ///</summary>
          [NonSerialized]
          public static string FieldCategoryCode = "CATEGORYCODE";

          ///<summary>
          /// 唯一识别主键
          ///</summary>
          [NonSerialized]
          public static string FieldObjectId = "OBJECTID";

          ///<summary>
          /// 主题
          ///</summary>
          [NonSerialized]
          public static string FieldTitle = "TITLE";

          ///<summary>
          /// 内容
          ///</summary>
          [NonSerialized]
          public static string FieldMSGContent = "MSGCONTENT";

          ///<summary>
          /// 接收者主键
          ///</summary>
          [NonSerialized]
          public static string FieldReceiverId = "RECEIVERID";

          ///<summary>
          /// 接收着姓名
          ///</summary>
          [NonSerialized]
          public static string FieldReceiverRealName = "RECEIVERREALNAME";

          ///<summary>
          /// 是否新信息
          ///</summary>
          [NonSerialized]
          public static string FieldIsNew = "ISNEW";

          ///<summary>
          /// 被阅读次数
          ///</summary>
          [NonSerialized]
          public static string FieldReadCount = "READCOUNT";

          ///<summary>
          /// 阅读日期
          ///</summary>
          [NonSerialized]
          public static string FieldReadDate = "READDATE";

          ///<summary>
          /// 消息的指向网页页面
          ///</summary>
          [NonSerialized]
          public static string FieldTargetURL = "TARGETURL";

          ///<summary>
          /// IP地址
          ///</summary>
          [NonSerialized]
          public static string FieldIPAddress = "IPADDRESS";

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
