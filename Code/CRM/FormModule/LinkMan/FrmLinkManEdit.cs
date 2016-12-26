using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmLinkManEdit : BaseForm
    {
        ILinkManService linkMainService = null;
        private LinkManEntity currentLinkManEntity = null;
        private string currentCustomerId = string.Empty; //当前客户Id
        private string currentLinkManId  = string.Empty;//当前联系人Id【主要用户修改用户】
        private string currentLinkManName = string.Empty;//当前联系人名称【主要用户修改用户】

        public FrmLinkManEdit(string customerId)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(customerId.Trim()))
            {
                MessageBoxHelper.ShowErrorMsg("客户主键不能为空！");
                return;
            }
            currentCustomerId = customerId;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="customerId">当前客户Id</param>
        public FrmLinkManEdit(string customerId,string linkManId,string linkManName)
            :this(customerId)           
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(linkManId.Trim()))
            {
                MessageBoxHelper.ShowErrorMsg("请选择待修改的联系人！");
                return;
            }
            currentLinkManId = linkManId;
            currentLinkManName = linkManName;
        }


        public override void FormOnLoad()
        {
            linkMainService      = new LinkManService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));
            
            BindCategory();
            this.Text = "新增联系人";
            if (!string.IsNullOrEmpty(currentLinkManId))
            {
                this.btnSaveContine.Visible = false;
                this.Text = "编辑联系人 - " + currentLinkManName;
                BindEditData();
            }
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BindCategory()
        {
            BasePageLogic.BindCategory(base.UserInfo, cboSex, "Gender");
            BasePageLogic.BindCategory(base.UserInfo, cboPostion, "Duty");
            BasePageLogic.BindCategory(base.UserInfo, cboEducationalBackground, "Education");
            BasePageLogic.BindCategory(base.UserInfo, cboDegree, "Degree");
            BasePageLogic.BindCategory(base.UserInfo, cboParty, "PoliticalStatus");
            BasePageLogic.BindCategory(base.UserInfo, cboBloodType, "BloodType");
        }

        private void BindEditData()
        {
            if (!string.IsNullOrEmpty(currentLinkManId.Trim()))
            {
                currentLinkManEntity   = linkMainService.GetEntity(base.UserInfo, currentLinkManId);
                txtName.Text           = currentLinkManEntity.Name;
                chkMainLinkMan.Checked = BusinessLogic.ConvertIntToBoolean(currentLinkManEntity.MainLinkMan);
                cboSex.SelectedValue   = currentLinkManEntity.Sex;
                cboPostion.SelectedValue = currentLinkManEntity.Postion;
                txtDepartment.Text = currentLinkManEntity.Department;
                txtMobilePhone.Text = currentLinkManEntity.MobilePhone;
                txtTelephone.Text = currentLinkManEntity.Telephone;
                txtHomePhone.Text = currentLinkManEntity.HomePhone;
                txtOfficeFax.Text = currentLinkManEntity.OfficeFax;
                txtIDCard.Text = currentLinkManEntity.IDCard;
                txtOfficeAddress.Text = currentLinkManEntity.OfficeAddress;
                txtQQ.Text = currentLinkManEntity.QQ;
                txtEmail.Text = currentLinkManEntity.Email;
                txtInterest.Text = currentLinkManEntity.Interest;
                txtDescription.Text = currentLinkManEntity.Description;
                txtMajor.Text = currentLinkManEntity.Major;
                txtSchool.Text = currentLinkManEntity.School;
                cboEducationalBackground.SelectedValue = currentLinkManEntity.EducationalBackground;
                cboDegree.SelectedValue = currentLinkManEntity.Degree;
                txtHomeZipCode.Text = currentLinkManEntity.HomeZipCode;
                txtHomeFax.Text = currentLinkManEntity.HomeFax;
                txtHomeAddress.Text = currentLinkManEntity.HomeAddress;
                txtNation.Text = currentLinkManEntity.Nation;
                cboParty.SelectedValue = currentLinkManEntity.Party;
                txtNativePlace.Text = currentLinkManEntity.NativePlace;
                txtNationality.Text = currentLinkManEntity.Nationality;
                cboBloodType.SelectedValue = currentLinkManEntity.BloodType;
                if (currentLinkManEntity.BirthdayType == 1)
                {
                    radGregorianCalendar.Checked = true;
                }
                else
                {
                    radLunarCalendar.Checked = true;
                }
                dtBirthday.Text = BusinessLogic.ConvertToDateToString(currentLinkManEntity.Birthday == null ? string.Empty : currentLinkManEntity.Birthday.ToString());
            }
        }

        #region private void SaveData(bool close) 保存新增的数据
        private void SaveData(bool close)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(txtName.Tag.ToString() + "不能为空！");
                txtName.Focus();
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            LinkManEntity linkManEntity = new LinkManEntity
            {
                CustomerId = BusinessLogic.ConvertToInt(currentCustomerId),
                Name = txtName.Text.Trim(),
                MainLinkMan = chkMainLinkMan.Checked ? 1 : 0,
                Sex = cboSex.SelectedValue.ToString(),
                Postion = cboPostion.SelectedValue.ToString(),
                Department = txtDepartment.Text.Trim(),
                MobilePhone = txtMobilePhone.Text.Trim(),
                Telephone = txtTelephone.Text.Trim(),
                HomePhone = txtHomePhone.Text.Trim(),
                OfficeFax = txtOfficeFax.Text.Trim(),
                IDCard = txtIDCard.Text.Trim(),
                OfficeAddress = txtOfficeAddress.Text.Trim(),
                QQ = txtQQ.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Interest = txtInterest.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Major = txtMajor.Text.Trim(),
                School = txtSchool.Text.Trim(),
                EducationalBackground = cboEducationalBackground.SelectedValue.ToString(),
                Degree = cboDegree.SelectedValue.ToString(),
                HomeZipCode = txtHomeZipCode.Text.Trim(),
                HomeFax = txtHomeFax.Text.Trim(),
                HomeAddress = txtHomeAddress.Text.Trim(),
                NativePlace = txtNativePlace.Text.Trim(),
                Party = cboParty.SelectedValue.ToString(),
                Nation = txtNation.Text.Trim(),
                Nationality = txtNationality.Text.Trim(),
                BloodType = cboBloodType.SelectedValue.ToString(),
                BirthdayType = 1
            };

            if (radLunarCalendar.Checked)
            {
                linkManEntity.BirthdayType = 2; //农历生日
            }
            linkManEntity.Birthday = BusinessLogic.ConvertToDateTime(dtBirthday.Text);
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            string linkManId = linkMainService.Add(base.UserInfo, linkManEntity, out statusCode, out statusMessage);
            if (linkManId.Trim().Length > 0)
            {
                this.Changed = true;
            }
            MessageBoxHelper.ShowInformationMsg(statusMessage);
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (this.Changed && close)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        private bool SaveEditData()
        {
            bool returnValue = false;           

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentLinkManEntity.CustomerId = BusinessLogic.ConvertToInt(currentCustomerId);
            currentLinkManEntity.Name = txtName.Text.Trim();
            currentLinkManEntity.MainLinkMan = chkMainLinkMan.Checked ? 1 : 0;
            currentLinkManEntity.Sex = BusinessLogic.ConvertToString(cboSex.SelectedValue);
            currentLinkManEntity.Postion = BusinessLogic.ConvertToString(cboPostion.SelectedValue);
            currentLinkManEntity.Department = txtDepartment.Text.Trim();
            currentLinkManEntity.MobilePhone = txtMobilePhone.Text.Trim();
            currentLinkManEntity.Telephone = txtTelephone.Text.Trim();
            currentLinkManEntity.HomePhone = txtHomePhone.Text.Trim();
            currentLinkManEntity.OfficeFax = txtOfficeFax.Text.Trim();
            currentLinkManEntity.IDCard = txtIDCard.Text.Trim();
            currentLinkManEntity.OfficeAddress = txtOfficeAddress.Text.Trim();
            currentLinkManEntity.QQ = txtQQ.Text.Trim();
            currentLinkManEntity.Email = txtEmail.Text.Trim();
            currentLinkManEntity.Interest = txtInterest.Text.Trim();
            currentLinkManEntity.Description = txtDescription.Text.Trim();

            currentLinkManEntity.Major = txtMajor.Text.Trim();
            currentLinkManEntity.School = txtSchool.Text.Trim();
            currentLinkManEntity.EducationalBackground = BusinessLogic.ConvertToString(cboEducationalBackground.SelectedValue);
            currentLinkManEntity.Degree = BusinessLogic.ConvertToString(cboDegree.SelectedValue);
            currentLinkManEntity.HomeZipCode = txtHomeZipCode.Text.Trim();
            currentLinkManEntity.HomeFax = txtHomeFax.Text.Trim();
            currentLinkManEntity.HomeAddress = txtHomeAddress.Text.Trim();
            currentLinkManEntity.NativePlace = txtNativePlace.Text.Trim();
            currentLinkManEntity.Party = BusinessLogic.ConvertToString(cboParty.SelectedValue);
            currentLinkManEntity.Nation = txtNation.Text.Trim();
            currentLinkManEntity.Nationality = txtNationality.Text.Trim();
            currentLinkManEntity.BloodType = BusinessLogic.ConvertToString(cboBloodType.SelectedValue);
            currentLinkManEntity.BirthdayType = 1; //公历生日（默认）
            if (radLunarCalendar.Checked)
            {
                currentLinkManEntity.BirthdayType = 2; //农历生日
            }
            currentLinkManEntity.Birthday = BusinessLogic.ConvertToNullableDateTime(dtBirthday.Text);

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            int success = linkMainService.Update(base.UserInfo, currentLinkManEntity, out statusCode, out statusMessage);
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                returnValue = true;
                this.Changed = true;
                MessageBoxHelper.ShowSuccessMsg(statusMessage);
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                returnValue = false;
            }

            return returnValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(txtName.Tag.ToString() + "不能为空！");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(currentLinkManId.Trim()))
            {
                SaveData(true);
            }
            else
            {
                if (SaveEditData())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }                
            }
        }

        private void btnSaveContine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(txtName.Tag.ToString() + "不能为空！");
                txtName.Focus();
                return;
            }

            SaveData(false);
            BasePageLogic.EmptyControlValue(pnlMain);
            txtNation.Text = "中国";
            txtNationality.Text = "汉族";
            txtName.Focus();
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
