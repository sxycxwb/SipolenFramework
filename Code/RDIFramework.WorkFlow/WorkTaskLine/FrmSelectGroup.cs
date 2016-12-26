using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    public partial class FrmSelectGroup : BaseForm_Single
    {
        public FrmSelectGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {
            lvGroup.Columns.Add("角色名称", 100, HorizontalAlignment.Left);
            lvGroup.Columns.Add("groupId", 0, HorizontalAlignment.Left);
            lvGroup.Columns.Add("描述", 200, HorizontalAlignment.Left);
        }

        private void plclassFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectGroupFm_Load(object sender, EventArgs e)
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
            //if (tbxGroupName.Text.Length == 0)
            //{
            //    WorkDialog.InformationDlg("请输入角色名称!", "请输入查询条件");
            //    tbxGroupName.Focus();
            //    return;

            //}
            lvGroup.Clear();
            InitializeUIData();
            DataTable dtSearch = null;
            string[] names = {PiRoleTable.FieldCategory,PiRoleTable.FieldEnabled,PiRoleTable.FieldDeleteMark};
            string[] values = {"Duty","1","0"};
            dtSearch = RDIFrameworkService.Instance.RoleService.GetDTByValues(this.UserInfo, names, values);
            //dtSearch = GroupData.GetGroupTableByName(tbxGroupName.Text);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["GroupName"].ToString(), 0);
                lvi1.SubItems.Add(dr["GroupId"].ToString());
                lvi1.SubItems.Add(dr["GroupDes"].ToString());
                lvGroup.Items.Add(lvi1);
            }

        }
        
    }
}

