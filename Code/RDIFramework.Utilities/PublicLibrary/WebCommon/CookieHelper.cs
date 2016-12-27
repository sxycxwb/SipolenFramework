/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-10-12 16:22:57
 ******************************************************************************/
using System;
using System.Collections.Specialized;
using System.Web;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// CookieHelper
    /// 操作Cookie的帮助类 
    /// </summary>
    public class CookieHelper
    {
        #region public static bool WriteCookie(string CookieName, NameValueCollection Nvc, int days, string Domain) 为Cookie赋值方法
        /// <summary>
        /// 为Cookie赋值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="Nvc">Cookie值集合</param>
        /// <param name="days">Cookie日期  0 为无时间限制。浏览器关闭就结束</param>
        /// <param name="Domain">Cookie站点</param>
        /// <returns>返回布尔值</returns>
        public static bool WriteCookie(string CookieName, NameValueCollection Nvc, int days, string Domain)
        {
            bool BoolReturnValue = false;
            if (Nvc != null && !string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                HttpCookie httpCookie = new HttpCookie(CookieName);
                for (int i = 0; i < Nvc.Count; i++)
                {
                    httpCookie.Values.Add(Nvc.GetKey(i), HttpUtility.UrlEncode(Nvc.Get(i))); //将值添入Cookie中
                }
                if (days > 0)
                {
                    httpCookie.Expires = DateTime.Now.AddDays(days);  //设置Cookie有效期
                }

                if (!string.IsNullOrEmpty(Domain)) //判断Cookie站点有效
                {
                    httpCookie.Domain = Domain; //设置Cookie站点
                }
                HttpContext.Current.Response.AppendCookie(httpCookie); //添加Cookie
                BoolReturnValue = true;
            }
            return BoolReturnValue;
        }
        /// <summary>
        /// 不限制日期的写cookies 江文海修改
        /// </summary>
        /// <param name="CookieName">cookie名称</param>
        /// <param name="Nvc">集合</param>
        /// <returns></returns>
        public static bool WriteCookieNoDay(string CookieName, NameValueCollection Nvc)
        {
            bool BoolReturnValue = false;
            if (Nvc != null && !string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                HttpCookie httpCookie = new HttpCookie(CookieName);
                for (int i = 0; i < Nvc.Count; i++)
                {
                    httpCookie.Values.Add(Nvc.GetKey(i), Nvc.Get(i)); //将值添入Cookie中
                }
                HttpContext.Current.Response.AppendCookie(httpCookie); //添加Cookie
                BoolReturnValue = true;
            }
            return BoolReturnValue;
        }
        /**/
        /// <summary>
        /// 为Cookie赋值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="Nvc">Cookie值集合</param>
        /// <param name="days">Cookie日期</param>
        /// <returns>返回布尔值</returns>
        public static bool WriteCookie(string CookieName, NameValueCollection Nvc, int days)
        {
            return WriteCookie(CookieName, Nvc, days, null);
        }
        /**/
        /// <summary>
        /// 为Cookie赋值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="Nvc">Cookie值集合</param>
        /// <returns>返回布尔值</returns>
        public static bool WriteCookie(string CookieName, NameValueCollection Nvc)
        {
            return WriteCookie(CookieName, Nvc, 1, null);
        }
        #endregion

        #region public static bool AddCookie(string CookieName, NameValueCollection Nvc) 添加Cookie值
        /// <summary>
        /// 添加Cookie值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="Nvc">Cookie值集合</param>
        /// <returns></returns>
        public static bool AddCookie(string CookieName, NameValueCollection Nvc)
        {
            bool BoolReturnValue = false;
            if (Nvc != null && !string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                for (int i = 0; i < Nvc.Count; i++)
                {
                    HttpContext.Current.Request.Cookies[CookieName].Values.Add(Nvc.GetKey(i), Nvc.Get(i));//添加Cookie;
                    HttpContext.Current.Response.Cookies[CookieName].Values.Add(Nvc.GetKey(i), Nvc.Get(i));//添加Cookie;
                }
            }
            return BoolReturnValue;
        }
        #endregion

        #region public static bool UpdateCookie(string CookieName, NameValueCollection Nvc) 更新Cookie
        /// <summary>
        /// 更新Cookie
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="Nvc">Cookie值集合</param>
        /// <returns>bool</returns>
        public static bool UpdateCookie(string CookieName, NameValueCollection Nvc)
        {
            bool BoolReturnValue = false;
            if (Nvc != null && !string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                HttpCookie httpCookie = new HttpCookie(CookieName);
                NameValueCollection NonceNvc = HttpContext.Current.Request.Cookies[CookieName].Values; //得到已有的Cookie值集合
                if (NonceNvc != null) //判断Cookie值集合是否为空
                {
                    string CookieValue = string.Empty;
                    //------------------------循环判断Cookie值是否存在于新Cookie中，如果存在就予以更新-----------------------
                    for (int i = 0; i < NonceNvc.Count; i++)
                    {
                        CookieValue = NonceNvc.Get(i);
                        for (int y = 0; y < Nvc.Count; y++)
                        {
                            if (NonceNvc.GetKey(i) == Nvc.GetKey(y))
                            {
                                if (CookieValue != Nvc.Get(y))
                                {
                                    CookieValue = Nvc.Get(y);
                                }
                                break;
                            }
                        }
                        httpCookie.Values.Add(NonceNvc.GetKey(i), CookieValue); //不存在于原Cookie的值 ，被新加入
                        CookieValue = string.Empty;
                    }
                    //---------------------------------------------------------------------------------------------------------
                    HttpContext.Current.Response.AppendCookie(httpCookie); //加入Cookie
                    BoolReturnValue = true;
                }
            }
            return BoolReturnValue;
        }
        #endregion

        #region public static NameValueCollection GetCookie(string CookieName) 得到Cookie值集合
        /// <summary>
        /// 得到Cookie值集合
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <returns>返回NameValueCollection集合</returns>
        public static NameValueCollection GetCookie(string CookieName)
        {
            NameValueCollection Nvc = new NameValueCollection();
            if (!string.IsNullOrEmpty(CookieName) && HttpContext.Current.Response.Cookies[CookieName] != null) //判断Cookie是否存在
            {
                Nvc = HttpContext.Current.Response.Cookies[CookieName].Values; //得到Cookie值集合
            }
            return Nvc;
        }
        #endregion

        #region public static bool DeleteCookie(string CookieName, string CookieDomain) 删除Cookie
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="CookieName">cookie的值</param>
        /// <param name="CookieDomain">cookie的域</param>
        /// <returns></returns>
        public static bool DeleteCookie(string CookieName, string CookieDomain)
        {
            bool BoolReturnValue = false;
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
            if (httpCookie != null)  //如果Cookie存在
            {
                if (!string.IsNullOrEmpty(CookieDomain))
                {
                    httpCookie.Domain = CookieDomain;
                }
                httpCookie.Expires = DateTime.Now.AddDays(-30); //来他个负30天，看他怎么存在
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                BoolReturnValue = true;
            }
            return BoolReturnValue;
        }
        /**/
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <returns>布尔值</returns>
        public static bool DeleteCookie(string CookieName)
        {
            return DeleteCookie(CookieName, null);
        }
        #endregion

        #region public static string GetSingleValue(string CookieName, string KeyName) 得到单独一条Cookie的值
        /// <summary>
        /// 得到单独一条Cookie的值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="KeyName">Key名称</param>
        /// <returns>返回string</returns>
        public static string GetSingleValue(string CookieName, string KeyName)
        {
            string StrReturnValue = string.Empty;
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
            if (httpCookie != null)  //如果Cookie存在
            {
                StrReturnValue = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[CookieName].Values[KeyName]); //得到指定Key的Value
            }
            return StrReturnValue;
        }
        /**/
        /// <summary>
        /// 得到服务器端单独一条Cookie的值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="KeyName">Key名称</param>
        /// <returns>返回string</returns>
        public static string GetSingleValueFromServer(string CookieName, string KeyName)
        {
            string StrReturnValue = string.Empty;
            HttpCookie httpCookie = HttpContext.Current.Response.Cookies[CookieName];
            if (httpCookie != null)  //如果Cookie存在
            {
                StrReturnValue = HttpContext.Current.Response.Cookies[CookieName].Values[KeyName]; //得到指定Key的Value
            }
            return StrReturnValue;
        }

        #endregion

        #region public static bool UpdateSingleValue(string CookieName, string KeyName, string Value) 更新单独一条Cookie的值
        /// <summary>
        /// 更新单独一条Cookie的值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="KeyName">Key名称</param>
        /// <param name="Value">值</param>
        /// <returns>返回布尔值</returns>
        public static bool UpdateSingleValue(string CookieName, string KeyName, string Value)
        {
            bool BoolReturnValue = false;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(KeyName, Value);
            if (!string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
                if (httpCookie != null)
                {
                    if (HttpContext.Current.Request.Cookies[CookieName].Values[KeyName] != null)
                    {
                        BoolReturnValue = UpdateCookie(CookieName, nvc);
                    }
                    else
                    {
                        BoolReturnValue = AddCookie(CookieName, nvc);
                    }
                }
                else
                {
                    BoolReturnValue = WriteCookie(CookieName, nvc);
                }
            }
            return BoolReturnValue;
        }
        #endregion

        #region public static bool AddSingleCookie(string CookieName, string KeyName, string Value) 添加单独的一条Cookie值
        /// <summary>
        /// 添加单独的一条Cookie值
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <param name="KeyName">Key名称</param>
        /// <param name="Value">值</param>
        /// <returns></returns>
        public static bool AddSingleCookie(string CookieName, string KeyName, string Value)
        {
            bool BoolReturnValue = false;
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(KeyName, Value);
            if (!string.IsNullOrEmpty(CookieName)) //判断是否能建Cookie
            {
                HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
                if (httpCookie != null)
                {
                    if (HttpContext.Current.Request.Cookies[CookieName].Values[KeyName] != null)
                    {
                        BoolReturnValue = UpdateCookie(CookieName, nvc);
                    }
                    else
                    {
                        BoolReturnValue = AddCookie(CookieName, nvc);
                    }
                }
                else
                {
                    BoolReturnValue = WriteCookie(CookieName, nvc);
                }
            }
            return BoolReturnValue;
        }
        #endregion

        #region public static bool HasCookie(string CookieName) 判断是否存在Cookie表
        /// <summary>
        /// 判断是否存在Cookie表
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <returns></returns>
        public static bool HasCookie(string CookieName)
        {
            bool BoolReturnValue = false;
            if (HttpContext.Current.Request.Cookies[CookieName] != null)
                BoolReturnValue = true;
            return BoolReturnValue;
        }
        #endregion
    }
}
