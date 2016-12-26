/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-16 12:58:57
 ******************************************************************************/
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{

    /// <summary>
    /// MessageBoxHelper
    /// 通用对话框显示类【Devexpress风格】
    /// </summary>
    public class MessageBoxHelper
    {
        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="strErrMsg">显示内容</param>
        public static void ShowErrorMsg(string strErrMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strErrMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示成功信息
        /// </summary>
        /// <param name="strSuccessMsg">显示内容</param>
        public static void ShowSuccessMsg(string strSuccessMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strSuccessMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="strWarningMsg">显示内容</param>
        public static void ShowWarningMsg(string strWarningMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strWarningMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示询问信息
        /// </summary>
        /// <param name="strQuestionMsg">显示内容</param>
        public static void ShowQuestionMsg(string strQuestionMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strQuestionMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示常规信息
        /// </summary>
        /// <param name="strQuestionMsg">显示内容</param>
        public static void ShowInformationMsg(string strQuestionMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strQuestionMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示严重错误信息
        /// </summary>
        /// <param name="strStopMsg">显示内容</param>
        public static void ShowStopMsg(string strStopMsg)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(strStopMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// 显示询问信息并返回DialogResult的结果
        /// </summary>
        /// <param name="strQuestionMsg">显示内容，如：你确定要删除吗？（是/否）</param>
        /// <returns>DialogResult【DialogResult.Yes 或 DialogResult.No】</returns>
        public static DialogResult Show(string strQuestionMsg)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(strQuestionMsg, RDIFramework.Utilities.RDIFrameworkMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return DialogResult.Yes;
            }
            else
            {
                return DialogResult.No;
            }
        }
    }
}
