/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-3-31 13:41:01
 ******************************************************************************/
using System;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmEditOrganize
    /// 编辑组织机构
    /// 
    ///     2016-01-30 V3.0 EricHu 修改编辑树根节点时的错误问题。
    ///     2014-06-11 v2.8 EricHu 增加管理员主键与副管理员主键。
    ///     
    /// </summary>
    public partial class FrmEditOrganize : BaseForm
    {
        IItemDetailsService itemDetailService  = RDIFrameworkService.Instance.ItemDetailsService;
        IOrganizeService organizeService       = RDIFrameworkService.Instance.OrganizeService;
        PiOrganizeEntity organizeEntity        = null;
        PiOrganizeEntity currentOrganizeEntity = null;
        bool isAdd = true; //为true:增加数据,false:修改数据

        /// <summary>
        /// 节点名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 父节点主键
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.txtParentId.SelectedValue.ToString();
            }
            set
            {
                this.txtParentId.SelectedValue = value;
            }
        }

        /// <summary>
        /// 父节点全称
        /// </summary>
        public string ParentFullName
        {
            get
            {
                return this.txtParentId.Text;
            }
            set
            {
                this.txtParentId.Text = value;
            }
        }

        public FrmEditOrganize()
        {
            FullName = string.Empty;
            InitializeComponent();
        }

        public FrmEditOrganize(string entityId)
        {
            FullName = string.Empty;
            InitializeComponent();
            this.EntityId = entityId;
            isAdd = false;
        }

        public FrmEditOrganize(string id,string fullName)
        {
            FullName = string.Empty;
            InitializeComponent();
            this.ParentId = id;
            this.ParentFullName = fullName;
        }


        public override void FormOnLoad()
        {
            BindCatalog();

            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                this.btnSaveContinue.Visible = false;                
                this.ShowEntity();
                this.Text = "编辑组织机构 - " + currentOrganizeEntity.FullName;
            }
        }

        public override void ShowEntity()
        {
            currentOrganizeEntity = organizeService.GetEntity(base.UserInfo, this.EntityId);
            if (currentOrganizeEntity == null || currentOrganizeEntity.FullName.Trim().Length <= 0) return;
            if (!string.IsNullOrEmpty(currentOrganizeEntity.ParentId))
            {
                txtParentId.Text          = organizeService.GetEntity(base.UserInfo, currentOrganizeEntity.ParentId.ToString()).FullName;
                txtParentId.SelectedValue = currentOrganizeEntity.ParentId;
            }
            txtFullName.Text            = currentOrganizeEntity.FullName;
            txtShortName.Text           = currentOrganizeEntity.ShortName;
            txtCode.Text                = currentOrganizeEntity.Code;
            cboCategory.SelectedValue   = currentOrganizeEntity.Category;
            txtManager.Text             = currentOrganizeEntity.Manager;
            txtAssistantManager.Text    = currentOrganizeEntity.AssistantManager;
            txtOuterPhone.Text          = currentOrganizeEntity.OuterPhone;
            txtInnerPhone.Text          = currentOrganizeEntity.InnerPhone;
            txtFax.Text                 = currentOrganizeEntity.Fax;
            txtPostalcode.Text          = currentOrganizeEntity.Postalcode;
            txtWeb.Text                 = currentOrganizeEntity.Web;
            txtAddress.Text             = currentOrganizeEntity.Address;
            chkEnabled.Checked          = BusinessLogic.ConvertIntToBoolean(currentOrganizeEntity.Enabled);
            chkIsInnerOrganize.Checked  = BusinessLogic.ConvertIntToBoolean(currentOrganizeEntity.IsInnerOrganize);
            txtDescription.Text         = currentOrganizeEntity.Description;
        }

        private void BindCatalog()
        {
            var dtItemDetail = itemDetailService.GetDTByCode(base.UserInfo, "OrganizeCategory");
            var dataRow = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            cboCategory.DisplayMember = "ItemName";
            cboCategory.ValueMember = "ItemValue";
            cboCategory.DataSource = dtItemDetail.DefaultView;
        }


        private bool SaveData()
        {
            organizeEntity = null;
            organizeEntity = new PiOrganizeEntity
            {
                ParentId = BusinessLogic.ConvertToString(txtParentId.SelectedValue),
                Code = txtCode.Text.Trim(),
                ShortName = txtShortName.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Category = cboCategory.SelectedValue.ToString(),
                OuterPhone = txtOuterPhone.Text.Trim(),
                InnerPhone = txtInnerPhone.Text.Trim(),
                Fax = txtFax.Text.Trim(),
                Postalcode = txtPostalcode.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Web = txtWeb.Text.Trim(),
                ManagerId = txtManager.AccessibleDescription,
                Manager = txtManager.Text.Trim(),
                AssistantManagerId = txtAssistantManager.AccessibleDescription,
                AssistantManager = txtAssistantManager.Text.Trim(),
                IsInnerOrganize = chkIsInnerOrganize.Checked ? 1 : 0,
                Enabled = chkEnabled.Checked ? 1 : 0,
                DeleteMark = 0,
                Description = txtDescription.Text.Trim()
            };

            if (base.UserInfo != null)
            {
                organizeEntity.CreateBy = UserInfo.RealName;
                organizeEntity.CreateUserId = UserInfo.Id;
            }

            string statusMessage = string.Empty;
            string statusCode = string.Empty;

            try
            {
                this.EntityId = organizeService.Add(base.UserInfo, organizeEntity, out statusCode, out statusMessage);
                this.FullName = organizeEntity.FullName;
                this.ParentId = txtParentId.SelectedValue.ToString();
                if (statusCode == StatusCode.OKAdd.ToString())
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                    }
                    return true;
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                    if (statusCode == StatusCode.ErrorNameExist.ToString())
                    {
                        this.txtFullName.SelectAll();
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
            currentOrganizeEntity.ParentId = BusinessLogic.ConvertToString(txtParentId.SelectedValue);
            currentOrganizeEntity.FullName = txtFullName.Text.Trim();
            currentOrganizeEntity.ShortName = txtShortName.Text.Trim();
            currentOrganizeEntity.Code = txtCode.Text.Trim();
            currentOrganizeEntity.Category = cboCategory.SelectedValue.ToString();
            currentOrganizeEntity.ManagerId = txtManager.AccessibleDescription;
            currentOrganizeEntity.Manager = txtManager.Text.Trim();
            currentOrganizeEntity.AssistantManagerId = txtAssistantManager.AccessibleDescription;
            currentOrganizeEntity.AssistantManager = txtAssistantManager.Text.Trim();
            currentOrganizeEntity.OuterPhone = txtOuterPhone.Text.Trim();
            currentOrganizeEntity.InnerPhone = txtInnerPhone.Text.Trim();
            currentOrganizeEntity.Fax = txtFax.Text.Trim();
            currentOrganizeEntity.Postalcode = txtPostalcode.Text.Trim();
            currentOrganizeEntity.Web = txtWeb.Text.Trim();
            currentOrganizeEntity.Address = txtAddress.Text.Trim();
            currentOrganizeEntity.Enabled = chkEnabled.Checked ? 1 : 0;
            currentOrganizeEntity.IsInnerOrganize = chkIsInnerOrganize.Checked ? 1 : 0;
            currentOrganizeEntity.Description = txtDescription.Text.Trim();
            if (base.UserInfo != null)
            {
                currentOrganizeEntity.ModifiedBy = base.UserInfo.RealName;
                currentOrganizeEntity.ModifiedUserId = base.UserInfo.Id;
            }

            int returnValue = 0;
            string statusMessage = string.Empty;
            try
            {
                returnValue = organizeService.Update(base.UserInfo, currentOrganizeEntity, out statusMessage);
                this.EntityId = currentOrganizeEntity.Id.ToString();
                this.FullName = currentOrganizeEntity.FullName;
                this.ParentId = txtParentId.SelectedValue == null ? string.Empty : txtParentId.SelectedValue.ToString();

                if (returnValue > 0)
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                    }
                    return true;
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                    return false;
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbMain)) return;
            if (this.isAdd) //增加数据
            {
                if (!this.SaveData()) return;
                this.Changed = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else //修改数据
            {
                if (!this.SaveEditData()) return;
                this.Changed = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbMain)) return;
            if (!this.SaveData()) return;
            this.Changed = true;
            BasePageLogic.EmptyControlValue(gbMain);
            txtFullName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

        private void btnExecutiveDirector_Click(object sender, EventArgs e)
        {
            var userSelect = new FrmUserSelect {MultiSelect = false};
            if (userSelect.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && userSelect.SelectedId != null)
            {
                txtManager.AccessibleDescription = userSelect.SelectedId;
                txtManager.Text = userSelect.SelectedFullName;
            }
        }

        private void btnDeputySupervisor_Click(object sender, EventArgs e)
        {
            var userSelect = new FrmUserSelect {MultiSelect = false};
            if (userSelect.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && userSelect.SelectedId != null)
            {
                txtAssistantManager.AccessibleDescription = userSelect.SelectedId;
                txtAssistantManager.Text = userSelect.SelectedFullName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
