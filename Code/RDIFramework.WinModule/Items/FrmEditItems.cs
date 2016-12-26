using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.WinForm.Utilities;
    using  RDIFramework.BizLogic;
    using  RDIFramework.Utilities;

    public partial class FrmEditItems : BaseForm
    {
        CiItemsEntity currenteEntity = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmEditItems()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty((this.EntityId)))
            {
                return;
            }
            BasePageLogic.BindCategory(base.UserInfo, cboCategory, "DataDictionaryCategory");
            this.ShowEntity();
        }

        public override void ShowEntity()
        {
            currenteEntity = RDIFrameworkService.Instance.ItemsService.GetEntity(this.UserInfo, this.EntityId);
            if (currenteEntity != null)
            {
                this.txtCode.Text              = currenteEntity.Code;
                this.txtFullName.Text          = currenteEntity.FullName;
                this.txtParentId.SelectedId    = currenteEntity.ParentId;
                this.cboCategory.SelectedValue = BusinessLogic.ConvertToString(currenteEntity.Category);
                this.txtDescription.Text       = currenteEntity.Description;
                this.chkEnabled.Checked        = BusinessLogic.ConvertIntToBoolean(currenteEntity.Enabled);
            }
        }

        public override bool SaveEntity()
        {
            currenteEntity.Code = txtCode.Text.Trim();
            currenteEntity.FullName = txtFullName.Text.Trim();
            currenteEntity.Category = string.IsNullOrEmpty(cboCategory.SelectedValue.ToString()) ? null : cboCategory.SelectedValue.ToString();
            currenteEntity.ParentId = txtParentId.SelectedId;
            currenteEntity.Description = txtDescription.Text.Trim();
            currenteEntity.Enabled = chkEnabled.Checked ? 1 : 0;

            if (base.UserInfo != null)
            {
                currenteEntity.ModifiedBy = UserInfo.RealName;
                currenteEntity.ModifiedUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var statusCode = string.Empty;

            try
            {
                RDIFrameworkService.Instance.ItemsService.Update(base.UserInfo, currenteEntity, out statusCode, out statusMessage);

                if (statusCode == StatusCode.OKUpdate.ToString())
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
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
                    else if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        this.txtCode.SelectAll();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain) && this.SaveEntity())
            {
                this.Changed = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
