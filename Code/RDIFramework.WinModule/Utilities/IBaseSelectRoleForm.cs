/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-4 11:10:15
 ******************************************************************************/

namespace RDIFramework.WinModule
{
    /// <summary>
    /// IBaseRoleSelect
    /// 选择角色窗体
    /// 
    /// 修改纪录
    ///
    ///		2012-5-4 版本：1.0 EricHu 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-5-4</date>
    /// </author> 
    /// </summary>
    public interface IBaseSelectRoleForm
    {
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        string[] RemoveIds { get; set; }

        /// <summary>
        /// 只显示角色
        /// </summary>
        bool ShowRoleOnly { get; set; }

        /// <summary>
        /// 是否允许选择空
        /// </summary>
        bool AllowNull { get; set; }

        /// <summary>
        /// 是否允许选择
        /// </summary>
        bool AllowSelect { get; set; }

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        bool MultiSelect { get; set; }

        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        string PermissionItemScopeCode { get; set; }

        /// <summary>
        /// 被选中的角色主键
        /// </summary>
        string SelectedId { get; set; }

        /// <summary>
        /// 被选中的角色全名
        /// </summary>
        string SelectedFullName { get; set; }

        /// <summary>
        /// 打开节点
        /// </summary>
        string OpenId { get; set; }

        /// <summary>
        /// 被选中的主键数组
        /// </summary>
        string[] SelectedIds { get; set; }
    }
}
