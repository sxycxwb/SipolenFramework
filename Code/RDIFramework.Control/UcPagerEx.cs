using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    public delegate void PageChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 分页用户控件，仅提供分页信息显示及改变页码操作
    /// </summary>
    public partial class UcPagerEx : UserControl
    {
        public event PageChangedEventHandler PageChanged;

        private int _pageSize;
        private int m_PageCount;
        private int _recordCount;
        private int _pageIndex;


        public UcPagerEx()
        {
            InitializeComponent();
            this._pageSize = 10;
            this._recordCount = 0;
            this._pageIndex = 1; //默认为第一页
        }

        /// <summary> 
        /// 带参数的构造函数
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public UcPagerEx(int recordCount, int pageSize)
        {
            InitializeComponent();

            this._pageSize = pageSize;
            this._recordCount = recordCount;
            this._pageIndex = 1; //默认为第一页
            this.InitPageInfo();
        }

        protected virtual void OnPageChanged(EventArgs e)
        {
            if (PageChanged != null)
            {
                InitPageInfo();
                PageChanged(this, e);
            }
        }

        [Description("设置或获取一页中显示的记录数目"), DefaultValue(20), Category("分页")]
        public int PageSize
        {
            set
            {
                this._pageSize = value;
            }
            get
            {
                return this._pageSize;
            }
        }

        [Description("获取记录总页数"), DefaultValue(0), Category("分页")]
        public int PageCount
        {
            get
            {
                return this.m_PageCount;
            }
        }

        [Description("设置或获取记录总数"), Category("分页")]
        public int RecordCount
        {
            set
            {
                this._recordCount = value;
            }
            get
            {
                return this._recordCount;
            }
        }

        [Description("当前的页面索引, 开始为1"), DefaultValue(0), Category("分页")]
        [Browsable(false)]
        public int PageIndex
        {
            set
            {
                this._pageIndex = value;
            }
            get
            {
                return this._pageIndex;
            }
        }

        /// <summary> 
        /// 初始化分页信息
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount, int pageSize)
        {
            this._recordCount = recordCount;
            this._pageSize = pageSize;
            this.InitPageInfo();
        }

        /// <summary> 
        /// 初始化分页信息
        /// <param name="recordCount">总记录数</param>
        /// </summary>
        public void InitPageInfo(int recordCount)
        {
            this._recordCount = recordCount;
            this.InitPageInfo();
        }

        /// <summary> 
        /// 初始化分页信息
        /// </summary>
        public void InitPageInfo()
        {
            if (this._pageSize < 1)
                this._pageSize = 10; //如果每页记录数不正确，即更改为10
            if (this._recordCount < 0)
                this._recordCount = 0; //如果记录总数不正确，即更改为0

            //取得总页数
            if (this._recordCount % this._pageSize == 0)
            {
                this.m_PageCount = this._recordCount / this._pageSize;
            }
            else
            {
                this.m_PageCount = this._recordCount / this._pageSize + 1;
            }

            //设置当前页
            if (this._pageIndex > this.m_PageCount)
            {
                this._pageIndex = this.m_PageCount;
            }
            if (this._pageIndex < 1)
            {
                this._pageIndex = 1;
            }

            //设置上一页按钮的可用性
            bool enable = (this.PageIndex > 1);
            this.btnPrevious.Enabled = enable;

            //设置首页按钮的可用性
            enable = (this.PageIndex > 1);
            this.btnFirst.Enabled = enable;

            //设置下一页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnNext.Enabled = enable;

            //设置末页按钮的可用性
            enable = (this.PageIndex < this.PageCount);
            this.btnLast.Enabled = enable;

            this.txtPageIndex.Text = this._pageIndex.ToString();
            
            this.lblPageInfo.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", this._recordCount, this._pageSize, this.m_PageCount);
        }

        public void RefreshData(int page)
        {
            this._pageIndex = page;
            EventArgs e = new EventArgs();
            OnPageChanged(e);
        }

        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            this.RefreshData(1);
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            if (this._pageIndex > 1)
            {
                this.RefreshData(this._pageIndex - 1);
            }
            else
            {
                this.RefreshData(1);
            }
        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (this._pageIndex < this.m_PageCount)
            {
                this.RefreshData(this._pageIndex + 1);
            }
            else if (this.m_PageCount < 1)
            {
                this.RefreshData(1);
            }
            else
            {
                this.RefreshData(this.m_PageCount);
            }
        }

        private void btnLast_Click(object sender, System.EventArgs e)
        {
            this.RefreshData(this.m_PageCount > 0 ? this.m_PageCount : 1);
        }

        private void txtPageIndex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num;
                try
                {
                    num = Convert.ToInt16(this.txtPageIndex.Text);
                }
                catch
                {
                    num = 1;
                }

                if (num > this.m_PageCount)
                    num = this.m_PageCount;
                if (num < 1)
                    num = 1;

                this.RefreshData(num);
            }
        }
    }
}
