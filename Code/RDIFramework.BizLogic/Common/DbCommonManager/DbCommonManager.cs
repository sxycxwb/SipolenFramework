//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
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
    ///     2015-09-17 版本：3.0 EricHu 增加DbCommonManager.GetDataReader.cs 下大量通用方法。
    ///     2015-02-22 版本：2.8 EricHu 增加DbCommonManager.GetList.css 下大量通用方法。
    ///		2012.02.04 版本：1.5 EricHu 文件进行分割，简化处理。
    ///		2010.06.23 版本：1.4 EricHu 删除简化了一些重复的函数功能。
    ///		2009.11.22 版本：1.3 EricHu 创建没有SystemInfo的构造函数。
    ///		2009.11.20 版本：1.2 EricHu 完善有数据库连接、当前用户信息的构造函数、增加NonSerialized。
    ///		2009.11.15 版本：1.1 EricHu 设置 SetParameter 函数功能。
    ///		2009.08.01 版本：1.0 EricHu 提炼了最基础的方法部分、觉得这些是很有必要的方法。
    ///
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2009.06.02</date>
    /// </author> 
    /// </summary>
    public abstract partial class DbCommonManager : IDbCommonManager
    {
        /// <summary>
        /// 数据表主键，需要用单一字段做为主键，建议默认为ID字段
        /// </summary>
        public string PrimaryKey = "ID";

        /// <summary>
        /// 是否自增量？大并发数据主键生成需要用这个方法
        /// 不是所有的情况下，都是在进行插入操作的，也不都是有Id字段的
        /// </summary>
        public bool Identity = true;
        
        /// <summary>
        /// 插入数据时，是否需要返回主键
        /// 默认都是需要插入操作时都要返回主键的
        /// </summary>
        public bool ReturnId = true;

        private string selectField = "*";
        /// <summary>
        /// 选取的字段
        /// </summary>
        public string SelectField
        {
            get
            {
                return selectField;
            }
            set
            {
                selectField = value;
            }
        }

        /// <summary>
        /// 当前控制的表名
        /// </summary>
        public string CurrentTableName = string.Empty;

        private static object locker = new Object();

        protected IDbProvider dbProvider = null;
        /// <summary>
        /// 当前的数据库连接
        /// </summary>
        public IDbProvider DBProvider
        {
            set
            {
                dbProvider = value;
            }
            get
            {
                if (dbProvider == null)
                {
                    lock (locker)
                    {
                        if (dbProvider == null)
                        {
                            dbProvider = DbFactoryProvider.GetProvider();
                            // 是自动打开关闭数据库状态
                            dbProvider.AutoOpenClose = true;
                        }
                    }
                }
                return dbProvider;
            }
        }

        protected UserInfo UserInfo = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbCommonManager()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">IDbProvider</param>
        public DbCommonManager(IDbProvider dbProvider) : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">IDbProvider</param>
        /// <param name="userInfo">用户</param>
        public DbCommonManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public void SetConnection(IDbProvider dbProvider)
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 设置当前用户
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        public void SetConnection(UserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 设置数据库连接、当前用户
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">当前用户</param>
        public void SetConnection(IDbProvider dbProvider, UserInfo userInfo)
        {
            this.SetConnection(dbProvider);
            UserInfo = userInfo;
        }

        public virtual void SetParameter(IDbProvider dbProvider)
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        public virtual void SetParameter(UserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="dbProvider">IDbProvider</param>
        /// <param name="userInfo">用户</param>
        public virtual void SetParameter(IDbProvider dbProvider, UserInfo userInfo)
        {
            DBProvider = dbProvider;
            UserInfo = userInfo;
        }

        //
        // 类对应的数据库最终操作
        //
        public virtual string AddEntity(object entity)
        {
            return string.Empty;
        }

        public virtual int UpdateEntity(object entity)
        {
            return 0;
        }
        
        public virtual int DeleteEntity(object id)
        {
            return DeleteEntity(new KeyValuePair<string, object>(BusinessLogic.FieldId, id));
        }
        
        public virtual int DeleteEntity(string name, object value)
        {
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, name, value);
        }

        public virtual int DeleteEntity(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return DbCommonLibary.Delete(DBProvider, this.CurrentTableName, parametersList);
        }

        //
        // 对象事件触发器（编写程序的人员，可以不实现这些方法）
        //
        public virtual bool AddBefore()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool AddAfter()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool UpdateBefore()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool UpdateAfter()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool GetBefore(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool GetAfter(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool DeleteBefore(string id)
        {
            // 这个函数需要覆盖
            return true;
        }
        public virtual bool DeleteAfter(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        //
        // 批量操作保存
        //
        public virtual int BatchSave(DataTable dataTable)
        {
            return 0;
        }

        //
        // 读取一条记录
        //

        public virtual object GetFrom(DataTable dataTable)
        {
            return GetFrom(dataTable, string.Empty);
        }

        public virtual object GetFrom(DataTable dataTable, string id)
        {
            return GetFrom(dataTable, BusinessLogic.FieldId, id);
        }

        public virtual object GetFrom(DataTable dataTable, string name, object value)
        {
            // 清除属性
            foreach (DataRow dataRow in dataTable.Rows.Cast<DataRow>().Where(dataRow => (value == null) || (value.ToString().Length == 0) || (dataRow[name].ToString().Equals(value))))
            {
                GetFrom(dataRow);
                break;
            }
            return this;
        }

        public virtual object GetFrom(DataRow dataRow)
        {
            return this;
        }


        //
        // 状态码的获取
        //

        private string returnStatusCode = StatusCode.Error.ToString();
        /// <summary>
        /// 运行状态返回值
        /// </summary>
        public string ReturnStatusCode
        {
            get
            {
                return this.returnStatusCode;
            }
            set
            {
                this.returnStatusCode = value;
            }
        }

        private string returnStatusMessage = string.Empty;
        /// <summary>
        /// 运行状态的信息
        /// </summary>
        public string ReturnStatusMessage
        {
            get
            {
                return this.returnStatusMessage;
            }
            set
            {
                this.returnStatusMessage = value;
            }
        }

        public string GetStateMessage()
        {
            return this.GetStateMessage(this.ReturnStatusCode);
        }

        public string GetStateMessage(string statusCode)
        {
            if (String.IsNullOrEmpty(statusCode))
            {
                return string.Empty;
            }
            StatusCode status = (StatusCode)Enum.Parse(typeof(StatusCode), statusCode, true);
            return this.GetStateMessage(status);
        }

        #region public string GetStateMessage(StatusCode statusCode) 获得状态的信息
        /// <summary>
        /// 获得状态的信息
        /// </summary>
        /// <param name="statusCode">程序运行状态</param>
        /// <returns>返回信息</returns>
        public string GetStateMessage(StatusCode statusCode)
        {
            string returnValue = string.Empty;
            switch (statusCode)
            {
                case StatusCode.DbError:
                    returnValue = RDIFrameworkMessage.MSG0002;
                    break;
                case StatusCode.Error:
                    returnValue = RDIFrameworkMessage.MSG0001;
                    break;
                case StatusCode.OK:
                    returnValue = RDIFrameworkMessage.MSG9965;
                    break;
                case StatusCode.UserNotFound:
                    returnValue = RDIFrameworkMessage.MSG9966;
                    break;
                case StatusCode.PasswordError:
                    returnValue = RDIFrameworkMessage.MSG9967;
                    break;
                case StatusCode.LogOnDeny:
                    returnValue = RDIFrameworkMessage.MSG9968;
                    break;
                case StatusCode.ErrorOnLine:
                    returnValue = RDIFrameworkMessage.MSG0048;
                    break;
                case StatusCode.ErrorMacAddress:
                    returnValue = RDIFrameworkMessage.MSG0049;
                    break;
                case StatusCode.ErrorIPAddress:
                    returnValue = RDIFrameworkMessage.MSG0050;
                    break;
                case StatusCode.ErrorOnLineLimit:
                    returnValue = RDIFrameworkMessage.MSG0051;
                    break;
                case StatusCode.PasswordCanNotBeNull:
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9961);
                    break;
                case StatusCode.PasswordNotStrength:
                    returnValue = RDIFrameworkMessage.MSG8000;
                    break;
                case StatusCode.ErrorDeleted:
                    returnValue = RDIFrameworkMessage.MSG0005;
                    break;
                case StatusCode.SetPasswordOK:
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG9963, RDIFrameworkMessage.MSG9964);
                    break;
                case StatusCode.OldPasswordError:
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0040, RDIFrameworkMessage.MSG9961);
                    break;
                case StatusCode.ChangePasswordOK:
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG9962, RDIFrameworkMessage.MSG9964);
                    break;
                case StatusCode.OKAdd:
                    returnValue = RDIFrameworkMessage.MSG0009;
                    break;
                case StatusCode.CanNotLock:
                    returnValue = RDIFrameworkMessage.MSG0043;
                    break;
                case StatusCode.LockOK:
                    returnValue = RDIFrameworkMessage.MSG0044;
                    break;
                case StatusCode.OKUpdate:
                    returnValue = RDIFrameworkMessage.MSG0010;
                    break;
                case StatusCode.OKDelete:
                    returnValue = RDIFrameworkMessage.MSG0013;
                    break;
                case StatusCode.Exist:
                    // "编号已存在,不可以重复."
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9955);
                    break;
                case StatusCode.ErrorCodeExist:
                    // "编号已存在,不可以重复."
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9977);
                    break;
                case StatusCode.ErrorNameExist:
                    // "名称已存在,不可以重复."
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9978);
                    break;
                case StatusCode.ErrorValueExist:
                    // "值已存在,不可以重复."
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9800);
                    break;
                case StatusCode.ErrorUserExist:
                    // "用户名已存在,不可以重复."
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9957);
                    break;
                case StatusCode.ErrorDataRelated:
                    returnValue = RDIFrameworkMessage.MSG0033;
                    break;
                case StatusCode.ErrorChanged:
                    returnValue = RDIFrameworkMessage.MSG0006;
                    break;

                case StatusCode.UserNotEmail:
                    returnValue = RDIFrameworkMessage.MSG9910;
                    break;

                case StatusCode.UserLocked:
                    returnValue = RDIFrameworkMessage.MSG9911;
                    break;

                case StatusCode.WaitForAudit:
                case StatusCode.UserNotActive:
                    returnValue = RDIFrameworkMessage.MSG9912;
                    break;

                case StatusCode.UserIsActivate:
                    returnValue = RDIFrameworkMessage.MSG9913;
                    break;

                case StatusCode.NotFound:
                    returnValue = RDIFrameworkMessage.MSG9956;
                    break;

                case StatusCode.ErrorLogOn:
                    returnValue = RDIFrameworkMessage.MSG9000;
                    break;

                case StatusCode.UserDuplicate:
                    returnValue = RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9957);
                    break;
                // 开始审核
                case StatusCode.StartAudit:
                    returnValue = RDIFrameworkMessage.MSG0009;
                    break;
                //// 审核通过
                //case AuditStatus.AuditPass:
                //    returnValue = RDIFrameworkMessage.MSG0009;
                //    break;
                //// 待审核
                //case AuditStatus.WaitForAudit:
                //    returnValue = RDIFrameworkMessage.MSG0010;
                //    break;
                //// 审核退回
                //case AuditStatus.AuditReject:
                //    returnValue = RDIFrameworkMessage.MSG0009;
                //    break;
                //// 审核结束
                //case AuditStatus.AuditComplete:
                //    returnValue = RDIFrameworkMessage.MSG0010;
                //    break;
                //// 提交成功。
                //case AuditStatus.SubmitOK:
                //    returnValue = RDIFrameworkMessage.MSG0009;
                //    break;
            }
            return returnValue;
        }
        #endregion

        public virtual int SetTableColumns(string tableCode, string tableName, string columnCode, string columnName)
        {
            //CiSequenceManager sequenceManager = new CiSequenceManager(this.DBProvider);
            string sortCode = string.Empty;//sequenceManager.GetSequence(CiTableColumnsTable.TableName);

            // 插入数据
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginInsert(CiTableColumnsTable.TableName);

            sqlBuilder.SetValue(CiTableColumnsTable.FieldTableCode, tableCode);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnCode, columnCode);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldColumnName, columnName);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldSortCode, sortCode);

            sqlBuilder.SetValue(CiTableColumnsTable.FieldCreateUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldCreateBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiTableColumnsTable.FieldCreateOn);

            sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(CiTableColumnsTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(CiTableColumnsTable.FieldModifiedOn);
            return sqlBuilder.EndInsert();
        }
    }
}