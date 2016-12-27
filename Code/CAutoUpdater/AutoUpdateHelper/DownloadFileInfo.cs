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
using System.IO;

namespace CAutoUpdater
{
    public class DownloadFileInfo
    {
        #region The private fields
        string downloadUrl = string.Empty;
        string fileName = string.Empty;
        string md5 = string.Empty;
        string lastver = string.Empty;
        int size = 0;
        #endregion

        #region The public property
        public string Md5
        {
            get
            {
                return this.md5;
            }
            set
            {
                this.md5 = value;
            }
        }

        /// <summary>
        /// Url Address
        /// </summary>
        public string DownloadUrl
        {
            get
            {
                return downloadUrl;
            }
        }

        /// <summary>
        /// File full name
        /// </summary>
        public string FileFullName
        {
            get
            {
                return fileName;
            }
        }

        /// <summary>
        /// File Name
        /// </summary>
        public string FileName
        {
            get
            {
                return Path.GetFileName(FileFullName);
            }
        }

        /// <summary>
        /// The lasted version
        /// </summary>
        public string LastVer
        {
            get
            {
                return lastver;
            }
            set
            {
                lastver = value;
            }
        }

        /// <summary>
        /// File size
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }
        #endregion

        #region The constructor of DownloadFileInfo
        public DownloadFileInfo(string url, string name, string ver, int size, string md5)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
            this.md5 = md5;
        }
        #endregion
    }
}