/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-22 16:08:22
 ******************************************************************************/
using System;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmDBLinkEdit : BaseForm
    {
        CiDbLinkDefineEntity currentDblinkDefine = null;

        private bool isAdd = true;
        /// <summary>
        /// 是否是添加数据[true:添加数据；false:修改数据]
        /// </summary>
        public bool IsAdd
        {
            get { return isAdd; }
            set { isAdd = value; }
        }

        private void BindCategory()
        {
            DataTable dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(base.UserInfo, "DataBaseType");
            DataRow dataRow = dtItemDetail.NewRow();
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            cboLinkType.DisplayMember = CiItemDetailsTable.FieldItemName;
            cboLinkType.ValueMember = CiItemDetailsTable.FieldItemValue;
            cboLinkType.DataSource = dtItemDetail.DefaultView;
        }

        public override void ShowEntity()
        {
            currentDblinkDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(this.UserInfo, this.EntityId);
            if (currentDblinkDefine == null)
            {
                return;
            }

            this.txtLinkName.Text = currentDblinkDefine.LinkName;
            this.cboLinkType.Text = currentDblinkDefine.LinkType;
            this.chkEnabled.Checked = BusinessLogic.ConvertIntToBoolean(currentDblinkDefine.Enabled);
            this.txtDescription.Text = currentDblinkDefine.Description;
            this.txtDbLinks.Text = SecretHelper.AESDecrypt(currentDblinkDefine.LinkData);
        }

        public FrmDBLinkEdit()
        {
            InitializeComponent();
        }

        public FrmDBLinkEdit(string entityId)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(entityId))
            {
                MessageBoxHelper.ShowErrorMsg(RDIFrameworkMessage.MSGC023);
                return;
            }
            this.EntityId = entityId;
        }

        public override void FormOnLoad()
        {
            BindCategory();
            
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                this.btnSaveContinue.Visible = false;
                isAdd = false;
                this.ShowEntity();
                this.Text = @"修改数据库连接 - " + currentDblinkDefine.LinkName;
            }           
        }
        
        private bool SaveEditData()
        {
            currentDblinkDefine.LinkName = this.txtLinkName.Text.Trim();
            currentDblinkDefine.LinkType = this.cboLinkType.Text.Trim();
            currentDblinkDefine.Enabled = this.chkEnabled.Checked ? 1 : 0;
            currentDblinkDefine.DeleteMark = 0;
            currentDblinkDefine.Description = this.txtDescription.Text.Trim();
            string linkData = txtDbLinks.Text.Trim();
            currentDblinkDefine.LinkData = SecretHelper.AESEncrypt(linkData);

            string statusMessage = string.Empty;
            string statusCode = string.Empty;           

            try
            {
                RDIFrameworkService.Instance.DbLinkDefineService.Update(base.UserInfo, currentDblinkDefine, out statusCode, out statusMessage);
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
                    this.txtLinkName.SelectAll();
                }
                return false;
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            }  
        }

        public override bool SaveEntity()
        {
            var dbLinkEntity = new CiDbLinkDefineEntity
            {
                LinkName = this.txtLinkName.Text.Trim(),
                LinkType = this.cboLinkType.Text.Trim(),
                Enabled = this.chkEnabled.Checked ? 1 : 0,
                DeleteMark = 0,
                Description = this.txtDescription.Text.Trim()
            };
            string linkData = txtDbLinks.Text.Trim();
            dbLinkEntity.LinkData = SecretHelper.AESEncrypt(linkData);

            string statusMessage = string.Empty;
            string statusCode = string.Empty;

            try
            {
                RDIFrameworkService.Instance.DbLinkDefineService.Add(base.UserInfo, dbLinkEntity, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKAdd.ToString())
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
                    this.txtLinkName.SelectAll();
                }
                return false;
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            }  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain) && this.SaveEntity())
            {
                this.Changed = true;
                BasePageLogic.EmptyControlValue(pnlMain);
                txtLinkName.Focus();
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

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);  
        }
    }
}
