//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2016 , RDIFramework.NET TECH, Ltd.
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// ProductInfoManager
    /// 产品信息
    /// 
    /// 修改纪录
    /// 
    /// 2012-08-29 版本：1.0 Edward 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>Edward</name>
    /// <date>2012-08-29</date>
    /// </author>
    /// </summary>
    public partial class ProductInfoManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductInfoManager()
        {
            base.CurrentTableName = ProductInfoTable.TableName;
            base.PrimaryKey = "ID";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public ProductInfoManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public ProductInfoManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public ProductInfoManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public ProductInfoManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public ProductInfoManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="productInfoEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(ProductInfoEntity productInfoEntity)
        {
            return this.AddEntity(productInfoEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="productInfoEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(ProductInfoEntity productInfoEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(productInfoEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="productInfoEntity">实体</param>
        /// <param name="statusMessage">状态消息</param>
        public int Update(ProductInfoEntity productInfoEntity,out string statusMessage)
        {
            var returnValue = 0;
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(ProductInfoTable.FieldProductName, productInfoEntity.ProductName),
                new KeyValuePair<string, object>(ProductInfoTable.FieldProductCode, productInfoEntity.ProductCode),
                new KeyValuePair<string, object>(ProductInfoTable.FieldDeleteMark, 0)
            };
            // 检查用户名是否重复
            if (this.Exists(parameters, productInfoEntity.Id))
            {
                // 名称或编号已重复
                statusMessage = "名称或编号重复！";
            }
            else
            {
                returnValue = this.UpdateEntity(productInfoEntity);
                statusMessage = returnValue == 0 ? "更新失败！" : "更新成功！";
            }

            return returnValue;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public ProductInfoEntity GetEntity(string id)
        {
            return BaseEntity.Create<ProductInfoEntity>(this.GetDT(new KeyValuePair<string, object>(ProductInfoTable.FieldId, id)));          
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="productInfoEntity">实体</param>
        public string AddEntity(ProductInfoEntity productInfoEntity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            if (productInfoEntity.Id != null)
            {
                sequence = productInfoEntity.Id;
            }

            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, ProductInfoTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(productInfoEntity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    productInfoEntity.Id = sequence;
                }

                sqlBuilder.SetValue(ProductInfoTable.FieldId, productInfoEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(ProductInfoTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(ProductInfoTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(productInfoEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            productInfoEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(ProductInfoTable.FieldId, productInfoEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, productInfoEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProductInfoTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(ProductInfoTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(ProductInfoTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProductInfoTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(ProductInfoTable.FieldModifiedUserId,UserInfo.Id);
            }
            sqlBuilder.SetDBNow(ProductInfoTable.FieldModifiedOn);
            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString(CultureInfo.InvariantCulture);
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
        /// <param name="productInfoEntity">实体</param>
        public int UpdateEntity(ProductInfoEntity productInfoEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, productInfoEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(ProductInfoTable.FieldModifiedBy, UserInfo.RealName);
                sqlBuilder.SetValue(ProductInfoTable.FieldModifiedUserId, UserInfo.Id);
            }
            sqlBuilder.SetDBNow(ProductInfoTable.FieldModifiedOn);
            sqlBuilder.SetWhere(ProductInfoTable.FieldId, productInfoEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="productInfoEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, ProductInfoEntity productInfoEntity)
        {
            sqlBuilder.SetValue(ProductInfoTable.FieldProductCode, productInfoEntity.ProductCode);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductName, productInfoEntity.ProductName);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductModel, productInfoEntity.ProductModel);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductStandard, productInfoEntity.ProductStandard);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductCategory, productInfoEntity.ProductCategory);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductUnit, productInfoEntity.ProductUnit);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductDescription, productInfoEntity.ProductDescription);
            sqlBuilder.SetValue(ProductInfoTable.FieldMiddleRate, productInfoEntity.MiddleRate);
            sqlBuilder.SetValue(ProductInfoTable.FieldReferenceCoefficient, productInfoEntity.ReferenceCoefficient);
            sqlBuilder.SetValue(ProductInfoTable.FieldProductPrice, productInfoEntity.ProductPrice);
            sqlBuilder.SetValue(ProductInfoTable.FieldWholesalePrice, productInfoEntity.WholesalePrice);
            sqlBuilder.SetValue(ProductInfoTable.FieldPromotionPrice, productInfoEntity.PromotionPrice);
            sqlBuilder.SetValue(ProductInfoTable.FieldInternalPrice, productInfoEntity.InternalPrice);
            sqlBuilder.SetValue(ProductInfoTable.FieldSpecialPrice, productInfoEntity.SpecialPrice);
            sqlBuilder.SetValue(ProductInfoTable.FieldEnabled, productInfoEntity.Enabled);
            sqlBuilder.SetValue(ProductInfoTable.FieldDescription, productInfoEntity.Description);
            sqlBuilder.SetValue(ProductInfoTable.FieldDeleteMark, productInfoEntity.DeleteMark);
        }

        /// <summary>
        /// 物理删除产品信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int DeleteProduct(string id)
        {
            return this.Delete(id);
        }

        /// <summary>
        /// 逻辑删除产品信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int SetPrductDeleted(string id)
        {
            return this.SetProperty(id, ProductInfoTable.FieldDeleteMark, 1);
        }

        /// <summary>
        /// 作废指定产品
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int SetProductDisannul(string id)
        {
            return this.SetProperty(id, ProductInfoTable.FieldEnabled, 1);
        }
    }
}
