using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace RDIFramework.WebCommon.DbHelper
{
    interface IDataAccess
    {
        DataTable ExecuteDataTable(string commandText);
        DataTable ExecuteDataTable(string commandText, params object[] paras);

        DataSet ExecuteDataSet(string commandText);
        DataSet ExecuteDataSet(string commandText, params object[] paras);

        int ExecuteNonQuery(string commandText);
        int ExecuteNonQuery(string commandText, params object[] paras);

        object ExecuteScalar(string commandText);
        object ExecuteScalar(string commandText, params object[] paras);

        DbDataReader ExecuteReader(string commandText);
        DbDataReader ExecuteReader(string commandText, params object[] paras);


        DataRow ExecuteDataRow(string commandText);
        DataRow ExecuteDataRow(string commandText, params object[] paras);


    }
}
