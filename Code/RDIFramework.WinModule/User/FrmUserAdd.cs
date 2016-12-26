/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 新增对组织机构的选择
    /// 用户新增
    /// 
    /// 修改记录
    ///     2014-05-28 EricHu V2.8 增加分支机构/子公司、子部门的管理。
    ///     2014-05-07 EricHu V2.8 修改增加用户时，对用户密码进行了重复加密的问题（在服务层已经做了相应的加密处理）。
    ///     2012-05-31 EricHu 新增对组织机构的选择。
    ///     
    /// </summary>
    public partial class FrmUserAdd : BaseForm
    {
        IRoleService roleService              = RDIFrameworkService.Instance.RoleService;
        IItemDetailsService itemDetailService = RDIFrameworkService.Instance.ItemDetailsService;
        IUserService userService              = RDIFrameworkService.Instance.UserService;
        bool isAddData                        = false; //是否新增了数据（主要用于刷新主窗体）

        public FrmUserAdd()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            BindRole();
            BindGender();           
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
            DataTable dtItemDetail = itemDetailService.GetDTByCode(base.UserInfo, "Gender");
            DataRow dataRow = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            cboGender.DisplayMember = "ItemName";
            cboGender.ValueMember = "ItemValue";
            cboGender.DataSource = dtItemDetail.DefaultView;
        }
       
        //private void BindCatalog()
        //{
        //    DataTable dtTemp = itemDetailService.GetDTByCode(base.UserInfo, "OrganizeCategory");

        //    if (dtTemp != null && dtTemp.Rows.Count > 0)
        //    {
        //        foreach (DataRow dataRow in dtTemp.Rows)
        //        {
        //            string[] names = { PiOrganizeTable.FieldCategory, PiOrganizeTable.FieldEnabled, PiOrganizeTable.FieldDeleteMark };
        //            string tempCategory = string.Empty;
        //            RDIFramework.Controls.UcComboBoxEx ucCombo = null;
        //            switch (dataRow[CiItemDetailsTable.FieldItemValue].ToString().Trim().ToLower())
        //            {
        //                case "company":
        //                    tempCategory = "Company";
        //                    ucCombo = cboCompanyName;
        //                    break;
        //                case "subcompany":
        //                    tempCategory = "SubCompany";
        //                    ucCombo = cboSubCompanyName;
        //                    break;
        //                case "department":
        //                    tempCategory = "Department";
        //                    ucCombo = cboDepartmentName;
        //                    break;
        //                case "subdepartment":
        //                    tempCategory = "SubDepartment";
        //                    break;
        //                case "workgroup":
        //                    tempCategory = "WorkGroup";
        //                    ucCombo = cboWorkgroupName;
        //                    break;
        //            }

        //            if (ucCombo != null)
        //            {
        //                string[] values = { tempCategory, "1", "0" };
        //                DataTable dtTempCompay = RDIFrameworkService.Instance.OrganizeService.GetDTByValues(base.UserInfo, names, values);
        //                DataRow dataRownew = dtTempCompay.NewRow();
        //                dtTempCompay.Rows.InsertAt(dataRownew, 0);
        //                ucCombo.DisplayMember = PiOrganizeTable.FieldFullName;
        //                ucCombo.ValueMember = PiOrganizeTable.FieldId;
        //                ucCombo.DataSource = dtTempCompay.DefaultView;
        //            }
        //        }
        //    }
        //}
        #endregion      

        #region public override bool SaveEntity():保存数据
        public override bool SaveEntity()
        {
            var userEntity = new PiUserEntity
            {
                Code = txtCode.Text.Trim(),
                UserName = txtUserName.Text.Trim(),
                RealName = txtRealName.Text.Trim(),
                Enabled = chkEnabled.Checked ? 1 : 0,
                Gender = cboGender.Text.Trim(),
                Mobile = txtMobile.Text.Trim(),
                QICQ = txtQQ.Text.Trim(),
                Telephone = txtTelphone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Birthday = BusinessLogic.ConvertToNullableDateTime(txtBirthday.Text),
                Duty = txtDuty.Text.Trim(),
                Title = txtTitle.Text.Trim(),
                QuickQuery = StringHelper.ToChineseSpell(txtRealName.Text.Trim()),
                HomeAddress = txtHomeAddress.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DeleteMark = 0,
                IsVisible = 1
            };

            var roleId = string.Empty;
            userEntity.RoleId = this.cboRoleName.SelectedValue != null &&this.cboRoleName.SelectedValue.ToString().Length > 0 ? BusinessLogic.ConvertToString(this.cboRoleName.SelectedValue): null;
            if (!string.IsNullOrEmpty(this.ucOSCompanyName.SelectedId))
            {
                userEntity.CompanyId = this.ucOSCompanyName.SelectedId;
                userEntity.CompanyName = this.ucOSCompanyName.SelectedFullName;
            }
            else
            {
                userEntity.CompanyId = null;
                userEntity.CompanyName = null;
            }

            if (!string.IsNullOrEmpty(this.ucOSSubCompanyName.SelectedId))
            {
                userEntity.SubCompanyId = this.ucOSSubCompanyName.SelectedId;
                userEntity.SubCompanyName = this.ucOSSubCompanyName.SelectedFullName;
            }
            else
            {
                userEntity.SubCompanyId = null;
                userEntity.SubCompanyName = null;
            }

            if (!string.IsNullOrEmpty(this.ucOSDepartmentName.SelectedId))
            {
                userEntity.DepartmentId = this.ucOSDepartmentName.SelectedId;
                userEntity.DepartmentName = this.ucOSDepartmentName.SelectedFullName;
            }
            else
            {
                userEntity.DepartmentId = null;
                userEntity.DepartmentName = null;
            }

            if (!string.IsNullOrEmpty(this.ucOSSubDepartmentName.SelectedId))
            {
                userEntity.SubDepartmentId = this.ucOSSubDepartmentName.SelectedId;
                userEntity.SubDepartmentName = this.ucOSSubDepartmentName.SelectedFullName;
            }
            else
            {
                userEntity.SubDepartmentId = null;
                userEntity.SubDepartmentName = null;
            }

            if (!string.IsNullOrEmpty(this.ucOSWorkgroupName.SelectedId))
            {
                userEntity.WorkgroupId = this.ucOSWorkgroupName.SelectedId;
                userEntity.WorkgroupName = this.ucOSWorkgroupName.SelectedFullName;
            }
            else
            {
                userEntity.WorkgroupId = null;
                userEntity.WorkgroupName = null;
            }

      
            userEntity.UserPassword = txtUserPassword.Text.Trim();

            //if (SystemInfo.EnableEncryptServerPassword) //在服务层已经做了此判断，不能重复加密 
            //{
            //    userEntity.UserPassword = string.IsNullOrEmpty(userEntity.UserPassword) ? SecretHelper.AESEncrypt(SystemInfo.DefaultPassword):SecretHelper.AESEncrypt(userEntity.UserPassword);
            //}
           
            userEntity.UserPassword = string.IsNullOrEmpty(userEntity.UserPassword) ?SystemInfo.DefaultPassword : userEntity.UserPassword;
           

            if (UserInfo != null)
            {
                userEntity.CreateBy = UserInfo.RealName;
                userEntity.CreateUserId = UserInfo.Id;
            }

            var returnValue = false;           

            try
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                var holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                string statusCode = string.Empty;
                string statusMessage = string.Empty;
                //增加用户
                this.EntityId = RDIFrameworkService.Instance.UserService.AddUser(UserInfo, userEntity, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKAdd.ToString())
                {
                    if (SystemInfo.ShowInformation)
                    {
                        // 添加成功，进行提示
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
                    }
                    this.Changed = true;
                    this.DialogResult = DialogResult.OK;
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
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
                return returnValue;
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

            return returnValue;
           
        }
        #endregion       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isAddData)
            {
                (this.Owner as BaseForm).RefreshForm();
            }

            this.Close();
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbDetail)) return;
            if (this.SaveEntity())
            {
                isAddData = true;
                this.Changed = true;
                BasePageLogic.EmptyControlValue(gbDetail);
                txtUserName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbDetail)) return;
            
            if (this.SaveEntity())
            {
                this.Changed = true;
                (this.Owner as BaseForm).RefreshForm();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }
    }
}
