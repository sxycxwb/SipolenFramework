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
using System.Xml;

namespace CAutoUpdater
{
    public class RemoteFile
    {
        #region The private fields
        private string path = "";
        private string url = "";
        private string lastver = "";
        private string md5 = "";
        private int size = 0;
        private bool needRestart = false;
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
        /// File Name
        /// </summary>
        public string Path { get { return path; } }

        /// <summary>
        /// URL Address
        /// </summary>
        public string Url { get { return url; } }

        /// <summary>
        /// The latest version
        /// </summary>
        public string LastVer { get { return lastver; } }

        /// <summary>
        /// File size
        /// </summary>
        public int Size { get { return size; } }

        /// <summary>
        /// Whether needs to restart the software
        /// </summary>
        public bool NeedRestart { get { return needRestart; } }
        #endregion

        #region The constructor of AutoUpdater
        public RemoteFile(XmlNode node)
        {
            this.path = node.Attributes["path"].Value;
            this.url = node.Attributes["url"].Value;
            this.md5 = node.Attributes["md5"].Value;
            this.lastver = node.Attributes["lastver"].Value;
            this.size = Convert.ToInt32(node.Attributes["size"].Value);
            this.needRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
        }
        #endregion
    }
}
