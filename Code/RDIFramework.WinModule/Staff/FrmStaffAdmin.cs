using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using grproLib;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmStaffAdmin
    /// 员工综合管理界面
    /// 
    /// 修改记录
    ///     
    ///     2014-05-29 EricHu V2.8 增加未设置部门的员工数据的显示。
    ///     2014-03-10 EricHu V2.8 新增打印功能。
    ///     2012-07-22 EricHu 创建FrmStaffAdmin。
    /// </summary>
    public partial class FrmStaffAdmin : BaseForm
    {
        IStaffService staffService           = RDIFrameworkService.Instance.StaffService;
        private DataTable DTOrganize         = new DataTable(PiOrganizeTable.TableName); // 组织机构 DataTable
        DataTable dtStaffList                = new DataTable(PiStaffTable.TableName);

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
        /// 打印
        /// </summary>
        private bool permissionPrint = false;
        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        #endregion

        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private Control LastControl = null;

        private string parentEntityId = string.Empty;
        /// <summary>
        /// 导航栏机构主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                this.parentEntityId = (this.tvOrganize.SelectedNode != null) &&
                                      (this.tvOrganize.SelectedNode.Tag != null)
                    ? ((DataRow) this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString()
                    : string.Empty;
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
        /// 表格中的员工主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiOrganizeTable.FieldId);
            }
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnMoveTo.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = false;
            // 检查添加权限
            this.btnAdd.Enabled = this.permissionAdd;
            if ((this.dtStaffList.DefaultView.Count >= 1) || (this.tvOrganize.Nodes.Count > 0))
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnMoveTo.Enabled = this.permissionMove;
                this.btnDelete.Enabled = this.permissionDelete;
                
                if (this.dtStaffList.DefaultView.Count >= 1)
                {
                    this.btnExport.Enabled = this.permissionExport;
                    this.btnPrint.Enabled = this.permissionPrint;
                }
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.btnExport.Enabled = this.permissionExport;
                    this.btnPrint.Enabled = this.permissionPrint;
                }
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("StaffAdmin");
            this.permissionAdd    = this.IsAuthorized("StaffAdmin.Add");
            this.permissionEdit   = this.IsAuthorized("StaffAdmin.Edit");
            this.permissionMove   = this.IsAuthorized("StaffAdmin.Move");
            this.permissionDelete = this.IsAuthorized("StaffAdmin.Delete");
            this.permissionExport = this.IsAuthorized("StaffAdmin.Export");
            this.permissionPrint = this.IsAuthorized("StaffAdmin.Print");
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的部门主键数组
        /// <summary>
        /// 获得已被选择的部门主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            dgvInfo.EndEdit();
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiOrganizeTable.FieldId, "colSelected", true);
        }
        #endregion

        public FrmStaffAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
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
                this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);//organizationService.GetDT(this.UserInfo);
                if (!this.UserInfo.IsAdministrator)
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
                // 获得员工列表
                this.GetStaffList();
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void GetStaffList() 获得员工列表
        /// <summary>
        /// 获得员工列表
        /// </summary>
        private void GetStaffList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            this.dtStaffList = this.chkNotDepartment.Checked ? staffService.GetDTNotOrganize(base.UserInfo) : staffService.GetDTByOrganize(base.UserInfo, this.ParentEntityId, true);
           
            // 只显示有效的用户
            if (this.chkEnabled.Checked)
            {
                BusinessLogic.SetFilter(this.dtStaffList, PiStaffTable.FieldEnabled, "1");
            }

            //只显示未离职的
            if (this.chkIsDimission.Checked)
            {
                BusinessLogic.SetFilter(this.dtStaffList, PiStaffTable.FieldIsDimission, "0");
            }


            if (this.ParentEntityId.Length > 0)
            {
                this.dtStaffList.DefaultView.Sort = PiStaffTable.FieldSortCode;
                this.dgvInfo.AutoGenerateColumns = false;
                this.dgvInfo.DataSource = this.dtStaffList.DefaultView;
                this.AddCheckBoxColumn(dgvInfo);
            }
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

        private void tvOrganize_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.ToolTipText)) return;
            
            e.Node.Nodes.Clear();
            LoadTreeOrganize(e.Node);
            e.Node.ToolTipText = e.Node.Text;
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            this.LastControl = this.tvOrganize;
            if (this.ActiveControl == this.tvOrganize)
            {
                this.parentEntityId = ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString();
                if (this.tvOrganize.SelectedNode != null)
                {
                    tvOrganize.PathSeparator = ">";
                    lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
                    this.GetStaffList();
                }
            }
        }

        #region public string AddStaff() 添加员工
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns>主键</returns>
        public string AddStaff()
        {
            string returnValue = string.Empty;
            string organizeId = string.Empty;

            var treeNode = this.tvOrganize.SelectedNode;
            if (treeNode != null)
            {
                organizeId = treeNode.Tag is DataRow
                    ? (treeNode.Tag as DataRow)[PiOrganizeTable.FieldId].ToString()
                    : (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            }

            var frmStaffAdd = new FrmStaffAdd(organizeId)
            {
                CurrentOrganizeId = organizeId,
                CurrentOrganizePath = this.tvOrganize.SelectedNode.FullPath
            };
            
            if (frmStaffAdd.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmStaffAdd.EntityId;
                this.GetStaffList();
            }
            return returnValue;
        }
        #endregion

        #region public string EditStaff() 编辑员工
        /// <summary>
        /// 编辑员工
        /// </summary>
        /// <returns>主键</returns>
        public string EditStaff(string staffId)
        {
            string returnValue = string.Empty;
            string organizeId = string.Empty;

            var treeNode = this.tvOrganize.SelectedNode;
            if (treeNode != null)
            {
                organizeId = treeNode.Tag is DataRow
                    ? (treeNode.Tag as DataRow)[PiOrganizeTable.FieldId].ToString()
                    : (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            }

            var frmStaffEdit = new FrmStaffEdit(staffId)
            {
                CurrentOrganizeId = organizeId,
                CurrentOrganizePath = this.tvOrganize.SelectedNode.FullPath
            };
            if (frmStaffEdit.ShowDialog(this) == DialogResult.OK)
            {
                returnValue = frmStaffEdit.EntityId;
                this.GetStaffList();
            }
            return returnValue;
        }
        #endregion

        #region private bool CheckInputMove(string selectedId) 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove(string selectedId)
        {
            bool returnValue = true;
            // 单个移动检查
            BasePageLogic.FindTreeNode(this.tvOrganize, this.parentEntityId);
            var treeNode = BasePageLogic.TargetNode;
            BasePageLogic.FindTreeNode(this.tvOrganize, selectedId);
            var targetTreeNode = BasePageLogic.TargetNode;
            if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text));
                returnValue = false;
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
            // 用反射获得窗体
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.ParentEntityId))
            {
                ((FrmOrganizeSelect)frmOrganizeSelect).OpenId = this.ParentEntityId;
            }
            ((FrmOrganizeSelect)frmOrganizeSelect).AllowNull = false;
            ((FrmOrganizeSelect)frmOrganizeSelect).PermissionScopeCode = "OrganizeAdmin";
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    // 调用事件
                    RDIFrameworkService.Instance.StaffService.BatchMoveTo(UserInfo, this.GetSelecteIds(), ((FrmOrganizeSelect)frmOrganizeSelect).SelectedId);
                    // 绑定屏幕数据
                    this.GetStaffList();
                    this.FormLoaded = true;
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

        #region private void SingleMove() 单个记录移动
        /// <summary>
        /// 单个记录移动
        /// </summary>
        public void SingleMove(string currentEntityId)
        {
            // 用反射获得窗体
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmOrganizeSelect";
            Form frmOrganizeSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            if (!String.IsNullOrEmpty(this.ParentEntityId))
            {
                ((FrmOrganizeSelect)frmOrganizeSelect).OpenId = this.ParentEntityId;
            }
            ((FrmOrganizeSelect)frmOrganizeSelect).AllowNull = false;
            ((FrmOrganizeSelect)frmOrganizeSelect).PermissionScopeCode = "OrganizeAdmin";
            ((FrmOrganizeSelect)frmOrganizeSelect).OnButtonConfirmClick += new BusinessLogic.CheckMoveEventHandler(CheckInputMove);
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                // 调用事件
                RDIFrameworkService.Instance.StaffService.MoveTo(UserInfo, currentEntityId, ((FrmOrganizeSelect)frmOrganizeSelect).SelectedId);
                // 绑定屏幕数据
                this.BindData(true);
                this.FormLoaded = true;
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }
        #endregion

        #region private void MoveObject() 移动数据
        /// <summary>
        /// 移动数据
        /// </summary>
        private void MoveObject()
        {
            if (this.LastControl == this.dgvInfo && BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected"))
            {
                this.BatchMove();
            }

            if (this.LastControl == this.tvOrganize && this.parentEntityId.Length > 0)
            {
                this.SingleMove(this.CurrentEntityId);
            }
        }

        #endregion

        #region private bool CheckInputBatchDelete() 检查输入的有效性
        /// <summary>
        /// 检查删除选择项的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInputBatchDelete()
        {
            bool returnValue = false;
            
            foreach (DataRow dataRow in from DataGridViewRow dgvRow in dgvInfo.Rows 
                                        let dataRowView = dgvRow.DataBoundItem as DataRowView where dataRowView != null 
                                        let dataRow = dataRowView.Row where dataRow.RowState != DataRowState.Deleted && (System.Boolean) (dgvRow.Cells["colSelected"].Value ?? false) 
                                        select dataRow)
            {
                // 有记录被选中了
                returnValue = true;
                // break;
                // 是否有子节点
                string id = string.Empty;
                if (string.IsNullOrEmpty(dataRow[PiStaffTable.FieldUserId].ToString()))
                {
                    id = dataRow[PiStaffTable.FieldUserId].ToString();
                }

                if (id == UserInfo.Id)
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0226);
                    returnValue = false;
                    return returnValue;
                }
            }

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
            this.FormLoaded = false;
            returnValue = RDIFrameworkService.Instance.StaffService.SetDeleted(UserInfo, this.GetSelecteIds());
            // 绑定数据
            this.GetStaffList();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        #region private int SingleDelete() 单个记录删除
        /// <summary>
        /// 单个记录删除
        /// </summary>
        /// <returns>影响行数</returns>
        private int SingleDelete()
        {
            var returnValue = 0;
            this.FormLoaded = false;
            returnValue = RDIFrameworkService.Instance.OrganizeService.SetDeleted(UserInfo, new string[] { this.ParentEntityId });
            ClientCache.Instance.DTOrganize = null;
            // 获取部门数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            // 清除当前记录
            this.ParentEntityId = string.Empty;
            // 绑定数据
            this.BindData(true);
            this.FormLoaded = true;
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
            if (this.LastControl == this.dgvInfo &&
                MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    returnValue = this.BatchDelete();
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

            //
            // TODO: 此处暂时禁止删除组织机构
            //
            /*if (this.LastControl == this.tvOrganize)
            {
                if (!BasePageLogic.NodeAllowDelete(this.tvOrganize.SelectedNode))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0035, this.tvOrganize.SelectedNode.Text));
                }
                else
                {
                    if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                    {
                        // 设置鼠标繁忙状态，并保留原先的状态
                        Cursor holdCursor = this.Cursor;
                        this.Cursor = Cursors.WaitCursor;
                        try
                        {
                            returnValue = this.SingleDelete();
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
            }*/
            return returnValue;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 添加员工
            this.AddStaff();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (dgvInfo.CurrentCell != null && dgvInfo.Rows.Count > 0)
            //{ 
            //    //编辑员工
            //    this.EditStaff(BasePageLogic.GetDataGridViewEntityId(dgvInfo,PiStaffTable.FieldId));
            //}

            //编辑员工
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiStaffTable.FieldId);
            if (!string.IsNullOrEmpty(tmpId))
            {
                this.EditStaff(tmpId);
            }
        }

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            // 移动数据
            this.MoveObject();
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            this.LastControl = dgvInfo;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckInputBatchDelete())
            {
                // 删除数据
                this.Delete();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            this.Close();    
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dtStaffList == null || this.dtStaffList.Rows.Count <= 0)
            {
                MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG9956);
                return;
            }

            var dtHeaderText = new Dictionary<string, string>
            {
                {"ID", "主键"},
                {"CODE", "编号"},
                {"REALNAME", "姓名"},
                {"GENDER", "性別"},
                {"MOBILE", "手机号码"},
                {"OFFICEPHONE", "办公电话"},
                {"OFFICEADDRESS", "办公地址"},
                {"EMAIL", "邮箱"},
                {"EDUCATION", "教育程度"},
                {"JOININDATE", "加入公司时间"},
                {"DESCRIPTION", "描述"}
            };
            string filename = this.Text;
            string savePath = SystemInfo.StartupPath + @"\Modules\Export\" + this.Text + ".xls";
            if (MessageBoxHelper.Show("确定导出当前所显示的数据到：" + savePath) == DialogResult.Yes)
            {
                try
                {
                    NPOIHelper.ExportByWinform(dtStaffList, dtHeaderText, savePath);
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG3010);
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dtStaffList == null || this.dtStaffList.Rows.Count <= 0)
            {
                MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG9956);
                return;
            }

            var reportUtil = new GrdReportUtil(new GridppReport());
            reportUtil.LoadReportFromFile(SystemInfo.StartupPath + @"\Report\report_StaffInfo.grf");
            reportUtil.DTReport = this.dtStaffList;
            reportUtil.FillRecordSetByDT();
            reportUtil.PrintPreview(true);
        }

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.SetControlState();
        }

        private void chkIsDimission_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStaffList();
        }

        private void chkNotDepartment_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStaffList();
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
                this.dtStaffList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.dtStaffList.Columns.Count <= 1) return;
                
                string rowFilter = string.Empty;
                search = StringHelper.GetSearchString(search);
                rowFilter = rbCustomerLikeSearch.Checked
                    ? StringHelper.GetLike(PiStaffTable.FieldCode, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldRealName, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldGender, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldMobile, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldOfficePhone, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldEmail, search)
                      + " OR " + StringHelper.GetLike(PiStaffTable.FieldDescription, search)
                    : StringHelper.GetEqual(PiStaffTable.FieldCode, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldRealName, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldGender, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldMobile, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldOfficePhone, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldEmail, search)
                      + " OR " + StringHelper.GetEqual(PiStaffTable.FieldDescription, search);
                this.dtStaffList.DefaultView.RowFilter = rowFilter;
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRowFilter();
        }
    }
}
