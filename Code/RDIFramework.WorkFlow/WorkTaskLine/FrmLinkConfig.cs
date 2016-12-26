using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class FrmLinkConfig : BaseForm_Single
    {
        public Link NowLink;
        public string UserId = "";//操作人账号，用作权限判断。
        public string UserName = "";

        public FrmLinkConfig(Link link, string userId, string userName)
        {
            InitializeComponent();
            NowLink = link;
            this.UserId = userId;
            this.UserName = userName;
        }

        private void loadCombobox(ComboBox cbx, DataTable dt, string fieldName)
        {
            cbx.Items.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(dr[fieldName].ToString());
                }
            }
            else
            {
                cbx.Items.Add("提交");
            }
        }

        private void LinkConfig_Load(object sender, System.EventArgs e)
        {
            var dt = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTaskCommands(SystemInfo.UserInfo, NowLink.flowGuid, NowLink.startTask.TaskId);
            loadCombobox(cboCommandName, dt, WorkTaskCommandsTable.FieldCommandName);
            tbxCondition.Text = NowLink.Condition;
            ndPriority.Value = NowLink.Priority;
            cboCommandName.Text = NowLink.CommandName;
            tbxDes.Text = NowLink.Des;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NowLink.Condition = tbxCondition.Text;
            NowLink.Priority = Convert.ToInt16(ndPriority.Value);
            if (cboCommandName.SelectedItem != null)
            {
                NowLink.CommandName = cboCommandName.SelectedItem.ToString();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("请选择命令！");
                cboCommandName.Focus();
                return;
            }
            NowLink.Des = tbxDes.Text;
            NowLink.SaveUpdateLink();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCommandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxDes.Text = cboCommandName.SelectedItem.ToString();
        }

        private void btnVarChoose_Click(object sender, EventArgs e)
        {
            var tmpSelectVar = new FrmSelectVar(NowLink.flowGuid, NowLink.startTask.TaskId);
            tmpSelectVar.ShowDialog();
            var dlr = tmpSelectVar.DialogResult;
            if (dlr == DialogResult.OK && tmpSelectVar.lvVar.SelectedItems.Count > 0)
            {
                tbxCondition.Text = tbxCondition.Text + @"<%" + tmpSelectVar.lvVar.SelectedItems[0].Text + @"%>";
            }
        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxCondition.Text = tbxCondition.Text + cboOperator.SelectedItem.ToString();
        }
    }
}
