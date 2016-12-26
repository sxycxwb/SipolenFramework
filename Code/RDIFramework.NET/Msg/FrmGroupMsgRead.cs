using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmGroupMsgRead : BaseForm
    {
        private string pictureId = string.Empty;
        public string PictureId
        {
            get
            {
                return this.pictureId;
            }
            set
            {
                this.pictureId = value;
                this.ShowPicture();
            }
        }

        // 声明FlashWindow()
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(
         IntPtr hWnd,           //   handle   to   window   
         bool bInvert       //   flash   status   
         );

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public bool FromDatabase = true;

        public FrmMsg FrmMsgOwner = null;

        /// <summary>
        /// 发送给谁的主键
        /// </summary>
        public string ReceiverId = string.Empty;

        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string OrganizeId = string.Empty;

        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId = string.Empty;

        // 防止线程阻塞的写法
        private delegate bool SetMessage(CiMessageEntity messageEntity);

        // 聊天内容（带样式）字符串
        public StringBuilder OneShow = new StringBuilder();

        public FrmGroupMsgRead()
        {
            InitializeComponent();
        }

        public FrmGroupMsgRead(string receiverId, string organizeId, string roleId)
            : this()
        {
            this.ReceiverId = receiverId;
            this.OrganizeId = organizeId;
            this.RoleId = roleId;
        }

        private string ReplaceMessage(string contents)
        {
            string webHostUrl = string.Empty;
            contents = contents.Replace("{OpenId}", this.UserInfo.OpenId);
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl1"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl1}", webHostUrl);
            }
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl2"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl2}", webHostUrl);
            }
            webHostUrl = ConfigurationManager.AppSettings["WebHostUrl"];
            if (!string.IsNullOrEmpty(webHostUrl))
            {
                contents = contents.Replace("{WebHostUrl}", webHostUrl);
            }
            return contents;
        }

        public bool OnReceiveMessage(CiMessageEntity messageEntity)
        {
            bool returnValue = false;
            returnValue = true;
            if (this.InvokeRequired)
            {
                SetMessage SetMessage = new SetMessage(OnReceiveMessage);
                this.Invoke(SetMessage, new object[] { messageEntity });
            }
            else
            {
                messageEntity.MSGContent = ReplaceMessage(messageEntity.MSGContent);

                StringBuilder sbContent = new StringBuilder();
                sbContent.Append("<div style='color:#00f;font-size:12px;'>" + messageEntity.CreateBy + " [");
                if (isToday((DateTime)messageEntity.CreateOn))
                {
                    sbContent.Append(((DateTime)messageEntity.CreateOn).ToLongTimeString() + "]：</div>");
                }
                else
                {
                    sbContent.Append(((DateTime)messageEntity.CreateOn).ToString(SystemInfo.DateTimeFormat) + "]：</div>");
                }
                sbContent.Append(messageEntity.MSGContent);
                OneShow.Append(sbContent.ToString());
                this.webMsg.DocumentText = this.webMsg.DocumentText.Insert(this.webMsg.DocumentText.Length, GetHtmlFace(sbContent.ToString()));
                this.PlaySound();

                FlashWindow(this.Handle, true);
            }

            return returnValue;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (!this.ReceiverId.Equals(this.UserInfo.Id))
            {
                this.btnSend.Enabled = ((!string.IsNullOrEmpty(this.ReceiverId) || !string.IsNullOrEmpty(this.OrganizeId) || !string.IsNullOrEmpty(this.RoleId)) && (this.txtMsgContent.Text.Length > 0));
            }
        }
        #endregion

        private void txtMsgContent_OnRichTextBoxTextChanged(object sender, EventArgs e)
        {
            // 设置按钮状态
            this.SetControlState();
        }
       
        #region private void SendMessage() 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendMessage()
        {
            this.btnSend.Enabled = false;
            StringBuilder sbmy = new StringBuilder();
            // 不是发给自己的消息
            if (!UserInfo.Id.Equals(this.ReceiverId))
            {
                // 设置信息样式
                string sendName = "<div style='color:#00f;font-size:12px;margin:2px;padding:0px'>" + UserInfo.RealName + "(" + UserInfo.DepartmentName + ") [" + DateTime.Now.ToLongTimeString() + "]:</div>";
                sbmy.Append("<div style='margin:2px;padding:0px 0px 0px 15px;" +
                    "font-family:" + txtMsgContent.Font.FontFamily.Name + ";" +
                    "font-size:" +
                    txtMsgContent.Font.Size + "pt;color:#" +
                    txtMsgContent.ForeColor.R.ToString("X2") +
                    txtMsgContent.ForeColor.G.ToString("X2") +
                    txtMsgContent.ForeColor.B.ToString("X2"));
                sbmy.Append(";font-weight:");
                sbmy.Append(txtMsgContent.Font.Bold ? "bold" : "");
                sbmy.Append(";font-style:");
                sbmy.Append(txtMsgContent.Font.Italic ? "italic" : "");
                sbmy.Append(";'>");
                sbmy.Append(GetHtmlHref(this.txtMsgContent.Text) + "</div>");

                this.webMsg.DocumentText = this.webMsg.DocumentText.Insert(this.webMsg.DocumentText.Length, sendName + GetHtmlFace(sbmy.ToString()));
            }
            RDIFrameworkService serviceInstance = new RDIFrameworkService();
            serviceInstance.MessageService.SendGroupMessage(UserInfo, this.OrganizeId, this.RoleId, sbmy.ToString());
            if (serviceInstance.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)serviceInstance.MessageService).Close();
            }
            this.txtMsgContent.Text = "";
            this.txtMsgContent.Focus();
        }
        #endregion

        private void FrmMsgRead_Load(object sender, EventArgs e)
        {
            //this.webMsg.Navigate("about:blank");
            this.webMsg.DocumentText = @"<body style=""margin: 3px;font-family:宋体"" onload=""scrollBy(0,document.body.scrollHeight)"">" +
               @"<script language=""javascript"" type=""text/javascript"">document.oncontextmenu=new Function(""event.returnValue=false;""); </script>"; //屏蔽右键

            if (!string.IsNullOrEmpty(this.OrganizeId))
            {
                this.Text = RDIFrameworkService.Instance.OrganizeService.GetEntity(this.UserInfo, this.OrganizeId).FullName;
            }

            if (!string.IsNullOrEmpty(this.RoleId))
            {
                this.Text = RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, this.RoleId).RealName;
            }
        }

        private string GetHtmlHref(string html)
        {
            Regex regex = new Regex(@"(http:\/\/([\w.]+\/?)\S*) ", RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled);
            html = regex.Replace(html, "<a href=\"$1\" target=\"_blank\">$1</a>");
            return html;
        }

        // 表情图标字符串替换为html显示
        private string GetHtmlFace(string html)
        {
            Regex regex = new Regex(@"\{\[(\d+)\]\}", RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled);
            html = regex.Replace(html, "<img src=\"" + Application.StartupPath + "\\Face\\Face_" + "$1" + ".gif\" style=\"vertical-align:middle;\" />");
            return html;
        }
       

        // 弹出显示加载不成功时重新加载一次
        private void webBMsg_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webMsg.DocumentText == "<HTML></HTML>\0")
            {
                this.webMsg.DocumentText = @"<body style=""margin: 3px;font-family:宋体"" onload=""scrollBy(0,document.body.scrollHeight)"">" +
                   @"<script language=""javascript"" type=""text/javascript"">document.oncontextmenu=new Function(""event.returnValue=false;""); </script>" +  //屏蔽右键
                   GetHtmlFace(OneShow.ToString()); //屏蔽右键
            }
        }

        // 检查日期是否今天 
        public static bool isToday(DateTime dt)
        {
            DateTime today = DateTime.Today;
            DateTime tempToday = new DateTime(dt.Year, dt.Month, dt.Day);
            if (today == tempToday)
                return true;
            else
                return false;
        }

        // 播放音乐
        [DllImport("winmm.dll")]
        // 播放windows音乐，重载
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;

        string filePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Resources\\Media\\msg.wav";

        void PlaySound()
        {
            PlaySound(filePath, 0, SND_ASYNC | SND_FILENAME);
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        public void ShowPicture()
        {
            if (!String.IsNullOrEmpty(this.PictureId))
            {
                // 显示图片
                this.ShowPicture(this.PictureId);
            }
            else
            {
                // 清除图片
                this.ClearPicture();
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="id">主键</param>
        private void ShowPicture(string id)
        {
            if (!this.FromDatabase)
            {
                this.pic.ImageLocation = SystemInfo.StartupPath + id;
            }
            else
            {
                byte[] fileContent = null;
                fileContent = this.Download(id);
                if (fileContent != null)
                {
                    MemoryStream memoryStream = new MemoryStream(fileContent);
                    Bitmap bitmap = new Bitmap(memoryStream);
                    this.pic.Image = bitmap;
                }
                else
                {
                    this.PictureId = string.Empty;
                    this.ClearPicture();
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }

        /// <summary>
        /// 清除图片
        /// </summary>
        private void ClearPicture()
        {
            this.pic.ImageLocation = string.Empty;
            this.pic.Image = null;
        }

        /// <summary>
        /// 从数据库中读取文件
        /// </summary>
        /// <param name="id">文件主键</param>
        /// <returns>文件</returns>
        public byte[] Download(string id)
        {
            RDIFrameworkService serviceInstance = new RDIFrameworkService();
            byte[] returnValue = serviceInstance.FileService.Download(UserInfo, id);
            if (serviceInstance.FileService is ICommunicationObject)
            {
                ((ICommunicationObject)serviceInstance.FileService).Close();
            }
            return returnValue;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 发送消息
            this.SendMessage();
        }

        private void FrmMsgRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
