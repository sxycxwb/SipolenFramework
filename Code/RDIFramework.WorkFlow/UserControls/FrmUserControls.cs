using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.Utilities;

    public partial class FrmUserControls : BaseForm_Single
    {
        public string NowNodeId = "";
        public string UserId = "";
        public string UserName = "";

        public FrmUserControls(string userId, string userName, string iKey)
        {
            InitializeComponent();
            UserId = userId;
            UserName = userName;
            NowNodeId = iKey;
            InitializeUIData();
        }

        #region 初始化界面数据
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {
            if (NowNodeId.Trim().Length == 0 || NowNodeId == null)
                throw new Exception("InitializeUIData方法错误，NowNodeId 不能为空！");
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetChildUserControl(this.UserInfo, NowNodeId);
            txtFullName.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldFullName]) ?? "";
            txtPath.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldPath]) ?? "";
            txtControlId.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldControlId]) ?? "";
            txtFormName.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldFormName]) ?? "";
            txtAssemblyName.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldAssemblyName]) ?? "";
            txtDes.Text = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldDescription]) ?? "";
            string formType = BusinessLogic.ConvertToString(dt.Rows[0][UserControlsTable.FieldType]) ?? "";
            if (!string.IsNullOrEmpty(formType))
            {
                switch (formType)
                {
                    case "1":
                        rbType1.Checked = true;
                        break;
                    case "2":
                        rbType2.Checked = true;
                        break;
                    case "3":
                        rbType3.Checked = true;
                        break;
                    default:
                         rbType1.Checked = true;
                        break;
                }
            }
            this.Text = txtFullName.Text + " 属性";
            //列出隶属的主表单
            var mdt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainCtrlsOfChild(this.UserInfo, NowNodeId);
            lvMainUserControl.Columns.Add("主表单", 200, HorizontalAlignment.Left);
            lvMainUserControl.Columns.Add("主表单id", 0, HorizontalAlignment.Left);
            lvMainUserControl.Columns.Add("描述", 200, HorizontalAlignment.Left);
            foreach (DataRow dr in mdt.Rows)
            {
                var lvi1 = new ListViewItem(BusinessLogic.ConvertToString(dr[MainUserControlTable.FieldFullName]) ?? "", 0);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr["MAINUSERCONTROLID"]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[MainUserControlTable.FieldDescription]) ?? "");
                lvMainUserControl.Items.Add(lvi1);
            }
        }

        private void SaveUIData()
        {
            var ucType = "1";
            if (rbType1.Checked)
            {
                ucType = "1";
            }

            if (rbType2.Checked)
            {
                ucType = "2";
            }

            if (rbType3.Checked)
            {
                ucType = "3";
            }

            var entity = new UserControlsEntity
            {
                Id = NowNodeId,
                FullName = txtFullName.Text,
                Path = txtPath.Text,
                Description = txtDes.Text,
                ControlId = txtControlId.Text,
                FormName = txtFormName.Text,
                AssemblyName = txtAssemblyName.Text,
                Type = ucType
            };
            RDIFrameworkService.Instance.WorkFlowUserControlService.UpdateUserControl(this.UserInfo, entity);
        }
        #endregion

        private bool CheckData()
        {
            if (txtFullName.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg("子表单名不能为空!");
                txtFullName.Focus();
                return false;
            }

            if (rbType1.Checked)
            {
                if (string.IsNullOrEmpty(txtFormName.Text) || string.IsNullOrEmpty(txtAssemblyName.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("表单名称或所在程序集不能为空!");
                    txtFormName.Focus();
                    return false;
                }
            }

            if (rbType2.Checked)
            {
                if (string.IsNullOrEmpty(txtControlId.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("控件ID不能为空!");
                    txtControlId.Focus();
                    return false;
                }
            }

            if (rbType3.Checked)
            {
                if (string.IsNullOrEmpty(txtFormName.Text) || string.IsNullOrEmpty(txtAssemblyName.Text) || string.IsNullOrEmpty(txtControlId.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("控件ID、表单名称或所在程序集不能为空!");
                    txtControlId.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var fdb = new OpenFileDialog
            {
                Filter = "txt files (*.ascx)|*.ascx",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = false
            };
            var fileName = "";
            var userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//用户控件路径
            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                var index = fileName.ToUpper().IndexOf(userControlPath.ToUpper(), System.StringComparison.Ordinal);
                txtPath.Text = fileName.Substring(index, fileName.Length - index);
                var fi = new System.IO.FileInfo(fileName);
                txtControlId.Text = "uc" + fi.Name;//得到文件名(不包括路径) 
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (CheckData())
                {
                    SaveUIData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg("错误代码：" + ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
