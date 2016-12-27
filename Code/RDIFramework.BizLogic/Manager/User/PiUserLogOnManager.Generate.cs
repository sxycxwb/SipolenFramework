using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiUserLogOnManager
    /// 系统用户表登录信息
    ///
    /// 修改纪录
    ///
    ///		2014-03-26 版本：1.0 XuWangBin 创建主键。
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-03-26</date>
    /// </author>
    /// </summary>
    public partial class PiUserLogOnManager : DbCommonManager, IDbCommonManager
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public PiUserLogOnManager()
        {
            base.CurrentTableName = PiUserLogOnTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiUserLogOnManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiUserLogOnManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiUserLogOnManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiUserLogOnManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public PiUserLogOnManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiUserLogOnEntity entity)
        {
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(PiUserLogOnEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(PiUserLogOnEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiUserLogOnEntity GetEntity(string id)
        {
            //PiUserLogOnEntity entity = new PiUserLogOnEntity(this.GetDT(new KeyValuePair<string, object>(PiUserLogOnTable.FieldId, id)));
            //return entity;
            return BaseEntity.Create<PiUserLogOnEntity>(this.GetDT(PiUserLogOnTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(PiUserLogOnEntity entity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (entity.Id != null)
            {
                sequence = entity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiUserLogOnTable.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(entity.Id)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    entity.Id = sequence ;
                }
                sqlBuilder.SetValue(PiUserLogOnTable.FieldId, entity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiUserLogOnTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiUserLogOnTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(entity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            entity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiUserLogOnTable.FieldId, entity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(PiUserLogOnTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserLogOnTable.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(PiUserLogOnTable.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(PiUserLogOnTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserLogOnTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(PiUserLogOnTable.FieldModifiedOn);
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

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int UpdateEntity(PiUserLogOnEntity entity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(PiUserLogOnTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiUserLogOnTable.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(PiUserLogOnTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiUserLogOnTable.FieldId, entity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiUserLogOnEntity entity)
        {
            sqlBuilder.SetValue(PiUserLogOnTable.FieldUserFrom, entity.UserFrom);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldUserPassword, entity.UserPassword);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldOpenId, entity.OpenId);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldAllowStartTime, entity.AllowStartTime);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldAllowEndTime, entity.AllowEndTime);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLockStartDate, entity.LockStartDate);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLockEndDate, entity.LockEndDate);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldFirstVisit, entity.FirstVisit);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldPreviousVisit, entity.PreviousVisit);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLastVisit, entity.LastVisit);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldChangePasswordDate, entity.ChangePasswordDate);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldMultiUserLogin, entity.MultiUserLogin);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldLogOnCount, entity.LogOnCount);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldPasswordErrorCount, entity.PasswordErrorCount);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldUserOnLine, entity.UserOnLine);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldCheckIPAddress, entity.CheckIPAddress);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldIPAddress, entity.IPAddress);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldMACAddress, entity.MACAddress);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldQuestion, entity.Question);
            sqlBuilder.SetValue(PiUserLogOnTable.FieldAnswerQuestion, entity.AnswerQuestion);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(PiUserLogOnTable.FieldId, id));
        }
    }
}
