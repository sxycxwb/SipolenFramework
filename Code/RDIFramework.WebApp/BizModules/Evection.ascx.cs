using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.BizModules
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// 差旅报销表单
    /// </summary>
    public partial class Evection : BaseUserControl
    {
        public static  DataTable evectionDetTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load();
            Panel2.Visible = CtrlState != WorkConst.STATE_VIEW; //控制编辑区是否显示
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("TestEvection");
            sqlBuilder.SetWhere("workflowinsId", WorkFlowInsId);
            DataTable dtEvection = sqlBuilder.EndSelect();

            if (dtEvection != null && dtEvection.Rows.Count > 0)//检查是否有数据
            {
                tbxBillCode.Text = dtEvection.Rows[0]["BillCode"].ToString(); ;
                YYSubmitDate.Value = dtEvection.Rows[0]["SubmitDate"].ToString();
                tbxSubmitUser.Text = dtEvection.Rows[0]["SubmitUser"].ToString();
                tbxDept.Text = dtEvection.Rows[0]["SubmitDepartment"].ToString();
                tbxReason.Text = dtEvection.Rows[0]["Reason"].ToString();
                tbxTotal.Text = dtEvection.Rows[0]["Total"].ToString();
                tbxCntotal.Text = dtEvection.Rows[0]["CnTotal"].ToString();
                tbxFactprice.Text = dtEvection.Rows[0]["FactPrice"].ToString();
                tbxLendprice.Text = dtEvection.Rows[0]["LendPrice"].ToString();
                tbxRemark.Text = dtEvection.Rows[0]["Description"].ToString();

                sqlBuilder.BeginSelect("TestEvectionDetail");
                sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
                evectionDetTable = sqlBuilder.EndSelect();
            }
            else
            {
                tbxBillCode.Text = "Evection-" + BusinessLogic.NewGuid();
                YYSubmitDate.Value = DateTimeHelper.GetDate(DateTime.Now);
                tbxSubmitUser.Text = this.UserName;
                tbxDept.Text = this.ArchCaption;
                sqlBuilder.BeginSelect("TestEvectionDetail");
                sqlBuilder.SetWhere("Id", ""); //得到一个空表
                evectionDetTable = sqlBuilder.EndSelect(); 
            }
            GridView1.DataSource = evectionDetTable;
            GridView1.DataBind();
        }

        private void DataBindSource()
        {
            GridView1.DataSource = evectionDetTable;
            GridView1.DataBind();
        }

        private void SumTotal()
        {
            double total = 0.00;
            double vehiclecost = 0.00;//车票费
            double livecost = 0.00;//住宿费
            double citycost = 0.00;//市内交通费
            double evectioncost = 0.00;//补贴
            double others = 0.00;//其他费
            double lendprice = 0.00;//借款

            foreach (DataRow dr in evectionDetTable.Rows)
            {
                vehiclecost = 0.00;//车票费
                livecost = 0.00;//住宿费
                citycost = 0.00;//市内交通费
                evectioncost = 0.00;//补贴
                others = 0.00;//其他费
                lendprice = 0.00;//借款
                if (dr["vehiclecost"].ToString().Length != 0)
                    vehiclecost = Convert.ToDouble(dr["vehiclecost"]);
                if (dr["citycost"].ToString().Length != 0)
                    citycost = Convert.ToDouble(dr["citycost"]);
                if (dr["liveprice"].ToString().Length != 0 && dr["livedays"].ToString().Length != 0)
                {
                    livecost = Convert.ToDouble(dr["livedays"]) * Convert.ToDouble(dr["liveprice"]);
                }
                if (dr["evectiondays"].ToString().Length != 0 && dr["allowance"].ToString().Length != 0)
                {
                    evectioncost = Convert.ToDouble(dr["evectiondays"]) * Convert.ToDouble(dr["allowance"]);
                }
                if (dr["others"].ToString().Length != 0)
                    others = Convert.ToDouble(dr["others"]);

                total = total + vehiclecost + citycost + livecost + evectioncost + others;
            }

            tbxTotal.Text = total.ToString();
            if (tbxLendprice.Text.Length != 0)
            {
                lendprice = Convert.ToDouble(tbxLendprice.Text);
            }
            tbxFactprice.Text = Convert.ToString(Math.Round(total - lendprice, 2));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxStartaddress.Text.Length == 0)
                {
                    ShowMessage(this.Page, "请输入起点。");
                    return;
                }
                if (tbxEndaddress.Text.Length == 0)
                {
                    ShowMessage(this.Page, "请输入终点。");
                    return;
                }

                if (evectionDetTable == null)
                {
                    var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
                    sqlBuilder.BeginSelect("TestEvectionDetail");
                    sqlBuilder.SetWhere("Id", ""); //得到一个空表
                    evectionDetTable = sqlBuilder.EndSelect(); 
                }

                DataRow dr = evectionDetTable.NewRow();
                dr["WorkFlowId"] = WorkFlowId;
                dr["WorkFlowInsId"] = WorkFlowInsId;
                dr["WorkTaskId"] = WorkTaskId;
                dr["WorkTaskInsId"] = WorkTaskInsId;
                dr["BillCode"] = tbxBillCode.Text;
                dr["startaddress"] = tbxStartaddress.Text;
                dr["endaddress"] = tbxEndaddress.Text;
                dr["vehicle"] = drpVehicle.SelectedValue;
                dr["vehiclecost"] = tbxVehicelcost.Text;
                dr["citycost"] = tbxCitycost.Text;
                dr["livedays"] = tbxLivedays.Text;
                dr["liveprice"] = tbxLiveprice.Text;
                dr["evectiondays"] = tbxEvectiondays.Text;
                dr["allowance"] = tbxAllowance.Text;
                dr["others"] = tbxOthers.Text;
                evectionDetTable.Rows.Add(dr);
                DataBindSource();
                SumTotal();
            }
            catch (Exception ex)
            {
                ShowMessage(this.Page, "增加失败:" + ex.Message.ToString());
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxStartaddress.Text.Length == 0)
                {
                    ShowMessage(this.Page, "请输入起点。");
                    return;
                }
                if (tbxEndaddress.Text.Length == 0)
                {
                    ShowMessage(this.Page, "请输入终点。");
                    return;
                }

                DataRow dr = evectionDetTable.Rows[GridView1.SelectedIndex];

                dr["WorkFlowId"] = WorkFlowId;
                dr["WorkFlowInsId"] = WorkFlowInsId;
                dr["WorkTaskId"] = WorkTaskId;
                dr["WorkTaskInsId"] = WorkTaskInsId;
                dr["BillCode"] = tbxBillCode.Text;
                dr["startaddress"] = tbxStartaddress.Text;
                dr["endaddress"] = tbxEndaddress.Text;
                dr["vehicle"] = drpVehicle.SelectedValue;
                dr["vehiclecost"] = tbxVehicelcost.Text;
                dr["citycost"] = tbxCitycost.Text;
                dr["livedays"] = tbxLivedays.Text;
                dr["liveprice"] = tbxLiveprice.Text;
                dr["evectiondays"] = tbxEvectiondays.Text;
                dr["allowance"] = tbxAllowance.Text;
                dr["others"] = tbxOthers.Text;

                DataBindSource();
                SumTotal();
            }
            catch (Exception ex)
            {
                ShowMessage(this.Page, "增加失败:" + ex.Message.ToString());
            }
        }

        private void SaveEvectionDet()
        {
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginDelete("TestEvectionDetail");
            sqlBuilder.SetWhere("WORKFLOWINSID", WorkFlowInsId);//首先删除已有的数据
            sqlBuilder.EndDelete();

            foreach (DataRow dr in evectionDetTable.Rows)
            {
                sqlBuilder.BeginInsert("TestEvectionDetail");
                sqlBuilder.SetValue("Id", BusinessLogic.NewGuid());
                sqlBuilder.SetValue("WorkFlowId", WorkFlowId);
                sqlBuilder.SetValue("WorkTaskId", WorkTaskId);
                sqlBuilder.SetValue("WorkFlowInsId", WorkFlowInsId);
                sqlBuilder.SetValue("WorkTaskInsId", WorkTaskInsId);
                sqlBuilder.SetValue("BillCode", dr["BillCode"].ToString());
                sqlBuilder.SetValue("StartAddress", dr["StartAddress"].ToString());
                sqlBuilder.SetValue("EndAddress", dr["EndAddress"].ToString());
                sqlBuilder.SetValue("Vehicle", dr["Vehicle"].ToString());
                sqlBuilder.SetValue("VehicleCost", BusinessLogic.ConvertToNullableDecimal(dr["VehicleCost"]));
                sqlBuilder.SetValue("CityCost", BusinessLogic.ConvertToNullableDecimal(dr["CityCost"]));
                sqlBuilder.SetValue("LiveDays", BusinessLogic.ConvertToNullableDecimal(dr["LiveDays"]));
                sqlBuilder.SetValue("LivePrice", BusinessLogic.ConvertToNullableDecimal(dr["LivePrice"]));
                sqlBuilder.SetValue("EvectionDays", BusinessLogic.ConvertToNullableDecimal(dr["EvectionDays"]));
                sqlBuilder.SetValue("Allowance", BusinessLogic.ConvertToNullableDecimal(dr["Allowance"]));
                sqlBuilder.SetValue("Others", BusinessLogic.ConvertToNullableDecimal(dr["Others"]));
                sqlBuilder.EndInsert();
            }
        }

        public override void SaveUserControl(bool IsDraft)
        {
            base.SaveUserControl(IsDraft);
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("TestEvection");
            sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
            DataTable dtTemp = sqlBuilder.EndSelect();
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                sqlBuilder.BeginUpdate("TestEvection");
            }
            else
            {
                sqlBuilder.BeginInsert("TestEvection");
            }

            sqlBuilder.SetValue("WorkFlowId", WorkFlowId);
            sqlBuilder.SetValue("WorkTaskId", WorkTaskId);
            sqlBuilder.SetValue("WorkFlowInsId", WorkFlowInsId);
            sqlBuilder.SetValue("WorkTaskInsId", WorkTaskInsId);
            sqlBuilder.SetValue("BillCode",tbxBillCode.Text);
             if (this.WorkFlowDbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue("SubmitDate", !string.IsNullOrEmpty(YYSubmitDate.Value) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(YYSubmitDate.Value)) : BusinessLogic.ConvertToDateToString(YYSubmitDate.Value));
            }
            else
            {
                sqlBuilder.SetValue("SubmitDate", BusinessLogic.ConvertToDateToString(YYSubmitDate.Value));
            }

            sqlBuilder.SetValue("SubmitUser",  tbxSubmitUser.Text);
            sqlBuilder.SetValue("SubmitDepartment",tbxDept.Text);
            sqlBuilder.SetValue("Total", BusinessLogic.ConvertToNullableDecimal(tbxTotal.Text));
            if (tbxLendprice.Text.Length != 0)
            {
                sqlBuilder.SetValue("LendPrice", BusinessLogic.ConvertToNullableDecimal(tbxLendprice.Text));
            }
            if (tbxFactprice.Text.Length != 0)
            {
                sqlBuilder.SetValue("FactPrice", BusinessLogic.ConvertToNullableDecimal(tbxFactprice.Text));
            }

            sqlBuilder.SetValue("Reason", tbxReason.Text);
            sqlBuilder.SetValue("Description", tbxRemark.Text);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
                sqlBuilder.EndUpdate();
            }
            else
            {
                sqlBuilder.SetValue("ID", BusinessLogic.NewGuid());
                sqlBuilder.EndInsert();
            }
            SaveEvectionDet();
        }
       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (CtrlState == WorkConst.STATE_VIEW) return;

            evectionDetTable.Rows.Remove(evectionDetTable.Rows[e.RowIndex]);
            DataBindSource();
            SumTotal();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = GridView1.SelectedRow;
            tbxStartaddress.Text = gvr.Cells[1].Text;
            tbxEndaddress.Text = gvr.Cells[2].Text;
            drpVehicle.Text = gvr.Cells[3].Text;
            tbxVehicelcost.Text = gvr.Cells[4].Text;
            tbxCitycost.Text = gvr.Cells[5].Text;
            tbxLivedays.Text = gvr.Cells[6].Text;
            tbxLiveprice.Text = gvr.Cells[7].Text;
            tbxEvectiondays.Text = gvr.Cells[8].Text;
            tbxAllowance.Text = gvr.Cells[9].Text;
            tbxOthers.Text = gvr.Cells[10].Text;
        }

        private void ShowMessage(Page p, string strMsg)
        {
            if (!p.IsStartupScriptRegistered("hello"))
                p.RegisterStartupScript("hello", "<script>alert('" + strMsg + "')</script>");

        }
    }
}