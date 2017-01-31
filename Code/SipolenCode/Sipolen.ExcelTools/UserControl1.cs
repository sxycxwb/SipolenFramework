using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sipolen.ExcelTools
{
    public partial class AutoTextBoxNew : TextBox
    {
        private string[] _keys;
        private SearchMode _searchMode;
        private List<BaseItem> items = new List<BaseItem>();
        private GridView _view;
        private GridControl _grid;
        private int _gvWidth = 200;
        private int _gvHeight = 200;
        private DataTable _dtlData = null;//绑定的数据源
        private Control _form;
        private string _needValue;
        private string _needName;
        private bool _isSearch = true;
        private bool _isShowAllData = false;

        #region 属性
        [TypeConverter(typeof(System.ComponentModel.CollectionConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("样式")]
        [Description("绑定列")]
        public List<BaseItem> Items
        {
            get
            { return items; }
        }

        [Category("样式")]
        [Description("模糊查找关键字")]
        public string[] SearchKey
        {
            get { return _keys; }
            set { _keys = value; }
        }

        [Category("样式")]
        [Description("赋值在文本框的tag里，对应数据源的字段名称")]
        public string NeedValue
        {
            get { return _needValue; }
            set { _needValue = value; }
        }

        [Category("样式")]
        [Description("赋值在文本框上的内容,对应数据源的字段名称")]
        public string NeedName
        {
            get { return _needName; }
            set { _needName = value; }
        }

        [Category("样式")]
        [Description("模糊查找的方式，有左模糊、右模糊、全模糊")]
        public SearchMode SearchModel
        {
            get { return _searchMode; }
            set
            {
                _searchMode = value;
            }
        }

        [Category("样式")]
        [Description("GridView宽度")]
        public int GridViewWidth
        {
            get { return _gvWidth; }
            set
            {
                _gvWidth = value;
            }
        }

        [Category("样式")]
        [Description("GridView高度")]
        public int GridViewHeight
        {
            get { return _gvHeight; }
            set
            {
                _gvHeight = value;
            }
        }

        [Category("样式")]
        [Description("当未输入查询条件时是否全显示数据")]
        public bool IsShowAllData
        {
            get { return _isShowAllData; }
            set
            {
                _isShowAllData = value;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public AutoTextBoxNew()
        {
            InitializeComponent();
            _grid = new GridControl();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dtlSource"></param>
        public void Init(DataTable dtlSource)
        {
            _dtlData = dtlSource;
            initListView();
        }

        /// <summary>
        /// 初始化GridView
        /// </summary>
        private void initListView()
        {
            if (items != null)
            {
                try
                {
                    _view = new GridView();
                    _view.OptionsView.ShowGroupPanel = false;
                    _view.OptionsBehavior.Editable = false;
                    _view.OptionsView.ColumnAutoWidth = false;
                    _grid.KeyDown += new KeyEventHandler(_grid_KeyDown);
                    _grid.MouseDoubleClick += new MouseEventHandler(_grid_MouseDoubleClick);
                    _grid.Leave += new EventHandler(_grid_Leave);
                    foreach (BaseItem item in items)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();

                        col.FieldName = item.FieldCode;
                        col.Caption = item.DisplayName;
                        col.Width = item.ColumnWidth == 0 ? 100 : item.ColumnWidth;
                        col.Visible = true;
                        _view.Columns.Add(col);
                    }
                    _grid.MainView = _view;
                    _grid.Width = _gvWidth;
                    _grid.Height = _gvHeight;
                    _form = this.Parent;
                    while (true)
                    {
                        if (_form.Parent == null) break;
                        _form = _form.Parent;
                    }
                    _grid.Location = _form.PointToClient(this.Parent.PointToScreen(new Point(this.Left, this.Top + this.Height + 3)));
                    _form.Controls.Add(_grid);
                    _grid.Visible = false;
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// GridView焦点离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _grid_Leave(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                _grid.Visible = false;
            }
        }

        /// <summary>
        /// GridView双击事件，赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_view.FocusedRowHandle >= 0)
            {
                _isSearch = false;
                this.Tag = _view.GetFocusedRowCellValue(_needValue).ToString();
                this.Text = _view.GetFocusedRowCellValue(_needName).ToString();
                _grid.Visible = false;
            }
        }

        /// <summary>
        /// GridView回车事件，赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_view.FocusedRowHandle >= 0)
                {
                    _isSearch = false;
                    this.Tag = _view.GetFocusedRowCellValue(_needValue).ToString();
                    this.Text = _view.GetFocusedRowCellValue(_needName).ToString();
                    _grid.Visible = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text != "")
            {
                if (_isSearch)
                {
                    DataTable dt = Search(this.Text);
                    _grid.DataSource = dt;
                    _grid.Visible = true;
                    _grid.BringToFront();
                }
                else
                {
                    _isSearch = true;
                }

            }
            else
            {
                if (_isShowAllData)
                {
                    _grid.DataSource = _dtlData;
                    _grid.Visible = true;
                    _grid.BringToFront();
                }
                else
                {
                    _grid.Visible = false;
                }
            }
            base.OnTextChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _grid.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (_grid.DataSource != null)
                {
                    _isSearch = false;
                    this.Tag = _view.GetRowCellValue(0, _needValue).ToString();
                    this.Text = _view.GetRowCellValue(0, _needName).ToString();
                    _grid.Visible = false;
                }
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// 检索
        /// </summary>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        private DataTable Search(string keyvalue)
        {
            DataTable dtlReturn = null;
            if (_dtlData != null && _keys.Length > 0)
            {
                string filters = "";
                foreach (string str in _keys)
                {
                    switch (_searchMode)
                    {
                        case SearchMode.Left:
                            filters += "or " + str + " like'%" + keyvalue + "' ";
                            break;
                        case SearchMode.Right:
                            filters += "or " + str + " like'" + keyvalue + "%' ";
                            break;
                        case SearchMode.All:
                            filters += "or " + str + " like'%" + keyvalue + "%' ";
                            break;
                    }
                }
                filters = filters.Substring(2, filters.Length - 2);
                DataRow[] dr = _dtlData.Select(filters);
                if (dr.Length > 0)
                {
                    dtlReturn = dr.CopyToDataTable();
                }
            }
            return dtlReturn;
        }

        /// <summary>
        /// 焦点离开隐藏起来
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            if (!_grid.IsFocused)
            {
                _grid.Visible = false;
            }
            base.OnLeave(e);
        }

    }

    public class BaseItem
    {
        public string DisplayName
        { get; set; }
        public string FieldCode
        { get; set; }
        public int ColumnWidth
        { get; set; }
    }

    public enum SearchMode { Left, Right, All }
}
