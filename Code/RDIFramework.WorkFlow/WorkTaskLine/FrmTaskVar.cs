using System;
using System.Data;
using System.Globalization;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmTaskVar.cs
    /// 任务变量
    /// 
    /// </summary>
    public partial class FrmTaskVar : BaseForm_Single
    {
        public string TaskVarId { get; set; }
        public string FmSate { get; set; }
        //RDIFrameworkWFV3.0
        private string varDataBaseName = "RDIFrameworkWFV3.0";

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string VarDataBaseName 
        {
            get { return this.varDataBaseName; }
            set { this.varDataBaseName = value; }
        }

        public string VarDataTableName { get; set; }
        public string VarTableColumnName { get; set; }
        public string SortField { get; set; }

        public FrmTaskVar(string sate)
        {
            InitializeComponent();
            this.txtCurrentDataBase.Text = @"RDIFrameworkWFV3.0";
            FmSate = sate;
        }

        public override void FormOnLoad()
        {
            InitData();
        }

        private void InitData()
        {
            if (cbxVarType.SelectedIndex < 0) cbxVarType.SelectedIndex = 0;//默认值
            if (cbxVarModule.SelectedIndex < 0) cbxVarModule.SelectedIndex = 0;
            this.VarDataBaseName = "RDIFrameworkWFV3.0";
            var bizService = new BusinessDBProviderService(SystemInfo.WorkFlowDbConnectionString, SystemInfo.WorkFlowDbType);

            string sqlString = string.Empty;
            switch (SystemInfo.RDIFrameworkDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    sqlString = string.IsNullOrEmpty(VarDataBaseName)
                        ? "SELECT * FROM ..SysObjects Where XType='U' ORDER BY Name"
                        : "SELECT * FROM [" + VarDataBaseName + "]..SysObjects Where XType='U' ORDER BY Name";
                    break;
                case CurrentDbType.MySql:
                    varDataBaseName = "rdiframework_wf_v30";
                    this.txtCurrentDataBase.Text = varDataBaseName;
                    sqlString = string.IsNullOrEmpty(varDataBaseName)
                        ? "SELECT TABLE_NAME name FROM information_schema.tables  WHERE TABLE_TYPE = 'BASE TABLE'"
                        : "SELECT TABLE_NAME name FROM information_schema.tables  WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA='" + VarDataBaseName + "'";
                    break;
                case CurrentDbType.Oracle:
                    sqlString = "select table_name name from user_tables";
                    break;
            }
            DataTable dtTables = bizService.Fill(SystemInfo.UserInfo, sqlString);
            BasePageLogic.BindCombo(cbxDataTable, dtTables, "name", "name");
            //绑定指定表的所有列：
            //select name from [RDIFrameworkWFV3.0].dbo.syscolumns where id=(select id from [RDIFrameworkWFV2.8].dbo.sysobjects where name='testQingjia')

            if (!string.IsNullOrEmpty(VarDataTableName))
            {
                switch (SystemInfo.RDIFrameworkDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.SqlServer:
                        sqlString = "select name from [" + VarDataBaseName + "].dbo.syscolumns where id=(select id from [" + VarDataBaseName + "].dbo.sysobjects where name='" + VarDataTableName + "')";
                        break;
                    case CurrentDbType.Oracle:
                        sqlString = "SELECT column_name name FROM USER_TAB_COLS WHERE TABLE_NAME = '" + VarDataTableName + "'";
                        break;
                    case CurrentDbType.MySql:
                        sqlString = "SELECT COLUMN_NAME name FROM information_schema.COLUMNS WHERE TABLE_NAME = '" + VarDataTableName + "'";
                        break;
                }
                DataTable dtColumns = bizService.Fill(SystemInfo.UserInfo, sqlString);
                BasePageLogic.BindCombo(cbxTableColumns, dtColumns, "name", "name");
            }

            if (FmSate == WorkConst.STATE_MOD)
            {
                cbxDataTable.Text = VarDataTableName;
                cbxTableColumns.Text = VarTableColumnName;
                comboBoxbx.Text = SortField;
            }
        }

        private string GetTableColumnsSql(string dbName, string tableName)
        {
            string sqlString = string.Empty;
            switch (SystemInfo.RDIFrameworkDbType)
            {
                case CurrentDbType.SqlServer:
                    sqlString = "select name from [" + dbName + "].dbo.syscolumns where id=(select id from [" + dbName + "].dbo.sysobjects where name='" + tableName + "')";
                    break;
                case CurrentDbType.MySql:
                    sqlString = "SELECT COLUMN_NAME name FROM information_schema.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
                    break;
                case CurrentDbType.Oracle:
                    sqlString = "SELECT column_name name FROM USER_TAB_COLS WHERE TABLE_NAME = '" + tableName + "'";
                    break;
            }

            return sqlString;
        }

        private void cbxDatatable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDataTable.SelectedIndex == 0) return;
            var bizService = new BusinessDBProviderService(SystemInfo.WorkFlowDbConnectionString, SystemInfo.WorkFlowDbType);
            DataTable dtColumns = bizService.Fill(SystemInfo.UserInfo, this.GetTableColumnsSql(VarDataBaseName, cbxDataTable.Text));
            BasePageLogic.BindCombo(cbxTableColumns, dtColumns, "name", "name");
            cbxTableColumns.SelectedIndex = 0;
            BasePageLogic.BindCombo(comboBoxbx, dtColumns, "name", "name");
            comboBoxbx.SelectedIndex = 0;
        }

        private bool CheckValue()
        {
            if (cbxDataTable.SelectedIndex == 0) return false;
            if (cbxTableColumns.SelectedIndex == 0) return false;
            return true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (CheckValue() == false)
            {
                MessageBoxHelper.ShowWarningMsg("表名或者字段!!");
                return;
            }

            try
            {
                string sql = "select   " + cbxTableColumns.SelectedItem.ToString() + " from " + cbxDataTable.SelectedItem.ToString() + " where 1=2 ";
                if (comboBoxbx.SelectedItem != null && comboBoxbx.SelectedItem.ToString() != "" && comboBoxbx.SelectedItem.ToString() != "请选择...")
                {
                    sql = sql + " order by " + comboBoxbx.SelectedItem.ToString() + " DESC";
                }

                var bizService = new BusinessDBProviderService(SystemInfo.WorkFlowDbConnectionString, SystemInfo.WorkFlowDbType);
                bizService.Fill(SystemInfo.UserInfo, sql);
                MessageBoxHelper.ShowSuccessMsg("测试连接成功!");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("测试连接失败:" + ex.Message.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
