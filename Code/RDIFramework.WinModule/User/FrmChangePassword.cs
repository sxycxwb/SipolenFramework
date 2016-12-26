/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-8 10:54:17
 ******************************************************************************/
using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmChangePassword
    /// 修改用户密码
    /// 
    /// 修改记录   
    ///     2012-06-08 EricHu 新增FrmChangePassword
    /// </summary>
    public partial class FrmChangePassword : BaseForm
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.gbDetail.Text = "当前用户[" + UserInfo.RealName + "(" + UserInfo.UserName + ")]";
        }

        private bool CheckInputValidate()
        {
            if (!this.txtOriginalPassword.Text.Trim().Equals(SecretHelper.AESDecrypt(UserInfo.Password.Trim())))
            {
                MessageBoxHelper.ShowErrorMsg(RDIFrameworkMessage.MSG9967);
                txtOriginalPassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNewPassword.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("新密码不能为空！");
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("确认密码不能为空！");
                txtConfirmPassword.Focus();
                return false;
            }

            if (!txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("新密码与确认密码不一至！");
                txtConfirmPassword.Focus();
                return false;
            }

            return true;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!CheckInputValidate()) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                RDIFrameworkService.Instance.LogOnService.ChangePassword(this.UserInfo, txtOriginalPassword.Text.Trim(), txtNewPassword.Text.Trim(), out statusCode, out statusMessage);
                // 设置为平常状态
                this.Cursor = holdCursor;
                if (statusCode == StatusCode.ChangePasswordOK.ToString())
                {
                    if (SystemInfo.ShowInformation)
                    {
                        // 提示修改成功
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
                        this.Close();
                    }
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                }

            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
