using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class FrmSelectTaskOperUser : BaseForm_Single
    {
        string Key = "";

        public FrmSelectTaskOperUser(string iKey)
        {
            InitializeComponent();
            Key = iKey;
        }


        private void InitializeUIData()
        {
            lvTask.Columns.Add("»ŒŒÒ√˚≥∆", 100, HorizontalAlignment.Left);
            lvTask.Columns.Add("taskId", 0, HorizontalAlignment.Left);
            lvTask.Columns.Add("√Ë ˆ", 200, HorizontalAlignment.Left);
            DataTable dtSearch = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTasks(SystemInfo.UserInfo, Key);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr[WorkTaskTable.FieldTaskCaption].ToString(), 0);
                lvi1.SubItems.Add(dr[WorkTaskTable.FieldWorkTaskId].ToString());
                lvi1.SubItems.Add(dr[WorkTaskTable.FieldDescription].ToString());
                lvTask.Items.Add(lvi1);
            }
        }

        private void FrmSelectTaskOperUser_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

