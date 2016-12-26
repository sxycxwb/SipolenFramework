//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------
using System.Windows.Forms;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 通用对话框显示类
    /// 
    /// 修改纪录
    ///     2008-08-05 EricHu 增加"得到用户选择的结果:DialogResult ShowDlgReturnResult(string strMsg)"
    ///     2008-05-20 EricHu 创建通用对话框显示类
    ///     
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>80368704</QQ>
    ///     <Email>80368704@qq.com</Email>
    /// </author>
    /// </summary>
    public abstract class DialogHelper
    {
        /// <summary>
        /// 数据为空
        /// </summary>
        public static string DATA_ISNULL =
            "数据为空，请检查你的操作数据是否正确？";


        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="strMsg">显示内容</param>
        public static void ShowErrorMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示成功信息
        /// </summary>
        /// <param name="strMsg">显示内容</param>
        public static void ShowSuccessMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "成功提示", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="strMsg">显示内容</param>
        public static void ShowWarningMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示询问信息
        /// </summary>
        /// <param name="strMsg">显示内容</param>
        public static void ShowQuestionMsg(string strMsg)
        {
            MessageBox.Show(strMsg, "询问提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示询问信息并返回DialogResult的结果
        /// </summary>
        /// <param name="strMsg">显示内容，如：你确定要删除吗？（是/否）</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowDlgReturnResult(string strMsg)
        {
            if (MessageBox.Show(strMsg, "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
