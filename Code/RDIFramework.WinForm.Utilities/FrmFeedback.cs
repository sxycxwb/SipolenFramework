/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-7 14:36:16
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmFeedback
    /// 意见反馈
    /// 
    /// 修改记录
    ///     2012-06-07 XuWangBin 创建FrmFeedback
    /// </summary>
    public partial class FrmFeedback :BaseForm
    {
        public FrmFeedback()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            txtContractInfo.Focus();

        }

        private bool InputValidate()
        {
            if (txtContractInfo.Text.Trim().Length <= 0)
            {
                MessageBoxHelper.ShowWarningMsg("请留下你的联系方式(邮箱、电话等)，以便我们及时回复你。");
                lblContractHint.ForeColor = Color.Peru;
                txtContractInfo.Focus();
                return false;
            }

            string body = htmlEditorEmailContent.XMailMessage.Body.Trim().ToUpper();           
            body = body.Substring(body.IndexOf("<BODY>") + 6, body.IndexOf("</BODY>") - (body.IndexOf("<BODY>") + 6));
            if (body.Length <= 0)
            {
                htmlEditorEmailContent.Focus();
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0240);
                return false;
            }

            return true;
        }

        #region private void SendFaceback()：发送反馈信息
        /// <summary>
        /// 发送反馈信息
        /// </summary>
        private void SendFaceback()
        {
            /*
            MailMessage mail = new MailMessage();  
            mail.From = new MailAddress("发件人邮箱");  
            mail.To.Add(new MailAddress("收件人邮箱")); 
            mail.Subject = "标题字符串";  
            mail.Body = "内容字符串"; 
            mail.Attachments.Add(new Attachment(@"附件地址")); 
            SmtpClient sc = new SmtpClient("Smtp服务器地址或域名");
            sc.Credentials = new System.Net.NetworkCredential("发件人邮箱", "发件人密码"); 
            sc.Send(mail);
            sc.Dispose();
             * */

            MailAddress from = new MailAddress(SystemInfo.ErrorReportMailUserName);
            MailMessage newMailMessage = this.htmlEditorEmailContent.XMailMessage;
            newMailMessage.From = from;

            string[] ErrorReportTo = SystemInfo.ErrorReportFrom.Trim().Split(',', ';', ' ');
            // 收件箱
            for (int i = 0; i < ErrorReportTo.Length; i++)
            {
                if (ErrorReportTo[i].Trim().Length > 0)
                {
                    newMailMessage.To.Add(new MailAddress(ErrorReportTo[i].Trim(), SystemInfo.CustomerCompanyName + RDIFrameworkMessage.MSG0243));
                }
            }

            //newMailMessage.To.Add(new MailAddress(SystemInfo.ErrorReportFrom, SystemInfo.CustomerCompanyName + RDIFrameworkMessage.MSG0243));

            newMailMessage.Subject = txtContractInfo.Text.Trim() + "|RDIFramework.NET ━ 意见反馈。";
            //设置SMTP服务器地址 
            SmtpClient newclient = new SmtpClient(SystemInfo.ErrorReportMailServer);   //以126为例为：smtp:126.com
            newclient.UseDefaultCredentials = false;
            //此处设置发件人邮箱的用户名和密码 
            newclient.Credentials = new System.Net.NetworkCredential(SystemInfo.ErrorReportMailUserName, SystemInfo.ErrorReportMailPassword); //发件人的账号和密码
            newclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (txtAddAttachments.Text != "")
            {
                newMailMessage.Attachments.Add(new Attachment(txtAddAttachments.Text));          // 发送附件
            }
            newMailMessage.Priority = MailPriority.Normal;  //设置发送级别
          
            //发送邮件 
            newclient.Send(newMailMessage);
        }
        #endregion

        private void btnAddAttachments_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {Title = "添加附件"};
            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtAddAttachments.Text = openFileDialog.FileName;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (InputValidate())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                bool sendSuccess = true;
                string failInfo = string.Empty;
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    SplashForm.StartSplash();
                    this.SendFaceback();
                    // 是否需要有提示信息？
                    if (SystemInfo.ShowInformation)
                    {
                        this.SendToBack();
                        sendSuccess = true;
                    }

                    this.Close();

                }
                catch (System.Net.WebException webExcption)
                {
                    sendSuccess = false;
                    failInfo = webExcption.InnerException.Message;
                }
                catch (Exception ex)
                {
                    sendSuccess = false;
                    failInfo = ex.Message;
                }
                finally
                {
                    SplashForm.CloseSplash();
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;

                    if (sendSuccess)
                    {
                        MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0237);
                    }
                    else
                    {
                        MessageBoxHelper.ShowErrorMsg(RDIFrameworkMessage.MSG0241);
                    }
                }                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkTencentWeibo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://blog.rdiframework.net/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rdiframework.net/");
        }
    }
}
