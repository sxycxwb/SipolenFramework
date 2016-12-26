using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using RDIFramework.Utilities;
using RDIFramework.BizLogic;

public partial class Utils
{
    /// <summary>
    /// 框架数据库连接
    /// </summary>
    public static readonly string RDIFrameworkDbConection = ConfigurationManager.AppSettings["RDIFrameworkDbConection"];

    /// <summary>
    /// Cookie 名称
    /// </summary>
    public static string CookieName = "RDIFramework.NET";
    /// <summary>
    /// Cookie 用户名
    /// </summary>
    public static string CookieUserName = "UserName";
    /// <summary>
    /// Cookie 密码
    /// </summary>
    public static string CookiePassword = "Password";

    /// <summary>
    /// Session 名称
    /// </summary>
    public static string SessionName = "UserInfo";

    //
    // 当前操作员权限相关检查函数
    //

    #region public static bool UserIsAdministrator() 判断当前用户是否为系统管理员
    /// <summary>
    /// 判断当前用户是否为系统管理员
    /// </summary>
    /// <returns>是否</returns>
    public static bool UserIsAdministrator()
    {
        bool returnValue = false;
        if (!UserIsLogOn()) return returnValue;
        var userInfo = (UserInfo)HttpContext.Current.Session["UserInfo"];
        returnValue = userInfo.IsAdministrator;
        return returnValue;
    }
    #endregion

    #region public static bool CheckIsLogOn() 检查是否已登录
    /// <summary>
    /// 检查是否已登录
    /// </summary>
    public static bool CheckIsLogOn(string userNotLogOn)
    {
        if (UserIsLogOn()) return true;
        if (string.IsNullOrEmpty(userNotLogOn))
        {
            string js = @"<Script language='JavaScript'>
                top.window.location.replace('{0}');
                </Script>";
            js = string.Format(js, Utils.UserNotLogOn);
            HttpContext.Current.Response.Write(js);
        }
        else
        {
            HttpContext.Current.Response.Redirect(userNotLogOn);
        }
        return false;
    }
    #endregion

    #region public static void CheckIsAdministrator() 检查判断当前用户是否为系统管理员
    /// <summary> 
    /// 检查判断当前用户是否为系统管理员
    /// </summary>
    public static void CheckIsAdministrator()
    {
        // 检查是否已登录
        Utils.CheckIsLogOn(null);
        // 是否系统管理员
        if (!UserIsAdministrator())
        {
            HttpContext.Current.Response.Redirect(Utils.UserIsNotAdminPage);
        }
    }
    #endregion

    //
    // 一 用户注册部分 
    //

    #region private static string GetAfterUserRegisterBody(BaseUserEntity userEntity) 用户注册之后，给用户发的激活账户的邮件
    /// <summary>
    /// 用户注册之后，给用户发的激活账户的邮件
    /// </summary>
    /// <param name="userEntity">用户实体</param>
    /// <returns>邮件主题</returns>
    private static string GetAfterUserRegisterBody(PiUserEntity userEntity)
    {
        var htmlBody = new StringBuilder();
        htmlBody.Append("<body style=\"font-size:10pt\">");
        htmlBody.Append("<div style=\"font-size:10pt; font-weight:bold\">尊敬的用户 " + userEntity.UserName + " 您好：</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 请点击此处激活您的账号：<a href='http://www.12345.cn/Modules/User/Activation.aspx?Id=" + userEntity.Id + "'><font size=\"3\" color=\"#6699cc\">" + userEntity.UserName + "</font></a></div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 也可以直接在url中输入网址下面的网址 http://www.12345.cn/Modules/User/Activation.aspx?Id=" + userEntity.Id + " 激活账户</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 如有任何疑问，欢迎致框架客服QQ：406590790，我们将热情为您解答。</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div style=\"text-align:center\">RDIFramework.NET 用户服务中心</div>");
        htmlBody.Append("<div style=\"text-align:center\">" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日</div></body>");
        return htmlBody.ToString();
    }
    #endregion

    #region public static bool AfterUserRegister(BaseUserEntity userEntity) 用户注册之后，给用户发的激活账户的邮件
    /// <summary>
    /// 用户注册之后，给用户发的激活账户的邮件
    /// </summary>
    /// <param name="userEntity">用户实体</param>
    /// <returns>成功发送邮件</returns>
    public static bool AfterUserRegister(PiUserEntity userEntity)
    {
        bool returnValue = false;
        IDbProvider dbProvider = new SqlProvider(RDIFrameworkDbConection);
        UserInfo userInfo = null;
        
        try
        {
            using (var mailMessage = new System.Net.Mail.MailMessage())
            {
                // 接收人邮箱地址
                mailMessage.To.Add(new System.Net.Mail.MailAddress(userEntity.Email));
                mailMessage.Body = GetAfterUserRegisterBody(userEntity);
                mailMessage.From = new System.Net.Mail.MailAddress("406590790@qq.com", "新密码");
                mailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
                mailMessage.Subject = "新密码。";
                mailMessage.IsBodyHtml = true;
                var smtpclient = new System.Net.Mail.SmtpClient(SystemInfo.ErrorReportMailServer)
                {
                    Credentials = new System.Net.NetworkCredential(SystemInfo.ErrorReportMailUserName, SystemInfo.ErrorReportMailPassword),
                    EnableSsl = false
                };
                smtpclient.Send(mailMessage);
                returnValue = true;
            }
        }
        catch (System.Exception exception)
        {
            // 若有异常，应该需要保存异常信息
            CiExceptionManager.LogException(dbProvider, userInfo, exception);
            returnValue = false;
        }
        finally
        {
            dbProvider.Close();
        }
        return returnValue;
    }
    #endregion

    //
    // 二 判断用户是否已登录部分
    //

    #region public static bool UserIsLogOn() 判断用户是否已登录
    /// <summary>
    /// 判断用户是否已登录
    /// </summary>
    /// <returns>已登录</returns>
    public static bool UserIsLogOn()
    {
        // 先判断 Session 里是否有用户
        if (SessionUtils.GetSession(SessionName) == null)
        {
            // 检查是否有Cookie？
            CheckCookie();
        }
        return HttpContext.Current.Session != null && SessionUtils.GetSession(SessionName) != null;
    }
    #endregion

    #region public static void SetSession(UserInfo userInfo)
    /// <summary>
    /// 保存Session
    /// </summary>
    /// <param name="userInfo">当前用户</param>
    public static void SetSession(UserInfo userInfo)
    {
        // 检查是否有效用户
        if (userInfo != null && !string.IsNullOrEmpty(userInfo.Id))
        {
            // if (userInfo.RoleId.Length == 0)
            // {
            //     userInfo.RoleId = DefaultRole.User.ToString();
            // }
            // 操作员

            SessionUtils.SetSession(SessionName, userInfo);          
        }
    }
    #endregion

    #region public static UserInfo UserInfo 获取用户信息
    /// <summary>
    /// 获取用户信息
    /// </summary>
    public static UserInfo UserInfo
    {
        get
        {
            UserInfo userInfo = null;
            if (UserIsLogOn())
            {
                userInfo = (UserInfo)SessionUtils.GetSession(SessionName);
            }
            return userInfo;
        }
    }
    #endregion

    /// <summary>
    /// 当前样式
    /// </summary>
    public static string CurrentTheme
    {
        get
        {
            if (HttpContext.Current.Session["theme"] == null)
            {
                var cook = HttpContext.Current.Request.Cookies["theme"];
                if (cook != null)
                {
                    HttpContext.Current.Session["theme"] = cook.Value;
                    return cook.Value;
                }
                else
                    return "default";
            }
            else
            {

                return HttpContext.Current.Session["theme"] as string;
            }
        }
    }

    //
    // 三 判断当前的CheckCookie内容情况
    //

    #region public static UserInfo CheckCookie()
    /// <summary>
    /// 检查当前的Cookie内容
    /// </summary>
    public static UserInfo CheckCookie()
    {
        UserInfo userInfo = null;
        // 这里应该再判断是否密码过期，用户过期等等，不只是用Cookie就可以了
        userInfo = CheckCookie(HttpContext.Current.Request);
        if (userInfo != null)
        {
            SetSession(userInfo);
        }
        return userInfo;
    }
    #endregion

    #region public static HttpCookie GetCookie(HttpRequest httpRequest) 获取Cookies
    /// <summary>
    /// 获取Cookies
    /// </summary>
    /// <param name="httpRequest">客户端请求</param>
    /// <returns></returns>
    public static HttpCookie GetCookie(HttpRequest httpRequest)
    {
        return httpRequest.Cookies[CookieName];
    }
    #endregion

    #region public static UserInfo CheckCookie(HttpRequest httpRequest)
    /// <summary>
    /// 检查当前的Cookie内容
    /// </summary>
    /// <param name="httpRequest">当前页</param>
    /// <returns>Cookie内容</returns>
    public static UserInfo CheckCookie(HttpRequest httpRequest)
    {
        UserInfo userInfo = null;
        string password = string.Empty;
        // 取得cookie的保存信息
        HttpCookie httpCookie = httpRequest.Cookies[Utils.CookieName];
        if (httpCookie == null) return userInfo;
        // 读取用户名
        if (!string.IsNullOrEmpty(httpCookie.Values[Utils.CookieUserName]))
        {
            string username = httpCookie.Values[Utils.CookieUserName].ToString();
            if (string.IsNullOrEmpty(SystemInfo.RDIFrameworkDbConection))
            {
                // 若没有能连接数据库，就直接从Cookie读取用户，这里应该重新定位一下用户信息那里，判断用户是否有效等等，密码是否修改了等等。
                userInfo = GetUserCookie(httpRequest);
            }
            else
            {
                if (SystemInfo.RememberPassword)
                {
                    // 读取密码
                    if (!string.IsNullOrEmpty(httpCookie.Values[Utils.CookiePassword]))
                    {
                        password = SecretHelper.AESDecrypt(httpCookie.Values[Utils.CookiePassword].ToString());
                    }
                    // 进行登录，这里是靠重新登录获取Cookie
                    userInfo = LogOn(username, password, false);
                }
            }
        }
        return userInfo;
    }
    #endregion

    #region public static UserInfo GetUserCookie(HttpRequest httpRequest)获取用户相应的Cookies信息
    /// <summary>
    /// 获取用户相应的Cookies信息
    /// </summary>
    /// <param name="httpRequest"></param>
    /// <returns></returns>
    public static UserInfo GetUserCookie(HttpRequest httpRequest)
    {
        UserInfo userInfo = null;
        HttpCookie httpCookie = httpRequest.Cookies[Utils.CookieName];
        if (httpCookie == null) return userInfo;
        userInfo = new UserInfo
        {
            UserName = HttpUtility.UrlDecode(httpCookie.Values[Utils.CookieUserName]),
            Code = httpCookie.Values["Code"],
            CompanyCode = httpCookie.Values["CompanyCode"],
            CompanyId =!string.IsNullOrEmpty(httpCookie.Values["CompanyId"])? BusinessLogic.ConvertToString(httpCookie.Values["CompanyId"]): null,
            CompanyName = HttpUtility.UrlDecode(httpCookie.Values["CompanyName"]),
            CurrentLanguage = httpCookie.Values["CurrentLanguage"],
            DepartmentCode = httpCookie.Values["DepartmentCode"],
            DepartmentId =!string.IsNullOrEmpty(httpCookie.Values["DepartmentId"])? BusinessLogic.ConvertToString(httpCookie.Values["DepartmentId"]): null,
            DepartmentName = HttpUtility.UrlDecode(httpCookie.Values["DepartmentName"]),
            Id = httpCookie.Values["Id"],
            IPAddress = httpCookie.Values["IPAddress"]
        };
        if (!string.IsNullOrEmpty(httpCookie.Values["IsAdministrator"]))
        {
            userInfo.IsAdministrator = httpCookie.Values["IsAdministrator"].ToString().Equals(true.ToString());
        }
        userInfo.OpenId = httpCookie.Values["OpenId"];
        userInfo.RealName = HttpUtility.UrlDecode(httpCookie.Values["RealName"]);
        userInfo.RoleId = !string.IsNullOrEmpty(httpCookie.Values["RoleId"]) ? BusinessLogic.ConvertToString(httpCookie.Values["RoleId"]) : null;
        userInfo.RoleName = HttpUtility.UrlDecode(httpCookie.Values["RoleName"]);
        if (!string.IsNullOrEmpty(httpCookie.Values["SecurityLevel"]))
        {
            userInfo.SecurityLevel = int.Parse(httpCookie.Values["SecurityLevel"]);
        }
        userInfo.ServicePassword = httpCookie.Values["ServicePassword"];
        userInfo.ServiceUserName = httpCookie.Values["ServiceUserName"];
        userInfo.StaffId = httpCookie.Values["StaffId"];
        userInfo.TargetUserId = httpCookie.Values["TargetUserId"];
        userInfo.Themes = httpCookie.Values["Themes"];
        userInfo.UserName = HttpUtility.UrlDecode(httpCookie.Values["UserName"]);
        userInfo.WorkgroupCode = httpCookie.Values["WorkgroupCode"];
        userInfo.WorkgroupId = !string.IsNullOrEmpty(httpCookie.Values["WorkgroupId"]) ? BusinessLogic.ConvertToString(httpCookie.Values["WorkgroupId"]) : null;
        userInfo.WorkgroupName = HttpUtility.UrlDecode(httpCookie.Values["WorkgroupName"]);
        // 只要出错，应该删除Cookie，重新跳转到登录页面才正确
        return userInfo;
    }
    #endregion

    #region public static void SaveCookie(string userName, string password)
    /// <summary>
    /// 保存Cookie
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    public static void SaveCookie(string userName, string password)
    {
        password = SecretHelper.AESEncrypt(password);
        var httpCookie = new HttpCookie(Utils.CookieName);
        // httpCookie.Domain = "HairihanTECH";
        httpCookie.Values[Utils.CookieUserName] = userName;
        if (SystemInfo.RememberPassword)
        {
            httpCookie.Values[Utils.CookiePassword] = password;
        }
        // 设置过期时间为1天
        DateTime dateTime = DateTime.Now;
        httpCookie.Expires = dateTime.AddDays(30);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }
    #endregion

    #region public static void SaveCookie(UserInfo userInfo)
    /// <summary>
    /// 保存Cookie
    /// </summary>
    /// <param name="userInfo">用户信息</param>
    public static void SaveCookie(UserInfo userInfo)
    {
        var nvCookies = new NameValueCollection();
        nvCookies.Add("Code", userInfo.Code);
        nvCookies.Add("CompanyCode", userInfo.CompanyCode);
        nvCookies.Add("CompanyId", userInfo.CompanyId != null ? userInfo.CompanyId.ToString() : "");
        nvCookies.Add("CompanyName", HttpUtility.UrlEncode(userInfo.CompanyName));
        nvCookies.Add("DepartmentCode", userInfo.DepartmentCode);
        nvCookies.Add("Id", userInfo.Id);
        nvCookies.Add("OpenId", userInfo.OpenId);
        nvCookies.Add("RoleName", userInfo.RoleName);
        nvCookies.Add("Password", userInfo.Password);
        nvCookies.Add("IsAdministrator",userInfo.IsAdministrator.ToString());
        CookieHelper.AddCookie(Utils.CookieName, nvCookies);

        SetSession(userInfo);
        /* string password = SecretHelper.AESEncrypt(userInfo.Password);        
        HttpCookie httpCookie = new HttpCookie(Utils.CookieName);      
        httpCookie.Values[Utils.CookieUserName] = HttpUtility.UrlEncode(userInfo.UserName);
        if (SystemInfo.RememberPassword)
        {
            httpCookie.Values[Utils.CookiePassword] = password;
        }
        httpCookie.Values["Code"] = userInfo.Code;
        httpCookie.Values["CompanyCode"] = userInfo.CompanyCode;
        if (userInfo.CompanyId != null)
        {
            httpCookie.Values["CompanyId"] = userInfo.CompanyId.ToString();
        }
        else
        {
            httpCookie.Values["CompanyId"] = null;
        }
        httpCookie.Values["CompanyName"] = HttpUtility.UrlEncode(userInfo.CompanyName);
        httpCookie.Values["CurrentLanguage"] = userInfo.CurrentLanguage;
        httpCookie.Values["DepartmentCode"] = userInfo.DepartmentCode;
        if (userInfo.DepartmentId != null)
        {
            httpCookie.Values["DepartmentId"] = userInfo.DepartmentId.ToString();
        }
        else
        {
            httpCookie.Values["DepartmentId"] = null;
        }
        httpCookie.Values["DepartmentName"] = HttpUtility.UrlEncode(userInfo.DepartmentName);
        httpCookie.Values["Id"] = userInfo.Id;
        httpCookie.Values["IPAddress"] = userInfo.IPAddress;
        httpCookie.Values["IsAdministrator"] = userInfo.IsAdministrator.ToString();
        httpCookie.Values["OpenId"] = userInfo.OpenId;
        httpCookie.Values["RealName"] = HttpUtility.UrlEncode(userInfo.RealName);
        if (userInfo.RoleId != null)
        {
            httpCookie.Values["RoleId"] = userInfo.RoleId.ToString();
        }
        else
        {
            httpCookie.Values["RoleId"] = null;
        }
        httpCookie.Values["RoleName"] = HttpUtility.UrlEncode(userInfo.RoleName);
        httpCookie.Values["SecurityLevel"] = userInfo.SecurityLevel.ToString();
        httpCookie.Values["ServicePassword"] = userInfo.ServicePassword;
        httpCookie.Values["ServiceUserName"] = userInfo.ServiceUserName;
        httpCookie.Values["StaffId"] = userInfo.StaffId;
        httpCookie.Values["TargetUserId"] = userInfo.TargetUserId;
        httpCookie.Values["Themes"] = userInfo.Themes;
        httpCookie.Values["UserName"] = HttpUtility.UrlEncode(userInfo.UserName);
        httpCookie.Values["WorkgroupCode"] = userInfo.WorkgroupCode;
        if (userInfo.WorkgroupId != null)
        {
            httpCookie.Values["WorkgroupId"] = userInfo.WorkgroupId.ToString();
        }
        else
        {
            httpCookie.Values["WorkgroupId"] = null;
        }
        httpCookie.Values["WorkgroupName"] = HttpUtility.UrlEncode(userInfo.WorkgroupName);
        // 设置过期时间为1天
        DateTime dateTime = DateTime.Now;
        httpCookie.Expires = dateTime.AddDays(30);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
        */
    }
    #endregion


    //
    // 四 用OpenId登录部分
    //

    #region public static UserInfo LogOn(string openId)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="openId">当点登录识别码</param>
    public static UserInfo LogOn(string openId)
    {
        // 统一的登录服务
        string returnStatusCode = string.Empty;
        string returnStatusMessage = string.Empty;
        UserInfo userInfo = RDIFrameworkService.Instance.LogOnService.LogOnByOpenId(GetUserInfo(), openId, out returnStatusCode, out returnStatusMessage);
        // 检查身份
        if (returnStatusCode.Equals(StatusCode.OK.ToString()))
        {
            LogOn(userInfo, false);
        }
        return userInfo;
    }
    #endregion


    //
    // 五 用用户名密码登录部分
    //

    #region public static UserInfo LogOn(string userName, string password, bool checkUserPassword = true)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="checkUserPassword">是否要检查用户密码</param>
    public static UserInfo LogOn(string userName, string password, bool checkUserPassword)
    {
        var userManager = new PiUserManager(Utils.GetUserInfo());
        return userManager.LogOn(userName, password,string.Empty, false, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"], string.Empty, checkUserPassword);
    }
    #endregion

    #region public static UserInfo LogOn(string userName, string password, string permissionItemCode, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="openId">单点登录标识</param>
    /// <param name="permissionItemCode">权限编号</param>
    /// <param name="persistCookie">是否保存密码</param>
    /// <param name="formsAuthentication">表单验证，是否需要重定位</param>
    /// <param name="returnStatusCode"></param>
    /// <param name="returnStatusMessage"></param>
    /// <returns></returns>
    public static UserInfo LogOn(string userName, string password,string openId, string permissionItemCode, bool persistCookie, bool formsAuthentication, out string returnStatusCode, out string returnStatusMessage)
    {       
        // 登录服务
        UserInfo userInfo = RDIFrameworkService.Instance.LogOnService.UserLogOn(Utils.GetUserInfo(), userName, password,openId, false, out returnStatusCode, out returnStatusMessage);
        // 检查身份
        if (!returnStatusCode.Equals(StatusCode.OK.ToString())) return userInfo;
        var isAuthorized = true;
        // 用户是否有哪个相应的权限
        if (!string.IsNullOrEmpty(permissionItemCode))
        {
            isAuthorized = RDIFrameworkService.Instance.PermissionService.IsAuthorized(userInfo, permissionItemCode, null);
        }
        // 有相应的权限才可以登录
        if (isAuthorized)
        {
            if (persistCookie)
            {
                // 相对安全的方式保存登录状态
                // SaveCookie(userName, password);
                // 内部单点登录方式
                CookieUtils.SetCookie("OpenId", userInfo.OpenId);
                //SaveCookie(userInfo);
            }
            LogOn(userInfo, formsAuthentication);
        }
        else
        {
            returnStatusCode = StatusCode.LogOnDeny.ToString();
            returnStatusMessage = "访问被拒绝、您的账户没有后台管理访问权限。";
        }
        return userInfo;
    }
    #endregion

    #region public static void LogOn(UserInfo userInfo, bool formsAuthentication = false)
    /// <summary>
    /// 验证用户
    /// </summary>
    /// <param name="userInfo">登录</param>
    /// <param name="formsAuthentication">formsAuthentication</param>
    public static void LogOn(UserInfo userInfo, bool formsAuthentication )
    {
        // 检查身份
        if ((userInfo != null) && (!string.IsNullOrEmpty(userInfo.Id)))
        {
            SetSession(userInfo);
            if (formsAuthentication)
            {
                FormsAuthentication.RedirectFromLoginPage(CookieName, false);
            }
        }
        else
        {
            LogOut();
        }
    }
    #endregion


    //
    // 六 安全退出部分
    //

    #region public static void RemoveUserCookie()
    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void RemoveUserCookie()
    {
        // 清空cookie
        var httpCookie = new HttpCookie(CookieName);
        // 设置过期时间，1秒钟后删除cookie就不对了,得时间很长才可以服务器时间与客户时间的差距得考虑好
        httpCookie.Expires = new DateTime(1978, 05, 19);
        HttpContext.Current.Response.Cookies.Add(httpCookie);
    }
    #endregion

    #region public static void RemoveUserSession()
    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void RemoveUserSession()
    {
        // 用户信息清除
        HttpContext.Current.Session[SessionName] = null;
        // 模块菜单信息清除
        HttpContext.Current.Session["_DTModule"] = null;
    }
    #endregion

    #region public static void Logout()
    /// <summary>
    /// 退出登录部分
    /// </summary>
    public static void LogOut()
    {
        RDIFrameworkService.Instance.LogOnService.OnExit(UserInfo);

        // 清除Seesion对象
        RemoveUserSession();

        // 清空cookie
        RemoveUserCookie();
        // Session.Abandon();
        // 在此处放置用户代码以初始化页面
        FormsAuthentication.SignOut();
        // 重新定位到登录页面
        HttpContext.Current.Response.Redirect("../login.htm", true);
    }
    #endregion


    //
    //  七 用户修改密码部分
    //

    #region public static bool EmailExists(string email) 电子邮件是否存在
    /// <summary>
    /// 电子邮件是否存在
    /// </summary>
    /// <param name="email">邮件地址</param>
    /// <returns>存在</returns>
    public static bool EmailExists(string email)
    {
        bool returnValue = false;
        return returnValue;
    }
    #endregion

    #region public static bool EmailExists(string userId, string email) 是否已经被别人用了
    /// <summary>
    /// 是否已经被别人用了
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <param name="email">电子邮件地址</param>
    /// <returns>已经重复</returns>
    public static bool EmailExists(string userId, string email)
    {
        bool returnValue = false;
        return returnValue;
    }
    #endregion

    #region public static int SetPasswordByEmail(string email, string newPassword) 按邮件设置密码
    /// <summary>
    /// 按邮件设置密码
    /// </summary>
    /// <param name="email">邮件地址</param>
    /// <param name="newPassword">密码</param>
    /// <returns>影响行数</returns>
    public static int SetPasswordByEmail(string email, string newPassword)
    {
        int returnValue = 0;
        return returnValue;
    }
    #endregion

    #region private static int SetPassword(string userId, string newPassword) 更新用户的新密码
    /// <summary>
    /// 更新用户的新密码
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <param name="newPassword">新密码</param>
    /// <returns>影响行数</returns>
    private static int SetPassword(string userId, string newPassword)
    {
        int returnValue = 0;
        return returnValue;
    }
    #endregion

    #region private static string GetPassword(string userId) 获取密码
    /// <summary>
    /// 获取密码
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <returns>密码</returns>
    private static string GetPassword(string userId)
    {
        string returnValue = string.Empty;
        return returnValue;
    }
    #endregion

    #region public static int ChangePassword(UserInfo userInfo, string oldPassword, string newPassword, out string statusCode) 更新密码
    /// <summary>
    /// 更新密码
    /// </summary>
    /// <param name="oldPassword">原密码</param>
    /// <param name="newPassword">新密码</param>
    /// <param name="statusCode">返回状态码</param>
    /// <returns>影响行数</returns>
    public static int ChangePassword(UserInfo userInfo, string oldPassword, string newPassword, out string statusCode)
    {
        int returnValue = 0;
        statusCode = string.Empty;
        // 新密码是否允许为空
        if (!SystemInfo.EnableCheckPasswordStrength)
        {
            if (String.IsNullOrEmpty(newPassword))
            {
                statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                return returnValue;
            }
        }
        // 是否加密
        oldPassword = SecretHelper.AESEncrypt(oldPassword);
        newPassword = SecretHelper.AESEncrypt(newPassword);

        // 判断输入原始密码是否正确
        // 密码错误
        if (!GetPassword(userInfo.Id).Equals(oldPassword))
        {
            statusCode = StatusCode.OldPasswordError.ToString();
            return returnValue;
        }
        // 更改密码
        returnValue = SetPassword(userInfo.Id, newPassword);
        if (returnValue == 1)
        {
            statusCode = StatusCode.ChangePasswordOK.ToString();
        }
        else
        {
            // 数据可能被删除
            statusCode = StatusCode.ErrorDeleted.ToString();
        }
        return returnValue;
    }
    #endregion


    //
    // 八 读取用户信息，更新用户信息部分
    //

    #region public static PiUserEntity GetUser(string userId) 获取用户信息
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="userId">用户主键</param>
    /// <returns>用户信息</returns>
    public static PiUserEntity GetUser(string userId)
    {
        PiUserEntity userEntity = null;
        if (!string.IsNullOrEmpty(userId))
        {
            // 这里需要打开用户中心的数据
            var dbHelper = new SqlProvider(RDIFrameworkDbConection);
            dbHelper.Open();

            var parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(PiUserTable.FieldId, userId));
            DataTable dtBaseUser = DbCommonLibary.GetDT(dbHelper, PiUserTable.TableName, parameters, 0, null, null);
            if (dtBaseUser.Rows.Count > 0)
            {
                userEntity = BaseEntity.Create<PiUserEntity>(dtBaseUser); 
                userEntity.WorkCategory = dtBaseUser.Rows[0][PiUserTable.FieldWorkCategory].ToString();
                userEntity.QICQ = dtBaseUser.Rows[0][PiUserTable.FieldQICQ].ToString();
                userEntity.UserAddress = dtBaseUser.Rows[0][PiUserTable.FieldUserAddress].ToString();
            }
            dbHelper.Close();
        }
        return userEntity;
    }
    #endregion

    #region public static int UpdateUser(PiUserEntity userEntity) 更新用户信息，若不存在当前用户，那就新增一条这样数据库中的冗余相对少一些，更新自己信息的，才会保存到网上商城这边。
    /// <summary>
    /// 更新用户信息，若不存在当前用户，那就新增一条
    /// 这样数据库中的冗余相对少一些，更新自己信息的，才会保存到网上商城这边。
    /// </summary>
    /// <param name="userEntity">用户信息</param>
    /// <returns>影响行数</returns>
    public static int UpdateUser(PiUserEntity userEntity)
    {
        int returnValue = 0;
        return returnValue;
    }
    #endregion

    //
    // 九 忘记密码部分
    //

    #region private static string GetSendPasswordBody(PiUserEntity userEntity, string password) 获取忘记密码邮件主题内容部分
    /// <summary>
    /// 获取忘记密码邮件主题内容部分
    /// </summary>
    /// <param name="userEntity">用户实体</param>
    /// <param name="password">密码</param>
    /// <returns>邮件主题</returns>
    private static string GetSendPasswordBody(PiUserEntity userEntity, string password)
    {
        var htmlBody = new StringBuilder();
        htmlBody.Append("<body style=\"font-size:10pt\">");
        htmlBody.Append("<div style=\"font-size:10pt; font-weight:bold\">尊敬的用户 " + userEntity.UserName + " 您好：</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 您的新密码是：<font size=\"3\" color=\"#6699cc\">" + password + "</font></div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 请重新登录系统 <a href='http://www.cnblogs.com/RDIFramework/'>立即登录.NET快速开发、整合框架</a></div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 如有任何疑问，欢迎致.NET快速开发、整合框架客服热线：15108937790，我们将热情为您解答。</div>");
        htmlBody.Append("<br>");
        htmlBody.Append("<div style=\"text-align:center\">.NET快速开发、整合框架 用户服务中心</div>");
        htmlBody.Append("<div style=\"text-align:center\">" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日</div></body>");
        return htmlBody.ToString();
    }
    #endregion

    #region private static bool SendPassword(BaseUserEntity userEntity) 发送密码给指定的邮箱
    /// <summary>
    /// 发送密码给指定的邮箱
    /// </summary>
    /// <param name="userEntity">用户实体</param>
    /// <returns>成功发送邮件</returns>
    private static bool SendPassword(PiUserEntity userEntity)
    {
        bool returnValue = false;
        IDbProvider dbProvider = new SqlProvider(RDIFrameworkDbConection);
        UserInfo userInfo = null;
        try
        {
            string password = RandomHelper.GetRandom(100000, 999999).ToString();
            using (var mailMessage = new System.Net.Mail.MailMessage())
            {
                // 接收人邮箱地址
                mailMessage.To.Add(new System.Net.Mail.MailAddress(userEntity.Email));
                mailMessage.Body = GetSendPasswordBody(userEntity, password);
                mailMessage.From = new System.Net.Mail.MailAddress("RDIFramework@126.com", ".NET快速开发、整合框架");
                mailMessage.BodyEncoding = Encoding.GetEncoding("GB2312");
                mailMessage.Subject = ".NET快速开发、整合框架 新密码。";
                mailMessage.IsBodyHtml = true;
                var smtpclient = new System.Net.Mail.SmtpClient("SMTP.126.COM", 25);
                smtpclient.Credentials = new System.Net.NetworkCredential("RDIFramework@126.com", "abcd");
                smtpclient.EnableSsl = false;
                smtpclient.Send(mailMessage);
                returnValue = true;
                // 修改用户的密码
                // 用户数据库进行差找用户操作
                dbProvider.Open();
                PiUserManager userManager = new PiUserManager(dbProvider);
                userInfo = userManager.ConvertToUserInfo(userEntity);
                userManager.SetParameter(userInfo);
                // 密码进行加密，读取网站的密钥
                password = userManager.EncryptUserPassword(password);
                userManager.SetPassword(userEntity.Id.ToString(), password);
            }
        }
        catch (System.Exception exception)
        {
            // 若有异常，应该需要保存异常信息
            CiExceptionManager.LogException(dbProvider, userInfo, exception);
            returnValue = false;
        }
        finally
        {
            dbProvider.Close();
        }
        return returnValue;
    }
    #endregion

    #region public static bool SendPassword(string userName, out string returnStatusCode, out string returnStatusMessage) 用户忘记密码，发送密码
    /// <summary>
    /// 用户忘记密码，发送密码
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="returnStatusCode">状态码</param>
    /// <param name="returnStatusMessage">状态信息</param>
    /// <returns>成功发送密码</returns>
    public static bool SendPassword(string userName, out string returnStatusCode, out string returnStatusMessage)
    {
        bool returnValue = false;
        // 1.用户是否找到？默认是未找到用户状态
        returnStatusCode = StatusCode.UserNotFound.ToString();
        returnStatusMessage = "用户未找到，请重新输入用户名。";
        // 用户数据库进行差找用户操作
        IDbProvider dbProvider = new SqlProvider(RDIFrameworkDbConection);
        dbProvider.Open();
        PiUserManager userManager = new PiUserManager(dbProvider);
        // 2.用户是否已被删除？
        var parameters = new List<KeyValuePair<string, object>>();
        parameters.Add(new KeyValuePair<string, object>(PiUserTable.FieldUserName, userName));
        parameters.Add(new KeyValuePair<string, object>(PiUserTable.FieldDeleteMark, 0));
        var userEntity = BaseEntity.Create<PiUserEntity>(userManager.GetDT(parameters, 0, string.Empty));     
        dbProvider.Close();
        // 是否已找到了此用户
        if (userEntity != null && !string.IsNullOrEmpty(userEntity.Id.ToString()))
        {
            // 3.用户是否有效的？
            if (userEntity.Enabled == 1)
            {
                if (!string.IsNullOrEmpty(userEntity.Email))
                {
                    // 5.重新产生随机密码？
                    // 6.发送邮件给用户？
                    // 7.重新设置用户密码？
                    returnValue = SendPassword(userEntity);
                    returnStatusCode = StatusCode.OK.ToString();
                    returnStatusMessage = "新密码已发送到您的注册邮箱" + userEntity.Email + "。";
                }
                else
                {
                    // 4.用户是否有邮件账户？
                    returnStatusCode = StatusCode.UserNotEmail.ToString();
                    returnStatusMessage = "用户没有电子邮件地址，无法从新设置密码，请您及时联系系统管理员。";
                }
            }
            else
            {
                if (userEntity.Enabled == 0)
                {
                    returnStatusCode = StatusCode.UserLocked.ToString();
                    returnStatusMessage = "用户被锁定，不允许设置密码。";
                }
                else
                {
                    returnStatusCode = StatusCode.UserNotActive.ToString();
                    returnStatusMessage = "用户还未被激活，不允许设置密码。";
                }
            }
        }
        return returnValue;
    }
    #endregion        
}
