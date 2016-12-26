using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RDIFramework.WebCommon
{
    public class SearchFilter
    {
        private string searchField;
        private string searchString;
        private string searchOper;

        /// <summary>
        /// 查询字段名
        /// </summary>
        public string SearchField
        {
            get { return searchField; }
            set { searchField = value; }
        }

        /// <summary>
        /// 查询值
        /// </summary>
        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; }
        }

        /// <summary>
        /// 查询方式
        /// </summary>
        public string SearchOper
        {
            get { return searchOper; }
            set { searchOper = value; }
        }

        /// <summary>
        /// 将JSON字符串转换为LIST
        /// </summary>
        /// <param name="jsons">json 串</param>
        /// <returns></returns>
        public static IList<SearchFilter> GetSearchList(string jsons, out string groupop)
        {
            JObject o = (JObject)JsonConvert.DeserializeObject(jsons);
            JToken torrentsArray = (JToken)o["rules"];
            groupop = o.SelectToken("groupOp").ToString().Replace("\"", "");
            IList<SearchFilter> searchResults = new List<SearchFilter>();
            SearchFilter c = null;
            foreach (JToken result in torrentsArray)
            {
                c = new SearchFilter
                {
                    SearchField = result.SelectToken("field").ToString().Replace("\"", ""),
                    searchString = result.SelectToken("data").ToString().Replace("\"", ""),
                    SearchOper = result.SelectToken("op").ToString().Replace("\"", "")
                };
                searchResults.Add(c);
            }

            return searchResults;
        }


        /// <summary>
        /// 将查询条件转换成SQL语句
        /// </summary>
        /// <param name="list">查询条件数组</param>
        /// <returns></returns>
        public static string ToSql(IList<SearchFilter> list, string grouptype)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "";
            foreach (SearchFilter result in list)
            {
                sb.Append(" " + grouptype + " ");
                switch (result.searchOper.ToString())
                {
                    case "eq": //等于
                        sb.AppendFormat(result.SearchField + " ='{0}'", result.SearchString);
                        break;
                    case "gt": //大于
                        sb.AppendFormat(result.SearchField + " >'{0}'", result.SearchString);
                        break;
                    case "ge": //大于 =
                        sb.AppendFormat(result.SearchField + " >='{0}' ", result.SearchString);
                        break;
                    case "lt": //小于
                        sb.AppendFormat(result.SearchField + " <'{0}'", result.SearchString);
                        break;
                    case "le": //小于 =
                        sb.AppendFormat(result.SearchField + " <='{0}'", result.SearchString);
                        break;
                    case "ne"://不等于
                        sb.AppendFormat(result.SearchField + " <>'{0}'", result.SearchString);
                        break;
                    case "cn"://模糊
                        sb.AppendFormat(result.SearchField + " like '%{0}%'", result.SearchString);
                        break;
                    case "nu":
                        sb.AppendFormat(result.SearchField + " {0}", "IS NULL ");
                        break;
                    case "nn":
                        sb.AppendFormat(result.SearchField + " {0}", "IS NOT NULL ");
                        break;
                    default:
                        sb.AppendFormat(result.SearchField + " ='{0}'", result.SearchString);
                        break;
                }
            }

            sql = sb.ToString();
            sql = sql.Substring(4);

            return sql;
        }
    }
}