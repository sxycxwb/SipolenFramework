using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmQueryEngineDefineAdd
    /// 添加查询引擎定义
    /// 
    /// </summary>
    public partial class FrmQueryEngineDefineAdd : BaseForm
    {
        public QueryEngineDefineEntity entity = null;

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
        private string queryEngineId = string.Empty;

        /// <summary>
        /// 查询引擎id
        /// </summary>
        public string QueryEngineId
        {
            get { return this.queryEngineId; }
            set { this.queryEngineId = value; }
        }

        public FrmQueryEngineDefineAdd()
        {
            InitializeComponent();
        }

        public FrmQueryEngineDefineAdd(string queryEngineId, string parentdFullName)
            : this()
        {
            txtQueryEngineId.SelectedValue = queryEngineId;
            txtQueryEngineId.Text = parentdFullName;
        }

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 设置焦点
            this.ActiveControl = this.txtCode;
            this.txtCode.Focus();
        }
        #endregion

        private void BindCategory()
        {
            List<CiDbLinkDefineEntity> listDbLink = RDIFrameworkService.Instance.DbLinkDefineService.GetList(this.UserInfo);
            var result = listDbLink.Where(p => p.Enabled == 1).OrderByDescending(p => p.SortCode).ToList();
            cboDataBaseLinkName.DisplayMember = CiDbLinkDefineTable.FieldLinkName;
            cboDataBaseLinkName.ValueMember = CiDbLinkDefineTable.FieldId;
            cboDataBaseLinkName.DataSource = result;

            IList<Info> infoList = new List<Info>();
            Info info1 = new Info() { Id = 1, Name = "表或视图" };
            Info info2 = new Info() { Id = 2, Name = "存储过程" };
            infoList.Add(info1);
            infoList.Add(info2);
            cboDataSourceType.DataSource = infoList;
            cboDataSourceType.ValueMember = "Id";
            cboDataSourceType.DisplayMember = "Name";
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            BindCategory();
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

        #region private QueryEngineDefineEntity GetEntity() 转换数据，将表单数据保存到实体类
        /// <summary>
        /// 读取屏幕中输入的数据
        /// </summary>
        /// <returns>操作权限项实体</returns>
        private QueryEngineDefineEntity GetEntity()
        {
            if (this.entity == null)
            {
                this.entity = new QueryEngineDefineEntity();
            }
            this.entity.SortCode = 0;
            this.entity.QueryEngineId = BusinessLogic.ConvertToString(txtQueryEngineId.SelectedValue) ?? null;
            this.entity.Code = this.txtCode.Text;
            this.entity.FullName = this.txtFullName.Text;
            this.entity.DataBaseLinkName = BusinessLogic.ConvertToString(this.cboDataBaseLinkName.SelectedValue);
            this.entity.DataSourceType = BusinessLogic.ConvertToInt(this.cboDataSourceType.SelectedValue);
            this.entity.DataSourceName = this.txtDataSourceName.Text;
            this.entity.QueryStringKey = this.txtQueryStringKey.Text;
            this.entity.QueryString = this.txtQueryString.Text;
            this.entity.SelectedField = this.txtSelectedField.Text;
            this.entity.OrderByField = this.txtOrderByField.Text;
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

            this.QueryEngineId = BusinessLogic.ConvertToString(this.txtQueryEngineId.SelectedValue);
            this.FullName = this.txtFullName.Text;
            this.entity.Id = RDIFrameworkService.Instance.QueryEngineService.AddQueryEngineDefine(UserInfo, this.entity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                if (this.Owner != null && !close && this.Owner is FrmQueryEngineDefineAdmin)
                {
                    ((FrmQueryEngineDefineAdmin)this.Owner).FormOnLoad();
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
                ((FrmQueryEngineDefineAdmin)this.Owner).FormOnLoad();
            }
            this.Close();
        } 
    }
}
