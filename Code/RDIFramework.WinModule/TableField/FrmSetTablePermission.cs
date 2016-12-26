using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSetTablePermission
    /// 设置需要做表（字段）权限控制的数据表
    /// 
    /// </summary>
    public partial class FrmSetTablePermission : BaseForm
    {
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTTableListLeft = new DataTable(CiTableColumnsTable.TableName);
        private DataTable DTTableListRight = new DataTable(CiItemDetailsTable.TableName);

        /// <summary>
        /// 左边目标数据表代码
        /// </summary>
        public string LeftTargetTableCode
        {
            get
            {
                string tableCode = string.Empty;
                if (this.lbTableListLeft.SelectedItem != null)
                {
                    tableCode = this.lbTableListLeft.SelectedValue.ToString();
                }
                return tableCode;
            }
        }

        /// <summary>
        /// 右边目标数据表代码
        /// </summary>
        public string RightTargetTableCode
        { 
            get
            {
                string tableCode = string.Empty;
                if (this.lbTableListRight.SelectedItem != null)
                {
                    tableCode = this.lbTableListRight.SelectedValue.ToString();
                }
                return tableCode;
            }
        }

        public override void SetControlState()
        {
            this.btnAdd.Enabled = false;
            this.btnRemove.Enabled = false;
            this.btnAddAll.Enabled = false;
            if (this.DTTableListLeft != null && this.DTTableListLeft.Rows.Count > 0)
            {
                this.btnAdd.Enabled = true;
                this.btnAddAll.Enabled = true;
            }
            if (this.DTTableListRight != null && this.DTTableListRight.Rows.Count > 0)
            {
                this.btnRemove.Enabled = true;
            }
        }

        public FrmSetTablePermission()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetTablePermissionScopeList();
            this.GetTableList();
        }
        #endregion

        private void BindData()
        {
            this.GetTablePermissionScopeList();
            this.GetTableList();
            this.SetControlState();
        }

        /// <summary>
        /// 得到右边数据表
        /// </summary>
        private void GetTablePermissionScopeList()
        {
            this.DTTableListRight = RDIFrameworkService.Instance.TableColumnsService.GetTablePermissionScope(this.UserInfo);
            this.lbTableListRight.ValueMember = CiItemDetailsTable.FieldItemValue;
            this.lbTableListRight.DisplayMember = CiItemDetailsTable.FieldItemName;
            this.lbTableListRight.DataSource = this.DTTableListRight.DefaultView;
        }

        /// <summary>
        /// 得到左边所有数据表
        /// </summary>
        private void GetTableList()
        {
            this.DTTableListLeft = RDIFrameworkService.Instance.TableColumnsService.GetTableNameAndCode(this.UserInfo);   
            
            //根据右表数据清除左表已有的数据列表（让其不要重复选择）。
            if (this.DTTableListRight != null && this.DTTableListRight.Rows.Count > 0)
            {
                for (int index = 0; index < this.DTTableListRight.Rows.Count; index++)
                {
                    var dataRows = this.DTTableListLeft.Select(CiTableColumnsTable.FieldTableCode + "='" + this.DTTableListRight.Rows[index][PiTablePermissionScopeTable.FieldItemCode].ToString().Trim() + "'");
                    if (dataRows.Length <= 0) continue;
                    foreach (DataRow dataRow in dataRows)
                    {
                        this.DTTableListLeft.Rows.Remove(dataRow);
                    }
                    this.DTTableListLeft.AcceptChanges();
                }
            }

            this.lbTableListLeft.ValueMember = CiTableColumnsTable.FieldTableCode;
            this.lbTableListLeft.DisplayMember = CiTableColumnsTable.FieldTableName;
            this.lbTableListLeft.DataSource = this.DTTableListLeft.DefaultView;
        }

        private string addTablePermissionScope(string itemCode,string itemName)
        {
            string returnValue = string.Empty;
            var entity = new PiTablePermissionScopeEntity
            {
                ItemCode = itemCode,
                ItemName = itemName,
                Enabled = 1,
                DeleteMark = 0
            };
            entity.ItemValue = entity.ItemCode;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            returnValue = RDIFrameworkService.Instance.TableColumnsService.AddTablePermissionScope(this.UserInfo, entity, out statusCode, out statusMessage);
            if (statusCode != StatusCode.OKAdd.ToString())
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);              
            }
            return returnValue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.lbTableListLeft.SelectedItem == null)
            {
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string itemName = lbTableListLeft.Text.Substring(lbTableListLeft.Text.IndexOf('［') + 1, lbTableListLeft.Text.Length - lbTableListLeft.Text.IndexOf('［') - 2);
                if (this.addTablePermissionScope(this.LeftTargetTableCode, itemName).Length > 0)
                {
                    this.BindData();  
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lbTableListRight.SelectedItem == null)
            {
                return;
            }
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                /*TODO
                 * 移除需要考虑的业务要求：
                 * 一、可做表权限控制的相应数据表被移除，如果其对应数据表已经做了相应的字段级，表级范围访问权限的控制，也应该做相应的移除处理才符合逻辑，
                 *     因此，此操作必须相当谨慎，考虑周全，以免影响相应的权限控制。
                 * 二、此处直接是物理删除可做表权限控制的相应数据表，是否考虑逻辑删除，以防止权限的混乱，以及垃圾数据的产生。
                */
               
                int returnValue = RDIFrameworkService.Instance.TableColumnsService.SetTablePermissionScopeDeleted(this.UserInfo, 
                                  new string[] { RDIFrameworkService.Instance.TableColumnsService.GetTablePermissionScopeEntity(this.UserInfo, PiTablePermissionScopeTable.FieldItemValue, this.RightTargetTableCode).Id.ToString()});
                if (returnValue > 0)
                {
                    this.BindData();
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }            
        }

        private void lbTableListLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void lbTableListRight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (lbTableListLeft.Items.Count <= 0)
            {
                return;
            }

            this.Changed = false;
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                foreach (DataRow dataRow in this.DTTableListLeft.Rows)
                {
                    string code = dataRow[CiTableColumnsTable.FieldTableCode].ToString();
                    string name = dataRow[CiTableColumnsTable.FieldTableName].ToString();
                    name = name.Substring(name.IndexOf('［') + 1, name.Length - name.IndexOf('［') - 2);
                    this.addTablePermissionScope(code, name);
                    this.Changed = true;
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                if (this.Changed)
                {
                    this.BindData();
                }
                this.Cursor = holdCursor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
