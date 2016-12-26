/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-16 15:13:43
 ******************************************************************************/

using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// CiSequenceManager
    /// 序列产生器表
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
    public partial class CiSequenceManager
    {
        /// <summary>
        /// 按名称获取实体
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>实体</returns>
        CiSequenceEntity GetEntityByName(string fullName)
        {
            CiSequenceEntity sequenceEntity = null;
            DataTable dataTable = this.GetDT(CiSequenceTable.FieldFullName, fullName);
            if (dataTable.Rows.Count > 0)
            {
                sequenceEntity = BaseEntity.Create<CiSequenceEntity>(dataTable); 
            }
            return sequenceEntity;
        }

        /// <summary>
        /// 获取添加
        /// </summary>
        /// <param name="fullName">序列名</param>
        /// <returns>序列实体</returns>
        CiSequenceEntity GetEntityByAdd(string fullName)
        {
            CiSequenceEntity sequenceEntity = null;            
            sequenceEntity = this.GetEntityByName(fullName);
            if (sequenceEntity == null)
            {
                sequenceEntity = new CiSequenceEntity
                {
                    FullName = fullName,
                    Sequence = this.DefaultSequence,
                    Reduction = this.DefaultReduction,
                    Step = DefaultStep,
                    Prefix = DefaultPrefix,
                    Separate = DefaultSeparator
                };
                // 这里是为了多种数据库的兼容
                //sequenceEntity.Id = BusinessLogic.NewGuid();
                this.Add(sequenceEntity, true);
            }

            return sequenceEntity;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        public string Add(CiSequenceEntity sequenceEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查是否重复
            if (this.Exists(CiSequenceTable.FieldFullName, sequenceEntity.FullName))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(sequenceEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        public int Update(CiSequenceEntity sequenceEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查名称是否重复
            if (this.Exists(CiSequenceTable.FieldFullName, sequenceEntity.FullName, sequenceEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                // 进行更新操作
                returnValue = this.UpdateEntity(sequenceEntity);
                statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            }
            return returnValue;
        }


        //
        // 读取序列的
        //


        /// <summary>
        /// 获取序列
        /// </summary>
        /// <param name="sequenceEntity">序列实体</param>
        /// <returns>序列</returns>
        string GetSequence(CiSequenceEntity sequenceEntity)
        {
            string sequence = sequenceEntity.Sequence.ToString();
            if (this.FillZeroPrefix)
            {
                sequence = BusinessLogic.RepeatString("0", (this.SequenceLength - sequenceEntity.Sequence.ToString().Length)) + sequenceEntity.Sequence.ToString();
            }
            if (this.UsePrefix)
            {
                sequence = sequenceEntity.Prefix + sequenceEntity.Separate + sequence;
            }
            return sequence;
        }

        /// <summary>
        /// 获取降序列
        /// </summary>
        /// <param name="sequenceEntity">序列实体</param>
        /// <returns>降序列</returns>
        string GetReduction(CiSequenceEntity sequenceEntity)
        {
            string reduction = sequenceEntity.Reduction.ToString();
            if (this.FillZeroPrefix)
            {
                reduction = BusinessLogic.RepeatString("0", (this.SequenceLength - sequenceEntity.Reduction.ToString().Length)) + sequenceEntity.Reduction.ToString();
            }
            if (this.UsePrefix)
            {
                reduction = sequenceEntity.Prefix + sequenceEntity.Separate + reduction;
            }
            return reduction;
        }
        

        //
        // 一 获取序列原值(没有序列时，涉及到并发问题、锁机制)
        //


        #region public string GetOldSequence(string fullName) 获得原序列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName)
        {
            return this.GetOldSequence(fullName, this.DefaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence) 获得原序列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence)
        {
            return this.GetOldSequence(fullName, defaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength) 获得原序列号
        /// <summary>
        /// 获得原序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength)
        {
            return this.GetOldSequence(fullName, defaultSequence, sequenceLength, false);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取序原列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            string sequence = string.Empty;
            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {
                this.SequenceLength = sequenceLength;
                this.FillZeroPrefix = fillZeroPrefix;
                this.DefaultReduction = defaultSequence;
                this.DefaultSequence = defaultSequence + 1;

                CiSequenceEntity sequenceEntity = GetEntityByAdd(fullName);
                sequence = GetSequence(sequenceEntity);
            }
            return sequence;
        }
        #endregion



        //
        // 三 获取新序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //

        public string GetOracleSequence(string fullName)
        {
            // 当前是自增量，并且是Oracle数据库
            return DBProvider.ExecuteScalar("SELECT SEQ_" + fullName.ToUpper() + ".NEXTVAL FROM DUAL ").ToString();
        }

        public string GetDB2Sequence(string fullName)
        {
            // 当前是自增量，并且是DB2数据库
            return DBProvider.ExecuteScalar("SELECT NEXTVAL FOR SEQ_" + fullName.ToUpper() + " FROM sysibm.sysdummy1").ToString();
        }

        #region public string GetSequence(string fullName) 获得序列号
        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName)
        {
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                return GetOracleSequence(fullName);
            }
            if (DBProvider.CurrentDbType == CurrentDbType.DB2)
            {
                return GetDB2Sequence(fullName);
            }
            return this.GetSequence(fullName, this.DefaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence) 获得序列号
        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName, int defaultSequence)
        {
            return this.GetSequence(fullName, defaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence, int sequenceLength) 获得序列号
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName, int defaultSequence, int sequenceLength)
        {
            return this.GetSequence(fullName, defaultSequence, sequenceLength, false);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取序列号
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充零</param>
        /// <returns>序列实体</returns>
        public string GetSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            this.DefaultSequence = defaultSequence;
            this.SequenceLength = sequenceLength;
            this.FillZeroPrefix = fillZeroPrefix;
            this.DefaultReduction = defaultSequence - 1;

            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            CiSequenceEntity sequenceEntity = null;

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {

                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        sequenceEntity = this.GetEntityByAdd(fullName);
                        this.UpdateSequence(fullName);
                        break;
                    case CurrentDbType.Oracle:
                        sequenceEntity = this.GetEntityByAdd(fullName);
                        this.UpdateSequence(fullName);
                        /*
                        // 这里加锁机制。
                        if (DBProvider.InTransaction)
                        {
                            // 不可以影响别人的事务
                            sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                            if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                            {
                                this.ReturnStatusCode = this.UpdateSequence(fullName) > 0 ? StatusCode.LockOK.ToString() : StatusCode.CanNotLock.ToString();
                            }
                        }
                        else
                        {
                            // 开始事务
                            IDbTransaction dbTransaction = DBProvider.BeginTransaction();
                            try
                            {
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                    if (this.UpdateSequence(fullName) > 0)
                                    {
                                        // 提交事务
                                        dbTransaction.Commit();
                                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                    }
                                    else
                                    {
                                        // 回滚事务
                                        dbTransaction.Rollback();
                                    }
                                }
                                else
                                {
                                    // 回滚事务
                                    dbTransaction.Rollback();
                                }
                            }
                            catch (System.Exception ex)
                            {
                                System.Console.WriteLine(ex);
                                // 回滚事务
                                dbTransaction.Rollback();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                            }
                        }
                         */
                        break;
                }
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return GetSequence(sequenceEntity);
        }
        #endregion

        #region protected int UpdateSequence(string fullName) 更新升序序列
        /// <summary>
        /// 更新升序序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>影响行数</returns>
        protected int UpdateSequence(string fullName)
        {
            return this.UpdateSequence(fullName, 1);
        }
        #endregion

        #region protected int UpdateSequence(string fullName, int sequenceCount) 更新升序序列
        /// <summary>
        /// 更新升序序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>影响行数</returns>
        protected int UpdateSequence(string fullName, int sequenceCount)
        {
            // 更新数据库里的值
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiSequenceTable.TableName);
            sqlBuilder.SetFormula(CiSequenceTable.FieldSequence, CiSequenceTable.FieldSequence + " + " + sequenceCount.ToString() + " * " + CiSequenceTable.FieldStep);
            sqlBuilder.SetWhere(CiSequenceTable.FieldFullName, fullName);
            return sqlBuilder.EndUpdate();
        }
        #endregion
        

        //
        // 三 获取降序序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //


        #region public string GetReduction(string fullName) 获取倒序序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(string fullName)
        {
            return this.GetReduction(fullName, this.DefaultSequence);
        }
        #endregion

        #region public string GetReduction(string fullName, int defaultSequence) 获取倒序序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列值</param>
        /// <returns>序列号</returns>
        public string GetReduction(string fullName, int defaultSequence)
        {            
            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            CiSequenceEntity sequenceEntity = null;

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {

                this.DefaultReduction = defaultSequence;
                this.DefaultSequence = defaultSequence + 1;

                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        sequenceEntity = GetEntityByAdd(fullName);
                        this.UpdateReduction(fullName);
                        break;
                    case CurrentDbType.Oracle:
                        if (DBProvider.InTransaction)
                        {
                            // 不可以影响别人的事务
                            sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                            if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                            {
                                this.ReturnStatusCode = this.UpdateReduction(fullName) > 0 ? StatusCode.LockOK.ToString() : StatusCode.CanNotLock.ToString();
                            }
                        }
                        else
                        {
                            // 这里加锁机制。
                            try
                            {
                                // 开始事务
                                DBProvider.BeginTransaction();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                    if (this.UpdateReduction(fullName) > 0)
                                    {
                                        // 提交事务
                                        DBProvider.CommitTransaction();
                                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                    }
                                    else
                                    {
                                        // 回滚事务
                                        DBProvider.RollbackTransaction();
                                    }
                                }
                                else
                                {
                                    // 回滚事务
                                    DBProvider.RollbackTransaction();
                                }
                            }
                            catch
                            {
                                // 回滚事务
                                DBProvider.RollbackTransaction();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                            }
                        }
                        break;
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return GetReduction(sequenceEntity);
        }
        #endregion

        #region protected int UpdateReduction(string fullName)
        /// <summary>
        /// 更新降序序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>影响行数</returns>
        protected int UpdateReduction(string fullName)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(CiSequenceTable.TableName);
            sqlBuilder.SetFormula(CiSequenceTable.FieldReduction, CiSequenceTable.FieldReduction + " - " + CiSequenceTable.FieldStep);
            sqlBuilder.SetWhere(CiSequenceTable.FieldFullName, fullName);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region protected CiSequenceEntity GetSequenceByLock(string fullName, int defaultSequence) 获得序列
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列实体</returns>
        protected CiSequenceEntity GetSequenceByLock(string fullName, int defaultSequence)
        {
            CiSequenceEntity sequenceEntity = new CiSequenceEntity();
            // 这里主要是为了判断是否存在
            sequenceEntity = this.GetEntityByName(fullName);
            if (sequenceEntity == null)
            {
                // 这里添加记录时加锁机制。
                // 是否已经被锁住
                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                for (int i = 0; i < SystemInfo.LockNoWaitCount; i++)
                {
                    // 被锁定的记录数
                    int lockCount = DbCommonLibary.LockNoWait(DBProvider, CiSequenceTable.TableName, CiSequenceTable.FieldFullName, CiSequenceTable.TableName);
                    if (lockCount > 0)
                    {

                        sequenceEntity.FullName = fullName;
                        sequenceEntity.Reduction = defaultSequence - 1;
                        sequenceEntity.Sequence = defaultSequence;
                        sequenceEntity.Step = DefaultStep;
                        this.AddEntity(sequenceEntity);

                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(RandomHelper.GetRandom(1, SystemInfo.LockNoWaitTickMilliSeconds));
                    }
                }
                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                {
                    // EricHu 这个是否能省略
                    sequenceEntity = this.GetEntityByName(fullName);
                }
            }
            else
            {
                // 若记录已经存在，加锁，然后读取记录。
                // 是否已经被锁住
                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                for (int i = 0; i < SystemInfo.LockNoWaitCount; i++)
                {
                    // 被锁定的记录数
                    int lockCount = DbCommonLibary.LockNoWait(DBProvider, CiSequenceTable.TableName, CiSequenceTable.FieldFullName, fullName);
                    if (lockCount > 0)
                    {
                        sequenceEntity = this.GetEntityByName(fullName);
                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(RandomHelper.GetRandom(1, SystemInfo.LockNoWaitTickMilliSeconds));
                    }
                }
            }
            return sequenceEntity;
        }
        #endregion
        

        //
        // 四 批量获取新序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //


        #region public string[] GetBatchSequence(string fullName, int sequenceCount) 获取序列号数组
        /// <summary>
        /// 获取序列号数组
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(string fullName, int sequenceCount)
        {
            return this.GetBatchSequence(fullName, sequenceCount, this.DefaultSequence);
        }
        #endregion

        #region private string[] GetSequence(CiSequenceTable sequenceEntity, int sequenceCount) 批量产生主键
        /// <summary>
        /// 批量产生主键
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>主键数组</returns>
        private string[] GetSequence(CiSequenceEntity sequenceEntity, int sequenceCount)
        {
            string[] returnValue = new string[sequenceCount];
            for (int i = 0; i < sequenceCount; i++)
            {
                returnValue[i] = GetSequence(sequenceEntity);
                sequenceEntity.Sequence += sequenceEntity.Step;
            }
            return returnValue;
        }
        #endregion

        #region public string[] GetBatchSequence(string fullName, int sequenceCount, int defaultSequence) 获取序列号数组
        /// <summary>
        /// 获取序列号数组
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(string fullName, int sequenceCount, int defaultSequence)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            string[] returnValue = new string[sequenceCount];

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {
                this.DefaultSequence = defaultSequence;
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        CiSequenceEntity sequenceEntity = this.GetEntityByAdd(fullName);
                        this.UpdateSequence(fullName, sequenceCount);
                        // 这里循环产生ID数组
                        returnValue = this.GetSequence(sequenceEntity, sequenceCount);
                        break;
                    case CurrentDbType.DB2:
                        for (int i = 0; i < sequenceCount; i++)
                        {
                            returnValue[i] = GetDB2Sequence(fullName);
                        }
                        break;
                    case CurrentDbType.Oracle:
                        for (int i = 0; i < sequenceCount; i++)
                        {
                            returnValue[i] = GetOracleSequence(fullName);
                        }
                        break;
                }
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return returnValue;
        }
        #endregion


        //
        // 重置序列(暂不考虑并发问题)
        //


        #region public int Reset(string[] ids) 批量重置
        /// <summary>
        /// 批量重置
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int Reset(string[] ids)
        {
            int returnValue = 0;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].Length > 0)
                {
                    sqlBuilder.BeginUpdate(CiSequenceTable.TableName);
                    sqlBuilder.SetValue(CiSequenceTable.FieldSequence, this.DefaultSequence);
                    sqlBuilder.SetValue(CiSequenceTable.FieldReduction, this.DefaultReduction);
                    sqlBuilder.SetWhere(CiSequenceTable.FieldId, ids[i]);
                    returnValue += sqlBuilder.EndUpdate();
                }
            }
            return returnValue;
        }
        #endregion
    }
}
