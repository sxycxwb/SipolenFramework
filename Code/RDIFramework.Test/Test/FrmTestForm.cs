using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    public partial class FrmTestForm : Form
    {
        public FrmTestForm()
        {
            InitializeComponent();
        }

        /*
            RDIFramework.Controls.UcAutoTextBox.DBhelper.ConnectionStr = @"Data Source=YONGHU\SQLINSTANCE;Initial Catalog=RDIFrameworkV2.7;uid=sa;password=qaz";
            this.ucAutoTextBox1.NextControl = ucAutoTextBox2;
            this.ucAutoTextBox1.GetTagSql(3);
            this.ucAutoTextBox1.IsEmpty = true;
         */
        private void FrmTestForm_Load(object sender, EventArgs e)
        {
            RDIFramework.Controls.UcAutoTextBox.DBhelper.ConnectionStr = @"Data Source=YONGHU\SQLINSTANCE;Initial Catalog=RDIFrameworkV2.7;uid=sa;password=qaz";
            this.ucAutoTextBox1.NextControl = ucAutoTextBox2;
            this.ucAutoTextBox1.GetTagSql(3);
            this.ucAutoTextBox1.IsEmpty = true;
        }
    }
}
