using System.Drawing;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        public static void SetColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = dataGridView.Columns.Count - 1; i > 0; i--)
            {
                if (dataGridView.Columns[i].DataPropertyName.Equals("Selected"))
                {
                    break;
                }
                if (!BusinessLogic.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns.RemoveAt(i);
                }
            }
        }

        public static void SetEditColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (BusinessLogic.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns[i].ReadOnly = false;
                    dataGridView.Columns[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                }
            }
        }

        public static void RemoveColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = dataGridView.Columns.Count - 1; i > 0; i--)
            {
                if (BusinessLogic.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns.RemoveAt(i);
                }
            }
        }
    }
}