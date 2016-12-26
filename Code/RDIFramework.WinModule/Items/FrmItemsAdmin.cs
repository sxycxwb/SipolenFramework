using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmItemsAdmin.cs
    /// 数据字典管理
    /// 
    /// 修改记录
    ///     2015-04-06 EricHu V2.9 新增数据字典管理。
    ///     
    /// 
    /// </summary>
    public partial class FrmItemsAdmin : BaseForm
    {
        /// <summary>
        /// 字典项 DataTable
        /// </summary>
        private DataTable DTItemsList = new DataTable(CiItemsTable.TableName);

        /// <summary>
        /// 字典明细 DataTable
        /// </summary>
        private DataTable DTItemsDetailList = new DataTable(CiItemDetailsTable.TableName);

        #region Permission Region
        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 本模块的导出数据
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 本模块的字典明细权限
        /// </summary>
        private bool permissionItemDetail = false;

        /// <summary>
        /// 本模块的用户权限
        /// </summary>
        private bool permissionUserPermission = false;

        /// <summary>
        /// 本模块的角色权限
        /// </summary>
        private bool permissionRolePermission = false;


        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAddItemsDetail = false;

        /// <summary>
        /// 本模块的编辑权限
        /// </summary>
        private bool permissionEditItemsDetail = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDeleteItemsDetail = false;
        #endregion

        public FrmItemsAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.mnuEdit.Enabled = false;
            this.mnuDelete.Enabled = false;            
            this.mnuUserPermission.Visible = false;
            this.mnuRolePermission.Visible = false;
            this.mnuAdd.Enabled = this.permissionAdd;

            this.btnEditItemDetail.Enabled = false;
            this.btnDeleteItemDetail.Enabled = false;
            if (DTItemsList.DefaultView.Count >= 1)
            {
                this.mnuAdd.Enabled = this.permissionAdd;
                this.mnuEdit.Enabled = this.permissionEdit;
                this.mnuDelete.Enabled = this.permissionDelete;                
                this.mnuUserPermission.Visible = this.permissionUserPermission;
                this.mnuRolePermission.Visible = this.permissionRolePermission;

                this.btnAddItemDetail.Enabled = this.permissionAddItemsDetail;
                this.btnEditItemDetail.Enabled = this.permissionEditItemsDetail;
                this.btnDeleteItemDetail.Enabled = this.permissionDeleteItemsDetail;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("DataDictionaryManagement");
            this.permissionAdd = this.IsAuthorized("DataDictionaryManagement.Add");
            this.permissionEdit = this.IsAuthorized("DataDictionaryManagement.Edit");
            this.permissionDelete = this.IsAuthorized("DataDictionaryManagement.Delete");
            this.permissionExport = this.IsAuthorized("DataDictionaryManagement.Export");
            this.permissionItemDetail = this.IsAuthorized("DataDictionaryManagement.ItemDetail");
            this.permissionUserPermission = this.IsAuthorized("DataDictionaryManagement.UserPermission");
            this.permissionRolePermission = this.IsAuthorized("DataDictionaryManagement.RolePermission");

            this.permissionAddItemsDetail = this.IsAuthorized("DictionaryDetail.Add");
            this.permissionEditItemsDetail = this.IsAuthorized("DictionaryDetail.Edit");
            this.permissionDeleteItemsDetail = this.IsAuthorized("DictionaryDetail.Delete");
        }
        #endregion

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        private string treeEntityId = string.Empty;
        /// <summary>
        /// 导航栏主键
        /// </summary>
        public string TreeEntityId
        {
            get
            {
                this.treeEntityId = (this.tvItems.SelectedNode != null) && (this.tvItems.SelectedNode.Tag != null)
                    ? ((DataRow)this.tvItems.SelectedNode.Tag)[CiItemsTable.FieldId].ToString()
                    : string.Empty;
                return this.treeEntityId;
            }
            set
            {
                this.treeEntityId = value;
            }
        }

        /// <summary>
        /// 列表中的主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, CiItemDetailsTable.FieldId);
            }
        }

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加模块载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                // 加载模块树
                this.LoadTree();
                if (this.tvItems.SelectedNode == null)
                {
                    if (this.tvItems.Nodes.Count > 0)
                    {
                        if (this.treeEntityId.Length == 0)
                        {
                            this.tvItems.SelectedNode = this.tvItems.Nodes[0];
                        }
                        else
                        {
                            BasePageLogic.FindTreeNode(this.tvItems, this.treeEntityId);
                            if (BasePageLogic.TargetNode != null)
                            {
                                this.tvItems.SelectedNode = BasePageLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BasePageLogic.ExpandTreeNode(this.tvItems);
                            }
                        }
                        if (this.tvItems.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvItems.SelectedNode.Expand();
                            this.tvItems.SelectedNode.EnsureVisible();
                        }
                    }
                }

            }
            if (this.TreeEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    this.GetItemsDetailList();
                }
            }          
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
            this.GetItems();
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region public void GetItems() 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public void GetItems()
        {
            this.DTItemsList = RDIFrameworkService.Instance.ItemsService.GetDT(UserInfo);
        }
        #endregion

        #region private void LoadTree() 加载模块树的主键
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvItems.BeginUpdate();
            this.tvItems.Nodes.Clear();
            var treeNode = new TreeNode();
            this.LoadTreeItems(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvItems.EndUpdate();
        }
        #endregion

        #region private void LoadTreeItems(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeItems(TreeNode treeNode)
        {
            if ((SystemInfo.EnableUserAuthorizationScope) && !UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.DTItemsList, CiItemsTable.FieldId, CiItemsTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.DTItemsList, CiItemsTable.FieldId, CiItemsTable.FieldParentId, CiItemsTable.FieldFullName, this.tvItems, treeNode);
        }
        #endregion

        #region private void GetItemsDetailList() 获得子模块列表
        /// <summary>
        /// 获得子模块列表
        /// </summary>
        private void GetItemsDetailList()
        {           
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.DTItemsDetailList = RDIFrameworkService.Instance.ItemsService.GetItemDetailDTByItemId(UserInfo, this.TreeEntityId);
                this.dgvInfo.AutoGenerateColumns = false;
                this.DTItemsDetailList.DefaultView.Sort = CiItemDetailsTable.FieldSortCode;
                this.dgvInfo.DataSource = this.DTItemsDetailList.DefaultView;                
                this.SetControlState();
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
        #endregion

        //增加字典项
        private void mnuAdd_Click(object sender, EventArgs e)
        {
            FrmAddItems frmAddItems = new FrmAddItems(this.TreeEntityId);
            if (frmAddItems.ShowDialog() == DialogResult.OK)
            {
                FormOnLoad();
            }
        }

        //修改字典项
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            FrmEditItems frmEditItems = new FrmEditItems {EntityId = this.TreeEntityId};
            if (frmEditItems.ShowDialog() == DialogResult.OK)
            {
                FormOnLoad();
            }
        }

        //删除字典项
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            this.DeleteItems();
        }
       
        private void mnuUserPermission_Click(object sender, EventArgs e)
        {
            // 用户资源管理权限
            var permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = CiItemsTable.TableName;
            var targetResourceSQL = "SELECT " + CiItemsTable.FieldId + " AS Id, "
                                        + CiItemsTable.FieldFullName + " AS RealName, "
                                        + CiItemsTable.FieldDescription + " AS Description FROM "
                                        + CiItemsTable.TableName
                                        + " WHERE " + CiItemsTable.FieldDeleteMark + " = 0 AND " + CiItemsTable.FieldEnabled + " = 1 ORDER BY " + CiItemsTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmUserResourcePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void mnuRolePermission_Click(object sender, EventArgs e)
        {
            // 角色资源管理权限
            var permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = CiItemsTable.TableName;
            var targetResourceSQL = "SELECT " + CiItemsTable.FieldId + " AS Id, "
                                        + CiItemsTable.FieldFullName + " AS RealName, "
                                        + CiItemsTable.FieldDescription + " AS Description FROM "
                                        + CiItemsTable.TableName
                                        + " WHERE " + CiItemsTable.FieldDeleteMark + " = 0 AND " + CiItemsTable.FieldEnabled + " = 1 ORDER BY " + CiItemsTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmRoleResourcePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            frmRoleModulePermission.ShowDialog(this);
        }

        //增加字典明细
        private void btnAddItemDetail_Click(object sender, EventArgs e)
        {
            FrmAddItemDetail frmAddItemDetail = new FrmAddItemDetail(this.TreeEntityId);
            if (frmAddItemDetail.ShowDialog() == DialogResult.OK)
            {
                this.GetItemsDetailList();
            }
        }

        //修改字典明细
        private void btnEditItemDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.EntityId))
            {
                return;
            }
            FrmEditItemsDetail frmEditItemsDetail = new FrmEditItemsDetail {EntityId = this.EntityId};
            if (frmEditItemsDetail.ShowDialog() == DialogResult.OK)
            {
                this.GetItemsDetailList();
            }
        }

        private void btnDeleteItemDetail_Click(object sender, EventArgs e)
        {
            this.DeleteItemDetals();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != DialogResult.Yes)
            {
                return;
            }
            this.Close();          
        }

        private void tvItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            tvItems.PathSeparator = ">";
            lblCurrentTvPath.Text = tvItems.SelectedNode.FullPath;
            if (this.TreeEntityId.Length > 0)
            {
                this.GetItemsDetailList();
            }
        }

        private int DeleteItems()
        {
            var returnValue = 0;
            if (string.IsNullOrEmpty(this.TreeEntityId))
            {
                return returnValue;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (!BasePageLogic.NodeAllowDelete(this.tvItems.SelectedNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvItems.SelectedNode.Text));
            }
            else
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    returnValue = RDIFrameworkService.Instance.ItemsService.SetDeleted(UserInfo, new string[] { this.TreeEntityId });
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags = { ((DataRow)this.tvItems.SelectedNode.Tag)[CiItemsTable.FieldId].ToString() };
                        BasePageLogic.BatchRemoveNode(this.tvItems, tags);
                    }
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }

        /// <summary>
        /// 删除字典明细
        /// </summary>
        private void DeleteItemDetals()
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return ;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var returnValue = RDIFrameworkService.Instance.ItemDetailsService.SetDeleted(this.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiItemDetailsTable.FieldId, "colSelected", true));
                    if (returnValue > 0)
                    {
                        if (SystemInfo.ShowSuccessMsg)
                        {
                            MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077, returnValue.ToString()));
                            this.GetItemsDetailList();
                        }
                    }
                    else
                    {
                        MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG3020);
                    }
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
            }
        }
    }
}
