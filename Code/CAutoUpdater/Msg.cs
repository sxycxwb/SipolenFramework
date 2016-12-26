using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CAutoUpdater
{
  public class Msg
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool EndDialog(IntPtr hDlg, out IntPtr nResult);

        public static void DisplayMsg(string sMsg, string sCaption, int timeout = 0)
        {
            //XtraMessageBox.Show(sMsg, sCaption);
            ThreadPool.QueueUserWorkItem(new WaitCallback(CloseMessageBox), new CloseState(sCaption, (timeout < 1000) ? 1000 : timeout)); // timeout,1000是毫秒
            sMsg = sMsg.Replace("!", "").Replace("！", "") + "!";
            MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void CloseMessageBox(object state)
        {
            CloseState closeState = state as CloseState;
            Thread.Sleep(closeState.Timeout);
            IntPtr dlg = FindWindow(null, closeState.Caption);

            if (dlg != IntPtr.Zero)
            {
                IntPtr result;
                EndDialog(dlg, out result);
            }
        }
    }
}