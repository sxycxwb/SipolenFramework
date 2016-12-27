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
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace CAutoUpdater
{
    public class Config
    {
        #region The private fields
        private bool enabled = true;
        private string serverUrl = string.Empty;
        private UpdateFileList updateFileList = new UpdateFileList();
        #endregion

        #region The public property
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }
        public string ServerUrl
        {
            get
            {
                return serverUrl;
            }
            set
            {
                serverUrl = value;
            }
        }
        public UpdateFileList UpdateFileList
        {
            get
            {
                return updateFileList;
            }
            set
            {
                updateFileList = value;
            }
        }
        #endregion

        #region The public method
        public static Config LoadConfig(string file)
        {
            Config config;
            if (File.Exists(file))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                StreamReader sr = new StreamReader(file);
                config = xs.Deserialize(sr) as Config;
                sr.Close();
            }
            else
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));    
                config = xs.Deserialize(new StringReader(Res.Autoupdater)) as Config;   
            }
           
            return config;
        }

        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }

        public void AddAndEdit(LocalFile fiel)
        {
            UpdateFileList.RemoveAll(x => { return x.Path == fiel.Path; });
            UpdateFileList.Add(fiel);
        }
        #endregion
    }
}