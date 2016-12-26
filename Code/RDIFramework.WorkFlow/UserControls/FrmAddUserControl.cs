using System;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAddUserControl
    /// �ӱ�ά��
    /// 
    /// </summary>
    public partial class FrmAddUserControl : BaseForm_Single
    {
        public string UserId="";
        public string UserName="";

        public FrmAddUserControl()
        {
            InitializeComponent();
        }

        public FrmAddUserControl(string userId, string userName)
        {
            InitializeComponent();
            UserId = userId;
            UserName = userName;
            this.rbType1.Checked = true;
        }   

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckData()
        {
            if (txtFullName.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg("�ӱ�������Ϊ��!");
                txtFullName.Focus();
                return false;
            }

            if (rbType1.Checked)
            {
                if (string.IsNullOrEmpty(txtFormName.Text) || string.IsNullOrEmpty(txtAssemblyName.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("�����ƻ����ڳ��򼯲���Ϊ��!");
                    txtFormName.Focus();
                    return false;
                }
            }

            if (rbType2.Checked)
            {
                if (string.IsNullOrEmpty(txtControlId.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("�ؼ�ID����Ϊ��!");
                    txtControlId.Focus();
                    return false;
                }
            }

            if (rbType3.Checked)
            {
                if (string.IsNullOrEmpty(txtFormName.Text) || string.IsNullOrEmpty(txtAssemblyName.Text) || string.IsNullOrEmpty(txtControlId.Text))
                {
                    MessageBoxHelper.ShowWarningMsg("�ؼ�ID�������ƻ����ڳ��򼯲���Ϊ��!");
                    txtControlId.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
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

                var c = new UserControlNode
                {
                    NodeId = BusinessLogic.NewGuid(),
                    Text = txtFullName.Text,
                    UserCtrlPath = txtPath.Text,
                    Description = txtDescription.Text,
                    ControlId = txtControlId.Text,
                    FormName = txtFormName.Text,
                    AssemblyName = txtAssemblyName.Text,
                    Type = ucType
                };
                c.InsertUserControlNode();
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var fdb = new OpenFileDialog
            {
                Filter = "���ļ� (*.ascx)|*.ascx",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = false
            };

            var fileName = "";
            var userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//�û��ؼ�·��
            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                var index = fileName.ToUpper().IndexOf(userControlPath.ToUpper(), System.StringComparison.Ordinal);
                txtPath.Text = fileName.Substring(index, fileName.Length - index);
                var fi = new System.IO.FileInfo(fileName);
                txtControlId.Text = "uc"+fi.Name;//�õ��ļ���(������·��)
            }
        }
    }
}

