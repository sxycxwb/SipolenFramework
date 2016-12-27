using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmQueryEngineAdmin
    /// 查询引擎管理
    /// 
    /// 修改记录    
    /// 
    ///     2015-10-22 版本：3.0 XuWangBin  查询引擎管理功能页面编写。
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2015-10-22</date>
    /// </author> 
    /// </summary>
    public partial class FrmQueryEngineAdmin : BaseForm
    {
        /// <summary>
        /// 查询引擎DataTable
        /// </summary>
        private DataTable DTQueryEngine = new DataTable(QueryEngineTable.TableName);

        /// <summary>
        /// 查询引擎列表DataTable
        /// </summary>
        private DataTable DTQueryEngineList = new DataTable(QueryEngineTable.TableName);

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
        /// 查询引擎主键，作为dgvList 中记录的父主键
        /// </summary>
        private string parentEntityId = string.Empty;

        /// <summary>
        /// 查询引擎主键，作为dgvList 中记录的父主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvList.SelectedNode != null) && (this.tvList.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineTable.FieldId].ToString();
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
        /// 查询引擎主键，dgvList中的选择项Id
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvList, QueryEngineTable.FieldId);
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

        public FrmQueryEngineAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
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

            // 位置顺序改变按钮部分
            if (this.DTQueryEngineList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }

            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                bool setTop = this.ucSortControl.SetTopEnabled;
                bool setUp = this.ucSortControl.SetUpEnabled;
                bool setDown = this.ucSortControl.SetDownEnabled;
                bool setBottom = this.ucSortControl.SetBottomEnabled;
                bool add = this.btnAdd.Enabled;
                bool edit = this.btnEdit.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit,true);
            }

            // 位置顺序改变按钮部分
            if (this.DTQueryEngineList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }
        }

        public event SetControlStateEventHandler OnButtonStateChange;

        public void SetSortButton(bool enabled)
        {
            this.ucSortControl.SetSortButton(enabled);
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("QueryEngineAdmin.Add");        // 新增权限
            this.permissionEdit = this.IsAuthorized("QueryEngineAdmin.Edit");       // 编辑权限
            this.permissionDelete = this.IsAuthorized("QueryEngineAdmin.Delete");     // 删除权限
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
            this.DTQueryEngine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDT(this.UserInfo);
            this.DTQueryEngine.DefaultView.Sort = QueryEngineTable.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion
        
        #region private void GetQueryEngineList() 获得查询引擎列表
        /// <summary>
        /// 获得查询引擎列表
        /// </summary>
        private void GetQueryEngineList()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTQueryEngineList = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDTByParent(UserInfo, this.ParentEntityId);
            this.dgvList.AutoGenerateColumns = false;
            this.DTQueryEngineList.DefaultView.Sort = QueryEngineTable.FieldSortCode;
            this.dgvList.DataSource = this.DTQueryEngineList.DefaultView;
            this.ucSortControl.DataBind(this.dgvList, this.permissionEdit);
            this.SetControlState();
            this.Cursor = holdCursor;
        }
        #endregion

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
            BasePageLogic.LoadTreeNodes(this.DTQueryEngine, QueryEngineTable.FieldId, QueryEngineTable.FieldParentId, QueryEngineTable.FieldFullName, this.tvList, treeNode, true, 2);
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
                this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineTable.FieldId].ToString();
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetQueryEngineList();
                }
            }
        }

        private void tvList_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvList_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode treeNode;
            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) return;
            Point point;
            TreeNode targetTreeNode;
            point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            targetTreeNode = ((TreeView)sender).GetNodeAt(point);
            treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                if (SystemInfo.ShowInformation &&
                    MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0038, treeNode.Text,
                        targetTreeNode.Text)) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                RDIFrameworkService.Instance.QueryEngineService.MoveToQueryEngine(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
                targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                treeNode.Remove();
            }
        }

        string QueryEngineList = string.Empty;

        private void GetTreeSort(TreeNode treeNode)
        {
            QueryEngineList += (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString() + ",";
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeSort(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetTreeSort() 获得树型权限项的排序顺序
        /// <summary>
        /// 获得树型机构的排序顺序
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetTreeSort()
        {
            var ids = new string[0];
            if (!UserInfo.IsAdministrator) return ids;
            this.QueryEngineList = string.Empty;
            for (int i = 0; i < this.tvList.Nodes.Count; i++)
            {
                this.GetTreeSort(this.tvList.Nodes[i]);
            }
            if (this.QueryEngineList.Length > 0)
            {
                this.QueryEngineList = this.QueryEngineList.Substring(0, this.QueryEngineList.Length - 1);
                ids = this.QueryEngineList.Split(',');
            }
            return ids;
        }
        #endregion

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

        private void dgvList_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = RDIFrameworkService.Instance.SequenceService.GetBatchSequence(UserInfo, QueryEngineTable.TableName, this.DTQueryEngineList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTQueryEngineList.DefaultView)
                {
                    dataRowView.Row[QueryEngineTable.FieldSortCode] = sequence[i];
                    i++;
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region private string Add(bool root) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        private string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmQueryEngineAdd frmQueryEngineAdd;
            if (this.LastControl == this.tvList)
            {
                if (root || (this.ParentEntityId.Length == 0) || (this.tvList.SelectedNode == null))
                {
                    frmQueryEngineAdd = new FrmQueryEngineAdd();
                }
                else
                {
                    frmQueryEngineAdd = new FrmQueryEngineAdd(this.ParentEntityId, this.tvList.SelectedNode.Text);
                }
            }
            else
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvList);
                if (root || dataRow == null)
                {
                    frmQueryEngineAdd = new FrmQueryEngineAdd();
                }
                else
                {
                    frmQueryEngineAdd = new FrmQueryEngineAdd(dataRow[QueryEngineTable.FieldId].ToString(), dataRow[QueryEngineTable.FieldFullName].ToString());
                }
            }
            frmQueryEngineAdd.Owner = this;
            if (frmQueryEngineAdd.ShowDialog() == DialogResult.OK)
            {
                returnValue = frmQueryEngineAdd.entity.Id.ToString();
                string fullName = frmQueryEngineAdd.FullName;
                string parentId = frmQueryEngineAdd.ParentId;
                // tvModule 中增加结点
                var newNode = new TreeNode
                {
                    Text = fullName,
                    Tag = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDTByIds(UserInfo,new string[] {returnValue}).Rows[0]
                };
                ;

                TreeNode parentNode = null;
                if (!root && !string.IsNullOrEmpty(parentId))
                {
                    BasePageLogic.FindTreeNode(this.tvList, parentId);
                    parentNode = BasePageLogic.TargetNode;
                }
                BasePageLogic.AddTreeNode(this.tvList, newNode, parentNode);
                // 绑定grdModule
                this.GetQueryEngineList();
                // 使新增加的数据在grdModule中可见
                if (this.DTQueryEngineList.Rows.Count > 0)
                    this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineList.Rows.Count - 1;
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
            if (this.DTQueryEngineList.Rows.Count > 0)
                this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineList.Rows.Count - 1;
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

        #region private void EditGrid() 编辑权限项
        /// <summary>
        /// 编辑组织机构
        /// </summary>
        private void EditGrid()
        {
            if (this.dgvList.RowCount == 0)
            {
                // 提高用户体验，如果dgvList没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvList;
                return;
            }
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvList, QueryEngineTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmQueryEngineEdit = new FrmQueryEngineEdit(tmpId);
            if (frmQueryEngineEdit.ShowDialog(this) == DialogResult.OK)
            {
                BasePageLogic.FindTreeNode(this.tvList, tmpId);
                TreeNode selectNode = BasePageLogic.TargetNode;
                selectNode.Text = frmQueryEngineEdit.FullName;
                TreeNode oldParentNode = selectNode.Parent;

                BasePageLogic.FindTreeNode(this.tvList, frmQueryEngineEdit.ParentId);
                TreeNode parentNode = BasePageLogic.TargetNode;
                // 编辑节点
                BasePageLogic.EditTreeNode(this.tvList, selectNode, parentNode);
                // 绑定dgvList
                this.GetQueryEngineList();
                if (this.DTQueryEngineList.Rows.Count > 0)
                {
                    this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineList.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region private void EditTree() 编辑权限项
        private void EditTree()
        {
            if (this.tvList.SelectedNode == null)
            {
                return;
            }
            var frmQueryEngineEdit = new FrmQueryEngineEdit(this.ParentEntityId);
            if (frmQueryEngineEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 编辑节点
                this.tvList.SelectedNode.Text = frmQueryEngineEdit.FullName;
                // 绑定dgvList
                this.GetQueryEngineList();
                if (this.DTQueryEngineList.Rows.Count > 0)
                {
                    this.dgvList.FirstDisplayedScrollingRowIndex = this.DTQueryEngineList.Rows.Count - 1;
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
            if (this.LastControl == this.tvList)
            {
                this.EditTree();
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
            return BasePageLogic.GetSelecteIds(this.dgvList, QueryEngineTable.FieldId, "colSelected", true);
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
                    // break;
                    // 是否有子节点
                    string id = dataRow[QueryEngineTable.FieldId].ToString();
                    BasePageLogic.FindTreeNode(this.tvList, id);
                    if (BasePageLogic.TargetNode != null && !BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                    {
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text),RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    var queryEnginentity = BaseEntity.Create<QueryEngineEntity>(dataRow);
                    if (queryEnginentity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, queryEnginentity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }

                    DataTable dtQueryEngineDefine =RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByEngineId(this.UserInfo,queryEnginentity.Id);
                    if (dtQueryEngineDefine != null && dtQueryEngineDefine.Rows.Count > 0)
                    {
                        MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0225); //当前节点定义的有查询引擎定义则也不能删除
                        returnValue = false;
                        break;
                        
                    }
                }
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                {
                    // 有记录被选中了
                    returnValue = true;
                    // break;
                    // 是否有子节点
                    string id = dataRow[QueryEngineTable.FieldId].ToString();
                    BasePageLogic.FindTreeNode(this.tvList, id);
                    if (BasePageLogic.TargetNode != null && !BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                    {
                        MessageBox.Show(
                            RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text),
                            RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    var queryEnginentity = BaseEntity.Create<QueryEngineEntity>(dataRow);
                    if (queryEnginentity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, queryEnginentity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                returnValue = RDIFrameworkService.Instance.QueryEngineService.SetDeletedQueryEngine(UserInfo, tags);
                // 获取模块列表
                this.DTQueryEngine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDT(this.UserInfo);
                // 在tree删除相应的节点
                BasePageLogic.BatchRemoveNode(this.tvList, tags);
                // 绑定dgvInfo
                this.GetQueryEngineList();
            }
            return returnValue;
        }
        #endregion

        #region private int SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        public int SingleDelete()
        {
            int returnValue = 0;
            if (this.tvList.SelectedNode == null)
            {
                return returnValue;
            }
            
            if (!BasePageLogic.NodeAllowDelete(this.tvList.SelectedNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvList.SelectedNode.Text));
            }
            else
            {

                DataTable dtQueryEngineDefine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByEngineId(this.UserInfo, this.ParentEntityId);
                if (dtQueryEngineDefine != null && dtQueryEngineDefine.Rows.Count > 0)
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0225); //当前节点定义的有查询引擎定义则也不能删除
                    return returnValue;
                }

                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 逻辑上删除
                    returnValue = RDIFrameworkService.Instance.QueryEngineService.SetDeletedQueryEngine(UserInfo, new string[] { this.ParentEntityId });
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags = { ((DataRow)this.tvList.SelectedNode.Tag)[PiPermissionTable.FieldId].ToString() };
                        BasePageLogic.BatchRemoveNode(this.tvList, tags);
                        // 绑定dgvInfo
                        this.GetQueryEngineList();
                    }
                }
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
            if (this.LastControl == this.tvList)
            {
                returnValue = this.SingleDelete();
            }
            return returnValue;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
