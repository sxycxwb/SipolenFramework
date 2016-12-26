using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmCustomerAdmin
    /// 客户管理主界面【我的客户】
    /// 
    /// </summary>
    public partial class FrmCustomerAdmin : BaseForm
    {
        DataTable dtCustomerClass = new DataTable(CustomerClassTable.TableName);
        DataTable dtCustomerList  = new DataTable(CustomerTable.TableName);
        DataTable dtLinkManList   = new DataTable(LinkManTable.TableName);
        ILinkManService linkMainService = null;
        ICustomerService customerService = null;
        ICustomerClassService customerClassService = null;
        private string parentEntityId = string.Empty;
        private string currentClassName = string.Empty;
        private string currentCustomerId = string.Empty;

        #region 权限控制部分
        //客户管理权限部分
        
        /// <summary>
        /// 访问客户管理权限
        /// </summary>
        private bool permissionCustomerAccess = false;
        /// <summary>
        /// 新增客户权限
        /// </summary>
        private bool permissionCustomerAdd = false;

        /// <summary>
        /// 编辑客户权限
        /// </summary>
        private bool permissionCustomerEdit = false;

        /// <summary>
        /// 删除客户权限
        /// </summary>
        private bool permissionCustomerDelete = false;

        /// <summary>
        /// 复制客户数据
        /// </summary>
        private bool permissionCustomerCopy = false;

        /// <summary>
        /// 发送邮件
        /// </summary>
        private bool permissionCustomerSendEmail = false;

        //联系人管理权限部分

        /// <summary>
        /// 添加联系人权限
        /// </summary>
        private bool permissionLinkManAdd = false;

        /// <summary>
        /// 编辑联系人权限
        /// </summary>
        private bool permissionLinkManEdit = false;

        /// <summary>
        /// 删除联系人权限
        /// </summary>
        private bool permissionLinkManDelete = false;

        /// <summary>
        /// 导入联系人权限
        /// </summary>
        private bool permissionLinkManImport = false;

        /// <summary>
        /// 导出联系人权限
        /// </summary>
        private bool permissionLinkManExport = false;

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            //客户部分
            this.btnAdd.Enabled     = false;
            this.btnEdit.Enabled    = false;
            this.btnCopy.Enabled    = false;
            this.btnDelete.Enabled  = false;
            this.btnEmail.Enabled   = false;

            //联系人部分
            this.btnAddLinkMain.Enabled = false;
            this.btnEditLinkMain.Enabled = false;
            this.btnDeleteLinkMain.Enabled = false;
            this.btnImportLinkMain.Enabled = false;
            this.btnExportLinkMain.Enabled = false;

            if ((this.dgvCustomer.DataSource != null) && (this.dgvCustomer.RowCount > 0))
            {
                this.btnAdd.Enabled = this.permissionCustomerAdd;
                this.btnEdit.Enabled = this.permissionCustomerEdit;            
                this.btnDelete.Enabled = this.permissionCustomerDelete;
                this.btnCopy.Enabled = this.permissionCustomerCopy;
                this.btnEmail.Enabled = this.permissionCustomerSendEmail;
            }

            if ((this.dgvLinkMain.DataSource != null) && (this.dgvLinkMain.RowCount > 0))
            {
                this.btnAddLinkMain.Enabled = this.permissionLinkManAdd;
                this.btnEditLinkMain.Enabled = this.permissionLinkManEdit;
                this.btnDeleteLinkMain.Enabled = this.permissionLinkManDelete;
                this.btnImportLinkMain.Enabled = this.permissionLinkManImport;
                this.btnExportLinkMain.Enabled = this.permissionLinkManExport;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionCustomerAccess = this.IsModuleAuthorized("CustomerAdmin");
            //客户部分
            this.permissionCustomerAdd = this.IsAuthorized("CustomerAdmin.Add");
            this.permissionCustomerEdit = this.IsAuthorized("CustomerAdmin.Edit");
            this.permissionCustomerDelete = this.IsAuthorized("CustomerAdmin.Delete");
            this.permissionCustomerCopy = this.IsAuthorized("CustomerAdmin.Copy");
            this.permissionCustomerSendEmail = this.IsAuthorized("CustomerAdmin.SendEmail");              
            //联系人部分
            this.permissionLinkManAdd = this.IsAuthorized("LinkManAdmin.Add");
            this.permissionLinkManEdit = this.IsAuthorized("LinkManAdmin.Edit");
            this.permissionLinkManDelete = this.IsAuthorized("LinkManAdmin.Delete");
            this.permissionLinkManImport = this.IsAuthorized("LinkManAdmin.Import");
            this.permissionLinkManExport = this.IsAuthorized("LinkManAdmin.Export");
        }
        #endregion

        #endregion

        /// <summary>
        /// 当前导航主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvCustomerClass.SelectedNode != null) && (this.tvCustomerClass.SelectedNode.Tag != null))
                {
                    try
                    {
                        this.parentEntityId = ((DataRow)this.tvCustomerClass.SelectedNode.Tag)[CustomerTable.FieldId].ToString();
                    }
                    catch
                    {
                        this.parentEntityId = this.tvCustomerClass.SelectedNode.Tag.ToString();
                    }
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

        public FrmCustomerAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            linkMainService      = new LinkManService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            customerService      = new CustomerService(DbLinks["CRMDBLink"].DbType,SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            customerClassService = new CustomerClassService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            this.DataGridViewOnLoad(dgvCustomer);
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
                // 获取客户分类数据               
                this.dtCustomerClass = customerClassService.GetDataTable(UserInfo);

                if (!this.UserInfo.IsAdministrator)
                {
                    BasePageLogic.CheckTreeParentId(this.dtCustomerClass, CustomerClassTable.FieldId, CustomerClassTable.FieldParentId);
                }
                this.LoadTree();
                if (this.tvCustomerClass.SelectedNode == null)
                {
                    if (this.tvCustomerClass.Nodes.Count > 0)
                    {
                        if (this.parentEntityId.Length == 0)
                        {
                            this.tvCustomerClass.SelectedNode = this.tvCustomerClass.Nodes[0];
                        }
                        else
                        {
                            BasePageLogic.FindTreeNode(this.tvCustomerClass, this.parentEntityId);
                            if (BasePageLogic.TargetNode != null)
                            {
                                this.tvCustomerClass.SelectedNode = BasePageLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BasePageLogic.ExpandTreeNode(this.tvCustomerClass);
                            }
                        }
                        if (this.tvCustomerClass.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvCustomerClass.SelectedNode.Expand();
                            this.tvCustomerClass.SelectedNode.EnsureVisible();
                        }
                    }
                }
            }

            if (this.ParentEntityId.Length > 0)
            {
                if (reloadTree)
                {
                    // 获得得到分类下的客户列表
                    this.GetCustomerList();
                }
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region private void GetCustomerList() 获得得到分类下的客户列表
        /// <summary>
        /// 获得得到分类下的客户列表
        /// </summary>
        private void GetCustomerList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
         
            this.dtCustomerList = customerService.GetDTByCategory(UserInfo, this.ParentEntityId);            
            this.dtCustomerList.DefaultView.Sort = CustomerTable.FieldSortCode;
            this.dgvCustomer.AutoGenerateColumns = false;
            this.dgvCustomer.DataSource = this.dtCustomerList.DefaultView;
            
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void GetLinkManList() 获得联系人列表通过客户ID
        /// <summary>
        /// 获得联系人列表通过客户ID
        /// </summary>
        private void GetLinkManList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(LinkManTable.FieldCustomerId, currentCustomerId));
            parameters.Add(new KeyValuePair<string, object>(LinkManTable.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(LinkManTable.FieldDeleteMark, 0));
            this.dtLinkManList = linkMainService.GetDataTableByValues(base.UserInfo, parameters);
            this.dtLinkManList.DefaultView.Sort = LinkManTable.FieldSortCode;
            this.dgvLinkMain.AutoGenerateColumns = false;
            this.dgvLinkMain.DataSource = null;
            this.dgvLinkMain.DataSource = dtLinkManList.DefaultView;
            // 设置按钮状态
            this.SetControlState();
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        #region private void LoadTree()  加载客户分类数据
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvCustomerClass.BeginUpdate();
            this.tvCustomerClass.Nodes.Clear();
            this.LoadTreeCustomerClass();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvCustomerClass.EndUpdate();
        }

        private void LoadTreeCustomerClass()
        {
            TreeNode treeNode = new TreeNode();
            this.LoadTreeCustomerClass(treeNode);
        }
        #endregion

        #region private void LoadTreeCustomerClass(TreeNode treeNode) 加载客户分类数据
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="TreeNode">当前节点</param>
        private void LoadTreeCustomerClass(TreeNode treeNode)
        {
            if ((SystemInfo.EnableUserAuthorizationScope) && !UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.dtCustomerClass, CustomerClassTable.FieldId, CustomerClassTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.dtCustomerClass, CustomerClassTable.FieldId, CustomerClassTable.FieldParentId, CustomerClassTable.FieldClassName, tvCustomerClass, treeNode);
        }
        #endregion

        #region 树操作相关控制代码
        private void tvCustomerClass_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Node.ToolTipText))
            {
                e.Node.Nodes.Clear();
                LoadTreeCustomerClass(e.Node);
                e.Node.ToolTipText = e.Node.Text;
            }
        }

        /// <summary>
        /// 设置快捷菜单中各菜单的可用性
        /// </summary>
        /// <param name="node">当前树节点</param>
        private void SetMenuState(TreeNode node)
        {            
            if (node.Text == "所有分类")
            {
                mnuAddLowerLevel.Enabled = true;
                mnuAddSameLevel.Enabled  = false;
                mnuDeleteCurrent.Enabled = false;
                mnuDown.Enabled          = false;
                mnuRenameClass.Enabled   = false;
                mnuUp.Enabled            = false;
            }
            else
            {
                mnuAddLowerLevel.Enabled = true;
                mnuAddSameLevel.Enabled  = true;
                mnuRenameClass.Enabled   = true;
            }

            mnuDeleteCurrent.Enabled = node.Nodes.Count <= 0 ? true  : false;
            mnuUp.Enabled            = node.PrevNode == null ? false : true;
            mnuDown.Enabled          = node.NextNode == null ? false : true;
            btnUpLevel.Enabled       = node.Parent == null   ? false : true;
        }

        private void tvCustomerClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvCustomerClass.SelectedNode == null ||
                this.tvCustomerClass.SelectedNode.Text.Equals("所有客户") ||
                this.tvCustomerClass.SelectedNode.Text.Equals("最近使用客户") ||
                this.tvCustomerClass.SelectedNode.Text.Equals("经常使用客户") ||
                this.tvCustomerClass.SelectedNode.Text.Equals("固定客户")||
                this.tvCustomerClass.Nodes.Count <= 0)
            {
                this.tvCustomerClass.ContextMenuStrip = null;
            }
            else
            {
                this.tvCustomerClass.ContextMenuStrip = this.cMnuCustomerClass;
            }

            if (this.tvCustomerClass.SelectedNode != null)
            {
                theLastNode = tvCustomerClass.SelectedNode;
                SetMenuState(this.tvCustomerClass.SelectedNode);
                this.GetCustomerList();
            }                   
        }


        TreeNode theLastNode = null;
        private void tvCustomerClass_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ForeColor = Color.Blue;
            e.Node.NodeFont = new Font("宋体", 10, FontStyle.Underline|FontStyle.Bold);
            if (theLastNode != null)
            {
                theLastNode.ForeColor = SystemColors.WindowText;
                theLastNode.NodeFont = new Font("宋体", 11, FontStyle.Regular);
            }
        }

        private void tvCustomerClass_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point clickPoint = new Point(e.X, e.Y);
                tvCustomerClass.SelectedNode = tvCustomerClass.GetNodeAt(clickPoint);
            }
        }

        private void tvCustomerClass_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != currentClassName && e.Label != null)
            {
                List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
                whereParameters.Add(new KeyValuePair<string, object>(CustomerClassTable.FieldId, tvCustomerClass.SelectedNode.Tag.ToString()));
                whereParameters.Add(new KeyValuePair<string, object>(CustomerClassTable.FieldDeleteMark, 0));
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(CustomerClassTable.FieldClassName, e.Label));
                customerClassService.UpdateByValues(UserInfo, whereParameters, parameters);
            }

            tvCustomerClass.LabelEdit = false;
        }

        private void tvCustomerClass_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            currentClassName = tvCustomerClass.SelectedNode.Text;
        }
        #endregion

        //客户分类管理各功能代码
        #region 客户分类管理各功能代码
        //新增同级分类
        private void mnuAddSameLevel_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                tvCustomerClass.LabelEdit = true;
                TreeNode tmp = new TreeNode("新分类");

                CustomerClassEntity customerClassEntity = new CustomerClassEntity();
                customerClassEntity.ClassName = "新分类";
                customerClassEntity.ParentId = tvCustomerClass.SelectedNode.Parent == null ? null : BusinessLogic.ConvertToNullableInt(((DataRow)this.tvCustomerClass.SelectedNode.Parent.Tag)[CustomerTable.FieldId].ToString());
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                tmp.Tag = customerClassService.Add(UserInfo, customerClassEntity, out statusCode, out statusMessage);
                if (statusCode != StatusCode.OKAdd.ToString())
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                }
                else
                {
                    tvCustomerClass.SelectedNode.Parent.Nodes.Add(tmp);
                    tmp.BeginEdit();
                    tvCustomerClass.SelectedNode = tmp;
                }
            }
        }

        //新增下级分类
        private void mnuAddLowerLevel_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                tvCustomerClass.LabelEdit = true;
                TreeNode tmp = new TreeNode("新分类");
                CustomerClassEntity customerClassEntity = new CustomerClassEntity();
                customerClassEntity.ClassName = "新分类";
                customerClassEntity.ParentId = tvCustomerClass.SelectedNode.Parent == null ? null : BusinessLogic.ConvertToNullableInt(((DataRow)this.tvCustomerClass.SelectedNode.Tag)[CustomerTable.FieldId].ToString());
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                tmp.Tag = customerClassService.Add(UserInfo, customerClassEntity, out statusCode, out statusMessage);

                if (statusCode != StatusCode.OKAdd.ToString())
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                }
                else
                {
                    tvCustomerClass.SelectedNode.Nodes.Add(tmp);
                    tmp.BeginEdit();
                    tvCustomerClass.SelectedNode = tmp;
                }
            }
        }

        //删除当前分类
        private void mnuDeleteCurrent_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                if (MessageBoxHelper.Show("是否删除当前分类：【" + tvCustomerClass.SelectedNode.Text + "】？\n删除分类并不删除该分类下的所有客户数据。") == System.Windows.Forms.DialogResult.Yes)
                {
                    List<KeyValuePair<string, object>> whereParameters = new List<KeyValuePair<string, object>>();
                    whereParameters.Add(new KeyValuePair<string, object>(CustomerTable.FieldCustomerClassID, this.ParentEntityId));
                    whereParameters.Add(new KeyValuePair<string, object>(CustomerTable.FieldDeleteMark, 0));
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(CustomerTable.FieldCustomerClassID, ((DataRow)this.tvCustomerClass.SelectedNode.Parent.Tag)[CustomerTable.FieldId].ToString()));
                    customerService.UpdateByValues(UserInfo, whereParameters, parameters);
                    customerClassService.Delete(UserInfo, this.ParentEntityId);
                    tvCustomerClass.SelectedNode.Remove();
                }
            }
        }

        //重命名当前分类
        private void mnuRenameClass_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                currentClassName = tvCustomerClass.SelectedNode.Text;
                tvCustomerClass.LabelEdit = true;
                tvCustomerClass.SelectedNode.BeginEdit();
            }
        }

        //上移
        private void mnuUp_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                TreeNode treeNode = tvCustomerClass.SelectedNode.PrevNode;
                if (treeNode != null)
                {
                    tvCustomerClass.SelectedNode.PrevNode.Remove();
                    int tmp = tvCustomerClass.SelectedNode.Index + 1;
                    if (tvCustomerClass.SelectedNode.Parent == null)
                    {
                        tvCustomerClass.Nodes.Insert(tmp, treeNode);
                    }
                    else
                    {
                        tvCustomerClass.SelectedNode.Parent.Nodes.Insert(tmp, treeNode);
                    }
                }
            }
        }

        //下移
        private void mnuDown_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode != null)
            {
                TreeNode treeNode = tvCustomerClass.SelectedNode.NextNode;
                if (treeNode != null)
                {
                    tvCustomerClass.SelectedNode.NextNode.Remove();
                    int tmp = tvCustomerClass.SelectedNode.Index - 1;
                    if (tvCustomerClass.SelectedNode.Parent == null)
                    {
                        tvCustomerClass.Nodes.Insert(tmp, treeNode);
                    }
                    else
                    {
                        tvCustomerClass.SelectedNode.Parent.Nodes.Insert(tmp, treeNode);
                    }
                }
            }
        }

        #endregion

        //客户管理界面各功能代码

        #region 客户管理界面各功能代码
        private void btnUpLevel_Click(object sender, EventArgs e)
        {
            tvCustomerClass.SelectedNode = tvCustomerClass.SelectedNode.Parent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tvCustomerClass.SelectedNode == null || tvCustomerClass.SelectedNode.Tag == null)
            {
                MessageBoxHelper.ShowWarningMsg("请选择一个分类后再进行添加！");
                return;
            }

            FrmCustomerEdit frmCustomerEdit = new FrmCustomerEdit(((DataRow)this.tvCustomerClass.SelectedNode.Tag)[CustomerTable.FieldId].ToString().ToString())
            {
                DbLinks = this.DbLinks
            };
            if (frmCustomerEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.GetCustomerList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentCell == null)
            {
                return;
            }
            string classId      = dgvCustomer[CustomerTable.FieldCustomerClassID,dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            string customerId   = dgvCustomer[CustomerTable.FieldId,dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            string shortName    = dgvCustomer["colShortName", dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            FrmCustomerEdit frmCustomerEdit = new FrmCustomerEdit(classId, customerId, shortName)
            {
                DbLinks = this.DbLinks
            };
            if (frmCustomerEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.GetCustomerList();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("是否要复制当前用户？（是/否）") == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvCustomer.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (BasePageLogic.CheckInputSelectAnyOne(dgvCustomer, "colSelected"))
            {
                if (!CheckInput())
                {
                    return;
                }

                if (MessageBoxHelper.Show("\n你确定删除所选数据吗？（是/否）") == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int returnValue = RDIFrameworkService.Instance.UserService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvCustomer, CustomerTable.FieldId, "colSelected", true));
                        if (returnValue > 0 && SystemInfo.ShowSuccessMsg)
                        {
                            MessageBoxHelper.ShowSuccessMsg("温馨提示:共删除【" + returnValue.ToString() + "】条数据！");
                            // 获取绑定数据
                            this.GetCustomerList();
                        }
                    }
                    catch (Exception exception)
                    {
                        this.ProcessException(exception);
                    }
                }
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            this.Close();       
        }

        #endregion

        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //设置第一列可读
            foreach (DataGridViewColumn dgvDataColumn in dgvCustomer.Columns)
            {
                if (!dgvDataColumn.Name.Contains("colSelected"))
                {
                    dgvDataColumn.ReadOnly = true;
                }
            }
        }

        #region private void SetCustomerRowFilter() 设置客户数据过滤
        /// <summary>
        /// 设置客户数据过滤
        /// </summary>
        private void SetCustomerRowFilter()
        {
            string search = this.txtCustomSearchValue.Text;
            if (String.IsNullOrEmpty(search))
            {
                this.dtCustomerList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                if (this.dtCustomerList.Columns.Count > 1)
                {
                    search = BusinessLogic.GetSearchString(search);

                    string operatorString = " LIKE ";
                    if (rbCustomerExactSearch.Checked)
                    {
                        operatorString = " = ";
                    }

                    if (rbCustomerAll.Checked)
                    {
                        this.dtCustomerList.DefaultView.RowFilter = CustomerTable.FieldShortName + operatorString + " '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldCompanyName + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldCompanyPhone + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldCompanyAddress + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldCompanyFax + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldPostalCode + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldWebAddress + operatorString + "  '" + search + "'"
                                                                  + " OR " + CustomerTable.FieldDescription + operatorString + "  '" + search + "'";
                    }
                    else
                    {
                        string filter = string.Empty;
                        filter = rbCustomerShortName.Checked ? CustomerTable.FieldShortName + operatorString + " '" + search + "'" : filter;
                        filter = rbCustomerCompanyPhone.Checked ? CustomerTable.FieldCompanyPhone + operatorString + " '" + search + "'" : filter;
                        filter = rbCustomerCompanyName.Checked ? CustomerTable.FieldCompanyName + operatorString + "  '" + search + "'" : filter;
                        filter = rbCustomerCompanyAddress.Checked ? CustomerTable.FieldWebAddress + operatorString + "  '" + search + "'" : filter;
                        filter = rbCustomerCompanyFax.Checked ? CustomerTable.FieldCompanyFax + operatorString + "  '" + search + "'" : filter;
                        filter = rbCustomerPostalCode.Checked ? CustomerTable.FieldPostalCode + operatorString + "  '" + search + "'" : filter;
                        filter = rbCustomerWebAddress.Checked ? CustomerTable.FieldWebAddress + operatorString + "  '" + search + "'" : filter;
                        filter = rbCustomerDescription.Checked ? CustomerTable.FieldDescription + operatorString + "  '" + search + "'" : filter;
                        this.dtCustomerList.DefaultView.RowFilter = filter;
                    }
                }
            }
        }
        #endregion

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            SetCustomerRowFilter();
        }

        #region  private void BindCostomerContactInfo() 绑定客户信息（客户、联系人的主要信息）
        private void BindCostomerContactInfo()
        {
            DataTable dtCustomerContactInfo = customerService.GetCustomerContactInfo(base.UserInfo, dgvCustomer[CustomerTable.FieldId, dgvCustomer.CurrentCell.RowIndex].Value.ToString());

            if (dtCustomerContactInfo == null || dtCustomerContactInfo.Rows.Count <= 0)
            {
                return;
            }

            lvCustomerInfo.Columns.Clear();
            lvCustomerInfo.Items.Clear();
            lvCustomerInfo.Groups.Clear();
            lvCustomerInfo.Columns.Add("信息", 150, HorizontalAlignment.Left);
            lvCustomerInfo.Columns.Add("值", 500, HorizontalAlignment.Left);

            ListViewGroup lvGroupCustomerInfo = new ListViewGroup("客户信息", HorizontalAlignment.Left);
            ListViewGroup lvGroupContractInfo = new ListViewGroup("联系人信息", HorizontalAlignment.Left);
            lvCustomerInfo.Groups.Add(lvGroupCustomerInfo);
            lvCustomerInfo.Groups.Add(lvGroupContractInfo);

            DataRow dataRow = dtCustomerContactInfo.Rows[0];
            for (int columnIndex = 0; columnIndex < dtCustomerContactInfo.Columns.Count; columnIndex++)
            {
                if (dtCustomerContactInfo.Rows[0][columnIndex] == null || string.IsNullOrEmpty(dtCustomerContactInfo.Rows[0][columnIndex].ToString()))
                {
                    continue;
                }
                ListViewItem listViewItem = new ListViewItem(dtCustomerContactInfo.Columns[columnIndex].ColumnName);
                listViewItem.Font = new Font("宋体", 11, listViewItem.Font.Style | FontStyle.Bold);
                if (dtCustomerContactInfo.Columns[columnIndex].ColumnName.Contains("联系人"))
                {
                    listViewItem.Group = lvGroupContractInfo;
                    lvCustomerInfo.Items.Add(listViewItem).SubItems.Add(dtCustomerContactInfo.Rows[0][columnIndex].ToString());
                }
                else
                {
                    listViewItem.Group = lvGroupCustomerInfo;
                    lvCustomerInfo.Items.Add(listViewItem).SubItems.Add(dtCustomerContactInfo.Rows[0][columnIndex].ToString());
                }
            }   
        }
        #endregion

        private void dgvCustomer_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentCell == null)
            {
                currentCustomerId = string.Empty;
                currentClassName = string.Empty;
                lvCustomerInfo.Columns.Clear();
                lvCustomerInfo.Items.Clear();
                lvCustomerInfo.Groups.Clear();

                this.dgvLinkMain.DataSource = null;
                return;
            }

            currentCustomerId = dgvCustomer[CustomerTable.FieldId, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            switch (tabCustomerLinkInfo.Tabs[tabCustomerLinkInfo.SelectedTabIndex].Text)
            {
                case "客户信息":
                    BindCostomerContactInfo();
                    break;
                case "联系人":
                    GetLinkManList();
                    break;
                case "跟进人员":
                    MessageBoxHelper.Show("跟进人员");
                    break;
                default:
                    MessageBoxHelper.Show("无...");
                    break;
            }

            BindCostomerContactInfo();               
        }

        private void tabCustomerLinkInfo_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            switch (tabCustomerLinkInfo.Tabs[tabCustomerLinkInfo.SelectedTabIndex].Text)
            {
                case "客户信息":
                    break;
                case "联系人":
                    GetLinkManList();
                    break;
                case "跟进人员":
                    MessageBoxHelper.Show("跟进人员");
                    break;
                default:
                    MessageBoxHelper.Show("无...");
                    break;
            }

            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        //联系人管理部分

        #region 联系人管理部分（添加、修改、删除、导入、导出等）

        //新增联系人
        private void btnAddLinkMain_Click(object sender, EventArgs e)
        {
            FrmLinkManEdit frmLinkMainEdit = new FrmLinkManEdit(currentCustomerId) {DbLinks = this.DbLinks};
            if (frmLinkMainEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                GetLinkManList();
            }
        }

        //编辑联系人
        private void btnEditLinkMain_Click(object sender, EventArgs e)
        {
            if (dgvLinkMain.Rows.Count <= 0 || dgvLinkMain.CurrentCell == null)
            {
                return;
            }

            string linkManName = dgvLinkMain["colName", dgvLinkMain.CurrentCell.RowIndex].Value.ToString();
            string linkManId   = dgvLinkMain["colLinkManId", dgvLinkMain.CurrentCell.RowIndex].Value.ToString();
            FrmLinkManEdit frmLinkMainEdit = new FrmLinkManEdit(currentCustomerId,linkManId,linkManName)
            {
                DbLinks = this.DbLinks
            };
            if (frmLinkMainEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                GetLinkManList();
            }
        }

        //删除联系人
        private void btnDeleteLinkMain_Click(object sender, EventArgs e)
        {
            if (dgvLinkMain.CurrentCell == null)
            {
                MessageBoxHelper.ShowWarningMsg("请选择要删除的数据！");
                return;
            }

            if (MessageBoxHelper.Show("确定删除联系人：[" + dgvLinkMain["colName",dgvLinkMain.CurrentCell.RowIndex].Value.ToString() + "]吗？") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string id = dgvLinkMain["colLinkManId", dgvLinkMain.CurrentCell.RowIndex].Value.ToString();
            try
            {
                int returnValue = linkMainService.SetDeleted(base.UserInfo, new string[] { id });
                if (returnValue > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg("删除成功！");
                    GetLinkManList();
                }
                else
                {
                    MessageBoxHelper.ShowSuccessMsg("删除失败！");
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        //导入联系人
        private void btnImportLinkMain_Click(object sender, EventArgs e)
        {

        }

        //导出联系人
        private void btnExportLinkMain_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnExportLinkManToExcel_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".csv";
            this.ExportToExcel(this.dgvLinkMain, @"\Modules\Export\", exportFileName);
        }

        private void btnExportLinkManToTxt_Click(object sender, EventArgs e)
        {
            // 导出Excel
            string exportFileName = this.Text + ".txt";
            this.ExportToText(this.dgvLinkMain, @"\Modules\Export\", exportFileName);
        }
    }
}
