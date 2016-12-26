using System;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 数据库类型选择
    /// </summary>
    public partial class DbTypeSel : Form
    {
        public string dbtype = "SQL2000";

        public DbTypeSel()
        {
            InitializeComponent();

            //backgroundWorker1 = backgroundWorker;
            //backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            //backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {           
            if (this.radbtn_dbtype_SQL2000.Checked)
            {
                dbtype = "SQL2000";
            }            
            if (this.radbtn_dbtype_Oracle.Checked)
            {
                dbtype = "Oracle";
            }
            if (radbtn_dbtype_MySQL.Checked)
            {
                dbtype = "MySQL";
            }
            if (this.radbtn_dbtype_Access.Checked)
            {
                dbtype = "OleDb";
            }
            if (radbtn_SQLite.Checked)
            {
                dbtype = "SQLite";
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {         
            this.Close();
        }       
       
    }
}