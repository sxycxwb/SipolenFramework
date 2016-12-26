/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:53
 ******************************************************************************/


using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// PiPlatFormAddInTable
    /// 平台插件表
    ///
    /// 修改纪录
    ///
    ///		2012-05-25 版本：1.0  创建PiPlatFormAddInTable。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-25</date>
    /// </author>
    /// </summary>
    public class PiPlatFormAddInTable
    {
        ///<summary>
        /// 平台插件
        ///</summary>
        [NonSerialized]
        public static string TableName = "PIPLATFORMADDIN";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 全局唯一标识符(GUID)
        ///</summary>
        [NonSerialized]
        public static string FieldGuid = "GUID";

        ///<summary>
        /// 插件的名称（要做到所见即所得）。
        ///</summary>
        [NonSerialized]
        public static string FieldName = "NAME";

        ///<summary>
        /// dll文件、exe文件等的程序集名称。
        ///</summary>
        [NonSerialized]
        public static string FieldAssemblyName = "ASSEMBLYNAME";

        ///<summary>
        /// 一般为类的全名(带命名空间)。
        ///</summary>
        [NonSerialized]
        public static string FieldClassName = "CLASSNAME";

        ///<summary>
        /// 插件
        ///</summary>
        [NonSerialized]
        public static string FieldAddIn = "ADDIN";

        ///<summary>
        /// 插件所占的空间大小（以KB为单位）。
        ///</summary>
        [NonSerialized]
        public static string FieldAddInSize = "ADDINSIZE";

        ///<summary>
        /// 版本信息
        ///</summary>
        [NonSerialized]
        public static string FieldVersion = "VERSION";

        ///<summary>
        /// 插件的开发人员（多个以逗号隔开）。
        ///</summary>
        [NonSerialized]
        public static string FieldDeveloper = "DEVELOPER";

        ///<summary>
        /// 下载次数
        ///</summary>
        [NonSerialized]
        public static string FieldDownLoadCount = "DOWNLOADCOUNT";

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
        /// 插件的描述信息。
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
