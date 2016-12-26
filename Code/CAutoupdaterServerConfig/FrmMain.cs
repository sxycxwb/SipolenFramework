using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CAutoupdaterServerConfig
{
    public partial class FrmMain : Form
    {
        FolderBrowserDialog browserDialog = null;

        /// <summary>
        /// 服务端配置文件
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return string.Concat(txtServerPath.Text.Trim() + "\\", txtConfigFileName.Text.Trim());
            }
        }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSelectServerPath_Click(object sender, EventArgs e)
        {
            using (browserDialog = new FolderBrowserDialog())
            {
                if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtServerPath.Text = browserDialog.SelectedPath;
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = true;

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem[] lvItems = new ListViewItem[fileDialog.FileNames.Length];
                    int lvItemIndex = 0;
                    foreach (string file in fileDialog.FileNames)
                    { 
                        string fileName = FileHelper.GetName(file);
                        string fileSize = FileHelper.GetFileSize(file).ToString();
                        string filePath = file;

                        //文件版本
                        string lastVer = string.Empty;
                        try
                        {
                            Assembly assembly = Assembly.LoadFile(file);
                            AssemblyName assemblyName = assembly.GetName();
                            lastVer = assemblyName.Version.ToString();
                        }
                        catch
                        {
                            lastVer = string.Empty;
                        }

                        string md5 = EncryptHelper.GetFileMD5(filePath);
                       
                        //lvItems[lvItemIndex] = new ListViewItem(new string[] {(lvItemIndex++ + 1).ToString(),fileName,filePath,fileSize,lastVer});
                        lvItems[lvItemIndex++] = new ListViewItem(new string[] { string.Empty, fileName, filePath, fileSize, lastVer, md5 });
                    }

                    lvFileList.Items.AddRange(lvItems);
                }
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lvFileList.SelectedItems == null || lvFileList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择要移除的文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem lvItem in lvFileList.SelectedItems)
            {
                lvFileList.Items.Remove(lvItem);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                int updateCount = 0;
                if (lvFileList.Items.Count <= 0)
                {
                    MessageBox.Show("没有要升级的文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (ListViewItem lvItem in lvFileList.Items)
                { 
                    string filePath = lvItem.SubItems[2].Text;
                    string fileName = System.IO.Path.GetFileName(filePath);
                    string url = txtServerURL.Text.Trim() + fileName;
                    if (!txtServerURL.Text.Trim().EndsWith("/"))
                    {
                        url = txtServerURL.Text.Trim() + "/" + fileName;
                    }
                    string fileSize = lvItem.SubItems[3].Text;
                    string fileVer = string.IsNullOrEmpty(lvItem.SubItems[4].Text) ? string.Empty : lvItem.SubItems[4].Text;
                    string md5 = lvItem.SubItems[5].Text;
                    bool needRestart = lvItem.Checked;
                    this.UpdateConfig(fileName, url, fileVer, fileSize, md5, needRestart);
                    FileHelper.FileCoppy(filePath, txtServerPath.Text.Trim() + "\\" + fileName);
                    lvFileList.Items.Remove(lvItem);
                    updateCount++;
                }
           
                if (updateCount > 0)
                {
                    MessageBox.Show("成功增加:" + updateCount.ToString() + "文件!", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("增加失败!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtConfigFileName.Text.Trim()))
            {
                MessageBox.Show("配置文件名称不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfigFileName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtServerURL.Text.Trim()))
            {
                MessageBox.Show("升级服务端地址不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerURL.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtServerPath.Text.Trim()))
            {
                MessageBox.Show("服务端目录不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerPath.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 增加配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="urlAddress">文件所在的URL地址</param>
        /// <param name="lastver">文件的最新版本</param>
        /// <param name="size">文件大小(以KB为单位)</param>
        /// <param name="needReset">是否需要重启应用程序</param>
        public void AddUpdaterConfig(string fileName, string urlAddress, string lastver, string size, string md5, bool needReset)
        {
            if (!FileHelper.Exists(ConfigFile))
            {
                XMLHelper.CreateXmlDocument(ConfigFile, "updateFiels", "1.0", "utf-8", null);
            }

            XMLHelper.Insert(ConfigFile, "/updateFiels", "file", "path", fileName);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "url", urlAddress);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "lastver", lastver);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "size", size);
            XMLHelper.CreateOrUpdateXmlAttributeByXPath(ConfigFile, "/updateFiels/file[@path='" + fileName + "']", "md5", md5);
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
        private void UpdateConfig(string fileName, string urlAddress, string lastver, string size, string md5, bool needReset)
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

            this.AddUpdaterConfig(fileName, urlAddress, lastver, size, md5, needReset);
        }
    }
}