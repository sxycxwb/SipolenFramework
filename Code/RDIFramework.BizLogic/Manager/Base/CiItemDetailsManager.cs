//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , gt TECH, Ltd.
//--------------------------------------------------------------------

using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CiItemDetailsManager
    /// 数据字典明细表
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
    public partial class CiItemDetailsManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CiItemDetailsManager()
        {
            base.CurrentTableName = CiItemDetailsTable.TableName;
            base.PrimaryKey = BusinessLogic.FieldId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public CiItemDetailsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public CiItemDetailsManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public CiItemDetailsManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public CiItemDetailsManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public CiItemDetailsManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 绑定下列列表
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByCode(string code)
        {
            var strSql = "SELECT " + CiItemDetailsTable.FieldItemCode + ","
                          + CiItemDetailsTable.FieldItemName + ","
                          + CiItemDetailsTable.FieldItemValue
                          + " FROM " + CiItemDetailsTable.TableName
                          + " WHERE " + CiItemDetailsTable.FieldItemId + " = ("
                          + "SELECT Id FROM "
                          + CiItemsTable.TableName
                          + " WHERE "
                          + CiItemsTable.FieldCode
                          + " = '" + code + "')"
                          + " AND " + CiItemDetailsTable.FieldDeleteMark + "= 0 "
                          + " AND " + CiItemDetailsTable.FieldEnabled + " = 1"
                          + " ORDER BY " + CiItemDetailsTable.FieldSortCode;
            return this.Fill(strSql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        /// <returns>受影响的行数</returns>
        public string Add(CiItemDetailsEntity ciItemDetailsEntity)
        {
            return this.AddEntity(ciItemDetailsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>受影响的行数</returns>
        public string Add(CiItemDetailsEntity ciItemDetailsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(ciItemDetailsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        public int Update(CiItemDetailsEntity ciItemDetailsEntity)
        {
            return this.UpdateEntity(ciItemDetailsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public CiItemDetailsEntity GetEntity(string id)
        {
            //var ciItemDetailsEntity = new CiItemDetailsEntity(this.GetDT(CiItemDetailsTable.FieldId, id));
            //return ciItemDetailsEntity;
            return BaseEntity.Create<CiItemDetailsEntity>(this.GetDT(CiItemDetailsTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        public string AddEntity(CiItemDetailsEntity ciItemDetailsEntity)
        {
            var returnValue = string.Empty;

            if (DBProvider.CurrentDbType == CurrentDbType.SqlServer)
            {
                ciItemDetailsEntity.SortCode = BusinessLogic.ConvertToNullableInt(dbProvider.ExecuteScalar("SELECT SortCode = ISNULL(MAX(SortCode),0) + 1 FROM CIITEMDETAILS WHERE DELETEMARK=0 AND ITEMID = '" + ciItemDetailsEntity.ItemId + "'"));
            }
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                ciItemDetailsEntity.SortCode = BusinessLogic.ConvertToNullableInt(DBProvider.ExecuteScalar("SELECT  NVL(MAX(SORTCODE),0) + 1 AS SORTCODE FROM CIITEMDETAILS WHERE DELETEMARK=0 AND ITEMID = '" + ciItemDetailsEntity.ItemId + "'"));
            }

            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider,this.Identity,this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName,CiItemDetailsTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(ciItemDetailsEntity.Id))
                {
                    returnValue = BusinessLogic.NewGuid();
                    ciItemDetailsEntity.Id = returnValue;
                }
                sqlBuilder.SetValue(CiItemDetailsTable.FieldId, ciItemDetailsEntity.Id);
            }
            this.SetEntity(sqlBuilder, ciItemDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemDetailsTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(CiItemDetailsTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemDetailsTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemDetailsTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemDetailsTable.FieldModifiedOn);
            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
            {
                returnValue = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return returnValue;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        public int UpdateEntity(CiItemDetailsEntity ciItemDetailsEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, ciItemDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(CiItemDetailsTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(CiItemDetailsTable.FieldModifiedOn);
            sqlBuilder.SetWhere(CiItemDetailsTable.FieldId, ciItemDetailsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 是否存在相同的明细项(主要用于修改明细项时做判断)
        /// </summary>
        /// <param name="ciItemDetailsEntity">实体</param>
        /// <returns>存在：true，不存在:false</returns>
        public bool IsExisted(CiItemDetailsEntity ciItemDetailsEntity)
        {
            var sqlStatement = "SELECT COUNT(1) FROM " + CiItemDetailsTable.TableName + " WHERE " 
                                + CiItemDetailsTable.FieldItemId + " = '" + ciItemDetailsEntity.ItemId + "'"
                                + " AND  " + CiItemDetailsTable.FieldItemName + " = '" + ciItemDetailsEntity.ItemName + "'"
                                + " AND  " + CiItemDetailsTable.FieldAllowDelete + " = 0  "
                                + " AND  " + CiItemDetailsTable.FieldId + " <> '" + ciItemDetailsEntity.Id + "'";

            return int.Parse(dbProvider.ExecuteScalar(sqlStatement).ToString()) > 0;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="ciItemDetailsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, CiItemDetailsEntity ciItemDetailsEntity)
        {
            sqlBuilder.SetValue(CiItemDetailsTable.FieldItemId, ciItemDetailsEntity.ItemId);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldParentId, ciItemDetailsEntity.ParentId);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldItemCode, ciItemDetailsEntity.ItemCode);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldItemName, ciItemDetailsEntity.ItemName);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldItemValue, ciItemDetailsEntity.ItemValue);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldAllowEdit, ciItemDetailsEntity.AllowEdit);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldAllowDelete, ciItemDetailsEntity.AllowDelete);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldIsPublic, ciItemDetailsEntity.IsPublic);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldSortCode, ciItemDetailsEntity.SortCode);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldDescription, ciItemDetailsEntity.Description);
            sqlBuilder.SetValue(CiItemDetailsTable.FieldModifiedUserId, ciItemDetailsEntity.ModifiedUserId);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(CiItemDetailsTable.FieldId, id);
        }
    }
}
