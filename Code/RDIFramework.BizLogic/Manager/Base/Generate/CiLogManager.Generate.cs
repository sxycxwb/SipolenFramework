//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// LogManager
    /// 系统日志表
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 EricHu 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class LogManager : DbCommonManager, IDbCommonManager
    {
        public LogManager()
        {
            CurrentTableName = CiLogTable.TableName;
            if (DBProvider == null)
            {
                DBProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            if (string.IsNullOrEmpty(CurrentTableName))
            {
                CurrentTableName = CiLogTable.TableName;
            }
        }

        public LogManager(IDbProvider dbProvider) : this()
        {
            DBProvider = dbProvider;
        }

        public LogManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        private static LogManager instance = null;
        private static object locker = new Object();

        public static LogManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new LogManager();
                        }
                    }
                }
                return instance;
            }
        }

        #region public int AddEntity(CiLogEntity logEntity)
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logEntity">日志对象</param>
        /// <returns>受影响的行数</returns>
        public string AddEntity(CiLogEntity logEntity)
        {
            if (!SystemInfo.EnableRecordLog)
            {
                return string.Empty;
            }

            string sequence = string.Empty;
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider,this.Identity,this.ReturnId);
            sqlBuilder.BeginInsert(CiLogTable.TableName);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(logEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    logEntity.Id = sequence;
                }
                sqlBuilder.SetValue(CiLogTable.FieldId, logEntity.Id);
            }

            if (String.IsNullOrEmpty(logEntity.CreateUserId))
            {
                logEntity.CreateUserId = logEntity.IPAddress;
            }

            sqlBuilder.SetValue(CiLogTable.FieldUserRealName, logEntity.UserRealName);
            sqlBuilder.SetValue(CiLogTable.FieldProcessId, logEntity.ProcessId);
            sqlBuilder.SetValue(CiLogTable.FieldProcessName, logEntity.ProcessName);
            sqlBuilder.SetValue(CiLogTable.FieldMethodEngName, logEntity.MethodEngName);
            sqlBuilder.SetValue(CiLogTable.FieldMethodName, logEntity.MethodName);
            sqlBuilder.SetValue(CiLogTable.FieldParameters, logEntity.Parameters);
            sqlBuilder.SetValue(CiLogTable.FieldWebUrl, logEntity.WebUrl);
            sqlBuilder.SetValue(CiLogTable.FieldIPAddress, logEntity.IPAddress);
            sqlBuilder.SetValue(CiLogTable.FieldDescription, logEntity.Description);

            if (logEntity.CreateUserId.Length == 0)
            {
                logEntity.CreateUserId = logEntity.IPAddress;
            }
            sqlBuilder.SetValue(CiLogTable.FieldCreateUserId, logEntity.CreateUserId);
            sqlBuilder.SetValue(CiLogTable.FieldCreateBy, logEntity.CreateBy);
            sqlBuilder.SetDBNow(CiLogTable.FieldCreateOn);
            if (DBProvider.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }
        #endregion
    }
}
