using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class FrmSelectMainUserCtrl : BaseForm_Single
    {
        public ListView FatherUserview;
        string UserId = "";
        string UserName = "";

        public FrmSelectMainUserCtrl(string iKey)
        {
            InitializeComponent();
            tbxCaption.Text = iKey;
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData(string ikey )
        {
            //列出所有主表单
            lvMainUserCtrl.Columns.Add("主表单名", 200, HorizontalAlignment.Left);
            lvMainUserCtrl.Columns.Add("表单Id", 0, HorizontalAlignment.Left);
            lvMainUserCtrl.Columns.Add("描述", 200, HorizontalAlignment.Left);
            var dtSearch = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainUserControlByFullName(SystemInfo.UserInfo, ikey);
            foreach (DataRow dr in dtSearch.Rows)
            {
                var lvi1 = new ListViewItem(dr[MainUserControlTable.FieldFullName].ToString(), 0);
                lvi1.SubItems.Add(dr[MainUserControlTable.FieldId].ToString());
                lvi1.SubItems.Add(dr[MainUserControlTable.FieldDescription].ToString());
                lvMainUserCtrl.Items.Add(lvi1);
            }
        }

        private void FrmSelectUser_Load(object sender, EventArgs e)
        {
            InitializeUIData(tbxCaption.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxCaption.Text.Length == 0)
            {
                MessageBoxHelper.ShowInformationMsg("请输入主表单名!");
                tbxCaption.Focus();
                return;
            }
            lvMainUserCtrl.Clear();
            InitializeUIData(tbxCaption.Text);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.lvMainUserCtrl.SelectedItems.Count <= 0) return;
            var key = lvMainUserCtrl.SelectedItems[0].SubItems[1].Text;
            var f = new FrmMainUserControl(UserId, UserName, WorkConst.STATE_MOD, key);
            f.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var f = new FrmMainUserControl(UserId, UserName, WorkConst.STATE_ADD, "");
            f.ShowDialog();
        }
    }
}

