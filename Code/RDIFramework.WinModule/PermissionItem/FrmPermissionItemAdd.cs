/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-24 10:59:26
 ******************************************************************************/
using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPermissionItemAdd
    /// 增加操作权限
    /// 
    /// </summary>
    public partial class FrmPermissionItemAdd : BaseForm
    {
        public PiPermissionItemEntity PermissionItemEntity = null;

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

        public FrmPermissionItemAdd()
        {
            InitializeComponent();
        }

        public FrmPermissionItemAdd(string parentId, string parentdFullName)
            : this()
        {
            txtParentId.SelectedValue = parentId;
            txtParentId.Text = parentdFullName;
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            // 系统管理员，还有自己创建的数据，可以进行修改
            if (UserInfo.IsAdministrator)
            {
                this.chkEnabled.Checked = true;
            }
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            if (this.PermissionItemEntity != null)
            {
                this.txtCode.Text = this.PermissionItemEntity.Code;
                this.txtFullName.Text = this.PermissionItemEntity.FullName;
                this.chkIsScope.Checked = this.PermissionItemEntity.IsScope == 1;
                this.chkEnabled.Checked = this.PermissionItemEntity.Enabled == 1;
                this.chkIsPublic.Checked = this.PermissionItemEntity.IsPublic == 1;
                this.txtDescription.Text = this.PermissionItemEntity.Description;
            }
            // 设置焦点
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 若不是系统管理员，不能添加跟节点
            this.lblParentReq.Visible = false;
            this.txtParentId.AccessibleName = "EmptyValue|NotNull";
            
            if (!UserInfo.IsAdministrator)
            {
                this.lblParentReq.Visible = true;
                this.txtParentId.AccessibleName = "EmptyValue";
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 显示内容
            this.ShowEntity();
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

        #region private BasePermissionEntity GetEntity() 转换数据，将表单数据保存到实体类
        /// <summary>
        /// 读取屏幕中输入的数据
        /// </summary>
        /// <returns>操作权限项实体</returns>
        private PiPermissionItemEntity GetEntity()
        {
            if (this.PermissionItemEntity == null)
            {
                this.PermissionItemEntity = new PiPermissionItemEntity();
            }
            this.PermissionItemEntity.SortCode = null;
            this.PermissionItemEntity.ParentId = BusinessLogic.ConvertToString(txtParentId.SelectedValue) ?? null;
            this.PermissionItemEntity.Code = this.txtCode.Text;
            this.PermissionItemEntity.FullName = this.txtFullName.Text;
            this.PermissionItemEntity.IsScope = this.chkIsScope.Checked ? 1 : 0;
            this.PermissionItemEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.PermissionItemEntity.IsPublic = this.chkIsPublic.Checked ? 1 : 0;
            this.PermissionItemEntity.DeleteMark = 0;
            this.PermissionItemEntity.Description = this.txtDescription.Text;
            this.PermissionItemEntity.AllowDelete = 1;
            this.PermissionItemEntity.AllowEdit = 1;
            return this.PermissionItemEntity;
        }
        #endregion

        #region private void SaveEntity() 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        /// <returns>保存成功</returns>
        private bool SaveEntity(bool close)
        {
            var returnValue = false;
            // 转换数据，将实体类保存到数据表
            this.GetEntity();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;

            this.ParentId = BusinessLogic.ConvertToString(this.txtParentId.SelectedValue);
            this.FullName = this.txtFullName.Text;
            // 调用接口方式实现
            //this.PermissionItemEntity.Id = Singleton<PermissionItemService>.Instance.Add(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            this.PermissionItemEntity.Id = RDIFrameworkService.Instance.PermissionItemService.Add(UserInfo, this.PermissionItemEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null && !close && this.Owner is FrmPermissionItemAdmin)
                {
                    ((FrmPermissionItemAdmin)this.Owner).FormOnLoad();
                }
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                returnValue = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
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

        #region private void ClearForm() 清除窗体
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.PermissionItemEntity.Id = string.Empty;
            this.txtCode.Text = "";
            this.txtFullName.Text = "";
            this.txtDescription.Text = "";
        }
        #endregion

        #region private void SaveData(bool close) 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SaveData(bool close)
        {
            // 检查输入的有效性
            if (!this.CheckInput()) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.SaveEntity(close))
                {
                    this.Changed = true;
                    if (close)
                    {
                        // 关闭窗口
                        this.Close();
                    }
                    else
                    {
                        // 重新加载窗体
                        this.ClearForm();
                    }
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
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 保存并关闭窗体
            this.SaveData(true);
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // 保存不关闭窗体
            this.SaveData(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Changed && this.Owner is FrmPermissionItemAdmin)
            {
                ((FrmPermissionItemAdmin)this.Owner).FormOnLoad();
            }
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
