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
    /// FrmPostAdmin
    /// 岗位管理
    /// 
    /// 修改记录    
    /// 
    ///     2014-08-05 版本：2.8 EricHu  新增移动功能。
    ///     2014.06.16 版本：2.8 EricHu  岗位管理功能页面编写。
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2014.06.16</date>
    /// </author> 
    /// </summary>
    public partial class FrmPostAdmin : BaseForm
    {
        DataTable DTOrganizeList = new DataTable(PiOrganizeTable.TableName);
        private DataTable DTRoleList = new DataTable(PiRoleTable.TableName);

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
        /// 表格中的岗位主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvRole, PiRoleTable.FieldId);
            }
        }

        /// <summary>
        /// 权限域编号
        /// </summary>
        private const string PermissionScopeCode = "Resource.ManagePermission";

        #region 权限控制部分
        /// <summary>
        /// 新增岗位权限
        /// </summary>
        public bool PermissionAdd = false;

        /// <summary>
        /// 编辑岗位权限
        /// </summary>
        public bool PermissionEdit = false;

        /// <summary>
        /// 删除权限
        /// </summary>
        public bool PermissionDelete = false;

        /// <summary>
        /// 岗位权限
        /// </summary>
        public bool PermissionSetPermission = false;

        /// <summary>
        /// 岗位用户权限
        /// </summary>
        public bool PermissionSetUser = false;

        /// <summary>
        /// 编辑组织机构权限
        /// </summary>
        public bool PermissionOrganizeEdit = false;

        /// <summary>
        /// 删除组织机构权限
        /// </summary>
        public bool PermissionOrganzieDelete = false;

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled    = false;
            this.btnEdit.Enabled   = false;
            this.btnDelete.Enabled = false;
            this.btnMoveTo.Enabled = false;
            this.btnRoleUsers.Enabled = false;
            this.btnRolePermission.Enabled = false;

            this.btnAdd.Enabled    = this.PermissionAdd;
            if (this.DTRoleList.DefaultView.Count >= 1)
            {
                this.btnEdit.Enabled   = this.PermissionEdit;
                this.btnDelete.Enabled = this.PermissionDelete;
                this.btnMoveTo.Enabled = this.PermissionEdit;
                this.btnRolePermission.Enabled = this.PermissionSetPermission;
                this.btnRoleUsers.Enabled = this.PermissionSetUser;
            }
            this.mnuAdd.Enabled = this.PermissionAdd;
            this.mnuEdit.Enabled = this.PermissionOrganizeEdit;
            this.mnuDelete.Enabled = this.PermissionOrganzieDelete;
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.PermissionAdd = this.IsAuthorized("PostAdmin.Add");
            this.PermissionEdit = this.IsAuthorized("PostAdmin.Edit");
            this.PermissionDelete = this.IsAuthorized("PostAdmin.Delete");
            this.PermissionSetPermission = this.IsAuthorized("PostAdmin.Permission");
            this.PermissionSetUser = this.IsAuthorized("PostAdmin.User");
            this.PermissionOrganizeEdit = this.IsAuthorized("OrganizeManagement.Edit");
            this.PermissionOrganzieDelete = this.IsAuthorized("OrganizeManagement.Delete");
        }
        #endregion        

        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvRole, PiOrganizeTable.FieldId, "colSelected", true);
        }
        #endregion

        public FrmPostAdmin()
        {
            InitializeComponent();
        }

        public override void  FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvRole);
            // 获取部门数据
            this.DTOrganizeList = this.GetOrganizeScope(PermissionScopeCode, true);
            this.DTOrganizeList.AcceptChanges();
            BindData(true);
        }

        #region private void BindData(bool reloadTree) 绑定数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            if (reloadTree)
            {
                this.LoadTree();
            }

            if (this.tvOrganize.SelectedNode == null)
            {
                if (this.tvOrganize.Nodes.Count > 0)
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
            if (reloadTree)
            {
                this.GetRoleList();
            }
        }
        #endregion

        #region private void GetRoleList() 获取岗位列表
        /// <summary>
        /// 获取岗位列表
        /// </summary>
        private void GetRoleList()
        {
            this.DTRoleList = RDIFrameworkService.Instance.RoleService.GetDTByOrganize(UserInfo, this.ParentEntityId, true);
            this.dgvRole.AutoGenerateColumns = false;
            this.DTRoleList.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.dgvRole.DataSource = this.DTRoleList.DefaultView;
            // 绑定数据
            this.SetControlState();
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
                BasePageLogic.CheckTreeParentId(this.DTOrganizeList, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.DTOrganizeList, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn dgvColumn in dgvRole.Columns.Cast<DataGridViewColumn>().Where(dgvColumn => !dgvColumn.Name.Contains("colSelected")))
            {
                dgvColumn.ReadOnly = true;
            }
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                tvOrganize.PathSeparator = ">";
                lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetRoleList();
                }
            }
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvOrganize;
            this.tvOrganize.ContextMenuStrip = this.tvOrganize.SelectedNode == null ? null : this.mnuOrganize;
            if (this.tvOrganize.SelectedNode == null) return;
            tvOrganize.PathSeparator = ">";
            lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
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
                if (MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0203, treeNode.Text, targetTreeNode.Text)) == System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }

            RDIFrameworkService.Instance.OrganizeService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
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

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) == null) return;
            tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.PermissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            this.LastControl = this.dgvRole;
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
            foreach (DataRow dataRow in from DataGridViewRow dgvRow in dgvRole.Rows let dataRow = (dgvRow.DataBoundItem as DataRowView).Row 
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
            //                MessageBoxHelper.ShowWarningMsg(string.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text));
            //                returnValue = false;
            //                return returnValue;
            //            }
            //        }
            //    }
            //}

            if (!returnValue)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
            }
            return returnValue;
        }
        #endregion

        #region private void btnAdd_Click(object sender, EventArgs e) 添加岗位
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            FrmPostRoleAdd FrmOrganizeRoleAdd;
            FrmOrganizeRoleAdd = this.parentEntityId.Length == 0 
                ? new FrmPostRoleAdd() 
                : new FrmPostRoleAdd(this.parentEntityId, this.tvOrganize.SelectedNode.Text);
            if (FrmOrganizeRoleAdd.ShowDialog(this) == DialogResult.OK)
            {
                result = FrmOrganizeRoleAdd.EntityId;
                // 获得岗位列表
                this.GetRoleList();
            }
        }
        #endregion

        #region private void btnEdit_Click(object sender, EventArgs e) 编辑岗位
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvRole, PiRoleTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }

            FrmPostRoleEdit frmOrganizeRoleEdit = new FrmPostRoleEdit(tmpId);
            if (frmOrganizeRoleEdit.ShowDialog(this) == DialogResult.OK)
            {
                // 获得岗位列表
                this.GetRoleList();
            }
        }
        #endregion       

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            int result = 0;
            result = RDIFrameworkService.Instance.RoleService.SetDeleted(UserInfo, this.GetSelecteIds());
            // 加载窗体
            this.GetRoleList();
            return result;
        }
        #endregion

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Delete()
        {
            int result = 0;
            if (BasePageLogic.CheckInputSelectAnyOne(dgvRole, "colSelected"))
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        result = this.BatchDelete();
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
            return result;
        }
        #endregion

        #region private void btnDelete_Click(object sender, EventArgs e) 删除选中的数据
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
        #endregion

        private void btnRoleUsers_Click(object sender, EventArgs e)
        {
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvRole);
            if (dataRow == null)
            {
                return;
            }

            string roleId = dataRow[PiRoleTable.FieldId].ToString();
            string roleRealName = dataRow[PiRoleTable.FieldRealName].ToString();
            var frmRoleUserAdmin = new FrmRoleUserAdmin(roleId, roleRealName);
            frmRoleUserAdmin.ShowDialog(this);
        }

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvRole);
            if (dataRow == null)
            {
                return;
            }

            string roleId = dataRow[PiRoleTable.FieldId].ToString();
            string roleRealName = dataRow[PiRoleTable.FieldRealName].ToString();

            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmRolePermission";
            if (!SystemInfo.EnablePermissionItem)
            {
                formName = "FrmRoleModulePermission";
            }
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType, roleId, roleRealName);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != DialogResult.Yes)
            {
                return;
            }          
            this.Close();            
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            string search = this.txtSearchValue.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTRoleList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringHelper.GetSearchString(search);
                this.DTRoleList.DefaultView.RowFilter =StringHelper.GetLike(PiRoleTable.FieldRealName, search)
                        + " OR " + StringHelper.GetLike("Users", search)
                        + " OR " + StringHelper.GetLike(PiRoleTable.FieldDescription, search);
                this.dgvRole.DataSource = this.DTRoleList.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        public void SingleMove()
        {
            if (String.IsNullOrEmpty(this.EntityId))
            {
                return;
            }
            var frmOrganizeSelect = new FrmOrganizeSelect(this.EntityId)
            {
                MultiSelect = false,
                AllowNull = false,
                PermissionScopeCode = this.PermissionItemScopeCode
            };

            if (frmOrganizeSelect.ShowDialog() != DialogResult.OK) return;
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            RDIFrameworkService.Instance.RoleService.MoveTo(UserInfo, this.EntityId, frmOrganizeSelect.SelectedId);
            this.GetRoleList();;
            this.Cursor = holdCursor;
        }
        #endregion

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            this.SingleMove();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                string assemblyName = "RDIFramework.WinModule";
                string formName = "FrmEditOrganize";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmOrganizeEdit = (Form)Activator.CreateInstance(type, (this.tvOrganize.SelectedNode.Tag as DataRow)[PiOrganizeTable.FieldId].ToString());
                if (frmOrganizeEdit.ShowDialog() == DialogResult.OK)
                {
                    this.FormLoaded = false;
                    this.FormOnLoad();
                    this.FormLoaded = true;
                }
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (this.LastControl != this.tvOrganize) return;

            if (!BasePageLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvOrganize.SelectedNode.Text));
            }
            else
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(this.ParentEntityId))
                    {
                        return;
                    }
                    int returnInt = RDIFrameworkService.Instance.OrganizeService.SetDeleted(UserInfo, new String[] { this.ParentEntityId });

                    if (returnInt <= 0) return;
                    this.FormLoaded = false;
                    this.FormOnLoad();
                    this.FormLoaded = true;
                }
            }
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.LastControl = dgvRole;
        }
    }
}
