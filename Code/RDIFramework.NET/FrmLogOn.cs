using System;
using System.Reflection;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmLogOn.cs
    /// 系统登录界面
    /// 
    /// 修改记录：
    ///     王进   V2.8 2014-12-28 修正登录界面，点击“取消”登录按钮，不能退回的问题。
    ///     EricHu v2.8 2014-06-19 修改了开户密码强度检查，用户登录时提示用户修改密码的异常问题；修改30天更换一次密码的逻辑错误。
    ///     EricHu v2.8 2014-06-18 修改登录界面用户按“回车键”进行登录，界面存在卡死的情况。
    /// 
    /// </summary>
    public partial class FrmLogOn : BaseForm
    {
        /// <summary>
        /// 已登录次数
        /// </summary>
        private int LogOnCount = 0;

        public FrmLogOn()
        {
            InitializeComponent();
        }

        #region public override void SetHelp() 设置帮助
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;

            // 修改成窗体显示软件名称+版本号
            Assembly assembly = Assembly.Load(SystemInfo.MainAssembly);
            //程序集名
            this.Text = SystemInfo.SoftFullName + " V" + assembly.GetName().Version.ToString();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (SystemInfo.LogOned)
            {
                this.Text = RDIFrameworkMessage.MSGReLogOn;
            }
            // 是否允许申请账户
            //this.btnRequestAnAccount.Visible = SystemInfo.AllowUserToRegister;
            // 密码强度检查
            //this.labPasswordReq.Visible = SystemInfo.EnableCheckPasswordStrength;
            // 已登录了？还是未登录状态
            if (SystemInfo.LogOned)
            {
                //this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnExit.Hide();
            }
            else
            {
                //this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnExit.Hide();
            }
        }
        #endregion

        #region private void GetLogOnInfo() 获取现有的登录信息
        /// <summary>
        /// 获取现有的登录信息
        /// </summary>
        private void GetLogOnInfo()
        {
            if (this.chkRememberPassword.Checked)
            {
                this.txtUserName.Text = SystemInfo.CurrentUserName;

                // 对密码进行解密操作
                string password = SystemInfo.CurrentPassword;
                if (SystemInfo.EncryptClientPassword)
                {
                    password = SecretHelper.AESDecrypt(password);
                }
                this.txtPassword.Text = password;

                // 写入注册表信息，这个往往是会遇到安全问题，出现异常等
                /*
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + SystemInfo.SoftName, false);
                if (registryKey != null)
                {
                    // 这里是保存用户名的读取，对用户名进行解密操作
                    string userName = (string)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                    userName = SecretUtil.Decrypt(userName);
                    DataRowView dataRowView = null;
                    for (int i = 0; i < this.cmbUser.Items.Count; i++)
                    {
                        dataRowView = (DataRowView)this.cmbUser.Items[i];
                        if (dataRowView[BaseUserEntity.FieldUserName].ToString().Equals(userName))
                        {
                            this.cmbUser.SelectedIndex = i;
                            // this.cmbUser.SelectedItem = this.cmbUser.Items[i];
                            // this.cmbUser.SelectedValue = userName;
                            break;
                        }
                    }
                    // 对密码进行解密操作
                    string password = (string)registryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    password = SecretUtil.Decrypt(password);
                    this.txtPassword.Text = password;
                }
                */
            }
            //this.chbAutoLogOn.Checked = SystemInfo.AutoLogOn;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 这里是按员工登录
            // this.DTUser = RDIFrameworkService.Instance.LogOnService.GetStaffDT(UserInfo);
            // 这里是按用户登录
            // this.DTUser = RDIFrameworkService.Instance.LogOnService.GetUserDT(UserInfo);

            // 员工需要按用户名排序问题解决
            // this.DTUser.DefaultView.Sort = BaseUserEntity.FieldSortCode;
            // 解决用户名密码记不住的问题
            // foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            // {
            //     this.cmbUser.Items.Add(dataRowView[BaseUserEntity.FieldUserName].ToString(//));
            // }
            // 显示用户真实姓名，保存用户名
            // this.txtUserName.DataSource = this.DTUser.DefaultView;
            // this.txtUserName.DisplayMember = BaseUserEntity.FieldRealName;
            // this.txtUserName.ValueMember = BaseUserEntity.FieldUserName;

            // 保存密码
            this.HelpButton = false;
            this.chkRememberPassword.Checked = SystemInfo.RememberPassword;
            // 获取现有的登录信息
            this.GetLogOnInfo();
            // 默认焦点在用户名输入上
            this.txtUserName.Focus();

            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.txtUserName.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 是否没有输入用户名
            if (this.txtUserName.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9957));
                this.txtUserName.Focus();
                return false;
            }
            // 密码强度检查
            if (SystemInfo.EnableCheckPasswordStrength && this.txtPassword.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007,
                    RDIFrameworkMessage.MSG9964));
                this.txtPassword.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region private bool CheckAllowLogOnCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        /// <returns>继续允许输入</returns>
        private bool CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= SystemInfo.PasswordErrorLockLimit)
            {
                // 控件重新设置状态
                this.txtPassword.Text = string.Empty;
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                // 进行提示信息，不能再输入了，已经错误N次了。
                MessageBoxHelper.ShowErrorMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0211, SystemInfo.PasswordErrorLockLimit.ToString()));
                return false;
            }
            return true;
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 已经登录次数 ++
            this.LogOnCount++;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                string userName = this.txtUserName.Text;
                var rdiFrameworkService = new RDIFrameworkService();
                
                var userInfo = rdiFrameworkService.LogOnService.UserLogOn(UserInfo, userName, this.txtPassword.Text,UserInfo.OpenId, true, out statusCode, out statusMessage);
                this.CloseCommunicationObject(rdiFrameworkService.LogOnService);
                if (statusCode == StatusCode.OK.ToString())
                {
                    // 检查身份
                    if ((userInfo != null) && (userInfo.Id.Length > 0))
                    {
                        // 用户登录，保存登录信息
                        SystemInfo.UserInfo = userInfo;
                        // 保存登录信息
                        this.SaveLogOnInfo(userInfo);
                        // 这里表示已经登录系统了
                        SystemInfo.LogOned = true;
                        // 这里是登录功能部分
                        if (this.Parent == null)
                        {
                            this.Hide();
                            Form mainForm = this.Owner;
                            // 这里不允许重复初始化服务
                             //((IBaseMainForm)mainForm).InitService();
                            ((IBaseMainForm)mainForm).InitForm();
                            ((IBaseMainForm)mainForm).CheckMenu();                          
                            mainForm.Show();
                        }
                        // 登录次数归零，允许重新登录
                        this.LogOnCount = 0;
                        // 密码强度检查
                        // 周期性更换密码要求,一个月更换一次密码,30天
                        if (SystemInfo.EnableCheckPasswordStrength)
                        {
                            bool chanagePassword = false;
                            string message = string.Empty;
                            PiUserLogOnEntity userLogOnEntity =RDIFrameworkService.Instance.LogOnService.GetEntity(UserInfo, userInfo.Id);

                            if (userLogOnEntity.ChangePasswordDate == null)
                            {
                                message = RDIFrameworkMessage.MSG0062;
                                chanagePassword = true;
                            }
                            else
                            {
                                TimeSpan ts = DateTime.Now.Subtract((DateTime)userLogOnEntity.ChangePasswordDate);
                                if (ts.TotalDays > 30)
                                {
                                    message = RDIFrameworkMessage.MSG0063;
                                    chanagePassword = true;
                                }
                            }

                            if (chanagePassword)
                            {
                                string assemblyName = "RDIFramework.WinModule";
                                string formName = "FrmChangePassword";
                                Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                                var frmUserChangePassword = (Form)Activator.CreateInstance(assemblyType);
                                frmUserChangePassword.ShowDialog(this);
                            }
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    System.Text.StringBuilder sbMessage = new System.Text.StringBuilder();
                    sbMessage.Append("用户验证过程中出现未知错误，请记录下面的异常信息，并通知您的\n系统管理员。\n");
                    sbMessage.Append("当前用户:“" + txtUserName.Text.Trim() + "”，信息：" + statusMessage);
                    sbMessage.Append("\n提示：密码是区分大小写的，请确定你是否因为疏忽而按下了“Caps Lock”键，该\n");
                    sbMessage.Append("键将会使你键入的任何字母自动转换为大写形式，从而可能导致您的密码不正确。\n");
                    sbMessage.Append("如果忘记了密码，请通知您的系统管理员，请他（她）帮助您解决这个问题。");
                    MessageBoxHelper.ShowWarningMsg(sbMessage.ToString());
                    this.txtPassword.Focus();
                    this.txtPassword.SelectAll();
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);               
                Application.ExitThread();
            }
            finally
            {
                // 已经忙完了
                this.Cursor = holdCursor;
            }
            return true;
        }
        #endregion

        #region private void SaveLogOnInfo(UserInfo userInfo) 将登录信息保存到XML文件中
        /// <summary>
        /// 将登录信息保存到XML文件中。
        /// 若不保存用户名密码，那就应该删除掉。
        /// </summary>
        /// <param name="userInfo">登录用户</param>
        private void SaveLogOnInfo(UserInfo userInfo)
        {
            SystemInfo.RememberPassword = this.chkRememberPassword.Checked;
            if (this.chkRememberPassword.Checked)
            {
                SystemInfo.CurrentUserName = userInfo.UserName;
                // SystemInfo.CurrentUserName = SecretHelper.AESEncrypt(userInfo.UserName);
                SystemInfo.CurrentPassword = SystemInfo.EncryptClientPassword ? SecretHelper.AESEncrypt(this.txtPassword.Text) : this.txtPassword.Text;
            }
            else
            {
                SystemInfo.CurrentUserName = string.Empty;
                SystemInfo.CurrentPassword = string.Empty;
            }

            //SystemInfo.AutoLogOn = this.chbAutoLogOn.Checked;

            // 保存用户的信息
            
            UserConfigHelper.SaveConfig();

            /*
            // 写入注册表，有时候会没有权限，发生异常信息等，可以考虑写入XML文件
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + SystemInfo.CompanyName + "\\" + SystemInfo.SoftName);
            if (this.chkRememberPassword.Checked)
            {
                // 默认的信息写入注册表,呵呵需要改进一下
                registryKey.SetValue(SystemInfo.CurrentUserName, SecretUtil.Encrypt(userInfo.UserName));
                registryKey.SetValue(SystemInfo.CurrentPassword, SecretUtil.Encrypt(this.txtPassword.Text));
            }
            else
            {
                registryKey.SetValue(SystemInfo.CurrentUserName, string.Empty);
                registryKey.SetValue(SystemInfo.CurrentPassword, string.Empty);
            }
            */
        }
        #endregion

        public override void Form_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) return;
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 用户登录
                this.LogOn();
            }
        }

        private void ConfirmLogOn()
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 用户登录
                this.LogOn();
                // 允许登录次数已经到了
                this.CheckAllowLogOnCount();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.ConfirmLogOn();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmLogOn_Load(object sender, EventArgs e)
        {
            // 这里判断自动登录
            if (!SystemInfo.LogOned && SystemInfo.AutoLogOn)
            {
                this.ConfirmLogOn();
                if (SystemInfo.LogOned)
                {
                    this.Close();
                }
            }
        }

        private void FrmLogOn_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 若没登录，直接关闭了，就需要退出了
            if (!SystemInfo.LogOned)
            {
                //Application.Exit();
                System.Environment.Exit(0);
            }
        }

        private void linkLblForgetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG9968);
        }
    }
}
