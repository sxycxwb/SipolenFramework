//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , EricHuSoft , Ltd. 
//-----------------------------------------------------------------

using System.Data;

namespace UMPlatForm.Utilities
{
    /// <summary>
    /// IDbProviderExpand
    /// 数据库访问扩展接口
    /// 
    /// 修改纪录
    /// 
    ///		2010.7.13 版本：1.0 EricHu 数据库访问扩展接口。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.07.13</date>
    /// </author> 
    /// </summary>
    public interface IDbProviderExpand
    {
        /// <summary>
        /// 利用Net SqlBulkCopy 批量导入数据库,速度超快
        /// </summary>
        /// <param name="dataTable">源内存数据表</param>
        void SqlBulkCopyData(DataTable dataTable);

        /// <summary>
        /// 得到分页数据(用存储过程实现)
        /// </summary>
        /// <param name="connection">存储过程的相关参数</param>
        /// <returns>分页后的数据（DataTable）</returns>
        DataTable GetPageList(IDbDataParameter[] dbParameters);
    }
}
