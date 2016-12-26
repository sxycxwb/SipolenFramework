/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
  

    /// <summary>
    /// FrmUserEdit
    /// 用户编辑
    /// 
    /// 修改记录
    ///     2012-05-31 EricHu 新增对组织机构的选择。
    ///     
    /// </summary>
    public partial class FrmUserUpdate : BaseEditForm
    {
        List<DataRow> listDataRow             = new List<DataRow>();
        IUserService userService              = RDIFrameworkService.Instance.UserService;
        IRoleService roleService              = RDIFrameworkService.Instance.RoleService;
        IItemDetailsService itemDetailService = RDIFrameworkService.Instance.ItemDetailsService;
        PiUserEntity currentUserEntity        = null;
        DataTable dtUser = new DataTable();

        public FrmUserUpdate(DataTable dt)
        {
            InitializeComponent();
            dtUser = dt;
        }

        public override void FormOnLoad()
        {
            //if (listDataRow.Count <= 0)
            //{
            //    return;
            //}
            this.SetAddButtonVisible = false;
            BindRole();
            BindGender();
            DisplayData();
        }

        public override void DisplayData()
        {
            currentUserEntity = null;
            currentUserEntity = new PiUserEntity();
            currentUserEntity = BaseEntity.Create<PiUserEntity>(dtUser.Select(PiUserTable.FieldId + "='" + this.EntityId + "'")[0]);
            txtUserName.Text = currentUserEntity.UserName;
            txtRealName.Text = currentUserEntity.RealName;
            txtCode.Text = currentUserEntity.Code;
            cboGender.Text = currentUserEntity.Gender;
            txtMobile.Text = currentUserEntity.Mobile;
            txtBirthday.Text = DateTimeHelper.FormatDate(currentUserEntity.Birthday.ToString());
            txtTelphone.Text = currentUserEntity.Telephone;
            txtDuty.Text = currentUserEntity.Duty;
            txtTitle.Text = currentUserEntity.Title;
            txtQQ.Text = currentUserEntity.QICQ;
            txtEmail.Text = currentUserEntity.Email;
            chkEnabled.Checked = BusinessLogic.ConvertIntToBoolean(currentUserEntity.Enabled);
            cboRoleName.SelectedValue = currentUserEntity.RoleId ?? null;
            ucOSCompanyName.SelectedId = string.IsNullOrEmpty(currentUserEntity.CompanyId) ? "" : currentUserEntity.CompanyId;
            ucOSSubCompanyName.SelectedId = string.IsNullOrEmpty(currentUserEntity.SubCompanyId) ? "" : currentUserEntity.SubCompanyId;
            ucOSDepartmentName.SelectedId = string.IsNullOrEmpty(currentUserEntity.DepartmentId) ? "" : currentUserEntity.DepartmentId;
            ucOSSubDepartmentName.SelectedId = string.IsNullOrEmpty(currentUserEntity.SubDepartmentId) ? "" : currentUserEntity.SubDepartmentId;
            ucOSWorkgroupName.SelectedId = string.IsNullOrEmpty(currentUserEntity.WorkgroupId) ? "" : currentUserEntity.WorkgroupId;           
            txtHomeAddress.Text = currentUserEntity.HomeAddress;
            txtDescription.Text = currentUserEntity.Description;
        }

        public override void ClearScreen()
        {
            BasePageLogic.EmptyControlValue(gbDetail);
        }

        public override bool SaveUpdated()
        {
            var returnValue = false;
            var userEntity = currentUserEntity;
            if (!BasePageLogic.ControlValueIsEmpty(gbDetail)) 
                return returnValue;
            
            userEntity.Id                = currentUserEntity.Id;
            userEntity.UserName          = txtUserName.Text.Trim();
            userEntity.RealName          = txtRealName.Text.Trim();
            userEntity.Code              = txtCode.Text.Trim();
            userEntity.Gender            = cboGender.Text;
            userEntity.Mobile            = txtMobile.Text.Trim();
            userEntity.Birthday          = DateTimeHelper.ToDate(txtBirthday.Text);
            userEntity.Telephone         = txtTelphone.Text.Trim();
            userEntity.Title             = txtTitle.Text.Trim();
            userEntity.Duty              = txtDuty.Text.Trim();
            userEntity.QICQ              = txtQQ.Text.Trim();
            userEntity.Email             = txtEmail.Text.Trim();
            userEntity.Enabled           = chkEnabled.Checked ? 1 : 0;
            userEntity.RoleId            = BusinessLogic.ConvertToString(BasePageLogic.GetComboSelectedValue(cboRoleName, BasePageLogic.ComboBoxValueType.SelectValue));
            userEntity.CompanyId         = string.IsNullOrEmpty(ucOSCompanyName.SelectedId) ? null : ucOSCompanyName.SelectedId;
            userEntity.CompanyName       = string.IsNullOrEmpty(ucOSCompanyName.SelectedId) ? null : ucOSCompanyName.SelectedFullName;
            userEntity.SubCompanyId      = string.IsNullOrEmpty(ucOSSubCompanyName.SelectedId) ? null : ucOSSubCompanyName.SelectedId;
            userEntity.SubCompanyName    = string.IsNullOrEmpty(ucOSSubCompanyName.SelectedId) ? null : ucOSSubCompanyName.SelectedFullName;
            userEntity.DepartmentId      = string.IsNullOrEmpty(ucOSDepartmentName.SelectedId) ? null : ucOSDepartmentName.SelectedId;
            userEntity.DepartmentName    = string.IsNullOrEmpty(ucOSDepartmentName.SelectedId) ? null : ucOSDepartmentName.SelectedFullName;
            userEntity.SubDepartmentId   = string.IsNullOrEmpty(ucOSSubDepartmentName.SelectedId) ? null : ucOSSubDepartmentName.SelectedId;
            userEntity.SubDepartmentName = string.IsNullOrEmpty(ucOSSubDepartmentName.SelectedId) ? null : ucOSSubDepartmentName.SelectedFullName;
            userEntity.WorkgroupId       = string.IsNullOrEmpty(ucOSWorkgroupName.SelectedId) ? null : ucOSWorkgroupName.SelectedId;
            userEntity.WorkgroupName     = string.IsNullOrEmpty(ucOSWorkgroupName.SelectedId) ? null : ucOSWorkgroupName.SelectedFullName;                
            userEntity.HomeAddress       = txtHomeAddress.Text.Trim();
            userEntity.Description       = txtDescription.Text.Trim();

            if (base.UserInfo != null)
            {
                userEntity.ModifiedBy    = UserInfo.RealName;
                userEntity.ModifiedUserId  = UserInfo.Id;
            }
               
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            userService.UpdateUser(UserInfo, userEntity,out statusCode,out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                returnValue = true;                     
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                if (statusCode == StatusCode.ErrorUserExist.ToString())
                {
                    this.txtUserName.SelectAll();
                    this.txtUserName.Focus();
                }
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
                returnValue = false;
            }

            return returnValue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        #region 绑定下拉列表
        private void BindRole()
        {
            var dtRole = roleService.GetDTByValues(base.UserInfo, new string[] { "DeleteMark", "Enabled" }, new string[] { "0", "1" });
            var dataRow = dtRole.NewRow();
            dtRole.Rows.InsertAt(dataRow, 0);
            cboRoleName.DisplayMember = "RealName";
            cboRoleName.ValueMember = "Id";
            cboRoleName.DataSource = dtRole.DefaultView;
        }

        private void BindGender()
        {
            var dtItemDetail = itemDetailService.GetDTByCode(base.UserInfo, "Gender");
            var dataRow = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            cboGender.DisplayMember = "ItemName";
            cboGender.ValueMember = "ItemValue";
            cboGender.DataSource = dtItemDetail.DefaultView;
        }      
        #endregion
    }
}
