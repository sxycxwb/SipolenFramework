using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    public interface IBaseEntity
    {
        BaseEntity GetFrom(DataRow dr);

        BaseEntity GetFrom(IDataReader dataReader);

        BaseEntity GetSingle(DataTable dt);
    }
}
