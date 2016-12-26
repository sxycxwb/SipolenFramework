#region  ��Ȩ��Ϣ
/*---------------------------------------------------------------------*
// Copyright (C) 2010 http://www.cnblogs.com/huyong
// ��Ȩ���С� 
// ��Ŀ  ���ƣ���Winformͨ�ÿؼ��⡷
// ��  ��  ���� UcPageControl.cs
// ��  ȫ  ���� RDIFramework.Controls.UcPageControl 
// ��      ��:  ��ҳ�ؼ�
// ����  ʱ�䣺 2010-06-05
// ��������Ϣ�� [**** ����:EricHu QQ:406590790 E-Mail:406590790@qq.com *****]
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
    #region ί������
    /// <summary>
    /// ����ί��
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate int EventPagingHandler(EventPagingArg e);
    #endregion

    #region ��ҳ�ؼ�
    /// <summary>
    /// ��ҳ�ؼ�
    /// 
    /// �޸ļ�¼(�˷�ҳ�ؼ���������޸ģ��������������ɷ���ʹ�á�)
    /// 
    ///     2014-01-20 EricHu V2.7 �ṩ��Oracle��ҳ��֧�֣�
    ///     2013-08-21 EricHu V2.5 ���¶�Sqlserver��ҳ�Ĵ洢���̣���ҳЧ�ʸ��ߡ�
    ///     2010-12-06 EricHu ����һ������һ����������ĩ�����ݵ��������أ���Ϊ�ؼ����������˴���
    ///     2010-12-05 EricHu �Է�ҳ�ؼ�����������Ӧ�Ż�
    ///     2010-06-05 EricHu ������ҳ�ؼ�
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
    [Description("��ҳ�ؼ�")]
    public partial class UcPageControl : UserControl
    {
        #region �����¼�
        /// <summary>
        /// �����ƶ�����ǰҳ��һĩ��¼ʱ����
        /// </summary>
        [Category("�û��ؼ�����"), Description("�����ƶ�����ǰҳ��һĩ��¼ʱ������"),Browsable(false)]
        public event EventHandler OnBindingNavigatorMovePreviousItemClick;

        /// <summary>
        /// �����ƶ�����ǰҳ��һ����¼ʱ����
        /// </summary>
        [Category("�û��ؼ�����"), Description("�����ƶ�����ǰҳ��һ����¼ʱ������"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveFirstItemClick;

        /// <summary>
        /// �����ƶ�����ǰҳ��һ����¼ʱ����
        /// </summary>
        [Category("�û��ؼ�����"), Description("�����ƶ�����ǰҳ��һ����¼ʱ������"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveNextItemClick;

        /// <summary>
        /// �����ƶ�����ǰҳ���һ����¼ʱ����
        /// </summary>
        [Category("�û��ؼ�����"), Description("�����ƶ�����ǰҳ���һ����¼ʱ������"), Browsable(false)]
        public event EventHandler OnBindingNavigatorMoveLastItemClick;

        /// <summary>
        /// ��������ҳ��ť(��һҳ����һҳ����һҳ�����һҳ��ת��ĳҳ)ʱ����
        /// </summary>
        [Category("�û��ؼ�����"), Description("��ҳʱ������")]
        public event EventPagingHandler EventPaging;
        #endregion 

        #region ���캯��
        public UcPageControl()
        {
            InitializeComponent();
        }
        #endregion

        #region ����

        private int _pageSize    = 20;  //ÿҳ��ʾ��¼��
        private int _nMax        = 0;   //�ܼ�¼��
        private int _pageCount   = 0;   //ҳ��=�ܼ�¼��/ÿҳ��ʾ��¼��
        private int _pageCurrent = 0;   //��ǰҳ��

        /// <summary>
        /// ÿҳ��ʾ��¼��
        /// </summary>
        [Category("�û��ؼ�����"), Description("ÿҳ��ʾ��¼����"), Browsable(true)]
        public int PageSize
        {
            get 
            { 
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                GetPageCount();//ҳ��
            }
        }              
      
        /// <summary>
        /// ��¼����
        /// </summary>
        [Category("�û��ؼ�����"), Description("��¼������"),Browsable(false)]
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
        /// ҳ��
        /// </summary>
        [Category("�û��ؼ�����"), Description("ҳ����"), Browsable(false)]
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
        /// ��ǰҳ��
        /// </summary>
        [Category("�û��ؼ�����"), Description("��ǰҳ�š�"), Browsable(false)]
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

        #region ����
        [Category("�û��ؼ�����"), Description("bindingNavigator��"), Browsable(false)]
        public BindingNavigator ToolBar
        {
            get 
            { 
                return this.bindingNavigator;
            }
        }

        /// <summary>
        /// �õ���ҳ��
        /// </summary>
        private void GetPageCount()
        {
            this.PageCount = this.NMax > 0 ? Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize))) : 0;
        }

        /// <summary>
        /// �󶨷�ҳ�ؼ�(�ؼ�����)
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
            this.lblMaxPage.Text = "��"+this.NMax.ToString()+"����¼";
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

        #region ��ť�¼�
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
                MessageBox.Show("�������ָ�ʽ����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    #region �Զ����¼����ݻ���
    /// <summary>
    /// �Զ����¼����ݻ���
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

    #region ����Դ�ṩ(PageData)
    /// <summary>
    /// ����Դ�ṩ
    /// 
    ///     �޸ļ�¼��
    ///     2010-12-19 EricHu �޸�int GetTotalCount(string connectionstring)����
    ///                     ����ѯ����Ϊ��ʱ����Ч�õ�ָ����ļ�¼������
    /// </summary>
    public class PageData
    {
        DataTable dtPageData                         = null;
        private int    _PageSize           = 20;           //��ҳ��С
        private int    _PageIndex          = 1;            //��ǰҳ
        private int    _PageCount          = 0;            //��ҳ��
        private int    _TotalCount         = 0;            //�ܼ�¼��
        private string _QueryFieldName     = "*";          //���ֶ�FieldStr
        private bool   _isQueryTotalCounts = true;         //�Ƿ��ѯ�ܵļ�¼����
        private string _TableName          = string.Empty; //����        
        private string _OrderStr           = string.Empty; //����_SortStr
        private string _QueryCondition     = string.Empty; //��ѯ������ RowFilter
        private string _PrimaryKey         = string.Empty; //����

        /// <summary>
        /// �Ƿ��ѯ�ܵļ�¼����
        /// </summary>
        public bool IsQueryTotalCounts
        {
            get { return _isQueryTotalCounts; }
            set { _isQueryTotalCounts = value; }
        }

        /// <summary>
        /// ��ҳ��С(ÿҳ��ʾ����������)
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
        /// ��ǰҳ
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
        /// ��ҳ��
        /// </summary>
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
        }

        /// <summary>
        /// �ܼ�¼��
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }

        /// <summary>
        /// ��������ͼ��
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
        /// ���ֶ�FieldStr
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
        /// �����ֶ�
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
        /// ��ѯ����
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
        /// ����
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
        /// �õ���ҳ����
        /// </summary>
        /// <param name="connectionstring">�����ַ���</param>
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

        #region private DataTable GetSqlSeverPageDate(string connectionstring) �õ�SqlServer��ҳ����
        /// <summary>
        /// �õ�SqlServer��ҳ����
        /// </summary>
        /// <param name="connectionstring">�����ַ���</param>
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

        #region private DataTable GetOraclePageDate(string connectionstring) �õ�Oracle��ҳ����
        /// <summary>
        /// �õ�Oracle��ҳ����
        /// </summary>
        /// <param name="connectionstring">�����ַ���</param>
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
            orcParameters[6] = new OracleParameter("p_rowcount", OracleType.Int32) { Value = 0, Direction = ParameterDirection.Output }; //���ص��ܼ�¼�� 
            orcParameters[7] = new OracleParameter("p_pagecount", OracleType.Int32) { Value = 0, Direction = ParameterDirection.Output }; //��ҳ��
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
        /// �õ��ܵļ�¼��
        /// </summary>
        /// <param name="connectionstring">�����ַ���</param>
        /// <returns>�ܵļ�¼��</returns>
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
                       + _TableName + "') and indid in (0,1) ";//����ѯ����Ϊ��ʱ����Ч�õ���¼����
            }

            return int.Parse(RDIFramework.Utilities.DbFactoryProvider.GetProvider(connectionstring).ExecuteScalar(strSql).ToString());
            //return Convert.ToInt32(DBProviderSQL.GetSingle(strSql.ToString(), connectionstring));           
        }
    }
    #endregion
}
