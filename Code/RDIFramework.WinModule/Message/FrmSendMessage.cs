using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSendMessage.cs
    /// 发送消息
    /// 
    /// </summary>
    public partial class FrmSendMessage : BaseForm
    {
        public FrmSendMessage()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.lblSender.Text = this.UserInfo.UserName + @"（" + this.UserInfo.RealName + @"）";
            this.txtTitle.Focus();
        }

        public override bool CheckInput()
        {
            const bool returnValue = false;
            if (string.IsNullOrEmpty(this.txtTitle.Text) || this.txtUserIdList.SelectedIds == null || this.txtUserIdList.SelectedIds.Length <= 0 || string.IsNullOrEmpty(this.rtxtMSGContent.Text))
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

        private void SendMessage()
        {
            try
            {
                var messageEntity = new CiMessageEntity
                {
                    Title = this.txtTitle.Text.Trim(),
                    MSGContent = this.rtxtMSGContent.Text.Trim(),
                    FunctionCode = MessageFunction.UserMessage.ToDescription()
                };

                int returnValue = RDIFrameworkService.Instance.MessageService.BatchSend(this.UserInfo, this.txtUserIdList.SelectedIds, null, null, messageEntity);
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
                MessageBoxHelper.ShowWarningMsg("请检测必输项！");
                txtUserIdList.Focus();
                return;
            }
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            SendMessage();
            this.Cursor = holdCursor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
