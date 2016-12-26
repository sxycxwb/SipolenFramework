using System.Collections.Generic;

namespace RDIFramework.Utilities
{
    public class HttpCookieHelper类使用方法参考
    {
        public void TestUse1()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL这里都是测试     必需项
                Method = "get",//URL     可选项 默认为Get
                ResultType = ResultType.Byte
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);

            //得到Cookie列表
            List<CookieItem> cookilist = HttpCookieHelper.GetCookieList(result.Cookie);
            //第一个Cookie项的Key值
            string key = cookilist[0].Key;
            //第一个Cookie项的Value值
            string value = cookilist[0].Value;

            //格式化Cookie
            string cookitem = HttpCookieHelper.CookieFormat(key, value);

            // 根据Key取Value
            string strKey = HttpCookieHelper.GetCookieValue(result.Cookie, "domain");
        }

        /// <summary>
        /// 登录一个网站时的处理
        /// </summary>
        public void TestUse2()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://bbs.xmfish.com/login.php",//URL     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "post",//URL     可选项 默认为Get
                //Timeout = 100000,//连接超时时间     可选项默认为100000
                //ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000
                //IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写
                //Cookie = "",//字符串Cookie     可选项
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值
                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                //Referer = "http://www.sufeinet.com",//来源URL     可选项
                Postdata = "answer=&cktime=0&customquest=&forward=&hideid=0&jumpurl=&lgt=0&pwpwd=&pwuser=&question=0&step=2&submit=",
                Allowautoredirect = true
            };
            HttpResult result = http.GetHtml(item);
            string cookie = string.Empty;
            foreach (CookieItem s in HttpCookieHelper.GetCookieList(result.Cookie))
            {
                if (s.Key.Contains("24a79_"))
                {
                    cookie += HttpCookieHelper.CookieFormat(s.Key, s.Value);
                }
            }
            if (result.Html.IndexOf("您已经顺利登录") > 0)
            {
                item = new HttpItem()
                {
                    URL = "http://bbs.xmfish.com/u.php",
                    Cookie = cookie
                };
                result = http.GetHtml(item);//目前这个里面是未登入的状态
            }
        }
    }
}
