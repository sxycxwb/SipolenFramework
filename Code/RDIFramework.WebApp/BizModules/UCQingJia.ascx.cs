using System;
using System.Data;

namespace RDIFramework.WebApp.BizModules
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class UCQingJia : BaseUserControl
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load();
            if (!IsPostBack)
            {
                InitData();
            }
        }

        /// <summary>
        /// 表单数据展现，考虑表单退回重新处理和保存草稿的情况
        /// 
        /// </summary>
        private void InitData()
        {
            string sql = "select * from testQingjia where workflowinsId=@workflowinsId";
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("testQingjia");
            sqlBuilder.SetWhere("workflowinsId", WorkFlowInsId);
            DataTable dt = sqlBuilder.EndSelect();
            if (dt != null && dt.Rows.Count > 0)//判断是否有数据，有数据读取数据库中的值
            {
                lbUserId.Text = dt.Rows[0]["userid"].ToString();
                lbUserName.Text = dt.Rows[0]["userName"].ToString();
                lbDutyCaption.Text = dt.Rows[0]["dutyCaption"].ToString();
                lbArchCaption.Text = dt.Rows[0]["archCaption"].ToString();
                tbxStartTime.Value = dt.Rows[0]["beginTime"].ToString();
                tbxEndTime.Value = dt.Rows[0]["endTime"].ToString();
                tbxDays.Text = dt.Rows[0]["Days"].ToString();
                tbxQingjia.Text = dt.Rows[0]["QingJia"].ToString();
                dplType.Text = dt.Rows[0]["QingJiaType"].ToString();
            }
            else//如果没有数据，初始化默认值
            {
                lbUserId.Text = UserId;
                lbUserName.Text = UserName;
                lbDutyCaption.Text = DutyCaption;
                lbArchCaption.Text = ArchCaption;
                tbxStartTime.Value = DateTime.Now.ToShortDateString();
                tbxEndTime.Value = DateTime.Now.ToShortDateString();
            }
        }

        /// <summary>
        /// 表单数据提交，避免重复提交
        /// </summary>
        public override void SaveUserControl(bool IsDraft)
        {
            base.SaveUserControl(IsDraft);

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
            sqlBuilder.SetValue("userId", lbUserId.Text);
            sqlBuilder.SetValue("userName", lbUserName.Text);
            sqlBuilder.SetValue("dutyCaption", lbDutyCaption.Text);
            sqlBuilder.SetValue("archCaption", lbArchCaption.Text);
            if (this.WorkFlowDbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue("BeginTime", !string.IsNullOrEmpty(tbxStartTime.Value) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(tbxStartTime.Value)) : BusinessLogic.ConvertToDateToString(tbxStartTime.Value));
                sqlBuilder.SetValue("EndTime", !string.IsNullOrEmpty(tbxEndTime.Value) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(tbxEndTime.Value)) : BusinessLogic.ConvertToDateToString(tbxEndTime.Value));
            }
            else
            {
                sqlBuilder.SetValue("BeginTime", BusinessLogic.ConvertToDateToString(tbxStartTime.Value));
                sqlBuilder.SetValue("EndTime", BusinessLogic.ConvertToDateToString(tbxEndTime.Value));
            }
            sqlBuilder.SetValue("Days", tbxDays.Text);
            sqlBuilder.SetValue("QingJiaType", BusinessLogic.ConvertToString(dplType.SelectedItem.Text));
            sqlBuilder.SetValue("QingJia", tbxQingjia.Text);
            sqlBuilder.EndInsert();
        }
    }
}