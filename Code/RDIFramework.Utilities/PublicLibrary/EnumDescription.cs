//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// EnumDescription
    /// 枚举状态的说明。
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.1 EricHu 重新排版。
    ///		2011.10.13 版本：1.0 EricHu 创建。
    ///		
    /// 版本：1.1
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>    
    public class EnumDescription : Attribute
    {
        private string _text;

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public EnumDescription(string text)
        {
            _text = text;
        }
    }
}