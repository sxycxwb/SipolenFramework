//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Reflection;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// EnumDescription
    /// 枚举状态的说明。
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0 EricHu 创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>    
    public static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumeration) 
        {
            Type type = enumeration.GetType();
            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());
            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (null != attrs && attrs.Length > 0)
                {
                    return ((EnumDescription)attrs[0]).Text;
                }
            }
            return enumeration.ToString(); 
        }
    }
}