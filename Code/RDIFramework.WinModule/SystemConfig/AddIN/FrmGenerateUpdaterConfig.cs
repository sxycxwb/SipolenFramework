/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-1 14:24:37
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmGenerateUpdaterConfig : BaseForm
    {
        FolderBrowserDialog browserDialog = null;
        List<string> selectedFiles = new List<string>();

        /// <summary>
        /// 服务端配置文件
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return string.Concat(txtSaveTo.Text.Trim() + "\\",txtConfigFileName.Text.Trim());
            }
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtConfigFileName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("配置文件名称不能为空！");
                txtConfigFileName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtSaveTo.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("请选择待保存的文件路径！");
                txtSaveTo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtUpdateFiles.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("请选择待更新的文件！");
                txtUpdateFiles.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtURLAddress.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg("URL地址前缀不能这空！");
                txtURLAddress.Focus();
                return false;
            }

            return true;

        }

        /// <summary>
        /// 增加插配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="urlAddress">文件所在的URL地址</param>
        /// <param name="lastver">文件的最新版本</param>
        /// <param name="size">文件大小(以KB为单位)</param>
        /// <param name="needReset">是否需要重启应用程序</param>
        public void AddUpdaterConfig(string fileName, string urlAddress, string lastver,long size,bool needReset)
        {
            if (!FileHelper.Exists(ConfigFile))
            {
                XMLHelper.CreateXmlDocument(ConfigFile, "updateFiels", "1.0", "utf-8", null);
            }

            XMLHelper.Insert(ConfigFile,"/updateFiels","file","path",fileName);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "url", urlAddress);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "lastver", lastver);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "size", size.ToString());
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "needRestart", needReset.ToString()); 

        }

        /// <summary>
        /// 修改插配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="urlAddress">文件所在的URL地址</param>
        /// <param name="lastver">文件的最新版本</param>
        /// <param name="size">文件大小(以KB为单位)</param>
        /// <param name="needReset">是否需要重启应用程序</param>
        private void UpdateConfig(string fileName, string urlAddress, string lastver, long size, bool needReset)
        {
            if (!FileHelper.Exists(ConfigFile))
            {
                XMLHelper.CreateXmlDocument(ConfigFile, "updateFiels", "1.0", "utf-8", null);
            }
            else
            {
                //先删除再新增
                string xpath = "/updateFiels/file[@path='" + fileName + "']";
                XMLHelper.DeleteXmlNodeByXPath(ConfigFile, xpath);
            }

            this.AddUpdaterConfig(fileName, urlAddress, lastver, size, needReset);          
        }

        public FrmGenerateUpdaterConfig()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            txtURLAddress.Focus();
            txtURLAddress.SelectAll();
        }

        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            using (browserDialog = new FolderBrowserDialog())
            {
                if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSaveTo.Text = browserDialog.SelectedPath;
                }
            }
        }

        private void btnSigleUpdateFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = true;

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtUpdateFiles.Text = string.Empty;
                    selectedFiles.Clear();
                    foreach (string name in fileDialog.FileNames)
                    {
                        selectedFiles.Add(name);
                        txtUpdateFiles.Text += name + ";";
                    }                  
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                int updateCount = 0;

                for (int iTemp = 0; iTemp < selectedFiles.Count; iTemp++)
                {
                    string currentFile = selectedFiles[iTemp];
                    string fileName = System.IO.Path.GetFileName(currentFile);
                    string url = txtURLAddress.Text.Trim() + fileName;
                    if (!txtURLAddress.Text.Trim().EndsWith("/"))
                    {
                         url = txtURLAddress.Text.Trim() +　"/" + fileName;
                    }
                   

                    string lastVer = string.Empty;
                    try
                    {
                        Assembly assembly = Assembly.LoadFile(currentFile);
                        AssemblyName assemblyName = assembly.GetName();
                        lastVer = assemblyName.Version.ToString();
                    }
                    catch
                    {
                        lastVer = string.Empty;
                    }

                    long size = FileHelper.GetFileSize(currentFile);
                    bool needRestart = chkNeedReStart.Checked;

                    this.UpdateConfig(fileName, url, lastVer, size, needRestart);
                    FileHelper.FileCoppy(currentFile, txtSaveTo.Text.Trim() + "\\" + fileName);
                    updateCount++;
                }

                if (updateCount > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg("成功增加:" + updateCount.ToString() + "文件!");
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg("增加失败！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
