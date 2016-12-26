//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

     /// <summary>
     /// CiExceptionManager
     /// 系统异常表
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
     public partial class CiExceptionManager : DbCommonManager
     {
      /// <summary>
      /// 构造函数
      /// </summary>
      public CiExceptionManager()
      {
          base.CurrentTableName = CiExceptionTable.TableName;
          base.PrimaryKey = BusinessLogic.FieldId;
      }

      /// <summary>
      /// 构造函数
      /// <param name="tableName">指定表名</param>
      /// </summary>
      public CiExceptionManager(string tableName)
      {
          base.CurrentTableName = tableName;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      public CiExceptionManager(IDbProvider dbProvider): this()
      {
          DBProvider = dbProvider;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="userInfo">用户信息</param>
      public CiExceptionManager(UserInfo userInfo) : this()
      {
          UserInfo = userInfo;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      /// <param name="userInfo">用户信息</param>
      public CiExceptionManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
      {
          UserInfo = userInfo;
      }

      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      /// <param name="userInfo">用户信息</param>
      /// <param name="tableName">指定表名</param>
      public CiExceptionManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
      {
          base.CurrentTableName = tableName;
      }

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="ciExceptionEntity">实体</param>
      /// <returns>主键</returns>
      public string Add(CiExceptionEntity ciExceptionEntity)
      {
          return this.AddEntity(ciExceptionEntity);
      }

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="ciExceptionEntity">实体</param>
      /// <param name="identity">自增量方式</param>
      /// <param name="returnId">返回主键</param>
      /// <returns>主键</returns>
      public string Add(CiExceptionEntity ciExceptionEntity, bool identity, bool returnId)
      {
          this.Identity = identity;
          this.ReturnId = returnId;
          return this.AddEntity(ciExceptionEntity);
      }

      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="ciExceptionEntity">实体</param>
      public int Update(CiExceptionEntity ciExceptionEntity)
      {
          return this.UpdateEntity(ciExceptionEntity);
      }

      /// <summary>
      /// 获取实体
      /// </summary>
      /// <param name="id">主键</param>
      public CiExceptionEntity GetEntity(string id)
      {
          //var ciExceptionEntity = new CiExceptionEntity(this.GetDT(CiExceptionTable.FieldId, id));
          //return ciExceptionEntity;
          return BaseEntity.Create<CiExceptionEntity>(this.GetDT(CiExceptionTable.FieldId, id));
      }

      /// <summary>
      /// 添加实体
      /// </summary>
      /// <param name="ciExceptionEntity">实体</param>
      public string AddEntity(CiExceptionEntity ciExceptionEntity)
      {
           var sequence = string.Empty;
           this.Identity = false;
           var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
           sqlBuilder.BeginInsert(this.CurrentTableName, CiExceptionTable.FieldId);
           if (!this.Identity)
           {
               if (string.IsNullOrEmpty(ciExceptionEntity.Id))
               {
                   sequence = BusinessLogic.NewGuid();
                   ciExceptionEntity.Id = sequence;
               }
               sqlBuilder.SetValue(CiExceptionTable.FieldId, ciExceptionEntity.Id);
           }
           this.SetEntity(sqlBuilder, ciExceptionEntity);
           if (UserInfo != null)
           {
               sqlBuilder.SetValue(CiExceptionTable.FieldCreateUserId, UserInfo.Id);
               sqlBuilder.SetValue(CiExceptionTable.FieldCreateBy, UserInfo.RealName);
           }
           sqlBuilder.SetDBNow(CiExceptionTable.FieldCreateOn);
           if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
           {
               sequence = sqlBuilder.EndInsert().ToString();
           }
           else
           {
               sqlBuilder.EndInsert();
           }
        return sequence;
      }

      #region public string AddEntity(Exception ex) 记录异常情况
      /// <summary>
      /// 记录异常情况
      /// </summary>
      /// <param name="ex">异常类</param>
      /// <returns>主键</returns>
      public int AddEntity(Exception ex)
      {
          // string sequence = CiSequenceManager.Instance.GetSequence(DBProvider, BaseExceptionEntity.TableName);
          //string sequence = BusinessLogic.NewGuid();
          var sqlBuilder = new SQLBuilder(DBProvider);
          sqlBuilder.BeginInsert(CiExceptionTable.TableName);
          sqlBuilder.SetValue(CiExceptionTable.FieldId, BusinessLogic.NewGuid());
          sqlBuilder.SetValue(CiExceptionTable.FieldTitle, UserInfo.ProcessName);
          sqlBuilder.SetValue(CiExceptionTable.FieldProcessId, UserInfo.ProcessId);
          sqlBuilder.SetValue(CiExceptionTable.FieldProcessName, UserInfo.ProcessName);
          sqlBuilder.SetValue(CiExceptionTable.FieldMessage, ex.Message);
          sqlBuilder.SetValue(CiExceptionTable.FieldThreadName, ex.Source);
          sqlBuilder.SetValue(CiExceptionTable.FieldFormattedMessage, ex.StackTrace);
          if (UserInfo != null)
          {
              //sqlBuilder.SetValue(CiExceptionTable.FieldIPAddress, UserInfo.IPAddress);
              sqlBuilder.SetValue(CiExceptionTable.FieldCreateUserId, UserInfo.Id);
              sqlBuilder.SetValue(CiExceptionTable.FieldCreateBy, UserInfo.RealName);
          }
          sqlBuilder.SetDBNow(CiExceptionTable.FieldCreateOn);
          return sqlBuilder.EndInsert();
      }
      #endregion

      /// <summary>
      /// 更新实体
      /// </summary>
      /// <param name="ciExceptionEntity">实体</param>
      public int UpdateEntity(CiExceptionEntity ciExceptionEntity)
      {
          var sqlBuilder = new SQLBuilder(DBProvider);
          sqlBuilder.BeginUpdate(this.CurrentTableName);
          this.SetEntity(sqlBuilder, ciExceptionEntity);
          sqlBuilder.SetWhere(CiExceptionTable.FieldId, ciExceptionEntity.Id);
          return sqlBuilder.EndUpdate();
      }

      /// <summary>
      /// 设置实体
      /// </summary>
      /// <param name="sqlBuilder">SQL语句生成器</param>
      /// <param name="ciExceptionEntity">实体</param>
      private void SetEntity(SQLBuilder sqlBuilder, CiExceptionEntity ciExceptionEntity)
      {
          sqlBuilder.SetValue(CiExceptionTable.FieldEventId, ciExceptionEntity.EventId);
          sqlBuilder.SetValue(CiExceptionTable.FieldCategory, ciExceptionEntity.Category);
          sqlBuilder.SetValue(CiExceptionTable.FieldPriority, ciExceptionEntity.Priority);
          sqlBuilder.SetValue(CiExceptionTable.FieldSeverity, ciExceptionEntity.Severity);
          sqlBuilder.SetValue(CiExceptionTable.FieldTitle, ciExceptionEntity.Title);
          sqlBuilder.SetValue(CiExceptionTable.FieldTimestamp, ciExceptionEntity.Timestamp);
          sqlBuilder.SetValue(CiExceptionTable.FieldMachineName, ciExceptionEntity.MachineName);
          sqlBuilder.SetValue(CiExceptionTable.FieldAppDomainName, ciExceptionEntity.AppDomainName);
          sqlBuilder.SetValue(CiExceptionTable.FieldProcessId, ciExceptionEntity.ProcessId);
          sqlBuilder.SetValue(CiExceptionTable.FieldProcessName, ciExceptionEntity.ProcessName);
          sqlBuilder.SetValue(CiExceptionTable.FieldThreadName, ciExceptionEntity.ThreadName);
          sqlBuilder.SetValue(CiExceptionTable.FieldWin32ThreadId, ciExceptionEntity.Win32ThreadId);
          sqlBuilder.SetValue(CiExceptionTable.FieldMessage, ciExceptionEntity.Message);
          sqlBuilder.SetValue(CiExceptionTable.FieldFormattedMessage, ciExceptionEntity.FormattedMessage);
      }

      /// <summary>
      /// 删除实体
      /// </summary>
      /// <param name="id">主键</param>
      /// <returns>影响行数</returns>
      public int Delete(int id)
      {
          return this.Delete(CiExceptionTable.FieldId, id);
      }

      #region public string LogException(UserInfo userInfo, Exception ex) 记录异常情况
      /// <summary>
      /// 用新数据库连接保存异常情况
      /// </summary>
      /// <param name="userInfo">用户信息</param>
      /// <param name="ex">异常</param>
      /// <returns>受影响的行数</returns>
      public int LogException(UserInfo userInfo, Exception ex)
      {
          return LogException(DBProvider, userInfo, ex);
      }
      #endregion

      #region public static string LogException(IDbProvider dbProvider, UserInfo userInfo, Exception ex) 记录异常情况
      /// <summary>
      /// 记录异常情况
      /// </summary>
      /// <param name="dbProvider">数据库连接</param>
      /// <param name="userInfo">用户</param>
      /// <param name="ex">异常</param>
      /// <returns>受影响的行数</returns>
      public static int LogException(IDbProvider dbProvider, UserInfo userInfo, Exception ex)
      {
          // 在控制台需要输出错误信息
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(ex.InnerException);
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine(string.Empty);

          var returnValue = 0;
          // 系统里应该可以配置是否记录异常现象
          if (!SystemInfo.LogException)
          {
              return returnValue;
          }
          // Windows系统异常中
          if (SystemInfo.EventLog)
          {
              if (!System.Diagnostics.EventLog.SourceExists(SystemInfo.SoftName))
              {
                  System.Diagnostics.EventLog.CreateEventSource(SystemInfo.SoftName,SystemInfo.SoftFullName);
              }
              var eventLog = new System.Diagnostics.EventLog();
              eventLog.Source = SystemInfo.SoftName;
              eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
          }
          // 判断一下数据库是否打开状态，若数据库都没能打开，还记录啥错误，不是又抛出另一个错误了？
          if (dbProvider != null && dbProvider.GetDbConnection() != null)
          {
              if (dbProvider.GetDbConnection().State == ConnectionState.Open)
              {
                  var exceptionManager = new CiExceptionManager(dbProvider, userInfo);
                  returnValue = exceptionManager.AddEntity(ex);
              }
          }
          return returnValue;
      }
      #endregion
      }
}
