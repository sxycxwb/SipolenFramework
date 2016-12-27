/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-19 17:04:32
 ******************************************************************************/

namespace RDIFramework.WinForm.Utilities
{
    /// <summary>
    /// 主窗口的接口
    /// </summary>
    public interface IBaseMainForm
    {
        /// <summary>
        /// 初始化窗体
        /// </summary>
        void InitForm();

        /// <summary>
        /// 初始化服务
        /// </summary>
        void InitService();

        /// <summary>
        /// 检查菜单
        /// </summary>
        void CheckMenu();
    }
}
