using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAddItems
    /// 增加数据字典
    /// 
    /// 
    /// </summary>
    public partial class FrmAddItems : BaseForm
    {
        /// <summary>
        /// 父节点主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmAddItems()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parentId">父节点主键</param>
        public FrmAddItems(string parentId)
            : this()
        {
            this.ParentId = parentId;
        }

        public override void FormOnLoad()
        {
            if (!string.IsNullOrEmpty((this.ParentId)))
            {
                this.txtParentId.SelectedId = this.ParentId;
            }
            BasePageLogic.BindCategory(base.UserInfo, cboCategory, "DataDictionaryCategory");
        }

        public override bool SaveEntity()
        {
            var itemEntity = new CiItemsEntity
            {
                Code        = txtCode.Text.Trim(),
                FullName    = txtFullName.Text.Trim(),
                Category    = string.IsNullOrEmpty(cboCategory.SelectedValue.ToString()) ? null : cboCategory.SelectedValue.ToString(),
                ParentId    = txtParentId.SelectedId,
                Description = txtDescription.Text.Trim(),
                DeleteMark  = 0,
                Enabled     = chkEnabled.Checked ? 1 : 0
            };

            if (base.UserInfo != null)
            {
                itemEntity.CreateBy     = UserInfo.RealName;
                itemEntity.CreateUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var statusCode = string.Empty;

            try
            {
                RDIFrameworkService.Instance.ItemsService.Add(base.UserInfo, itemEntity, out statusCode, out statusMessage);

                if (statusCode == StatusCode.OKAdd.ToString())
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

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                }
                BasePageLogic.EmptyControlValue(pnlMain);
                this.txtCode.Focus();
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
