/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-13 17:22:03
 ******************************************************************************/

using System;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmEditRole
    /// 角色编辑界面（新增、修改等）。
    /// 
    /// 修改记录
    /// </summary>
    public partial class FrmEditRole : BaseForm
    {
        IItemDetailsService itemDetailService = RDIFrameworkService.Instance.ItemDetailsService;
        IRoleService roleService = RDIFrameworkService.Instance.RoleService;
        PiRoleEntity roleEntity = null;
        PiRoleEntity currentRoleEntity = null;
        bool isAdd = true; //为true:增加数据,false:修改数据

        public FrmEditRole()
        {
            InitializeComponent();
        }

        public FrmEditRole(string id)
        {
            InitializeComponent();
            this.EntityId = id;
        }

        public override void FormOnLoad()
        {
            BindCategory();

            if (!string.IsNullOrEmpty(this.EntityId))
            {
                this.btnAdd.Visible = false;
                isAdd = false;
                this.ShowEntity();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain) && this.SaveEntity())
            {
                this.Changed = true;
                BasePageLogic.EmptyControlValue(pnlMain);
                txtRealName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(pnlMain)) return;
            
            if (this.isAdd) //增加数据
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else //修改数据
            {
                if (this.SaveEditData())
                {
                    this.Changed = true;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

        public override void ShowEntity()
        {
            currentRoleEntity = roleService.GetEntity(base.UserInfo, this.EntityId);
            if (currentRoleEntity != null && currentRoleEntity.RealName.Trim().Length > 0)
            {
                txtCode.Text              = currentRoleEntity.Code;
                txtRealName.Text          = currentRoleEntity.RealName;
                txtDescription.Text       = currentRoleEntity.Description;
                cboCategory.SelectedValue = currentRoleEntity.Category;
                chkEnabled.Checked        = BusinessLogic.ConvertIntToBoolean(currentRoleEntity.Enabled);
                txtRealName.Focus();
            }
        }

        private void BindCategory()
        {
            var dtItemDetail    = itemDetailService.GetDTByCode(base.UserInfo, "RoleCategory");
            var dataRow           = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            cboCategory.DisplayMember = CiItemDetailsTable.FieldItemName;
            cboCategory.ValueMember   = CiItemDetailsTable.FieldItemValue;
            cboCategory.DataSource    = dtItemDetail.DefaultView;
        }

        public override bool SaveEntity()
        {
            roleEntity = null;
            roleEntity = new PiRoleEntity
            {
                Code = txtCode.Text.Trim(),
                RealName = txtRealName.Text.Trim(),
                Enabled = chkEnabled.Checked ? 1 : 0,
                Description = txtDescription.Text.Trim(),
                DeleteMark = 0,
                AllowDelete = 1,
                AllowEdit = 1
            };

            if (this.cboCategory.SelectedValue != null && this.cboCategory.SelectedValue.ToString().Length > 0)
            {
                roleEntity.Category = cboCategory.SelectedValue.ToString();
            }
            else
            {
                roleEntity.Category = null;
            }


            if (base.UserInfo != null)
            {
                roleEntity.CreateBy = UserInfo.RealName;
                roleEntity.CreateUserId = UserInfo.Id;
            }

            string statusMessage = string.Empty;
            string statusCode = string.Empty;

            try
            {
                roleService.Add(base.UserInfo, roleEntity, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKAdd.ToString())
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg( statusMessage);
                    }
                    return true;
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                    if (statusCode == StatusCode.ErrorNameExist.ToString())
                    {
                        this.txtRealName.SelectAll();
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            }  
        }

        /// <summary>
        /// 保存修改的数据
        /// </summary>
        /// <returns>true:修改成功,false:修改失败</returns>
        private bool SaveEditData()
        {
            currentRoleEntity.RealName = txtRealName.Text.Trim();
            currentRoleEntity.Code = txtCode.Text.Trim();
            if (this.cboCategory.SelectedValue != null && this.cboCategory.SelectedValue.ToString().Length > 0)
            {
                currentRoleEntity.Category = cboCategory.SelectedValue.ToString();
            }
            else
            {
                currentRoleEntity.Category = null;
            }

            currentRoleEntity.Enabled = chkEnabled.Checked ? 1 : 0;
            currentRoleEntity.Description = txtDescription.Text.Trim();

            if (base.UserInfo != null)
            {
                currentRoleEntity.ModifiedBy = base.UserInfo.RealName;
                currentRoleEntity.ModifiedUserId = base.UserInfo.Id;
            }
            
            string statusMessage = string.Empty;
            string statusCode = string.Empty;
            try
            {
                roleService.Update(base.UserInfo, currentRoleEntity, out statusCode,out statusMessage);
                if (statusCode == StatusCode.OKUpdate.ToString())
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
                    }
                    return true;
                }
                
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtRealName.SelectAll();
                }
                return false;
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            } 
        }
    }
}
