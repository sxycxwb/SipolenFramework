/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2011-01-16 11:09:15
 ******************************************************************************/
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmOrganizeAdmin
    /// 组织机构管理
    /// 
    /// 修改记录
    /// 
    ///     2015-01-27 版本：2.9 王进  修改选择组织机构树不能删除的问题。
    /// 
    /// </summary>
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.01.16</date>
    /// </author> 
    public partial class FrmOrganizeAdmin : BaseForm
    {
        IOrganizeService organizationService = RDIFrameworkService.Instance.OrganizeService;
        DataTable DTOrganize = null;
        DataTable DTOrganizeList = new DataTable(PiOrganizeTable.TableName);

        #region 权限定义区域
        /// <summary>
        /// 访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 新增组织机构权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 编辑组织机构权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 删除组织机构权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 移动组织机构
        /// </summary>
        private bool permissionMove = false;

        /// <summary>
        /// 导出
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// (用户-组织机构)权限
        /// </summary>
        bool permissionUserOrganizePermission = false;

        /// <summary>
        /// (角色-组织机构)权限
        /// </summary>
        bool permissionRolerOrganizePermission = false;

        /// <summary>
        /// 组织机构权限设置
        /// </summary>
        private bool permissionOrganizePermission = false;

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";
        #endregion

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private Control LastControl = null;

        public event SetControlStateEventHandler OnButtonStateChange;

        private string parentEntityId = string.Empty;
        /// <summary>
        /// 导航栏机构主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString();
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
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                string entityId = string.Empty;
                entityId = this.LastControl == this.tvOrganize ? this.ParentEntityId : this.EntityId;
                return entityId;
            }
        }

        /// <summary>
        /// 表格中的组织机构主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiOrganizeTable.FieldId);
            }
        }

        public void SetSortButton(bool enabled)
        {
            this.ucSortControl.SetSortButton(enabled);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.SetSortButton(false);
            this.btnAdd.Enabled    = false;
            this.btnEdit.Enabled   = false;
            this.btnMoveTo.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            this.mnuAdd.Enabled    = false;
            this.mnuEdit.Enabled   = false;
            this.mnuMoveTo.Enabled = false;
            this.mnuDelete.Enabled = false;
            this.ddbOrganizePermissionSet.Visible = SystemInfo.EnableUserAuthorizationScope || SystemInfo.EnableOrganizePermission;
            this.btnUserOrganizePermission.Visible = SystemInfo.EnableUserAuthorizationScope;
            this.btnRoleOrganizePermission.Visible = SystemInfo.EnableUserAuthorizationScope;
            this.btnPermission.Visible = SystemInfo.EnableOrganizePermission;
            this.btnUserOrganizePermission.Enabled = false;
            this.btnRoleOrganizePermission.Enabled = false;
            this.btnPermission.Enabled = false;

            // 检查添加权限
            this.btnAdd.Enabled    = this.permissionAdd;
            this.mnuAdd.Enabled    = this.permissionAdd;
            if ((this.DTOrganizeList.DefaultView.Count >= 1) || (this.tvOrganize.Nodes.Count > 0))
            {
                this.btnEdit.Enabled   = this.permissionEdit;
                this.btnMoveTo.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
                this.mnuEdit.Enabled   = this.permissionEdit;
                this.mnuMoveTo.Enabled = this.permissionMove;
                this.mnuDelete.Enabled = this.permissionDelete;
                this.btnUserOrganizePermission.Enabled = this.permissionUserOrganizePermission;
                this.btnRoleOrganizePermission.Enabled = this.permissionRolerOrganizePermission;
                this.btnPermission.Enabled = this.permissionOrganizePermission;

                if (this.DTOrganizeList.DefaultView.Count >= 1)
                {
                    this.btnExport.Enabled = this.permissionExport;
                }
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.btnExport.Enabled = this.permissionExport;
                }              
            }

            // 位置顺序改变按钮部分
            if (this.DTOrganizeList.DefaultView.Count > 1)
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
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit,  batchSave);
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess   = this.IsModuleAuthorized("OrganizeManagement");
            this.permissionAdd      = this.IsAuthorized("OrganizeManagement.Add");
            this.permissionEdit     = this.IsAuthorized("OrganizeManagement.Edit");
            this.permissionMove     = this.IsAuthorized("OrganizeManagement.Move");
            this.permissionDelete   = this.IsAuthorized("OrganizeManagement.Delete");
            this.permissionExport   = this.IsAuthorized("OrganizeManagement.Export");
            this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
            this.permissionUserOrganizePermission  = this.IsAuthorized("OrganizeManagement.UserOrganizePermission");
            this.permissionRolerOrganizePermission = this.IsAuthorized("OrganizeManagement.RolerOrganizePermission");
            this.permissionOrganizePermission = this.IsAuthorized("OrganizeManagement.Permission");
        }
        #endregion        

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiOrganizeTable.FieldId, "colSelected", true);
        }
        #endregion

        public FrmOrganizeAdmin()
        {
            InitializeComponent();
        }

        public override void  FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvInfo);
            BindData(true);
        }

        #region private void BindData(bool reloadTree) 绑定数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                // 获取部门数据，这里是按权限范围进行获取
                this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, this.chkInnerOrganize.Checked);//organizationService.GetDT(this.UserInfo);
                if (!this.UserInfo.IsAdministrator || this.chkInnerOrganize.Checked)
                {
                    BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
                }
                this.LoadTree();
                if (this.tvOrganize.SelectedNode == null && this.tvOrganize.Nodes.Count > 0)
                {
                    if (this.parentEntityId.Length == 0)
                    {
                        this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                    }
                    else
                    {
                        BasePageLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
                        if (BasePageLogic.TargetNode != null)
                        {
                            this.tvOrganize.SelectedNode = BasePageLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BasePageLogic.ExpandTreeNode(this.tvOrganize);
                        }
                    }
                    if (this.tvOrganize.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvOrganize.SelectedNode.Expand();
                        this.tvOrganize.SelectedNode.EnsureVisible();
                    }
                }
            }

            if (this.ParentEntityId.Length > 0 && reloadTree)
            {
                // 获得子部门列表
                this.GetOrganizeList();
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;       
            this.DTOrganizeList = organizationService.GetDTByParent(UserInfo, this.ParentEntityId);
            this.DTOrganizeList.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.DataSource = this.DTOrganizeList.DefaultView;
            this.AddCheckBoxColumn(dgvInfo);
            // 动态加载树形结构
            //if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            //{
            //    foreach (var treeNode in from DataRow dataRow in this.DTOrganizeList.Rows select new TreeNode
            //    {
            //        Text = dataRow[PiOrganizeTable.FieldFullName].ToString(),
            //        Tag = dataRow[PiOrganizeTable.FieldId].ToString()
            //    })
            //    {
            //        this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
            //    }                
            //}
                
            // 设置排序按钮
            this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void LoadTree()  加载组织机构到树
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            this.LoadTreeOrganize();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }

        private void LoadTreeOrganize()
        {
            var treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            if ((SystemInfo.EnableUserAuthorizationScope) && !UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode, !SystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        public override void RefreshForm()
        {
            this.FormOnLoad();
        }

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn dgvColumn in dgvInfo.Columns.Cast<DataGridViewColumn>().Where(dgvColumn => !dgvColumn.Name.Contains("colSelected")))
            {
                dgvColumn.ReadOnly = true;
            }
        }

        private void tvOrganize_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.ToolTipText)) return;
            e.Node.Nodes.Clear();   
            LoadTreeOrganize(e.Node);
            e.Node.ToolTipText = e.Node.Text;
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded || this.ActiveControl != this.tvOrganize) return;
            tvOrganize.PathSeparator = ">";
            lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
            if (this.tvOrganize.SelectedNode == null) return;
            BasePageLogic.TargetNode = this.tvOrganize.SelectedNode;
            this.GetOrganizeList();
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvOrganize;
            this.tvOrganize.ContextMenuStrip = this.tvOrganize.SelectedNode == null ? null : this.mnuOrganize;
            if (this.tvOrganize.SelectedNode == null) return;
            tvOrganize.PathSeparator = ">";
            lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
            this.GetOrganizeList();
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)) return;
            // 拖放的目标节点
            TreeNode targetTreeNode;
            // 获取当前光标所处的坐标
            // 定义一个位置点的变量，保存当前光标所处的坐标点
            Point point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            // 根据坐标点取得处于坐标点位置的节点
            targetTreeNode = ((TreeView)sender).GetNodeAt(point);
            // 获取被拖动的节点
            treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
            if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode)) return;
            if (SystemInfo.ShowInformation)
            {
                // 是否移动部门
                if (MessageBoxHelper.Show(RDIFrameworkMessage.Format("确定移动{0}到{1}吗?", treeNode.Text, targetTreeNode.Text)) == System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            organizationService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
            // 往目标节点中加入被拖动节点的一份克隆
            targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
            // 将被拖动的节点移除
            treeNode.Remove();
        }

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //if (this.permissionEdit)
            //{
            //    // 开始进行拖放操作，并将拖放的效果设置成移动。
            //    this.DoDragDrop(e.Item, DragDropEffects.Move);
            //}
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) == null) return;
            tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            this.LastControl = this.dgvInfo;
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            var returnValue = false;

            //重构后 V2.7
            foreach (DataRow dataRow in from DataGridViewRow dgvRow in dgvInfo.Rows let dataRow = (dgvRow.DataBoundItem as DataRowView).Row 
                                        where (System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false) select dataRow)
            {
                // 有记录被选中了
                returnValue = true;
                // 是否有子节点
                var id = dataRow[PiOrganizeTable.FieldId].ToString();
                BasePageLogic.FindTreeNode(this.tvOrganize, id);
                if (BasePageLogic.TargetNode != null && !BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                {
                    MessageBoxHelper.ShowWarningMsg(string.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text));
                    returnValue = false;
                    return returnValue;
                }
            }
            //重构前的代码 V2.5版本
            //foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            //{
            //    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
            //    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
            //    {
            //        // 有记录被选中了
            //        returnValue = true;
            //        // 是否有子节点
            //        string id = dataRow[PiOrganizeTable.FieldId].ToString();
            //        BasePageLogic.FindTreeNode(this.tvOrganize, id);
            //        if (BasePageLogic.TargetNode != null)
            //        {
            //            if (!BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
            //            {
            //                MessageBoxHelper.ShowWarningMsg(string.Format("{0} 有子节点不允许被删除！", BasePageLogic.TargetNode.Text));
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }
            //    }
            //}

            if (!returnValue)
            {
                MessageBoxHelper.ShowWarningMsg("无选择的数据!");
            }
            return returnValue;
        }
        #endregion

        #region private void btnAdd_Click(object sender, EventArgs e) 添加组织机构
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string returnValue = string.Empty;
            FrmEditOrganize editOrgznize = null;
            if (this.LastControl == this.tvOrganize)
            {
                editOrgznize = this.ParentEntityId.Length == 0 || this.tvOrganize.SelectedNode == null
                    ? new FrmEditOrganize()
                    : new FrmEditOrganize(this.ParentEntityId, this.tvOrganize.SelectedNode.Text);
            }   
            else
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                editOrgznize = dataRow == null ? new FrmEditOrganize() : new FrmEditOrganize(dataRow[PiOrganizeTable.FieldId].ToString(), dataRow[PiOrganizeTable.FieldFullName].ToString());
            }

            if (editOrgznize.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;
            returnValue = editOrgznize.EntityId;
            var fullName = editOrgznize.FullName;
            var parentId = editOrgznize.ParentId;
            // tvOrganize 中增加结点
            var newNode = new TreeNode();
            newNode.Text = fullName;
            newNode.Tag = RDIFrameworkService.Instance.OrganizeService.GetDTByIds(UserInfo, new string[] { returnValue }).Rows[0];
            TreeNode parentNode = null;
            if (!string.IsNullOrEmpty(parentId))
            {
                BasePageLogic.FindTreeNode(this.tvOrganize, parentId);
                parentNode = BasePageLogic.TargetNode;
            }
            BasePageLogic.AddTreeNode(this.tvOrganize, newNode, parentNode);
            // 绑定数据
            this.GetOrganizeList();
            this.FormLoaded = false;
            this.BindData(true);
            this.FormLoaded = true;

            if (SystemInfo.ClientCache)
            {
                ClientCache.Instance.DTOrganize = null;
            }

            // 使新增加的数据可见
            if (this.DTOrganizeList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
        }
        #endregion

        #region private void btnEdit_Click(object sender, EventArgs e) 编辑组织机构
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.LastControl == dgvInfo)
            {
                switch (this.dgvInfo.Rows.Count)
                {
                    case 0:
                        this.LastControl = tvOrganize;
                        return;
                }

                //var frmEditOrganize = new FrmEditOrganize(this.EntityId);
                string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiOrganizeTable.FieldId);
                if (string.IsNullOrEmpty(tmpId))
                {
                    return;
                }
                var frmEditOrganize = new FrmEditOrganize(tmpId);
                if (frmEditOrganize.ShowDialog(this) != DialogResult.OK) return;
                BasePageLogic.FindTreeNode(this.tvOrganize,tmpId);
                var selectedNode = BasePageLogic.TargetNode;
                selectedNode.Text = frmEditOrganize.FullName;
                var oldParentNode = selectedNode.Parent;
                BasePageLogic.FindTreeNode(this.tvOrganize, frmEditOrganize.ParentId);
                var parentNode = BasePageLogic.TargetNode;

                BasePageLogic.EditTreeNode(this.tvOrganize, selectedNode, parentNode);

                this.GetOrganizeList();
                if (this.DTOrganizeList.Rows.Count > 0)
                {
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
                }
            }
            else
            {
                if (tvOrganize.SelectedNode == null)
                {
                    return;
                }

                var frmEditOrganize = new FrmEditOrganize(this.ParentEntityId);
                if (frmEditOrganize.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.tvOrganize.SelectedNode.Text = frmEditOrganize.FullName;
                    this.GetOrganizeList();
                    if (this.DTOrganizeList.Rows.Count <= 0) return;
                    this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
                }
            }

        }
        #endregion       

        #region private void btnDelete_Click(object sender, EventArgs e) 删除选中的数据
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.LastControl == dgvInfo)
            {
                var returnValue = 0;
                if (this.CheckInputBatchDelete() &&
                    MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SystemInfo.ClientCache)
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }

                    this.FormLoaded = false;
                    // 绑定数据
                    var tags = BasePageLogic.GetSelecteIds(this.dgvInfo, PiOrganizeTable.FieldId, "colSelected",true);
                    returnValue = organizationService.SetDeleted(UserInfo, tags);
                    if (SystemInfo.ClientCache)
                    {
                        ClientCache.Instance.DTOrganize = null;
                    }
                    // 获取列表
                    this.DTOrganize = organizationService.GetDT(UserInfo);
                    // 在tree删除相应的节点
                    BasePageLogic.BatchRemoveNode(this.tvOrganize, tags);
                    // 绑定grdModule
                    this.GetOrganizeList();
                    this.FormLoaded = true;
                }
            }
            else
            {
                var returnValue = 0;
                if (this.tvOrganize.SelectedNode == null)
                {
                    returnValue = 0;
                    return;
                }
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    if (!BasePageLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
                    {
                        MessageBoxHelper.ShowWarningMsg(string.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text));
                    }
                    else
                    {
                        if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) != System.Windows.Forms.DialogResult.Yes) return;
                        returnValue = organizationService.SetDeleted(UserInfo, new String[] { this.ParentEntityId });
                        if (SystemInfo.ClientCache)
                        {
                            ClientCache.Instance.DTOrganize = null;
                        }
                        if (returnValue <= 0) return;
                        string[] tags = { ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString()};
                        BasePageLogic.BatchRemoveNode(this.tvOrganize, tags);
                        // 绑定grdOrganize
                        this.GetOrganizeList();
                    }                   
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.FormLoaded = true;
                    this.Cursor = holdCursor;
                }
            }
        }
        #endregion

        #region  private void btnMoveTo_Click(object sender, EventArgs e) 移动数据

        #region private bool CheckInputMove(string selectedId) 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(string selectedId)
        {
            var returnValue = true;
            // 单个移动检查
            if (this.LastControl == this.tvOrganize)
            {
                BasePageLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
                var treeNode = BasePageLogic.TargetNode;
                BasePageLogic.FindTreeNode(this.tvOrganize, selectedId);
                var targetTreeNode = BasePageLogic.TargetNode;
                if (treeNode != null && !BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036,
                        treeNode.Text, targetTreeNode.Text));
                    returnValue = false;
                }
            }
            // 进行批量检查
            if (this.LastControl == this.dgvInfo)
            {
                BasePageLogic.FindTreeNode(this.tvOrganize, selectedId);
                TreeNode targetTreeNode = BasePageLogic.TargetNode;
                var selecteIds = this.GetSelecteIds();
                foreach (string tmpId in selecteIds)
                {
                    BasePageLogic.FindTreeNode(this.tvOrganize, tmpId);
                    TreeNode treeNode = BasePageLogic.TargetNode;
                    if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode)) continue;
                    MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    returnValue = false;
                    break;
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
            if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected")) return;
            var frmOrganizeSelect = new FrmOrganizeSelect(this.ParentEntityId, this.chkInnerOrganize.Checked);
            if (UserInfo.IsAdministrator)
            {
                frmOrganizeSelect.AllowNull = true;
            }
            else
            {
                frmOrganizeSelect.AllowNull = false;
                frmOrganizeSelect.PermissionScopeCode = this.PermissionItemScopeCode;
            }
            frmOrganizeSelect.OnButtonConfirmClick += new BusinessLogic.CheckMoveEventHandler(CheckInputMove);
            if (frmOrganizeSelect.ShowDialog() != DialogResult.OK) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            RDIFrameworkService.Instance.OrganizeService.BatchMoveTo(UserInfo, this.GetSelecteIds(), frmOrganizeSelect.SelectedId);
            //if ((SystemInfo.ClientCache) && (this.chkRefresh.Checked))
            //{
            //    ClientCache.Instance.DTOrganize = null;
            //}
            this.ParentEntityId = frmOrganizeSelect.SelectedId;
            // 调用事件
            var tags = this.GetSelecteIds();
            RDIFrameworkService.Instance.OrganizeService.BatchMoveTo(UserInfo, tags, frmOrganizeSelect.SelectedId);
            // 移动treeNode
            BasePageLogic.FindTreeNode(this.tvOrganize, frmOrganizeSelect.SelectedId);
            var parentNode = BasePageLogic.TargetNode;
            if (tags.Length > 0)
            {
                foreach (string tmpTag in tags)
                {
                    BasePageLogic.FindTreeNode(this.tvOrganize, tmpTag);
                    BasePageLogic.MoveTreeNode(this.tvOrganize, BasePageLogic.TargetNode, parentNode);
                }
            }
            // 绑定grdOrganize
            this.GetOrganizeList();
            if (this.DTOrganizeList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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
            var frmOrganizeSelect = new FrmOrganizeSelect(this.ParentEntityId, this.chkInnerOrganize.Checked);
            if (UserInfo.IsAdministrator)
            {
                frmOrganizeSelect.AllowNull = true;
            }
            else
            {
                frmOrganizeSelect.AllowNull = false;
                frmOrganizeSelect.PermissionScopeCode = this.PermissionItemScopeCode;
            }
            frmOrganizeSelect.OnButtonConfirmClick += new BusinessLogic.CheckMoveEventHandler(CheckInputMove);
            if (frmOrganizeSelect.ShowDialog() != DialogResult.OK) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            RDIFrameworkService.Instance.OrganizeService.MoveTo(UserInfo, this.CurrentEntityId, frmOrganizeSelect.SelectedId);
            if (!SystemInfo.ClientCache)
            {
                ClientCache.Instance.DTOrganize = null;
            }
            this.FormLoaded = false;
            //if ((SystemInfo.ClientCache) && (this.chkRefresh.Checked))
            //{
            //    ClientCache.Instance.DTOrganize = null;
            //}
            // 移动treeNode
            BasePageLogic.FindTreeNode(this.tvOrganize, frmOrganizeSelect.SelectedId);
            BasePageLogic.MoveTreeNode(this.tvOrganize, this.tvOrganize.SelectedNode, BasePageLogic.TargetNode);
            // 绑定grdOrganize
            this.GetOrganizeList();
            if (this.DTOrganizeList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTOrganizeList.Rows.Count - 1;
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveTo()
        {
            if (this.LastControl == this.dgvInfo)
            {
                this.BatchMove();
            }
            if (this.LastControl == this.tvOrganize)
            {
                this.SingleMove();
            }
        }
        #endregion

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveTo();
        }
        #endregion

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            this.FormLoaded = false;
            RDIFrameworkService.Instance.OrganizeService.BatchSave(UserInfo, this.DTOrganizeList);
            if (!SystemInfo.ClientCache)
            {
                ClientCache.Instance.DTOrganize = null;
            }
            // 绑定数据
            this.BindData(true);
            this.FormLoaded = true;
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
            }
        }        

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            // 检查批量输入的有效性
            if (BasePageLogic.CheckInputModifyAnyOne(this.DTOrganizeList))
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();                   
                    this.DTOrganizeList.AcceptChanges();
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

        private void ReSet()
        { 
            // 重新获取客户端的缓存组织机构块数据
            ClientCache.Instance.DTOrganize = organizationService.GetDT(UserInfo);         
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {            
            this.Save();
            this.ReSet();
        }    
        private void btnExport_Click(object sender, EventArgs e)
        {
            this.ExportToExcel(dgvInfo, "ExportFile", "组织机构");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0101) != DialogResult.Yes)
            {
                return;
            }          
            this.Close();            
        }

        private void btnUserOrganizePermission_Click(object sender, EventArgs e)
        {
            // 用户权限批量设置(用户-组织机构)
            var permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = PiOrganizeTable.TableName;
            var targetResourceSQL = "SELECT " + PiOrganizeTable.FieldId + " AS Id, "
                                        + PiOrganizeTable.FieldParentId + " AS ParentId, "
                                        + PiOrganizeTable.FieldFullName + " AS RealName, "
                                        + PiOrganizeTable.FieldDescription + " AS Description FROM "
                                        + PiOrganizeTable.TableName
                                        + " WHERE " + PiOrganizeTable.FieldIsInnerOrganize + " = 1 AND " + PiOrganizeTable.FieldDeleteMark + " = 0 AND " + PiOrganizeTable.FieldEnabled + " = 1 ORDER BY " + PiOrganizeTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmUserOrganizePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmUserOrganizePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmUserOrganizePermission.ShowDialog(this);
        }

        private void btnRoleOrganizePermission_Click(object sender, EventArgs e)
        {
            // 角色权限批量设置(角色-组织机构)
            const string permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = PiOrganizeTable.TableName;
            var targetResourceSQL = "SELECT " + PiOrganizeTable.FieldId + " AS Id, "
                                        + PiOrganizeTable.FieldParentId + " AS ParentId, "
                                        + PiOrganizeTable.FieldFullName + " AS RealName, "
                                        + PiOrganizeTable.FieldDescription + " AS Description FROM "
                                        + PiOrganizeTable.TableName
                                        + " WHERE " + PiOrganizeTable.FieldIsInnerOrganize + " = 1 AND " + PiOrganizeTable.FieldDeleteMark + " = 0 AND " + PiOrganizeTable.FieldEnabled + " = 1 ORDER BY " + PiOrganizeTable.FieldSortCode;

            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmRoleOrganizePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var RoleOrganizePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            RoleOrganizePermission.ShowDialog(this);
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            FrmOrganizePermission frmOrganizePermission;
            if (this.LastControl == this.tvOrganize)
            {
                if ((this.ParentEntityId.Length == 0) || (this.tvOrganize.SelectedNode == null))
                {
                    frmOrganizePermission = new FrmOrganizePermission();
                }
                else
                {
                    frmOrganizePermission = new FrmOrganizePermission(this.ParentEntityId, this.tvOrganize.SelectedNode.Text);
                }
            }
            else
            {
                DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                string id = dataRow[PiOrganizeTable.FieldId].ToString();
                if (String.IsNullOrEmpty(id))
                {
                    MessageBox.Show(RDIFrameworkMessage.MSG0060, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string realName = dataRow[PiOrganizeTable.FieldFullName].ToString();
                    frmOrganizePermission = new FrmOrganizePermission(id, realName);
                }
            }
            frmOrganizePermission.ShowDialog(this);
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
                this.DTOrganizeList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTOrganizeList.Columns.Count <= 1) return;
                string rowFilter = string.Empty;
                search = StringHelper.GetSearchString(search);
                rowFilter = rbCustomerLikeSearch.Checked
                    ? StringHelper.GetLike(PiOrganizeTable.FieldCode, search)
                      + " OR " + StringHelper.GetLike(PiOrganizeTable.FieldFullName, search)
                      + " OR " + StringHelper.GetLike(PiOrganizeTable.FieldManager, search)
                      + " OR " + StringHelper.GetLike(PiOrganizeTable.FieldOuterPhone, search)
                      + " OR " + StringHelper.GetLike(PiOrganizeTable.FieldFax, search)
                      + " OR " + StringHelper.GetLike(PiOrganizeTable.FieldDescription, search)
                    : StringHelper.GetEqual(PiOrganizeTable.FieldCode, search)
                      + " OR " + StringHelper.GetEqual(PiOrganizeTable.FieldFullName, search)
                      + " OR " + StringHelper.GetEqual(PiOrganizeTable.FieldManager, search)
                      + " OR " + StringHelper.GetEqual(PiOrganizeTable.FieldOuterPhone, search)
                      + " OR " + StringHelper.GetEqual(PiOrganizeTable.FieldFax, search)
                      + " OR " + StringHelper.GetEqual(PiOrganizeTable.FieldDescription, search);
                this.DTOrganizeList.DefaultView.RowFilter = rowFilter;
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }


    }
}
