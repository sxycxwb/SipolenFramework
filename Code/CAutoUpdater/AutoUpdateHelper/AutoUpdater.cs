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
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CAutoUpdater
{
    #region The delegate
    public delegate void ShowHandler();
    #endregion

    public class AutoUpdater : IAutoUpdater
    {
        #region The private fields
        private Config config = null;
        private bool bNeedRestart = false;
        private bool bDownload = false;
        List<DownloadFileInfo> downloadFileListTemp = null;
        #endregion

        #region The public event
        public event ShowHandler OnShow;
        #endregion

        #region The constructor of AutoUpdater
        public AutoUpdater()
        {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
        }

        #endregion

        #region The public method
        /// <summary>
        /// Automatic updates ( through version of the file and file size judging whether to update )
        /// </summary>
        public void Update()
        {
            if (!config.Enabled)
            {
                return;
            }

            ClearOld();//删除旧文件

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(config.ServerUrl);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //先检查本地文件特征
            foreach (LocalFile file in config.UpdateFileList)
            {
                if (!CheckUpdateFiles(file.Path, file.Md5))
                {
                    downloadList.RemoveAll(x => { return x.FileName == file.Path; });
                    downloadList.Add(new DownloadFileInfo(file.Updateurl, file.Path, file.LastVer, file.Size, file.Md5));
                    bDownload = true;
                }
            }
            config.UpdateFileList.Clear(); //清除本地配置  

            #region 处理对于本地没有，远程有的更新文件
            //处理对于本地没有，远程有的更新文件。
            foreach (RemoteFile file in listRemotFile.Values)
            {
               
                //更新新的配置到本地配置文件。
                config.AddAndEdit(new LocalFile(file.Path, file.LastVer, file.Size, file.Md5, file.Url));

                if (!CheckUpdateFiles(file.Path, file.Md5))
                {
                    downloadList.RemoveAll(x => { return x.FileName == file.Path; });
                    downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size, file.Md5));
                    bDownload = true;
                }
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME)); //暂时保存
                if (file.NeedRestart)
                    bNeedRestart = true;
            }
            #endregion

            #region xxx

            downloadFileListTemp = downloadList;

            if (bDownload)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);

                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    StartDownload(downloadList);
                }
            }
            #endregion
        }
    
        private bool CheckUpdateFiles(string filename, string md5)
        {
            //先检查本地文件实际的MD5与配置中的md5是滞一样
            return EncryptHelper.GetFileMD5(filename) == md5 ? true : false;
        }

        public void RollBack()
        {
            foreach (DownloadFileInfo file in downloadFileListTemp)
            {
                string tempUrlPath = CommonUnitity.GetFolderUrl(file);
                string oldPath = string.Empty;
                try
                {
                    if (!string.IsNullOrEmpty(tempUrlPath))
                    {
                        oldPath = Path.Combine(CommonUnitity.systemBinUrl + tempUrlPath.Substring(1), file.FileName);
                    }
                    else
                    {
                        oldPath = Path.Combine(CommonUnitity.systemBinUrl, file.FileName);
                    }

                    if (oldPath.EndsWith("_"))
                        oldPath = oldPath.Substring(0, oldPath.Length - 1);

                    MoveFolderToOld(oldPath + "0", oldPath);
                }
                catch 
                {
                    //log the error message,you can use the application's log code
                }
            }
        }

        #endregion

        #region The private method
        string newfilepath = string.Empty;
        private void MoveFolderToOld(string oldPath, string newPath)
        {
            if (File.Exists(oldPath) && File.Exists(newPath))
            {
                System.IO.File.Copy(oldPath, newPath, true);
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //
                if (DialogResult.Cancel == dp.ShowDialog())
                {
                    return;
                }
                //更新完成
                
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
                
                if (bNeedRestart)
                {
                    //需要重启更新
                    Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.TEMPFOLDERNAME), true); 
                    Msg.DisplayMsg(ConstFile.APPLYTHEUPDATE, ConstFile.MESSAGETITLE, 5000);
                    CommonUnitity.RestartApplication();
                }
            }
        }

        //删除所有旧文件
        private void ClearOld()
        {
            string[] dirs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.old", SearchOption.AllDirectories);
            foreach (var x in dirs)
            {
                try
                {
                    File.Delete(x);
                }
                catch
                {
                }
            }
        }   
     

        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                list.Add(node.Attributes["path"].Value, new RemoteFile(node));
            }

            return list;
        }
        #endregion
    }
}