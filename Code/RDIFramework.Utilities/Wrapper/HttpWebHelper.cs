//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 准备POST
    /// </summary>
    /// <param name="httpRequest"></param>
    public delegate void OnGetPostReady(HttpWebRequest httpRequest);

    /// <summary>
    /// 准备取回应
    /// </summary>
    /// <param name="httpRequest"></param>
    public delegate void OnGetResponseReady(HttpWebRequest httpRequest);

    /// <summary>
    /// HttpWebHelper
    /// 
    /// <author>
    ///     <name>XuWangBin</name>
    ///     <QQ>80368704</QQ>
    ///     <Email>80368704@qq.com</Email>
    /// </author>
    /// </summary>
    public class HttpWebHelper
    {
        protected HttpWebRequest httpRequest;
        protected HttpWebResponse httpResponse;
        protected CookieContainer cookieContainer;
        protected CredentialCache credentialCache;
        protected bool certificatedMode = false;
        protected string certFilepath = string.Empty;
        public OnGetPostReady OnGetPostReadyHandler = null;
        public OnGetPostReady OnGetResponseReadyHandler = null;
        protected readonly int DEFAULT_BUFFER_SIZE = 4096;
        public WebProxy webProxySrv = null;
        private static readonly int MyConnectionLimit = 300;

        public bool CheckGotoRecv
        {
            get;
            set;
        }

        public bool DoBetIsGotoRecv
        {
            get;
            set;
        }

        public bool LastAccessError
        {
            private set;
            get;
        }

        /// <summary>
        /// 当前自动转向后的url
        /// </summary>
        public string CurrentUrl
        {
            private set;
            get;
        }

        public string CurrentLocation
        {
            private set;
            get;
        }

        public string CurSetCookie
        {
            set;
            get;
        }

        public string CurSetCookie2
        {
            set;
            get;
        }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public HttpWebHelper()
        {
            this.cookieContainer = new CookieContainer();
            ServicePointManager.DefaultConnectionLimit = MyConnectionLimit;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.MaxServicePointIdleTime = 10000;
        }

        /// <summary>
        /// 代理参数构造器
        /// </summary>
        /// <param name="wp"></param>
        public HttpWebHelper(WebProxy wp)
            : this()
        {
            this.webProxySrv = wp;
        }

        /// <summary>
        /// 需要基本认证的构造器
        /// </summary>
        /// <param name="cred"></param>
        public HttpWebHelper(bool cred)
            : this()
        {
            this.certificatedMode = cred;
        }

        public HttpWebHelper(bool cred, WebProxy wp)
            : this()
        {
            this.certificatedMode = cred;
            this.webProxySrv = wp;
        }

        /// <summary>
        /// 基本认证和证书,refer页面
        /// </summary>
        /// <param name="cred"></param>
        /// <param name="certFilepath"></param>
        public HttpWebHelper(bool cred, string certFilepath)
            : this(cred)
        {
            this.certFilepath = certFilepath;
        }

        public HttpWebHelper(bool cred, WebProxy wp, string certFilepath)
            : this(cred, wp)
        {
            this.certFilepath = certFilepath;
        }

        /// <summary>
        /// 提供批量用户名和密码的构造器
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public HttpWebHelper(string uri, string method, string username, string password)
            : this(true)
        {
            this.credentialCache = new CredentialCache();
            this.credentialCache.Add(new Uri(uri), method, new NetworkCredential(username, password));
        }

        /// <summary>
        /// 安全询问回调函数,直接同意
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        private void SetHttpRequestOptions_Accept(string url, string method, CookieCollection cc, string referUrl, bool nocache, DecompressionMethods dm, string httpAccept)
        {
            this.SetHttpRequestOptions(url, method, cc, referUrl, nocache, dm);
            this.httpRequest.Accept = httpAccept;
        }

        /// <summary>
        /// 设置HttpWebRequest对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="cc"></param>
        /// <param name="referUrl"></param>
        /// <param name="nocache"></param>
        /// <param name="dm"></param>
        private void SetHttpRequestOptions(string url, string method, CookieCollection cc, string referUrl, bool nocache, DecompressionMethods dm)
        {
            httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.UnsafeAuthenticatedConnectionSharing = true;
            httpRequest.ServicePoint.ConnectionLimit = MyConnectionLimit;

            if (null != this.webProxySrv) httpRequest.Proxy = this.webProxySrv;

            if (this.certificatedMode && url.ToLower().Substring(0, 5).Equals("https"))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);

                if (null == this.credentialCache)
                    httpRequest.UseDefaultCredentials = true;
                else
                    httpRequest.Credentials = this.credentialCache;

                if (!string.IsNullOrEmpty(this.certFilepath))
                    httpRequest.ClientCertificates.Add(X509Certificate.CreateFromCertFile(this.certFilepath));
            }

            httpRequest.CookieContainer = this.cookieContainer;
            if (!string.IsNullOrEmpty(referUrl)) httpRequest.Referer = referUrl;
            httpRequest.AutomaticDecompression = dm;
            httpRequest.ServicePoint.Expect100Continue = false;
            httpRequest.ServicePoint.UseNagleAlgorithm = false;
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            // httpRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
            // httpRequest.AllowWriteStreamBuffering = true; 默认值就是true
            // httpRequest.AllowAutoRedirect = true; 默认值就是true
            httpRequest.Method = method;
            httpRequest.Timeout = 30000;//Convert.ToInt32(ConfigurationManager.AppSettings["HTTP_REQUEST_TIMEOUT"]);
            // 读写超时
            //httpRequest.ReadWriteTimeout = ApplicationConfig.HTTP_REQUEST_TIMEOUT;
            // httpRequest.MaximumAutomaticRedirections = 50; 默认值就是50
            httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; .NET4.0C; .NET4.0E)";
            httpRequest.Headers.Add("Accept-Language", "zh-CN");
            // httpRequest.Headers.Add("UA-CPU", "x86");
            httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");


            if (nocache)
            {
                httpRequest.Headers.Add("Cache-Control", "no-cache");
                //httpRequest.Headers.Add("Pragma", "no-cache");
            }

            if (null != cc) httpRequest.CookieContainer.Add(cc);

            // 回调发起请求前事件
            if (null != this.OnGetPostReadyHandler)
            {
                try
                {
                    this.OnGetPostReadyHandler(this.httpRequest);
                    //Logger.WriteError("KeepAlive = " + this.httpRequest.KeepAlive.ToString());
                }
                catch (System.Exception ex)
                {
                    this.LastAccessError = true;
                    LogHelper.WriteLog(ex);
                }
            }
        }

        private void SetHttpRequestOptions(string url, string method, CookieCollection cc, string referUrl, string httpAccept)
        {
            this.SetHttpRequestOptions_Accept(url, method, cc, referUrl, false, DecompressionMethods.GZip | DecompressionMethods.Deflate, httpAccept);
        }

        /// <summary>
        /// 重新设置某些成员
        /// </summary>
        private void ManualResetMember()
        {
            this.cookieContainer = httpRequest.CookieContainer;
            this.CurrentUrl = httpRequest.Address.OriginalString;
            this.CurrentLocation = httpResponse.Headers["Location"];
        }

        public MemoryStream GetMemoryStream(string url, string method, CookieCollection cc, string referUrl, string httpAccept)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                this.SetHttpRequestOptions(url, method, cc, referUrl, "*/*");
                this.httpRequest.Accept = httpAccept;
                this.httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                // 是否收到响应
                if (!this.httpRequest.HaveResponse)
                {
                    this.httpResponse.Close();
                    this.httpRequest.Abort();
                    return ms;
                }

                this.ManualResetMember();

                if (null != this.OnGetResponseReadyHandler)
                {
                    try
                    {
                        this.OnGetResponseReadyHandler(this.httpRequest);
                    }
                    catch (System.Exception ex)
                    {
                        this.LastAccessError = true;
                        LogHelper.WriteLog(ex);
                    }
                }

                this.DoBetIsGotoRecv = true;

                Stream sm = httpResponse.GetResponseStream();
                if (null != sm && sm.CanRead)
                {
                    //int readBytes = 0;
                    //byte[] buffer = new byte[DEFAULT_BUFFER_SIZE];
                    //while ((readBytes = sm.Read(buffer, 0, buffer.Length)) != 0)
                    //{
                    //    ms.Write(buffer, 0, readBytes);
                    //}

                    BinaryReader br = new BinaryReader(sm);
                    byte[] bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    while (null != bytes && bytes.Length != 0)
                    {
                        ms.Write(bytes, 0, bytes.Length);
                        bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    }
                    br.Close();
                }

                if (httpResponse.Headers["Set-Cookie"] != null)
                {
                    this.CurSetCookie = httpResponse.Headers["Set-Cookie"].ToString();
                }

                var aa = httpResponse.Cookies;

                //if (httpResponse.Headers.Get("Set-Cookie") != null)
                //{
                //    this.CurSetCookie = httpResponse.Headers["Set-Cookie"].ToString();
                //}

                httpResponse.Close();
                if (null != sm) sm.Close();

                // 非常重要,回到开头
                ms.Seek(0, SeekOrigin.Begin);
            }
            catch (System.Exception ex)
            {
                this.LastAccessError = true;
                LogHelper.WriteLog(ex);
                if (null != httpRequest) httpRequest.Abort();
            }

            return ms;
        }




        public MemoryStream GetMemoryStream(string url, string method, CookieCollection cc, string referUrl, string httpAccept,
            out CookieCollection ccOut)
        {
            MemoryStream ms = new MemoryStream();
            CookieCollection cctemp = new CookieCollection();
            try
            {
                this.SetHttpRequestOptions(url, method, cc, referUrl, "*/*");
                this.httpRequest.Accept = httpAccept;
                this.httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                // 是否收到响应
                if (!this.httpRequest.HaveResponse)
                {

                    ccOut = null;
                    this.httpResponse.Close();
                    this.httpRequest.Abort();
                    return ms;
                }

                this.ManualResetMember();

                if (null != this.OnGetResponseReadyHandler)
                {
                    try
                    {
                        this.OnGetResponseReadyHandler(this.httpRequest);
                    }
                    catch (System.Exception ex)
                    {
                        this.LastAccessError = true;
                        LogHelper.WriteLog(ex);
                    }
                }

                this.DoBetIsGotoRecv = true;

                Stream sm = httpResponse.GetResponseStream();
                if (null != sm && sm.CanRead)
                {
                    //int readBytes = 0;
                    //byte[] buffer = new byte[DEFAULT_BUFFER_SIZE];
                    //while ((readBytes = sm.Read(buffer, 0, buffer.Length)) != 0)
                    //{
                    //    ms.Write(buffer, 0, readBytes);
                    //}

                    BinaryReader br = new BinaryReader(sm);
                    byte[] bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    while (null != bytes && bytes.Length != 0)
                    {
                        ms.Write(bytes, 0, bytes.Length);
                        bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    }
                    br.Close();
                }

                if (httpResponse.Headers["Set-Cookie"] != null)
                {
                    this.CurSetCookie = httpResponse.Headers["Set-Cookie"].ToString();
                }

                cctemp = httpResponse.Cookies;

                //if (httpResponse.Headers.Get("Set-Cookie") != null)
                //{
                //    this.CurSetCookie = httpResponse.Headers["Set-Cookie"].ToString();
                //}

                httpResponse.Close();
                if (null != sm) sm.Close();

                // 非常重要,回到开头
                ms.Seek(0, SeekOrigin.Begin);
            }
            catch (System.Exception ex)
            {
                this.LastAccessError = true;
                LogHelper.WriteLog(ex);
                if (null != httpRequest) httpRequest.Abort();
            }

            ccOut = cctemp;
            return ms;
        }



        public MemoryStream SimpleGetMemoryStream(string url, string method)
        {
            return this.GetMemoryStream(url, method, null, null, "text/html");
        }

        public MemoryStream SimpleGetMemoryStream(string url, string method, CookieCollection cc)
        {
            return this.GetMemoryStream(url, method, cc, null, "text/html");
        }

        public MemoryStream SimpleGetMemoryStream(string url, string method, string httpAccept)
        {
            return this.GetMemoryStream(url, method, null, null, httpAccept);
        }

        public MemoryStream SimpleGetMemoryStream(string url, string method, string httpAccept, CookieCollection cc)
        {
            return this.GetMemoryStream(url, method, cc, null, httpAccept);
        }

        /// <summary>
        /// 仅仅发送请求,返回所有的输出文本
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="coding"></param>
        /// <param name="cc"></param>
        /// <param name="referUrl"></param>
        /// <returns></returns>
        public string SimpleDoPostWrapper(string url, string method, Encoding coding, CookieCollection cc, string referUrl)
        {
            string str = string.Empty;
            StreamReader sr = null;
            MemoryStream sm = null;

            if (null == coding)
            {
                sm = this.GetMemoryStream(url, method, cc, referUrl, "text/html");
                sr = new StreamReader(sm);
            }
            else
            {
                sm = this.GetMemoryStream(url, method, cc, referUrl, "text/html");
                sr = new StreamReader(sm, coding);
            }
            str = sr.ReadToEnd();
            sr.Close();
            sm.Close();
            return str;
        }

        public string SimpleDoPostWrapper(string url, string method, Encoding coding, CookieCollection cc, string referUrl, out CookieCollection ccOut)
        {
            CookieCollection tempcc = new CookieCollection();
            string str = string.Empty;
            StreamReader sr = null;
            MemoryStream sm = null;

            if (null == coding)
            {
                sm = this.GetMemoryStream(url, method, cc, referUrl, "text/html", out tempcc);
                sr = new StreamReader(sm);
            }
            else
            {
                sm = this.GetMemoryStream(url, method, cc, referUrl, "text/html", out tempcc);
                sr = new StreamReader(sm, coding);
            }
            str = sr.ReadToEnd();
            sr.Close();
            sm.Close();
            ccOut = tempcc;
            return str;
        }

        public string SimpleDoPostWrapper(string url, string method)
        {
            return this.SimpleDoPostWrapper(url, method, null, null, null);
        }

        public string SimpleDoPostWrapper(string url, string method, CookieCollection cc)
        {
            return this.SimpleDoPostWrapper(url, method, null, cc, null);
        }

        public string SimpleDoPostWrapper(string url, string method, string referUrl)
        {
            return this.SimpleDoPostWrapper(url, method, null, null, referUrl);
        }

        /// <summary>
        /// 上送数据,返回输出流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="coding"></param>
        /// <param name="cc"></param>
        /// <param name="referUrl"></param>
        /// <returns></returns>
        public MemoryStream GetMemoryStream(string url, string data, string method, Encoding coding, CookieCollection cc, string referUrl)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                this.SetHttpRequestOptions(url, method, cc, referUrl, "text/html");
                byte[] bytesData = coding.GetBytes(data);
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytesData, 0, bytesData.Length);
                requestStream.Flush();
                requestStream.Close();

                this.httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                // 是否收到响应
                if (!this.httpRequest.HaveResponse)
                {
                    this.httpResponse.Close();
                    this.httpRequest.Abort();
                    return ms;
                }

                this.ManualResetMember();

                if (null != this.OnGetResponseReadyHandler)
                {
                    try
                    {
                        this.OnGetResponseReadyHandler(this.httpRequest);
                    }
                    catch (System.Exception ex)
                    {
                        this.LastAccessError = true;
                        LogHelper.WriteLog(ex);
                    }
                }

                this.DoBetIsGotoRecv = true;

                Stream sm = httpResponse.GetResponseStream();
                if (null != sm && sm.CanRead)
                {
                    //int readBytes = 0;
                    //byte[] buffer = new byte[DEFAULT_BUFFER_SIZE];

                    //while ((readBytes = sm.Read(buffer, 0, buffer.Length)) != 0)
                    //{
                    //    ms.Write(buffer, 0, readBytes);
                    //}

                    BinaryReader br = new BinaryReader(sm);
                    byte[] bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    while (null != bytes && bytes.Length != 0)
                    {
                        ms.Write(bytes, 0, bytes.Length);
                        bytes = br.ReadBytes(DEFAULT_BUFFER_SIZE);
                    }
                    br.Close();
                }

                if (httpResponse.Headers["Set-Cookie"] != null)
                {
                    this.CurSetCookie = httpResponse.Headers["Set-Cookie"].ToString();
                }
                httpResponse.Close();
                if (null != sm) sm.Close();

                // 非常重要,回到开头
                ms.Seek(0, SeekOrigin.Begin);
            }
            catch (System.Exception ex)
            {
                this.LastAccessError = true;
                LogHelper.WriteLog(ex);
                if (null != httpRequest) httpRequest.Abort();
            }

            return ms;
        }

        public MemoryStream SimpleGetMemoryStream(string url, string data, string method, Encoding coding)
        {
            return this.GetMemoryStream(url, data, method, coding, null, null);
        }

        public MemoryStream SimpleGetMemoryStream(string url, string data, string method, Encoding coding, string referUrl)
        {
            return this.GetMemoryStream(url, data, method, coding, null, referUrl);
        }

        /// <summary>
        /// 上送,返回所有的输出文本
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <param name="coding"></param>
        /// <param name="referUrl"></param>
        /// <returns></returns>
        public string DoPostWrapper(string url, string data, string method, Encoding coding, CookieCollection cc, string referUrl)
        {
            string str = string.Empty;
            MemoryStream sm = this.GetMemoryStream(url, data, method, coding, cc, referUrl);
            StreamReader sr = new StreamReader(sm, coding);
            str = sr.ReadToEnd();
            sr.Close();
            sm.Close();
            return str;
        }

        public string DoPostWrapper(string url, string data, string method, Encoding coding)
        {
            return this.DoPostWrapper(url, data, method, coding, null, null);
        }

        public string DoPostWrapper(string url, string data, string method, Encoding coding, CookieCollection cc)
        {
            return this.DoPostWrapper(url, data, method, coding, cc, null);
        }

        public string DoPostWrapper(string url, string data, string method, Encoding coding, string referUrl)
        {
            return this.DoPostWrapper(url, data, method, coding, null, referUrl);
        }

        /// <summary>
        /// 上送,返回所有的输出文本,参数是字典
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dicArguments"></param>
        /// <param name="method"></param>
        /// <param name="coding"></param>
        /// <param name="referUrl"></param>
        /// <returns></returns>
        public string DoPostWrapper(string url, Dictionary<string, string> dicArguments, string method, Encoding coding, CookieCollection cc, string referUrl)
        {
            string data = this.BuildRequestArguments(dicArguments);
            return this.DoPostWrapper(url, data, method, coding, cc, referUrl);
        }

        public string DoPostWrapper(string url, Dictionary<string, string> dicArguments, string method, Encoding coding)
        {
            return this.DoPostWrapper(url, dicArguments, method, coding, null, null);
        }

        public string DoPostWrapper(string url, Dictionary<string, string> dicArguments, string method, Encoding coding, CookieCollection cc)
        {
            return this.DoPostWrapper(url, dicArguments, method, coding, cc, null);
        }

        public string DoPostWrapper(string url, Dictionary<string, string> dicArguments, string method, Encoding coding, string referUrl)
        {
            return this.DoPostWrapper(url, dicArguments, method, coding, null, referUrl);
        }

        /// <summary>
        /// 下载验证码,只返回内存流,调用函数要负责关闭该Stream
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public MemoryStream DownloadStream(string url, string method)
        {
            return this.SimpleGetMemoryStream(url, method, "*/*");
        }


        public MemoryStream DownloadStream(string url, string method, CookieCollection cc)
        {
            return this.SimpleGetMemoryStream(url, method, "*/*", cc);
        }

        /// <summary>
        /// 从字典中生成上传参数.提供编码定制支持
        /// </summary>
        /// <param name="dicArguments"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        public string BuildRequestArguments(Dictionary<string, string> dicArguments, Encoding coding)
        {
            StringBuilder sb = new StringBuilder();
            string str = string.Empty;
            if (0 == dicArguments.Count) return str;
            foreach (KeyValuePair<string, string> kvp in dicArguments)
            {
                //if (null != coding)
                    // sb.Append(HttpUtility.UrlEncode(kvp.Key, coding) + "=" + HttpUtility.UrlEncode(kvp.Value, coding));
                    
                //else
                    //sb.Append(HttpUtility.UrlEncode(kvp.Key) + "=" + HttpUtility.UrlEncode(kvp.Value));
                    
                // a&b
                //sb.Append("&");
            }
            str = sb.ToString();
            return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 从字典中生成上传的默认参数,不提供编码定制支持
        /// </summary>
        /// <param name="dicArguments"></param>
        /// <returns></returns>
        public string BuildRequestArguments(Dictionary<string, string> dicArguments)
        {
            return this.BuildRequestArguments(dicArguments, null);
        }

        /// <summary>
        /// 查询cookie中的某个项的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string GetCookieValue(string key, string domain)
        {
            if (0 == this.cookieContainer.Count)
            {
                return string.Empty;
            }

            CookieCollection cc = this.cookieContainer.GetCookies(new Uri(domain));
            return cc[key].Value;
        }

        /// <summary>
        /// 设置cookies容器
        /// </summary>
        /// <param name="cc"></param>
        public void SetCookieContainer(CookieContainer cc)
        {
            this.cookieContainer = cc;
        }

        /// <summary>
        /// 放棄請求
        /// </summary>
        public bool AbortHttpRequest()
        {
            if (null != this.httpRequest)
            {
                this.httpRequest.Abort();
            }

            return this.CheckGotoRecv && this.DoBetIsGotoRecv;
        }


        public string GetCookieSting()
        {
            if (0 == this.cookieContainer.Count)
            {
                return string.Empty;
            }

            List<Cookie> cooklist = GetAllCookies(this.cookieContainer);
            StringBuilder sbc = new StringBuilder();
            foreach (Cookie cookie in cooklist)
            {
                sbc.AppendFormat("{0};{1};{2};{3};{4};{5}\r/n",
                    cookie.Domain, cookie.Name, cookie.Path, cookie.Port,
                    cookie.Secure.ToString(), cookie.Value);
            }

            return sbc.ToString();

        }
        public List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }

            return lstCookies;
        }

        public List<Cookie> GetAllCookies()
        {
            WebClient wc = new WebClient();
            return GetAllCookies(this.cookieContainer);
        }

        public void AddCookieInCookieContainer(Cookie cookie)
        {
            this.cookieContainer.Add(cookie);
        }
    }
}
