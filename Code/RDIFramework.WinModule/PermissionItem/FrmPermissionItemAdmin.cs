/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-24 10:41:28
 ******************************************************************************/
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
    /// FrmPermissionItemAdmin
    /// 操作权限管理
    /// 
    /// </summary>
    public partial class FrmPermissionItemAdmin : BaseForm
    {
         /// <summary>
        /// 权限项DataTable
        /// </summary>
        private DataTable DTPermission = new DataTable(PiPermissionTable.TableName);

        /// <summary>
        /// 权限项列表DataTable
        /// </summary>
        private DataTable DTPermissionList = new DataTable(PiPermissionTable.TableName);

        /// <summary>
        /// 移动功能选择窗口
        /// </summary>
        FrmPermissionSelect frmPermissionItemSelect = null; 

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl = null;

        /// <summary>
        /// 访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 新增权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 移动权限
        /// </summary>
        private bool permissionMove = false;

        /// <summary>
        /// 删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 导出数据
        /// </summary>
        private bool permissionExport = false;


        /// <summary>
        /// 本模块角色操作权限
        /// </summary>
        private bool permissionRolePermissionItem = false;

        /// <summary>
        /// 本模块用户操作权限
        /// </summary>
        private bool permissionUserPermissionItem = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 2011-03-17
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 权限项主键，作为dgvInfo 中记录的父主键
        /// </summary>
        private string parentEntityId = string.Empty;

        /// <summary>
        /// 权限项主键，作为dgvInfo 中记录的父主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvPermission.SelectedNode != null) && (this.tvPermission.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvPermission.SelectedNode.Tag)[PiPermissionItemTable.FieldId].ToString();
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
        /// 权限项主键，dgvInfo中的选择项Id
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiPermissionTable.FieldId);
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
                this.currentEntityId = this.LastControl == this.tvPermission ? this.ParentEntityId : this.EntityId;
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }

        public FrmPermissionItemAdmin()
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
            this.btnMove.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnBatchSave.Enabled = false;
            this.btnRolePermissionItem.Enabled = false;
            this.btnUserPermissionItem.Enabled = false;
            this.btnExport.Enabled = false;
            this.ddbPermissionItemPermissionSet.Visible = SystemInfo.EnablePermissionItem;
            this.btnUserPermissionItem.Visible = SystemInfo.EnableUserAuthorization && SystemInfo.EnablePermissionItem;
            this.btnRolePermissionItem.Visible = SystemInfo.EnablePermissionItem;
            this.btnAdd.Enabled = this.permissionAdd;          

            if ((this.dgvInfo.DataSource != null) && (this.dgvInfo.RowCount > 0))
            {
                this.btnAdd.Enabled  = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionMove;
                this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnBatchSave.Enabled = this.permissionEdit; 
                this.btnUserPermissionItem.Enabled = this.permissionUserPermissionItem;
                this.btnRolePermissionItem.Enabled = this.permissionRolePermissionItem;
            }
            if (this.tvPermission.Nodes.Count > 0)
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMove.Enabled = this.permissionMove;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnExport.Enabled = this.permissionExport;

                this.btnRolePermissionItem.Enabled = this.permissionRolePermissionItem;
                this.btnUserPermissionItem.Enabled = this.permissionUserPermissionItem;
                this.btnExport.Enabled = this.permissionExport;                
            }

            // 位置顺序改变按钮部分
            if (this.DTPermissionList.DefaultView.Count > 1)
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
                bool batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchSave);
            }           

            // 位置顺序改变按钮部分
            if (this.DTPermissionList.DefaultView.Count > 1)
            {
                this.SetSortButton(this.permissionEdit);
            }
        }

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
            // 模块访问权限
            this.permissionAccess             = this.IsModuleAuthorized(this.Name);
            this.permissionAdd                = this.IsAuthorized("PermissionItemManagement.Add");        // 新增权限
            //this.permissionAddRoot      = this.IsAuthorized("PermissionItemManagement.AddRoot");    // 添加根权限
            this.permissionEdit               = this.IsAuthorized("PermissionItemManagement.Edit");       // 编辑权限
            this.permissionMove               = this.IsAuthorized("PermissionItemManagement.Move");       // 移动权限
            this.permissionDelete             = this.IsAuthorized("PermissionItemManagement.Delete");     // 删除权限
            this.permissionExport             = this.IsAuthorized("PermissionItemManagement.Export");     // 导出数据
            this.permissionAccredit           = this.IsAuthorized("UserManagement.Accredit");
            this.permissionRolePermissionItem = this.IsAuthorized("PermissionItemManagement.RolePermissionItem");
            this.permissionUserPermissionItem = this.IsAuthorized("PermissionItemManagement.UserPermissionItem");
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
                if (this.tvPermission.SelectedNode == null && this.tvPermission.Nodes.Count > 0)
                {
                    if (this.parentEntityId.Length == 0)
                    {
                        this.tvPermission.SelectedNode = this.tvPermission.Nodes[0];
                    }
                    else
                    {
                        BasePageLogic.FindTreeNode(this.tvPermission, this.parentEntityId);
                        if (BasePageLogic.TargetNode != null)
                        {
                            this.tvPermission.SelectedNode = BasePageLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BasePageLogic.ExpandTreeNode(this.tvPermission);
                        }
                    }
                    if (this.tvPermission.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvPermission.SelectedNode.Expand();
                        this.tvPermission.SelectedNode.EnsureVisible();
                    }
                }
            }
            if (this.ParentEntityId.Length > 0 && reloadTree)
            {
                this.GetPermissionList();
            }
            //if (!this.permissionEdit)
            //{
            //    // 只读属性设置
            //    this.dgvInfo.Columns["colSelected"].ReadOnly = !this.permissionEdit;
            //    this.dgvInfo.Columns["colFullName"].ReadOnly = !this.permissionEdit;
            //    this.dgvInfo.Columns["colIsScope"].ReadOnly = !this.permissionEdit;
            //    this.dgvInfo.Columns["colDescription"].ReadOnly = !this.permissionEdit;
            //    // 修改背景颜色
            //    this.dgvInfo.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
            //    this.dgvInfo.Columns["colIsScope"].DefaultCellStyle.BackColor = Color.White;
            //    this.dgvInfo.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
            //}
            // 设置按钮状态
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
            this.DataGridViewOnLoad(dgvInfo);
            // 获取操作权限项定义数据
            //this.DTPermission = RDIFrameworkService.Instance.PermissionItemService.GetDT(UserInfo);
            this.DTPermission = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            this.DTPermission.DefaultView.Sort = PiPermissionItemTable.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetPermissionList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetPermissionList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.DTPermissionList = RDIFrameworkService.Instance.PermissionItemService.GetDTByParent(UserInfo, this.ParentEntityId);
            //this.DataTableAddColumn();
            this.dgvInfo.AutoGenerateColumns = false;
            this.DTPermissionList.DefaultView.Sort = PiPermissionItemTable.FieldSortCode;
            this.dgvInfo.DataSource = this.DTPermissionList.DefaultView;
            // 设置排序按钮
            this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
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
            this.tvPermission.BeginUpdate();
            this.tvPermission.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreePermission(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermission.EndUpdate();
        }
        #endregion

        #region private void LoadTreePermission(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermission(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTPermission, PiPermissionTable.FieldId, PiPermissionItemTable.FieldParentId, PiPermissionItemTable.FieldFullName, this.tvPermission, treeNode,true,2);
        }
        #endregion

        private void tvPermission_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvPermission;
            if (this.tvPermission.SelectedNode == null)
            {
                this.tvPermission.ContextMenuStrip = null;
            }
            else
            {
                tvPermission.PathSeparator = ">";
                lblCurrentTvPath.Text = tvPermission.SelectedNode.FullPath;
                //this.tvPermission.ContextMenuStrip = this.cMnuPermission;
            }          
        }

        private void tvPermission_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            if (this.LastControl == this.tvPermission)
            {
                this.parentEntityId = ((DataRow)this.tvPermission.SelectedNode.Tag)[PiPermissionTable.FieldId].ToString();
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetPermissionList();
                }
            }
        }

        private void tvPermission_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvPermission_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvPermission_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) return;
            //定义一个位置点的变量，保存当前光标所处的坐标点
            Point point;
            //拖放的目标节点
            TreeNode targetTreeNode;
            //获取当前光标所处的坐标
            point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            //根据坐标点取得处于坐标点位置的节点
            targetTreeNode = ((TreeView)sender).GetNodeAt(point);
            //获取被拖动的节点
            treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //判断拖动的节点与目标节点是否是同一个,同一个不予处理
            if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                if (SystemInfo.ShowInformation &&
                    MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0038, treeNode.Text,
                        targetTreeNode.Text)) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                RDIFrameworkService.Instance.PermissionItemService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
                // 往目标节点中加入被拖动节点的一份克隆
                targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                // 将被拖动的节点移除
                treeNode.Remove();
            }
        }

        private void mItmAdd_Click(object sender, EventArgs e)
        {
            //this.btnAdd.PerformClick();
        }

        private void mItmRootAdd_Click(object sender, EventArgs e)
        {
            this.Add(true);
        }

        private void mItmEdit_Click(object sender, EventArgs e)
        {
            this.EditTree();
        }

        private void mItmMove_Click(object sender, EventArgs e)
        {
            this.SingleMove();
        }

        private void mItmPermissionItems_Click(object sender, EventArgs e)
        {
            //FrmSetPermissionItem frmPermissionItem = new FrmSetPermissionItem(this.CurrentEntityId);
            //frmPermissionItem.ShowDialog();
        } 

        private void mItmDelete_Click(object sender, EventArgs e)
        {
            // 删除事件
            this.SingleDelete();
        }

        private void mItmModulePermission_Click(object sender, EventArgs e)
        {
            // 权限挂接
            this.ModuleSetPermission();
        }

        string PermissionList = string.Empty;

        private void GetTreeSort(TreeNode treeNode)
        {
            PermissionList += (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString() + ",";
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
            this.PermissionList = string.Empty;
            for (int i = 0; i < this.tvPermission.Nodes.Count; i++)
            {
                this.GetTreeSort(this.tvPermission.Nodes[i]);
            }
            if (this.PermissionList.Length > 0)
            {
                this.PermissionList = this.PermissionList.Substring(0, this.PermissionList.Length - 1);
                ids = this.PermissionList.Split(',');
            }
            return ids;
        }
        #endregion

        private void mItmSetSortCode_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                RDIFrameworkService.Instance.PermissionItemService.BatchSetSortCode(UserInfo, this.GetTreeSort());
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            this.LastControl = this.dgvInfo;
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.permissionEdit)
            {
                this.EditGrid();
            }
        }

        private void btnRolePermissionItem_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRolePermissionItem";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserPermissionItem_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserPermissionItem";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            // 全部导出Excel
            DataTable dataTable = RDIFrameworkService.Instance.PermissionItemService.GetDT(UserInfo);
            dataTable.DefaultView.Sort = PiPermissionItemTable.FieldParentId + ", " + PiPermissionItemTable.FieldSortCode;
            string exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, dataTable.DefaultView, @"\Modules\Export\", exportFileName);
        }

        private void dgvInfo_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                string[] sequence = RDIFrameworkService.Instance.SequenceService.GetBatchSequence(UserInfo, PiPermissionTable.TableName, this.DTPermissionList.DefaultView.Count);
                int i = 0;
                foreach (DataRowView dataRowView in this.DTPermissionList.DefaultView)
                {
                    dataRowView.Row[PiPermissionItemTable.FieldSortCode] = sequence[i];
                    i++;
                }                
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region private string Add(bool root) 添加组织机构
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <returns>主键</returns>
        private string Add(bool root)
        {
            string returnValue = string.Empty;
            FrmPermissionItemAdd frmPermissionItemAdd;
            if (this.LastControl == this.tvPermission)
            {
                if (root||(this.ParentEntityId.Length == 0) || (this.tvPermission.SelectedNode == null))
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd();
                }
                else
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd(this.ParentEntityId, this.tvPermission.SelectedNode.Text);
                }
            }
            else
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                if (root || dataRow == null)
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd();
                }
                else
                {
                    frmPermissionItemAdd = new FrmPermissionItemAdd(dataRow[PiPermissionTable.FieldId].ToString(), dataRow[PiPermissionItemTable.FieldFullName].ToString());
                }
            }
            frmPermissionItemAdd.Owner = this;
            if (frmPermissionItemAdd.ShowDialog() == DialogResult.OK)
            {
                returnValue = frmPermissionItemAdd.PermissionItemEntity.Id.ToString();
                string fullName = frmPermissionItemAdd.FullName;
                string parentId = frmPermissionItemAdd.ParentId;
                // tvModule 中增加结点
                var newNode = new TreeNode();
                newNode.Text = fullName;
                newNode.Tag = RDIFrameworkService.Instance.PermissionItemService.GetDTByIds(UserInfo, new string[] { returnValue }).Rows[0]; ;

                TreeNode parentNode = null;
                if (!root && !string.IsNullOrEmpty(parentId))
                {
                    BasePageLogic.FindTreeNode(this.tvPermission, parentId);
                    parentNode = BasePageLogic.TargetNode;
                }
                BasePageLogic.AddTreeNode(this.tvPermission, newNode, parentNode);
                // 绑定grdModule
                this.GetPermissionList();
                // 使新增加的数据在grdModule中可见
                if (this.DTPermissionList.Rows.Count > 0)
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
            return returnValue;
        }
        #endregion

        #region public void AddFromChild(TreeNode newNode,TreeNode parentNode) 从FrmPermissionItemAdd调用该方法添加节点
        /// <summary>
        /// 从FrmPermissionItemAdd调用该方法添加节点
        /// </summary>
        /// <param name="newNode"></param>
        /// <param name="parentNode"></param>
        public void AddFromChild(TreeNode newNode, TreeNode parentNode)
        {
            BasePageLogic.AddTreeNode(tvPermission, newNode, parentNode);
            // 绑定grdModule
            this.GetPermissionList();
            // 使新增加的数据在grdModule中可见
            if (this.DTPermissionList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
        }
        #endregion

        public  string Add()
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
            if (this.dgvInfo.RowCount == 0)
            {
                // 提高用户体验，如果dgvInfo没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvPermission;
                return;
            }
            //var frmPermissionItemEdit = new FrmPermissionItemEdit(this.EntityId);
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiPermissionItemTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmPermissionItemEdit = new FrmPermissionItemEdit(tmpId);
            if (frmPermissionItemEdit.ShowDialog(this) == DialogResult.OK)
            {
                BasePageLogic.FindTreeNode(this.tvPermission, tmpId);
                TreeNode selectNode = BasePageLogic.TargetNode;
                selectNode.Text = frmPermissionItemEdit.FullName;
                TreeNode oldParentNode = selectNode.Parent;

                BasePageLogic.FindTreeNode(this.tvPermission, frmPermissionItemEdit.ParentId);
                TreeNode parentNode = BasePageLogic.TargetNode;
                // 编辑节点
                BasePageLogic.EditTreeNode(this.tvPermission, selectNode, parentNode);
                // 绑定dgvInfo
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
        }
        #endregion

        #region private void EditTree() 编辑权限项
        private void EditTree()
        {
            if (this.tvPermission.SelectedNode == null)
            {
                return;
            }
            var frmPermissionItemEdit = new FrmPermissionItemEdit(this.ParentEntityId);
            if (frmPermissionItemEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 编辑节点
                this.tvPermission.SelectedNode.Text = frmPermissionItemEdit.FullName;
                // 绑定dgvInfo
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                {
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
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
            if (this.LastControl == this.dgvInfo)
            {
               this.EditGrid();
            }
            if (this.LastControl == this.tvPermission)
            {
                this.EditTree();
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        }

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            bool returnValue = true;
            // 单个移动检查
            if (this.LastControl == this.tvPermission)
            {
                BasePageLogic.FindTreeNode(this.tvPermission, this.parentEntityId);
                TreeNode treeNode = BasePageLogic.TargetNode;
                BasePageLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                TreeNode targetTreeNode = BasePageLogic.TargetNode;
                if (treeNode != null && !BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    MessageBox.Show(
                        RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text),
                        RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                }
            }
            // 进行批量检查
            if (this.LastControl == this.dgvInfo)
            {
                BasePageLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                TreeNode targetTreeNode = BasePageLogic.TargetNode;
                foreach (var tmpid in this.GetSelecteIds())
                {
                    BasePageLogic.FindTreeNode(this.tvPermission, tmpid);
                    var treeNode = BasePageLogic.TargetNode;
                    if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                    {
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region private void BatchMove() 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        private void BatchMove()
        {
            if (BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected"))
            {
                frmPermissionItemSelect = new FrmPermissionSelect(this.parentEntityId);
                frmPermissionItemSelect.AllowNull = UserInfo.IsAdministrator;
                frmPermissionItemSelect.OnButtonConfirmClick += new FrmPermissionSelect.ButtonConfirmEventHandler(CheckInputMove);
                if (frmPermissionItemSelect.ShowDialog() == DialogResult.OK)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    var holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    this.ParentEntityId = frmPermissionItemSelect.SelectedId;
                    // 调用事件
                    var tags = this.GetSelecteIds();
                    RDIFrameworkService.Instance.PermissionItemService.BatchMoveTo(UserInfo, tags, frmPermissionItemSelect.SelectedId);
                    // 移动treeNode
                    BasePageLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                    var parentNode = BasePageLogic.TargetNode;
                    if (tags.Length > 0)
                    {
                        for (int i = 0; i < tags.Length; i++)
                        {
                            BasePageLogic.FindTreeNode(this.tvPermission, tags[i]);
                            BasePageLogic.MoveTreeNode(this.tvPermission, BasePageLogic.TargetNode, parentNode);
                        }
                    }
                    // 绑定grdModule
                    this.GetPermissionList();
                    if (this.DTPermissionList.Rows.Count > 0)
                        this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        public void SingleMove()
        {
            if (String.IsNullOrEmpty(this.ParentEntityId))
            {
                return;
            }
            frmPermissionItemSelect = new FrmPermissionSelect(this.ParentEntityId);
            frmPermissionItemSelect.AllowNull = UserInfo.IsAdministrator;
            frmPermissionItemSelect.OnButtonConfirmClick += new FrmPermissionSelect.ButtonConfirmEventHandler(this.CheckInputMove);
            if (frmPermissionItemSelect.ShowDialog() == DialogResult.OK)
            {
                RDIFrameworkService.Instance.PermissionItemService.MoveTo(this.UserInfo, this.CurrentEntityId, frmPermissionItemSelect.SelectedId);
                // 移动treeNode
                BasePageLogic.FindTreeNode(this.tvPermission, frmPermissionItemSelect.SelectedId);
                BasePageLogic.MoveTreeNode(this.tvPermission, this.tvPermission.SelectedNode, BasePageLogic.TargetNode);
                // 绑定dgvInfo
                this.GetPermissionList();
                if (this.DTPermissionList.Rows.Count > 0)
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTPermissionList.Rows.Count - 1;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.LastControl == this.dgvInfo)
            {
                this.BatchMove();
            }
            if (this.LastControl == this.tvPermission)
            {
                this.SingleMove();
            }
        }
        #endregion

        private void btnMove_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            var exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiPermissionTable.FieldId, "colSelected", true);
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

            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                var dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    // break;
                    // 是否有子节点
                    string id = dataRow[PiPermissionTable.FieldId].ToString();
                    BasePageLogic.FindTreeNode(this.tvPermission, id);
                    if (BasePageLogic.TargetNode != null && !BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                    {
                        MessageBox.Show(
                            RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text),
                            RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    var permissionItemEntity = BaseEntity.Create<PiPermissionItemEntity>(dataRow); 
                    if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, permissionItemEntity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }
                }
                if ((System.Boolean)(dgvRow.Cells["colSelected"].Value??false))
                {
                    // 有记录被选中了
                    returnValue = true;
                    // break;
                    // 是否有子节点
                    string id = dataRow[PiPermissionTable.FieldId].ToString();
                    BasePageLogic.FindTreeNode(this.tvPermission, id);
                    if (BasePageLogic.TargetNode != null && !BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                    {
                        MessageBox.Show(
                            RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text),
                            RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    var permissionItemEntity = BaseEntity.Create<PiPermissionItemEntity>(dataRow); 
                    if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
                    {
                        // 有不允许删除的数据
                        MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, permissionItemEntity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        returnValue = false;
                        break;
                    }

                    selectedCount++;
                }
            }

            //foreach (DataRow dataRow in this.DTPermissionList.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // break;
            //        // 是否有子节点
            //        string id = dataRow[PiPermissionTable.FieldId].ToString();
            //        BasePageLogic.FindTreeNode(this.tvPermission, id);
            //        if (BasePageLogic.TargetNode != null)
            //        {
            //            if (!BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
            //            {
            //                MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }

            //        BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
            //        if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, permissionItemEntity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }
            //    }
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        // 有记录被选中了
            //        returnValue = true;
            //        // break;
            //        // 是否有子节点
            //        string id = dataRow[PiPermissionTable.FieldId].ToString();
            //        BasePageLogic.FindTreeNode(this.tvPermission, id);
            //        if (BasePageLogic.TargetNode != null)
            //        {
            //            if (!BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
            //            {
            //                MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }

            //        BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(dataRow);
            //        if (permissionItemEntity.AllowDelete.ToString().Equals("0"))
            //        {
            //            // 有不允许删除的数据
            //            MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, permissionItemEntity.FullName), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            returnValue = false;
            //            break;
            //        }

            //        selectedCount++;
            //    }
            //}
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
                // returnValue = RDIFrameworkService.Instance.PermissionItemService.BatchDelete(UserInfo, this.GetSelecteIds());  
                string[] tags = this.GetSelecteIds();
                // 逻辑删除
                returnValue = RDIFrameworkService.Instance.PermissionItemService.SetDeleted(UserInfo, tags);
                // 获取模块列表
                this.DTPermission = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
                // 在tree删除相应的节点
                BasePageLogic.BatchRemoveNode(this.tvPermission, tags);
                // 绑定dgvInfo
                this.GetPermissionList();
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
            if (this.tvPermission.SelectedNode == null)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (!BasePageLogic.NodeAllowDelete(this.tvPermission.SelectedNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvPermission.SelectedNode.Text));
            }
            else
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 逻辑上删除
                    returnValue = RDIFrameworkService.Instance.PermissionItemService.SetDeleted(UserInfo, new string[] { this.ParentEntityId });
                    // 物理删除
                    // returnValue = RDIFrameworkService.Instance.PermissionItemService.Delete(UserInfo, this.ParentEntityId);
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags = { ((DataRow)this.tvPermission.SelectedNode.Tag)[PiPermissionTable.FieldId].ToString() };
                        BasePageLogic.BatchRemoveNode(this.tvPermission, tags);
                        // 绑定dgvInfo
                        this.GetPermissionList();
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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
            if (this.LastControl == this.dgvInfo)
            {
               returnValue = this.BatchDelete();  
            }
            if (this.LastControl == this.tvPermission)
            {
               returnValue = this.SingleDelete();      
            }
            return returnValue;
        }
        #endregion

        private void btnBatchDelete_Click(object sender, EventArgs e)
        {
            // 删除数据
            this.Delete();
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            this.FormLoaded = false;
            RDIFrameworkService.Instance.PermissionItemService.BatchSave(UserInfo, this.DTPermissionList);
            // 绑定数据
            this.FormOnLoad();
            this.FormLoaded = true;
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
            }
        }
        #endregion

        #region public void Save() 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            // 检查批量输入的有效性
            if (BasePageLogic.CheckInputModifyAnyOne(this.DTPermissionList))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();
                    this.DTPermissionList.AcceptChanges();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion 

        #region private void ModuleSetPermission() 模块权限设置
        /// <summary>
        /// 模块权限设置
        /// </summary>
        private void ModuleSetPermission()
        {
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmPermissionItemModuleBatchSet";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmModulePermissionBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmModulePermissionBatchSet.ShowDialog(this);
        }
        #endregion

        private void btnModulePermission_Click(object sender, EventArgs e)
        {
            // 权限挂接
            this.ModuleSetPermission();
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPermissionAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!BasePageLogic.IsModfiedAnyOne(this.DTPermissionList)) return;
            // 数据有变动是否保存的提示
            DialogResult dialogResult = MessageBoxHelper.Show(RDIFrameworkMessage.MSG0045);
            if (dialogResult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (dialogResult == DialogResult.OK)
            {
                // 保存数据
                this.BatchSave();
            }
        }

        private void tvPermission_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvPermission.GetNodeAt(e.X, e.Y) != null)
            {
                tvPermission.SelectedNode = tvPermission.GetNodeAt(e.X, e.Y);
            }
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            var search = this.txtSearchValue.Text.Trim();

            if (search == "'")
            {
                search = string.Empty;
            }

            this.txtSearchValue.Text = this.txtSearchValue.Text.Replace("'", "");
            search = search.Replace("'", "");


            if (String.IsNullOrEmpty(search))
            {
                this.DTPermissionList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTPermissionList.Columns.Count > 1)
                {
                    string rowFilter = string.Empty;
                    search = StringHelper.GetSearchString(search);
                    if (rbCustomerLikeSearch.Checked)
                    {
                        rowFilter = StringHelper.GetLike(PiPermissionItemTable.FieldCode, search)
                            + " OR " + StringHelper.GetLike(PiPermissionItemTable.FieldFullName, search)
                            + " OR " + StringHelper.GetLike(PiPermissionItemTable.FieldDescription, search);
                    }
                    else
                    {
                        rowFilter = StringHelper.GetEqual(PiPermissionItemTable.FieldCode, search)
                            + " OR " + StringHelper.GetEqual(PiPermissionItemTable.FieldFullName, search)
                            + " OR " + StringHelper.GetEqual(PiPermissionItemTable.FieldDescription, search);
                    }
                    this.DTPermissionList.DefaultView.RowFilter = rowFilter;
                }
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }       
    }
}
