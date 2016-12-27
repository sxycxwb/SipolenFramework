/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:27
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:08
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace RDIFramework.Controls
{
    public class ImageObject
    {
        /// <summary>
        /// 得到要绘置的图片对像
        /// </summary>
        /// <param name="resPath">图像在程序集中的地址</param>
        /// <returns></returns>
        public static Bitmap GetResBitmap(string resPath)
        {
            Stream stream = FindStream(resPath);

            if (stream == null)
            {
                return null;
            }
            return new Bitmap(stream);
        }

        /// <summary>
        /// 得到图程序集中的图片对像
        /// </summary>
        /// <param name="resPath">图像在程序集中的地址</param>
        /// <returns></returns>
        private static Stream FindStream(string resPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resNames = assembly.GetManifestResourceNames();
            foreach (string str in resNames)
            {
                if (str == resPath)
                {
                    return assembly.GetManifestResourceStream(str);
                }
            }
            return null;
        }
    }
}
