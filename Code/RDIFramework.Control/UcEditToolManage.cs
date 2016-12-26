#region  版权信息
/*---------------------------------------------------------------------*
// Copyright (C) 2010 http://www.cnblogs.com/huyong
// 版权所有。 
// 项目  名称：《Winform通用控件库》
// 文  件  名： 用户控件属性.cs
// 类  全  名： RDIFramework.Controls.用户控件属性 
// 描      述:  数据编辑控件
// 创建  时间： 2010-06-18
// 创建人信息： [**** 姓名:EricHu QQ:406590790 E-Mail:406590790@qq.com *****]
*----------------------------------------------------------------------*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// 数据编辑控件
    /// 用户控件属性
    /// 
    ///修改纪录:
    ///       2010-06-18 EricHu 创建数据编辑控件
    /// 
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("OnCloseButtomClicked")]
    [ToolboxBitmap(typeof(UcEditToolManage), "Images.UcEditToolManage.bmp")]
    [Description("数据编辑控件")]
    public partial class UcEditToolManage : UserControl
    {
        #region 自定义属性
        private string _selectedDataTableName = "用地档案";
        [Browsable(false),Category("用户控件属性"), Description("设置或获取用户选择的数据表")]
        public string SelectedDataTableName
        {
            get
            {
                return _selectedDataTableName;
            }
            set
            {
                _selectedDataTableName = value;
            }
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 增加按钮的单击事件
        /// </summary>
        [Category("用户控件属性"),Description("增加按钮的单击事件")]
        public event EventHandler OnAddButtomClicked;

        /// <summary>
        /// 修改按钮的单击事件
        /// </summary>
        [Category("用户控件属性"),Description("修改按钮的单击事件")]
        public event EventHandler OnEditButtomClicked;

        /// <summary>
        /// 删除按钮的单击事件
        /// </summary>
        [Category("用户控件属性"),Description("删除按钮的单击事件")]
		public event EventHandler OnDeleteButtomClicked;

        /// <summary>
        /// 保存按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("保存按钮的单击事件")]
		public event EventHandler OnSaveButtomClicked;

        /// <summary>
        /// 取消按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("取消按钮的单击事件")]
		public event EventHandler OnCancelButtomClicked;

        /// <summary>
        /// 显示记录列表按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("显示记录列表按钮的单击事件")]
		public event EventHandler OnShowRecordListClicked;

        /// <summary>
        /// 显示记录详细信息按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("显示记录详细信息按钮的单击事件")]
		public event EventHandler OnShowRecordDetailClicked;

        /// <summary>
        /// 分隔显示按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("分隔显示按钮的单击事件")]
		public event EventHandler OnSplitShowClicked;

        /// <summary>
        /// 打印按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("打印按钮的单击事件")]
		public event EventHandler OnPrintButtomClicked;

        /// <summary>
        /// 导出按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("导出按钮的单击事件")]
		public event EventHandler OnExportButtomClicked;

        /// <summary>
        /// 关闭按钮的单击事件
        /// </summary>
		[Category("用户控件属性"),Description("关闭按钮的单击事件")]
		public event EventHandler OnCloseButtomClicked;

        /// <summary>
        /// 著录土地信息按钮的单击事件
        /// </summary>
        [Category("用户控件属性"), Description("著录土地信息按钮的单击事件")]
        public event EventHandler OnSoilInfoButtomClicked;

        /// <summary>
        /// 著录卷内目录文件按钮的单击事件
        /// </summary>
        [Category("用户控件属性"), Description("著录卷内目录文件按钮的单击事件")]
        public event EventHandler OnBookListButtomClicked;

        /// <summary>
        /// CboDataTable的SelectedIndexChanged属性值更改时发生
        /// </summary>
        [Category("用户控件属性"), Description("CboDataTable的SelectedIndexChanged属性值更改时发生")]
        public event EventHandler OnCboDataTableSelectedIndexChanged;

        /// <summary>
        /// btnReceiveData1按钮单击事件
        /// </summary>
        [Category("用户控件属性"), Description("btnReceiveData1按钮单击事件")]
        public event EventHandler OnReceiveData1ButtomClicked;

        /// <summary>
        /// btnReceiveData2按钮单击事件
        /// </summary>
        [Category("用户控件属性"), Description("btnReceiveData2按钮单击事件")]
        public event EventHandler OnReceiveData2ButtomClicked;

        /// <summary>
        /// btnReceiveData3按钮单击事件
        /// </summary>
        [Category("用户控件属性"), Description("btnReceiveData3按钮单击事件")]
        public event EventHandler OnReceiveData3ButtomClicked;
		#endregion
		
		#region 可见性属性
		private bool _addButtomVisible          = true;  //增加按钮的可见性
		private bool _editButtomVisible         = true;  //修改按钮的可见性
		private bool _deleteButtomVisible       = true;  //删除按钮的可见性
		private bool _saveButtomVisible         = true;  //保存按钮的可见性
		private bool _cancelButtomVisible       = true;  //取消按钮的可见性
		private bool _splitButtomVisible        = true;  //分隔按钮的可见性
		private bool _printButtomVisible        = true;  //打印按钮的可见性
		private bool _exportButtomVisible       = true;  //导出按钮的可见性
		private bool _closeButtomVisible        = true;  //关闭按钮的可见性
        private bool _soilInfoButtomVisible     = false; //土地信息按钮的可见性
        private bool _bookListButtomVisible     = false; //卷内目录文件按钮的可见性
        private bool _dataTableComboVisible     = false; //数据表标签与列表的可见性

        #region 接收数据可见性属性说明
        private bool _receiveDataComboVisible   = false; //接收数据下接列表的可见性
        private bool _receiveData1ButtomVisible = true;  //接收数据1按钮的可见性
        private bool _receiveData2ButtomVisible = true;  //接收数据2按钮的可见性
        private bool _receiveData3ButtomVisible = true;  //接收数据3按钮的可见性

        /// <summary>
        /// 接收数据下接列表的可见性
        /// </summary>
        [Category("用户控件属性"), Description("接收数据下接列表的可见性")]
        public bool ReceiveDataComboVisible
        {
            get
            {
                return _receiveDataComboVisible;
            }
            set
            {
                _receiveDataComboVisible = value;
                drpReceiveData.Visible = _receiveDataComboVisible;
            }
        }

        /// <summary>
        /// 接收数据1按钮的可见性
        /// </summary>
        [Category("用户控件属性"), Description("接收数据1按钮的可见性")]
        public bool ReceiveData1ButtomVisible
        {
            get
            {
                return _receiveData1ButtomVisible;
            }
            set
            {
                _receiveData1ButtomVisible = value;
                btnReceiveData1.Visible = _receiveData1ButtomVisible;
            }
        }

        /// <summary>
        /// 接收数据2按钮的可见性
        /// </summary>
        [Category("用户控件属性"), Description("接收数据2按钮的可见性")]
        public bool ReceiveData2ButtomVisible
        {
            get
            {
                return _receiveData2ButtomVisible;
            }
            set
            {
                _receiveData2ButtomVisible = value;
                btnReceiveData2.Visible = _receiveData2ButtomVisible;
            }
        }

        /// <summary>
        /// 接收数据3按钮的可见性
        /// </summary>
        [Category("用户控件属性"), Description("接收数据3按钮的可见性")]
        public bool ReceiveData3ButtomVisible
        {
            get
            {
                return _receiveData3ButtomVisible;
            }
            set
            {
                _receiveData3ButtomVisible = value;
                btnReceiveData3.Visible = _receiveData3ButtomVisible;
            }
        }
        #endregion


        /// <summary>
        /// 土地信息按钮的可见性
        /// </summary>
        [Category("用户控件属性"), Description("土地信息按钮的可见性")]
        public bool SoilInfoButtomVisible
        {
            get
            {
                return _soilInfoButtomVisible;
            }
            set
            {
                _soilInfoButtomVisible = value;
                btnSoilInfo.Visible = _soilInfoButtomVisible;
            }
        }

        /// <summary>
        /// 卷内目录文件按钮的可见性
        /// </summary>
        [Category("用户控件属性"), Description("卷内目录文件按钮的可见性")]
        public bool BookListButtomVisible
        {
            get
            {
                return _bookListButtomVisible;
            }
            set
            {
                _bookListButtomVisible = value;
                btnBookList.Visible = _bookListButtomVisible;
            }
        }

        /// <summary>
        /// 增加按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("增加按钮的可见性")]
		public bool AddButtomVisible
		{
			get
			{
				return _addButtomVisible;
			}
			set
			{
				_addButtomVisible = value;
				btnAdd.Visible = _addButtomVisible;
			}
		}

        /// <summary>
        /// 修改按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("修改按钮的可见性")]
		public bool EditButtomVisible
		{
			get
			{
				return _editButtomVisible;
			}
			set
			{
				_editButtomVisible = value;
				btnEdit.Visible = _editButtomVisible;
			}
		}

        /// <summary>
        /// 删除按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("删除按钮的可见性")]
		public bool DeleteButtomVisible
		{
			get
			{
				return _deleteButtomVisible;
			}
			set
			{
				_deleteButtomVisible = value;
				btnDelete.Visible = _deleteButtomVisible;
			}
		}

        /// <summary>
        /// 保存按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("保存按钮的可见性")]
		public bool SaveButtomVisible
		{
			get
			{
				return _saveButtomVisible;
			}
			set
			{
				_saveButtomVisible = value;
				btnSave.Visible = _saveButtomVisible;
			}
		}

        /// <summary>
        /// 取消按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("取消按钮的可见性")]
		public bool CancelButtomVisible
		{
			get
			{
				return _cancelButtomVisible;
			}
			set
			{
				_cancelButtomVisible = value;
				btnCancel.Visible = _cancelButtomVisible;
			}
		}

        /// <summary>
        /// 分隔按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("分隔按钮的可见性")]
		public bool SplitButtomVisible
		{
			get
			{
				return _splitButtomVisible;
			}
			set
			{
				_splitButtomVisible = value;
				btnSplit.Visible = _splitButtomVisible;
			}
		}

        /// <summary>
        /// 打印按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("打印按钮的可见性")]
		public bool PrintButtomVisible
		{
			get
			{
				return _printButtomVisible;
			}
			set
			{
				_printButtomVisible = value;
				btnPrint.Visible = _printButtomVisible;
			}
		}

        /// <summary>
        /// 导出按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("导出按钮的可见性")]
		public bool ExportButtomVisible
		{
			get
			{
				return _exportButtomVisible;
			}
			set
			{
				_exportButtomVisible = value;
				btnExport.Visible = _exportButtomVisible;
			}
		}

        /// <summary>
        /// 关闭按钮的可见性
        /// </summary>
		[Category("用户控件属性"),Description("关闭按钮的可见性")]
		public bool CloseButtomVisible
		{
			get
			{
				return _closeButtomVisible;
			}
			set
			{
				_closeButtomVisible = value;
				btnClose.Visible = _closeButtomVisible;
                toolStripSeparator2.Visible = _closeButtomVisible;
			}
		}

        /// <summary>
        /// 数据表标签与列表的可见性
        /// </summary>
        [Category("用户控件属性"),Description("数据表标签与列表的可见性")]
        public bool DataTableVisible
        {
            get
            {
                return _dataTableComboVisible;
            }
            set
            {
                _dataTableComboVisible = value;
                lblDataTable.Visible = cboDataTable.Visible = _dataTableComboVisible;
            }
        }
		#endregion

        #region 按钮图标属性

        private Bitmap _bookListButtomImage = RDIFramework.Controls.Properties.Resources.著录;
        private Bitmap _soilInfoButtomImage = RDIFramework.Controls.Properties.Resources.著录;

        /// <summary>
        /// 指定BookListButtom要显示的图标
        /// </summary>
        [Category("用户控件属性"), Description("指定BookListButtom要显示的图标")]
        public Bitmap BookListButtomImage
        {
            get
            {
                return _bookListButtomImage;
            }
            set
            {
                _bookListButtomImage = value;
                btnBookList.Image = _bookListButtomImage;
            }
        }
       
        /// <summary>
        /// 指定SoilInfoButtom要显示的图标
        /// </summary>
        [Category("用户控件属性"), Description("指定SoilInfoButtom要显示的图标")]
        public Bitmap SoilInfoButtomImage
        {
            get
            {
                return _soilInfoButtomImage;
            }
            set
            {
                _soilInfoButtomImage = value;
                btnSoilInfo.Image = _soilInfoButtomImage;
            }
        }

        /// <summary>
        /// 指定btnExport要显示的图标
        /// </summary>
        [Category("用户控件属性"), Description("指定btnExport要显示的图标")]
        public Bitmap ExportButtomImage
        {
            get 
            {
                return (Bitmap)btnExport.Image;
            }
            set
            {
                btnExport.Image = value;
            }
        }
        #endregion

        #region 可用性属性
        private bool _addButtomEnabled      = true; //指示是否已启用增加按钮
		private bool _editButtomEnabled     = true; //指示是否已启用修改按钮
		private bool _deleteButtomEnabled   = true; //指示是否已启用删除按钮
		private bool _saveButtomEnabled     = true; //指示是否已启用保存按钮
		private bool _cancelButtomEnabled   = true; //指示是否已启用取消按钮
		private bool _splitButtomEnabled    = true; //指示是否已启用分隔按钮
		private bool _printButtomEnabled    = true; //指示是否已启用打印按钮
		private bool _exportButtomEnabled   = true; //指示是否已启用导出按钮
		private bool _closeButtomEnabled    = true; //指示是否已启用关闭按钮
        private bool _soilInfoButtomEnabled = true; //指示是否已启用土地信息按钮
        private bool _bookListButtomEnabled = true; //指示是否已启用卷内目录文件按钮

        /// <summary>
        /// 指示是否已启用土地信息按钮
        /// </summary>
        [Category("用户控件属性"), Description("指示是否已启用土地信息按钮")]
        public bool SoilInfoButtomEnabled
        {
            get
            {
                return _soilInfoButtomEnabled;
            }
            set
            {
                _soilInfoButtomEnabled = value;
                btnSoilInfo.Enabled    = _soilInfoButtomEnabled;
            }
        }

        /// <summary>
        /// 指示是否已启用卷内目录文件按钮
        /// </summary>
        [Category("用户控件属性"), Description("指示是否已启用卷内目录文件按钮")]
        public bool BookListButtomEnabled
        {
            get
            {
                return _bookListButtomEnabled;
            }
            set
            {
                _bookListButtomEnabled = value;
                btnBookList.Enabled    = _bookListButtomEnabled;
            }
        }

        /// <summary>
        /// 指示是否已启用增加按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用增加按钮")]
		public bool AddButtomEnabled
		{
			get
			{
				return _addButtomEnabled;
			}
			set
			{
				_addButtomEnabled = value;
				btnAdd.Enabled    = _addButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用修改按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用修改按钮")]
		public bool EditButtomEnabled
		{
			get
			{
				return _editButtomEnabled;
			}
			set
			{
				_editButtomEnabled = value;
				btnEdit.Enabled    = _editButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用删除按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用删除按钮")]
		public bool DeleteButtomEnabled
		{
			get
			{
				return _deleteButtomEnabled;
			}
			set
			{
				_deleteButtomEnabled = value;
				btnDelete.Enabled    = _deleteButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用保存按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用保存按钮")]
		public bool SaveButtomEnabled
		{
			get
			{
				return _saveButtomEnabled;
			}
			set
			{
				_saveButtomEnabled = value;
				btnSave.Enabled    = _saveButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用取消按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用取消按钮")]
		public bool CancelButtomEnabled
		{
			get
			{
				return _cancelButtomEnabled;
			}
			set
			{
				_cancelButtomEnabled = value;
				btnCancel.Enabled    = _cancelButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用分隔按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用分隔按钮")]
		public bool SplitButtomEnabled
		{
			get
			{
				return _splitButtomEnabled;
			}
			set
			{
				_splitButtomEnabled = value;
				btnSplit.Enabled    = _splitButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用打印按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用打印按钮")]
		public bool PrintButtomEnabled
		{
			get
			{
				return _printButtomEnabled;
			}
			set
			{
				_printButtomEnabled = value;
				btnPrint.Enabled    = _printButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用导出按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用导出按钮")]
		public bool ExportButtomEnabled
		{
			get
			{
				return _exportButtomEnabled;
			}
			set
			{
				_exportButtomEnabled = value;
				btnExport.Enabled    = _exportButtomEnabled;
			}
		}

        /// <summary>
        /// 指示是否已启用关闭按钮
        /// </summary>
		[Category("用户控件属性"),Description("指示是否已启用关闭按钮")]
		public bool CloseButtomEnabled
		{
			get
			{
				return _closeButtomEnabled;
			}
			set
			{
				_closeButtomEnabled = value;
				btnClose.Enabled    = _closeButtomEnabled;
			}
		}
		#endregion

        #region 设置各非关键按钮的文本
        private string _soilInfoText     = "著录";
        private string _bookListText     = "著录";
        private string _receiveData1Text = "集体土地登记数据";
        private string _receiveData2Text = "土地登记属性数据";
        private string _receiveData3Text = "土地分割登记属性数据";
        private string _exportButtomText = "导出";

        /// <summary>
        /// 设置或得到在btnSoilInfo上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在btnSoilInfo上显示的文本")]
        public string SoilInfoText
        {
            get { return _soilInfoText; }
            set {
                _soilInfoText           = value;
                btnSoilInfo.Text        = _soilInfoText;
                btnSoilInfo.ToolTipText = _soilInfoText;
            }
        }

        /// <summary>
        /// 设置或得到在btnBookList上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在btnBookList上显示的文本")]
        public string BookListText
        {
            get { return _bookListText; }
            set {
                _bookListText           = value;
                btnBookList.Text        = _bookListText;
                btnBookList.ToolTipText = _bookListText;
            }
        }

        /// <summary>
        /// 设置或得到在btnReceiveData1上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在btnReceiveData1上显示的文本")]
        public string ReceiveData1Text
        {
            get { return _receiveData1Text; }
            set {
                _receiveData1Text           = value;
                btnReceiveData1.Text        = _receiveData1Text;
                btnReceiveData1.ToolTipText = _receiveData1Text;
            }
        }

        /// <summary>
        /// 设置或得到在btnReceiveData2上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在btnReceiveData2上显示的文本")]
        public string ReceiveData2Text
        {
            get { return _receiveData2Text; }
            set
            {
                _receiveData2Text           = value;
                btnReceiveData2.Text        = _receiveData2Text;
                btnReceiveData2.ToolTipText = _receiveData2Text;
            }
        }

        /// <summary>
        /// 设置或得到在btnReceiveData3上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在btnReceiveData3上显示的文本")]
        public string ReceiveData3Text
        {
            get { return _receiveData3Text; }
            set
            {
                _receiveData3Text           = value;
                btnReceiveData3.Text        = _receiveData3Text;
                btnReceiveData3.ToolTipText = _receiveData3Text;
            }
        }

        /// <summary>
        /// 设置或得到在ExportButtom上显示的文本
        /// </summary>
        [Category("用户控件属性"), Description("设置或得到在ExportButtom上显示的文本")]
        public string ExportButtomText
        {
            get { return _exportButtomText; }
            set
            {
                _exportButtomText     = value;
                btnExport.Text        = _exportButtomText;
                btnExport.ToolTipText = _exportButtomText;
            }
        }
        #endregion

        #region 事件
        public UcEditToolManage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (OnAddButtomClicked != null)
            { 
                OnAddButtomClicked(this,null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (OnEditButtomClicked != null)
            {
                OnEditButtomClicked(this, null);
            }
        }
        
        void BtnCloseClick(object sender, EventArgs e)
        {
        	if (OnCloseButtomClicked != null)
            {
                OnCloseButtomClicked(this, null);
            }
        }
        
               
        void MnuShowRecordListClick(object sender, EventArgs e)
        {
        	if (OnShowRecordListClicked != null)
            {
                OnShowRecordListClicked(this, null);
            }
        }
        
        void MnuShowRecordDetailClick(object sender, EventArgs e)
        {
        	if (OnShowRecordDetailClicked != null)
            {
                OnShowRecordDetailClicked(this, null);
            }
        }
        
        void MnuSplitShowClick(object sender, EventArgs e)
        {
        	if (OnSplitShowClicked != null)
            {
                OnSplitShowClicked(this, null);
            }
        }
        
        void BtnSaveClick(object sender, EventArgs e)
        {
        	if (OnSaveButtomClicked != null)
            {
                OnSaveButtomClicked(this, null);
            }
        }
        
        void BtnDeleteClick(object sender, EventArgs e)
        {
			if (OnDeleteButtomClicked != null)
            {
                OnDeleteButtomClicked(this, null);
            }        	
        }
        
        void BtnExportClick(object sender, EventArgs e)
        {
        	if (OnExportButtomClicked != null)
            {
                OnExportButtomClicked(this, null);
            }     
        }
        
        void BtnPrintClick(object sender, EventArgs e)
        {
        	if (OnPrintButtomClicked != null)
            {
                OnPrintButtomClicked(this, null);
            }  
        }
        
        void BtnCancelClick(object sender, EventArgs e)
        {
        	if (OnCancelButtomClicked != null)
            {
                OnCancelButtomClicked(this, null);
            }  
        }
        private void btnBookList_Click(object sender, EventArgs e)
        {
            if (OnBookListButtomClicked != null)
            {
                OnBookListButtomClicked(this, null);
            }
        }

        private void btnSoilInfo_Click(object sender, EventArgs e)
        {
            if (OnSoilInfoButtomClicked != null)
            {
                OnSoilInfoButtomClicked(this, EventArgs.Empty);
            }
        }

        private void UcEditToolManage_Load(object sender, EventArgs e)
        {
            cboDataTable.SelectedIndex = 0;
            SelectedDataTableName = cboDataTable.Text.Trim();
        }


        private void cboDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDataTableName = cboDataTable.Text.Trim();
            if (OnCboDataTableSelectedIndexChanged != null)
            {
                OnCboDataTableSelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        private void btnReceiveData1_Click(object sender, EventArgs e)
        {
            if (OnReceiveData1ButtomClicked != null)
            {
                OnReceiveData1ButtomClicked(this, EventArgs.Empty);
            }
        }

        private void btnReceiveData2_Click(object sender, EventArgs e)
        {
            if (OnReceiveData2ButtomClicked != null)
            {
                OnReceiveData2ButtomClicked(this, EventArgs.Empty);
            }
        }

        private void btnReceiveData3_Click(object sender, EventArgs e)
        {
            if (OnReceiveData3ButtomClicked != null)
            {
                OnReceiveData3ButtomClicked(this, EventArgs.Empty);
            }
        }
        #endregion        

        #region 方法
        /// <summary>
        /// 设置增加，修改，删除，保存按钮的可用性
        /// </summary>
        /// <param name="bAddEnabled">增加按钮的可用性</param>
        /// <param name="bEditEnabled">编辑按钮的可用性</param>
        /// <param name="bDelEnabled">删除按钮的可用性</param>
        /// <param name="bSaveEnabled">保存按钮的可用性</param>
        [Description("设置增加，修改，删除，保存按钮的可用性"),Browsable(false)]
        public void SetBaseBtnEnabled(bool bAddEnabled,bool bEditEnabled,bool bDelEnabled,
            bool bSaveEnabled)
        {
            AddButtomEnabled        = bAddEnabled;
            EditButtomEnabled       = bEditEnabled;
            DeleteButtomEnabled     = bDelEnabled;
            SaveButtomEnabled       = bSaveEnabled;
            if (SaveButtomEnabled)
            {
                CancelButtomEnabled = true;
            }
            else
            {
                CancelButtomEnabled = false;
            }
        }

        /// <summary>
        /// 设置保存、修改与BookListButtom按钮的可用性
        /// </summary>
        /// <param name="bSaveEnabled">保存按钮的可用性</param>
        /// <param name="bEditEnabled">编辑按钮的可用性</param>
        /// <param name="bBookListEnabled">BookListButtom按钮的可用性</param>
        [Description("设置保存、修改与BookListButtom按钮的可用性"), Browsable(false)]
        public void SetBaseBtnEnabled(bool bSaveEnabled, bool bEditEnabled, bool bBookListEnabled)
        {
            SaveButtomEnabled       = bSaveEnabled;
            EditButtomEnabled       = bEditEnabled;
            BookListButtomEnabled   = bBookListEnabled;
            if (SaveButtomEnabled)
            {
                CancelButtomEnabled = true;
            }
            else
            {
                CancelButtomEnabled = false;
            }
        }
        #endregion
    }
}
