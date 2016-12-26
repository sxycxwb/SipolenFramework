/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-16 14:51:33
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace RDIFramework.WinModule
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    public partial class UcSortControl : UserControl
    {
        public UcSortControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public UserInfo UserInfo
        {
            get
            {
                return SystemInfo.UserInfo;
            }
        }

        private DataGridView dataGridView;
        private DataView dataView;
        private bool dataTableFlag = true;
        private dynamic lstT;
        private string tabelName = "";

        // 实体主键
        public string EntityId
        {
            get
            {
                if (dataTableFlag)
                    return BasePageLogic.GetDataGridViewEntityId(this.dataGridView, BusinessLogic.FieldId);
                else
                {
                    if (this.dataGridView.CurrentRow.Index == -1) return string.Empty;
                    else return ReflectHelper.GetProperty(lstT[this.dataGridView.CurrentRow.Index], BusinessLogic.FieldId).ToString();
                }
            }
        }

        public string OEntityId
        {
            set;
            get;
        }
        private bool permissionEdit = true;    // 编辑权限

        #region public void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public void SetControlState()
        {
            this.SetSortButton(false);
            if (dataTableFlag)
            {
                // 位置顺序改变按钮部分
                if ((this.dataView != null) && (this.dataView.Count > 1))
                {
                    this.SetSortButton(this.permissionEdit);
                }
            }
            else
            {
                if ((this.lstT != null) && (this.lstT.Count > 1))
                {
                    this.SetSortButton(this.permissionEdit);
                }
            }
            if (SystemInfo.BusinessDbType == CurrentDbType.DB2
                || SystemInfo.BusinessDbType == CurrentDbType.Oracle)
            {
                this.btnSetTop.Visible = false;
                this.btnSetBottom.Visible = false;
            }
        }
        #endregion

        public void DataBind(DataGridView dataGridView, bool permissionEdit)
        {
            this.permissionEdit = permissionEdit;
            this.dataGridView = dataGridView;
            if (dataGridView.DataMember != null && dataGridView.DataSource != null)
            {
                this.dataView = (DataView) dataGridView.DataSource;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        dynamic st;
        public void DataBind(DataGridView dataGridView, string tabelName, dynamic st)
        {
            this.DataBind(dataGridView, true, tabelName, st);
        }
        public void DataBind(DataGridView dataGridView, bool permissionEdit, string tabelName, dynamic st)
        {
            this.st = st;
            dataTableFlag = false;
            this.tabelName = tabelName;
            this.permissionEdit = permissionEdit;
            this.dataGridView = dataGridView;
            if (dataGridView.DataMember != null && dataGridView.DataSource != null)
            {
                this.lstT = dataGridView.DataSource;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        public void DataBind(DataGridView dataGridView, string tabelName)
        {
            this.DataBind(dataGridView, true, tabelName);
        }

        public void DataBind(DataGridView dataGridView, bool permissionEdit, string tabelName)
        {
            dataTableFlag = false;
            this.tabelName = tabelName;
            this.permissionEdit = permissionEdit;
            this.dataGridView = dataGridView;
            this.dataGridView.Sort(this.dataGridView.Columns["SortCode"], ListSortDirection.Ascending);
            if (dataGridView.DataMember != null && dataGridView.DataSource != null)
            {
                this.lstT = dataGridView.DataSource;
            }
            // 设置按钮状态
            this.SetControlState();
        }

        public void DataBind(DataGridView dataGridView)
        {
            this.DataBind(dataGridView, true);
        }

        public bool SetTopEnabled
        {
            get
            {
                return this.btnSetTop.Enabled;
            }
            set
            {
                this.btnSetTop.Enabled = value;
            }
        }

        public bool SetUpEnabled
        {
            get
            {
                return this.btnSetUp.Enabled;
            }
            set
            {
                this.btnSetUp.Enabled = value;
            }
        }

        public bool SetDownEnabled
        {
            get
            {
                return this.btnSetDown.Enabled;
            }
            set
            {
                this.btnSetDown.Enabled = value;
            }
        }

        public bool SetBottomEnabled
        {
            get
            {
                return this.btnSetBottom.Enabled;
            }
            set
            {
                this.btnSetBottom.Enabled = value;
            }
        }

        #region public void SetSortButton(bool enabled) 设置排序按钮
        /// <summary>
        /// 设置排序按钮
        /// </summary>
        /// <param name="enabled">有效</param>
        public void SetSortButton(bool enabled)
        {
            this.btnSetTop.Enabled = enabled;
            this.btnSetUp.Enabled = enabled;
            this.btnSetDown.Enabled = enabled;
            this.btnSetBottom.Enabled = enabled;
        }
        #endregion

        private void UcSortControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetSortButton(false);
            }
        }

        private int _RowCount = -1;
        private int RowCount
        {
            get { return _RowCount; }
            set
            {
                _RowCount = value;
                this.OEntityId = this.EntityId;
            }
        }
        private int RowIndex
        {
            get
            {
                return this.dataGridView.CurrentRow.Index;
            }
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetTop()
        {
            RowCount = RowIndex;
            int returnValue = 0;
            string targetId = "";
            targetId = dataTableFlag ? SortLogic.GetPreviousId(this.dataView, this.EntityId) : SortLogic.GetPreviousIdDyn(lstT, this.EntityId);
            if (targetId.Length > 0)
            {
                var rdiFrameworkService = new RDIFrameworkService();
                string sequence = rdiFrameworkService.SequenceService.GetReduction(UserInfo, dataTableFlag ? this.dataView.Table.TableName : tabelName);
                if (rdiFrameworkService.SequenceService is ICommunicationObject)
                {
                    ((ICommunicationObject)rdiFrameworkService.SequenceService).Close();
                }
                if (dataTableFlag)
                    returnValue = BusinessLogic.SetProperty(this.dataView.Table, this.EntityId, BusinessLogic.FieldSortCode, sequence);
                else
                {
                    returnValue = BusinessLogic.SetPropertyDyn(this.lstT, this.EntityId, BusinessLogic.FieldSortCode, sequence);
                    SetCRow();
                }
            }
            else
            {
                if (SystemInfo.ShowInformation)
                {
                    MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0021);
                }
            }
            return returnValue;
        }

        private void SetCRow()
        {
            this.dataGridView.Sort(this.dataGridView.Columns["SortCode"], System.ComponentModel.ListSortDirection.Ascending);
            this.dataGridView.Rows[RowCount].Selected = false;
            for (int i = 0; i < this.lstT.Count; i++)
            {
                dynamic t = this.lstT[i];
                if (t.Id.ToString() == this.OEntityId)
                {
                    this.dataGridView.Rows[i].Selected = true;
                    this.dataGridView.CurrentCell = this.dataGridView.Rows[i].Cells[0];
                    break;

                }
            }
        }

        private void btnSetTop_Click(object sender, EventArgs e)
        {
            this.SetTop();
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetUp()
        {
            RowCount = RowIndex;
            int returnValue = 0;
            string targetId = "";
            targetId = dataTableFlag ? SortLogic.GetPreviousId(this.dataView, this.EntityId) : SortLogic.GetPreviousIdDyn(this.lstT, this.EntityId);
            if (targetId.Length > 0)
            {
                if (dataTableFlag)
                    returnValue = SortLogic.Swap(this.dataView.Table, this.EntityId, targetId);
                else
                {
                    returnValue = SortLogic.SwapDyn(this.lstT, this.EntityId, targetId);
                    SetCRow();
                }
            }
            else
            {
                if (SystemInfo.ShowInformation)
                {
                    MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0021);
                }
            }
            return returnValue;
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            this.SetUp();
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetDown()
        {
            RowCount = RowIndex;
            int returnValue = 0;
            string targetId = "";
            targetId = dataTableFlag ? SortLogic.GetNextId(this.dataView, this.EntityId) : SortLogic.GetNextIdDyn(this.lstT, this.EntityId);
            if (targetId.Length > 0)
            {
                if (dataTableFlag)
                    returnValue = SortLogic.Swap(this.dataView.Table, this.EntityId, targetId);
                else
                {
                    returnValue = SortLogic.SwapDyn(this.lstT, this.EntityId, targetId);
                    SetCRow();
                }
            }
            else
            {
                if (SystemInfo.ShowInformation)
                {
                    MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0022);
                }
            }
            return returnValue;
        }

        private void btnSetDown_Click(object sender, EventArgs e)
        {
            this.SetDown();
        }

        /// <summary>
        /// 置底
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetBottom()
        {
            RowCount = RowIndex;
            int returnValue = 0;
            string targetId = "";
            targetId = dataTableFlag ? SortLogic.GetNextId(this.dataView, this.EntityId) : SortLogic.GetNextIdDyn(this.lstT, this.EntityId);
            if (targetId.Length > 0)
            {
                var rdiFrameworkService = new RDIFrameworkService();
                string sequence = rdiFrameworkService.SequenceService.GetSequence(UserInfo, dataTableFlag ? this.dataView.Table.TableName : tabelName);
                if (rdiFrameworkService.SequenceService is ICommunicationObject)
                {
                    ((ICommunicationObject)rdiFrameworkService.SequenceService).Close();
                }
                if (dataTableFlag)
                    returnValue = BusinessLogic.SetProperty(this.dataView.Table, this.EntityId, BusinessLogic.FieldSortCode, sequence);
                else
                {
                    returnValue = BusinessLogic.SetPropertyDyn(this.lstT, this.EntityId, BusinessLogic.FieldSortCode, sequence);
                    SetCRow();
                }
            }
            else
            {
                if (SystemInfo.ShowInformation)
                {
                    MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0022);
                }
            }
            return returnValue;
        }

        private void btnSetBottom_Click(object sender, EventArgs e)
        {
            this.SetBottom();
        }       
    }

    public class ObjectPropertyCompare<T> : System.Collections.Generic.IComparer<T>
    {
        private PropertyDescriptor property;
        private ListSortDirection direction;

        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            this.property = property;
            this.direction = direction;
        }

        #region IComparer<T>

        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="x">相对属性x</param>
        /// <param name="y">相对属性y</param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            int? xValue = null;
            int? yValue = null;
            object x1 = ReflectHelper.GetProperty(x, "SortCode");
            object y1 = ReflectHelper.GetProperty(y, "SortCode");
            if (x1 != null) xValue = (int)x1;
            if (y1 != null) yValue = (int)y1;
            return Nullable.Compare(xValue, yValue) * ((ListSortDirection.Ascending == direction) ? 1 : -1);
        }

        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }

    public class BindingCollection<T> : BindingList<T>
    {
        private bool isSorted;
        private PropertyDescriptor sortProperty;
        private ListSortDirection sortDirection;
        public static BindingCollection<T> GetBindList(List<T> lst)
        {
            var bind = new BindingCollection<T>();
            foreach (var t in lst.Where(t => !(t == null)))
            {
                bind.Add(t);
            }
            return bind;
        }
        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            var items = this.Items as List<T>;

            if (items != null)
            {
                var pc = new ObjectPropertyCompare<T>(property, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }

            sortProperty = property;
            sortDirection = direction;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        //排序
        public void Sort(PropertyDescriptor property, ListSortDirection direction)
        {
            this.ApplySortCore(property, direction);
        }
    }
}
