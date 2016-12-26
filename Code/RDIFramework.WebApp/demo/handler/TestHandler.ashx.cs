using System.Web;

namespace RDIFramework.WebApp.demo.handler
{
    using RDIFramework.WebCommon;

    /// <summary>
    /// TestHandler 的摘要说明
    /// </summary>
    public class TestHandler : IHttpHandler
    {
        private string Action
        {
            get
            {
                return PublicMethod.GetString(getObj("action"));
            }
        }
        private object getObj(string key) { return WebCommon.StringHelper.GetRequestObject(key); }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (Action)
            {
                case "getTestData":
                    getTestData(context);
                    break;
            }
        }

        private void getTestData(HttpContext ctx)
        {
            var writeJson = "{\"total\":28,\"rows\":[ {\"productid\":\"FI-SW-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"1\",\"listprice\":36.50,\"email\":\"caoguanghuicgh@163.com\",\"linkname\":\"曹光辉\",\"itemid\":\"No.1\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"K9-DL-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"0\",\"listprice\":18.50,\"email\":\"wuyanyang1982@163.com\",\"linkname\":\"吴艳阳\",\"itemid\":\"No.2\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"RP-SN-01\",\"city\":\"LYG\",\"county\":\"GYX\",\"mobile\":\"13851494266\",\"status\":\"0\",\"listprice\":28.50,\"email\":\"wangbo1982@163.com\",\"linkname\":\"王波\",\"itemid\":\"No.3\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"RP-SN-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"0\",\"listprice\":26.50,\"email\":\"fanjinyang1982@163.com\",\"linkname\":\"范金阳\",\"itemid\":\"No.4\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"RP-LI-02\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"1\",\"listprice\":35.50,\"email\":\"wangxiaoting1988@163.com\",\"linkname\":\"王晓婷\",\"itemid\":\"No.5\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"FL-DSH-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"1\",\"listprice\":158.50,\"email\":\"wuyanxi1984@163.com\",\"linkname\":\"吴艳曦\",\"itemid\":\"No.6\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"FL-DSH-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"1\",\"listprice\":83.50,\"email\":\"wuqiang1981@163.com\",\"linkname\":\"吴强\",\"itemid\":\"No.7\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"FL-DLH-02\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"1\",\"listprice\":63.50,\"email\":\"juqian19881022@163.com\",\"linkname\":\"居茜\",\"itemid\":\"No.8\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"FL-DLH-02\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"0\",\"listprice\":89.50,\"email\":\"chenzhongfeng@163.com\",\"linkname\":\"陈中锋\",\"itemid\":\"No.9\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"}, {\"productid\":\"AV-CB-01\",\"city\":\"NJ\",\"county\":\"JNQ\",\"mobile\":\"13851494266\",\"status\":\"0\",\"listprice\":63.50,\"email\":\"songwenguang@163.com\",\"linkname\":\"宋文广\",\"itemid\":\"No.10\",\"startTime\":\"2012-10-10\",\"endTime\":\"2012-10-12\"} ]}";
            ctx.Response.Write(writeJson);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}