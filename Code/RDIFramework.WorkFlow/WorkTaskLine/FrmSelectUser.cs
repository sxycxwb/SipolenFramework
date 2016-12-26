using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmSelectUser : BaseForm_Single
    {
        public ListView FatherUserview;
        public FrmSelectUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {
            //列出所有用户
            lvUser.Columns.Add("帐号", 100, HorizontalAlignment.Left);
            lvUser.Columns.Add("用户名", 100, HorizontalAlignment.Left);
            lvUser.Columns.Add("描述", 200, HorizontalAlignment.Left);
        }

        private void FrmSelectUser_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxUserId.Text.Length == 0&&tbxUserName.Text.Length==0)
            {
                MessageBoxHelper.ShowInformationMsg("请输入帐号或者用户名!");
                tbxUserId.Focus();
                return;
                
            }
            lvUser.Clear();
            InitializeUIData();
            DataTable dtSearch=RDIFrameworkService.Instance.UserService.GetDT(this.UserInfo);

            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr[PiUserTable.FieldId].ToString(), 0);
                lvi1.SubItems.Add(dr[PiUserTable.FieldUserName].ToString());
                lvi1.SubItems.Add(dr[PiUserTable.FieldRealName].ToString());
                lvUser.Items.Add(lvi1);
            }
        }
    }
}

