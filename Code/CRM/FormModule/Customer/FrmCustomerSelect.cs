using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.Utilities;

    public partial class FrmCustomerSelect : BaseForm
    {
        DataTable dtCustomerClass = new DataTable(CustomerClassTable.TableName);
        DataTable dtCustomerList  = new DataTable(CustomerTable.TableName);
        DataTable dtLinkManList   = new DataTable(LinkManTable.TableName);
        ICustomerService customerService = null;
        ICustomerClassService customerClassService = null;
        private string parentEntityId = string.Empty;
        private string currentClassName = string.Empty;

        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string SelectedId { get; set; }

        /// <summary>
        /// 被选中的员工全名
        /// </summary>
        public string SelectedName { get; set; }

        /// <summary>
        /// 当前导航主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvCustomerClass.SelectedNode != null) && (this.tvCustomerClass.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvCustomerClass.SelectedNode.Tag)[CustomerTable.FieldId].ToString();
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

        public FrmCustomerSelect()
        {
            SelectedName = string.Empty;
            SelectedId = string.Empty;
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            customerService      = new CustomerService(DbLinks["CRMDBLink"].DbType,SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            customerClassService = new CustomerClassService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            this.DataGridViewOnLoad(dgvCustomer);
            BindData(true);
        }

        #region public void SetControlState() 设置界面按钮的可用性

        private void SetCustomerControlState()
        {            
            btnSelect.Enabled = true;
            if(dgvCustomer.Rows.Count <= 0)
            {
                btnSelect.Enabled = false;
            }
        }
       
        #endregion

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
            this.SetCustomerControlState();
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
            this.SetCustomerControlState();
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
        /// <param name="treeNode">当前节点</param>
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

        TreeNode theLastNode = null;
        private void tvCustomerClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvCustomerClass.SelectedNode != null)
            {
                theLastNode = tvCustomerClass.SelectedNode;
                this.GetCustomerList();
            }                   
        }

        private void tvCustomerClass_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ForeColor = Color.Blue;
            e.Node.NodeFont = new Font("宋体", 10, FontStyle.Underline | FontStyle.Bold);
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
        #endregion       

        private void btnUpLevel_Click(object sender, EventArgs e)
        {
            tvCustomerClass.SelectedNode = tvCustomerClass.SelectedNode.Parent;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentCell != null && dgvCustomer.Rows.Count > 0)
            {
                this.SelectedId = dgvCustomer[CustomerTable.FieldId, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
                this.SelectedName = dgvCustomer["colShortName", dgvCustomer.CurrentCell.RowIndex].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.FormOnLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();       
        }

        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnSelect.Enabled = dgvCustomer.Rows.Count > 0;
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell == null)
            {
                currentClassName = string.Empty;
                this.SelectedId = string.Empty;
                this.SelectedName = string.Empty;
                return;
            }
            this.btnSelect.PerformClick();
        }

    }
}
