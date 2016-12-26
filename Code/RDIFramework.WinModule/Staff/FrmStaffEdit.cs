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
    public partial class FrmStaffEdit : BaseForm
    {
        /// <summary>
        /// 员工实体
        /// </summary>
        public PiStaffEntity staffEntity = null;

        /// <summary>
        /// 权限域编号（限制创建员工的范围用）
        /// </summary>
        //private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 员工主键
        /// </summary>
        public string StaffId = string.Empty;

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

        public FrmStaffEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">组织机构主键</param>
        public FrmStaffEdit(string id)
            :this()       
        {
            this.StaffId = id;
        }

        public override void FormOnLoad()
        {
            this.staffEntity = RDIFrameworkService.Instance.StaffService.GetEntity(base.UserInfo, this.StaffId);
            BindCategory();
            // 显示内容
            this.ShowStaffEntity();
        }

        #region private void ShowStaffEntity() 显示内容
        /// <summary>
        /// 显示员工内容
        /// </summary>
        private void ShowStaffEntity()
        {
            if (this.staffEntity.Id == null)
            {
                return;
            }
            txtRealName.Text            = staffEntity.RealName;
            txtUserName.Text            = staffEntity.UserName;
            txtCode.Text                = staffEntity.Code;
            cboGender.Text              = staffEntity.Gender;
            cboWorkingProperty.Text     = staffEntity.WorkingProperty;
            mtxtWorkingDate.Text        = staffEntity.WorkingDate == null ? string.Empty : DateTimeHelper.FormatDate(staffEntity.WorkingDate.ToString());
            mtxtJoinInDate.Text         = staffEntity.JoinInDate == null ? string.Empty : DateTimeHelper.FormatDate(staffEntity.JoinInDate.ToString());
            txtEmail.Text               = staffEntity.Email;
            txtIdentificationCode.Text  = staffEntity.IdentificationCode;
            txtBankCode.Text            = staffEntity.BankCode;
            txtMobile.Text              = staffEntity.Mobile;
            txtShortNumber.Text         = staffEntity.ShortNumber;
            txtOfficePhone.Text         = staffEntity.OfficePhone;
            txtOfficeFax.Text           = staffEntity.OfficeFax;
            txtOfficeZipCode.Text       = staffEntity.OfficeZipCode;
            txtQICQ.Text                = staffEntity.QICQ;
            txtOfficeAddress.Text       = staffEntity.OfficeAddress;
            txtDescription.Text         = staffEntity.Description;
            mtxtBirthday.Text           = staffEntity.Birthday == null ? string.Empty : DateTimeHelper.FormatDate(staffEntity.Birthday.ToString());
            txtAge.Text                 = staffEntity.Age;
            cboEducation.Text           = staffEntity.Education;
            cboDegree.Text              = staffEntity.Degree;
            txtMajor.Text               = staffEntity.Major;
            txtSchool.Text              = staffEntity.School;
            cboTitle.Text               = staffEntity.Title;
            cboTitleLevel.Text          = staffEntity.TitleLevel;
            mtxtTitleDate.Text          = staffEntity.TitleDate == null ? string.Empty : DateTimeHelper.FormatDate(staffEntity.TitleDate.ToString());
            txtNativePlace.Text         = staffEntity.NativePlace;
            txtHomeZipCode.Text         = staffEntity.HomeZipCode;
            txtHomeFax.Text             = staffEntity.HomeFax;
            cboParty.Text               = staffEntity.Party;
            txtNation.Text              = staffEntity.Nation;
            cboNationality.Text         = staffEntity.Nationality;
            txtHomeAddress.Text         = staffEntity.HomeAddress;
            txtHomePhone.Text           = staffEntity.HomePhone;
            txtTelphone.Text            = staffEntity.Telephone;
            chkEnabled.Checked          = BusinessLogic.ConvertIntToBoolean(staffEntity.Enabled);
            chkIsDimission.Checked      = BusinessLogic.ConvertIntToBoolean(staffEntity.IsDimission);
            mtxtDimissionDate.Text      = staffEntity.DimissionDate == null ? string.Empty : DateTimeHelper.FormatDate(staffEntity.DimissionDate.ToString());
            txtDimissionCause.Text      = staffEntity.DimissionCause;
            txtDimissionWhither.Text    = staffEntity.DimissionWhither;
        }
        #endregion

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
            staffEntity.Code = this.txtCode.Text;
            staffEntity.RealName = this.txtRealName.Text;
            staffEntity.UserName = this.txtUserName.Text;
            staffEntity.Gender = this.cboGender.SelectedValue == null ? null : this.cboGender.SelectedValue.ToString();
            staffEntity.Birthday = BusinessLogic.ConvertToNullableDateTime(this.mtxtBirthday.Text);
            staffEntity.Age = this.txtAge.Text.Trim();
            staffEntity.IdentificationCode = this.txtIdentificationCode.Text.Trim();
            staffEntity.BankCode = this.txtBankCode.Text.Trim();
            staffEntity.Email = this.txtEmail.Text.Trim();
            staffEntity.Mobile = this.txtMobile.Text.Trim();
            staffEntity.ShortNumber = this.txtShortNumber.Text.Trim();
            staffEntity.Telephone = this.txtTelphone.Text.Trim();
            staffEntity.QICQ = this.txtQICQ.Text.Trim();
            staffEntity.OfficePhone = this.txtOfficePhone.Text.Trim();
            staffEntity.OfficeZipCode = this.txtOfficeZipCode.Text.Trim();
            staffEntity.OfficeAddress = this.txtOfficeAddress.Text.Trim();
            staffEntity.OfficeFax = this.txtOfficeFax.Text.Trim();
            staffEntity.HomePhone = this.txtHomePhone.Text.Trim();
            staffEntity.Education = this.cboEducation.SelectedValue == null ? null : this.cboEducation.SelectedValue.ToString();
            staffEntity.School = this.txtSchool.Text.Trim();
            staffEntity.Degree = this.cboDegree.SelectedValue == null ? null : this.cboDegree.SelectedValue.ToString();
            staffEntity.Title = this.cboTitle.SelectedValue == null ? null : this.cboTitle.SelectedValue.ToString();
            staffEntity.TitleDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtTitleDate.Text);
            staffEntity.TitleLevel = this.cboTitleLevel.SelectedValue == null ? null : this.cboTitleLevel.SelectedValue.ToString();
            staffEntity.WorkingDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtWorkingDate.Text);
            staffEntity.JoinInDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtJoinInDate.Text);
            staffEntity.HomeZipCode = this.txtHomeZipCode.Text.Trim();
            staffEntity.HomeAddress = this.txtHomeAddress.Text.Trim();
            staffEntity.HomeFax = this.txtHomeFax.Text.Trim();
            staffEntity.NativePlace = this.txtNativePlace.Text.Trim();
            staffEntity.Party = this.cboParty.SelectedValue == null ? null : this.cboParty.SelectedValue.ToString();
            staffEntity.Nation = this.txtNation.Text.Trim();
            staffEntity.Nationality = this.cboNationality.SelectedValue == null ? null : this.cboNationality.SelectedValue.ToString();
            staffEntity.Major = this.txtMajor.Text.Trim();
            staffEntity.WorkingProperty = this.cboWorkingProperty.SelectedValue == null ? null : this.cboWorkingProperty.SelectedValue.ToString();
            staffEntity.IsDimission = BusinessLogic.ConvertToNullableInt(this.chkIsDimission.Checked ? 1 : 0);
            staffEntity.DimissionDate = BusinessLogic.ConvertToNullableDateTime(this.mtxtDimissionDate.Text);
            staffEntity.DimissionCause = this.txtDimissionCause.Text.Trim();
            staffEntity.DimissionWhither = this.txtDimissionWhither.Text.Trim();
            staffEntity.Enabled = BusinessLogic.ConvertToNullableInt(this.chkEnabled.Checked ? 1 : 0);
            staffEntity.Description = this.txtDescription.Text.Trim();
            return staffEntity;
        }
        #endregion

        #region private bool SaveEntity() 保存
        /// <summary>
        /// 保存数据
        /// </summary>
        private bool SaveEntity()
        {        
            var returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;         
           
            //
            // TODO: 在此处添加处理是否创建用户
            //              
            string userId = string.Empty;
            if (this.chkIsDimission.Checked != BusinessLogic.ConvertIntToBoolean(this.staffEntity.IsDimission) && chkIsDimission.Checked)
            {               
                if (MessageBoxHelper.Show("确定该员工离职吗？") == System.Windows.Forms.DialogResult.No)
                {
                    chkIsDimission.Checked = false;
                }

                if (chkIsDimission.Checked &&!DateTimeHelper.IsDate(mtxtDimissionDate.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("对于离职员工，离职日期不能为空！");
                    mtxtDimissionDate.Focus();
                    return false;
                }
            }
                
            // 再处理员工信息
            var staffEntity = this.GetStaffEntity();
            RDIFrameworkService.Instance.StaffService.UpdateStaff(UserInfo, staffEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                //
                //TODO:在此添加处理员工照片的相关代码
                //
                   
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
                if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    this.txtRealName.SelectAll();
                    this.txtRealName.Focus();
                }
            }           
            return returnValue;
        }
        #endregion
   
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (!BasePageLogic.ControlValueIsEmpty(pnlMan)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.SaveEntity())
                {
                    // 关闭窗口
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
