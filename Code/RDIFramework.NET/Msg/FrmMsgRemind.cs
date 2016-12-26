using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmMsgRemind
    /// 消息提醒
    /// 
    /// 
    /// </summary>
    public partial class FrmMsgRemind : BaseForm
    {
        public FrmMsgRemind()
        {
            InitializeComponent();
        }

        // 声明FlashWindow()
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(
             IntPtr hWnd,           //   handle  to  window   
             bool bInvert           //   flash  status   
         );

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.StartPosition = FormStartPosition.Manual;

            Rectangle bounds = Screen.FromControl(this).WorkingArea;
            this.Location = new Point(bounds.Width - this.Width, bounds.Height - this.Height);
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        // 播放音乐
        [DllImport("winmm.dll")]
        // 播放windows音乐，重载
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;

        string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Resources\\Media\\msg.wav";

        private void PlaySound()
        {
            PlaySound(filePath, 0, SND_ASYNC | SND_FILENAME);
        }

        // 防止线程阻塞的写法
        private delegate bool SetMessage(CiMessageEntity message);

        public bool OnReceiveMessage(string message, string createOn = null)
        {
            if (createOn == null)
            {
                createOn = DateTime.Now.ToString(SystemInfo.DateTimeFormat);
            }
            this.txtMsgContent.AppendText(createOn + " : " + "\r\n");
            this.txtMsgContent.AppendText(message + "\r\n");
            this.txtMsgContent.AppendText("- - - - - - - - - - - - - - -" + "\r\n");
            this.txtMsgContent.ScrollToCaret();
            this.PlaySound();
            FlashWindow(this.Handle, true);
            return true;
        }

        public bool OnReceiveMessage(CiMessageEntity messageEntity)
        {
            bool returnValue = false;
            if (this.InvokeRequired)
            {
                SetMessage SetMessage = new SetMessage(OnReceiveMessage);
                this.Invoke(SetMessage, new object[] { messageEntity });
            }
            else
            {
                OnReceiveMessage(messageEntity.MSGContent, ((DateTime)messageEntity.CreateOn).ToString(SystemInfo.DateTimeFormat));
                returnValue = true;
            }
            return returnValue;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            /*
            if (this.FromUserId.Length == 0)
            {
                this.btnReply.Enabled = false;
            }
            else
            {
                this.btnReply.Enabled = true;
            }
            */
        }
        #endregion

        private void btnReply_Click(object sender, EventArgs e)
        {
            /*
            if (this.FromUserId.Length > 0)
            {
                this.Hide();
                ((FrmMsg)this.Owner).ShowMessageRead(this.FromUserId, this.FromUserFullName, this.Owner);
                this.Close();
            }
            */
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
