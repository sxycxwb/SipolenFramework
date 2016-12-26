/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-25 9:50:28
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiPlatFormAddInManager
    /// 平台插件
    ///
    /// 修改纪录
    ///
    ///		2012-05-25 版本：1.0 EricHu 创建PiPlatFormAddInManager。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-25</date>
    /// </author>
    /// </summary>
    public class PiPlatFormAddInManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiPlatFormAddInManager()
        {
            base.CurrentTableName = PiPlatFormAddInTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiPlatFormAddInManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiPlatFormAddInManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiPlatFormAddInManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiPlatFormAddInManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public PiPlatFormAddInManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piPlatFormAddInEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiPlatFormAddInEntity piPlatFormAddInEntity)
        {
            return this.AddEntity(piPlatFormAddInEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piPlatFormAddInEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(PiPlatFormAddInEntity piPlatFormAddInEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(piPlatFormAddInEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="piPlatFormAddInEntity">实体</param>
        public int Update(PiPlatFormAddInEntity piPlatFormAddInEntity)
        {
            return this.UpdateEntity(piPlatFormAddInEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiPlatFormAddInEntity GetEntity(string id)
        {
            PiPlatFormAddInEntity piPlatFormAddInEntity = new PiPlatFormAddInEntity(this.GetDT(PiPlatFormAddInTable.FieldId, id));
            return piPlatFormAddInEntity;
        }

        #region  public string Add(PiPlatFormAddInEntity piPlatFormAddInEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="piPlatFormAddInEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(PiPlatFormAddInEntity piPlatFormAddInEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            statusCode         = string.Empty;
            string[] names = { PiPlatFormAddInTable.FieldName,PiPlatFormAddInTable.FieldEnabled,PiPlatFormAddInTable.FieldDeleteMark};
            string[] values = { piPlatFormAddInEntity.Name,"1","0"};
            // 检查名称是否重复
            if (this.Exists(names, values))
            {
                statusCode = StatusCode.ErrorNameExist.ToString();

                piPlatFormAddInEntity.Id = GetId(PiPlatFormAddInTable.FieldName, piPlatFormAddInEntity.Name);
                //名称存在就更新数据
                if(this.UpdateEntity(piPlatFormAddInEntity) > 0)
                {
                    statusCode = StatusCode.OKUpdate.ToString();
                    returnValue = StatusCode.OKUpdate.ToString();
                }
            }
            else
            {
                returnValue = this.AddEntity(piPlatFormAddInEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="piPlatFormAddInEntity">实体</param>
        public string AddEntity(PiPlatFormAddInEntity piPlatFormAddInEntity)
        {
            string sequence = string.Empty;
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, PiPlatFormAddInTable.FieldId);
            if (!this.Identity)
            {
                if (String.IsNullOrEmpty(piPlatFormAddInEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    piPlatFormAddInEntity.Id = sequence;
                }
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldId, piPlatFormAddInEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiPlatFormAddInTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiPlatFormAddInTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (piPlatFormAddInEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            piPlatFormAddInEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiPlatFormAddInTable.FieldId, piPlatFormAddInEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, piPlatFormAddInEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPlatFormAddInTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPlatFormAddInTable.FieldModifiedOn);
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
        /// <param name="piPlatFormAddInEntity">实体</param>
        public int UpdateEntity(PiPlatFormAddInEntity piPlatFormAddInEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, piPlatFormAddInEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(PiPlatFormAddInTable.FieldModifiedUserId, piPlatFormAddInEntity.ModifiedUserId);
            }
            sqlBuilder.SetDBNow(PiPlatFormAddInTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiPlatFormAddInTable.FieldId, piPlatFormAddInEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="piPlatFormAddInEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiPlatFormAddInEntity piPlatFormAddInEntity)
        {
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldGuid, piPlatFormAddInEntity.Guid);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldName, piPlatFormAddInEntity.Name);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldAssemblyName, piPlatFormAddInEntity.AssemblyName);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldClassName, piPlatFormAddInEntity.ClassName);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldAddIn, piPlatFormAddInEntity.AddIn);

            //if (piPlatFormAddInEntity.AddInSize != null)
            //{
            //    sqlBuilder.SetValue(PiPlatFormAddInTable.FieldAddInSize, piPlatFormAddInEntity.AddIn.Length);
            //}
            //else
            //{
            //    sqlBuilder.SetValue(PiPlatFormAddInTable.FieldAddInSize, piPlatFormAddInEntity.AddInSize);
            //}

            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldAddInSize, piPlatFormAddInEntity.AddInSize);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldVersion, piPlatFormAddInEntity.Version);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldDeveloper, piPlatFormAddInEntity.Developer);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldDownLoadCount, piPlatFormAddInEntity.DownLoadCount);
            sqlBuilder.SetValue(PiPlatFormAddInTable.FieldDescription, piPlatFormAddInEntity.Description);     
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiPlatFormAddInTable.FieldId, id);
        }
    }
}
