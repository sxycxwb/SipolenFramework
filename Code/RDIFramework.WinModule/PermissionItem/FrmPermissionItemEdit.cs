/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:56:12
 ******************************************************************************/
using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPermissionItemEdit
    /// 编辑操作权限
    /// 
    /// </summary>
    public partial class FrmPermissionItemEdit : BaseForm
    {
        public PiPermissionItemEntity PermissionItemEntity = new PiPermissionItemEntity();

        /// <summary>
        /// 权限项名称
        /// </summary>
        private string fullName = string.Empty;

        /// <summary>
        /// 权限项名称
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// 父权限项id
        /// </summary>
        private string parentId = string.Empty;

        /// <summary>
        /// 父权限项id
        /// </summary>
        public string ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        public FrmPermissionItemEdit()
        {
            InitializeComponent();
        }

        public FrmPermissionItemEdit(string id)
            : this()
        {
            this.PermissionItemEntity.Id = id;
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            if (!UserInfo.IsAdministrator)
            {

            }
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 从数据权限读取类属性
            if (!string.IsNullOrEmpty(this.PermissionItemEntity.Id))
            {
                //// 将类转显示到页面
                //this.ucParent.CheckMove = true;
                //// 默认选中的节点
                //this.ucParent.SelectedId = this.PermissionItemEntity.ParentId.ToString();
                //if (this.PermissionItemEntity.Id > 0)
                //{
                //    // 原来的节点
                //    this.ucParent.OpenId = this.PermissionItemEntity.Id.ToString();
                //}

                if (this.PermissionItemEntity.ParentId != null && this.PermissionItemEntity.ParentId.ToString().Length > 0)
                {
                    this.txtParentId.SelectedValue = this.PermissionItemEntity.ParentId;
                    this.txtParentId.Text          = RDIFrameworkService.Instance.PermissionItemService.GetEntity(UserInfo,this.PermissionItemEntity.ParentId.ToString()).FullName;
                }
                
                
                this.txtCode.Text        = this.PermissionItemEntity.Code;
                this.txtFullName.Text    = this.PermissionItemEntity.FullName;
                this.chkIsScope.Checked  = this.PermissionItemEntity.IsScope == 1;
                this.chkEnabled.Checked  = this.PermissionItemEntity.Enabled == 1;
                this.chkIsPublic.Checked = this.PermissionItemEntity.IsPublic == 1;
                this.txtDescription.Text = this.PermissionItemEntity.Description;
                // 自己的数据，自己能修改
                if (UserInfo.Id.Equals(this.PermissionItemEntity.CreateUserId))
                {
                }
                // 设置焦点
                this.ActiveControl      = this.txtFullName;
                this.txtFullName.Focus();
            }
            else
            {
                // 这里需要进行判断，数据是否被其他人已经删除
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0005);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.PermissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntity(UserInfo, this.PermissionItemEntity.Id.ToString());
            // 获得页面的权限
            this.GetPermission();
            // 显示内容
            this.ShowEntity();

            this.Text = "编辑操作权限 - " + PermissionItemEntity.FullName;
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            this.txtCode.Text = this.txtCode.Text.TrimEnd();
            if (this.txtCode.Text.Trim().Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9977));
                this.txtCode.Focus();
                return false;
            }
            this.txtFullName.Text = this.txtFullName.Text.TrimEnd();
            if (this.txtFullName.Text.Trim().Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9978));
                this.txtFullName.Focus();
                return false;
            }
            return returnValue;
        }
        #endregion

        #region private void GetEntity() 转换数据，将表单保存到实体类
        /// <summary>
        /// 转换数据，将表单保存到实体类
        /// </summary>
        private void GetEntity()
        {

            this.PermissionItemEntity.ParentId = BusinessLogic.ConvertToString(this.txtParentId.SelectedValue);
            if (string.IsNullOrEmpty(this.PermissionItemEntity.ParentId))
            {
                this.PermissionItemEntity.ParentId = null;
            }

            this.PermissionItemEntity.Code          = this.txtCode.Text;
            this.PermissionItemEntity.FullName      = this.txtFullName.Text;
            this.PermissionItemEntity.IsScope       = this.chkIsScope.Checked ? 1 : 0;
            this.PermissionItemEntity.Enabled       = this.chkEnabled.Checked ? 1 : 0;
            this.PermissionItemEntity.IsPublic      = this.chkIsPublic.Checked ? 1 : 0;
            this.PermissionItemEntity.Description   = this.txtDescription.Text;
        }
        #endregion

        private void ucParent_SelectedIndexChanged(string selectedId)
        {
            this.PermissionItemEntity.ParentId = !string.IsNullOrEmpty(selectedId) ? selectedId : null;
        }

        #region public override bool SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool returnValue = false;
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.FullName = this.txtFullName.Text;
            this.ParentId = BusinessLogic.ConvertToString(this.txtParentId.SelectedValue);
            // 调用接口方式实现
            RDIFrameworkService.Instance.PermissionItemService.Update(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                returnValue = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        // 关闭窗口
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            var frmPermissionSelect = new FrmPermissionSelect();
            if (frmPermissionSelect.ShowDialog() == DialogResult.OK)
            {
                this.txtParentId.SelectedValue = frmPermissionSelect.SelectedId;
                this.txtParentId.Text = frmPermissionSelect.SelectedFullName;
            }
            this.SetControlState();
        }

        private void btnSetEmpty_Click(object sender, EventArgs e)
        {
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
