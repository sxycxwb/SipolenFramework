//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// SystemInfo
    /// 系统基础信息部分
    /// 
    /// 修改记录
    ///		
    /// 版本：3.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.07</date>
    /// </author>
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// 是否已经成功登录系统
        /// </summary>
        public static bool LogOned = false;

        /// <summary>
        /// 用户在线状态
        /// </summary>
        public static int OnLineState = 0;


        #region 客户端的配置信息部分
        
        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string CurrentUserName = string.Empty;

        /// <summary>
        /// 当前密码
        /// </summary>
        public static string CurrentPassword = string.Empty;

        /// <summary>
        /// 登录是否保存密码，默认能记住密码会好用一些
        /// </summary>
        public static bool RememberPassword = true;

        /// <summary>
        /// 是否自动登录，默认不自动登录会好一些
        /// </summary>
        public static bool AutoLogOn = false;

        /// <summary>
        /// 客户端加密存储密码，这个应该是要加密才可以
        /// </summary>
        public static bool EncryptClientPassword = true;

        /// <summary>
        /// 远程调用Service用户名（为了提高软件的安全性）
        /// </summary>
        public static string ServiceUserName = "RDIFramework";

        /// <summary>
        /// 远程调用Service密码（为了提高软件的安全性）
        /// </summary>
        public static string ServicePassword = "RDIFramework654123";
        
        /// <summary>
        /// 默认加载所有用户用户量特别大时的优化配置项目，默认是小规模用户
        /// </summary>
        public static bool LoadAllUser = true;

        /// <summary>
        /// 动态加载组织机构树，当数据量非常庞大时用的参数，默认是小规模用户
        /// </summary>
        public static bool OrganizeDynamicLoading = true;

        /// <summary>
        /// 是否采用多语言
        /// </summary>
        public static bool MultiLanguage = false;

        /// <summary>
        /// 当前客户选择的语言
        /// </summary>
        public static string CurrentLanguage = "zh-CN";

        /// <summary>
        /// 当前语言
        /// </summary>
        public static string Themes = string.Empty;

        private int lockWaitMinute = 60;

        /// <summary>
        /// 锁定等待时间分钟
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        }

        /// <summary>
        /// 即时通信指向的网站地址
        /// </summary>
        public static string WebHostUrl = "WebHostUrl";

        /// <summary>
        /// 显示异常的详细信息?
        /// </summary>
        public static bool ShowExceptionDetail = true;

        /// <summary>
        /// 显示操作成功信息？
        /// </summary>
        public static bool ShowSuccessMsg = true;

        /// <summary>
        /// 分页大小(默认为每页显示20条数据)
        /// </summary>
        public static int PageSize = 50;

        /// <summary>
        /// 配置文件名称
        /// </summary>
        public static string ConfigFile = "Config";
        #endregion
        
        #region 服务器端的配置信息
        /// <summary>
        /// 主机地址
        /// Host = "127.0.0.1";
        /// </summary>
        public static string Host = string.Empty;

        /// <summary>
        /// 端口号
        /// </summary>
        public static int Port = 0;

        /// <summary>
        /// 允许新用户注册
        /// </summary>
        public static bool AllowUserToRegister = true;

        /// <summary>
        /// 是否启用即时内部消息
        /// </summary>
        public static bool UseMessage = true;

        /// <summary>
        /// 是否启用表格数据权限
        /// 启用分级管理范围权限设置，启用逐级授权
        /// </summary>
        public static bool EnableUserAuthorizationScope = false;

        /// <summary>
        /// 启用按用户权限
        /// </summary>
        public static bool EnableUserAuthorization = true;

        /// <summary>
        /// 启用模块菜单权限
        /// </summary>
        public static bool EnableModulePermission = true;

        /// <summary>
        /// 启用操作权限
        /// </summary>
        public static bool EnablePermissionItem = true;

        /// <summary>
        /// 启用数据表的约束条件限制
        /// </summary>
        public static bool EnableTableConstraintPermission = false;

        /// <summary>
        /// 启用数据表的列权限
        /// </summary>
        public static bool EnableTableFieldPermission = false;

        /// <summary>
        /// 启用组织机构权限
        /// </summary>
        public static bool EnableOrganizePermission = false;

        /// <summary>
        /// 设置手写签名
        /// </summary>
        public static bool EnableHandWrittenSignature = true;

        /// <summary>
        /// 登录历史纪录
        /// </summary>
        public static bool EnableRecordLogOnLog = true;

        /// <summary>
        /// 是否进行日志记录
        /// </summary>
        public static bool EnableRecordLog = true;

        /// <summary>
        /// 是否更新访问日期信息
        /// </summary>
        public static bool UpdateVisit = true;

        /// <summary>
        /// 同时在线用户数量限制
        /// </summary>
        public static int OnLineLimit = 0;

        /// <summary>
        /// 是否检查用户IP地址
        /// </summary>
        public static bool EnableCheckIPAddress = false;        

        /// <summary>
        /// 是否登记异常
        /// </summary>
        public static bool LogException = true;

        /// <summary>
        /// 是否登记数据库操作
        /// </summary>
        public static bool LogSQL = false;

        /// <summary>
        /// 是否登记到 Windows 系统异常中
        /// </summary>
        public static bool EventLog = false;

        /// <summary>
        /// 系统默认密码
        /// </summary>
        public static string DefaultPassword = "abcd1234";

        #endregion

        #region 服务器端安全设置

        /// <summary>
        /// 检查密码强度
        /// </summary>
        public static bool EnableCheckPasswordStrength = false;

        /// <summary>
        /// 服务器端加密存储密码
        /// </summary>
        public static bool EnableEncryptServerPassword = true;

        /// <summary>
        /// 密码最小长度
        /// </summary>
        public static int PasswordMiniLength = 6;

        /// <summary>
        /// 必须字母+数字组合
        /// </summary>
        public static bool NumericCharacters = true; 

        /// <summary>
        /// 密码修改周期(月)
        /// </summary>
        public static int PasswordChangeCycle = 3;

        /// <summary>
        /// 禁止用户重复登录
        /// 只允许登录一次
        /// </summary>
        public static bool CheckOnLine = false;

        /// <summary>
        /// 用户名最小长度
        /// </summary>
        public static int AccountMinimumLength = 4;

        /// <summary>
        /// 密码错误锁定次数
        /// </summary>
        public static int PasswordErrorLockLimit = 5;

        /// <summary>
        ///连续输入N次密码后，密码错误锁定周期(分钟)
        /// 0 表示 需要系统管理员进行审核，帐户直接被设置为无效
        /// </summary>
        public static int PasswordErrorLockCycle = 30;

        #endregion

        #region 数据库连接相关配置

        /// <summary>
        /// RDIFramework.NET框架数据库类别
        /// </summary>
        public static CurrentDbType RDIFrameworkDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 业务数据库类别
        /// </summary>
        public static CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 工作流数据库类别
        /// </summary>
        public static CurrentDbType WorkFlowDbType   = CurrentDbType.SqlServer;

        /// <summary>
        /// 是否加数据库连接
        /// </summary>
        public static bool EncryptDbConnection       = false;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string RDIFrameworkDbConection = string.Empty;

        /// <summary>
        /// 数据库连接的字符串
        /// </summary>
        public static string RDIFrameworkDbConectionString = string.Empty;

        /// <summary>
        /// 业务数据库
        /// </summary>
        public static string BusinessDbConnection = string.Empty;

        /// <summary>
        /// 业务数据库（连接串，可能是加密的）
        /// </summary>
        public static string BusinessDbConnectionString = string.Empty;

        /// <summary>
        /// 工作流数据库
        /// </summary>
        public static string WorkFlowDbConnection = string.Empty;

        /// <summary>
        /// 工作流数据库（连接串，可能是加密的）
        /// </summary>
        public static string WorkFlowDbConnectionString = string.Empty;

        #endregion
        
        #region 系统性的参数配置
        
        /// <summary>
        /// 软件是否需要注册
        /// </summary>
        public static bool NeedRegister = true;        

        /// <summary>
        /// 检查周期[以秒为单位]2分钟内不在线的，就认为是已经没在线了，心跳方式检查
        /// </summary>
        public static int OnLineTime0ut = 2*60 +20;

        /// <summary>
        /// 每过1分钟，检查一次在线状态
        /// </summary>
        public static int OnLineCheck = 60;

        /// <summary>
        /// 注册码
        /// </summary>
        public static string RegisterKey = string.Empty;

        /// <summary>
        /// 当前网站的安装地址
        /// </summary>
        public static string StartupPath = string.Empty;

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public static bool MatchCase = true;

        /// <summary>
        /// 最多获取数据的行数限制
        /// </summary>
        public static int TopLimit = 200;

        /// <summary>
        /// 锁不住记录时的循环次数
        /// </summary>
        public static int LockNoWaitCount = 5;

        /// <summary>
        /// 锁不住记录时的等待时间
        /// </summary>
        public static int LockNoWaitTickMilliSeconds = 30;

        /// <summary>
        /// 是否采用服务器端缓存
        /// </summary>
        public static bool ServerCache = false;

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public static string LastUpdate = "2016.02.18";

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string Version = "3.0";

        /// <summary>
        /// 每个操作是否进行信息提示。
        /// </summary>
        public static bool ShowInformation = true;

        /// <summary>
        /// 时间格式
        /// </summary>
        public static string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期短格式
        /// </summary>
        public static string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 日期长格式
        /// </summary>
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 当前软件Id
        /// </summary>
        public static string SoftName = string.Empty;

        /// <summary>
        /// 软件的名称
        /// </summary>
        public static string SoftFullName = string.Empty;

        /// <summary>
        /// 根菜单编号
        /// </summary>
        public static string RootMenuCode = string.Empty;

        /// <summary>
        /// 是否采用客户端缓存
        /// </summary>
        public static bool ClientCache = false;

        /// <summary>
        /// 当前客户公司名称
        /// </summary>
        public static string CustomerCompanyName = string.Empty;
        
        /// <summary>
        /// 系统图标文件
        /// </summary>
        public static string AppIco = "Resource\\App.ico";

        /// <summary>
        /// 插件所在的目录
        /// </summary>
        public static string AddInDirectory = "AddIn\\";

        /// <summary>
        /// RegistryKey、Configuration、UserConfig 注册表或者配置文件读取参数
        /// </summary>
        public static ConfigurationCategory ConfigurationFrom = ConfigurationCategory.Configuration;

        public static string RegisterException = "请您联系：XuWangBin QQ:406590790 手机：13005007127 电子邮件：406590790@qq.com 对软件进行注册。";

        public static string CustomerPhone = "";	// 当前客户公司电话
        public static string CompanyName = "";	// 公司名称
        public static string CompanyPhone = "13005007127";	// 公司电话

        public static string Copyright = "Copyright 2009-2016 XuWangBin";
        public static string BugFeedback = @"mailto:RDIFramework@126.com?subject=On the UMPllatForm feedback&body=Here to enter your valuable feedback";
        public static string IEDownloadUrl = @"http://download.microsoft.com/download/ie6sp1/finrel/6_sp1/W98NT42KMeXP/CN/ie6setup.exe";

        public static string HelpNamespace = string.Empty;
        public static string UploadDirectory = "Document/";
        #endregion
        
        #region 客户端动态加载程序相关
        
        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;
        public static string MainForm = "FrmRDIFrameworkNav";

        public static string LogOnAssembly = "RDIFramework.NET";
        public static string LogOnForm = "FrmLogOn";

        /// <summary>
        /// 服务实现
        /// </summary>
        public static string Service = "RDIFramework.BizLogic";

        /// <summary>
        /// 服务映射工厂
        /// </summary>
        public static string ServiceFactory = "ServiceFactory";
        
        // public static string DbProviderClass = "RDIFramework.Utilities.SqlProvider";
        public static string DbProviderAssmely = "RDIFramework.Utilities";

        /// <summary>
        /// 当前主题样式
        /// </summary>
        public static string CurrentStyle = "VisualStudio2010Blue";
        /// <summary>
        /// 当前主题颜色
        /// </summary>
        public static string CurrentThemeColor = string.Empty;
        #endregion
        
        #region 系统邮件错误报告反馈相关

        /// <summary>
        /// 发送给谁，用,;符号隔开
        /// </summary>
        public static string ErrorReportFrom = "406590790@qq.com";

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public static string ErrorReportMailServer = "smtp.126.com";            
   
        /// <summary>
        /// 用户名
        /// </summary>
        public static string ErrorReportMailUserName = "umplatform@126.com";          

        /// <summary>
        /// 密码
        /// </summary>
        public static string ErrorReportMailPassword = "umplatform2012";

        /// <summary>
        /// 平台博客
        /// </summary>
        public static string RDIFrameworkBlog = "http://www.cnblogs.com/huyong/";

        /// <summary>
        /// 平台微博（腾讯）
        /// </summary>
        public static string RDIFrameworkWeibo = "http://t.qq.com/yonghu86";

        #endregion

        /// <summary>
        /// 工作流节点超时时间设置（以小时为单位）
        /// </summary>
        public static string NodeTimeout = "72";

        private static UserInfo userInfo = null;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public static UserInfo UserInfo
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = new UserInfo();
                    // IP地址
                    if (String.IsNullOrEmpty(userInfo.IPAddress))
                    {
                        userInfo.IPAddress = MachineInfoHelper.GetIPAddress();
                    }
                    //Mac地址  
                    if (String.IsNullOrEmpty(userInfo.MACAddress))
                    {
                        userInfo.MACAddress = MachineInfoHelper.GetMacAddress();
                    }

                    // 主键
                    if (String.IsNullOrEmpty(userInfo.Id))
                    {
                        userInfo.Id = MachineInfoHelper.GetIPAddress();
                    }
                    // 用户名
                    if (String.IsNullOrEmpty(userInfo.UserName))
                    {
                        userInfo.UserName = System.Environment.MachineName;
                    }
                    // 真实姓名
                    if (String.IsNullOrEmpty(userInfo.RealName))
                    {
                        userInfo.RealName = System.Environment.UserName;
                    }
                    userInfo.ServiceUserName = SystemInfo.ServiceUserName;
                    userInfo.ServicePassword = SystemInfo.ServicePassword;
                }
                return userInfo;
            }
            set
            {
                userInfo = value;
            }
        }

        /// <summary>
        /// C/S程序保存登录信息部分
        /// </summary>
        /// <param name="userInfo">用户</param>
        public static void LogOn(UserInfo userInfo)
        {
            SystemInfo.UserInfo = userInfo;
        }
        
        /// <summary>
        /// 验证用户是否是授权的用户
        /// 不是任何人都可以调用服务的，将来这里还可以进行扩展的
        /// 例如用IP地址限制等等
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>验证成功</returns>
        public static bool IsAuthorized(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return false;
            }

            // 若系统设置的用户名是空的，那就不用判断了
            if (string.IsNullOrEmpty(ServiceUserName))
            {
                return true;
            }
            // 若系统设置的用密码是空的，那就不用判断了
            if (string.IsNullOrEmpty(ServicePassword))
            {
                return true;
            }
            // 调用服务器的用户名、密码都对了，才可以调用服务程序，否则认为是非授权的操作
            if (ServiceUserName.Equals(userInfo.ServiceUserName) && ServicePassword.Equals(userInfo.ServicePassword))
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 得到指定名称的链接字符串
    /// </summary>
    public class ConnectStrings : System.Collections.Generic.List<ConnectString>
    {
        public ConnectString this[string name]
        {
            get
            {
                foreach (ConnectString connStr in this)
                {
                    if (connStr.LinkName.Equals(name))
                    {
                        return connStr;
                    }
                }
                return null;
            }
        }
    }

    /// <summary>
    /// 连接字符串
    /// </summary>
    [Serializable]
    public class ConnectString
    {
        private string _linkName = string.Empty;
        private string _dbLink = string.Empty;
        private CurrentDbType _dbType = CurrentDbType.SqlServer;

        /// <summary>
        /// 连接名称
        /// </summary>
        public string LinkName
        {
            get
            {
                return _linkName;
            }
            set
            {
                _linkName = value;
            }
        }
        /// <summary>
        /// 数据库连接字符串(加密的)
        /// </summary>
        public string DbLink
        {
            get
            {
                return _dbLink;
            }
            set
            {
                _dbLink = value;
            }
        }

        public string GetSqlServerDBLink
        {
            get
            {
                return SecretHelper.AESDecrypt(this.DbLink);
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public CurrentDbType DbType
        {
            get
            {
                return _dbType;
            }
            set
            {
                _dbType = value;
            }
        }
    }
}