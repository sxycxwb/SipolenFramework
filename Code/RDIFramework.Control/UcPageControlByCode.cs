#region  版权信息
/*---------------------------------------------------------------------*
// Copyright (C) 2010 http://www.cnblogs.com/huyong
// 版权所有。 
// 项目  名称：《Winform通用控件库》
// 文  件  名： UcPageControlByCode.cs
// 类  全  名： DotNet.Controls.UcPageControlByCode 
// 描      述:  分页控件（使用代码实现，不用存储过程）
// 创建  时间： 2011-01-05
// 创建人信息： [**** 姓名:胡勇 QQ:406590790 E-Mail:406590790@qq.com *****]
*----------------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    using RDIFramework.Utilities;

    /// <summary>
    /// 分页控件（使用代码实现，不用存储过程）
    /// UcPageControlByCode
    /// 修改纪录
    ///     2013-11-28 EricHu 整合此分页控件进RDIFramework.NET，同时修改对Oracle、Access、DB2的支持。
    ///     2010-01-06 胡勇 修改转到某页由原来的KeyPress方法改为KeyDown，让用户按回车键确认转页，以防止连续绑定两次。
    ///     2011-01-06 胡勇 增加对分页控件的初始化代码:public DataTable InitializePageControl()。
    ///     2011-01-05 胡勇 创建分页控件
    ///     
    /// <author>
    ///     <name>胡勇</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    public partial class UcPageControlByCode : UserControl
    {
        #region 私有变量
        //定义几个保存分页参数变量          
        int pageCount, recCount, currentPage, pages, jumpPage;
        int pageCounts, pageIndex, jumpPages;
        #endregion

        #region 自定义事件
        /// <summary>
        /// 单击分页按钮(第一页、上一页、下一页、最后页、跳页)时发生
        /// </summary>
        [Category("UcPageControlByCode"), Description("单击分页按钮时发生")]
        public event EventHandler OnEventPageClicked;
        #endregion

        #region 自定义属性
        private int    _pageSize          = 50;             //分页大小
        private string _sqlWhereStatement = string.Empty;   //MsSql Where语句
        private string _sqlConnString     = string.Empty;   //MsSql 数据库连接字符串
        private string _TableName         = string.Empty;   //表名        
        private string _orderField        = string.Empty;   //数据表的排序字段
        private string _primaryKey        = string.Empty;   //数据表的主键
        private string _queryFieldList    = "*";            //字段列表（默认为：*)
        private DataTable _pageTable      = new DataTable();
       
        /// <summary>
        /// 返回当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return pageIndex + 1;
            }
        }

        [Browsable(true), Category("UcPageControlByCode"), Description("得到或设置分页大小(默认为:50)")]
        /// <summary>
        /// 得到或设置分页大小(默认为:50)
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }


        [Browsable(false), Category("UcPageControlByCode"), Description("得到或设置SQL语句的Where表达式")]
        /// <summary>
        /// SQL语句的Where表达式
        /// </summary>
        public string SqlWhereStatement
        {
            get
            {
                return _sqlWhereStatement;
            }
            set
            {
                _sqlWhereStatement = value;
            }
        }       

        [Browsable(false), Category("UcPageControlByCode"), Description("得到用户单击分页按钮后返回的DataTable")]
        /// <summary>
        /// 得到用户单击分页按钮后返回的DataTable
        /// </summary>
        public DataTable PageTable
        {
            get
            {
                return _pageTable;
            }
        }

        [Browsable(true), Category("UcPageControlByCode"), Description("设置或得到与分页控件绑定的表名或视图名")]
        /// <summary>
        /// 设置或得到与分页控件绑定的表名或视图名
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

        [Browsable(true), Category("UcPageControlByCode"), Description("设置或得到分页控件排序字段")]
        /// <summary>
        /// 设置或得到分页控件排序字段
        /// </summary>
        public string OrderField
        {
            get
            {
                return _orderField;
            }
            set
            {
                _orderField = value;
            }
        }

        [Browsable(true), Category("UcPageControlByCode"), Description("设置或得到分页控件绑定数据表的主键")]
        /// <summary>
        /// 设置或得到分页控件绑定数据表的主键
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                return _primaryKey;
            }
            set
            {
                _primaryKey = value;
            }
        }

        [Browsable(true), Category("UcPageControlByCode"), Description("设置或得到分页控件绑定的字段列表(默认为:*)")]
        /// <summary>
        /// 设置或得到分页控件绑定的字段列表(默认为:*)
        /// </summary>
        public string QueryFieldList
        {
            get
            {
                return _queryFieldList;
            }
            set
            {
                _queryFieldList = value;
            }
        }
        #endregion

        #region 构造函数
        public UcPageControlByCode()
        {
            InitializeComponent();
        }
        #endregion

        #region 分页实现相关代码

        CurrentDbType pageDbType = CurrentDbType.SqlServer;
        string pageConnstring = string.Empty;

        #region 给UcPageControlByCode控件传递必需参数
        /// <summary>
        /// 给UcPageControlByCode控件传递必需参数
        /// </summary>
        /// <param name="connStr">连接字符串</param>
        /// <param name="whereStatement">MsSql Where语句 </param>
        /// <param name="tbName">数据表名或视力名</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="primaryKeyName">主键值</param>
        /// <param name="fieldList">字段列表(默认为:*)</param>
        public void SetUcPageControlPars(CurrentDbType dbType,string dbConnstring, string whereStatement, string tbName
                                       , string orderField, string primaryKeyName, string fieldList)
        {
            if (dbConnstring == null)
            {
                DialogHelper.ShowErrorMsg("无可用数据库连接！");
                return;
            }
            else
            {
                this.pageDbType = dbType;
                this.pageConnstring = dbConnstring;
            }

            this.SqlWhereStatement = whereStatement;
            this.TableName = tbName;
            this.OrderField = orderField;
            this.PrimaryKey = primaryKeyName;
            if (!string.IsNullOrEmpty(fieldList.Trim()))
            {
                this.QueryFieldList = fieldList;
            }
        }
        #endregion

        #region 初始化UcPageControlByCode:DataTable InitializePageControl()
        /// <summary>
        /// 绑定UcPageControlByCode(并返回包含当前页的DataTable)
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable BindPageControl()
        {
            recCount = Calc();                          //获取总记录数  
            pageCount = recCount / PageSize + OverPage();//计算总页数（加上OverPage()函数防止有余数造成显示数据不完整）
            pageCounts = recCount / PageSize - ModPage(); //保存总页数（减去ModPage()函数防止SQL语句执行时溢出查询范围，可以用存储过程分页算法来理解这句） 
            pageIndex = 0;                               //保存一个为0的页面索引值到pageIndex   
            jumpPages = pageCount;                       //保存pageCount到jumpPages，跳页时判断用户输入数是否超出页码范围  
            lblPageCount.Text = pageCount.ToString();            //显示lblpageCount、lblrecCount的状态   
            lblRecCount.Text = recCount.ToString();

            //判断跳页文本框失效                   
            if (recCount <= PageSize)
            {
                txtGoToPage.Enabled = false;
            }
            else
            {
                txtGoToPage.Enabled = true;
            }

            return TDataBind();//调用数据绑定函数TDataBind()进行数据绑定运算   
        }
        #endregion

        /// <summary>
        /// 计算余页
        /// </summary>
        /// <returns></returns>         
        private int OverPage()
        {
            int pages = 0;
            if (recCount % PageSize != 0)
                pages = 1;
            else
                pages = 0;
            return pages;
        }

        /// <summary>
        /// 计算余页，防止SQL语句执行时溢出查询范围   
        /// </summary>
        /// <returns></returns>
        private int ModPage()
        {
            int pages = 0;
            if (recCount % PageSize == 0 && recCount != 0)
                pages = 1;
            else
                pages = 0;
            return pages;
        }

        /// <summary>
        /// 计算总记录数
        /// </summary>
        /// <returns>记录总数</returns> 
        private int Calc()
        {
            int RecordCount = 0;
            string sqlStatement = string.Empty;
            if (string.IsNullOrEmpty(SqlWhereStatement.Trim()))
            {
                sqlStatement = "select count(*) as rowsCount from " + TableName;
            }
            else
            {
                sqlStatement = "select count(*) as rowsCount from " +TableName + " where " + SqlWhereStatement;
            }

            IDataReader dr = DbFactoryProvider.GetProvider(this.pageDbType, this.pageConnstring).ExecuteReader(sqlStatement); ;
            if (dr.Read())
                RecordCount = Int32.Parse(dr["rowsCount"].ToString());
            dr.Close();
            dr.Dispose();
            return RecordCount;
        }

        private DataTable TDataBind()
        {
            //读取页码值保存到currentPage变量中进行按钮失效运算      
            currentPage = pageIndex;
            //读取总页参数进行按钮失效运算         
            pages = pageCounts;
            //判断四个按钮（首页、上一页、下一页、尾页）状态   
            if (currentPage + 1 > 1)
            {
                btnFirstPage.Enabled = true;
                btnPrevPage.Enabled = true;
            }
            else
            {
                btnFirstPage.Enabled = false;
                btnPrevPage.Enabled = false;
            }
            if (currentPage == pages)
            {
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
                btnLastPage.Enabled = true;
            }          
            //核心SQL语句，进行查询运算（决定了分页的效率:)）
            StringBuilder sbSqlStatement = new StringBuilder();
            switch(this.pageDbType)
            {
                case CurrentDbType.SqlServer:
                case CurrentDbType.DB2:
                    if (string.IsNullOrEmpty(SqlWhereStatement.Trim()))
                    {
                        sbSqlStatement.Append("SELECT TOP " + PageSize + "  " + QueryFieldList + " FROM " + TableName + " WHERE " + PrimaryKey + " NOT IN(SELECT TOP ");
                        sbSqlStatement.Append(PageSize * currentPage + "  " + PrimaryKey + " FROM " + TableName);
                        sbSqlStatement.Append(" ORDER BY " + OrderField + " DESC) ORDER BY " + OrderField + " DESC");
                    }
                    else
                    {
                        sbSqlStatement.Append("SELECT TOP " + PageSize + "  " + QueryFieldList + " FROM " + TableName + " WHERE " + SqlWhereStatement + " AND " + PrimaryKey + " NOT IN(SELECT TOP ");
                        sbSqlStatement.Append(PageSize * currentPage + "  " + PrimaryKey + "  FROM " + TableName + " WHERE " + SqlWhereStatement + "  ORDER BY " + OrderField + " DESC) ORDER BY " + OrderField + " DESC");
                    }
                    break;
                case CurrentDbType.Oracle:
                    string sqlCount = (this.PageIndex * this.PageSize).ToString();
                    string sqlStart = ((this.PageIndex - 1) * this.PageSize).ToString();
                    if (!string.IsNullOrEmpty(SqlWhereStatement)) 
                    {
                        SqlWhereStatement = "WHERE " + SqlWhereStatement;
                    }

                    sbSqlStatement.Append(string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                        , TableName, SqlWhereStatement, OrderField, sqlCount, sqlStart));
                    break;
                case CurrentDbType.Access:
                    sqlStart = ((this.PageIndex - 1) * this.PageSize).ToString();
                    sbSqlStatement.Append(string.Format("SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} * FROM {2} T ORDER BY {3} ) T1 ORDER BY {4} DESC ) T2 ORDER BY {5} "
                                    , PageSize, sqlStart, TableName, OrderField, OrderField, OrderField));
                    break;
                    
            }
            _pageTable = DbFactoryProvider.GetProvider(this.pageDbType, this.pageConnstring).Fill(sbSqlStatement.ToString());
            //显示Label控件LcurrentPaget和文本框控件gotoPage状态           
            lblCurrentPage.Text = (currentPage + 1).ToString();
            txtGoToPage.Text = (currentPage + 1).ToString();
            return _pageTable;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = pageIndex;
            pages = pageCounts;
            currentPage = 0;
            pageIndex = currentPage;
            //调用数据绑定函数TDataBind()            
            _pageTable = TDataBind();
            if (OnEventPageClicked != null)
            {
                OnEventPageClicked(this, null);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            currentPage = pageIndex;
            pages = pageCounts;
            currentPage--;
            pageIndex = currentPage;
            //调用数据绑定函数TDataBind()            
            _pageTable = TDataBind();
            if (OnEventPageClicked != null)
            {
                OnEventPageClicked(this, null);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage = pageIndex;
            pages = pageCounts;
            currentPage++;
            pageIndex = currentPage;
            //调用数据绑定函数TDataBind()            
            _pageTable = TDataBind();
            if (OnEventPageClicked != null)
            {
                OnEventPageClicked(this, null);
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = pageIndex;
            pages = pageCounts;
            currentPage = pages;
            pageIndex = currentPage;
            //调用数据绑定函数TDataBind()            
            _pageTable = TDataBind();
            if (OnEventPageClicked != null)
            {
                OnEventPageClicked(this, null);
            }
        }

        private void txtGoToPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //读取可用页数值保存到jumpPage变量中       
                    jumpPage = jumpPages;
                    //判断用户输入值是否超过可用页数范围值                
                    if (Int32.Parse(txtGoToPage.Text) > jumpPage || Int32.Parse(txtGoToPage.Text) <= 0)
                    {
                        DialogHelper.ShowWarningMsg("页码范围越界!");
                        txtGoToPage.Clear();
                        txtGoToPage.Focus();
                    }
                    else
                    {
                        //转换用户输入值保存在int型InputPage变量中              
                        int InputPage = Int32.Parse(txtGoToPage.Text.ToString()) - 1;
                        //写入InputPage值到pageIndex中                  
                        pageIndex = InputPage;
                        //调用数据绑定函数TDataBind()再次进行数据绑定运算             
                        _pageTable = TDataBind();
                        if (OnEventPageClicked != null)
                        {
                            OnEventPageClicked(this, null);
                        }
                    }
                }
                catch (Exception ex) //捕获由用户输入不正确数据类型时造成的异常    
                {
                    DialogHelper.ShowWarningMsg(ex.Message);
                    txtGoToPage.Clear();
                    txtGoToPage.Focus();
                }
            }
        }
        #endregion       
    }
}
