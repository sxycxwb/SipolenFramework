/*****************************************************************
* Copyright (C) XuWangBin Corporation. All rights reserved.
* 
* Author:   XuWangBin 
* Email:    80368704@qq.com
* Website:  http://www.cnblogs.com/huyong/       
* Create Date:  5/8/2010 
* Usage:
*
* RevisionHistory
* Date         Author               Description
* 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAutoUpdater
{
    public partial class DownloadConfirm : Form
    {
        #region The private fields
        List<DownloadFileInfo> downloadFileList = null;
        int ltime = 10;
        #endregion

        #region The constructor of DownloadConfirm
        public DownloadConfirm(List<DownloadFileInfo> downloadfileList)
        {
            InitializeComponent();

            downloadFileList = downloadfileList;
        }

        #endregion

        #region The private method
        private void OnLoad(object sender, EventArgs e)
        {
            ListViewItem[] lvItems = new ListViewItem[this.downloadFileList.Count];
            int lvItemIndex = 0;
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                // ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString() });
                lvItems[lvItemIndex++] = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString(),file.Md5 });
            }
            lvFileList.Items.AddRange(lvItems);
            this.Activate();
            this.Focus();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            ltime--;
            if (ltime == 0)
            {
                timer1.Enabled = false;
                btnOk.PerformClick();
              //  btnOk.DialogResult = DialogResult.OK;
            }
            else
            {
                label6.Text = string.Format("将在{0}秒后自动更新!", ltime);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }
    }
}