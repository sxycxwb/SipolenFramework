/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:57:56
 ******************************************************************************/
using System;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;
  

    /// <summary>
    /// FrmUserDimission
    /// 用户编辑
    /// 
    /// 修改记录
    ///     2012-05-31 EricHu 新增对组织机构的选择。
    ///     
    /// </summary>
    public partial class FrmUserDimission : BaseForm
    {
        PiUserEntity currentUserEntity        = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmUserDimission(string id) 
        {
            InitializeComponent();
            this.EntityId = id;
        }      

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty(this.EntityId))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
                return;
            }
            this.currentUserEntity = RDIFrameworkService.Instance.UserService.GetEntity(UserInfo, this.EntityId);
            if (currentUserEntity == null)
            {
                return;
            }
            BindRole();
            ShowEntity();
        }

        private void BindRole()
        {
            var dtRole = RDIFrameworkService.Instance.RoleService.GetDTByValues(base.UserInfo, new string[] { "DeleteMark", "Enabled" }, new string[] { "0", "1" });
            var dataRow = dtRole.NewRow();
            dtRole.Rows.InsertAt(dataRow, 0);
            cboRoleName.DisplayMember = "RealName";
            cboRoleName.ValueMember = "Id";
            cboRoleName.DataSource = dtRole.DefaultView;
        }

        public override void ShowEntity()
        {
            txtUserName.Text                 = currentUserEntity.UserName;
            txtRealName.Text                 = currentUserEntity.RealName;
            txtDuty.Text                     = currentUserEntity.Duty;
            txtTitle.Text                    = currentUserEntity.Title;
            txtDimissionCause.Text           = currentUserEntity.DimissionCause;
            txtDimissionWhither.Text         = currentUserEntity.DimissionWhither;
            chkIsDimission.Checked           = BusinessLogic.ConvertIntToBoolean(currentUserEntity.IsDimission);
            if (currentUserEntity.DimissionDate != null)
            {
                dtDimissionDate.Text = DateTimeHelper.FormatDate(currentUserEntity.DimissionDate.ToString());
            }

            if (currentUserEntity.RoleId != null)
            {
                cboRoleName.SelectedValue = currentUserEntity.RoleId;
            }

            ucOSCompanyName.SelectedId = string.IsNullOrEmpty(currentUserEntity.CompanyId) ? "" : currentUserEntity.CompanyId;
            ucOSDepartmentName.SelectedId = string.IsNullOrEmpty(currentUserEntity.DepartmentId) ? "" : currentUserEntity.DepartmentId;
        }

        public override bool CheckInput()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(txtDimissionCause.Text))
            {
                returnValue = false;
                MessageBoxHelper.ShowErrorMsg("离职原因不能为空!");
            }

            return returnValue;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            int returnValue =  RDIFrameworkService.Instance.LogOnService.UserDimission(this.UserInfo, this.txtUserName.Text.Trim(),txtDimissionCause.Text.Trim(), BusinessLogic.ConvertToNullableDateTime(dtDimissionDate.Text),txtDimissionWhither.Text.Trim());
            if (returnValue > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG3010);
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG3020);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
