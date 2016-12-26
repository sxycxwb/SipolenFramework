//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , EricHu. 
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.BizLogic
{   
    public partial class DbCommonManager
    {
        public virtual int GetMax(string maxField)
        {
            return DbCommonLibary.GetMax(DBProvider, this.CurrentTableName, maxField);
        }

        public virtual int GetMax(string maxField,string whereConditional)
        {
            return DbCommonLibary.GetMax(DBProvider, this.CurrentTableName, maxField, whereConditional);
        }

        public virtual int GetMax(string maxField, params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = parameters.ToList();
            return DbCommonLibary.GetMax(DBProvider, this.CurrentTableName, maxField, parametersList);
        }     
    }
}