/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-14 14:43:42
 ******************************************************************************/
using System;

namespace RDIFramework.NET
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmOption
    /// 平台选择配置
    /// 
    /// 修改记录
    ///     2015-04-19 EricHu V2.9 新增“当前语言”的配置项。
    ///     2012-06-15 EricHu 新增对配置文件的保存。
    ///     2012-06-14 EricHu 创建FrmOption
    /// </summary>
    public partial class FrmOption : BaseForm
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        #region private void BindData():加载配置信息到界面
        private void BindData()
        {
            /**********************************************************
            * 一、客户端配置
            **********************************************************/
            EncryptClientPassword.Checked = SystemInfo.EncryptClientPassword;
            AutoLogOn.Checked             = SystemInfo.AutoLogOn;
            RememberPassword.Checked      = SystemInfo.RememberPassword;
            LoadAllUser.Checked           = SystemInfo.LoadAllUser;
            EncryptDbConnection.Checked   = SystemInfo.EncryptDbConnection;
            ServiceUserName.Text          = SystemInfo.ServiceUserName;
            ServicePassword.Text          = SystemInfo.ServicePassword;
            RDIFrameworkDbType.Text       = SystemInfo.RDIFrameworkDbType.ToString();
            //zh-CN,zh-TW,en-US
            switch (SystemInfo.CurrentLanguage)
            {
                case "zh-CN":
                    CurrentLanguage.SelectedItem = CurrentLanguage.Items[0];
                    break;
                case "zh-TW":
                    CurrentLanguage.SelectedItem = CurrentLanguage.Items[1];
                    break;
                case "en-US":
                    CurrentLanguage.SelectedItem = CurrentLanguage.Items[2];
                    break;
            }
            RDIFrameworkDbConection.Text = SystemInfo.RDIFrameworkDbConectionString;
            if (SystemInfo.EncryptDbConnection)
            {
                RDIFrameworkDbConection.Text = SecretHelper.AESDecrypt(SystemInfo.RDIFrameworkDbConectionString);
            }
            /**********************************************************
            * 二、服务端配置
            **********************************************************/
            AllowUserToRegister.Checked             = SystemInfo.AllowUserToRegister;
            EnableRecordLog.Checked                 = SystemInfo.EnableRecordLog;
            EnableCheckIPAddress.Checked            = SystemInfo.EnableCheckIPAddress;
            EnableUserAuthorizationScope.Checked    = SystemInfo.EnableUserAuthorizationScope;
            EnableUserAuthorization.Checked         = SystemInfo.EnableUserAuthorization;
            EnableModulePermission.Checked          = SystemInfo.EnableModulePermission;
            EnablePermissionItem.Checked            = SystemInfo.EnablePermissionItem;
            EnableTableFieldPermission.Checked      = SystemInfo.EnableTableFieldPermission;
            EnableTableConstraintPermission.Checked = SystemInfo.EnableTableConstraintPermission;
            EnableEncryptServerPassword.Checked     = SystemInfo.EnableEncryptServerPassword;
            EnableCheckPasswordStrength.Checked     = SystemInfo.EnableCheckPasswordStrength;
            NumericCharacters.Checked               = SystemInfo.NumericCharacters;
            CheckOnLine.Checked                     = SystemInfo.CheckOnLine;
            EnableOrganizePermission.Checked        = SystemInfo.EnableOrganizePermission;
            OnLineLimit.Value                       = SystemInfo.OnLineLimit;
            OnLineTime0ut.Value                     = SystemInfo.OnLineTime0ut;
            AccountMinimumLength.Value              = SystemInfo.AccountMinimumLength;
            PasswordChangeCycle.Value               = SystemInfo.PasswordChangeCycle;
            PasswordErrorLockLimit.Value            = SystemInfo.PasswordErrorLockLimit;
            PasswordErrorLockCycle.Value            = SystemInfo.PasswordErrorLockCycle;
            DefaultPassword.Text                    = SystemInfo.DefaultPassword;
            PasswordMiniLength.Value                = SystemInfo.PasswordMiniLength;
            //**********************************************************
            //三、系统参数配置
            //**********************************************************
            MainForm.SelectedValue = SystemInfo.MainForm;
            foreach (DevComponents.Editors.ComboItem cboItem in MainForm.Items)
            {
                if (SystemInfo.MainForm == cboItem.Text)
                {
                    MainForm.SelectedItem = cboItem;
                    break;
                }
            }
            LogOnForm.Text               = SystemInfo.LogOnForm;
            LogOnAssembly.Text           = SystemInfo.LogOnAssembly;
            CustomerCompanyName.Text     = SystemInfo.CustomerCompanyName;
            ConfigurationFrom.Text       = SystemInfo.ConfigurationFrom.ToString();
            SoftName.Text                = SystemInfo.SoftName;
            SoftFullName.Text            = SystemInfo.SoftFullName;
            Version.Text                 = SystemInfo.Version;
            Service.Text                 = SystemInfo.Service;
            RegisterKey.Text             = SystemInfo.RegisterKey;
            //**********************************************************
            //四、错误报告反馈配置
            //**********************************************************
            ErrorReportFrom.Text         = SystemInfo.ErrorReportFrom;
            ErrorReportMailUserName.Text = SystemInfo.ErrorReportMailUserName;            
            ErrorReportMailServer.Text   = SystemInfo.ErrorReportMailServer;
            ErrorReportMailPassword.Text = SystemInfo.ErrorReportMailPassword;
        }
        #endregion

        #region private void SaveConfigInfo():保存配置信息
        private void SaveConfigInfo()
        {
            //**********************************************************
            //一、客户端配置
            //**********************************************************
            SystemInfo.EncryptClientPassword = EncryptClientPassword.Checked;
            SystemInfo.AutoLogOn             = AutoLogOn.Checked;
            SystemInfo.RememberPassword      = RememberPassword.Checked;
            SystemInfo.LoadAllUser           = LoadAllUser.Checked;
            SystemInfo.EncryptDbConnection   = EncryptDbConnection.Checked;
            SystemInfo.ServiceUserName       = ServiceUserName.Text.Trim();
            SystemInfo.ServicePassword       = ServicePassword.Text.Trim();

            switch(RDIFrameworkDbType.Text.Trim())
            {
                case "SqlServer":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.SqlServer;
                    break;
                case "Oracle":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.Oracle;
                    break;
                case "MySql":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.MySql;
                    break;
                case "DB2":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.DB2;
                    break;
                case "Access":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.Access;
                    break;
                case "SQLite":
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.SQLite;
                    break;
                default:
                    SystemInfo.RDIFrameworkDbType = CurrentDbType.SqlServer;
                    break;
            }
            SystemInfo.CurrentLanguage = CurrentLanguage.SelectedItem == null ? "zh-CN" : CurrentLanguage.SelectedItem.ToString();

            SystemInfo.RDIFrameworkDbConectionString = RDIFrameworkDbConection.Text.Trim();

            if (SystemInfo.EncryptDbConnection)
            {
                SystemInfo.RDIFrameworkDbConectionString = SecretHelper.AESEncrypt(SystemInfo.RDIFrameworkDbConectionString);
                SystemInfo.BusinessDbConnectionString    = SecretHelper.AESEncrypt(SystemInfo.BusinessDbConnectionString);
                SystemInfo.WorkFlowDbConnectionString    = SecretHelper.AESEncrypt(SystemInfo.WorkFlowDbConnectionString);
            }
            //**********************************************************
            //二、服务端配置
            //**********************************************************

            SystemInfo.AllowUserToRegister             = AllowUserToRegister.Checked;
            SystemInfo.EnableRecordLog                 = EnableRecordLog.Checked;
            SystemInfo.EnableCheckIPAddress            = EnableCheckIPAddress.Checked;
            SystemInfo.EnableUserAuthorization         = EnableUserAuthorization.Checked;
            SystemInfo.EnableModulePermission          = EnableModulePermission.Checked;
            SystemInfo.EnablePermissionItem            = EnablePermissionItem.Checked;
            SystemInfo.EnableTableFieldPermission      = EnableTableFieldPermission.Checked;
            SystemInfo.EnableTableConstraintPermission = EnableTableConstraintPermission.Checked;
            SystemInfo.EnableEncryptServerPassword     = EnableEncryptServerPassword.Checked;
            SystemInfo.EnableCheckPasswordStrength     = EnableCheckPasswordStrength.Checked;
            SystemInfo.NumericCharacters               = NumericCharacters.Checked;
            SystemInfo.CheckOnLine                     = CheckOnLine.Checked;
            SystemInfo.EnableOrganizePermission        = EnableOrganizePermission.Checked;
            if(OnLineLimit.Text.Trim().Length > 0)
            {
                SystemInfo.OnLineLimit = OnLineLimit.Value;
            }

            if (OnLineTime0ut.Text.Trim().Length > 0)
            {
                SystemInfo.OnLineTime0ut = OnLineTime0ut.Value;
            }

            if (AccountMinimumLength.Text.Trim().Length > 0)
            {
                SystemInfo.AccountMinimumLength = AccountMinimumLength.Value;
            }

            if (PasswordChangeCycle.Text.Trim().Length > 0)
            {
                SystemInfo.PasswordChangeCycle = PasswordChangeCycle.Value;
            }

            if (PasswordErrorLockLimit.Text.Trim().Length > 0)
            {
                SystemInfo.PasswordErrorLockLimit = PasswordErrorLockLimit.Value;
            }

            if (PasswordErrorLockCycle.Text.Trim().Length > 0)
            {
                SystemInfo.PasswordErrorLockCycle = PasswordErrorLockCycle.Value;
            }

            SystemInfo.DefaultPassword = DefaultPassword.Text.Trim();

            if (PasswordMiniLength.Text.Trim().Length > 0)
            {
                SystemInfo.PasswordMiniLength = PasswordMiniLength.Value;
            }
            
            //**********************************************************
            //三、系统参数配置
            //**********************************************************
            SystemInfo.MainForm                = BusinessLogic.ConvertToString(MainForm.SelectedItem);
            SystemInfo.LogOnForm               = LogOnForm.Text.Trim();
            SystemInfo.LogOnAssembly           = LogOnAssembly.Text.Trim();
            SystemInfo.CustomerCompanyName     = CustomerCompanyName.Text.Trim();
            //SystemInfo.ConfigurationFrom     = ConfigurationFrom.Text.Trim();
            SystemInfo.SoftName                = SoftName.Text.Trim();
            SystemInfo.SoftFullName            = SoftFullName.Text.Trim();
            SystemInfo.Version                 = Version.Text.Trim();
            SystemInfo.Service                 = Service.Text.Trim();
            //SystemInfo.RegisterKey           = RegisterKey.Text;   
            
            /**********************************************************
            * 四、错误报告反馈配置
            **********************************************************/
            SystemInfo.ErrorReportFrom         = ErrorReportFrom.Text.Trim();
            SystemInfo.ErrorReportMailServer   = ErrorReportMailServer.Text.Trim();
            SystemInfo.ErrorReportMailUserName = ErrorReportMailUserName.Text.Trim();
            SystemInfo.ErrorReportMailPassword = ErrorReportMailPassword.Text.Trim();


            UserConfigHelper.SaveConfig();
            //再次得到配置文件。这儿主要是对加密的数据在软件运行过程中是解密的。
            UserConfigHelper.GetConfig();
        }
        #endregion

        public override void FormOnLoad()
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0284) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                if (MainForm.SelectedItem == null)
                {
                    MessageBoxHelper.ShowErrorMsg("必须设置主界面风格！");
                    MainForm.Focus();
                    return;
                }
                SaveConfigInfo();
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                this.Close();
            }
            catch(Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
