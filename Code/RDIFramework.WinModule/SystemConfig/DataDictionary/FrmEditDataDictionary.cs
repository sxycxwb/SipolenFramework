using System;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmEditDataDictionary : BaseForm
    {
        IItemsService itemsService       = RDIFrameworkService.Instance.ItemsService;
        DataRow currentRowData           = null;
        CiItemsEntity currentItems       = null;
        bool isAdd                       = true;//默认为新增数据

        public FrmEditDataDictionary()
        {
            InitializeComponent();
        }

        public FrmEditDataDictionary(DataRow row)
        {
            InitializeComponent();
            currentRowData = row;
        }

        public override void FormOnLoad()
        {            
            BasePageLogic.BindCategory(base.UserInfo, cboCategory, "DataDictionaryCategory");

            //修改数据做相关控制
            if (currentRowData != null && !string.IsNullOrEmpty(currentRowData[CiItemsTable.FieldId].ToString()))
            {
                currentItems         = itemsService.GetEntity(base.UserInfo, currentRowData[CiItemsTable.FieldId].ToString());
                btnSaveContinue.Visible       = false;
                isAdd                = false;
                txtCode.Text         = currentItems.Code;
                txtFullName.Text     = currentItems.FullName;
                cboCategory.SelectedValue = BusinessLogic.ConvertToString(currentItems.Category);
                txtDescription.Text  = currentItems.Description;
                chkEnabled.Checked   = BusinessLogic.ConvertIntToBoolean(currentItems.Enabled);
            }
        }

        //添加数据字典
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                    BasePageLogic.EmptyControlValue(pnlMain);
                    txtCode.Focus();
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

        #region private bool EditData():修改数据字典
        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <returns>成功：true；失败:false</returns>
        private bool UpdateData()
        {

            currentItems.Code = txtCode.Text.Trim();
            currentItems.FullName = txtFullName.Text.Trim();
            currentItems.Category = string.IsNullOrEmpty(cboCategory.SelectedValue.ToString()) ? null : cboCategory.SelectedValue.ToString();
            currentItems.Description = txtDescription.Text.Trim();
            currentItems.Enabled = chkEnabled.Checked ? 1 : 0;

            if (base.UserInfo != null)
            {
                currentItems.ModifiedBy = UserInfo.RealName;
                currentItems.ModifiedUserId = UserInfo.Id;
            }

            var statusMessage = string.Empty;
            var statusCode    = string.Empty;            

            try
            {
                itemsService.Update(base.UserInfo, currentItems,out statusCode, out statusMessage);

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
        #endregion

        #region public override bool SaveEntity():保存数据
        public override bool SaveEntity()
        {
            var itemEntity    = new CiItemsEntity
            {
                Code = txtCode.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Category =string.IsNullOrEmpty(cboCategory.SelectedValue.ToString())? null: cboCategory.SelectedValue.ToString(),
                Description = txtDescription.Text.Trim(),
                DeleteMark = 0,
                Enabled = chkEnabled.Checked ? 1 : 0
            };

            if (base.UserInfo != null)
            {
                itemEntity.CreateBy = UserInfo.RealName;
                itemEntity.CreateUserId = UserInfo.Id;
            }

            var statusMessage       = string.Empty;
            var statusCode          = string.Empty;

            try
            {
                itemsService.Add(base.UserInfo, itemEntity,out statusCode, out statusMessage);

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
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
