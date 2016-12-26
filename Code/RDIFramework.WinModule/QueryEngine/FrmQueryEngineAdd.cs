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
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmQueryEngineAdd : BaseForm
    {
        public QueryEngineEntity entity = null;

        /// <summary>
        /// 名称
        /// </summary>
        private string fullName = string.Empty;

        /// <summary>
        /// 名称
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

        public FrmQueryEngineAdd()
        {
            InitializeComponent();
        }

        public FrmQueryEngineAdd(string parentId, string parentdFullName)
            : this()
        {
            txtParentId.SelectedValue = parentId;
            txtParentId.Text = parentdFullName;
        }

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            if (this.entity != null)
            {
                this.txtCode.Text = this.entity.Code;
                this.txtFullName.Text = this.entity.FullName;
                this.chkAllowEdit.Checked = this.entity.AllowEdit == 1;
                this.chkEnabled.Checked = this.entity.Enabled == 1;
                this.chkAllowDelete.Checked = this.entity.AllowDelete == 1;
                this.txtDescription.Text = this.entity.Description;
            }
            // 设置焦点
            this.ActiveControl = this.txtCode;
            this.txtCode.Focus();
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

        #region private QueryEngineEntity GetEntity() 转换数据，将表单数据保存到实体类
        /// <summary>
        /// 读取屏幕中输入的数据
        /// </summary>
        /// <returns>操作权限项实体</returns>
        private QueryEngineEntity GetEntity()
        {
            if (this.entity == null)
            {
                this.entity = new QueryEngineEntity();
            }
            this.entity.SortCode = 0;
            this.entity.ParentId = BusinessLogic.ConvertToString(txtParentId.SelectedValue) ?? null;
            this.entity.Code = this.txtCode.Text;
            this.entity.FullName = this.txtFullName.Text;
            this.entity.AllowEdit = this.chkAllowEdit.Checked ? 1 : 0;
            this.entity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.entity.AllowDelete = this.chkAllowDelete.Checked ? 1 : 0;
            this.entity.DeleteMark = 0;
            this.entity.Description = this.txtDescription.Text;
            return this.entity;
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
            this.entity.Id = RDIFrameworkService.Instance.QueryEngineService.AddQueryEngine(UserInfo, this.entity, out statusCode, out statusMessage);
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
            this.entity.Id = string.Empty;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Changed && this.Owner is FrmPermissionItemAdmin)
            {
                ((FrmQueryEngineAdmin)this.Owner).FormOnLoad();
            }
            this.Close();
        } 
    }
}
