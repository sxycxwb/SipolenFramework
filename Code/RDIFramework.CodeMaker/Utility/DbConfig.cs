using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    #region 数据源登录信息
    /// <summary>
    /// DbInfo 的摘要说明。
    /// </summary>
    public class DbSettings
    {
        public DbSettings()
        { }

        #region

        private string _dbtype;
        private string _server;
        private string _connectstr;
        private string _dbName;
        private bool _connectSimple = false;

        /// <summary>
        /// 数据源类型 
        /// </summary>
        [XmlElement]
        public string DbType
        {
            set { _dbtype = value; }
            get { return _dbtype; }
        }

        /// <summary>
        /// 服务器
        /// </summary>
        [XmlElement]
        public string Server
        {
            set { _server = value; }
            get { return _server; }
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        [XmlElement]
        public string ConnectStr
        {
            set { _connectstr = value; }
            get { return _connectstr; }
        }

        /// <summary>
        /// 数据库//增加一个是否单库字段。
        /// </summary>
        [XmlElement]
        public string DbName
        {
            set { _dbName = value; }
            get { return _dbName; }
        }

        /// <summary>
        /// 简洁连接模式，只列出表名，无字段信息。
        /// </summary>
        [XmlElement]
        public bool ConnectSimple
        {
            set { _connectSimple = value; }
            get { return _connectSimple; }
        }

        #endregion

    }
    #endregion 

    public class DbConfig
    {
        static string fileName = Application.StartupPath + "\\DbSetting.config";

        #region 得到 所有登陆过的数据源设置
        /// <summary>
        /// 得到所有登陆过的数据源设置
        /// </summary>
        /// <returns></returns>
        public static DbSettings[] GetSettings()
        {
            try
            {
                var ds = new DataSet();
                var DbList = new ArrayList();
                if (File.Exists(fileName))
                {
                    DbSettings dbobj;
                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dbobj = new DbSettings
                            {
                                DbType = dr["DbType"].ToString(),
                                Server = dr["Server"].ToString(),
                                ConnectStr = dr["ConnectStr"].ToString(),
                                DbName = dr["DbName"].ToString()
                            };
                            if (ds.Tables[0].Columns.Contains("ConnectSimple"))
                            {
                                if ((dr["ConnectSimple"] != null) && (dr["ConnectSimple"].ToString().Length > 0))
                                {
                                    dbobj.ConnectSimple = bool.Parse(dr["ConnectSimple"].ToString());
                                }
                            }
                            DbList.Add(dbobj);
                        }
                    }
                }
                var dbList = (DbSettings[])DbList.ToArray(typeof(DbSettings));
                return dbList;
            }
            catch
            {
                return null;
            }


        }
        /// <summary>
        /// 得到当前数据库服务器配置信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSettingDs()
        {
            try
            {
                var ds = new DataSet();
                if (File.Exists(fileName))
                {
                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema                    
                }
                return ds;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 根据 长服务器名 得到服务器配置
        /// <summary>
        /// 根据长服务器名得到服务器配置
        /// </summary>
        /// <param name="servername"></param>
        public static DbSettings GetSetting(string loneServername)
        {
            //127.0.0.1(dbtype)(dbName)            
            var dbtype = "SQL2000";
            var s = loneServername.IndexOf("(");
            var server = loneServername.Substring(0, s);
            var e = loneServername.IndexOf(")", s);
            dbtype = loneServername.Substring(s + 1, e - s - 1);
            var dbName = "";
            if (loneServername.Length > e + 1)
            {
                dbName = loneServername.Substring(e + 2).Replace(")", "");
            }
            return GetSetting(dbtype, server, dbName);
        }
        #endregion

        #region 得到 指定数据源 和 IP 的服务器配置信息
        /// <summary>
        /// 得到指定数据源的配置信息
        /// </summary>
        /// <returns></returns>
        public static DbSettings GetSetting(string DbType, string Serverip, string DbName)
        {
            try
            {
                DbSettings dbset = null;
                var ds = new DataSet();
                if (File.Exists(fileName))
                {
                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema
                    if (ds.Tables.Count > 0)
                    {
                        var strwhere = "DbType='" + DbType + "' and Server='" + Serverip + "'";
                        if (DbName.Trim() != "")
                        {
                            strwhere += " and DbName='" + DbName + "'";
                        }
                        var drs = ds.Tables[0].Select(strwhere);
                        if (drs.Length > 0)
                        {
                            dbset = new DbSettings
                            {
                                DbType = drs[0]["DbType"].ToString(),
                                Server = drs[0]["Server"].ToString(),
                                ConnectStr = drs[0]["ConnectStr"].ToString(),
                                DbName = drs[0]["DbName"].ToString()
                            };

                            if (ds.Tables[0].Columns.Contains("ConnectSimple") &&
                                ((drs[0]["ConnectSimple"] != null) && (drs[0]["ConnectSimple"].ToString().Length > 0)))
                            {
                                dbset.ConnectSimple = bool.Parse(drs[0]["ConnectSimple"].ToString());
                            }
                        }
                    }
                }
                return dbset;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 保存当前数据源设置

        public static DataTable CreateDataTable()
        {
            var table = new DataTable("DBServer");
            DataColumn col;

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "DbType"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "Server"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "ConnectStr"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "DbName"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.Boolean"), ColumnName = "ConnectSimple"};
            table.Columns.Add(col);

            return table;
        }

        /// <summary>
        /// 增加当前数据源设置
        /// </summary>
        /// <param name="data"></param>
        public static bool AddSettings(DbSettings dbobj)
        {
            try
            {
                var ds = new DataSet();
                if (!File.Exists(fileName))
                {
                    #region 第一次添加
                    var dt = CreateDataTable();
                    var rown = dt.NewRow();
                    rown["DbType"] = dbobj.DbType;
                    rown["Server"] = dbobj.Server;
                    rown["ConnectStr"] = dbobj.ConnectStr;
                    rown["DbName"] = dbobj.DbName;
                    rown["ConnectSimple"] = dbobj.ConnectSimple;
                    dt.Rows.Add(rown);

                    ds.Tables.Add(dt);
                    #endregion
                }
                else
                {
                    #region 追加

                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema
                    if (ds.Tables.Count > 0)
                    {
                        var drs = ds.Tables[0].Select("DbType='" + dbobj.DbType + "' and Server='" + dbobj.Server + "' and DbName='" + dbobj.DbName + "'");
                        if (drs.Length > 0)
                        {
                            //drs[0]["DbType"] = dbobj.DbType;
                            //drs[0]["Server"] = dbobj.Server;
                            //drs[0]["Uid"] = dbobj.Uid;
                            //drs[0]["Password"] = dbobj.Password;
                            //drs[0]["LoginMode"] = dbobj.LoginMode;
                            return false;
                        }
                        else
                        {
                            var rown = ds.Tables[0].NewRow();
                            rown["DbType"] = dbobj.DbType;
                            rown["Server"] = dbobj.Server;
                            rown["ConnectStr"] = dbobj.ConnectStr;
                            rown["DbName"] = dbobj.DbName;
                            rown["ConnectSimple"] = dbobj.ConnectSimple;
                            ds.Tables[0].Rows.Add(rown);

                        }
                    }
                    else
                    {
                        var dt = CreateDataTable();
                        var rown = dt.NewRow();
                        rown["DbType"] = dbobj.DbType;
                        rown["Server"] = dbobj.Server;
                        rown["ConnectStr"] = dbobj.ConnectStr;
                        rown["DbName"] = dbobj.DbName;
                        rown["ConnectSimple"] = dbobj.ConnectSimple;
                        dt.Rows.Add(rown);

                        ds.Tables.Add(dt);
                    }
                    #endregion

                }
                ds.WriteXml(fileName);
                return true;
            }
            catch
            {
                //throw new Exception("保存配置信息失败！");
                return false;
            }
        }

        /// <summary>
        /// 更新当前数据源设置
        /// </summary>
        /// <param name="data"></param>
        public static void UpdateSettings(DbSettings dbobj)
        {
            try
            {
                var ds = new DataSet();
                if (!File.Exists(fileName))
                {
                    var dt = CreateDataTable();
                    var rown = dt.NewRow();
                    rown["DbType"] = dbobj.DbType;
                    rown["Server"] = dbobj.Server;
                    rown["ConnectStr"] = dbobj.ConnectStr;
                    rown["DbName"] = dbobj.DbName;
                    rown["ConnectSimple"] = dbobj.ConnectSimple;
                    dt.Rows.Add(rown);

                    ds.Tables.Add(dt);
                }
                else
                {
                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema
                    if (ds.Tables.Count > 0)
                    {
                        var drs = ds.Tables[0].Select("DbType='" + dbobj.DbType + "' and Server='" + dbobj.Server + "' and DbName='" + dbobj.DbName + "'");
                        if (drs.Length > 0)
                        {
                            drs[0]["DbType"] = dbobj.DbType;
                            drs[0]["Server"] = dbobj.Server;
                            drs[0]["ConnectStr"] = dbobj.ConnectStr;
                            drs[0]["DbName"] = dbobj.DbName;
                            drs[0]["ConnectSimple"] = dbobj.ConnectSimple;

                        }
                        else
                        {
                            var rown = ds.Tables[0].NewRow();
                            rown["DbType"] = dbobj.DbType;
                            rown["Server"] = dbobj.Server;
                            rown["ConnectStr"] = dbobj.ConnectStr;
                            rown["DbName"] = dbobj.DbName;
                            rown["ConnectSimple"] = dbobj.ConnectSimple;
                            ds.Tables[0].Rows.Add(rown);

                        }
                    }
                    else
                    {
                        var dt = CreateDataTable();
                        var rown = dt.NewRow();
                        rown["DbType"] = dbobj.DbType;
                        rown["Server"] = dbobj.Server;
                        rown["ConnectStr"] = dbobj.ConnectStr;
                        rown["DbName"] = dbobj.DbName;
                        rown["ConnectSimple"] = dbobj.ConnectSimple;
                        dt.Rows.Add(rown);

                        ds.Tables.Add(dt);
                    }

                }
                ds.WriteXml(fileName);
            }
            catch
            {
                throw new Exception("保存配置信息失败！");
            }
        }


        #endregion

        #region 删除 指定数据源的配置信息
        /// <summary>
        /// 删除指定数据源的配置信息
        /// </summary>
        /// <returns></returns>
        public static void DelSetting(string DbType, string Serverip, string DbName)
        {
            try
            {
                var ds = new DataSet();
                if (File.Exists(fileName))
                {
                    ds.ReadXml(fileName);//,XmlReadMode.ReadSchema
                    if (ds.Tables.Count > 0)
                    {
                        var strwhere = "DbType='" + DbType + "' and Server='" + Serverip + "'";
                        if ((DbName.Trim() != "") && (DbName.Trim() != "master"))
                        {
                            strwhere += " and DbName='" + DbName + "'";
                        }
                        var drs = ds.Tables[0].Select(strwhere);
                        if (drs.Length > 0)
                        {
                            ds.Tables[0].Rows.Remove(drs[0]);
                        }
                        ds.Tables[0].AcceptChanges();
                    }
                }
                ds.WriteXml(fileName);
            }
            catch
            {
                //return null;
            }
        }
        #endregion
    }
}
