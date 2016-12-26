using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RDIFramework.BizLogic
{

    public partial class PiUserManager : DbCommonManager
    {
        #region private bool CheckIPAddress(string ipAddress, string userId) 检查用户IP地址
        /// <summary>
        /// 检查用户IP地址
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <returns>是否符合限制</returns>
        private bool CheckIPAddress(string ipAddress, string userId)
        {
            bool returnValue = false;
            
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, userId),
                new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, "IPAddress"),
                new KeyValuePair<string, object>(CiParameterTable.FieldEnabled, 1)
            };

            DataTable dt = DbCommonLibary.GetDT(this.DBProvider, CiParameterTable.TableName, parameters);
            if (dt.Rows.Count > 0)
            {
                string parameterCode = string.Empty;
                string parameterCotent = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    parameterCode = dt.Rows[i][CiParameterTable.FieldParameterCode].ToString();
                    parameterCotent = dt.Rows[i][CiParameterTable.FieldParameterContent].ToString();
                    switch (parameterCode)
                    {
                        // 匹配单个IP
                        case "Single":
                            returnValue = CheckSingleIPAddress(ipAddress, parameterCotent);
                            break;
                        // 匹配ip地址段
                        case "Range":
                            returnValue = CheckIPAddressWithRange(ipAddress, parameterCotent);
                            break;
                        // 匹配带掩码的地址段
                        case "Mask":
                            returnValue = CheckIPAddressWithMask(ipAddress, parameterCotent);
                            break;
                    }
                    if (returnValue) break;
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 检查是否匹配单个IP
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="sourceIp"></param>
        /// <returns></returns>
        private bool CheckSingleIPAddress(string ipAddress, string sourceIp)
        {
            return ipAddress.Equals(sourceIp);
        }
        /// <summary>
        /// 检查是否匹配地址段
        /// </summary>
        /// <param name="ipAddress">192.168.0.8</param>
        /// <param name="ipRange">192.168.0.1-192.168.0.10</param>
        /// <returns></returns>
        private bool CheckIPAddressWithRange(string ipAddress, string ipRange)
        {
            //先判断符合192.168.0.1-192.168.0.10 的正则表达式

            //在判断ipAddress是否有效
            string startIp = ipRange.Split('-')[0];
            string endIp = ipRange.Split('-')[1];
            //如果大于等于 startip 或者 小于等于endip
            return CompareIp(ipAddress, startIp) == 2 && CompareIp(ipAddress, endIp) == 0 || CompareIp(ipAddress, startIp) == 1 || CompareIp(ipAddress, endIp) == 1;
        }
        /// <summary>
        /// 比较两个IP地址，比较前可以先判断是否是IP地址
        /// </summary>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <returns>1：相等;  0：ip1小于ip2 ; 2：ip1大于ip2；-1 不符合ip正则表达式 </returns>
        public int CompareIp(string ip1, string ip2)
        {
            //if (!IsIP(ip1) || !IsIP(ip2))
            //{
            //    return -1;

            //}

            String[] arr1 = ip1.Split('.');
            String[] arr2 = ip2.Split('.');
            for (int i = 0; i < arr1.Length; i++)
            {
                int a1 = int.Parse(arr1[i]);
                int a2 = int.Parse(arr2[i]);
                if (a1 > a2)
                {
                    return 2;
                }
                else if (a1 < a2)
                {
                    return 0;
                }
            }
            return 1;

        }
        /// <summary>
        /// 检查是否匹配带通配符的IP地址
        /// </summary>
        /// <param name="ipAddress">192.168.1.1</param>
        /// <param name="ipWithMask">192.168.1.*</param>
        /// <returns></returns>
        private bool CheckIPAddressWithMask(string ipAddress, string ipWithMask)
        {
            //先判断是否符合192.168.1.*

            //然后判断
            string[] arr1 = ipAddress.Split('.');
            string[] arr2 = ipWithMask.Split('.');
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!(arr2[i].Equals("*") || arr1[i].Equals(arr2[i])))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        private bool CheckIPAddress(string[] ipAddress, string userId)
        {
            return ipAddress.Any(t => this.CheckIPAddress(t, userId));
        }

        #region private bool CheckMacAddress(string macAddress, string userId) 检查用户的网卡Mac地址
        /// <summary>
        /// 检查用户的网卡Mac地址
        /// </summary>
        /// <param name="macAddress">Mac地址</param>
        /// <param name="userId">用户主键</param>
        /// <returns>是否符合限制</returns>
        private bool CheckMacAddress(string macAddress, string userId)
        {
            bool returnValue = false;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, userId),
                new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, "MacAddress"),
                new KeyValuePair<string, object>(CiParameterTable.FieldEnabled, 1)
            };

            DataTable dt = DbCommonLibary.GetDT(this.DBProvider, CiParameterTable.TableName, parameters);
            if (dt.Rows.Count > 0)
            {
                string parameterCode = string.Empty;
                string parameterCotent = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    parameterCode = dt.Rows[i][CiParameterTable.FieldParameterCode].ToString();
                    parameterCotent = dt.Rows[i][CiParameterTable.FieldParameterContent].ToString();
                    returnValue = (macAddress.ToLower()).Equals(parameterCotent.ToLower());
                    if (returnValue) break;
                }
            }
            return returnValue;
        }
        #endregion

        private bool CheckMacAddress(string[] macAddress, string userId)
        {
            return macAddress.Any(t => this.CheckMacAddress(t, userId));
        }
    }
}
