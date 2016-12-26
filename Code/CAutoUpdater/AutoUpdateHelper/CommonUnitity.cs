/*****************************************************************
 * Copyright (C) EricHu Corporation. All rights reserved.
 * 
 * Author:   EricHu 
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
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace CAutoUpdater
{
    class CommonUnitity
    {
        public static string systemBinUrl = AppDomain.CurrentDomain.BaseDirectory;

        public static void RestartApplication()
        {
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        public static string GetFolderUrl(DownloadFileInfo file)
        {
            string folderPathUrl = string.Empty;
            int folderPathPoint = file.DownloadUrl.IndexOf("/", 15) + 1;
            string filepathstring = file.DownloadUrl.Substring(folderPathPoint);
            int folderPathPoint1 = filepathstring.IndexOf("/");
            string filepathstring1 = filepathstring.Substring(folderPathPoint1 + 1);
          //  folderPathUrl = file.FileName;
             
            if (filepathstring1.IndexOf("/") != -1)
            {
                string[] exeGroup = filepathstring1.Split('/');
                for (int i = 0; i < exeGroup.Length - 1; i++)
                {
                    folderPathUrl += "\\" + exeGroup[i];
                }
                if (!Directory.Exists(systemBinUrl + ConstFile.TEMPFOLDERNAME + folderPathUrl))
                {
                    Directory.CreateDirectory(systemBinUrl + ConstFile.TEMPFOLDERNAME + folderPathUrl);
                }              
            }          
            return folderPathUrl;
        }
    }
}
