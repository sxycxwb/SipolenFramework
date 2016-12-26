using System;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class ProjectProperty : Form
    {
        public ProjectProperty()
        {
            InitializeComponent();
        }

        private void ProjectProperty_Load(object sender, EventArgs e)
        {
            GetSetting();
        }

        #region private SettingHelper GetSetting() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private SettingHelper GetSetting()
        {
            var settingHelper = new SettingHelper();
            settingHelper.GetSetting();
            this.txtCompanyName.Text = settingHelper.Company;
            this.txtProjectName.Text = settingHelper.Project;
            this.txtCreateBy.Text = settingHelper.Author;
            this.txtOutPut.Text = settingHelper.Output;

            if (String.IsNullOrEmpty(this.txtCompanyName.Text))
            {
                this.txtCompanyName.Text = "柯锐特软件（http://www.rdiframework.net/）";
            }
            if (String.IsNullOrEmpty(this.txtCreateBy.Text))
            {
                this.txtCreateBy.Text = "EricHu";
            }
            return settingHelper;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var settingHelper = new SettingHelper
            {
                Author = txtCreateBy.Text.Trim(),
                Company = txtCompanyName.Text.Trim(),
                Project = txtProjectName.Text.Trim(),
                Output = txtOutPut.Text.Trim()
            };
            settingHelper.SaveSetting();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnSelectOutPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            this.txtOutPut.Text = folderBrowserDialog1.SelectedPath;
            var settingHelper = new SettingHelper
            {
                Author = txtCreateBy.Text.Trim(),
                Company = txtCompanyName.Text.Trim(),
                Project = txtProjectName.Text.Trim(),
                Output = txtOutPut.Text.Trim()
            };
            settingHelper.SaveSetting();
        }
    }
}
