using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace RDIFramework.WebCommon.GenericSort
{
    public class SortClass
    {
        private string _sortProperty;
        private SortDirection _sortDirection;

        /// <summary>
        /// 排序的属性
        /// </summary>
        public string SortProperty
        {
            get { return _sortProperty; }
            set { _sortProperty = value; }
        }

        /// <summary>
        /// 排序方向
        /// </summary>
        public SortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }

        /// <summary>
        /// 初始化构造函数
        /// </summary>
        /// <param name="sortProperty">排序属性</param>
        /// <param name="sortDirection">排序方向</param>
        public SortClass(string sortProperty, SortDirection sortDirection)
        {
            _sortDirection = sortDirection;
            _sortProperty = sortProperty;
        }
    }
}
