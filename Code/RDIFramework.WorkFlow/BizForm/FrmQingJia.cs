using System;
using System.Data;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 请假申请
    /// </summary>
    public partial class FrmQingJia : FrmBaseBizeForm
    {
        public FrmQingJia()
        {
            InitializeComponent();
        }

        private void FrmQingJia_Load(object sender, EventArgs e)
        {
            base.Form_Load();
            this.SetControlState();
            this.ShowEntity();
        }

        public override void SetControlState()
        {
            if (!string.IsNullOrEmpty(this.PageState))
            {
                this.pnlTool.Enabled = this.PageState != WorkConst.STATE_VIEW;
            }
            
            if (!string.IsNullOrEmpty(this.CtrlState))
            {
                gbMain.Enabled = btnSave.Enabled = this.CtrlState != "查看";
            }
            else
            {
                gbMain.Enabled = btnSave.Enabled = false;
            }
        }

        public override void ShowEntity()
        {
            string sql = "select * from testQingjia where workflowinsId=@workflowinsId";
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("testQingjia");
            sqlBuilder.SetWhere("workflowinsId", WorkFlowInsId);
            DataTable dt = sqlBuilder.EndSelect();
            if (dt != null && dt.Rows.Count > 0)//判断是否有数据，有数据读取数据库中的值
            {
                txtUserId.Text = dt.Rows[0]["userid"].ToString();
                txtUserName.Text = dt.Rows[0]["userName"].ToString();
                txtDuty.Text = dt.Rows[0]["dutyCaption"].ToString();
                txtDepartment.Text = dt.Rows[0]["archCaption"].ToString();
                dtBeginTime.Text = dt.Rows[0]["beginTime"].ToString();
                dtEndTime.Text = dt.Rows[0]["endTime"].ToString();
                txtDays.Text = dt.Rows[0]["Days"].ToString();
                txtQingJia.Text = dt.Rows[0]["QingJia"].ToString();
                cboQingJiaType.Text = dt.Rows[0]["QingJiaType"].ToString();
            }
            else//如果没有数据，初始化默认值
            {
                txtUserId.Text = UserId;
                txtUserName.Text = UserName;
                txtDuty.Text = DutyCaption;
                txtDepartment.Text = ArchCaption;
                dtBeginTime.Text = DateTime.Now.ToShortDateString();
                dtEndTime.Text = DateTime.Now.ToShortDateString();
            }
        }

        public override void SaveFormData(bool isDraft)
        {
            base.SaveFormData(isDraft);
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            string sql = "DELETE TESTQINGJIA WHERE WORKFLOWINSID=@WORKFLOWINSID";//先删除原有数据
            sqlBuilder.BeginDelete("testQingjia");
            sqlBuilder.SetWhere("WORKFLOWINSID", WorkFlowInsId);
            sqlBuilder.EndDelete();


            sqlBuilder.BeginInsert("testQingjia");
            sqlBuilder.SetValue("WorkFlowId", WorkFlowId);
            sqlBuilder.SetValue("WorkTaskId", WorkTaskId);
            sqlBuilder.SetValue("WorkFlowInsId", WorkFlowInsId);
            sqlBuilder.SetValue("WorkTaskInsId", WorkTaskInsId);
            sqlBuilder.SetValue("ID", BusinessLogic.NewGuid());
            sqlBuilder.SetValue("userId", txtUserId.Text);
            sqlBuilder.SetValue("userName", txtUserName.Text);
            sqlBuilder.SetValue("dutyCaption", txtDuty.Text);
            sqlBuilder.SetValue("archCaption", txtDepartment.Text);
            if (this.WorkFlowDbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue("BeginTime", !string.IsNullOrEmpty(dtBeginTime.Text) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(dtBeginTime.Text)) : BusinessLogic.ConvertToDateToString(dtBeginTime.Text));
                sqlBuilder.SetValue("EndTime", !string.IsNullOrEmpty(dtEndTime.Text) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(dtEndTime.Text)) : BusinessLogic.ConvertToDateToString(dtEndTime.Text));
            }
            else
            {
                sqlBuilder.SetValue("BeginTime", BusinessLogic.ConvertToDateToString(dtBeginTime.Text));
                sqlBuilder.SetValue("EndTime", BusinessLogic.ConvertToDateToString(dtEndTime.Text));
            }
            sqlBuilder.SetValue("Days", txtDays.Text);
            sqlBuilder.SetValue("QingJiaType", BusinessLogic.ConvertToString(cboQingJiaType.SelectedItem));
            sqlBuilder.SetValue("QingJia", txtQingJia.Text);
            sqlBuilder.EndInsert();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(BusinessLogic.ConvertToString(cboQingJiaType.SelectedItem)))
            {
                MessageBoxHelper.ShowWarningMsg("请选择请假类型！");
                cboQingJiaType.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDays.Text))
            {
                MessageBoxHelper.ShowWarningMsg("请假天数不能为空！");
                txtDays.Focus();
                return false;
            }

            if(!MathHelper.IsDecimal(txtDays.Text))
            {
                MessageBoxHelper.ShowWarningMsg("请假天数必须为数值型！");
                txtDays.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtQingJia.Text))
            {
                MessageBoxHelper.ShowWarningMsg("请假事由不能为空！");
                txtQingJia.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            this.SaveFormData(false);
            MessageBoxHelper.ShowSuccessMsg("保存成功！");
        }
    }
}
