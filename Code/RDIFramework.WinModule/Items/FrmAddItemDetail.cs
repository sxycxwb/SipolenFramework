using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAddItemDetail
    /// 增加字典明细
    /// 
    /// 
    /// </summary>
    public partial class FrmAddItemDetail : BaseForm
    {
        /// <summary>
        /// 当前数据字典主键
        /// </summary>
        public string CurrentItemId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="itemId">当前数据字典主键</param>
        public FrmAddItemDetail(string itemId)
        {
            this.CurrentItemId = itemId;
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty((this.CurrentItemId)))
            {
                return;
            }
        }

        public override bool SaveEntity()
        {
            var itemEntity = new CiItemDetailsEntity
            {
                ItemId          =  this.CurrentItemId,
                ItemCode        = txtItemCode.Text.Trim(),
                ItemName        = txtItemName.Text.Trim(),
                ItemValue       = txtItemValue.Text.Trim(),
                Description     = txtDescription.Text.Trim(),
                Enabled         = chkEnabled.Checked ? 1 : 0,
                AllowDelete     = 1,
                AllowEdit       = 1,
                IsPublic        = 1,
                DeleteMark      = 0,
                ParentId        = null
            };

            if (base.UserInfo != null)
            {
                itemEntity.CreateBy     = UserInfo.RealName;
                itemEntity.CreateUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var returnValue = 0;

            try
            {
                returnValue = RDIFrameworkService.Instance.ItemDetailsService.Add(base.UserInfo, itemEntity, out statusMessage);

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

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                }
                BasePageLogic.EmptyControlValue(pnlMain);
                this.txtItemCode.Focus();
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
