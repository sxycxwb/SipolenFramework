using System;
using System.Windows.Forms;

namespace CRM
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmIncomingCallEdit
    /// 来电管理-编辑（添加或修改）来电
    /// </summary>
    public partial class FrmIncomingCallEdit : BaseForm
    {
        IncomingCallEntity currentIncomingCallEntity = new IncomingCallEntity();
        IIncomingCallService incomingCallService = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmIncomingCallEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">当前实体主键</param>
        public FrmIncomingCallEdit(string id):this()
        {
            this.EntityId = id;
        }

        public override void FormOnLoad()
        {
            incomingCallService = new IncomingCallService(DbLinks["CRMDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["CRMDBLink"].DbLink));

            if (!string.IsNullOrEmpty(this.EntityId))
            {
                this.btnSaveContine.Visible = false;
                this.Text = "来电修改";
                BindEditData();
            }
            this.txtCallRecord.Focus();
        }

        /// <summary>
        ///  绑定修改的数据
        /// </summary>
        private void BindEditData()
        {
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                currentIncomingCallEntity = incomingCallService.GetEntity(base.UserInfo, this.EntityId);
                if (currentIncomingCallEntity == null)
                {
                    return;
                }
                this.txtCallRecord.Text = currentIncomingCallEntity.CallRecord;
                this.txtCallNumber.Text = currentIncomingCallEntity.CallNumber;
                this.txtCustomerName.Text = currentIncomingCallEntity.CustomerName;
                this.txtCustomerName.SelectedValue = currentIncomingCallEntity.CustomerId;
                if (!string.IsNullOrEmpty(currentIncomingCallEntity.CallType.Trim()))
                {
                    switch (currentIncomingCallEntity.CallType.Trim())
                    {
                        case "销售机会":
                            rbCallType1.Checked = true;
                            break;
                        case "售后服务":
                            rbCallType2.Checked = true;
                            break;
                        case "投诉":
                            rbCallType3.Checked = true;
                            break;
                        case "合作":
                            rbCallType4.Checked = true;
                            break;
                        case "其他":
                            rbCallType5.Checked = true;
                            break;
                    }
                }
                rbNotHandled.Checked = true;
                if(BusinessLogic.ConvertIntToBoolean(currentIncomingCallEntity.Handled))
                {
                    rbHandled.Checked = true;                    
                }
                this.dtCallDate.Text = BusinessLogic.ConvertToDateToString(currentIncomingCallEntity.CallDate == null ? string.Empty : currentIncomingCallEntity.CallDate.ToString());
                this.txtDescription.Text = currentIncomingCallEntity.Description;
            }
        }

        public override bool CheckInput()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.txtCallRecord.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("来电内容不能为空!");
                txtCallRecord.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCustomerName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("来电客户不能为空!");
                txtCustomerName.Focus();
                return false;
            }
            return returnValue;
        }

        public override bool SaveEntity()
        {
            IncomingCallEntity entity = new IncomingCallEntity
            {
                CallRecord = this.txtCallRecord.Text.Trim(),
                CallNumber = this.txtCallNumber.Text.Trim(),
                CustomerName = this.txtCustomerName.Text.Trim(),
                CustomerId = BusinessLogic.ConvertToInt32(this.txtCustomerName.SelectedValue)
            };
            string callType = string.Empty;
            callType = rbCallType1.Checked ? rbCallType1.Text : callType;
            callType = rbCallType2.Checked ? rbCallType2.Text : callType;
            callType = rbCallType3.Checked ? rbCallType3.Text : callType;
            callType = rbCallType4.Checked ? rbCallType4.Text : callType;
            callType = rbCallType5.Checked ? rbCallType5.Text : callType;
            entity.CallType = callType;
            entity.Handled = 0;
            if (rbHandled.Checked)
            {
                entity.Handled = 1;
            }
            entity.CallDate = BusinessLogic.ConvertToDateTime(dtCallDate.Text);
            entity.Description = this.txtDescription.Text.Trim();
            string objectId = incomingCallService.Add(base.UserInfo, entity);
            if (objectId.Length > 0)
            {
                this.Changed = true;
                if (SystemInfo.ShowSuccessMsg)
                {
                    MessageBoxHelper.ShowSuccessMsg("新增成功！");
                    return true;
                }
            }
            else
            {
                MessageBoxHelper.ShowErrorMsg("新增失败！");
                return false;
            }
            return true;
        }

        private bool SaveEditData()
        {
            bool returnValue = false;  
            currentIncomingCallEntity.CallRecord = this.txtCallRecord.Text.Trim();
            currentIncomingCallEntity.CallNumber = this.txtCallNumber.Text.Trim();
            currentIncomingCallEntity.CustomerName = this.txtCustomerName.Text.Trim();
            currentIncomingCallEntity.CustomerId = BusinessLogic.ConvertToInt32(this.txtCustomerName.SelectedValue);
            string callType = string.Empty;
            callType = rbCallType1.Checked ? rbCallType1.Text : callType;
            callType = rbCallType2.Checked ? rbCallType2.Text : callType;
            callType = rbCallType3.Checked ? rbCallType3.Text : callType;
            callType = rbCallType4.Checked ? rbCallType4.Text : callType;
            callType = rbCallType5.Checked ? rbCallType5.Text : callType;
            currentIncomingCallEntity.CallType = callType;
            currentIncomingCallEntity.Handled = 0;
            if (rbHandled.Checked)
            {
                currentIncomingCallEntity.Handled = 1;
            }
            currentIncomingCallEntity.CallDate = BusinessLogic.ConvertToDateTime(dtCallDate.Text);
            currentIncomingCallEntity.Description = this.txtDescription.Text.Trim();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            int success =incomingCallService.Update(base.UserInfo, currentIncomingCallEntity, out statusCode, out statusMessage);
            if (success > 0 || statusCode == StatusCode.OKUpdate.ToString())
            {
                this.Changed = true;
                if (SystemInfo.ShowSuccessMsg)
                {
                    MessageBoxHelper.ShowSuccessMsg("更新成功！");
                    returnValue = true;
                }
            }
            else
            {
                MessageBoxHelper.ShowErrorMsg(statusMessage);
                returnValue = false;
            }

            return returnValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                if (this.EntityId.Length > 0)
                {
                    if (this.SaveEditData())
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if (this.SaveEntity())
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomerSelect frmCustomerSelect = new FrmCustomerSelect {DbLinks = this.DbLinks};
            if (frmCustomerSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtCustomerName.SelectedValue = frmCustomerSelect.SelectedId;
                this.txtCustomerName.Text          = frmCustomerSelect.SelectedName;
            }
        }

        private void btnSaveContine_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                if (this.SaveEntity())
                {
                    this.txtCallRecord.Clear();
                    this.txtCustomerName.Clear();
                    this.txtCustomerName.SelectedValue = null;
                    this.txtDescription.Clear();
                    this.txtCallNumber.Clear();
                    this.txtCallRecord.Focus();
                }
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                if (MessageBoxHelper.Show("确定放弃新增？") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }        
    }
}
