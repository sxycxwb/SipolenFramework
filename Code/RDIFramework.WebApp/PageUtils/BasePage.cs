using System;
using System.Web;
using System.Web.UI;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;

/// <summary>
/// 页面基类
/// </summary>
public partial class BasePage : System.Web.UI.Page
{
    public string CurrentID { get; private set; }

    /// <summary>
    /// 用户锁
    /// </summary>
    public static readonly object UserLock = new object();

    /// <summary>
    /// 每页显示多少条记录
    /// </summary>
    protected int PageSize = 30;

    /// <summary>
    /// 单点登录唯一识别标识
    /// </summary>
    public string OpenId = string.Empty;


    private IDbProvider rdiFrameworkDbProvider = null;
    /// <summary>
    /// RDIFramework.NET框架数据库
    /// </summary>
    protected IDbProvider RDIFrameworkDbProvider
    {
        get {
            return rdiFrameworkDbProvider ?? (rdiFrameworkDbProvider =DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType,SystemInfo.RDIFrameworkDbConectionString));
        }
    }

    /// <summary>
    /// 创建工具栏按钮
    /// </summary>
    /// <returns></returns>
    public virtual string BuildToolBarButtons()
    {
        return string.Empty;
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    private UserInfo userInfo = null;

    /// <summary>
    /// 当前操作员信息对象
    /// </summary>
    public UserInfo UserInfo
    {
        get
        {
            this.userInfo = Utils.UserInfo;
            return this.userInfo;
        }
        set
        {
            this.userInfo = value;
        }
    }

    /// <summary>
    /// 权限控制
    /// </summary>
    private void CheckPermission()
    {    
        if (string.IsNullOrEmpty(CookieUtils.GetCookieValue("OpenId")))
        {
            Response.Redirect("/login.htm");
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        this.CheckPermission();
    }  

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.CurrentID = Request.QueryString["Id"];
        if (!IsPostBack)
        {                
            this.GetParamterOpenId();
        }
    }
       
    /// <summary>
    ///所有页面基础类的，活得单点登录唯一识别标识的方法
    /// </summary>
    public void GetParamterOpenId()
    {
        if (Page.Request["OpenId"] == null) return;
        // 读取参数
        this.OpenId = Page.Request["OpenId"].ToString();
        if (!Utils.UserIsLogOn())
        {
            this.UserInfo = Utils.LogOn(this.OpenId);
        }
    }
       

    /// <summary>
    /// 记录异常信息
    /// </summary>
    /// <param name="exception">异常信息实体</param>
    public void LogException(Exception exception)
    {
        CiExceptionManager.LogException(this.RDIFrameworkDbProvider, this.UserInfo, exception);
    }

    /// <summary>
    /// 取得序列号,主键为非自增时使用
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <returns>序列</returns>
    protected string GetSequence(string tableName)
    {
        string sequence = string.Empty;
        var manager = new CiSequenceManager(this.RDIFrameworkDbProvider, true);
        sequence = manager.GetSequence(tableName);
        return sequence;
    }

    /// <summary>
    /// 皮肤
    /// </summary>
    public string Theme
    {
        /*
        get
        {
            if (HttpContext.Current.Session["theme"] == null)
            {
                var cook = HttpContext.Current.Request.Cookies["theme"];
                if (cook == null)
                {
                    UserInfo vUser = Utils.UserInfo;
                    var tmpTheme = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id, "WebTheme");
                    return tmpTheme ?? "default";
                }
                HttpContext.Current.Session["theme"] = cook.Value;
                return cook.Value;
            }
            else
            {
                return HttpContext.Current.Session["theme"] as string;
            }
        }
        set
        {
            HttpContext.Current.Session["theme"] = value;
        }
         */
        get
        {
            UserInfo vUser = Utils.UserInfo;
            var tmpTheme = "default";
            if (vUser != null)
            {
                tmpTheme = RDIFrameworkService.Instance.ParameterService.GetParameter(vUser, "User", vUser.Id, "WebTheme");
            }
            if (string.IsNullOrEmpty(tmpTheme)) 
            {
                tmpTheme = "default";
            }
            HttpContext.Current.Session["theme"] = tmpTheme;

            //写Cookie让Desktop.html界面调用
            HttpCookie cookie = HttpContext.Current.Request.Cookies["theme"];
            if (cookie == null)
            {
                cookie = new HttpCookie("theme");
            }
            cookie.Value = tmpTheme;
            HttpContext.Current.Response.AppendCookie(cookie);

            return tmpTheme;
        }
        set
        {
            HttpContext.Current.Session["theme"] = value;
        }
    }

    protected override void OnError(EventArgs e)
    {
        HttpContext ctx = HttpContext.Current;
        //ctx.Response.Redirect("~/msg/error.htm");
        string absolutePath = ctx.Request.Url.AbsolutePath.ToLower();
        string msg = "抱歉发生错误，纯属意外，请重新登录试试吧！ ";
        msg += " <a href='../login.htm'>登新登录</a>";           
        ctx.Response.Write(msg);
        ctx.Response.End();
    }

    #region JS提示

    /// <summary>
    /// 添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    protected void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }

    /// <summary>
    /// 带回传函数的添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    /// <param name="callback">JS回调函数</param>
    protected void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }

    /// <summary>
    /// 网页弹出提示对话框
    /// </summary>
    /// <param name="p">网页</param>
    /// <param name="strMsg">提示信息</param>
    protected void  ShowMessage(Page p, string strMsg)
    {
        if (!p.IsStartupScriptRegistered("hello"))
        {
            p.RegisterStartupScript("hello", "<script>alert('" + strMsg + "')</script>");
        }
    }
    #endregion
}
