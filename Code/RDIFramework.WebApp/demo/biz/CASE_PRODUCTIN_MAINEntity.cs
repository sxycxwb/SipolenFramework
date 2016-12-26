using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.WebApp
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CASE_PRODUCTIN_MAINEntity
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
    public partial class CASE_PRODUCTIN_MAINEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 入库单编码
        /// </summary>
        public string CODE { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? INDATE { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public string INTYPE { get; set; }

        /// <summary>
        /// 库房
        /// </summary>
        public string DEPOT { get; set; }

        /// <summary>
        /// 保管员
        /// </summary>
        public string CUSTODIAN { get; set; }

        /// <summary>
        /// 供货商名称
        /// </summary>
        public string SUPPLIERNAME { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DELETEMARK { get; set; }

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
        public CASE_PRODUCTIN_MAINEntity()
        {
            CREATEON = DateTime.Now;
            DELETEMARK = 0;
            CODE = BusinessLogic.NewGuid();
            ID = BusinessLogic.NewGuid();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public CASE_PRODUCTIN_MAINEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public CASE_PRODUCTIN_MAINEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public CASE_PRODUCTIN_MAINEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public CASE_PRODUCTIN_MAINEntity GetSingle(DataTable dataTable)
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
        public List<CASE_PRODUCTIN_MAINEntity> GetList(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select new CASE_PRODUCTIN_MAINEntity().GetFrom(dataRow)).ToList();
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public CASE_PRODUCTIN_MAINEntity GetFrom(DataRow dataRow)
        {
            this.ID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldID]);
            this.CODE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldCODE]);
            this.INDATE = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTIN_MAINTable.FieldINDATE]);
            this.INTYPE = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldINTYPE]);
            this.DEPOT = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldDEPOT]);
            this.CUSTODIAN = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldCUSTODIAN]);
            this.SUPPLIERNAME = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldSUPPLIERNAME]);
            this.DESCRIPTION = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldDESCRIPTION]);
            this.DELETEMARK = BusinessLogic.ConvertToNullableInt(dataRow[CASE_PRODUCTIN_MAINTable.FieldDELETEMARK]);
            this.CREATEON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTIN_MAINTable.FieldCREATEON]);
            this.CREATEUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldCREATEUSERID]);
            this.CREATEBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldCREATEBY]);
            this.MODIFIEDON = BusinessLogic.ConvertToNullableDateTime(dataRow[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDON]);
            this.MODIFIEDUSERID = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDUSERID]);
            this.MODIFIEDBY = BusinessLogic.ConvertToString(dataRow[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDBY]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public CASE_PRODUCTIN_MAINEntity GetFrom(IDataReader dataReader)
        {
            this.ID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldID]);
            this.CODE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldCODE]);
            this.INDATE = BusinessLogic.ConvertToNullableDateTime(dataReader[CASE_PRODUCTIN_MAINTable.FieldINDATE]);
            this.INTYPE = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldINTYPE]);
            this.DEPOT = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldDEPOT]);
            this.CUSTODIAN = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldCUSTODIAN]);
            this.SUPPLIERNAME = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldSUPPLIERNAME]);
            this.DESCRIPTION = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldDESCRIPTION]);
            this.DELETEMARK = BusinessLogic.ConvertToNullableInt(dataReader[CASE_PRODUCTIN_MAINTable.FieldDELETEMARK]);
            this.CREATEON = BusinessLogic.ConvertToNullableDateTime(dataReader[CASE_PRODUCTIN_MAINTable.FieldCREATEON]);
            this.CREATEUSERID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldCREATEUSERID]);
            this.CREATEBY = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldCREATEBY]);
            this.MODIFIEDON = BusinessLogic.ConvertToNullableDateTime(dataReader[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDON]);
            this.MODIFIEDUSERID = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDUSERID]);
            this.MODIFIEDBY = BusinessLogic.ConvertToString(dataReader[CASE_PRODUCTIN_MAINTable.FieldMODIFIEDBY]);
            return this;
        }
    }
}