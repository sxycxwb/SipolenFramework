using System;
using System.Collections.Generic;
using System.Text;

namespace RDIFramework.WebCommon
{
    public class MessageBox
    {
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "message", "<script language='javascript' defer>alert(\"" + msg.ToString() + "\");</script>");
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "message", Builder.ToString());

        }

        /// <summary>
        /// 显示消息提示对话框，并打开指定窗口(该方法必须引用ControlHelper.js文件)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void ShowOpenAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("ShowOpen('{0}');", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "message", Builder.ToString());

        }
        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="url">跳转的目标URL</param>
        public static void Redirect(System.Web.UI.Page page, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "message", Builder.ToString());
        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "message", "<script language='javascript' defer>" + script + "</script>");
        }
        /// <summary>
        /// 弹出自定义信息，并跳转到目标URL
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="alertstring">提示信息</param>
        /// <param name="locationhref">跳转的目标URL地址</param>
        public static void ResponseScript(System.Web.UI.Page page, string alertstring, string locationhref)
        {
            page.Response.Write("<script type='text/javascript'>alert('" + alertstring + "');location.href='" + locationhref + "';</script>");
        }

        /// <summary>
        /// 使用HIALERT jQuery 弹出插件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="alertstring">内容</param>
        /// <param name="title">标题 </param>
        public static void HiAlert(System.Web.UI.Page page, string alertstring, string title)
        {
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "hialertmsg", "<script type='text/javascript'>hiAlert('" + alertstring + "','"+title+"');</script>");
        }

        /// <summary>
        /// 使用HIALERT jQuery 弹出插件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="alertstring">内容</param>
        /// <param name="title">标题 </param>
        /// <param name="function">方法串 </param>
        public static void HiAlert(System.Web.UI.Page page, string alertstring, string title,string function)
        {            
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "hialertmsg", "<script type='text/javascript'>hiAlert('" + alertstring + "','" + title + "',function(e){if(e){"+function+"}});</script>");
        }

        /// <summary>
        /// 使用HIALERT jQuery 弹出插件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="alertstring">内容</param>
        public static void HiAlert(System.Web.UI.Page page, string alertstring)
        {
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), Guid.NewGuid().ToString(), "document.body.onload=function(){hiAlert('" + alertstring + "','系统提示');}",true);
        }

        /// <summary>
        /// 向body页面的onload事件中加入弹出信息
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="alertstring">要弹出的信息</param>
        public static void HiBodyAlert(System.Web.UI.Page page, string alertstring)
        {
            if (alertstring == "") return;
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), Guid.NewGuid().ToString(), "document.body.onload=function(){hiAlert('" + alertstring + "','提示');}", true);
        }

        public static void HiAlertThickboxclose(System.Web.UI.Page page, string alertstring)
        {
            page.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), Guid.NewGuid().ToString(), "self.parent.hiAlert('" + alertstring + "','系统提示',function(){self.parent.tb_remove();});", true);
        }
    }
}
