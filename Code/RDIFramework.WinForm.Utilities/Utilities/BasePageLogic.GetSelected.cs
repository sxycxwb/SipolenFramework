using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    public partial class BasePageLogic
    {
        #region public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataTable.DefaultView, fieldId, fieldSelected);
        }
        #endregion

        #region public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataView">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataView, fieldId, fieldSelected, true);
        }
        #endregion

        #region public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetUnSelecteIds(DataTable dataTable, string fieldId, string fieldSelected)
        {
            return GetUnSelecteIds(dataTable.DefaultView, fieldId, fieldSelected);
        }
        #endregion

        #region public static string[] GetUnSelecteIds(DataView dataView, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataView">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetUnSelecteIds(DataView dataView, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataView, fieldId, fieldSelected, false);
        }
        #endregion

        #region public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected, bool selected) 获得已被选择的主键数组
        public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected, bool selected)
        {
            var ids = new string[0];
            var Ids = (from DataRowView dataRowView in dataView
                       where dataRowView.Row.RowState != DataRowState.Deleted
                       where dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(selected.ToString().ToUpper())
                       select dataRowView.Row[fieldId].ToString() into id
                       where id.Length > 0
                       select id).Aggregate(string.Empty, (current, id) => current + (id + ","));

            //V2.5版本：
            //foreach (DataRowView dataRowView in dataView)
            //{
            //    if (dataRowView.Row.RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(selected.ToString().ToUpper()))
            //    {
            //        string id = dataRowView.Row[fieldId].ToString();
            //        if (id.Length > 0)
            //        {
            //            Ids += id + ",";
            //        }
            //    }
            //}
            // 分离Id
            if (Ids.Length > 1)
            {
                Ids = Ids.TrimEnd(',');
                ids = Ids.Split(',');
            }
            return ids;
        }
        #endregion

        #region public static string[] GetSelecteIds(DataGridView dgView, string fieldId, string fieldSelected, bool selected) 获得已被选择的主键数组
        /// <summary>
        /// 获得(已/未)被选择的主键数组
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="selected">(已/未)被选择</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataGridView dgView, string fieldId, string fieldSelected, bool selected)
        {
            string[] ids = new string[0];
            string Ids = (from DataGridViewRow dgvRow in dgView.Rows
                          let dataRowView = dgvRow.DataBoundItem as DataRowView
                          where dataRowView == null || dataRowView.Row.RowState != DataRowState.Deleted
                          where ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false)) == selected
                          select dataRowView.Row[fieldId].ToString() into id
                          where id.Length > 0
                          select id).Aggregate(string.Empty, (current, id) => current + (id + ","));

            //V2.5版本
            //foreach (DataGridViewRow dgvRow in dgView.Rows)
            //{
            //    var dataRowView = dgvRow.DataBoundItem as DataRowView;
            //    if (dataRowView != null && dataRowView.Row.RowState == DataRowState.Deleted)
            //    {
            //        continue;
            //    }
            //    if (((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false)) == selected)
            //    {
            //        string id = dataRowView.Row[fieldId].ToString();
            //        if (id.Length > 0)
            //        {
            //            Ids += id + ",";
            //        }
            //    }
            //}
            // 分离Id
            Ids = Ids.TrimEnd(',');
            if (!string.IsNullOrEmpty(Ids.Trim()))
            {
                ids = Ids.Split(',');
            }
            return ids;
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataTable dataTable, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataTable dataTable, string fieldSelected)
        {
            return GetSelecteRow(dataTable.DefaultView, fieldSelected);
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataView dataView, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="dataView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataView dataView, string fieldSelected)
        {
            DataRow returnValue = null;
            foreach (var dataRowView in from DataRowView dataRowView in dataView
                                        where dataRowView.Row.RowState != DataRowState.Deleted
                                        where dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(true.ToString().ToUpper())
                                        select dataRowView)
            {
                returnValue = dataRowView.Row;
            }
            return returnValue;
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataGridView dgView, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataGridView dgView, string fieldSelected)
        {
            DataRow returnValue = null;
            foreach (var dataRow in from DataGridViewRow dgvRow in dgView.Rows
                                    let dataRowView = dgvRow.DataBoundItem as DataRowView
                                    where dataRowView != null
                                    let dataRow = dataRowView.Row
                                    where dataRow.RowState != DataRowState.Deleted
                                    where (System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false)
                                    select dataRow)
            {
                returnValue = dataRow;
            }
            return returnValue;
        }
        #endregion
    }
}