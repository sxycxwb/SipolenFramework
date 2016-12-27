//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------


namespace RDIFramework.Utilities
{
    #region public enum MessageFunction 消息功能分类
    /// <summary>
    /// 消息功能分类
    /// </summary>
    public enum MessageFunction
    {
        Message = 0,         // 0 消息。
        Remind = 1,          // 1 提示。
        Warning = 2,         // 2 警示。
        WaitForAudit = 3,    // 3 待审核事项。
        Comment = 4,         // 4 评论。
        TodoList = 5,        // 5 待审核。
        Note = 6,            // 6 备忘录。
        UserMessage = 7,     //用户信息
        RoleMessage = 8,     //角色信息
        OrganizeMessage = 9, //组织机构信息
        SystemPush = 10      //系统推送
    }
    #endregion
}