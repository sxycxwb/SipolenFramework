/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserAdmin
    /// 用户综合管理界面
    /// 
    /// 修改记录
    ///     2015-01-22 EricHu V3.0 新增离职管理，访问日志功能 。
    ///     2015-07-18 EricHu V3.0 修改无用户数据时不能增加用户的问题。
    ///     2015-01-04 王进   V2.9 删除未使用的方法。
    ///     2014-05-06 EricHu V2.8 增加导出功能。
    ///     2014-04-26 EricHu V2.8 增加按组织机构来加载用户并以分页的形式展示，这样就可以满足大批量用户展示的请求。
    ///     2013-06-18 EricHu 版本2.5 新增对“有效”、“无效”、“全部用户”的搜索功能。
    ///     2012-05-26 EricHu 版本2.1 修改：当非用户管理员进入“用户管理”界面，提示排序字段不存在的问题。
    /// </summary>
    public partial class FrmUserAdmin : BaseForm
    {
        /// <summary>
        /// 用户管理用户数据
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName);

        /// <summary>
        /// 组织机构 DataTable
        /// </summary>
        private DataTable DTOrganizeList = new DataTable(PiOrganizeTable.TableName);

        #region 权限部分
        /// <summary>
        /// 用户管理
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 查询用户
        /// </summary>
        private bool permissionSearch = false;

        /// <summary>
        /// 添加用户
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 编辑用户
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 设置密码
        /// </summary>
        private bool permissionSetPassword = false;

        /// <summary>
        /// 导出数据
        /// </summary>
        private bool permissionExport = false;

        /// <summary>
        /// 删除用户
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 用户授权
        /// </summary>
        private bool permissionAccredit = false;

        /// <summary>
        /// 用户兼职组织
        /// </summary>
        private bool permissionUserOrganize = false;

        /// <summary>
        /// 用户离职
        /// </summary>
        private bool permissionDimission = false;
        
        /// <summary>
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";
        #endregion

        public event SetControlStateEventHandler OnButtonStateChange;

        #region public override string EntityId 用户主键
        /// <summary>
        /// 用户主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiUserTable.FieldId);
            }
        }
        #endregion

        #region public string OrganizeId 组织机构主键
        private string organizeId = string.Empty;
        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    if (this.tvOrganize.SelectedNode.Tag is DataRow)
                    {
                        this.organizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[PiOrganizeTable.FieldId].ToString();
                    }
                    else
                    {
                        this.organizeId = this.tvOrganize.SelectedNode.Tag.ToString();
                    }
                }
                else
                {
                    this.organizeId = string.Empty;
                }
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }
        #endregion

        #region public string CurrentEntityId 当前选种的Id
        /// <summary>
        /// 当前选种的ID
        /// </summary>
        private string entityId = string.Empty;
        public string CurrentEntityId
        {
            get
            {
                return this.entityId;
            }
            set
            {
                this.entityId = value;
            }
        }
        #endregion
       
        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized(this.Name);
            this.permissionAdd = this.IsAuthorized("UserManagement.Add");
            this.permissionEdit = this.IsAuthorized("UserManagement.Edit");
            this.permissionSetPassword = this.IsAuthorized("UserManagement.SetUserPassword");
            this.permissionExport = this.IsAuthorized("UserManagement.Export");
            this.permissionDelete = this.IsAuthorized("UserManagement.Delete");
            this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
            this.permissionSearch = this.IsAuthorized("UserManagement.Search");
            this.permissionUserOrganize = this.IsAuthorized("UserManagement.UserOrganize");
            this.permissionDimission = this.IsAuthorized("UserManagement.Dimission");
        }
        #endregion

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = this.permissionAdd;
            // 是否有数据的判断
            if (this.DTUser.DefaultView.Count <= 0)           
            {
                //this.btnAdd.Enabled = false;
                this.btnSetPassword.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnBatchSave.Enabled = false;
                this.ucSortControl.Enabled = false;
                this.cboEnabledSearch.Enabled = false;
                this.btnUserOrganize.Enabled = false;
                this.btnDimission.Enabled = false;
            }
            else
            {
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnSetPassword.Enabled = this.permissionSetPassword;
                this.btnBatchSave.Enabled = this.permissionEdit;
                this.btnDelete.Enabled = this.permissionDelete;
                this.btnAdd.Enabled = this.permissionAdd;
                this.ucSortControl.Enabled = this.permissionEdit;
                this.cboEnabledSearch.Enabled = this.btnFind.Enabled = this.permissionSearch;
                this.btnUserOrganize.Enabled = this.permissionUserOrganize;
                this.btnDimission.Enabled = this.permissionDimission;
            }

            // 检查委托是否为空
            if (OnButtonStateChange != null)
            {
                var setTop = this.ucSortControl.SetTopEnabled;
                var setUp = this.ucSortControl.SetUpEnabled;
                var setDown = this.ucSortControl.SetDownEnabled;
                var setBottom = this.ucSortControl.SetBottomEnabled;
                var add        = this.btnAdd.Enabled;
                var edit       = this.btnEdit.Enabled;
                var batchSave = this.btnBatchSave.Enabled;
                OnButtonStateChange(setTop, setUp, setDown, setBottom, add, edit, batchSave);
            }
        }
        #endregion

        public void SetSortButton(bool enabled)
        {
            this.ucSortControl.SetSortButton(enabled);
        }

        public FrmUserAdmin()
        {
            InitializeComponent();
        }

        #region private void BindData() 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            this.dgvInfo.AutoGenerateColumns = false;
            if (this.DTUser.Columns.Count > 0)
            {
                this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            }

            this.dgvInfo.DataSource = this.DTUser.DefaultView;
            if (this.CurrentEntityId.Length > 0)
            {
                this.dgvInfo.FirstDisplayedScrollingRowIndex = BasePageLogic.GetRowIndex(this.DTUser, PiUserTable.FieldId, this.CurrentEntityId);
            }
            // 设置排序按钮
            this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
            // 设置用户能否修改有效状态
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.dgvInfo.Columns["colEnabled"].ReadOnly = !this.permissionEdit;
            }
            this.SetControlState();
        }

        private void Search(bool? enabled)
        {
            var recordCount = 0;
            if (!string.IsNullOrEmpty(this.OrganizeId)) 
            {
                this.DTUser = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, enabled);
            }
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.BindData();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize, bool? enabled = true)
        {
            var searchValue = this.txtSearch.Text;
            return RDIFrameworkService.Instance.UserService.GetUserPageDTByDepartment(UserInfo, this.PermissionItemScopeCode, searchValue, enabled, string.Empty, null, true, true, out recordCount, pageIndex, pageSize, PiUserTable.FieldSortCode, OrganizeId);
        }
        #endregion      

        #region private void LoadTreeOrganize() 加载组织机构树
        /// <summary>
        /// 加载组织机构树
        /// </summary>
        private void LoadTreeOrganize()
        {
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            var treeNode = new TreeNode {ImageIndex = 0, SelectedImageIndex = 0};
            this.LoadTreeOrganize(treeNode);
            if (this.tvOrganize.Nodes.Count > 0)
            {
                this.tvOrganize.Nodes[0].Expand();
            }
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode, !SystemInfo.OrganizeDynamicLoading);
        }

        private void OrganzieTreeImange(TreeNode tNode, string organizeCategory)
        {
            switch (organizeCategory.ToLower())
            {
                case "compay":
                    tNode.ImageIndex = 0;
                    tNode.SelectedImageIndex = 0;
                    break;
                case "subcompay":
                    tNode.ImageIndex = 1;
                    tNode.SelectedImageIndex = 1;
                    break;
                case "department":
                    tNode.ImageIndex = 2;
                    tNode.SelectedImageIndex = 2;
                    break;
                case "subdepartment":
                    tNode.ImageIndex = 3;
                    tNode.SelectedImageIndex = 3;
                    break;
                case "workgroup":
                    tNode.ImageIndex = 4;
                    tNode.SelectedImageIndex = 4;
                    break;
                default:
                    tNode.ImageIndex = 5;
                    tNode.SelectedImageIndex = 5;
                    break;
            }
        }
        #endregion    

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            this.tvOrganize.BeginUpdate();
            this.DTOrganizeList = RDIFrameworkService.Instance.OrganizeService.GetDTByParent(UserInfo, this.OrganizeId);
            this.DTOrganizeList.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                foreach (DataRow dr in this.DTOrganizeList.Rows)
                {
                    var treeNode = new TreeNode
                    {
                        Text = dr[PiOrganizeTable.FieldFullName].ToString(),
                        Tag = dr[PiOrganizeTable.FieldId].ToString()
                    };
                    OrganzieTreeImange(treeNode, dr[PiOrganizeTable.FieldCategory].ToString());
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
            }
            this.tvOrganize.EndUpdate();
            this.tvOrganize.SelectedNode.Expand();
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad()
        private void FormOnLoad(bool loadUser, string searchValue)
        {
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);

            if (this.DTOrganize != null && this.DTOrganize.Rows.Count > 0)
            {
                this.LoadTreeOrganize();
                if (!UserInfo.IsAdministrator && SystemInfo.EnableUserAuthorizationScope &&
                    this.tvOrganize.Nodes.Count > 0)
                {
                    this.tvOrganize.SelectedNode = tvOrganize.Nodes[0];
                }

                this.Search(true);
                this.SetRowFilter();
            }
            else
            {
                cboEnabledSearch.Enabled =  btnFind.Enabled = false;
            }
        }

        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);
            // 加载窗体，检查是否配置为默认加载用户列表，就怕用户数量太多了。
            this.FormOnLoad(SystemInfo.LoadAllUser, string.Empty);
            // 若有过滤条件，要进行数据过滤
            this.SetRowFilter();       
        }
        #endregion 
       
        #region private void BindDataOldNotUse() 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataOldNotUse()
        {
            //BasePageLogic.DataTableAddColumn(this.DTUser, "colSelected");
            this.dgvInfo.AutoGenerateColumns = false;
            if (DTUser != null && DTUser.Rows.Count > 0)
            {
                this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            }

            this.dgvInfo.DataSource = this.DTUser.DefaultView;
            if (this.CurrentEntityId.Length > 0)
            {
                this.dgvInfo.FirstDisplayedScrollingRowIndex = BasePageLogic.GetRowIndex(this.DTUser, PiUserTable.FieldId, this.CurrentEntityId);
            }
            // 设置排序按钮
            this.ucSortControl.DataBind(this.dgvInfo, this.permissionEdit);
            // 设置用户能否修改有效状态
            if (!this.permissionEdit)
            {
                // 只读属性设置
                this.dgvInfo.Columns["colEnabled"].ReadOnly = !this.permissionEdit;
            }
            this.SetControlState();
        }
        #endregion

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            var search = this.txtSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.DTUser.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.DTUser.Columns.Count > 1)
                {
                    search = BusinessLogic.GetSearchString(search);
                    this.DTUser.DefaultView.RowFilter = PiUserTable.FieldUserName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldRealName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldCode + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldDepartmentName + " LIKE '" + search + "'"
                                                        + " OR " + PiUserTable.FieldDescription + " LIKE '" + search + "'";
                }
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
          
            this.Close();           
        }        

        private void dgvInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //设置第一列可读
            foreach (var dgvReceiveDataColumn in dgvInfo.Columns.Cast<DataGridViewColumn>().Where(dgvReceiveDataColumn => !dgvReceiveDataColumn.Name.Contains("colSelect")))
            {
                dgvReceiveDataColumn.ReadOnly = true;
            }
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInfo.CurrentCell != null)
            {
                btnEdit.PerformClick();    
            }
        }

        public override void RefreshForm()
        {
            this.FormOnLoad();
        }

        public override bool CheckInput()
        {
            var returnValue = true;
            foreach (var userEntity in from DataGridViewRow dgvRow in dgvInfo.Rows 
                                       let dataRowView = dgvRow.DataBoundItem as DataRowView where dataRowView != null 
                                       let dataRow = dataRowView.Row where (System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false) 
                                       select BaseEntity.Create<PiUserEntity>(dataRow))
            {
                //不能删除自己
                if (userEntity.Id != null && base.UserInfo.Id.Equals(userEntity.Id.ToString()))
                {
                    returnValue = false;
                    MessageBoxHelper.ShowWarningMsg(string.Format(RDIFrameworkMessage.MSG0100,UserInfo.RealName));
                    break;
                }

                if (!string.IsNullOrEmpty(userEntity.Code) && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
                {
                    returnValue = false;
                    MessageBoxHelper.ShowWarningMsg("温馨提示：当前用户为超级用户！");
                    break;
                }

                // 超级管理员等不允许删除
                if (userEntity.Code != null && userEntity.Code.Equals(DefaultRole.Administrator.ToString()))
                {
                    MessageBoxHelper.ShowWarningMsg("温馨提示：超级管理员等不允许删除！");
                    break;
                }

                //if (userEntity.UserOnLine == 1)
                //{
                //    returnValue = false;
                //    MessageBoxHelper.ShowWarningMsg("温馨提示：当前用户为在线用户！");
                //    break;
                //}
            }
            return returnValue;
        }

        private void dgvInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentCell == null || dgvInfo.Rows.Count <= 0)
            {
                return;
            }            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {           
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.Search(true);
            this.Cursor = holdCursor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmUserAdd = new FrmUserAdd {Owner = this};
            //this.ShowFormInMainTab(frmUserAdd, "FrmUserAdd", btnAdd.Image);
            frmUserAdd.ShowDialog();    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //法一、调用FrmUserUpdate窗体做编辑界面
            //dgvInfo.EndEdit();
            //if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            //var listDataRow = (from DataGridViewRow dgvRow in dgvInfo.Rows 
            //                   let dataRowView = dgvRow.DataBoundItem as DataRowView where dataRowView != null 
            //                   let dataRow = dataRowView.Row where (System.Boolean) (dgvRow.Cells["colSelected"].Value ?? false) 
            //                   select dataRow).ToList();

            /*
            var IDList = (from dataRowView in (from DataGridViewRow dgvRow in dgvInfo.Rows select dgvRow.DataBoundItem).OfType<DataRowView>()
                          select dataRowView.Row into dataRow where dataRow != null 
                          select dataRow[PiUserTable.FieldId].ToString()).ToList();
            var frmUserUpdate = new FrmUserUpdate(this.DTUser);            
            frmUserUpdate.EntityId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiUserTable.FieldId);
            frmUserUpdate.IDList = IDList;
            frmUserUpdate.OnDataSaved += new EventHandler(frmUserUpdate_OnDataSaved);
            if (frmUserUpdate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // 获取绑定数据
                this.BindData();
            }
            */

            //法二、调用FrmUserEdit窗体做编辑界面
            //var frmUserEdit = new FrmUserEdit(this.EntityId);
            //if (frmUserEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    // 获取绑定数据
            //    this.BindData();
            //}      
          
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, PiUserTable.FieldId);
            if (!string.IsNullOrEmpty(tmpId))
            {
                var frmUserEdit = new FrmUserEdit(tmpId);
                if (frmUserEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // 获取绑定数据
                    this.BindData();
                }      
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (!CheckInput())
            {
                return;
            }

            if (MessageBoxHelper.Show("\n你确定删除所选用户吗？（是/否）") != DialogResult.Yes) return;
            
            try
            {
                var returnValue = RDIFrameworkService.Instance.UserService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, PiUserTable.FieldId, "colSelected", true));
                if (returnValue > 0 && SystemInfo.ShowSuccessMsg)
                {
                    MessageBoxHelper.ShowSuccessMsg("温馨提示:共删除【" + returnValue.ToString(CultureInfo.InvariantCulture) + "】条用户数据！");
                    this.Search(true);
                }
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (!CheckInput())
            {
                return;
            }

            //此处还要做判断，超级管理员才能做批量修改(即可选择多个用户同时修改其密码为统一密码)。

            var userIds = BasePageLogic.GetSelecteIds(this.dgvInfo, PiUserTable.FieldId, "colSelected", true);
            if (userIds.Length > 1 && MessageBoxHelper.Show("确认批量设置所选用户的密码吗？") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            var userPassword = new FrmUserPassword(userIds);
            userPassword.ShowDialog();
        }

        private void btnUserOrganize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.EntityId))
            {
                MessageBoxHelper.ShowInformationMsg("请选择一个用户！");
                return;
            }
            var frmAddUserOrganize = new FrmUserOrganize(this.EntityId);
            frmAddUserOrganize.ShowDialog();
        }

        private void SearchByEnabled(bool? enabled)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.Search(enabled);
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }

        private void btnViewEnabledUser_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.SearchByEnabled(true);
            this.Cursor = holdCursor;
        }

        private void btnViewAllUser_Click(object sender, EventArgs e)
        {
            this.SearchByEnabled(null);
        } 

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            RDIFrameworkService.Instance.UserService.BatchSave(this.UserInfo, this.DTUser);
            // 绑定屏幕数据
            this.FormOnLoad();
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
            }
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (!BasePageLogic.CheckInputModifyAnyOne(this.DTUser)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                this.BatchSave();                   
                this.DTUser.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (this.tvOrganize.SelectedNode != null)
            {
                tvOrganize.PathSeparator = ">";
                lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
            }      
            if (this.FormLoaded)
            {
                this.GetOrganizeList();
                this.Search(null);
            }
            this.Cursor = holdCursor;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search(null);
            this.Cursor = holdCursor;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.DTUser == null || this.DTUser.Rows.Count <= 0)
            {
                MessageBoxHelper.ShowInformationMsg("温馨提示：没有要导出的用户数据！");
                return;
            }

            var dtHeaderText = new Dictionary<string, string>
            {
                {"ID", "主键"},
                {"CODE", "编号"},
                {"USERNAME", "登录名"},
                {"REALNAME", "用户名"},
                {"GENDER", "性別"},
                {"MOBILE", "手机号码"},
                {"DEPARTMENTNAME", "部门"},
                {"ROLENAME", "默认角色"},
                {"EMAIL", "邮箱"},
                {"ENABLED", "效"},
                {"DESCRIPTION", "描述"}
            };
            var filename = this.Text;
            var savePath = SystemInfo.StartupPath + @"\Modules\Export\" + this.Text + ".xls";
            if (MessageBoxHelper.Show("确定导出当前所显示的数据到：" + savePath) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    NPOIHelper.ExportByWinform(DTUser, dtHeaderText, savePath);
                    MessageBoxHelper.ShowSuccessMsg("恭喜你，导出成功！");
                }
                catch (Exception ex)
                {
                    ProcessException(ex);                    
                }
            }
        }
        private void btnLogByUser_Click(object sender, EventArgs e)
        {
            var logByUser = new FrmLogByUser(this.EntityId,RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo,this.EntityId).RealName) { DbLinks = this.DbLinks };
            this.ShowFormInMainTab(logByUser, "FrmLogByUser", btnLogByUser.Image);
        }

        private void btnLogByGeneral_Click(object sender, EventArgs e)
        {
            var logByGeneral = new FrmLogByGeneral() { DbLinks = this.DbLinks };
            this.ShowFormInMainTab(logByGeneral, "FrmLogByGeneral", btnLogByGeneral.Image);
        }

        private void btnDimission_Click(object sender, EventArgs e)
        {
            var userDimission = new FrmUserDimission(this.EntityId){ DbLinks = this.DbLinks };
            if (userDimission.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Search(true);
            }
        }
    }
}
