//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------


using System;
using System.Security.Cryptography;
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 加解密公共类
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2011.07.15</date>
    /// </author>
    /// </summary>
    public class SecretHelper
    {
        #region public static bool CheckRegister() 检查注册码是否正确
        /// <summary>
        /// 检查注册码是否正确
        /// </summary>
        /// <returns>是否进行了注册</returns>
        public static bool CheckRegister()
        {
            return !(SystemInfo.NeedRegister && DateTime.Now.Year >= 2018 && DateTime.Now.Month > 12);
        }
        #endregion

        #region 256位AES加解密
        /// <summary>
        /// 256位AES加密
        /// </summary>
        /// <param name="toEncrypt">待加密文本</param>
        /// <returns>加密后的文本</returns>
        public static string AESEncrypt(string toEncrypt)
        {
            if (string.IsNullOrEmpty(toEncrypt.Trim()))
            {
                return string.Empty;
            }

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");//12345678901234567890123456789012 注意，此处不能乱改动
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            var rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 256位AES解密
        /// </summary>
        /// <param name="toDecrypt">待解密文本</param>
        /// <returns>解密后的文本</returns>
        public static string AESDecrypt(string toDecrypt)
        {
            if (string.IsNullOrEmpty(toDecrypt.Trim()))
            {
                return string.Empty;
            }

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            var rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
    }
}