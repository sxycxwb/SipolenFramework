using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        #region public static void CheckTreeParentId(DataTable dataTable, string fieldId, string fieldParentId)
        /// <summary>
        /// 查找 ParentId 字段的值是否在 Id字段 里
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="fieldParentId">父节点字段</param>
        public static void CheckTreeParentId(DataTable dataTable, string fieldId, string fieldParentId)
        {
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                var dataRow = dataTable.Rows[i];
                // if (dataTable.Columns[fieldId].GetType() == typeof(int))
                if (dataRow[fieldParentId].ToString().Length > 0)
                {
                    if (dataTable.Select(fieldId + " = '" + dataRow[fieldParentId].ToString() + "'").Length == 0)
                    {
                        dataRow[fieldParentId] = DBNull.Value;
                    }
                }
            }
        }
        #endregion

        #region public static bool IsModfiedAnyOne(DataTable dataTable) 当前数据是否被修改过
        public static bool IsModfiedAnyOne(DataTable dataTable)
        {
            return IsModfiedAnyOne(dataTable, false);
        }
        #endregion

        #region public static bool IsModfiedAnyOne(DataTable dataTable, bool containSelectedColumn) 当前数据是否被修改过
        /// <summary>
        /// 当前数据是否被修改过
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="containSelectedColumn">含选择列</param>
        /// <returns>是否有修改</returns>
        public static bool IsModfiedAnyOne(DataTable dataTable, bool containSelectedColumn)
        {
            bool returnValue = false;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Modified)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        // 含选择列
                        if (containSelectedColumn || (dataTable.Columns[i].ColumnName.ToUpper() != "colSelected".ToUpper()))
                        {
                            if (dataRow[i].ToString() != dataRow[i, DataRowVersion.Original].ToString())
                            {
                                returnValue = true;
                                break;
                            }
                        }
                    }
                }
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    returnValue = true;
                    break;
                }
                if (dataRow.RowState == DataRowState.Added)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataTable dataTable) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataTable dataTable)
        {
            return CheckInputSelectOne(dataTable, "colSelected");
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataTable dataTable, string fieldSelected) 检查是否选择了一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataTable dataTable, string fieldSelected)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow[fieldSelected].ToString() == true.ToString())
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC024);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            dgView.EndEdit();
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC024);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataTable dataTable, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataTable dataTable, string fieldSelected)
        {
            return CheckInputSelectAnyOne(dataTable.DefaultView, fieldSelected);
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataView dataView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dataView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataView dataView, string fieldSelected)
        {
            bool returnValue = dataView.Cast<DataRowView>().Any(dataRowView => dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(true.ToString().ToUpper()));
            //V2.5版本
            //foreach (DataRowView dataRowView in dataView)
            //{
            //    if (!dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(true.ToString().ToUpper())) continue;
            //    returnValue = true;
            //    break;
            //}
            if (!returnValue)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected)
        {
            bool returnValue = false;
            dgView.EndEdit();
            if (string.IsNullOrEmpty(fieldSelected))
            {
                fieldSelected = BusinessLogic.SelectedColumn;
            }
            for (int rowCount = 0; rowCount < dgView.Rows.Count; rowCount++)
            {
                if ((System.Boolean)(dgView.Rows[rowCount].Cells[fieldSelected].Value ?? false))
                {
                    returnValue = true;
                    break;
                }
            }

            if (!returnValue)
            {
                MessageBoxHelper.ShowWarningMsg("无选择的记录！");
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected,bool showMessage) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected, bool showMessage)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                if (showMessage)
                {
                    MessageBox.Show(RDIFrameworkMessage.MSGC023, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                if (showMessage)
                {
                    MessageBox.Show(RDIFrameworkMessage.MSGC024, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected,bool showMessage, out bool otherError) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <param name="otherError">其他错误</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected, bool showMessage, out bool otherError)
        {
            otherError = false;
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                if (showMessage)
                {
                    MessageBox.Show(RDIFrameworkMessage.MSGC023, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            if (selectRowCount > 1)
            {

                MessageBox.Show(RDIFrameworkMessage.MSGC024, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);

                otherError = true;
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected, bool showMessage)
        {
            bool returnValue = dgView.Rows.Cast<DataGridViewRow>().Any(dgvRow => (System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false));

            if (!returnValue)
            {
                if (showMessage)
                {
                    MessageBox.Show(RDIFrameworkMessage.MSGC023, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputModifyAnyOne(DataTable dataTable) 检查是否有数据变动
        /// <summary>
        /// 检查是否有数据变动
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <returns>有变动</returns>
        public static bool CheckInputModifyAnyOne(DataTable dataTable)
        {
            bool returnValue = false;
            returnValue = IsModfiedAnyOne(dataTable);
            if (!returnValue)
            {
                MessageBox.Show(RDIFrameworkMessage.MSG0004, RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion
    }
}