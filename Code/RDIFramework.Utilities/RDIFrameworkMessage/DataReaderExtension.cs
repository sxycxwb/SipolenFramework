using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RDIFramework.Utilities
{
    public static class DataReaderExtension
    {
        // Methods
        public static List<T> ToList<T>(this IDataReader dataReader) where T : new()
        {
            List<T> list = new List<T>();
            if (dataReader != null)
            {
                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        list.Add(dataReader.ToObject<T>());
                    }
                }
            }
            return list;
        }

        public static T ToObject<T>(this IDataReader dr) where T : new()
        {
            dynamic obj2 = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
            return (T)obj2.GetFrom(dr);
        }
    }

 

}
