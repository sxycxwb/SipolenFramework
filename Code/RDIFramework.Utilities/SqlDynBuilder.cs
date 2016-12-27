/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-10 17:12:56
 ******************************************************************************/
using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// 动生成插入与更新SQL语句（暂时只适用于SqlServer）
    /// </summary>
    public class SqlDynBuilder
    {
        private System.Data.DataView ct;
        private string _tableName;
        private string _ConnName;

        #region 构造函数
        public SqlDynBuilder(string tableName)
        {
            _tableName = tableName;
            _ConnName = "";

            ct = GetColumnsType();

            if (ct == null || ct.Table.Rows.Count == 0)
                throw new Exception("要操作的表不存在！");
        }

        public SqlDynBuilder(string tableName, string connname)
        {
            //
            _tableName = tableName;
            if (connname == null)
                _ConnName = "";
            else
                _ConnName = connname;

            ct = GetColumnsType();

            if (ct == null || ct.Table.Rows.Count == 0)
                throw new Exception("要操作的表不存在！");
        }
        #endregion

        /// <summary>
        /// 生成Insert语句
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="v"></param>
        /// <param name="type">0=空值以null替代;1=空值转换(字符型为'',数值型为0,日期型为null);2=空值跳过(这时值取决于数据库的默认值设置)</param>
        /// <returns></returns>
        public string BuildInsertSql(System.Collections.Specialized.NameValueCollection v, int type)
        {

            if (ct == null || ct.Table.Rows.Count == 0)
            {
                throw new Exception("要操作的表或字段不存在！");
            }
            //将V name全部改成小写
            System.Collections.Specialized.NameValueCollection lowerv = new System.Collections.Specialized.NameValueCollection();
            for (int x = 0; x < v.Count; x++)
            {
                string vn = v.GetKey(x).ToLower();
                string vv = "";
                if (v[x] != null)
                    vv = v[x].ToString();
                lowerv.Add(vn, vv);
            }
            v = lowerv;

            int colcount = 0;

            string columns = "", values = "";

            string vKeys = Key2String(v).ToLower();

            for (int i = 0; i < ct.Table.Rows.Count; i++)
            {
                string coln = ct.Table.Rows[i]["name"].ToString();

                if (v != null && vKeys.IndexOf("," + coln.ToLower() + ",") != -1)
                {
                    colcount++;

                    string colv = v[coln.ToLower()].ToString();
                    int collen = int.Parse(ct.Table.Rows[i]["length"].ToString())
                        , coltype = int.Parse(ct.Table.Rows[i]["xtype"].ToString());

                    //coltype
                    //0=数据
                    //1=字符型
                    //2=日期型
                    //-1=不支持的类型


                    if (coltype == -1)
                        throw new Exception("出现不支持的数据类型！");

                    if (colv == null || colv == "")
                    {
                        #region 空值
                        if (type == 0)
                        {
                            columns += (columns.Equals(string.Empty)) ? " [" + coln + "] " : ", [" + coln + "] ";
                            values += (values.Equals(string.Empty)) ? " null " : ", null ";
                        }
                        else if (type == 1)
                        {
                            columns += (columns.Equals(string.Empty)) ? " [" + coln + "] " : ", [" + coln + "] ";

                            if (coltype == 0)
                                values += (values.Equals(string.Empty)) ? " 0 " : ", 0 ";
                            else if (coltype == 1)
                                values += (values.Equals(string.Empty)) ? " '' " : ", '' ";
                            else if (coltype == 2)
                                values += (values.Equals(string.Empty)) ? " N'' " : ", N'' ";
                            else
                                values += (values.Equals(string.Empty)) ? " null " : ", null ";
                        }
                        else
                        {
                            continue;
                        }
                        #endregion

                    }
                    else
                    {
                        #region 代入字段值

                        //简单判断字符型的长度，可以自己加其它的判断
                        //                        if (coltype==1 && colv.Length>collen)
                        //                        {
                        //                            throw new Exception("要插入的字符串长度超过数据库设置！");
                        //                        }

                        //0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据
                        if (coltype == 0 || coltype == 4)
                        {
                            columns += (columns.Equals(string.Empty)) ? " [" + coln + "] " : ", [" + coln + "] ";
                            values += (values.Equals(string.Empty)) ? " " + colv + " " : ", " + colv + " ";
                        }
                        else if (coltype == 1 || coltype == 3)
                        {
                            colv = colv.Replace("'", "''");
                            columns += (columns.Equals(string.Empty)) ? " [" + coln + "] " : ", [" + coln + "] ";
                            values += (values.Equals(string.Empty)) ? " '" + colv + "' " : ", '" + colv + "' ";
                        }
                        else if (coltype == 2)
                        {
                            colv = colv.Replace("'", "''");
                            columns += (columns.Equals(string.Empty)) ? " [" + coln + "] " : ", [" + coln + "] ";
                            values += (values.Equals(string.Empty)) ? " N'" + colv + "' " : ", N'" + colv + "' ";
                        }
                        else
                        {
                            continue;
                        }

                        #endregion
                    }
                }
            }

            if (v != null && colcount != v.Count)
                throw new Exception("指定的字段列表中某些字段不存在！");

            if (!columns.Equals(string.Empty) && !values.Equals(string.Empty))
            {
                string sql = "Insert into {0} ({1}) values ({2})";
                return string.Format(sql, _tableName, columns, values);
            }
            else
                return string.Empty;

        }

        public string BuildInsertSql(System.Collections.Specialized.NameValueCollection v)
        {
            return BuildInsertSql(v, 0);
        }

        /// <summary>
        /// 生成update语句
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="v"></param>
        /// <param name="type">0=空值以null替代;1=空值转换(字符型为'',数值型为0,日期型为null);2=空值跳过</param>
        /// <returns></returns>
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v
            , System.Collections.Specialized.NameValueCollection identity, int type)
        {
            if (ct == null || ct.Table.Rows.Count == 0)
            {
                throw new Exception("要操作的表或字段不存在！");
            }

            //将V name全部改成小写
            System.Collections.Specialized.NameValueCollection lowerv = new System.Collections.Specialized.NameValueCollection();
            for (int x = 0; x < v.Count; x++)
            {
                string vn = v.GetKey(x).ToLower();
                string vv = "";
                if (v[x] != null)
                    vv = v[x].ToString();
                lowerv.Add(vn, vv);
            }
            v = lowerv;

            //将V name全部改成小写
            System.Collections.Specialized.NameValueCollection lowerid = new System.Collections.Specialized.NameValueCollection();
            for (int x = 0; x < identity.Count; x++)
            {
                string vn = identity.GetKey(x).ToLower();
                string vv = "";
                if (identity[x] != null)
                    vv = identity[x].ToString();
                lowerid.Add(vn, vv);
            }
            identity = lowerid;

            string setvalues = "", identitycolumns = "";
            int idcount = 0
                , colcount = 0;

            string vKeys = Key2String(v).ToLower()
                , idKeys = Key2String(identity).ToLower();

            #region 生成Set串
            for (int i = 0; i < ct.Table.Rows.Count; i++)
            {
                string coln = ct.Table.Rows[i]["name"].ToString();

                if (identity != null && idKeys.IndexOf("," + coln.ToLower() + ",") != -1)
                {
                    idcount++;

                    string colv = identity[coln.ToLower()].ToString();
                    int coltype = int.Parse(ct.Table.Rows[i]["xtype"].ToString());

                    if (colv == null)
                        throw new Exception("指定的条件没有给出匹配值！");

                    //0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据
                    if (coltype == 0 || coltype == 4)
                    {
                        identitycolumns += (identitycolumns.Equals(string.Empty)) ? " [" + coln + "]=" + colv + " " : "and [" + coln + "]=" + colv + " ";
                    }
                    else if (coltype == 1 || coltype == 3)
                    {
                        colv = colv.Replace("'", "''");
                        identitycolumns += (identitycolumns.Equals(string.Empty)) ? " [" + coln + "]='" + colv + "' " : "and [" + coln + "]='" + colv + "' ";
                    }
                    else if (coltype == 2)
                    {
                        colv = colv.Replace("'", "''");
                        identitycolumns += (identitycolumns.Equals(string.Empty)) ? " [" + coln + "]=N'" + colv + "' " : "and [" + coln + "]=N'" + colv + "' ";
                    }

                    //这里存在一个小缺陷，多个条件间只能是与操作

                }

                if (v != null && vKeys.IndexOf("," + coln.ToLower() + ",") != -1)
                {
                    colcount++;
                    string colv = v[coln.ToLower()].ToString();
                    int collen = int.Parse(ct.Table.Rows[i]["length"].ToString())
                        , coltype = int.Parse(ct.Table.Rows[i]["xtype"].ToString());

                    //coltype
                    //0=数据
                    //1=字符型
                    //2=日期型
                    //-1=不支持的类型


                    if (coltype == -1)
                        throw new Exception("出现不支持的数据类型！");

                    if (colv == null || colv == "")
                    {
                        #region 空值
                        //0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据
                        if (type == 0)
                        {
                            setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=null " : ", [" + coln + "]=null ";
                        }
                        else if (type == 1)
                        {
                            if (coltype == 0)
                                setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=0 " : ", [" + coln + "]=0 ";
                            else if (coltype == 1)
                                setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]='' " : ", [" + coln + "]='' ";
                            else if (coltype == 2)
                                setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=N'' " : ", [" + coln + "]=N'' ";
                            else
                                setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=null " : ", [" + coln + "]=null ";
                        }

                        #endregion

                    }
                    else
                    {
                        #region 代入字段值

                        //简单判断字符型的长度，可以加其它的判断
                        //                        if (coltype==1 && colv.Length>collen)
                        //                        {
                        //                            throw new Exception("要插入的字符串长度超过数据库设置！");
                        //                        }

                        //0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据
                        if (coltype == 0 || coltype == 4)
                        {
                            setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=" + colv + " " : ", [" + coln + "]=" + colv + " ";
                        }
                        else if (coltype == 1 || coltype == 3)
                        {
                            colv = colv.Replace("'", "''");
                            setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]='" + colv + "' " : ", [" + coln + "]='" + colv + "' ";
                        }
                        else if (coltype == 2)
                        {
                            colv = colv.Replace("'", "''");
                            setvalues += (setvalues.Equals(string.Empty)) ? " [" + coln + "]=N'" + colv + "' " : ", [" + coln + "]=N'" + colv + "' ";
                        }

                        #endregion
                    }
                }
            }
            #endregion

            if (identity != null && idcount != identity.Count)
                throw new Exception("指定的更新条件中某些字段不存在！");

            if (v != null && colcount != v.Count)
                throw new Exception("指定的字段列表中某些字段不存在！");


            if (!setvalues.Equals(string.Empty))
            {
                string sql = "";
                if (identity != null && identity.Count > 0)
                {
                    sql = "update {0} set {1} where {2}";
                    sql = string.Format(sql, _tableName, setvalues, identitycolumns);
                }
                else
                {
                    sql = "update {0} set {1}";
                    sql = string.Format(sql, _tableName, setvalues);
                }
                return sql;
            }
            else
                return string.Empty;
        }
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v, System.Collections.Specialized.NameValueCollection identity)
        {
            return BuildUpdateSql(v, identity, 0);
        }
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v, string idcolumn, string idvalue, int type)
        {
            System.Collections.Specialized.NameValueCollection identity = new System.Collections.Specialized.NameValueCollection();
            identity.Add(idcolumn, idvalue);
            return BuildUpdateSql(v, identity, type);
        }
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v, string idcolumn, string idvalue)
        {
            return BuildUpdateSql(v, idcolumn, idvalue, 0);
        }


        /// <summary>
        /// 生成没有Where条件的Update语句
        /// </summary>
        /// <param name="v"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v, int type)
        {
            return BuildUpdateSql(v, null, type);
        }

        /// <summary>
        /// 生成没有Where条件的Update语句
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string BuildUpdateSql(System.Collections.Specialized.NameValueCollection v)
        {
            return BuildUpdateSql(v, null, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private System.Data.DataView GetColumnsType()
        {
            

            //Fan.iData.DB idb;   //数据库连接类，改成自己的数据库连接
            //if (_ConnName == "")
            //    idb = new Fan.iData.DB();
            //else
            //    idb = new Fan.iData.DB(_ConnName);

            string sql = @"
                     select a.[name],a.[length]
                     ,case 
                     when a.xusertype in (127,104,106,62,56,60,108,59,52,122,48) then 0 
                     when a.xusertype in (175,35,167) then 1 
                     when a.xusertype in (239,99,231) then 2
                     when a.xusertype in (61,58) then 3 
                     when a.xusertype in (165,173,36) then 4
                     when a.xusertype in (34,98,241,189,256) then -1 else -1 end [xtype]
                     from syscolumns a 
                     where object_id('" + _tableName + @"')=a.[id] order by a.colid
                    ";
            //return idb.GetDataView(sql);
            
            return DbFactoryProvider.GetProvider(_ConnName).Fill(sql).DefaultView;

            #region 0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据;-1=不支持的类型
            //0=数值型;1=字符型;2=Unicode字符型;3=日期型;4=二进制数据;-1=不支持的类型
            //name    xtype
            //bigint    127
            //binary    173
            //bit    104
            //char    175
            //datetime    61
            //decimal    106
            //float    62
            //image    34
            //int    56
            //money    60
            //nchar    239
            //ntext    99
            //numeric    108
            //nvarchar    231
            //real    59
            //smalldatetime    58
            //smallint    52
            //smallmoney    122
            //sql_variant    98
            //sysname    231
            //text    35
            //timestamp    189
            //tinyint    48
            //uniqueidentifier    36
            //varbinary    165
            //varchar    167
            //xml    241
            #endregion

        }


        private string Key2String(System.Collections.Specialized.NameValueCollection k)
        {
            string keystring = ",";
            for (int i = 0; k != null && i < k.Count; i++)
            {
                keystring += k.GetKey(i) + ',';
            }
            return keystring;
        }

        private void Test()
        {
            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();
            nvc.Add("col1", "value1");
            nvc.Add("col2", "value2");
            SqlDynBuilder isql = new SqlDynBuilder("testTable");

            string InsertSql = isql.BuildInsertSql(nvc);
            string UpdateSql = isql.BuildUpdateSql(nvc, "idCol", "value");

        }
    }
}
