using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.WebApp
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTIN_DETAILEntity
    /// 
    /// 
    /// 修改纪录
    /// 
    /// 2013-12-18 版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2013-12-18</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class CASE_PRODUCTIN_DETAILEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 入库单主表主键
        /// </summary>
        public string CASE_PRODUCTIN_MAIN_ID { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string SEQUENCE { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string CATEGORY { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string CODE { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string FULLNAME { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string MODEL { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string FORMAT { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal? AMOUNT { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? UNITPRICE { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal? TOTALSUM { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DELETEMARK { get; set; }

        /// <summary>
        /// 入库状态
        /// </summary>
        public string STATE { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string PEOPLE { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CREATEON { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CREATEUSERID { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CREATEBY { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MODIFIEDON { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string MODIFIEDUSERID { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string MODIFIEDBY { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CASE_PRODUCTIN_DETAILEntity()
        {
            CREATEON = DateTime.Now;
            DELETEMARK = 0;
            TOTALSUM = 0;
            AMOUNT = 0;
            CODE = BusinessLogic.NewGuid();
            ID = BusinessLogic.NewGuid();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public CASE_PRODUCTIN_DETAILEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public CASE_PRODUCTIN_DETAILEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public CASE_PRODUCTIN_DETAILEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public CASE_PRODUCTIN_DETAILEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<CASE_PRODUCTIN_DETAILEntity> GetList(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select new CASE_PRODUCTIN_DETAILEntity().GetFrom(dataRow)).ToList();
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public CASE_PRODUCTIN_DETAILEntity GetFrom(DataRow dataRow)
        {
            this.ID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldID]);
            this.CASE_PRODUCTIN_MAIN_ID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCASE_PRODUCTIN_MAIN_ID]);
            this.SEQUENCE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldSEQUENCE]);
            this.CATEGORY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCATEGORY]);
            this.CODE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCODE]);
            this.FULLNAME = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldFULLNAME]);
            this.MODEL = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldMODEL]);
            this.FORMAT = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldFORMAT]);
            this.UNIT = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldUNIT]);
            this.AMOUNT = BusinessLogic.ConvertToNullableDecimal(dataRow[CASE_PRODUCTIN_DETAILTable.FieldAMOUNT]);
            this.UNITPRICE = BusinessLogic.ConvertToNullableDecimal(dataRow[CASE_PRODUCTIN_DETAILTable.FieldUNITPRICE]);
            this.TOTALSUM = BusinessLogic.ConvertToNullableDecimal(dataRow[CASE_PRODUCTIN_DETAILTable.FieldTOTALSUM]);
            this.DELETEMARK = BusinessLogic.ConvertToNullableInt(dataRow[CASE_PRODUCTIN_DETAILTable.FieldDELETEMARK]);
            this.STATE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldSTATE]);
            this.PEOPLE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldPEOPLE]);
            this.CREATEON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCREATEON]);
            this.CREATEUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCREATEUSERID]);
            this.CREATEBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldCREATEBY]);
            this.MODIFIEDON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDON]);
            this.MODIFIEDUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDUSERID]);
            this.MODIFIEDBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDBY]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public CASE_PRODUCTIN_DETAILEntity GetFrom(IDataReader dataReader)
        {
            this.ID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldID]);
            this.CASE_PRODUCTIN_MAIN_ID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCASE_PRODUCTIN_MAIN_ID]);
            this.SEQUENCE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldSEQUENCE]);
            this.CATEGORY = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCATEGORY]);
            this.CODE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCODE]);
            this.FULLNAME = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldFULLNAME]);
            this.MODEL = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldMODEL]);
            this.FORMAT = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldFORMAT]);
            this.UNIT = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldUNIT]);
            this.AMOUNT = BusinessLogic.ConvertToNullableDecimal(dataReader[CASE_PRODUCTIN_DETAILTable.FieldAMOUNT]);
            this.UNITPRICE = BusinessLogic.ConvertToNullableDecimal(dataReader[CASE_PRODUCTIN_DETAILTable.FieldUNITPRICE]);
            this.TOTALSUM = BusinessLogic.ConvertToNullableDecimal(dataReader[CASE_PRODUCTIN_DETAILTable.FieldTOTALSUM]);
            this.DELETEMARK = BusinessLogic.ConvertToNullableInt(dataReader[CASE_PRODUCTIN_DETAILTable.FieldDELETEMARK]);
            this.STATE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldSTATE]);
            this.PEOPLE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldPEOPLE]);
            this.CREATEON = BusinessLogic.ConvertToNullableDateTime(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCREATEON]);
            this.CREATEUSERID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCREATEUSERID]);
            this.CREATEBY = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldCREATEBY]);
            this.MODIFIEDON = BusinessLogic.ConvertToNullableDateTime(dataReader[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDON]);
            this.MODIFIEDUSERID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDUSERID]);
            this.MODIFIEDBY = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_DETAILTable.FieldMODIFIEDBY]);
            return this;
        }
    }
}