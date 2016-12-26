#region  版权信息
/*---------------------------------------------------------------------*
// Copyright (C) 2010 http://www.cnblogs.com/huyong
// 版权所有。 
// 项目  名称：《Winform通用控件库》
// 文  件  名： UcPageControl.cs
// 类  全  名： RDIFramework.Controls.UcPageControl 
// 描      述:  分页控件
// 创建  时间： 2010-06-05
// 创建人信息： [**** 姓名:EricHu QQ:406590790 E-Mail:406590790@qq.com *****]
*----------------------------------------------------------------------*/
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using RDIFramework.Utilities;
using System.Data.OracleClient;

namespace RDIFramework.Controls
{
    #region 委托申明
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate int EventPagingHandler(EventPagingArg e);
    #endregion

    #region 分页控件
    /// <summary>
    /// 分页控件
    /// 
    /// 修改纪录(此分页控件经过多次修改，已趋于完美，可放心使用。)
    /// 
    ///     2014-01-20 EricHu V2.7 提供对Oracle分页的支持！
    ///     2013-08-21 EricHu V2.5 更新对Sqlserver分页的存储过程，分页效率更高。
    ///     2010-12-06 EricHu 对上一条、下一条、首条、末条数据导航的隐藏，因为控件本身已做了处理。
    ///     2010-12-05 EricHu 对分页控件代码做了相应优化
    ///     2010-06-05 EricHu 创建分页控件
    ///     
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("EventPaging")]
    [ToolboxBitmap(typeof(UcPageControl), "Images.UcPageControl.bmp")]
    [Description("分页控件")]
    public partial class UcPageControl : UserControl
    {
        #region 申明事件
        /// <summary>
        /// 单击移动到当前页上一末记录时发生
        /// </summary>
        [Category("用户控件属性"), Description("单击移动到当前页上一末记录时发生。"),Browsable(false)]
        public event EventHandler OnBindingNavigatorMovePreviousItemClick;

        /// <summary>
        /// 单击移动到当前页第一条记录时发生
        /// </summary>
        [Category("用户控件属性"), Description("单击移动到当前页第一条记录时发生。"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveFirstItemClick;

        /// <summary>
        /// 单击移动到当前页下一条记录时发生
        /// </summary>
        [Category("用户控件属性"), Description("单击移动到当前页下一条记录时发生。"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveNextItemClick;

        /// <summary>
        /// 单击移动到当前页最后一条记录时发生
        /// </summary>
        [Category("用户控件属性"), Description("单击移动到当前页最后一条记录时发生。"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveLastItemClick;

        /// <summary>
        /// 单击各分页按钮(上一页、下一页、第一页、最后一页和转到某页)时发生
        /// </summary>
        [Category("用户控件属性"), Description("分页时发生。")]
        public event EventPagingHandler EventPaging;
        #endregion 

        #region 构造函数
        public UcPageControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 属性

        private int _pageSize    = 20;  //每页显示记录数
        private int _nMax        = 0;   //总记录数
        private int _pageCount   = 0;   //页数=总记录数/每页显示记录数
        private int _pageCurrent = 0;   //当前页号

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        [Category("用户控件属性"), Description("每页显示记录数。"), Browsable(true)]
        public int PageSize
        {
            get 
            { 
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                GetPageCount();//页数
            }
        }              
      
        /// <summary>
        /// 记录总数
        /// </summary>
        [Category("用户控件属性"), Description("记录总数。"),Browsable(false)]
        public int NMax
        {
            get 
            { 
                return _nMax; 
            }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }       

        /// <summary>
        /// 页数
        /// </summary>
        [Category("用户控件属性"), Description("页数。"), Browsable(false)]
        public int PageCount
        {
            get 
            { 
                return _pageCount;
            }
            set 
            { 
                _pageCount = value; 
            }
        }       

        /// <summary>
        /// 当前页号
        /// </summary>
        [Category("用户控件属性"), Description("当前页号。"), Browsable(false)]
        public int PageCurrent
        {
            get 
            {
                return _pageCurrent;
            }
            set 
            {
                _pageCurrent = value; 
            }
        }
        #endregion

        #region 方法
        [Category("用户控件属性"), Description("bindingNavigator。"), Browsable(false)]
        public BindingNavigator ToolBar
        {
            get 
            { 
                return this.bindingNavigator;
            }
        }

        /// <summary>
        /// 得到总页数
        /// </summary>
        private void GetPageCount()
        {
            this.PageCount = this.NMax > 0 ? Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize))) : 0;
        }

        /// <summary>
        /// 绑定分页控件(关键代码)
        /// </summary>
        public void Bind()
        {
            if (this.EventPaging != null)
            {
                this.NMax = this.EventPaging(new EventPagingArg(this.PageCurrent));
            }

            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            if (this.PageCount == 1)
            {
                this.PageCurrent = 1;
            }
            lblPageCount.Text = this.PageCount.ToString();
            this.lblMaxPage.Text = "共"+this.NMax.ToString()+"条记录";
            this.txtCurrentPage.Text = this.PageCurrent.ToString();

            if (this.PageCurrent == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.NMax == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
        }

        #endregion

        #region 按钮事件
        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageCurrent = 1;
            this.Bind();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                PageCurrent = 1;
            }
            this.Bind();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.PageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                PageCurrent = PageCount;
            }
            this.Bind();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PageCurrent = PageCount;
            this.Bind();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtCurrentPage.Text == null || txtCurrentPage.Text == "") return;
            if (Int32.TryParse(txtCurrentPage.Text, out _pageCurrent))
            {
                this.Bind();
            }
            else
            {
                MessageBox.Show("输入数字格式错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Bind();
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if(OnBindingNavigatorMovePreviousItemClick != null)
            {
                OnBindingNavigatorMovePreviousItemClick(this, null);
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (OnBindingNavigatorMoveFirstItemClick != null)
            {
                OnBindingNavigatorMoveFirstItemClick(this, null);
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (OnBindingNavigatorMoveNextItemClick != null)
            {
                OnBindingNavigatorMoveNextItemClick(this, null);
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (OnBindingNavigatorMoveLastItemClick != null)
            {
                OnBindingNavigatorMoveLastItemClick(this, null);
            }
        }
    #endregion
    }
    #endregion

    #region 自定义事件数据基类
    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;
        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }
    #endregion

    #region 数据源提供(PageData)
    /// <summary>
    /// 数据源提供
    /// 
    ///     修改记录：
    ///     2010-12-19 EricHu 修改int GetTotalCount(string connectionstring)方法
    ///                     当查询条件为空时，高效得到指定表的记录总数。
    /// </summary>
    public class PageData
    {
        DataTable dtPageData                         = null;
        private int    _PageSize           = 20;           //分页大小
        private int    _PageIndex          = 1;            //当前页
        private int    _PageCount          = 0;            //总页数
        private int    _TotalCount         = 0;            //总记录数
        private string _QueryFieldName     = "*";          //表字段FieldStr
        private bool   _isQueryTotalCounts = true;         //是否查询总的记录条数
        private string _TableName          = string.Empty; //表名        
        private string _OrderStr           = string.Empty; //排序_SortStr
        private string _QueryCondition     = string.Empty; //查询的条件 RowFilter
        private string _PrimaryKey         = string.Empty; //主键

        /// <summary>
        /// 是否查询总的记录条数
        /// </summary>
        public bool IsQueryTotalCounts
        {
            get { return _isQueryTotalCounts; }
            set { _isQueryTotalCounts = value; }
        }

        /// <summary>
        /// 分页大小(每页显示多少条数据)
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;

            }
            set
            {
                _PageSize = value;
            }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }

        /// <summary>
        /// 表名或视图名
        /// </summary>
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        /// <summary>
        /// 表字段FieldStr
        /// </summary>
        public string QueryFieldName
        {
            get
            {
                return _QueryFieldName;
            }
            set
            {
                _QueryFieldName = value;
            }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderStr
        {
            get
            {
                return _OrderStr;
            }
            set
            {
                _OrderStr = value;
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QueryCondition
        {
            get
            {
                return _QueryCondition;
            }
            set
            {
                _QueryCondition = value;
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get 
            {
                return _PrimaryKey;
            }
            set 
            {
                _PrimaryKey = value;
            }
        }

        private CurrentDbType pageDbType = CurrentDbType.SqlServer;
        public CurrentDbType PageDbType
        {
            get { return pageDbType; }
            set { pageDbType = value; }
        }
        

        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="connectionstring">连接字符串</param>
        /// <returns>DataSet</returns>
        public DataTable QueryDataTable(string connectionstring)
        {
            switch (PageDbType)
            {
                case CurrentDbType.SqlServer:
                    dtPageData = GetSqlSeverPageDate(connectionstring);
                    break;
                case CurrentDbType.Oracle:
                    dtPageData = GetOraclePageDate(connectionstring);
                    break;
            }

            return dtPageData;
        }

        #region private DataTable GetSqlSeverPageDate(string connectionstring) 得到SqlServer分页数据
        /// <summary>
        /// 得到SqlServer分页数据
        /// </summary>
        /// <param name="connectionstring">连接字符串</param>
        /// <returns></returns>
        private DataTable GetSqlSeverPageDate(string connectionstring)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Tables",      SqlDbType.VarChar,  255),
				    new SqlParameter("@PrimaryKey" , SqlDbType.VarChar , 255),	
                    new SqlParameter("@Sort",        SqlDbType.VarChar , 255),
                    new SqlParameter("@CurrentPage", SqlDbType.Int          ),
					new SqlParameter("@PageSize",    SqlDbType.Int          ),									
                    new SqlParameter("@Fields",      SqlDbType.VarChar,  255),
					new SqlParameter("@Filter",      SqlDbType.VarChar,  1000),
                    new SqlParameter("@Group" ,      SqlDbType.VarChar,  1000)
					};
            parameters[0].Value = _TableName;
            parameters[1].Value = _PrimaryKey;
            parameters[2].Value = _OrderStr;
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[5].Value = _QueryFieldName;
            parameters[6].Value = _QueryCondition;
            parameters[7].Value = string.Empty;
            //dtPageData = RDIFramework.Utilities.DbFactoryProvider.GetProvider(connectionstring).ExecuteProcedureForDataTable("pGetPageData","tbPageData",parameters);
            dtPageData = DbFactoryProvider.GetProvider(connectionstring).ExecuteProcedureForDataTable("pGetPageData", _TableName, parameters);
            if (_isQueryTotalCounts)
            {
                _TotalCount = GetTotalCount(connectionstring);
            }

            if (_TotalCount == 0)
            {
                _PageIndex = 0;
                _PageCount = 0;
            }
            else
            {
                _PageCount = _TotalCount % _PageSize == 0 ? _TotalCount / _PageSize : _TotalCount / _PageSize + 1;

                if (_PageIndex > _PageCount)
                {
                    _PageIndex = _PageCount;
                    parameters[4].Value = _PageSize;
                    dtPageData = QueryDataTable(connectionstring);
                }
            }

            return dtPageData;
        }
        #endregion

        #region private DataTable GetOraclePageDate(string connectionstring) 得到Oracle分页数据
        /// <summary>
        /// 得到Oracle分页数据
        /// </summary>
        /// <param name="connectionstring">连接字符串</param>
        /// <returns></returns>
        private DataTable GetOraclePageDate(string connectionstring)
        {
            var orcParameters = new OracleParameter[9];
            orcParameters[0] = new OracleParameter("p_tablename", OracleType.VarChar, 50) {Value = _TableName};
            orcParameters[1] = new OracleParameter("p_tablecolumn", OracleType.VarChar, 1000) {Value = _QueryFieldName};
            orcParameters[2] = new OracleParameter("p_order", OracleType.VarChar, 100) { Value = _OrderStr };
            orcParameters[3] = new OracleParameter("p_pagesize", OracleType.Int32) { Value = PageSize };
            orcParameters[4] = new OracleParameter("p_curpage", OracleType.Int32) { Value = PageIndex };
            orcParameters[5] = new OracleParameter("p_where", OracleType.VarChar, 1000) { Value = _QueryCondition };
            orcParameters[6] = new OracleParameter("p_rowcount", OracleType.Int32) { Value = 0, Direction = ParameterDirection.Output }; //返回的总记录数 
            orcParameters[7] = new OracleParameter("p_pagecount", OracleType.Int32) { Value = 0, Direction = ParameterDirection.Output }; //总页数
            orcParameters[8] = new OracleParameter("p_cursor", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtPageData = DbFactoryProvider.GetProvider(PageDbType, connectionstring).ExecuteProcedureForDataTable("package_page.proc_page", _TableName, orcParameters);

            if (_isQueryTotalCounts)
            {
                Int32.TryParse(orcParameters[6].Value.ToString(), out _TotalCount);
            }

            if (_TotalCount == 0)
            {
                _PageIndex = 0;
                _PageCount = 0;
            }
            else
            {
                _PageCount = _TotalCount % _PageSize == 0 ? _TotalCount / _PageSize : _TotalCount / _PageSize + 1;

                if (_PageIndex > _PageCount)
                {
                    _PageIndex = _PageCount;
                    orcParameters[3].Value = _PageSize;
                    dtPageData = QueryDataTable(connectionstring);
                }
            }

            return dtPageData;
        }
        #endregion

        /// <summary>
        /// 得到总的记录数
        /// </summary>
        /// <param name="connectionstring">连接字符串</param>
        /// <returns>总的记录数</returns>
        public int GetTotalCount(string connectionstring)
        {
            //string strSql = " select count(1) from "+_TableName;

            //if (_QueryCondition != string.Empty)
            //{
            //    strSql += " where " + _QueryCondition;
            //}
            string strSql = "";
            if (_QueryCondition != string.Empty)
            {
                strSql = " select count(1) from " + _TableName + " where " + _QueryCondition; ;
            }
            else
            {
                strSql = "select rows from sys.sysindexes where id = object_id('" 
                       + _TableName + "') and indid in (0,1) ";//当查询条件为空时，高效得到记录总数
            }

            return int.Parse(RDIFramework.Utilities.DbFactoryProvider.GetProvider(connectionstring).ExecuteScalar(strSql).ToString());
            //return Convert.ToInt32(DBProviderSQL.GetSingle(strSql.ToString(), connectionstring));           
        }
    }
    #endregion
}
