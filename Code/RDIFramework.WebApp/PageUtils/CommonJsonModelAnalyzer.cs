using System;
using System.Collections.Generic;
using System.Text;

namespace RDIFramework.WebApp
{
    public class CommonJsonModelAnalyzer
    {
        protected string _GetKey(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
                return rawjson;
            rawjson = rawjson.Trim();
            string[] jsons = rawjson.Split(new char[] { ':' });
            return jsons.Length < 2 ? rawjson : jsons[0].Replace("\"", "").Trim();
        }

        protected string _GetValue(string rawjson)
        {
            if (string.IsNullOrEmpty(rawjson))
                return rawjson;
            rawjson = rawjson.Trim();
            string[] jsons = rawjson.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (jsons.Length >= 2)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 1; i < jsons.Length; i++)
                {
                    builder.Append(jsons[i]);
                    builder.Append(":");
                }
                if (builder.Length > 0)
                    builder.Remove(builder.Length - 1, 1);
                string value = builder.ToString();
                if (value.StartsWith("\""))
                    value = value.Substring(1);
                if (value.EndsWith("\""))
                    value = value.Substring(0, value.Length - 1);
                return value;
            }
            return rawjson;
        }

        protected List<string> _GetCollection(string rawjson)
        {
            //[{},{}]
            var list = new List<string>();
            if (string.IsNullOrEmpty(rawjson))
                return list;
            rawjson = rawjson.Trim();
            var builder = new StringBuilder();
            int nestlevel = -1;
            int mnestlevel = -1;
            for (var i = 0; i < rawjson.Length; i++)
            {
                if (i == 0)
                    continue;
                else if (i == rawjson.Length - 1)
                    continue;
                var jsonchar = rawjson[i];
                if (jsonchar == '{')
                {
                    nestlevel++;
                }
                if (jsonchar == '}')
                {
                    nestlevel--;
                }
                if (jsonchar == '[')
                {
                    mnestlevel++;
                }
                if (jsonchar == ']')
                {
                    mnestlevel--;
                }
                if (jsonchar == ',' && nestlevel == -1 && mnestlevel == -1)
                {
                    list.Add(builder.ToString());
                    builder = new StringBuilder();
                }
                else
                {
                    builder.Append(jsonchar);
                }
            }
            if (builder.Length > 0)
                list.Add(builder.ToString());
            return list;
        }

    }
}