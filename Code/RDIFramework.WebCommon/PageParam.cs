using System.Web;

namespace RDIFramework.WebCommon
{
    /// <summary>
    /// EasyUi分页参数
    /// </summary>
    public class PageParam
    {
        private HttpContext _context;
        public PageParam(HttpContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex
        {
            get
            {
                int pageIndex;
                int.TryParse(_context.Request["page"], out pageIndex);
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                return pageIndex;
            }
        }

        /// <summary>
        /// grid 排序字段
        /// </summary>
        public string SortField
        {
            get { return _context.Request["sort"]; }
        }

        /// <summary>
        /// grid 排序方式 asc || desc
        /// </summary>
        public string Order
        {
            get { return _context.Request["order"]; }
        }


        /// <summary>
        /// 页尺寸
        /// </summary>
        public int PageSize
        {
            get
            {
                int pageSize;
                int.TryParse(_context.Request["rows"], out pageSize);
                if (pageSize == 0)
                {
                    pageSize = 20;
                }
                return pageSize;
            }
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        public string Filter
        {
            get
            {
                string returnValue = PublicMethod.GetString(_context.Request["filter"]);
                if (!string.IsNullOrEmpty(returnValue))
                {
                    string grouptype;
                    var list = SearchFilter.GetSearchList(returnValue, out grouptype);
                    returnValue = SearchFilter.ToSql(list, grouptype);
                }
                return returnValue;
            }
        }

        /// <summary>
        /// 筛选条件扩展（主要用于页面有搜索条件的：参考日志管理）
        /// </summary>
        public string FilterEx
        {
            get
            {
                string returnValue = PublicMethod.GetString(_context.Request["filter"]);
                if (!string.IsNullOrEmpty(returnValue))
                {
                    returnValue = HttpUtility.UrlDecode(FilterTranslator.ToSql(returnValue));
                }
                return returnValue;
            }
        }
    }
}
