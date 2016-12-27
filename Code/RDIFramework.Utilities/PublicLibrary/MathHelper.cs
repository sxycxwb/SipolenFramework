//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Text.RegularExpressions;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 数字通用操作类
    /// 
    /// 修改纪录
    ///     2008-07-01 XuWangBin 数字通用操作类
    ///     
    /// <author>
    ///     <name>XuWangBin</name>
    ///     <QQ>80368704</QQ>
    ///     <Email>80368704@qq.com</Email>
    /// </author>
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// 检测是否浮点型数据
        /// </summary>
        /// <param name="s">待检查数据</param>
        /// <returns>True:是浮点型，False:不是浮点型</returns>
        public static bool IsDecimal(string s)
        {
            try
            {
                decimal d = decimal.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否整数型数据
        /// </summary>
        /// <param name="input">待检查数据</param>
        /// <returns></returns>
        public static bool IsInteger(string input)
        {
            return input != null && IsInteger(input, true);
        }

        /// <summary>
        /// 将输入的字符串转换成整数型数据
        /// </summary>
        /// <param name="strValue">待转换数据</param>
        /// <returns>成功，返回整数型数据；失败，返回null</returns>
        public static int? ToInteger(string strValue)
        {
            if (string.IsNullOrEmpty(strValue.Trim()))
            {
                return null;
            }

            try
            {
                return int.Parse(strValue.Trim());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static int? StringCastToInteger(object objValue)
        {
            if (objValue == null)
            {
                return null;
            }


            if (string.IsNullOrEmpty(objValue.ToString().Trim()))
            {
                return null;
            }
            try
            {
                return int.Parse(objValue.ToString().Trim());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将输入的字符串转换成浮点型数据
        /// </summary>
        /// <param name="strValue">待转换数据</param>
        /// <returns>成功，返回浮点型数据；失败，返回null</returns>
        public static decimal? ToDecimal(string strValue)
        {
            if (string.IsNullOrEmpty(strValue.Trim()))
            {
                return null;
            }
            try
            {
                return decimal.Parse(strValue.Trim());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 是否全是正整数
        /// </summary>
        /// <param name="input"></param>
        /// <param name="plus"></param>
        /// <returns></returns>
        public static bool IsInteger(string input, bool plus)
        {
            if (input == null)
            {
                return false;
            }
            string pattern = "^-?[0-9]+$";
            if (plus)
                pattern = "^[0-9]+$";
            return Regex.Match(input, pattern, RegexOptions.Compiled).Success;
        }
    }
}
