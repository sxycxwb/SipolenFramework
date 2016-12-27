//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    ///	DbCommonManager
    /// 通用基类部分
    /// 
    /// 
    /// 修改纪录
    ///     
    ///     2014-05-18 版本: 2.8 XuWangBin 重新本代码。
    ///		2012.02.04 版本：1.0 XuWangBin 进行提炼，把代码进行分组。
    ///
    /// 版本：2.8
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public partial class DbCommonManager
    {
        //
        // 设置属性
        //
        public virtual int SetProperty(string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, targetField, targetValue);
        }

        public virtual int SetProperty(object id, string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, id, targetField, targetValue);
        }

        public virtual int SetProperty(object id, string[] targetFields, Object[] targetValues)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, id, targetFields, targetValues);
        }

        public virtual int SetProperty(string name, object value, string[] targetFields, Object[] targetValues)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, name, value, targetFields, targetValues);
        }

        public virtual int SetProperty(string name, string[] values, string[] targetFields, Object[] targetValues)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, name, values, targetFields, targetValues);
        }

        public virtual int SetProperty(object[] ids, string[] targetFields, Object[] targetValues)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids, targetFields, targetValues);
        }

        public virtual int SetProperty(string whereName, object whereValue, string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereName, whereValue, targetField, targetValue);
        }

        public virtual int SetProperty(string whereName1, object whereValue1, string whereName2, object whereValue2, string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereName1, whereValue1, whereName2, whereValue2, targetField, targetValue);
        }

        public virtual int SetProperty(string name, Object[] values, string targetField, object targetValue)
        {
            var returnValue = 0;
            if (values == null)
            {
                returnValue += DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, name, string.Empty, targetField, targetValue);
            }
            else
            {
                returnValue += values.Sum(t => DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, name, t, targetField, targetValue));
            }
            return returnValue;
        }

        public virtual int SetProperty(object[] ids, string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, BusinessLogic.FieldId, ids, targetField, targetValue);
        }

        public virtual int SetProperty(string[] names, object[] values, string targetField, object targetValue)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, names, values, targetField, targetValue);
        }

        //---------------------------------
        public virtual int SetProperty(KeyValuePair<string, object> parameter)
        {
            var parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, null, parameters);
        }

        public virtual int SetProperty(object id, KeyValuePair<string, object> parameter)
        {
            return this.SetProperty(new KeyValuePair<string, object>(BusinessLogic.FieldId, id), parameter);
        }

        public virtual int SetProperty(object id, List<KeyValuePair<string, object>> parameters)
        {
            return this.SetProperty(new KeyValuePair<string, object>(BusinessLogic.FieldId, id), parameters);
        }

        public virtual int SetProperty(object[] ids, KeyValuePair<string, object> parameter)
        {
            return this.SetProperty(BusinessLogic.FieldId, ids, parameter);
        }

        public virtual int SetProperty(object[] ids, List<KeyValuePair<string, object>> parameters)
        {
            return this.SetProperty(BusinessLogic.FieldId, ids, parameters);
        }

        public virtual int SetProperty(string name, object[] values, KeyValuePair<string, object> parameter)
        {
            var returnValue = 0;
            if (values == null)
            {
                returnValue += this.SetProperty(new KeyValuePair<string, object>(name, string.Empty), parameter);
            }
            else
            {
                returnValue += values.Sum(t => this.SetProperty(new KeyValuePair<string, object>(name, t), parameter));
            }
            return returnValue;
        }

        public virtual int SetProperty(string name, object[] values, List<KeyValuePair<string, object>> parameters)
        {
            var returnValue = 0;
            if (values == null)
            {
                returnValue += this.SetProperty(new KeyValuePair<string, object>(name, string.Empty), parameters);
            }
            else
            {
                returnValue += values.Sum(t => this.SetProperty(new KeyValuePair<string, object>(name, t), parameters));
            }
            return returnValue;
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter1, KeyValuePair<string, object> whereParameter2, KeyValuePair<string, object> parameter)
        {
            var whereParameters = new List<KeyValuePair<string, object>>
            {
                whereParameter1,
                whereParameter2
            };
            var parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter, KeyValuePair<string, object> parameter)
        {
            var whereParameters = new List<KeyValuePair<string, object>> {whereParameter};
            var parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(List<KeyValuePair<string, object>> whereParameters, KeyValuePair<string, object> parameter)
        {
            var parameters = new List<KeyValuePair<string, object>> {parameter};
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(KeyValuePair<string, object> whereParameter, List<KeyValuePair<string, object>> parameters)
        {
            var whereParameters = new List<KeyValuePair<string, object>> {whereParameter};
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereParameters, parameters);
        }

        public virtual int SetProperty(List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters)
        {
            return DbCommonLibary.SetProperty(DBProvider, this.CurrentTableName, whereParameters, parameters);
        }


        #region public int BatchSetCode(string[] ids, string[] codes) 重置编号
        /// <summary>
        /// 重置编号
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="codes">编号数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetCode(string[] ids, string[] codes)
        {
            return ids.Select((t, i) => this.SetProperty(t, BusinessLogic.FieldCode, codes[i])).Sum();

            //V2.5版本代码
            //int returnValue = 0;
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    returnValue += this.SetProperty(ids[i], BusinessLogic.FieldCode, codes[i]);
            //}
            //return returnValue;
        }

        #endregion

        ///
        /// 重新生成排序码
        ///

        #region public int BatchSetSortCode(string[] ids) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetSortCode(string[] ids)
        {
            var returnValue = 0;
            //CiSequenceManager sequenceManager = new CiSequenceManager(dbProvider);
            //string[] sortCodes = sequenceManager.GetBatchSequence(this.CurrentTableName, ids.Length);
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    returnValue += this.SetProperty(ids[i], BusinessLogic.FieldSortCode, sortCodes[i]);
            //}
            return returnValue;
        }
        #endregion

        #region public virtual int ResetSortCode() 重新设置表的排序码
        /// <summary>
        /// 重新设置表的排序码
        /// </summary>
        /// <returns>影响行数</returns>
        public virtual int ResetSortCode()
        {
            var returnValue = 0;
            //DataTable dataTable = this.GetDT(BusinessLogic.FieldSortCode);
            //CiSequenceManager sequenceManager = new CiSequenceManager(dbProvider);
            //string[] sortCode = sequenceManager.GetBatchSequence(this.CurrentTableName, dataTable.Rows.Count);
            //int i = 0;
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    returnValue += this.SetProperty(dataRow[BusinessLogic.FieldId].ToString(), BusinessLogic.FieldSortCode, sortCode[i]);
            //    i++;
            //}
            return returnValue;
        }
        #endregion

        #region public virtual int ChangeEnabled(object id) 变更有效状态
        /// <summary>
        /// 变更有效状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public virtual int ChangeEnabled(object id)
        {
            var returnValue = 0;
            var sqlQuery = " UPDATE " + this.CurrentTableName
                            + " SET " + BusinessLogic.FieldEnabled + " = (CASE " + BusinessLogic.FieldEnabled + " WHEN 0 THEN 1 WHEN 1 THEN 0 END) "
                            + " WHERE (" + BusinessLogic.FieldId + " = " + DBProvider.GetParameter(BusinessLogic.FieldId) + ")";
            var names = new string[1];
            var values = new Object[1];
            names[0] = BusinessLogic.FieldId;
            values[0] = id;
            returnValue = DBProvider.ExecuteNonQuery(sqlQuery, DBProvider.MakeParameters(names, values));
            return returnValue;
        }
        #endregion
    }
}