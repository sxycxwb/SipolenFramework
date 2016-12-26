/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:47
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// CiFileTable
    /// 文件表
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
    public partial class CiFileTable
    {
        ///<summary>
        /// 文件表
        ///</summary>
        [NonSerialized]
        public static string TableName = "CIFILE";

        ///<summary>
        /// 代码
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 文件夹节点代码
        ///</summary>
        [NonSerialized]
        public static string FieldFolderId = "FOLDERID";

        ///<summary>
        /// 文件名
        ///</summary>
        [NonSerialized]
        public static string FieldFileName = "FILENAME";

        ///<summary>
        /// 文件路径
        ///</summary>
        [NonSerialized]
        public static string FieldFilePath = "FILEPATH";

        ///<summary>
        /// 文件内容
        ///</summary>
        [NonSerialized]
        public static string FieldFileContent = "FILECONTENT";

        ///<summary>
        /// 文件大小
        ///</summary>
        [NonSerialized]
        public static string FieldFileSize = "FILESIZE";

        ///<summary>
        /// 图片文件位置
        ///</summary>
        [NonSerialized]
        public static string FieldImageUrl = "IMAGEURL";

        ///<summary>
        /// 被阅读次数
        ///</summary>
        [NonSerialized]
        public static string FieldReadCount = "READCOUNT";

        ///<summary>
        /// 文件类别
        ///</summary>
        [NonSerialized]
        public static string FieldCategory = "CATEGORY";

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

        /// <summary>
        /// 删除标志
        /// </summary>
         [NonSerialized]
        public static string FieldDeleteMark = "DELETEMARK";

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
