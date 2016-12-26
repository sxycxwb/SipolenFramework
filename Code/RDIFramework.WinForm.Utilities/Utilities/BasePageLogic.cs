//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

	/// <summary>
    ///	BasePageLogic
	/// 通用页面控制类
	/// 
	/// 修改纪录
	///     2014-11-26 EricHu V2.8 增加对DataGridView右键自动增加“全选、取消全选与反选快捷菜单”。
    ///     2014-11-23 EricHu V2.8 新增重构方法：public static string GetDataGridViewEntityId(DataGridView targetDataGridView, string fieldId, string fieldSelected, bool selected = true)
	///     2014-06-27 EricHu V2.8 重新组织本类，对常用功能进行了分离。
    ///     2014-05-27 EricHu V2.8 修改“LoadDataGridViewColumnWidth”方法，对于列名称改后，加载DGV时不再出错。
    ///     2014-01-03 EricHu V2.7 重新重构，把所有能用Linq表示的全用Linq实现，精简代码，提供效率，代码质量得到了质的飞跃。
    ///     2012-06-12 EricHu 添加方法：设置进度条当前进度值(显示百分比)。
    ///     2012-05-31 EricHu 对方法：GetComboSelectedValue进行了重构。
    ///     2012-03-12 EricHu 再次对【容器包含控件属性控制】各方法集进行重构，清除多余重复代码，程序执行效率大大提升。
    ///     2011.02.03 EricHu 新增对【容器包含控件属性控制】各方法集。
	///	
	/// 版本：2.9
	///
	/// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.02.03</date>
	/// </author> 
	/// </summary>
    public partial class BasePageLogic
    {
        #region public static DataRow GetDataGridViewEntity(DataGridView targetDataGridView) 获得表格中的当前数据行
        /// <summary>
        /// 获得表格中的当前数据行
        /// </summary>
        /// <param name="targetDataGridView">目标表格控件</param>
        /// <returns>数据行</returns>
        public static DataRow GetDataGridViewEntity(DataGridView targetDataGridView)
        {
            DataRow dataRow = null;
            CurrencyManager currencyManager = null;
            if (targetDataGridView.DataMember == string.Empty)
            {
                if (targetDataGridView.DataSource != null)
                {
                    currencyManager = (CurrencyManager)targetDataGridView.BindingContext[targetDataGridView.DataSource, string.Empty];
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(targetDataGridView.DataMember))
                {
                    currencyManager = (CurrencyManager)targetDataGridView.BindingContext[targetDataGridView.DataMember];
                }
            }
            if (currencyManager != null && currencyManager.Count > 0)
            {
                dataRow = ((DataRowView)currencyManager.Current).Row;
            }
            return dataRow;
        }
        #endregion

        #region public static string ObjectsToList(object ids) 字段值数组转换为字符串列表
        /// <summary>
        /// 字段值数组转换为字符串列表
        /// </summary>
        /// <param name="ids">字段值</param>
        /// <returns>字段值字符串</returns>
        public static string ObjectsToList(Object[] ids)
        {
            string returnValue = string.Empty;
            string stringList = ids.Aggregate("'", (current, t) => current + (t + "', '"));
            //V2.5代码
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    stringList += ids[i] + "', '";
            //}
            returnValue = ids.Length == 0 ? " NULL " : stringList.Substring(0, stringList.Length - 3);
            return returnValue;
        }
        #endregion

        #region public static string GetDataGridViewEntityID(DataGridView targetDataGridView, string fieldId) 获得表格中的当前的ID主键
        /// <summary>
        /// 获得表格中的当前的ID主键
        /// </summary>
        /// <param name="targetDataGridView">目标表格控件</param>
        /// <param name="fieldId">主键字段</param>
        /// <returns>主键</returns>
        public static string GetDataGridViewEntityId(DataGridView targetDataGridView, string fieldId)
        {
            string returnValue = string.Empty;
            if (targetDataGridView.CurrentRow != null)
            {
                DataRow dataRow = (targetDataGridView.CurrentRow.DataBoundItem as DataRowView).Row;
                if (dataRow != null)
                {
                    returnValue = dataRow[fieldId].ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string GetDataGridViewEntityId(DataGridView targetDataGridView, string fieldId, string fieldSelected, bool selected = true) 获得表格中当前所选的ID主键键

        /// <summary>
	    /// 获得表格中当前所选的ID主键键
	    /// </summary>
	    /// <param name="targetDataGridView">目标表格控件</param>
	    /// <param name="fieldId">主键字段</param>
	    /// <param name="fieldSelected">选择列（CheckBox类型列）</param>
	    /// <param name="selected">是否选中</param>
	    /// <returns>主键</returns>
        public static string GetDataGridViewEntityId(DataGridView targetDataGridView, string fieldId, string fieldSelected, bool selected = true)
        {
            string returnValue = string.Empty;
            targetDataGridView.EndEdit();
            if (string.IsNullOrEmpty(fieldSelected))
            {
                fieldSelected = BusinessLogic.SelectedColumn;
            }
           
            foreach (DataGridViewRow dgvRow in targetDataGridView.Rows)
            {
                var dataRowView = dgvRow.DataBoundItem as DataRowView;
                if (dataRowView != null && dataRowView.Row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false)) == selected)
                {
                    string tmpValue = dataRowView.Row[fieldId].ToString();
                    if (tmpValue.Length > 0)
                    {
                        returnValue += tmpValue + ",";
                    }
                }
            }

            returnValue = returnValue.TrimEnd(',');

            if (!string.IsNullOrEmpty(returnValue.Trim()) && returnValue.Split(',').Length > 1)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC024);
                return string.Empty;
            }

            if(string.IsNullOrEmpty(returnValue.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
                return string.Empty;
            }

	        return returnValue;
        }
        #endregion

        #region public static string GetDataGridViewFieldValue(DataGridView targetDataGridView, string fieldName) 获得表格中的当前指定字段列的值
        /// <summary>
        /// 获得表格中的当前指定字段列的值
        /// </summary>
        /// <param name="targetDataGridView">目标表格控件</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns>字段值</returns>
        public static string GetDataGridViewFieldValue(DataGridView targetDataGridView, string fieldName)
        {
            string returnValue = string.Empty;
            if (targetDataGridView.CurrentRow != null)
            {
                DataRow dataRow = (targetDataGridView.CurrentRow.DataBoundItem as DataRowView).Row;
                if (dataRow != null)
                {
                    returnValue = dataRow[fieldName].ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void LoadDataGridViewColumnWidth(Form targetForm) 加载页面DataGridView控件上的列宽
        /// <summary>
        /// 加载页面DataGridView控件上的列宽
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        public static void LoadDataGridViewColumnWidth(Form targetForm)
        {
            //FrmDataGridViewSetting窗体不加载保存
            if (targetForm.Name == "FrmDataGridViewSetting")
            {
                return;
            }
            //配置数据权限
            DataSet dsDataGridViewColumns = new DataSet();
            // 窗体的名字
            string key = targetForm.Name;
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //检索出DataGridViews控件
            var fieldDataGridViews = from dgv in fieldInfo
                                     where dgv.FieldType.Name.Equals("DataGridView") || dgv.FieldType.Name.Equals("UcDataGridView")
                                     select dgv;

            foreach (var targetDataGridView in fieldDataGridViews.Select(item => (DataGridView)item.GetValue(targetForm)))
            {
                //加载事件
                LoadMouseClick(targetDataGridView, targetForm);

                var targetFileFullName = SystemInfo.StartupPath + "\\UserParameter\\" + targetForm.Name + "_" + targetDataGridView.Name + ".xml";
                //判断DataGridView配置文件是否存在,如果存在则设置列宽，如果不存在则新增文件。
                if (System.IO.File.Exists(targetFileFullName))
                {
                    dsDataGridViewColumns.Tables.Clear();
                    try
                    {
                        dsDataGridViewColumns.ReadXml(targetFileFullName);
                    }
                    catch (XmlException xmlException)
                    {
                        continue;
                    }
                    

                    if (dsDataGridViewColumns.Tables.Count <= 0)
                    {
                        continue;
                    }

                    //如果列没有更新
                    if (dsDataGridViewColumns.Tables[0].Rows.Count == targetDataGridView.ColumnCount)
                    {
                        for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                        {
                            try
                            {
                                //if (!dsDataGridViewColumns.Tables[0].Columns.Contains(targetDataGridView.Columns[j].Name))
                                //{
                                //    continue;
                                //}

                                targetDataGridView.Columns[j].HeaderText = targetDataGridView.Columns[j].HeaderText;
                                DataRow[] tmpRow = dsDataGridViewColumns.Tables[0].Select("ColumnName='" + targetDataGridView.Columns[j].Name + "'");
                                if (tmpRow != null && tmpRow.Length > 0)
                                {
                                    //设置冻结列
                                    bool ColumnFrozen = bool.Parse(tmpRow[0]["Frozen"].ToString());

                                    targetDataGridView.Columns[j].Frozen = ColumnFrozen;
                                    //设置显示
                                    bool ColumnVisible = bool.Parse(tmpRow[0]["Visible"].ToString());
                                    targetDataGridView.Columns[j].Visible = ColumnVisible;
                                    //设置位置
                                    int DisplayIndex = int.Parse(tmpRow[0]["DisplayIndex"].ToString());
                                    //冻结列有待优化
                                
                                    targetDataGridView.Columns[j].DisplayIndex = DisplayIndex;
                                    //设置列宽
                                    int ColumnsWidth = int.Parse(tmpRow[0]["Width"].ToString());
                                    targetDataGridView.Columns[j].Width = ColumnsWidth;
                                }
                                else
                                {
                                    SaveDataGridViewColumnWidth(targetForm, targetDataGridView);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        SaveDataGridViewColumnWidth(targetForm, targetDataGridView);
                    }
                }
                else
                {
                    if (!System.IO.Directory.Exists(SystemInfo.StartupPath + "\\UserParameter"))
                    {
                        System.IO.Directory.CreateDirectory(SystemInfo.StartupPath + "\\UserParameter");
                    }
                    SaveDataGridViewColumnWidth(targetForm, targetDataGridView);
                }
            }
        }

        private static int GetSelectColumnIndex(DataGridView targetDataGridView)
	    {
            int columnSelectedIndex = -1;
            if (targetDataGridView != null)
            {
                for (int colIndex = 0; colIndex < targetDataGridView.Columns.Count; colIndex++)
                {
                    string columnName = targetDataGridView.Columns[colIndex].Name.ToLower();
                    if (columnName == "colselected" || columnName == "selected")
                    {
                        columnSelectedIndex = colIndex;
                        break;
                    }
                }
            }
	        return columnSelectedIndex;
	    }

        //设置DataGridView右键菜单
        private static void LoadMouseClick(DataGridView targetDataGridView, Form targetForm)
        { 
            System.Windows.Forms.ContextMenuStrip contextMenuStrip = new ContextMenuStrip {Tag = targetForm};
            System.Windows.Forms.ToolStripMenuItem clickToolStripMenuItem = new ToolStripMenuItem();

            System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem = new ToolStripMenuItem("全选");//全选
            System.Windows.Forms.ToolStripMenuItem unSelectAllToolStripMenuItem = new ToolStripMenuItem("取消全选");//全选
            System.Windows.Forms.ToolStripMenuItem invertSelectToolStripMenuItem = new ToolStripMenuItem("反选"); //反选
            System.Windows.Forms.ToolStripSeparator sep1 = new ToolStripSeparator();
            int columnSelectedIndex = GetSelectColumnIndex(targetDataGridView);
            
            selectAllToolStripMenuItem.Visible = unSelectAllToolStripMenuItem.Visible = invertSelectToolStripMenuItem.Visible = sep1.Visible = targetDataGridView.MultiSelect && columnSelectedIndex >= 0;
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            invertSelectToolStripMenuItem.Click += invertSelectToolStripMenuItem_Click;
            unSelectAllToolStripMenuItem.Click += unSelectAllToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Tag = unSelectAllToolStripMenuItem.Tag = invertSelectToolStripMenuItem.Tag = targetDataGridView;

            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                clickToolStripMenuItem ,
                sep1,
                selectAllToolStripMenuItem,
                unSelectAllToolStripMenuItem,
                invertSelectToolStripMenuItem
            });

            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            clickToolStripMenuItem.Name = "clickToolStripMenuItem";
            clickToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            clickToolStripMenuItem.Text = RDIFrameworkMessage.clickToolStripMenuItem;
            clickToolStripMenuItem.Tag = targetDataGridView;
            clickToolStripMenuItem.Click += new System.EventHandler(clickToolStripMenuItem_Click);
            targetDataGridView.ContextMenuStrip = contextMenuStrip;
        }

        private static void clickToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FrmDataGridViewSetting frmDataGridViewSetting = new FrmDataGridViewSetting
            {
                TargetDataGridView = (sender as ToolStripMenuItem).Tag as DataGridView,
                TargetForm = (sender as ToolStripMenuItem).Owner.Tag as Form
            };
            frmDataGridViewSetting.ShowDialog();
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void selectAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DataGridView targetDataGridView = (sender as ToolStripMenuItem).Tag as DataGridView;
            targetDataGridView.EndEdit();
            int columnSelectedIndex = GetSelectColumnIndex(targetDataGridView);

            for (int i = 0; i < targetDataGridView.Rows.Count; i++)
            {
                targetDataGridView.Rows[i].Cells[columnSelectedIndex].Value = true;
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void unSelectAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DataGridView targetDataGridView = (sender as ToolStripMenuItem).Tag as DataGridView;
            targetDataGridView.EndEdit();
            int columnSelectedIndex = GetSelectColumnIndex(targetDataGridView);

            for (int i = 0; i < targetDataGridView.Rows.Count; i++)
            {
                targetDataGridView.Rows[i].Cells[columnSelectedIndex].Value = false;
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void invertSelectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DataGridView targetDataGridView = (sender as ToolStripMenuItem).Tag as DataGridView;
            targetDataGridView.EndEdit();
            int columnSelectedIndex = GetSelectColumnIndex(targetDataGridView);
            for (int i = 0; i < targetDataGridView.Rows.Count; i++)
            {
                targetDataGridView.Rows[i].Cells[columnSelectedIndex].Value = !BusinessLogic.ConvertToBoolean(targetDataGridView.Rows[i].Cells[columnSelectedIndex].Value);
            }
        }
        #endregion

        #region public static void SaveDataGridViewColumnWidth(Form targetForm) 保存页面DataGridView控件上的列宽
        /// <summary>
        /// 保存页面DataGridView控件上的列宽
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        public static void SaveDataGridViewColumnWidth(Form targetForm)
        {
            //配置数据权限
            DataSet dsDataGridViewColumns = new DataSet();
            // 窗体的名字
            string key = targetForm.Name;
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //检索出DataGridViews控件
            var fieldDataGridViews = from dgv in fieldInfo
                                     where dgv.FieldType.Name.Equals("DataGridView") || dgv.FieldType.Name.Equals("UcDataGridView")
                                     select dgv;
            foreach (var item in fieldDataGridViews)
            {
                SaveDataGridViewColumnWidth(targetForm, (DataGridView)item.GetValue(targetForm));
            }
        }

        private static void SaveDataGridViewColumnWidth(Form targetForm, DataGridView targetDataGridView)
        {
            //FrmDataGridViewSetting窗体不加载保存
            if (targetForm.Name == "FrmDataGridViewSetting")
            {
                return;
            }

            string targetFilePath = SystemInfo.StartupPath + "\\UserParameter\\";
            if (!System.IO.Directory.Exists(targetFilePath))
            {
                System.IO.Directory.CreateDirectory(targetFilePath);
            }

            string targetFileFullName = targetFilePath + targetForm.Name + "_" + targetDataGridView.Name + ".xml";
            DataSet dsDataGridViewColumns = new DataSet(targetDataGridView.Name);
            dsDataGridViewColumns.Tables.Add(targetDataGridView.Name);
            dsDataGridViewColumns.Tables[0].Columns.Add("ColumnName", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("HeaderText", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("Frozen", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("Visible", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("DisplayIndex", typeof(int));
            dsDataGridViewColumns.Tables[0].Columns.Add("Width", typeof(int));
            for (int j = 0; j < targetDataGridView.ColumnCount; j++)
            {
                DataGridViewColumn Column = targetDataGridView.Columns[j];
                dsDataGridViewColumns.Tables[0].Rows.Add(Column.Name, Column.HeaderText, Column.Frozen, Column.Visible, Column.DisplayIndex, Column.Width);
            }
            if (!System.IO.File.Exists(targetFileFullName))
            {
                System.IO.File.Create(targetFileFullName).Close();
            }

            dsDataGridViewColumns.WriteXml(targetFileFullName);
        }
        #endregion

        #region public static int GetRowIndex(DataTable dataTable, string fieldId, string id) 查找主键在视图中的位置
        /// <summary>
        /// 查找主键在视图中的位置
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">主键</param>
        /// <returns>位置</returns>
        public static int GetRowIndex(DataTable dataTable, string fieldId, string id)
        {
            int returnValue = 0;
            bool finded = false;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (dataRowView[fieldId].ToString() == id)
                {
                    finded = true;
                    break;
                }
                returnValue++;
            }
            if (!finded)
            {
                returnValue = 0;
            }
            return returnValue;
        }
        #endregion

        #region public static void DataTableAddColumn(DataTable dataTable, string fieldName) 往 DataTable 里面添加一列
        /// <summary>
        /// 往 DataTable 里面添加一列(布尔值列)
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名</param>
        public static void DataTableAddColumn(DataTable dataTable, string fieldName)
        {
            DataTableAddColumn(dataTable, fieldName, typeof(System.Boolean));
        }
        #endregion

        #region public static void DataTableAddColumn(DataTable dataTable, string fieldName) 往 DataTable 里面添加一列
        /// <summary>
        /// 往 DataTable 里面添加一列
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="dataType">数据类型</param>
        public static void DataTableAddColumn(DataTable dataTable, string fieldName, Type dataType)
        {
            if (dataTable != null && !dataTable.Columns.Contains(fieldName))
            {
                var DataColumn = new DataColumn(fieldName, dataType);
                DataColumn.DefaultValue = false;
                DataColumn.AllowDBNull = false;
                dataTable.Columns.Add(DataColumn);
            }
        }

	    #endregion

        #region public static Form GetForm(string assemblyName, string formName) 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="formName">窗体名称</param>
        /// <returns>加载窗体</returns>
        public static Form GetForm(string assemblyName, string formName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + formName, true, false);
            return (Form)Activator.CreateInstance(type);
        }
        #endregion

        #region public static Form ShowForm(string assemblyName, string formName) 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="formName">窗体名称</param>
        /// <returns>显示窗体</returns>
        public static Form ShowForm(string assemblyName, string formName)
        {
            Form form = GetForm(assemblyName, formName);
            form.Show();
            return form;
        }
        #endregion

        #region public static void SetProgressPos(ProgressBar proBar, Label lblPercent, int value) 设置进度条当前进度值(显示百分比)
        /// <summary>
        /// 设置进度条当前进度值(显示百分比)
        /// </summary>
        /// <param name="proBar">当前进度条</param>
        /// <param name="lblPercent">标签</param>
        /// <param name="value">当前值</param>
        public static void SetProgressPos(ProgressBar proBar, Label lblPercent, int value)
        {
            if (value <= proBar.Maximum && proBar.Maximum > 0) //如果值有效
            {
                proBar.Value = value;

                if (lblPercent != null)
                {
                    lblPercent.Text = (value * 100 / proBar.Maximum).ToString() + "%(当前进度)";//显示百分比
                }
            }
            Application.DoEvents();
        }
        #endregion

        #region public static string FromatStringWidth(Font font, string target, int width) 获取指定长度的字符串
        /// <summary>
        /// 获取指定长度的字符串
        /// </summary>
        /// <param name="font">显示的字体</param>
        /// <param name="target">目标字符串</param>
        /// <param name="width">需要截断的宽度</param>
        /// <returns>结果字符串</returns>
        public static string FromatStringWidth(Font font, string target, int width)
        {
            // 创建画布对象
            Image image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            string returnValue = target;
            SizeF sizeF = graphics.MeasureString(target, font);
            for (int i = target.Length - 1; i >= 0; i--)
            {
                if (sizeF.Width <= width)
                {
                    break;
                }
                returnValue = target.Substring(0, i);
                sizeF = graphics.MeasureString(returnValue, font);
            }
            // 释放资源
            graphics.Dispose();
            return returnValue;
        }
        #endregion
        
    }
}