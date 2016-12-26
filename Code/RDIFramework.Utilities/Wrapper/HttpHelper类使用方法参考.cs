﻿using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RDIFramework.Utilities
{
    public class HttpHelper类使用方法参考
    {
        /// <summary>
        /// HttpHelper类使用方法1
        /// </summary>
        public void TestUse1()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
                Timeout = 100000,//连接超时时间     可选项默认为100000
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写
                Cookie = "",//字符串Cookie     可选项
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值
                ContentType = "text/html",//返回类型    可选项有默认值
                Referer = "http://www.sufeinet.com",//来源URL     可选项
                Allowautoredirect = true,//是否根据３０１跳转     可选项
                CerPath = "d:\\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数
                Connectionlimit = 1024,//最大连接数     可选项 默认为1024
                Postdata = "C:\\PERKYSU_20121129150608_ScrubLog.txt",//Post数据     可选项GET时不需要写
                PostDataType = PostDataType.FilePath,//默认为传入String类型，也可以设置PostDataType.Byte传入Byte类型数据
                ProxyIp = "192.168.1.105：8015",//代理服务器ID 端口可以直接加到后面以：分开就行了    可选项 不需要代理 时可以不设置这三个参数
                ProxyPwd = "123456",//代理服务器密码     可选项
                ProxyUserName = "administrator",//代理服务器账户名     可选项
                ResultType = ResultType.Byte,//返回数据类型，是Byte还是String
                PostdataByte = System.Text.Encoding.Default.GetBytes("测试一下"),//如果PostDataType为Byte时要设置本属性的值
                CookieCollection = new System.Net.CookieCollection(),//可以直接传一个Cookie集合进来
            };
            item.Header.Add("测试Key1", "测试Value1");
            item.Header.Add("测试Key2", "测试Value2");
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            //取出返回的Cookie
            string cookie = result.Cookie;
            //返回的Html内容
            string html = result.Html;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }
            //表示StatusCode的文字说明与描述
            string statusCodeDescription = result.StatusDescription;
            //把得到的Byte转成图片
            Image img = byteArrayToImage(result.ResultByte);
        }

        /// <summary>
        /// 最简单的Post与Get的写法
        /// </summary>
        /// <returns></returns>
        public void TestUse2()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL这里都是测试     必需项
                Method = "get",//URL     可选项 默认为Get
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            item = new HttpItem()
            {
                URL = "http://tool.sufeinet.com",//URL这里都是测试URl   必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "post",//URL     可选项 默认为Get
                Postdata = "user=123123&pwd=1231313"
            };
            //得到新的HTML代码
            result = http.GetHtml(item);
        }

        /// <summary>
        /// HttpHelper设置Header参考的方法
        /// </summary>
        public void TestUse3()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
            };
            item.Header.Add("测试Key1", "测试Value1");
            item.Header.Add("测试Key2", "测试Value2");
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            //取出返回的Cookie
            string cookie = result.Cookie;
            //返回的Html内容
            string html = result.Html;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }
            //表示StatusCode的文字说明与描述
            string statusCodeDescription = result.StatusDescription;
        }

        /// <summary>
        /// HttpHelper获取图片的方式
        /// </summary>
        public void TestUse4()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                ResultType = ResultType.Byte
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }
            //表示StatusCode的文字说明与描述
            string statusCodeDescription = result.StatusDescription;
            //把得到的Byte转成图片
            Image img = byteArrayToImage(result.ResultByte);
        }

        /// <summary>
        /// 二次或多次使用Cookie的方式
        /// </summary>
        public void TestUse5()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL这里都是测试     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            item = new HttpItem()
            {
                URL = "http://tool.sufeinet.com",//URL这里都是测试URl   必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
                Cookie = result.Cookie,
            };
            //得到新的HTML代码
            result = http.GetHtml(item);
        }

        /// <summary>
        /// CookieCollection类型的Cookie使用方法
        /// </summary>
        public void TestUse6()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL这里都是测试     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
                ResultCookieType = ResultCookieType.CookieCollection
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            item = new HttpItem()
            {
                URL = "http://tool.sufeinet.com",//URL这里都是测试URl   必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
                CookieCollection = result.CookieCollection,
                ResultCookieType = ResultCookieType.CookieCollection
            };
            //得到新的HTML代码
            result = http.GetHtml(item);
        }

        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        private Image byteArrayToImage(byte[] Bytes)
        {
            MemoryStream ms = new MemoryStream(Bytes);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }

        #region 在webBrowser中取Cookie的方法
        //在很多情况下我们会使用间进程的webBrowser去实现一些网页的请求和抓去，这个时候有部分网页是取不到Cookie的，那怎么办呢？下面我提供一个方法，应该99%的都能取到，
        //取当前webBrowser登录后的Cookie值   
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, object lpReserved);
        //取出Cookie，当登录后才能取    
        private static string GetCookieString(string url)
        {
            // Determine the size of the cookie      
            int datasize = 256;
            StringBuilder cookieData = new StringBuilder(datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie    
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
                    return null;
            }
            return cookieData.ToString();
        }
        #endregion

        #region 去掉所有的Html代码
        /// <summary>
        /// 过滤html标签
        /// </summary>
        /// <param name="strHtml">html的内容</param>
        /// <returns></returns>
        public static string StripHTML(string stringToStrip)
        {
            // paring using RegEx           //
            stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = StripHtmlXmlTags(stringToStrip);
            return stringToStrip;
        }

        private static string StripHtmlXmlTags(string content)
        {
            return Regex.Replace(content, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        #endregion

        #region 设置URl格式的问题
        public static string URLDecode(string text)
        {
            return HttpUtility.UrlDecode(text, Encoding.Default);
        }
        public static string URLEncode(string text)
        {
            return HttpUtility.UrlEncode(text, Encoding.Default);
        }
        #endregion

    }
}
