using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmQueryEngineEdit : BaseForm
    {
        public QueryEngineEntity queryEngineEntity = new QueryEngineEntity();

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
        /// 查询引擎id
        /// </summary>
        private string parentId = string.Empty;

        /// <summary>
        /// 查询引擎id
        /// </summary>
        public string ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }

        public FrmQueryEngineEdit()
        {
            InitializeComponent();
        }

        public FrmQueryEngineEdit(string id)
            : this()
        {
            this.queryEngineEntity.Id = id;
        }

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 从数据权限读取类属性
            if (!string.IsNullOrEmpty(this.queryEngineEntity.Id))
            {
                if (this.queryEngineEntity.ParentId != null && this.queryEngineEntity.ParentId.ToString().Length > 0)
                {
                    this.txtParentId.SelectedValue = this.queryEngineEntity.ParentId;
                    this.txtParentId.Text = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineEntity(UserInfo, this.queryEngineEntity.ParentId.ToString()).FullName;
                }


                this.txtCode.Text = this.queryEngineEntity.Code;
                this.txtFullName.Text = this.queryEngineEntity.FullName;
                this.chkEnabled.Checked = this.queryEngineEntity.Enabled == 1;
                this.chkAllowEdit.Checked = this.queryEngineEntity.AllowEdit == 1;
                this.chkAllowDelete.Checked = this.queryEngineEntity.AllowDelete == 1;
                this.txtDescription.Text = this.queryEngineEntity.Description;
                this.ActiveControl = this.txtCode;
                this.txtCode.Focus();
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
            this.queryEngineEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineEntity(UserInfo, this.queryEngineEntity.Id.ToString());
            // 显示内容
            this.ShowEntity();
            this.Text = "编辑查询引擎 - " + queryEngineEntity.FullName;
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

            this.queryEngineEntity.ParentId = BusinessLogic.ConvertToString(this.txtParentId.SelectedValue);
            if (string.IsNullOrEmpty(this.queryEngineEntity.ParentId))
            {
                this.queryEngineEntity.ParentId = null;
            }

            this.queryEngineEntity.Code = this.txtCode.Text;
            this.queryEngineEntity.FullName = this.txtFullName.Text;
            this.queryEngineEntity.AllowEdit = this.chkAllowEdit.Checked ? 1 : 0;
            this.queryEngineEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            this.queryEngineEntity.AllowDelete = this.chkAllowDelete.Checked ? 1 : 0;
            this.queryEngineEntity.Description = this.txtDescription.Text;
        }
        #endregion

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
            RDIFrameworkService.Instance.QueryEngineService.UpdateQueryEngine(UserInfo, this.queryEngineEntity, out statusCode, out statusMessage);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
