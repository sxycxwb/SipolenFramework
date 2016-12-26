using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDIFramework.BizLogic
{
    public interface IDataRow
    {
        object this[string name] { get; }
        object this[int i] { get; }

        bool ContainsColumn(string columnName);
    }
}
