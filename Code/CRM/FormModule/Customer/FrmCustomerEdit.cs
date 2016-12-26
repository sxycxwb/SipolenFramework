using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace CRM
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 客户编辑（添加、修改）
    /// FrmCustomerEdit
    /// 
    /// </summary>
    public partial class FrmCustomerEdit : BaseForm
    {
        DataTable dtCustomerClass                    = new DataTable(CustomerClassTable.TableName);
        ICustomerService customerService             = null;
        ICustomerClassService customerClassService   = null;
        ILinkManService linkMainService              = null;
        private CustomerEntity currentCustomerEntity = null;
        private LinkManEntity currentLinkManEntity   = null;
        private string currentCustomerId             = string.Empty; //当前客户Id【主要用户修改用户】
        private string currentCustomerName           = string.Empty;//当前客户简称【主要用户修改用户】


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="classId">当前分类ID</param>
        public FrmCustomerEdit(string classId)
        {
            InitializeComponent();
            CurrentEntityId = classId;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="classId">当前分类ID</param>
        /// <param name="customerId">当前客户Id【主要用户修改用户】</param>
        /// <param name="shortName">当前客户简称【主要用户修改用户】</param>
        public FrmCustomerEdit(string classId,string customerId,string shortName)
        {
            InitializeComponent();
            CurrentEntityId     = classId;
            if (string.IsNullOrEmpty(customerId.Trim()))
            {
                MessageBoxHelper.ShowErrorMsg("请选择待修改的用户！");
                return;
            }
            currentCustomerId   = customerId;
            currentCustomerName = shortName;
        }

        /// <summary>
        /// 当前导航主键
        /// </summary>
        public string CurrentEntityId { get; set; }

        public override void FormOnLoad()
        {
            customerService      = new CustomerService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            customerClassService = new CustomerClassService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            linkMainService      = new LinkManService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            BindTree(true);
            BindCategory();
            this.Text = "新增用户";
            if (!string.IsNullOrEmpty(currentCustomerId))
            {
                this.btnSaveContine.Visible = false;
                this.Text = "编辑用户 - " + currentCustomerName;
                BindEditData();
            }          
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BindCategory()
        {
            BasePageLogic.BindCategory(base.UserInfo, cboStatus, "CustomerState");
            BasePageLogic.BindCategory(base.UserInfo, cboCredit, "CustomerCreditDegree");
            BasePageLogic.BindCategory(base.UserInfo, cboSatisfy, "CustomerSatisfaction");
            BasePageLogic.BindCategory(base.UserInfo, cboSex, "Gender");
            BasePageLogic.BindCategory(base.UserInfo, cboPostion, "Duty");
        }

        #region private void BindData(bool reloadTree) 绑定数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindTree(bool reloadTree)
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
                        if (this.CurrentEntityId.Length == 0)
                        {
                            this.tvCustomerClass.SelectedNode = this.tvCustomerClass.Nodes[0];
                        }
                        else
                        {
                            BasePageLogic.FindTreeNode(this.tvCustomerClass, this.CurrentEntityId);
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
                            lblCurrentClass.Text = this.tvCustomerClass.SelectedNode.Text;
                            this.tvCustomerClass.SelectedNode.Expand();
                            this.tvCustomerClass.SelectedNode.EnsureVisible();
                        }
                    }
                }
            }         
            // 设置按钮状态
            this.SetControlState();
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

        #region private void BindEditData() 绑定待修改的数据
        private void BindEditData()
        {
            currentCustomerEntity = customerService.GetEntity(base.UserInfo,currentCustomerId); 
         
            if (currentCustomerEntity != null)
            {
                //得到主联系人
                currentLinkManEntity = linkMainService.GetMainByCustomerId(base.UserInfo, currentCustomerEntity.Id.ToString());
                //绑定客户信息界面
                txtFullName.Text = currentCustomerEntity.FullName;
                txtShortName.Text = currentCustomerEntity.ShortName;
                txtCompanyName.Text = currentCustomerEntity.CompanyName;
                txtCompanyAddress.Text = currentCustomerEntity.CompanyAddress;
                txtPostalCode.Text = currentCustomerEntity.PostalCode;
                txtCompanyPhone.Text = currentCustomerEntity.CompanyPhone;
                txtCompanyFax.Text = currentCustomerEntity.CompanyFax;
                txtWebAddress.Text = currentCustomerEntity.WebAddress;
                txtBank.Text = currentCustomerEntity.Bank;
                txtBankAccount.Text = currentCustomerEntity.BankAccount;
                txtBankroll.Text = currentCustomerEntity.Bankroll.ToString();
                txtTurnover.Text = currentCustomerEntity.Turnover.ToString();
                txtLicenceNo.Text = currentCustomerEntity.LicenceNo;
                txtLocalTaxNo.Text = currentCustomerEntity.LocalTaxNo;
                txtNationalTaxNo.Text = currentCustomerEntity.NationalTaxNo;
                txtDescription.Text = currentCustomerEntity.Description;
                cboStatus.SelectedValue = currentCustomerEntity.Status;
                cboSatisfy.SelectedValue = currentCustomerEntity.Satisfy;
                cboCredit.SelectedValue = currentCustomerEntity.Credit;
                dtEstablishDate.Text = BusinessLogic.ConvertToDateToString(currentCustomerEntity.EstablishDate == null ? string.Empty : currentCustomerEntity.EstablishDate.ToString());
                if (currentLinkManEntity != null && currentLinkManEntity.Id > 0)
                {
                    //绑定主联系人界面
                    txtName.Text = currentLinkManEntity.Name;
                    txtDepartment.Text = currentLinkManEntity.Department;
                    cboPostion.SelectedValue = currentLinkManEntity.Postion;
                    cboSex.SelectedValue = currentLinkManEntity.Sex;                    
                    txtMobilePhone.Text = currentLinkManEntity.MobilePhone;
                    txtEmail.Text = currentLinkManEntity.Email;
                    txtQQ.Text = currentLinkManEntity.QQ;
                    txtInterest.Text = currentLinkManEntity.Interest;
                }
            }
        }
        #endregion

        TreeNode theLastNode = null;
        private void tvCustomerClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvCustomerClass.SelectedNode != null)
            {
                theLastNode = tvCustomerClass.SelectedNode;
                lblCurrentClass.Text = this.tvCustomerClass.SelectedNode.Text;
                try
                {
                    CurrentEntityId = ((DataRow)this.tvCustomerClass.SelectedNode.Tag)[CustomerClassTable.FieldId].ToString();
                }
                catch
                {
                    CurrentEntityId = this.tvCustomerClass.SelectedNode.Tag.ToString();
                }
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

        #region private bool CheckValueIsEmpty() 界面输入的可用性判断
        private bool CheckValueIsEmpty()
        { 
            string information = string.Empty;
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                information += txtFullName.Tag.ToString() + "\n";
            }

            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                information += txtCompanyName.Tag.ToString() + "\n";
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                information += txtName.Tag.ToString() + "\n";
            }

            if (string.IsNullOrEmpty(cboSatisfy.Text.Trim()))
            {
                information += cboSatisfy.Tag.ToString() + "\n";
            }

            if (string.IsNullOrEmpty(cboCredit.Text.Trim()))
            {
                information += cboCredit.Tag.ToString() + "\n";
            }

            if (!string.IsNullOrEmpty(information))
            {
                MessageBoxHelper.ShowWarningMsg(information + "不能为空！");
                return false;
            }

            return true;
        }
        #endregion

        #region 保存数据
        private void SaveData(bool close)
        {
            if (CheckValueIsEmpty())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                var customerEntity    = new CustomerEntity
                {
                    Code = BusinessLogic.NewGuid(),
                    CustomerClassID = BusinessLogic.ConvertToInt(CurrentEntityId),
                    FullName = txtFullName.Text.Trim(),
                    ShortName = txtShortName.Text.Trim(),
                    CompanyName = txtCompanyName.Text.Trim(),
                    Satisfy =string.IsNullOrEmpty(cboSatisfy.SelectedValue.ToString())
                            ? 3
                            : BusinessLogic.ConvertToInt(cboSatisfy.SelectedValue),
                    Credit =string.IsNullOrEmpty(cboCredit.SelectedValue.ToString())
                            ? 3
                            : BusinessLogic.ConvertToInt(cboCredit.SelectedValue),
                    CompanyAddress = txtCompanyAddress.Text.Trim(),
                    PostalCode = txtPostalCode.Text.Trim(),
                    CompanyPhone = txtCompanyPhone.Text.Trim(),
                    CompanyFax = txtCompanyFax.Text.Trim(),
                    WebAddress = txtWebAddress.Text.Trim(),
                    EstablishDate = BusinessLogic.ConvertToDateTime(dtEstablishDate.Text),
                    LicenceNo = txtLicenceNo.Text.Trim(),
                    Chieftain = txtChieftain.Text.Trim(),
                    Bankroll = BusinessLogic.ConvertToInt(txtBankroll.Text.Trim()),
                    Turnover = BusinessLogic.ConvertToInt(txtTurnover.Text.Trim()),
                    Bank = txtBank.Text.Trim(),
                    BankAccount = txtBankAccount.Text.Trim(),
                    LocalTaxNo = txtLocalTaxNo.Text.Trim(),
                    NationalTaxNo = txtNationalTaxNo.Text.Trim(),
                    Status =string.IsNullOrEmpty(cboStatus.SelectedValue.ToString())
                            ? 1
                            : BusinessLogic.ConvertToInt(cboStatus.SelectedValue),
                    Description = txtDescription.Text.Trim()
                };

                string statusCode    = string.Empty;
                string statusMessage = string.Empty;
                string customerId    = customerService.Add(base.UserInfo, customerEntity,out statusCode,out statusMessage);
                string information   = statusMessage;
                if (customerId.Length > 0)
                {
                    this.Changed = true;                    
                    LinkManEntity linkMainEntity = new LinkManEntity
                    {
                        CustomerId = BusinessLogic.ConvertToInt(customerId),
                        MainLinkMan = 1,
                        Name = txtName.Text.Trim(),
                        Department = txtDepartment.Text.Trim(),
                        Postion = cboPostion.SelectedValue.ToString(),
                        Sex = cboSex.SelectedValue.ToString(),
                        MobilePhone = txtMobilePhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        QQ = txtQQ.Text.Trim(),
                        Interest = txtInterest.Text.Trim()
                    };
                    string value                 =  linkMainService.Add(base.UserInfo, linkMainEntity, out statusCode, out statusMessage);
                    if (value.Length <= 0)
                    {
                        information += "\n主联系人" + statusMessage;
                    }
                }

                MessageBoxHelper.ShowInformationMsg(information);

                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;

                if (this.Changed && close)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
      
        private void SaveEditData()
        {
            if (CheckValueIsEmpty())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                currentCustomerEntity.CustomerClassID = BusinessLogic.ConvertToInt(CurrentEntityId);
                currentCustomerEntity.FullName = txtFullName.Text.Trim();
                currentCustomerEntity.ShortName = txtShortName.Text.Trim();
                currentCustomerEntity.CompanyName = txtCompanyName.Text.Trim();
                currentCustomerEntity.Satisfy = string.IsNullOrEmpty(cboSatisfy.SelectedValue.ToString()) ? 3 : BusinessLogic.ConvertToInt(cboSatisfy.SelectedValue);
                currentCustomerEntity.Credit = string.IsNullOrEmpty(cboCredit.SelectedValue.ToString()) ? 3 : BusinessLogic.ConvertToInt(cboCredit.SelectedValue);
                currentCustomerEntity.CompanyAddress = txtCompanyAddress.Text.Trim();
                currentCustomerEntity.PostalCode = txtPostalCode.Text.Trim();
                currentCustomerEntity.CompanyPhone = txtCompanyPhone.Text.Trim();
                currentCustomerEntity.CompanyFax = txtCompanyFax.Text.Trim();
                currentCustomerEntity.WebAddress = txtWebAddress.Text.Trim();
                currentCustomerEntity.EstablishDate = BusinessLogic.ConvertToDateTime(dtEstablishDate.Text);
                currentCustomerEntity.LicenceNo = txtLicenceNo.Text.Trim();
                currentCustomerEntity.Chieftain = txtChieftain.Text.Trim();
                currentCustomerEntity.Bankroll = BusinessLogic.ConvertToInt(txtBankroll.Text.Trim());
                currentCustomerEntity.Turnover = BusinessLogic.ConvertToInt(txtTurnover.Text.Trim());
                currentCustomerEntity.Bank = txtBank.Text.Trim();
                currentCustomerEntity.BankAccount = txtBankAccount.Text.Trim();
                currentCustomerEntity.LocalTaxNo = txtLocalTaxNo.Text.Trim();
                currentCustomerEntity.NationalTaxNo = txtNationalTaxNo.Text.Trim();
                currentCustomerEntity.Status = string.IsNullOrEmpty(cboStatus.SelectedValue.ToString()) ? 1 : BusinessLogic.ConvertToInt(cboStatus.SelectedValue);
                currentCustomerEntity.Description = txtDescription.Text.Trim();

                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                int returnValue = customerService.Update(base.UserInfo, currentCustomerEntity, out statusCode, out statusMessage);
                string information = statusMessage;
                if (returnValue > 0)
                {
                    this.Changed = true;
                    if (currentLinkManEntity == null || currentLinkManEntity.Id <= 0)
                    {
                        currentLinkManEntity = new LinkManEntity();
                    }
                    currentLinkManEntity.CustomerId = BusinessLogic.ConvertToInt(currentCustomerId);
                    currentLinkManEntity.MainLinkMan = 1;
                    currentLinkManEntity.Name = txtName.Text.Trim();
                    currentLinkManEntity.Department = txtDepartment.Text.Trim();
                    currentLinkManEntity.Postion     = BusinessLogic.ConvertToString(cboPostion.SelectedValue);
                    currentLinkManEntity.Sex = BusinessLogic.ConvertToString(cboSex.SelectedValue);
                    currentLinkManEntity.MobilePhone = txtMobilePhone.Text.Trim();
                    currentLinkManEntity.Email = txtEmail.Text.Trim();
                    currentLinkManEntity.QQ = txtQQ.Text.Trim();
                    currentLinkManEntity.Interest = txtInterest.Text.Trim();
                    string reValue = string.Empty;
                    if (currentLinkManEntity.Id == null || currentLinkManEntity.Id <= 0)
                    {
                        reValue = linkMainService.Add(base.UserInfo,currentLinkManEntity, out statusCode, out statusMessage);
                    }
                    else
                    {
                        reValue = linkMainService.Update(base.UserInfo, currentLinkManEntity, out statusCode, out statusMessage).ToString();
                    }
                    if (BusinessLogic.ConvertToInt32(reValue) <= 0)
                    {
                        information += "\n主联系人" + statusMessage;
                    }
                }

                MessageBoxHelper.ShowInformationMsg(information);

                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;

                if (this.Changed)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentCustomerId.Trim()))
            {
                SaveData(true);
            }
            else
            {
                SaveEditData();
            }
        }

        private void btnSaveContine_Click(object sender, EventArgs e)
        {
            SaveData(false);
            BasePageLogic.EmptyControlValue(pnlMainData);
            txtFullName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                if (MessageBoxHelper.Show("确定放弃新增？") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

       
    }
}
