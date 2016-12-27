using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserOrganize.cs
    /// 用户兼职组织机构
    /// 
    /// 修改记录
    ///     2014-07-08 V2.8 XuWangBin 增加FrmUserOrganize.cs。
    /// </summary>
    public partial class FrmUserOrganize : BaseForm
    {
        private DataTable DTUserOrganize = null;

        private string userId = string.Empty;
        /// <summary>
        /// 目标用户主键
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public FrmUserOrganize(string userId)
        {
            InitializeComponent();
            this.UserId = userId;
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvTargetResource);
            this.GetUserOrganizeList();
        }

        /// <summary>
        /// 得到用户兼职组织机构列表
        /// </summary>
        private void GetUserOrganizeList()
        {
            PiUserEntity userEntity = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.UserId);
            this.lblResourceName.Text = userEntity.UserName + @"[" + userEntity.RealName + @"]";

            this.DTUserOrganize = RDIFrameworkService.Instance.UserService.GetUserOrganizeDT(this.UserInfo, this.UserId);
            this.dgvTargetResource.AutoGenerateColumns = false;
            this.dgvTargetResource.DataSource = this.DTUserOrganize.DefaultView;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        private void btnAddToOrganize_Click(object sender, EventArgs e)
        {
            var frmAddUserToOrganize = new FrmAddUserToOrganize(this.UserId);
            if (frmAddUserToOrganize.ShowDialog() == DialogResult.OK)
            {
                this.GetUserOrganizeList();
            }
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvTargetResource, PiUserOrganizeTable.FieldId, "colSelected", true);
        }
        #endregion

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            return RDIFrameworkService.Instance.UserService.BatchDeleteUserOrganize(UserInfo, this.GetSelecteIds());
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvTargetResource, "colSelected")) return;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) != DialogResult.Yes) return;

            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int result = this.BatchRemove();
                this.GetUserOrganizeList();
                this.SetControlState();
                if (SystemInfo.ShowInformation)
                {
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0077, result.ToString()));
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
