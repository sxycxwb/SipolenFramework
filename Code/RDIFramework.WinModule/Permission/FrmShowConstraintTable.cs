using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmShowConstraintTable
    /// 查看约束数据集
    /// 
    /// </summary>
    public partial class FrmShowConstraintTable : BaseForm
    {
        public FrmShowConstraintTable()
        {
            InitializeComponent();
        }

        private string tableName = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        private string tableRealName = string.Empty;
        /// <summary>
        /// 表全名
        /// </summary>
        public string TableRealName
        {
            get
            {
                return tableRealName;
            }
            set
            {
                tableRealName = value;
            }
        }


        private string tableConstraint = string.Empty;
        /// <summary>
        /// 条件表达式
        /// </summary>
        public string TableConstraint
        {
            get
            {
                return tableConstraint;
            }
            set
            {
                tableConstraint = value;
            }
        }


        public FrmShowConstraintTable(string tableRealName, string tableName, string tableConstraint)
            : this()
        {
            this.TableRealName = tableRealName;
            this.TableName = tableName;
            this.TableConstraint = tableConstraint;
            this.LoadUserParameters = false;
        }

        private void ProcessTable(DataTable dt)
        {
            RDIFrameworkService service = new RDIFrameworkService();
            DataTable dtColumns = service.TableColumnsService.GetDTByTable(UserInfo, this.TableName);
            if (service.TableColumnsService is ICommunicationObject)
            {
                ((ICommunicationObject)service.TableColumnsService).Close();
            }
            // 1:列的显示顺序
            // 2:列是否显示？
            // 3:列的中文名字？
            foreach (DataRow dataRow in dtColumns.Rows)
            {
                if (!dataRow[CiTableColumnsTable.FieldEnabled].ToString().Equals("1")) continue;
                var dgvtbc = new DataGridViewTextBoxColumn
                {
                    Name = dataRow[CiTableColumnsTable.FieldColumnCode].ToString(),
                    HeaderText = dataRow[CiTableColumnsTable.FieldColumnName].ToString(),
                    DataPropertyName = dataRow[CiTableColumnsTable.FieldColumnCode].ToString()
                };
                this.dgvTable.Columns.Add(dgvtbc);
            }
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnExport.Enabled = false || this.dgvTable.RowCount > 0;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.txtTargetTable.Text = this.TableRealName;

            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvTable);

            string commandText = string.Empty;
            //暂时只针对RDIFramework所在数据库做验证。
            commandText = RDIFramework.Utilities.SystemInfo.RDIFrameworkDbType == Utilities.CurrentDbType.Oracle
                        ? " SELECT * FROM " + this.TableName + " WHERE  ROWNUM <= 500 AND " + this.TableConstraint
                        : " SELECT top 500 * FROM " + this.TableName + " WHERE " + this.TableConstraint;

            DataTable dt = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, commandText);
            dt.TableName = this.TableName;
            // 表格显示序号的处理部分
            this.ProcessTable(dt);
            this.dgvTable.AutoGenerateColumns = false;
            this.dgvTable.DataSource = dt;
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".xls";
            this.ExportToExcel(this.dgvTable, @"\Modules\Export\", exportFileName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
