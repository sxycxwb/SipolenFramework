/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 10:53:34
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
    /// FrmModuleAdmin
    /// 模块综合管理窗体
    /// 
    /// 修改记录
    ///     
    ///     2012-10-24 EricHu 新增组织机构模块权限。
    ///     2012-05-16 EricHu 新增排序功能的实现。
    ///     2012-04-17 EricHu 创建模块综合管理（FrmModuleAdmin）。
    ///     2012-05-15 EricHu 启用对分级授权（范围授权）的支持。
    /// </summary>
    public partial class FrmModuleAdmin : BaseForm
    {
        IModuleService moduleService            = RDIFrameworkService.Instance.ModuleService;

        public event SetControlStateEventHandler OnButtonStateChange;

        /// <summary>
        /// 模块 DataTable
        /// </summary>
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);
        
        /// <summary>
        /// 模块列表 DataTable
        /// </summary>
        private DataTable DTModuleList = new DataTable(PiModuleTable.TableName);

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private Control LastControl = null;

        private string moduleList = string.Empty;


        /// <summary>
        /// 移动功能选择窗口
        /// </summary>
        FrmModuleSelect frmModuleSelect = null;

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
        /// 本模块的角色模块权限
        /// </summary>
        private bool permissionRoleModulePermission = false;

        /// <summary>
        /// 本模块的用户模块权限
        /// </summary>
        private bool permissionUserModulePermission = false;

        /// <summary>
        /// 本模块的模块配置权限
        /// </summary>
        private bool permissionModuleConfig = false;

        /// <summary>
        /// 模块关联操作权限项
        /// </summary>
        private bool permissionModulePermissionItem = false;

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        private string parentEntityId = string.Empty;
        /// <summary>
        /// 导航栏主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                this.parentEntityId = (this.tvModule.SelectedNode != null) && (this.tvModule.SelectedNode.Tag != null)
                    ? ((DataRow) this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString()
                    : string.Empty;
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 列表中的主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiModuleTable.FieldId);
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
                this.currentEntityId = this.LastControl == this.tvModule ? this.ParentEntityId : this.EntityId;
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }
        
        public FrmModuleAdmin()
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
            this.btnDelete.Enabled               = false;
            this.btnEdit.Enabled                 = false;
            this.btnMoveTo.Enabled               = false;
            this.btnExport.Enabled               = false;
            this.btnRoleModulePermission.Enabled = false;
            this.btnUserModulePermission.Enabled = false;
            this.btnModuleConfig.Enabled         = false;
            this.btnExport.Enabled               = false;
            this.btnModulePermissionItem.Enabled = false;
            this.ddbModulePermissionSet.Visible  = SystemInfo.EnableModulePermission;
            this.btnUserModulePermission.Visible = SystemInfo.EnableUserAuthorization && SystemInfo.EnableModulePermission;
            this.btnRoleModulePermission.Visible = SystemInfo.EnableModulePermission;
            this.btnOrganizeModulePermission.Visible = SystemInfo.EnableOrganizePermission && SystemInfo.EnableModulePermission;

            // 检查添加组织机构
            this.btnAdd.Enabled = this.permissionAdd;
            if (this.DTModuleList.DefaultView.Count >= 1)
            {
                this.btnEdit.Enabled    = this.permissionEdit;
                this.btnMoveTo.Enabled  = this.permissionEdit;
                this.btnDelete.Enabled  = this.permissionDelete;
                this.btnExport.Enabled  = this.permissionExport;
                this.SetSortButton(this.permissionEdit);
            }

            if (this.tvModule.Nodes.Count > 0)
            {
                this.btnEdit.Enabled    = this.permissionEdit;
                this.btnMoveTo.Enabled  = this.permissionEdit;
                this.btnDelete.Enabled  = this.permissionDelete;

                this.btnRoleModulePermission.Enabled = this.permissionRoleModulePermission;
                this.btnUserModulePermission.Enabled = this.permissionUserModulePermission;
                this.btnModuleConfig.Enabled         = this.permissionModuleConfig;
                this.btnModulePermissionItem.Enabled = this.permissionModulePermissionItem;
                this.btnExport.Enabled               = this.permissionExport;
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
        }
        #endregion

        public void SetSortButton(bool enabled)
        {
            this.ucSortControl.SetSortButton(enabled);
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.IsModuleAuthorized("ModuleManagement");
            this.permissionAdd                      = this.IsAuthorized("ModuleManagement.Add");
            this.permissionEdit                     = this.IsAuthorized("ModuleManagement.Edit");
            this.permissionDelete                   = this.IsAuthorized("ModuleManagement.Delete");
            this.permissionExport                   = this.IsAuthorized("ModuleManagement.Export");
            this.IsAuthorized("UserManagement.Accredit");
            this.permissionUserModulePermission     = this.IsAuthorized("ModuleManagement.UserModulePermission");
            this.permissionRoleModulePermission     = this.IsAuthorized("ModuleManagement.RoleModulePermission");
            //this.IsAuthorized("ModuleManagement.OrganizeModulePermission") && SystemInfo.EnableOrganizePermission;
            this.permissionModuleConfig             = this.IsAuthorized("ModuleManagement.ModuleConfig");
            this.permissionModulePermissionItem     = this.IsAuthorized("ModuleAdmin.ModulePermissionItem");
        }
        #endregion

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
                if (this.tvModule.SelectedNode == null)
                {
                    if (this.tvModule.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                        }
                        else
                        {
                            BasePageLogic.FindTreeNode(this.tvModule, this.parentEntityId);
                            if (BasePageLogic.TargetNode != null)
                            {
                                this.tvModule.SelectedNode = BasePageLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BasePageLogic.ExpandTreeNode(this.tvModule);
                            }
                        }
                        if (this.tvModule.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvModule.SelectedNode.Expand();
                            this.tvModule.SelectedNode.EnsureVisible();
                        }
                    }
                }

            }
            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    this.GetModuleList();
                }
            }
            // 判断编辑权限
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.dgvInfo.Columns["colSelected"].ReadOnly = !this.permissionEdit;
                this.dgvInfo.Columns["colFullName"].ReadOnly = !this.permissionEdit;
                this.dgvInfo.Columns["colDescription"].ReadOnly = !this.permissionEdit;
                // 修改背景颜色
                //this.dgvInfo.Columns["colFullName"].DefaultCellStyle.BackColor = Color.White;
                //this.dgvInfo.Columns["colDescription"].DefaultCellStyle.BackColor = Color.White;
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
            btnOrganizeModulePermission.Visible = SystemInfo.EnableOrganizePermission;            
            // 获取模块列表
            this.DTModule = this.GetModuleScope(this.PermissionItemScopeCode);
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        #region private void GetModuleList() 获得子模块列表
        /// <summary>
        /// 获得子模块列表
        /// </summary>
        private void GetModuleList()
        {
            //if (!reloadTree && !this.FormLoaded)
            //{
            //    return;
            //}
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.DTModuleList = moduleService.GetDTByParent(UserInfo, this.ParentEntityId);
                //this.DataTableAddColumn();
                this.dgvInfo.AutoGenerateColumns = false;
                this.DTModuleList.DefaultView.Sort = PiModuleTable.FieldSortCode;
                this.dgvInfo.DataSource = this.DTModuleList.DefaultView;
                // 设置排序按钮
                this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
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

        #region private void LoadTree() 加载模块树的主键
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            var treeNode = new TreeNode();   
            this.LoadTreeModule(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode) 加载模块树的主键
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            if ((SystemInfo.EnableUserAuthorizationScope) && !UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId, PiModuleTable.FieldFullName, this.tvModule, treeNode);
        }
        #endregion

        #region private void ModuleSetPermission() 模块权限设置
        /// <summary>
        /// 模块权限设置
        /// </summary>
        private void ModulePermissionSet()
        {
            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmModulePermissionItemBatchSet";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmModulePermissionBatchSet = (Form)Activator.CreateInstance(assemblyType);
            frmModulePermissionBatchSet.ShowDialog(this);
        }
        #endregion

        #region private void SetAccessPermission() 权限资源访问设置
        /// <summary>
        /// 权限资源访问设置
        /// </summary>
        private void SetAccessPermission()
        {
            var targetResourceCategory = PiModuleTable.TableName;
            var targetResourceId = ((DataRow)this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString();
            var targetResourceName = this.tvModule.SelectedNode.Text;
            const string permissionItemCode = "Resource.AccessPermission";
            if (string.IsNullOrEmpty(targetResourceId)) return;
            const string assemblyName = "DotNet.WinForm";
            const string formName = "FrmResourceSetPermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmResourceSetPermission = (Form)Activator.CreateInstance(assemblyType, targetResourceCategory, targetResourceId, targetResourceName, permissionItemCode);
            frmResourceSetPermission.ShowDialog(this);
        }
        #endregion

        private void GetTreeSort(TreeNode treeNode)
        {
            moduleList += (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString() + ",";
            for (var i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeSort(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetTreeSort() 获得树型机构的排序顺序
        /// <summary>
        /// 获得树型机构的排序顺序
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetTreeSort()
        {
            var ids = new string[0];
            if (!UserInfo.IsAdministrator) return ids;

            this.moduleList = string.Empty;
            for (var i = 0; i < this.tvModule.Nodes.Count; i++)
            {
                this.GetTreeSort(this.tvModule.Nodes[i]);
            }
            if (this.moduleList.Length <= 0) return ids;
            this.moduleList = this.moduleList.Substring(0, this.moduleList.Length - 1);
            ids = this.moduleList.Split(',');
            return ids;
        }
        #endregion

        #region public string Add(bool root) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>主键</returns>
        public string Add()
        {
            string returnValue = string.Empty;
            FrmModuleEdit frmModuleEdit;

            if (this.LastControl == this.tvModule)
            {
                frmModuleEdit = new FrmModuleEdit {ParentId = this.ParentEntityId};

                //if (this.ParentEntityId.Length == 0 || this.tvModule.SelectedNode == null)
                //{
                //    frmModuleEdit = new FrmModuleEdit();
                //}
                //else
                //{
                //    //frmModuleEdit = new FrmModuleEdit(this.ParentEntityId, this.tvModule.SelectedNode.Text);
                //    frmModuleEdit = new FrmModuleEdit(this.EntityId);
                //}
            }
            else
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                frmModuleEdit = new FrmModuleEdit();
                frmModuleEdit.ParentId = dataRow[PiModuleTable.FieldId].ToString();

                //if (dataRow == null)
                //{
                //    frmModuleEdit = new FrmModuleEdit();
                //}
                //else
                //{
                //    //frmModuleEdit = new FrmModuleEdit(dataRow[PiModuleTable.FieldId].ToString(), dataRow[PiModuleTable.FieldFullName].ToString());
                //    frmModuleEdit = new FrmModuleEdit(dataRow[PiModuleTable.FieldId].ToString());
                //}
            }

            if ((frmModuleEdit.ShowDialog(this) != DialogResult.OK) && !frmModuleEdit.Changed) return returnValue;

            returnValue = frmModuleEdit.EntityId;
            string fullName = frmModuleEdit.FullName;
            string parentId = frmModuleEdit.ParentId;
            // tvModule 中增加结点
            var newNode = new TreeNode
            {
                Text = fullName,
                Tag =
                    RDIFrameworkService.Instance.ModuleService.GetDTByIds(UserInfo, new string[] {returnValue}).Rows[0]
            };

            TreeNode parentNode = null;
            if (!string.IsNullOrEmpty(parentId))
            {
                BasePageLogic.FindTreeNode(this.tvModule, parentId);
                parentNode = BasePageLogic.TargetNode;
            }
            BasePageLogic.AddTreeNode(this.tvModule, newNode, parentNode);
            // 绑定dgvInfo
            this.GetModuleList();
            // 使新增加的数据在dgvInfo中可见
            if (this.DTModuleList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
            return returnValue;
        }
        #endregion

        #region private void EditTree() 编辑树节点
        /// <summary>
        /// 编辑树节点
        /// </summary>
        private void EditTree()
        {
            if (this.tvModule.SelectedNode == null)
            {
                return;
            }
            var frmModuleEdit = new FrmModuleEdit(((DataRow)this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString());
            if (frmModuleEdit.ShowDialog(this) != DialogResult.OK) return;
            // 编辑节点
            this.tvModule.SelectedNode.Text = frmModuleEdit.FullName;
            // 绑定dgvInfo
            this.GetModuleList();
            if (this.DTModuleList.Rows.Count > 0)
            {
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
            }
        }
        #endregion

        #region private void EditGrid() 编辑模块
        /// <summary>
        /// 编辑模块
        /// </summary>
        private void EditGrid()
        {
            if (this.dgvInfo.RowCount == 0)
            {
                // 提高用户体验，如果grdPermission没有数据则修改tvPermissiion 中的selectedNode
                this.LastControl = this.tvModule;
                return;
            }
            //var frmModuleEdit = new FrmModuleEdit(this.EntityId);
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiModuleTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmModuleEdit = new FrmModuleEdit(tmpId);
            if (frmModuleEdit.ShowDialog(this) != DialogResult.OK) return;

            BasePageLogic.FindTreeNode(this.tvModule, tmpId);
            var selectNode = BasePageLogic.TargetNode;
            selectNode.Text = frmModuleEdit.FullName;
            var oldParentNode = selectNode.Parent;

            BasePageLogic.FindTreeNode(this.tvModule, frmModuleEdit.ParentId);
            var parentNode = BasePageLogic.TargetNode;
            // 编辑节点
            BasePageLogic.EditTreeNode(this.tvModule, selectNode, parentNode);
            // 绑定dgvInfo
            this.GetModuleList();
            if (this.DTModuleList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
        }
        #endregion

        #region public void Edit() 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        public void Edit()
        {
            // 编辑模块
            if (this.LastControl == this.dgvInfo)
            {
                this.EditGrid();
            }
            if (this.LastControl == this.tvModule)
            {
                this.EditTree();
            }
        }
        #endregion

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            bool returnValue = true;
            // 单个移动检查
            if (this.LastControl == this.tvModule)
            {
                BasePageLogic.FindTreeNode(this.tvModule, this.parentEntityId);
                var treeNode = BasePageLogic.TargetNode;
                BasePageLogic.FindTreeNode(this.tvModule, frmModuleSelect.SelectedId);
                var targetTN = BasePageLogic.TargetNode;
                if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTN))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTN.Text));
                    returnValue = false;
                }
            }
            // 进行批量检查
            if (this.LastControl != this.dgvInfo) return returnValue;
            
            BasePageLogic.FindTreeNode(this.tvModule, frmModuleSelect.SelectedId);
            var targetTreeNode = BasePageLogic.TargetNode;
            var SelecteIds = this.GetSelecteIds();
            foreach (string temId in SelecteIds)
            {
                BasePageLogic.FindTreeNode(this.tvModule, temId);
                var treeNode = BasePageLogic.TargetNode;
                if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text));
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
            
            frmModuleSelect = new FrmModuleSelect(this.ParentEntityId) {AllowNull = true};
            frmModuleSelect.OnButtonConfirmClick += new FrmModuleSelect.ButtonConfirmEventHandler(CheckInputMove);
            if (frmModuleSelect.ShowDialog() != DialogResult.OK) return;
            
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.ParentEntityId = frmModuleSelect.SelectedId;
            // 调用事件
            var tags = this.GetSelecteIds();
            moduleService.BatchMoveTo(UserInfo, tags, frmModuleSelect.SelectedId);
            // 移动treeNode
            BasePageLogic.FindTreeNode(this.tvModule, frmModuleSelect.SelectedId);
            var parentNode = BasePageLogic.TargetNode;
            if (tags.Length > 0)
            {
                foreach (string tmpTag in tags)
                {
                    BasePageLogic.FindTreeNode(this.tvModule, tmpTag);
                    BasePageLogic.MoveTreeNode(this.tvModule, BasePageLogic.TargetNode, parentNode);
                }
            }
            // 绑定dgvInfo
            this.GetModuleList();
            if (this.DTModuleList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        private void SingleMove()
        {
            if (String.IsNullOrEmpty(this.ParentEntityId))
            {
                return;
            }

            frmModuleSelect = new FrmModuleSelect(this.ParentEntityId) {AllowNull = true};
            frmModuleSelect.OnButtonConfirmClick += new FrmModuleSelect.ButtonConfirmEventHandler(this.CheckInputMove);
            if (frmModuleSelect.ShowDialog() != DialogResult.OK) return;
            
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 调用事件
            moduleService.MoveTo(UserInfo, this.CurrentEntityId, frmModuleSelect.SelectedId);
            // 移动treeNode
            BasePageLogic.FindTreeNode(this.tvModule, frmModuleSelect.SelectedId);
            BasePageLogic.MoveTreeNode(this.tvModule, this.tvModule.SelectedNode, BasePageLogic.TargetNode);
            // 绑定dgvInfo
            this.GetModuleList();
            if (this.DTModuleList.Rows.Count > 0)
                this.dgvInfo.FirstDisplayedScrollingRowIndex = this.DTModuleList.Rows.Count - 1;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
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
            if (this.LastControl == this.tvModule)
            {
                this.SingleMove();
            }
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的模块主键数组
        /// <summary>
        /// 获得已被选择的模块主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiModuleTable.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            var returnValue = false;
            var moduleEntity = new PiModuleEntity();

            foreach (DataRow dataRow in from DataGridViewRow dgvRow 
                    in dgvInfo.Rows let dataRow = (dgvRow.DataBoundItem as DataRowView).Row 
                    where dataRow.RowState != DataRowState.Deleted 
                    where (System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false) select dataRow)
            {
                // 是否允许删除
                moduleEntity.GetFrom(dataRow);
                if (moduleEntity.AllowDelete == 0)
                {
                    returnValue = false;
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, moduleEntity.FullName));
                    return returnValue;
                }
                else
                {
                    returnValue = true;
                    // 是否有子节点
                    string id = dataRow[PiModuleTable.FieldId].ToString();
                    BasePageLogic.FindTreeNode(this.tvModule, id);
                    if (BasePageLogic.TargetNode != null)
                    {
                        if (!BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
                        {
                            MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text));
                            returnValue = false;
                        }
                    }
                    return returnValue;
                }
            }

            //优化前代码
            //foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            //{
            //    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
            //    if (dataRow.RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
            //    {
            //        // 是否允许删除
            //        moduleEntity.GetFrom(dataRow);
            //        if (moduleEntity.AllowDelete == 0)
            //        {
            //            returnValue = false;
            //            MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0018, moduleEntity.FullName));
            //            return returnValue;
            //        }
            //        else
            //        {
            //            returnValue = true;
            //            // 是否有子节点
            //            string id = dataRow[PiModuleTable.FieldId].ToString();
            //            BasePageLogic.FindTreeNode(this.tvModule, id);
            //            if (BasePageLogic.TargetNode != null)
            //            {
            //                if (!BasePageLogic.NodeAllowDelete(BasePageLogic.TargetNode))
            //                {
            //                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, BasePageLogic.TargetNode.Text));
            //                    returnValue = false;
            //                }
            //            }
            //            return returnValue;
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

        #region public override int BatchDelete() 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>影响行数</returns>
        public override int BatchDelete()
        {
            var returnValue = 0;
            if (!this.CheckInputBatchDelete()) return returnValue;
            
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
            {
                // 删除选中的纪录
                // returnValue = RDIFrameworkService.Instance.ModuleService.BatchDelete(UserInfo, this.GetSelecteIds());
                var tags = this.GetSelecteIds();
                returnValue = moduleService.SetDeleted(UserInfo, tags);
                // 获取模块列表
                this.DTModule = moduleService.GetDT(UserInfo);
                // 在tree删除相应的节点
                BasePageLogic.BatchRemoveNode(this.tvModule, tags);
                // 绑定dgvInfo
                this.GetModuleList();
            }
            return returnValue;
        }
        #endregion

        #region private void SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        private int SingleDelete()
        {
            var returnValue = 0;
            if (this.tvModule.SelectedNode == null)
            {
                return returnValue;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (!BasePageLogic.NodeAllowDelete(this.tvModule.SelectedNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvModule.SelectedNode.Text));
            }
            else
            {
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    returnValue = moduleService.SetDeleted(UserInfo, new string[] { this.ParentEntityId });
                    // 有数据被删除了？
                    if (returnValue > 0)
                    {
                        string[] tags = {((DataRow)this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString()};
                        BasePageLogic.BatchRemoveNode(this.tvModule, tags);
                        // 绑定dgvInfo
                        this.GetModuleList();
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
        /// <returns>影响行数</returns>
        public int Delete()
        {
            var returnValue = 0;
            if (this.LastControl == this.dgvInfo)
            {
                // 检查批量输入的有效性
                if (BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected"))
                {
                    returnValue = this.BatchDelete();
                }
            }

            if (this.LastControl == this.tvModule)
            {
                returnValue = this.SingleDelete();
            }
            return returnValue;
        }
        #endregion

        #region private bool CheckInputBatchSave() 检查批量输入的有效性
        /// <summary>
        /// 检查批量输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchSave()
        {
            var selectedCount = 0;
            var returnValue = false;
            var moduleEntity = new PiModuleEntity();
            foreach (DataRow dataRow in this.DTModuleList.Rows)
            {
                // 这里判断数据的各种状态
                if (dataRow.RowState == DataRowState.Modified)
                {
                    // 是否允许编辑
                    moduleEntity.GetFrom(dataRow);
                    if (moduleEntity.AllowEdit == 0)
                    {
                        if ((dataRow[PiModuleTable.FieldFullName, DataRowVersion.Original] != dataRow[PiModuleTable.FieldFullName, DataRowVersion.Current]) || (dataRow[PiModuleTable.FieldDescription, DataRowVersion.Original] != dataRow[PiModuleTable.FieldDescription, DataRowVersion.Current]))
                        {
                            returnValue = false;
                            MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0020, RDIFrameworkMessage.MSG9978));
                            // 这里需要直接返回了，不再进行输入交验了。
                            return returnValue;
                        }
                    }
                    selectedCount++;
                }
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    selectedCount++;
                }
            }
            // 有记录被选中了
            returnValue = selectedCount > 0;
            if (!returnValue)
            {
                MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0004);
            }
            return returnValue;
        }
        #endregion

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            moduleService.BatchSave(UserInfo, this.DTModuleList);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0012);
            }
        }
        #endregion

        #region public void Save():保存数据
        public void Save()
        {
            // 检查批量输入的有效性
            if (this.CheckInputBatchSave())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // 批量保存
                    this.BatchSave();
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

        private void ReSet()
        {
            // 重新获取客户端的缓存模块数据
            ClientCache.Instance.DTMoule = moduleService.GetDT(UserInfo);
            ClientCache.Instance.DTUserMoule = moduleService.GetDT(UserInfo);
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加
            this.Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 编辑模块
            this.Edit();
            this.ReSet();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }     

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.ReSet();
        }

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
            this.ReSet();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvInfo, @"\Modules\Export\", exportFileName);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.FormOnLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != DialogResult.Yes)
            {
                return;
            }
            this.Close();           
        }

        private void tvModule_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvModule;
            if (this.tvModule.SelectedNode == null)
            {
                this.tvModule.ContextMenuStrip = null;
            }
        }

        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            if (this.ParentEntityId.Length > 0)
            {
                this.GetModuleList();
            }
        }

        private void tvModule_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvModule_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvModule_DragDrop(object sender, DragEventArgs e)
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
            if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode)) return;
            
            if (SystemInfo.ShowInformation)
            {
                // 是否移动模块
                if (MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0038, treeNode.Text, targetTreeNode.Text)) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            moduleService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(),(targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
            // 往目标节点中加入被拖动节点的一份克隆
            this.tvModule.SelectedNode = targetTreeNode;
            targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
            // 将被拖动的节点移除
            treeNode.Remove();
        }

        private void dgvInfo_Sorted(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.permissionEdit)
            {
                var sequence = RDIFrameworkService.Instance.SequenceService.GetBatchSequence(UserInfo, PiModuleTable.TableName, this.DTModuleList.DefaultView.Count);
                var i = 0;
                foreach (DataRowView dataRowView in this.DTModuleList.DefaultView)
                {
                    dataRowView.Row[PiModuleTable.FieldSortCode] = sequence[i];
                    i++;
                }
                // 控制导航按钮
                //this.SetSortButton(false);
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
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

        private void dgvInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int? moduleType = BusinessLogic.ConvertToNullableInt(dgvInfo.Rows[e.RowIndex].Cells["colMODULETYPE"].Value);
            if (moduleType == null) return;
            switch (moduleType)
            {
                case 1:
                    dgvInfo.Rows[e.RowIndex].Cells["colCode"].Style.BackColor = lblWinFormColor.BackColor;
                    dgvInfo.Rows[e.RowIndex].Cells["colFullName"].Style.BackColor = lblWinFormColor.BackColor;
                    break;
                case 2:
                    dgvInfo.Rows[e.RowIndex].Cells["colCode"].Style.BackColor = lblWebFormColor.BackColor;
                    dgvInfo.Rows[e.RowIndex].Cells["colFullName"].Style.BackColor = lblWebFormColor.BackColor;
                    break;
                case 3:
                    dgvInfo.Rows[e.RowIndex].Cells["colCode"].Style.BackColor = lblWinWebFormColor.BackColor;
                    dgvInfo.Rows[e.RowIndex].Cells["colFullName"].Style.BackColor = lblWinWebFormColor.BackColor;
                    break;
            }
        }   

        private void btnRoleModulePermission_Click(object sender, EventArgs e)
        {
            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmRoleModulePermissionBatchSet";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }

        private void btnUserModulePermission_Click(object sender, EventArgs e)
        {
            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmUserModulePermissionBatchSet";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmRoleModulePermission = (Form)Activator.CreateInstance(assemblyType);
            frmRoleModulePermission.ShowDialog(this);
        }


        private void btnOrganizeModulePermission_Click(object sender, EventArgs e)
        {
            // 组织机构->模块访问权限设置
            const string permissionItemCode = "Resource.ManagePermission";
            var targetResourceCategory = PiModuleTable.TableName;
            var targetResourceSQL = "SELECT " + PiModuleTable.FieldId + " AS Id, "
                                        + PiModuleTable.FieldParentId + " AS ParentId, "
                                        + PiModuleTable.FieldFullName + " AS RealName, "
                                        + PiModuleTable.FieldDescription + " AS Description FROM "
                                        + PiModuleTable.TableName
                                        + " WHERE " + PiModuleTable.FieldDeleteMark + " = 0 AND " + PiModuleTable.FieldEnabled + " = 1 ORDER BY " + PiModuleTable.FieldSortCode;

            var assemblyName = "RDIFramework.WinModule";
            var formName = "FrmOrganizeResourcePermission";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var RoleOrganizePermission = (Form)Activator.CreateInstance(assemblyType, permissionItemCode, targetResourceCategory, targetResourceSQL);
            RoleOrganizePermission.ShowDialog(this);
        }

        private void btnModuleConfig_Click(object sender, EventArgs e)
        {
            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmModuleConfig";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmUserPermissionAdmin = (Form)Activator.CreateInstance(assemblyType);
            frmUserPermissionAdmin.ShowDialog(this);
        }

        private void btnModulePermissionItem_Click(object sender, EventArgs e)
        {
            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmModulePermissionItemSet";
            var assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            var frmModulePermissionItemSet = (Form)Activator.CreateInstance(assemblyType);
            frmModulePermissionItemSet.ShowDialog(this);
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
                this.DTModuleList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTModuleList.Columns.Count <= 1) return;
                string rowFilter = string.Empty;
                search = StringHelper.GetSearchString(search);
                rowFilter = rbCustomerLikeSearch.Checked
                    ? StringHelper.GetLike(PiModuleTable.FieldCode, search)
                      + " OR " + StringHelper.GetLike(PiModuleTable.FieldFullName, search)
                      + " OR " + StringHelper.GetLike(PiModuleTable.FieldTarget, search)
                      + " OR " + StringHelper.GetLike(PiModuleTable.FieldDescription, search)
                    : StringHelper.GetEqual(PiPermissionItemTable.FieldCode, search)
                      + " OR " + StringHelper.GetEqual(PiPermissionItemTable.FieldFullName, search)
                      + " OR " + StringHelper.GetEqual(PiModuleTable.FieldTarget, search)
                      + " OR " + StringHelper.GetEqual(PiPermissionItemTable.FieldDescription, search);
                this.DTModuleList.DefaultView.RowFilter = rowFilter;
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }
    }
}
