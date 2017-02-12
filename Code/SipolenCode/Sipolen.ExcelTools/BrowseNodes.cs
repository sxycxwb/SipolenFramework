using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDIFramework.Utilities;
using RDIFramework.WinForm.Utilities;
using Sipolen.ExcelTools.Model;

namespace Sipolen.ExcelTools
{
    public partial class BrowseNodes : BaseForm
    {
        private Country selectedCountry;
        private CountryTemplate selectedCountryTemplate;

        public BrowseNodes(Country country, CountryTemplate countryTemplate)
        {
            InitializeComponent();
            selectedCountry = country;
            selectedCountryTemplate = countryTemplate;
        }

        /// <summary>
        /// 业务逻辑数据库连接字符串
        /// </summary>
        public string BusinessDbConnection = SystemInfo.BusinessDbConnection;

        CurrentDbType BusinessDbType = CurrentDbType.SqlServer;

        private void browse_nodes_TextChanged(object sender, EventArgs e)
        {
            BindNodeGridView();
        }

        /// <summary>
        /// GridView双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nodeGridView_DoubleClick(object sender, EventArgs e)
        {
            int index = nodeGridView.CurrentRow.Index;
            string[] arr = new string[nodeGridView.ColumnCount];
            for (int i = 0; i < nodeGridView.ColumnCount; i++)
            {
                arr[i] = nodeGridView.Rows[index].Cells[i].Value.ToString();
            }
            if (MessageBox.Show($"确认选择【{arr[1]}】", "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Main main = (Main)this.Owner;//把Form2的父窗口指针赋给lForm1
                main.BrowseNodeNum = arr[0];//使用父窗口指针赋值
                this.Close();
            }
        }

        /// <summary>
        /// 绑定节点GridView
        /// </summary>
        private void BindNodeGridView()
        {
            //选择国家与模板类型
            var country = selectedCountry.CountryName;
            var template = selectedCountryTemplate.TemplateName;

            string searchTxt = browse_nodes.Text.Trim();
            string searchSql = $"SELECT NODEID,NODENAME,NODEDESC FROM S_NODEDICT WHERE NODEDESC LIKE '%{searchTxt}%' AND COUNTRY ='{country}' AND CATEGORY = '{template}'";
            var dt = ExecSql(searchSql);
            if (dt.Rows.Count > 0)
            {
                this.nodeGridView.AutoGenerateColumns = false;
                nodeGridView.DataSource = dt;
            }
        }

        private DataTable ExecSql(string sql)
        {
            DataTable dt = new DataTable();
            using (IDbProvider dbProvider = DbFactoryProvider.GetProvider(BusinessDbType))
            {
                try
                {
                    dbProvider.Open(BusinessDbConnection);
                    dt = dbProvider.Fill(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbProvider.Close();
                }
            }
            return dt;
        }
    }
}
