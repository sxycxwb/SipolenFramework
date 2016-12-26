using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmQueryEngineDefineAdmin
    /// 查询引擎定义
    /// 
    /// 修改记录    
    /// 
    ///     2015-10-23 版本：3.0 EricHu  查询引擎定义功能页面编写。
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2015-10-23</date>
    /// </author> 
    /// </summary>
    public partial class FrmQueryEngineDefineAdmin : BaseForm
    {
        /// <summary>
        /// 查询引擎宝DataTable
        /// </summary>
        private DataTable DTQueryEngineDefine = new DataTable(QueryEngineDefineTable.TableName);

        /// <summary>
        /// 查询引擎宝列表DataTable
        /// </summary>
        private DataTable DTQueryEngineDefineList = new DataTable(QueryEngineDefineTable.TableName);

        /// <summary>
        /// 新增权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl = null;

        /// <summary>
        /// 查询引擎定义主键，作为dgvList 中记录的父主键
        /// </summary>
        private string parentEntityId = string.Empty;

        /// <summary>
        /// 查询引擎定义主键，作为dgvList 中记录的查询引擎主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvList.SelectedNode != null) && (this.tvList.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineDefineTable.FieldId].ToString();
                }
                else
                {
                    this.parentEntityId = string.Empty;
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 权限项主键，dgvList中的选择项Id
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvList, QueryEngineDefineTable.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                this.currentEntityId = this.LastControl == this.tvList ? this.ParentEntityId : this.EntityId;
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }

        public FrmQueryEngineDefineAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnAdd.Enabled = this.permissionAdd;

            if ((this.dgvList.DataSource != null) && (this.dgvList.RowCount > 0))
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
            }
            if (this.tvList.Nodes.Count > 0)
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("QueryEngineDefine.Add");        // 新增权限
            this.permissionEdit = this.IsAuthorized("QueryEngineDefine.Edit");       // 编辑权限
            this.permissionDelete = this.IsAuthorized("QueryEngineDefine.Delete");     // 删除权限
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树的主键
            if (reloadTree)
            {
                this.LoadTree();
                if (this.tvList.SelectedNode == null && this.tvList.Nodes.Count > 0)
                {
                    if (this.parentEntityId.Length == 0)
                    {
                        this.tvList.SelectedNode = this.tvList.Nodes[0];
                    }
                    else
                    {
                        BasePageLogic.FindTreeNode(this.tvList, this.parentEntityId);
                        if (BasePageLogic.TargetNode != null)
                        {
                            this.tvList.SelectedNode = BasePageLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BasePageLogic.ExpandTreeNode(this.tvList);
                        }
                    }
                    if (this.tvList.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvList.SelectedNode.Expand();
                        this.tvList.SelectedNode.EnsureVisible();
                    }
                }
            }
            if (this.ParentEntityId.Length > 0 && reloadTree)
            {
                this.GetQueryEngineList();
            }

            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvList);
            this.DTQueryEngineDefine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDT(this.UserInfo);
            this.DTQueryEngineDefine.DefaultView.Sort = QueryEngineDefineTable.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        private void GetQueryEngineList()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var recordCount = 0;
            var where = QueryEngineDefineTable.FieldQueryEngineId + "='" + this.ParentEntityId + "'";

            this.DTQueryEngineDefineList = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByPage(this.UserInfo, where, out recordCount, ucPager.PageIndex, ucPager.PageSize, (QueryEngineDefineTable.FieldSortCode + " desc"));
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvList.AutoGenerateColumns = false;
            this.DTQueryEngineDefineList.DefaultView.Sort = QueryEngineDefineTable.FieldSortCode;
            this.dgvList.DataSource = this.DTQueryEngineDefineList.DefaultView;
            this.SetControlState();
            this.Cursor = holdCursor;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetQueryEngineList();
            this.Cursor = holdCursor;
        }

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvList.BeginUpdate();
            this.tvList.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeQueryEngine(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvList.EndUpdate();
        }
        #endregion

        #region private void LoadTreeQueryEngine(TreeNode treeNode) 加载查询引擎树
        /// <summary>
        /// 加载查询引擎树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeQueryEngine(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTQueryEngineDefine, QueryEngineTable.FieldId, QueryEngineTable.FieldParentId, QueryEngineTable.FieldFullName, this.tvList, treeNode, true, 2);
        }
        #endregion

        private void tvList_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvList;
            tvList.PathSeparator = ">";
            lblCurrentTvPath.Text = tvList.SelectedNode.FullPath;
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            if (this.LastControl == this.tvList)
            {
                this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineDefineTable.FieldId].ToString();
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetQueryEngineList();
                }
            }
        }

        private void dgvList_Click(object sender, EventArgs e)
        {
            this.LastControl = this.dgvList;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.permissionEdit)
            {
                this.EditGrid();
            }
        }

        #region private string Add(bool root) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        private string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmQueryEngineDefineAdd frmQueryEngineAdd;
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvList);
            if (root || dataRow == null)
            {
                frmQueryEngineAdd = new FrmQueryEngineDefineAdd();
            }
            else
            {
                frmQueryEngineAdd = new FrmQueryEngineDefineAdd(dataRow[QueryEngineDefineTable.FieldQueryEngineId].ToString(), dataRow[QueryEngineDefineTable.FieldFullName].ToString());
            }
            frmQueryEngineAdd.Owner = this;
            if (frmQueryEngineAdd.ShowDialog() == DialogResult.OK)
            {
                returnValue = frmQueryEngineAdd.entity.Id.ToString();
                string fullName = frmQueryEngineAdd.FullName;
                string queryEngineId = frmQueryEngineAdd.QueryEngineId;
                // 绑定grdModule
                this.GetQueryEngineList();
                // 使新增加的数据在dgvList中可见
                if (this.DTQueryEngineDefineList.Rows.Count > 0)
                    this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineDefineList.Rows.Count - 1;
            }
            return returnValue;
        }
        #endregion

        #region public void AddFromChild(TreeNode newNode,TreeNode parentNode) 从FrmQueryEngineAdd调用该方法添加节点
        /// <summary>
        /// 从FrmQueryEngineAdd调用该方法添加节点
        /// </summary>
        /// <param name="newNode"></param>
        /// <param name="parentNode"></param>
        public void AddFromChild(TreeNode newNode, TreeNode parentNode)
        {
            BasePageLogic.AddTreeNode(tvList, newNode, parentNode);
            // 绑定grdModule
            this.GetQueryEngineList();
            // 使新增加的数据在grdModule中可见
            if (this.DTQueryEngineDefineList.Rows.Count > 0)
                this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineDefineList.Rows.Count - 1;
        }
        #endregion

        public string Add()
        {
            return this.Add(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加操作权限
            this.Add();
        }

        #region private void EditGrid() 编辑查询引擎定义
        /// <summary>
        /// 编辑查询引擎定义
        /// </summary>
        private void EditGrid()
        {
            if (this.dgvList.RowCount == 0)
            {
                // 提高用户体验，如果dgvList没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvList;
                return;
            }
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvList, QueryEngineDefineTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmQueryEngineEdit = new FrmQueryEngineDefineEdit(tmpId);
            if (frmQueryEngineEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 绑定dgvList
                this.GetQueryEngineList();
                if (this.DTQueryEngineDefineList.Rows.Count > 0)
                {
                    this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineDefineList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region public void Edit() 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑组织机构
            if (this.LastControl == this.dgvList)
            {
                this.EditGrid();
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvList, QueryEngineDefineTable.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = true;
            int selectedCount = 0;

            foreach (DataGridViewRow dgvRow in dgvList.Rows)
            {
                var dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                {
                    // 是否有子节点
                    string id = dataRow[QueryEngineDefineTable.FieldId].ToString();
                    var entity = BaseEntity.Create<QueryEngineDefineEntity>(dataRow);
                    if (entity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, entity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                    selectedCount++;
                }
            }

            if (returnValue && selectedCount == 0)
            {
                returnValue = false;
                MessageBox.Show(RDIFrameworkMessage.MSGC023, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int returnValue = 0;
            if (this.CheckInputBatchDelete() && MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
            {
                string[] tags = this.GetSelecteIds();
                // 逻辑删除
                returnValue = RDIFrameworkService.Instance.QueryEngineService.SetDeletedQueryEngineDefine(UserInfo, tags);
                // 绑定dgvInfo
                this.GetQueryEngineList();
            }
            return returnValue;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int returnValue = 0;
            if (this.LastControl == this.dgvList)
            {
                returnValue = this.BatchDelete();
            }
            return returnValue;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        private void GetPreviewData()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var recordCount = 0;
            QueryEngineDefineEntity queryEngineDefineEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineEntity(this.UserInfo, this.EntityId);
            CiDbLinkDefineEntity dblinkEntity = null;
            IDbProvider dbProvider = null;
            if (queryEngineDefineEntity != null && !string.IsNullOrEmpty(queryEngineDefineEntity.DataBaseLinkName))
            {
                dblinkEntity = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(this.UserInfo, queryEngineDefineEntity.DataBaseLinkName);
            }

            if (dblinkEntity != null)
            {
                var DbDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntityByLinkName(this.UserInfo, dblinkEntity.LinkName);
                dbProvider = DbDefine != null ? DbFactoryProvider.GetProvider((CurrentDbType)Enum.Parse(typeof(CurrentDbType), DbDefine.LinkType, true), SecretHelper.AESDecrypt(DbDefine.LinkData))
                                        : DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnectionString);

                var dtDynamicJsonDt = dbProvider.GetDTByPage(out recordCount, queryEngineDefineEntity.QueryString, ucPagerEx1.PageIndex, ucPagerEx1.PageSize, string.Empty, queryEngineDefineEntity.OrderByField);
                ucPagerEx1.RecordCount = recordCount;
                ucPagerEx1.InitPageInfo();
                this.dgvListSample.AutoGenerateColumns = true;
                this.dgvListSample.DataSource = dtDynamicJsonDt.DefaultView;
            }
            else
            {
                ucPagerEx1.RecordCount = 0;
                ucPagerEx1.InitPageInfo();
                this.dgvListSample.AutoGenerateColumns = true;
                this.dgvListSample.DataSource = null;
            }
                        
            this.Cursor = holdCursor;
        }

        private void btnPreviewData_Click(object sender, EventArgs e)
        {
            this.ucPagerEx1.PageIndex = 1;
            GetPreviewData();
        }

        private void ucPagerEx1_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetPreviewData();
            this.Cursor = holdCursor;
        }

        private void mnuShoEngineList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void mnuShowDataSampleList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void mnuShoAll_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
