using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;  
 
namespace CAutoUpdater
{
    /// <summary>
    ///@Author:jilongliang
    ///@Date:2012/7/30
    ///@Descripte:EncryptHelper加密帮助类.
    /// </summary>
    public class EncryptHelper
    {
        public static string GetFileMD5(string filePath)
        {
            StringBuilder sb = new StringBuilder(32);
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(fs);
                fs.Close();

                byte[] b = md5.Hash;
                md5.Clear();

                for (int i = 0; i < b.Length; i++)
                {
                    sb.Append(b[i].ToString("X2"));
                }
            }
            catch
            {
            }

            return sb.ToString();
        }

        /// <summary>
        ///方法一:
        ///此种加密之后的字符串是三十二位的(字母加数据)字符串 
        /// Example:password是admin 加密变成后21232f297a57a5a743894a0e4a801fc3
        /// </summary>
        /// <param name="beforeStr"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string beforeStr)
        {
            string afterString = "";
            try
            {
                MD5 md5 = MD5.Create();
                byte[]hashs = md5.ComputeHash(Encoding.UTF8.GetBytes(beforeStr));
  
                foreach (byte by in hashs)
                //这里是字母加上数据进行加密.//3y 可以,y3不可以或 x3j等应该是超过32位不可以
                    afterString += by.ToString("x2");
            }
            catch 
            {
            }
            return afterString;
        }

        /// <summary>
        /// 方法:二
        ///HashAlgorithm加密
        /// 这种加密是 字母加-加字符 
        /// Example:password是admin 加密变成后19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12
        ////其实这个-可以用Repace替换它,然后进一步加密.或者换成另外字符或￥$  % &等等呵呵
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static String HashEncrypt(string password)
        {
            Byte[]hashedBytes = null;
            try
            {
                Byte[]clearBytes = new UnicodeEncoding().GetBytes(password);
                hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            }
            catch 
            {
            }
            return BitConverter.ToString(hashedBytes);//MD5加密
        }
  
        /// <summary>
        /// 方法:三
        /// MD5  +  HashCode加密
        /// Example:password是admin 加密变成后 895b7da64943134be17b825ce118456c
        /// </summary>
        /// <returns></returns>
        public static String MD5HashCodeEncrypt(string encryptPwd)
        {
            return MD5Encrypt(HashEncrypt(encryptPwd)); //在HashEncrypt基础上再MD5
        }
  
        /// <summary>
        /// 方法:四
        /// HashCode+MD5 加密
        /// Example:password是admin 加密变成后EB-1D-6D-E2-FC-F1-CD-94-4D-75-78-E6-3D-7A-12-32
        /// </summary>
        /// <param name="EncryptPwd"></param>
        /// <returns></returns>
        public static String HashCodeMD5Encrypt(string encryptPwd)
        {
            return HashEncrypt(MD5Encrypt(encryptPwd)); //在MD5基础再HashCode
        }

        /// <summary>
        /// 方法:五
        /// </summary>
        /// <param name="EncryptPwd"></param>
        /// <returns></returns>

        public static String HashMD5Encrypt(string encryptPwd)
        {
            return HashCodeMD5Encrypt(HashCodeMD5Encrypt(encryptPwd)); //在HashCodeMD5Encrypt基础再HashCode
        }

        /// <summary>
        /// 方法:六
        /// 哈哈 是不是  有点晕呢？
        /// 大家伙可以继续写下去
        /// </summary>
        /// <param name="EncryptPwd"></param>
        /// <returns></returns>
        public static String MD5HashEncrypt(string encryptPwd)
        {
            return MD5HashCodeEncrypt(MD5HashCodeEncrypt(encryptPwd)); //在MD5基础再HashCode
        }
    }
}