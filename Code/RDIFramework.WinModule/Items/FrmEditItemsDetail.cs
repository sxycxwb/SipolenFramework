using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.WinForm.Utilities;
    using  RDIFramework.BizLogic;
    using  RDIFramework.Utilities;

    /// <summary>
    /// FrmEditItemsDetail
    /// 修改字典明细
    /// 
    /// 
    /// </summary>
    public partial class FrmEditItemsDetail : BaseForm
    {
        CiItemDetailsEntity currenteEntity = null;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmEditItemsDetail()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty((this.EntityId)))
            {
                return;
            }
            this.ShowEntity();
        }

        public override void ShowEntity()
        {
            currenteEntity = RDIFrameworkService.Instance.ItemDetailsService.GetEntity(this.UserInfo, this.EntityId);
            if (currenteEntity != null)
            {
                this.txtItemCode.Text              = currenteEntity.ItemCode;
                this.txtItemName.Text              = currenteEntity.ItemName;
                this.txtItemValue.Text             = currenteEntity.ItemValue;
                this.txtDescription.Text           = currenteEntity.Description;
                this.chkEnabled.Checked            = BusinessLogic.ConvertIntToBoolean(currenteEntity.Enabled);
            }
        }

        public override bool SaveEntity()
        {
            currenteEntity.ItemCode    = txtItemCode.Text.Trim();
            currenteEntity.ItemName    = txtItemName.Text.Trim();
            currenteEntity.ItemValue   = txtItemValue.Text.Trim();
            currenteEntity.Description = txtDescription.Text.Trim();
            currenteEntity.Enabled     = chkEnabled.Checked ? 1 : 0;

            if (base.UserInfo != null)
            {
                currenteEntity.ModifiedBy = UserInfo.RealName;
                currenteEntity.ModifiedUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var returnValue = 0;

            try
            {
                returnValue = RDIFrameworkService.Instance.ItemDetailsService.Update(base.UserInfo, currenteEntity, out statusMessage);

                if (returnValue > 0)
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
                    }
                    return true;
                }
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                return false;
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
