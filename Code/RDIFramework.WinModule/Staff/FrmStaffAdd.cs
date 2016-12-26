using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmStaffAdd
    /// 员工管理-添加员工窗体
    /// 
    /// </summary>
    public partial class FrmStaffAdd : BaseForm
    {
        /// <summary>
        /// 员工实体
        /// </summary>
        public PiStaffEntity staffEntity = null;

        /// <summary>
        /// 权限域编号（限制创建员工的范围用）
        /// </summary>
        //private string PermissionItemScopeCode = "Resource.ManagePermission";

        private string currentOrganizeId = string.Empty;
        /// <summary>
        /// 当前组织机构主键
        /// </summary>
        public string CurrentOrganizeId
        { 
            get { return this.currentOrganizeId; }
            set { this.currentOrganizeId = value; }
        }
        private string currentOrganizePath = string.Empty;
        /// <summary>
        /// 当前组织机构路径（取TreeView控件的FullPath属性值）
        /// </summary>
        public string CurrentOrganizePath
        {
            get{ return this.currentOrganizePath;}
            set{
                this.currentOrganizePath = value;
                this.lblCurrentOrganizePath.Text = this.currentOrganizePath;}
        }

        public FrmStaffAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        public FrmStaffAdd(string organizeId):this()
        {
            this.CurrentOrganizeId = organizeId;
        }

        public override void FormOnLoad()
        {
            BindCategory();
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BindCategory()
        {
            BasePageLogic.BindCategory(base.UserInfo, cboWorkingProperty, "WorkingProperty");
            BasePageLogic.BindCategory(base.UserInfo, cboEducation, "Education");
            BasePageLogic.BindCategory(base.UserInfo, cboDegree, "Degree");
            BasePageLogic.BindCategory(base.UserInfo, cboGender, "Gender");
            BasePageLogic.BindCategory(base.UserInfo, cboParty, "PoliticalStatus");
            BasePageLogic.BindCategory(base.UserInfo, cboTitle, "Title");
            BasePageLogic.BindCategory(base.UserInfo, cboTitleLevel, "TitleLevel");
            BasePageLogic.BindCategory(base.UserInfo, cboNationality, "Nationality");
        }

        #region private PiStaffEntity GetStaffEntity() 员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns>实体</returns>
        private PiStaffEntity GetStaffEntity()
        {
            var staffEntity = new PiStaffEntity
            {
                Code = this.txtCode.Text,
                RealName = this.txtRealName.Text,
                UserName = this.txtUserName.Text,
                Gender = this.cboGender.SelectedValue == null ? null : this.cboGender.SelectedValue.ToString(),
                Birthday = BusinessLogic.ConvertToNullableDateTime(this.mtxtBirthday.Text),
                Age = this.txtAge.Text.Trim(),
                IdentificationCode = this.txtIdentificationCode.Text.Trim(),
                BankCode = this.txtBankCode.Text.Trim(),
                Email = this.txtEmail.Text.Trim(),
                Mobile = this.txtMobile.Text.Trim(),
                ShortNumber = this.txtShortNumber.Text.Trim(),
                Telephone = this.txtTelphone.Text.Trim(),
                QICQ = this.txtQICQ.Text.Trim(),
                OfficePhone = this.txtOfficePhone.Text.Trim(),
                OfficeZipCode = this.txtOfficeZipCode.Text.Trim(),
                OfficeAddress = this.txtOfficeAddress.Text.Trim(),
                OfficeFax = this.txtOfficeFax.Text.Trim(),
                HomePhone = this.txtHomePhone.Text.Trim(),
                Education = this.cboEducation.SelectedValue == null ? null : this.cboEducation.SelectedValue.ToString(),
                School = this.txtSchool.Text.Trim(),
                Degree = this.cboDegree.SelectedValue == null ? null : this.cboDegree.SelectedValue.ToString(),
                Title = this.cboTitle.SelectedValue == null ? null : this.cboTitle.SelectedValue.ToString(),
                TitleDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtTitleDate.Text),
                TitleLevel =this.cboTitleLevel.SelectedValue == null ? null : this.cboTitleLevel.SelectedValue.ToString(),
                WorkingDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtWorkingDate.Text),
                JoinInDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtJoinInDate.Text),
                HomeZipCode = this.txtHomeZipCode.Text.Trim(),
                HomeAddress = this.txtHomeAddress.Text.Trim(),
                HomeFax = this.txtHomeFax.Text.Trim(),
                NativePlace = this.txtNativePlace.Text.Trim(),
                Party = this.cboParty.SelectedValue == null ? null : this.cboParty.SelectedValue.ToString(),
                Nation = this.txtNation.Text.Trim(),
                Nationality =
                    this.cboNationality.SelectedValue == null ? null : this.cboNationality.SelectedValue.ToString(),
                Major = this.txtMajor.Text.Trim(),
                WorkingProperty = this.cboWorkingProperty.SelectedValue == null
                    ? null
                    : this.cboWorkingProperty.SelectedValue.ToString(),
                IsDimission = BusinessLogic.ConvertToNullableInt(this.chkIsDimission.Checked ? 1 : 0),
                DimissionDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtDimissionDate.Text),
                DimissionCause = this.txtDimissionCause.Text.Trim(),
                DimissionWhither = this.txtDimissionWhither.Text.Trim(),
                Enabled = BusinessLogic.ConvertToNullableInt(this.chkEnabled.Checked ? 1 : 0),
                Description = this.txtDescription.Text.Trim()
            };
            return staffEntity;
        }
        #endregion

        #region private bool SaveEntity() 保存
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>保存成功</returns>
        private bool SaveEntity(bool closeForm)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var returnValue = true;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;            
            try
            {
                //
                // TODO: 在此处添加处理是否创建用户
                //
              
                string userId = string.Empty;
                
                // 再处理员工信息
                var staffEntity = this.GetStaffEntity();
                this.EntityId = RDIFrameworkService.Instance.StaffService.Add(UserInfo, staffEntity, out statusCode, out statusMessage,this.CurrentOrganizeId);
                // 添加员工的照片
                if (!string.IsNullOrEmpty(this.EntityId))
                {
                    //
                    //TODO:在此添加处理员工照片的相关代码
                    //
                   
                    this.Changed = true;
                }
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowInformationMsg(statusMessage);
                }
                if (statusCode == StatusCode.OKAdd.ToString() && closeForm)
                {
                    // 自动关闭窗体了
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
            return returnValue;
        }
        #endregion

        private void txtRealName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.txtUserName.Text = StringHelper.ToChineseSpell(this.txtRealName.Text);                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (!BasePageLogic.ControlValueIsEmpty(pnlMan)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //增加了保存成功后关闭窗体
                if (this.SaveEntity(false))
                {
                    BasePageLogic.EmptyControlValue(pnlMan);                        
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (!BasePageLogic.ControlValueIsEmpty(pnlMan)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SaveEntity(true);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
