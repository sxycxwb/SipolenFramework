﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.Specialized;

namespace RDIFramework.BizLogic
{

    /// <summary>
    /// SQLBuilder
    /// SQL语句生成器（适合简单的添加、删除、更新等语句，可以写出编译时强类型检查的效果）
    /// 
    /// 修改记录
    ///    
    ///		2012.02.07 版本：1.0 XuWangBin   主键创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.07</date>
    /// </author> 
    /// </summary>
    public partial class SQLBuilder
    {
        #region public string SetWhere(KeyValuePair<string, object> parameter, string relation = " AND ") 设置条件
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="parameter">参数条件</param>
        /// <param name="relation">条件 AND OR</param>
        /// <returns>条件语句</returns>
        public void SetWhere(KeyValuePair<string, object> parameter, string relation = " AND ")
        {
            this.SetWhere(parameter.Key, parameter.Value, parameter.Key, relation);
        }
        #endregion

        #region 设置条件 public string SetWhere(List<KeyValuePair<string, object>> parameters, string relation = " AND ")
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="parameters">条件</param>
        /// <param name="relation">条件 AND OR</param>
        /// <returns>条件语句</returns>
        public string SetWhere(List<KeyValuePair<string, object>> parameters, string relation = " AND ")
        {
            foreach (var key in parameters)
            {
                this.SetWhere(key.Key, key.Value, key.Key, relation);
            }
            string returnValue = this.WhereSql;
            return returnValue;
        }
        #endregion

        #region public string SetWhere(NameValueCollection parameters, string relation = " AND ")
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <param name="parameters">条件</param>
        /// <param name="relation">条件 AND OR</param>
        /// <returns>条件语句</returns>
        public string SetWhere(NameValueCollection parameters, string relation = " AND ")
        {
            foreach (var key in parameters.AllKeys)
            {
                this.SetWhere(key, parameters[key], relation);
            }
            string returnValue = this.WhereSql;
            return returnValue;
        }
        #endregion
    }
}