using System;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmEditDictionaryDetail
    /// 编辑字典明细窗体
    /// 
    /// 修改记录
    /// </summary>
    public partial class FrmEditDictionaryDetail : BaseForm
    {
        IItemDetailsService itemDetailService = RDIFrameworkService.Instance.ItemDetailsService;
        CiItemDetailsEntity currentItemDetailEntity = null;
        string currentItemId = string.Empty;
        bool isAdd = true;//默认为新增数据

        public FrmEditDictionaryDetail(string itemId)
        {
            InitializeComponent();
            isAdd = true;//新增数据
            currentItemId = itemId;
        }

        public FrmEditDictionaryDetail(DataRow row)
        {
            InitializeComponent();
            currentItemDetailEntity = itemDetailService.GetEntity(base.UserInfo, row[CiItemDetailsTable.FieldId].ToString());
            isAdd                   = false;//修改数据
            btnSaveContinue.Visible = false;
            txtItemCode.Text        = currentItemDetailEntity.ItemCode;
            txtItemName.Text        = currentItemDetailEntity.ItemName;
            txtItemValue.Text       = currentItemDetailEntity.ItemValue;
            txtDescription.Text     = currentItemDetailEntity.Description;
            chkEnabled.Checked      = BusinessLogic.ConvertIntToBoolean(currentItemDetailEntity.Enabled);
        }

        public override bool SaveEntity()
        {
            var itemDetailEntity = new CiItemDetailsEntity
            {
                ItemId = currentItemId,
                ItemCode = txtItemCode.Text.Trim(),
                ItemName = txtItemName.Text.Trim(),
                ItemValue = txtItemValue.Text.Trim(),
                Enabled = chkEnabled.Checked ? 1 : 0,
                Description = txtDescription.Text.Trim(),
                AllowDelete = 1,
                AllowEdit = 1,
                IsPublic = 1,
                DeleteMark = 0,
                ParentId = null
            };

            if (base.UserInfo != null)
            {
                itemDetailEntity.CreateBy = UserInfo.RealName;
                itemDetailEntity.CreateUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var returnValue = 0;

            try
            {
                returnValue = itemDetailService.Add(base.UserInfo, itemDetailEntity, out statusMessage);
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

            if (returnValue > 0)
            {
                if (SystemInfo.ShowSuccessMsg)
                {
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                return true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg( statusMessage);
            }
            return false;
            
        }

        private bool UpdateData()
        {
            currentItemDetailEntity.ItemCode = txtItemCode.Text.Trim();
            currentItemDetailEntity.ItemName = txtItemName.Text.Trim();
            currentItemDetailEntity.ItemValue = txtItemValue.Text.Trim();
            currentItemDetailEntity.Description = txtDescription.Text.Trim();
            currentItemDetailEntity.Enabled = chkEnabled.Checked ? 1 : 0;

            if (base.UserInfo != null)
            {
                currentItemDetailEntity.ModifiedBy = UserInfo.RealName;
                currentItemDetailEntity.ModifiedUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var returnValue = 0;

            try
            {
                returnValue = itemDetailService.Update(base.UserInfo, currentItemDetailEntity, out statusMessage);
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

            if (returnValue > 0)
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
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                    BasePageLogic.EmptyControlValue(pnlMain);
                    txtItemCode.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                if (isAdd) //新增数据
                {
                    if (this.SaveEntity())
                    {
                        this.Changed = true;
                    }
                }
                else //修改数据
                {
                    if (UpdateData())
                    {
                        this.Changed = true;
                    }
                }

                if (this.Changed)
                {
                    (this.Owner as BaseForm).RefreshForm();
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                (this.Owner as BaseForm).RefreshForm();                
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
