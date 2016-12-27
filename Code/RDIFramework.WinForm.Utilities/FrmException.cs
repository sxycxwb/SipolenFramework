//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmException
    /// 
    /// 修改纪录
    /// 
    ///     2007.08.20 版本：2.0 XuWangBin Instance 实例调用模式，加快运行速度。
    ///		2007.04.16 版本：1.0 XuWangBin 创建。
    ///		
    /// 版本：2.1
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2007.04.16</date>
    /// </author> 
    /// </summary>
    public partial class FrmException : BaseForm
    {
        /// <summary>
        /// 异常信息
        /// </summary>
        public CiExceptionEntity exceptionEntity = null;

        public FrmException()
        {
            InitializeComponent();
        }

        private CiExceptionEntity ConvertException(Exception ex)
        {
            exceptionEntity = new CiExceptionEntity();
            exceptionEntity.Message = ex.Message;
            exceptionEntity.FormattedMessage = ex.StackTrace;
            exceptionEntity.CreateOn = BusinessLogic.ConvertToNullableDateTime(System.DateTime.Now.ToString(SystemInfo.DateTimeFormat));
            exceptionEntity.CreateUserId = UserInfo.Id;
            exceptionEntity.CreateBy = UserInfo.RealName;
            return exceptionEntity;
        }

        public FrmException(CiExceptionEntity exceptionEntity)
            : this()
        {
            this.exceptionEntity = exceptionEntity;
        }

        public FrmException(Exception ex)
            : this()
        {
            this.exceptionEntity = this.ConvertException(ex);
        }

        public override void FormOnLoad()
        {
            this.ShowEntity();
        }
        
        #region public override void ShowEntity() 显示异常
        /// <summary>
        /// 显示异常
        /// </summary>
        public override void ShowEntity()
        {
            this.txtCustomer.Text = SystemInfo.CustomerCompanyName;
            this.txtSoft.Text = SystemInfo.SoftFullName;
            this.txtUser.Text = this.exceptionEntity.CreateBy;
            this.txtUser.Tag = this.exceptionEntity.CreateUserId;
            this.txtOccurTime.Text = this.exceptionEntity.CreateOn.ToString();
            this.txtException.Text = "Error Message：" + System.Environment.NewLine + 
                                    this.exceptionEntity.Message + System.Environment.NewLine
                                    + "StackTrace:" + System.Environment.NewLine + this.exceptionEntity.FormattedMessage;
        }
        #endregion

        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = this.txtException.Text;
            System.Drawing.Font printFont = new System.Drawing.Font("宋体", 30, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
        }

        private void Print()
        {
            PrintDialog printDialogException = new PrintDialog();
            DialogResult result = printDialogException.ShowDialog();
            PrintDocument docToPrint = new PrintDocument(); 
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            printDialogException.AllowSomePages = true; 
            printDialogException.ShowHelp = true;
            printDialogException.Document = docToPrint;
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        #region private void SendErrorReport() 发送错误报告
        /// <summary>
        /// 发送错误报告
        /// </summary>
        private void SendErrorReport()
        {
            MailAddress from = new MailAddress(SystemInfo.ErrorReportMailUserName);
            MailMessage newMailMessage = new MailMessage();
            newMailMessage.From = from;

            string[] ErrorReportFrom = SystemInfo.ErrorReportFrom.Split(',', ';', ' ');
            // 收件箱
            for (int i = 0; i < ErrorReportFrom.Length; i++)
            {
                if (ErrorReportFrom[i].Trim().Length > 0)
                {
                    newMailMessage.To.Add(new MailAddress(ErrorReportFrom[i].Trim(), SystemInfo.CustomerCompanyName + RDIFrameworkMessage.MSG0243));
                }
            }

            //newMailMessage.To.Add(new MailAddress(SystemInfo.ErrorReportFrom, SystemInfo.CustomerCompanyName + RDIFrameworkMessage.MSG0243));

            newMailMessage.Body = this.txtException.Text;
            newMailMessage.Subject = "Error From " + this.txtCustomer.Text + "(" + this.UserInfo.IPAddress + ")";
            //设置SMTP服务器地址 
            SmtpClient newclient = new SmtpClient(SystemInfo.ErrorReportMailServer);   //以126为例为：smtp:126.com
            newclient.UseDefaultCredentials = false;
            //此处设置发件人邮箱的用户名和密码 
            newclient.Credentials = new System.Net.NetworkCredential(SystemInfo.ErrorReportMailUserName, SystemInfo.ErrorReportMailPassword); //发件人的账号和密码
            newclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //if (txt附件.Text != "")
            //{
            //    newMailMessage.Attachments.Add(new Attachment(txt附件.Text));          // 发送附件
            //}
            newMailMessage.Priority = MailPriority.High;  //设置发送级别

            //发送邮件 
            newclient.Send(newMailMessage);
        }
        #endregion

        private void btnReport_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                SendErrorReport();                
                // 是否需要有提示信息？
                if (SystemInfo.ShowInformation)
                {
                    this.SendToBack();
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0237);                    
                }   
                this.Close();               
                         
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}