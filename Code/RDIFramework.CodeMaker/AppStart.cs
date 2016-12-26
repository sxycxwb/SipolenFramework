using System;
using System.Windows.Forms;
using System.Threading;

namespace RDIFramework.CodeMaker
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
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                 var app = new MainForm();
                //FrmTestForm app = new FrmTestForm();
                //Application.Run(app);
                 if (app.mutex != null)
                 {
                     Application.Run(app);
                 }
                 else
                 {
                     MessageBox.Show(app, "程序已经在运行中！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"错误信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //Application.Run(new FrmTestForm());
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
                var result = ShowThreadExceptionDialog(e.Exception);
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
            var errorMessage = "错误信息：\n\n" +
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
