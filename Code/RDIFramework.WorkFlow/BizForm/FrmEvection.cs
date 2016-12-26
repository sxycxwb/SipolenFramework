using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 差旅报销业务表单
    /// </summary>
    public partial class FrmEvection : FrmBaseBizeForm
    {
        DataTable evectionDetTable;

        public FrmEvection()
        {
            InitializeComponent();
        }

        private void FrmEvection_Load(object sender, EventArgs e)
        {
            base.Form_Load();
            this.SetControlState();
            this.ShowEntity();
        }

        public override void SetControlState()
        {
            if (!string.IsNullOrEmpty(this.PageState))
            {
                this.pnlTool.Enabled = this.panel2.Visible = this.PageState != WorkConst.STATE_VIEW;
            }

            if (!string.IsNullOrEmpty(this.CtrlState))
            {
                btnAdd.Enabled = btnEdit.Enabled = btnSave.Enabled = this.CtrlState != "查看";
            }
            else
            {
                btnAdd.Enabled = btnEdit.Enabled = btnSave.Enabled = false;
            }
        }

        private void BindDgv()
        {
            this.dgvEvectionDetail.AutoGenerateColumns = false;
            this.dgvEvectionDetail.DataSource = evectionDetTable;
        }

        public override void ShowEntity()
        {
            var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            sqlBuilder.BeginSelect("TestEvection");
            sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
            DataTable dtEvection = sqlBuilder.EndSelect();

            if (dtEvection != null && dtEvection.Rows.Count > 0)//检查是否有数据
            {
                txtBillCode.Text = dtEvection.Rows[0]["BillCode"].ToString(); ;
                dtSubmitDate.Text = dtEvection.Rows[0]["SubmitDate"].ToString();
                txtSubmitUser.Text = dtEvection.Rows[0]["SubmitUser"].ToString();
                txtDepartment.Text = dtEvection.Rows[0]["SubmitDepartment"].ToString();
                txtReason.Text = dtEvection.Rows[0]["Reason"].ToString();
                txtTotal.Text = dtEvection.Rows[0]["Total"].ToString();
                txtCnTotal.Text = dtEvection.Rows[0]["CnTotal"].ToString();
                txtFactPrice.Text = dtEvection.Rows[0]["FactPrice"].ToString();
                txtLendPrice.Text = dtEvection.Rows[0]["LendPrice"].ToString();
                txtDescription.Text = dtEvection.Rows[0]["Description"].ToString();

                sqlBuilder.BeginSelect("TestEvectionDetail");
                sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
                evectionDetTable = sqlBuilder.EndSelect();
            }
            else
            {
                txtBillCode.Text = "Evection-" + BusinessLogic.NewGuid();
                txtSubmitUser.Text = DateTimeHelper.GetDate(DateTime.Now);
                txtSubmitUser.Text = this.UserName;
                txtDepartment.Text = this.ArchCaption;
                this.dtSubmitDate.Value = DateTime.Now;
                sqlBuilder.BeginSelect("TestEvectionDetail");
                sqlBuilder.SetWhere("Id", ""); //得到一个空表
                evectionDetTable = sqlBuilder.EndSelect();
            }

            this.BindDgv();
        }

        private bool CheckEvectionDetailInput()
        {
            if (string.IsNullOrEmpty(txtStartAddress.Text))
            {
                MessageBoxHelper.ShowWarningMsg("必须输入起点！");
                txtStartAddress.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEndAddress.Text))
            {
                MessageBoxHelper.ShowWarningMsg("必须输入终点！");
                txtEndAddress.Focus();
                return false;
            }

            return true;
        }

        private void SumTotal()
        {
            double total = 0.00;
            double VehicleCost = 0.00;//车票费
            double livecost = 0.00;//住宿费
            double CityCost = 0.00;//市内交通费
            double evectioncost = 0.00;//补贴
            double Others = 0.00;//其他费
            double lendprice = 0.00;//借款

            foreach (DataRow dr in evectionDetTable.Rows)
            {
                VehicleCost = 0.00;//车票费
                livecost = 0.00;//住宿费
                CityCost = 0.00;//市内交通费
                evectioncost = 0.00;//补贴
                Others = 0.00;//其他费
                lendprice = 0.00;//借款
                if (dr["VehicleCost"].ToString().Length != 0)
                    VehicleCost = Convert.ToDouble(dr["VehicleCost"]);
                if (dr["CityCost"].ToString().Length != 0)
                    CityCost = Convert.ToDouble(dr["CityCost"]);
                if (dr["LivePrice"].ToString().Length != 0 && dr["LiveDays"].ToString().Length != 0)
                {
                    livecost = Convert.ToDouble(dr["LiveDays"]) * Convert.ToDouble(dr["LivePrice"]);
                }
                if (dr["EvectionDays"].ToString().Length != 0 && dr["Allowance"].ToString().Length != 0)
                {
                    evectioncost = Convert.ToDouble(dr["EvectionDays"]) * Convert.ToDouble(dr["Allowance"]);
                }
                if (dr["Others"].ToString().Length != 0)
                    Others = Convert.ToDouble(dr["Others"]);

                total = total + VehicleCost + CityCost + livecost + evectioncost + Others;
            }

            txtTotal.Text = total.ToString();
            if (txtLendPrice.Text.Length != 0)
            {
                lendprice = Convert.ToDouble(txtLendPrice.Text);
            }
            txtFactPrice.Text = Convert.ToString(Math.Round(total - lendprice, 2));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.CheckEvectionDetailInput())
            {
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
            dr["BillCode"] = txtBillCode.Text;
            dr["StartAddress"] = txtStartAddress.Text;
            dr["EndAddress"] = txtEndAddress.Text;
            dr["Vehicle"] = cboVehicle.Text;
            dr["VehicleCost"] = txtVehicleCost.Text;
            dr["CityCost"] = BusinessLogic.ConvertToNullableDecimal(txtCityCost.Text);
            dr["LiveDays"] = BusinessLogic.ConvertToNullableDecimal(txtLiveDays.Text);
            dr["LivePrice"] = BusinessLogic.ConvertToNullableDecimal(txtLivePrice.Text);
            dr["EvectionDays"] = BusinessLogic.ConvertToNullableDecimal(txtEvectionDays.Text);
            dr["Allowance"] = BusinessLogic.ConvertToNullableDecimal(txtAllowance.Text);
            dr["Others"] = BusinessLogic.ConvertToNullableDecimal(txtOthers.Text);
            evectionDetTable.Rows.Add(dr);
            this.BindDgv();
            SumTotal();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!this.CheckEvectionDetailInput())
            {
                return;
            }

            DataRow dr = evectionDetTable.Rows[dgvEvectionDetail.CurrentCell.RowIndex];

            dr["WorkFlowId"] = WorkFlowId;
            dr["WorkFlowInsId"] = WorkFlowInsId;
            dr["WorkTaskId"] = WorkTaskId;
            dr["WorkTaskInsId"] = WorkTaskInsId;
            dr["BillCode"] = txtBillCode.Text;
            dr["StartAddress"] = txtStartAddress.Text;
            dr["EndAddress"] = txtEndAddress.Text;
            dr["Vehicle"] = cboVehicle.Text;
            dr["VehicleCost"] = txtVehicleCost.Text;
            dr["CityCost"] = BusinessLogic.ConvertToNullableDecimal(txtCityCost.Text);
            dr["LiveDays"] = BusinessLogic.ConvertToNullableDecimal(txtLiveDays.Text);
            dr["LivePrice"] = BusinessLogic.ConvertToNullableDecimal(txtLivePrice.Text);
            dr["EvectionDays"] = BusinessLogic.ConvertToNullableDecimal(txtEvectionDays.Text);
            dr["Allowance"] = BusinessLogic.ConvertToNullableDecimal(txtAllowance.Text);
            dr["Others"] = BusinessLogic.ConvertToNullableDecimal(txtOthers.Text);
            this.BindDgv();
            SumTotal();
        }

        private void dgvEvectionDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvEvectionDetail.CurrentCell == null)
            {
                return;
            }
            DataRow dr = evectionDetTable.Rows[dgvEvectionDetail.CurrentCell.RowIndex];
            txtStartAddress.Text = dr["StartAddress"].ToString() ?? "";
            txtEndAddress.Text = dr["EndAddress"].ToString() ?? "";
            cboVehicle.Text = dr["Vehicle"].ToString() ?? "";
            txtVehicleCost.Text = dr["VehicleCost"].ToString() ?? "";
            txtCityCost.Text = dr["CityCost"].ToString() ?? "";
            txtLiveDays.Text = dr["LiveDays"].ToString() ?? "";
            txtLivePrice.Text = dr["LivePrice"].ToString() ?? "";
            txtEvectionDays.Text = dr["EvectionDays"].ToString() ?? "";
            txtAllowance.Text = dr["Allowance"].ToString() ?? "";
            txtOthers.Text = dr["Others"].ToString() ?? "";
        }

        private void txtVehicleCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            BasePageLogic.InputControl(sender, e, '.');//使其只能输入数字与小数点
        }

        private void txtFactPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotal.Text) && MathHelper.IsDecimal(txtTotal.Text))
            {
                txtCnTotal.Text = RMBHelper.CmycurD(decimal.Parse(txtTotal.Text));
            }
        }

        private bool CheckInput()
        {
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

        public override void SaveFormData(bool isDraft)
        {
            base.SaveFormData(isDraft);
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
           
            sqlBuilder.SetValue("WorkTaskInsId", WorkTaskInsId);
            sqlBuilder.SetValue("BillCode", txtBillCode.Text);
            if (this.WorkFlowDbProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue("SubmitDate", !string.IsNullOrEmpty(dtSubmitDate.Text) ? BusinessLogic.GetOracleDateFormat(DateTimeHelper.ToDate(dtSubmitDate.Text)) : BusinessLogic.ConvertToDateToString(dtSubmitDate.Text));
            }
            else
            {
                sqlBuilder.SetValue("SubmitDate", BusinessLogic.ConvertToDateToString(dtSubmitDate.Text));
            }
            sqlBuilder.SetValue("SubmitUser", txtSubmitUser.Text);
            sqlBuilder.SetValue("SubmitDepartment", txtDepartment.Text);
            sqlBuilder.SetValue("Total", BusinessLogic.ConvertToNullableDecimal(txtTotal.Text));
            sqlBuilder.SetValue("CnTotal", txtCnTotal.Text);
            if (txtLendPrice.Text.Length != 0)
            {
                sqlBuilder.SetValue("LendPrice", BusinessLogic.ConvertToNullableDecimal(txtLendPrice.Text));
            }
            if (txtFactPrice.Text.Length != 0)
            {
                sqlBuilder.SetValue("FactPrice", BusinessLogic.ConvertToNullableDecimal(txtFactPrice.Text));
            }

            sqlBuilder.SetValue("Reason", txtReason.Text);
            sqlBuilder.SetValue("Description", txtDescription.Text);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                sqlBuilder.SetWhere("WorkFlowInsId", WorkFlowInsId);
                sqlBuilder.EndUpdate();
            }
            else
            {
                sqlBuilder.SetValue("WorkFlowInsId", WorkFlowInsId);
                sqlBuilder.SetValue("ID", BusinessLogic.NewGuid());
                sqlBuilder.EndInsert();
            }
            SaveEvectionDet();
        }
    }
}
