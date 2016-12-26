using System;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// PiTablePermissionScopeTable
    /// 表数据范围权限
    /// 
    /// 修改纪录
    /// 
    /// 2013-03-08 版本：1.0 EricHu 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>EricHu</name>
    /// <date>2013-03-08</date>
    /// </author>
    /// </summary>
    public partial class PiTablePermissionScopeTable
    {
        ///<summary>
        /// 表数据范围权限
        ///</summary>
        [NonSerialized]
        public static string TableName = "PITABLEPERMISSIONSCOPE";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "ID";

        ///<summary>
        /// 表
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "PARENTID";

        ///<summary>
        /// 表名
        ///</summary>
        [NonSerialized]
        public static string FieldItemCode = "ITEMCODE";

        ///<summary>
        /// 表名
        ///</summary>
        [NonSerialized]
        public static string FieldItemName = "ITEMNAME";

        ///<summary>
        /// 表
        ///</summary>
        [NonSerialized]
        public static string FieldItemValue = "ITEMVALUE";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "ENABLED";

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
