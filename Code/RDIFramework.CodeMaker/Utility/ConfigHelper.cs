using System;
using System.Configuration;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// web.config������
	/// </summary>
	public sealed class ConfigHelper
	{

		#region �õ�AppSettings�е������ַ�����Ϣ
		/// <summary>
		/// �õ�AppSettings�е������ַ�����Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            return ConfigurationManager.AppSettings[key];
		}
		#endregion

		#region �õ�AppSettings�е�����bool��Ϣ
		/// <summary>
		/// �õ�AppSettings�е�����bool��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
		    if (null == cfgVal || string.Empty == cfgVal) return result;
		    try
		    {
		        result = bool.Parse(cfgVal);
		    }
		    catch(FormatException)
		    {
		        // Ignore format exceptions.
		    }

		    return result;
		}
		#endregion

		#region �õ�AppSettings�е�����decimal��Ϣ
		/// <summary>
		/// �õ�AppSettings�е�����decimal��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
		    if (null == cfgVal || string.Empty == cfgVal) return result;
		    try
		    {
		        result = decimal.Parse(cfgVal);
		    }
		    catch(FormatException)
		    {
		        // Ignore format exceptions.
		    }

		    return result;
		}
		#endregion

		#region �õ�AppSettings�е�����int��Ϣ
		/// <summary>
		/// �õ�AppSettings�е�����int��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
		    if (null == cfgVal || string.Empty == cfgVal) return result;
		    try
		    {
		        result = int.Parse(cfgVal);
		    }
		    catch(FormatException)
		    {
		        // Ignore format exceptions.
		    }

		    return result;
		}
		#endregion

	}
}
