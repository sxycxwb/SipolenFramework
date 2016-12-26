using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace RDIFramework.Test
{
    static class AppStart
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var handler = new ThreadExceptionHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(handler.Application_ThreadException);


            /*测试使用，到时删除
            DirectoryInfo folder = new DirectoryInfo(@"D:\Temp\modulePhoto");
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                //.icon-download{background:url('icon/download.png') no-repeat;}
                //<li title="/css/icon/accept.png"><span class="icon icon16_icon-accept">&nbsp;</span></li>
                //RDIFramework.Utilities.FileHelper.FileAdd(@"C:\iconNew16.css", "." + RDIFramework.Utilities.FileHelper.GetName(file.FullName) + "{background:url('../Images/Icon16/" + RDIFramework.Utilities.FileHelper.GetName(file.FullName) + file.Extension + "') no-repeat;}" + "|");
                RDIFramework.Utilities.FileHelper.FileAdd(@"C:\iconModuleList.css", @"<li title='" + "../Images/Icon16/" + RDIFramework.Utilities.FileHelper.GetName(file.FullName) + file.Extension + "'><span class='icon icon16_" +  RDIFramework.Utilities.FileHelper.GetName(file.FullName) + "'>&nbsp;</span></li>" + "|");
            }
             */
            Application.Run(new FrmTest());
        }
    }

    #region ThreadExceptionHandler 捕获未处理的异常
    /// 
    /// 捕获未处理的异常
    /// 
    internal class ThreadExceptionHandler
    {
        // Handles the thread exception. 
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                // Exit the program if the user clicks Abort.
                DialogResult result = ShowThreadExceptionDialog(e.Exception);
                if (result == DialogResult.Abort)
                    Application.Exit();
            }
            catch
            {
                try
                {
                    MessageBox.Show("严重错误", "严重错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /// 
        /// Creates and displays the error message.
        /// 
        private DialogResult ShowThreadExceptionDialog(Exception ex)
        {
            string errorMessage = "错误信息：\n\n" +
                ex.Message + "\n\n" + ex.GetType() +
                "\n\nStack Trace:\n" +
                ex.StackTrace;
            return MessageBox.Show(errorMessage,
                    "Application Error",
                    MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Stop);
        }
    }
    #endregion
}
