/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:57
 ******************************************************************************/
using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{    
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserPassword
    /// 用户密码设置窗口
    /// 
    /// 修改记录
    /// </summary>
    public partial class FrmUserPassword : BaseForm
    {
        string[] userIds = null;
        IUserService userService = RDIFrameworkService.Instance.UserService;

        public FrmUserPassword(string[]  userIdList)
        {
            InitializeComponent();

            if (userIdList == null)
            {
                MessageBoxHelper.ShowWarningMsg("温馨提示：无待修改的用户！");
                return;
            }

            userIds = userIdList;
        }

        #region private bool SetPassword()
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <returns>是否成功</returns>
        private bool SetPassword()
        {
            return SetPassword(this.txtNewPassword.Text);
        }
        #endregion

        #region private bool SetPassword(string newPassword)
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <returns>是否成功</returns>
        private bool SetPassword(string newPassword)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            RDIFrameworkService.Instance.LogOnService.SetPassword(UserInfo, userIds, newPassword, out statusCode, out statusMessage);
            // 设置为平常状态
            this.Cursor = holdCursor;
            if (statusCode == StatusCode.SetPasswordOK.ToString())
            {
                if (SystemInfo.ShowInformation)
                {
                    // 提示修改成功
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbDetail))
            {
                return;
            }
            else
            {
                if (!txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0231);
                    txtConfirmPassword.Focus();
                    return;
                }
            }

            if (MessageBoxHelper.Show("确认修改用户密码嘛?") == System.Windows.Forms.DialogResult.Yes)
            {
                // 更新用户的密码
                if (this.SetPassword())
                {
                    this.Close();
                }
            }
        }


        private void btnDeletePassword_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确认删除用户密码嘛?") != System.Windows.Forms.DialogResult.Yes) return;
            // 更新用户的密码
            if (this.SetPassword(null))
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //设置为系统默认密码
        private void btnSetDefaultPwd_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定设置为系统默认密码吗（是/否）?") != System.Windows.Forms.DialogResult.Yes) return;
            if (this.SetPassword(SystemInfo.DefaultPassword))
            {
                this.Close();
            }
        }
    }
}
