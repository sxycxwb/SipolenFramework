using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmBroadcastMessage.cs
    /// 广播消息
    /// </summary>
    public partial class FrmBroadcastMessage : BaseForm
    {
        public FrmBroadcastMessage()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.lblSender.Text = this.UserInfo.UserName + @"（" + this.UserInfo.RealName + @"）";
            this.rtxtMSGContent.Focus();
        }

         public override bool CheckInput()
        {
            const bool returnValue = false;
            if (string.IsNullOrEmpty(this.rtxtMSGContent.Text))
            {
                return returnValue;
            }

            if(!string.IsNullOrEmpty(this.rtxtMSGContent.Text) && (this.rtxtMSGContent.Text.Trim().Length <10 || this.rtxtMSGContent.Text.Trim().Length > 500))
            {
                MessageBoxHelper.ShowWarningMsg("亲，信息内容长度应为10至500之间!");
                return returnValue;
            }
             return true;
        }

        private void BroadcastMessage()
        {
            try
            {
                int returnValue = 0;
                if (!string.IsNullOrEmpty(this.rtxtMSGContent.Text))
                {
                    returnValue = RDIFrameworkService.Instance.MessageService.Broadcast(this.UserInfo, this.rtxtMSGContent.Text);
                }

                if (returnValue > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg("发送成功！");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMsg("发送失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("发送失败，错误：" + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                rtxtMSGContent.Focus();
                return;
            }
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            BroadcastMessage();
            this.Cursor = holdCursor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
