using System;

namespace RDIFramework.Utilities
{
    public partial class BusinessLogic
    {
        #region 类型转换
        /// <summary>
        /// 将指定对象的值转换为其等效的整型表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的整型表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static int? ConvertToNullableInt(Object targetValue)
        {
            int? returnValue = null;
            if (targetValue == null || targetValue == DBNull.Value)
            {
                return returnValue;
            }

            int result = 0;
            int.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的 32 位有符号整数。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的32 位有符号整数表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static Int32? ConvertToNullableInt32(Object targetValue)
        {
            Int32? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            Int32 result = 0;
            Int32.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的 64 位有符号整数。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的64 位有符号整数表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static Int64? ConvertToNullableInt64(Object targetValue)
        {
            Int64? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            Int64 result = 0;
            Int64.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的64位有符号整数。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的64 位有符号整数表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static long? ConvertToNullableLong(Object targetValue)
        {
            long? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            long result = 0;
            long.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的等效双精度浮点数。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的等效双精度浮点数表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static Double? ConvertToNullableDouble(Object targetValue)
        {
            Double? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            Double result = 0;
            Double.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的等效单精度浮点数字。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的等效单精度浮点数字表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static float? ConvertToNullableFloat(Object targetValue)
        {
            float? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            float result = 0;
            float.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的等效 Decimal 表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的等效 Decimal 表示形式，如果 targetValue 为 null，则为 null。</returns>
        public static decimal? ConvertToNullableDecimal(Object targetValue)
        {
            decimal? returnValue = null;
            if (targetValue == DBNull.Value)
            {
                return returnValue;
            }

            decimal result = 0;
            decimal.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为 DateTime 值。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的值的日期和时间等效项，如果 targetValue 为 null，则返回null。</returns>
        public static DateTime? ConvertToNullableDateTime(Object targetValue)
        {
            DateTime? returnValue = null;

            if (DateTimeHelper.IsDate(targetValue.ToString()))
            {
                returnValue = Convert.ToDateTime(targetValue.ToString());
            }

            return returnValue;
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的字符串表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <param name="isNullReturn">如果为空默认返回null，可以自行指定返回的值</param>
        /// <returns>targetValue 的字符串表示形式，如果 targetValue 为 null，则返回参数isNullReturn指定的值null。</returns>
        public static string ConvertToString(Object targetValue,string isNullReturn = null)
        {
            return targetValue != DBNull.Value ? Convert.ToString(targetValue) : isNullReturn;
        }

        /// <summary>
        /// 将指定对象（整型）的值转换为其等效的Boolean表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的等效 Boolean 表示形式，如果 targetValue 为 null，则为 false。</returns>
        public static Boolean ConvertIntToBoolean(Object targetValue)
        {
            return targetValue != null && targetValue != DBNull.Value && (targetValue.ToString().Equals("1") || targetValue.ToString().Equals(true.ToString()));
        }

        /// <summary>
        /// 将指定对象的值转换为其等效的Boolean表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的等效 Boolean 表示形式，如果 targetValue 为 null，则为 false。</returns>
        public static Boolean ConvertToBoolean(Object targetValue)
        {
            return targetValue != null && targetValue != DBNull.Value && (targetValue.ToString().Equals(true.ToString()));
        }

        
        /// <summary>
        /// 将指定对象的值转换为 DateTime 值字符串表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的值的日期和时间等效项的字符串表示形式，如果 targetValue 为 null，则返回null。</returns>
        public static string ConvertToDateToString(Object targetValue)
        {
            if (DateTimeHelper.IsDateTime(targetValue.ToString()))
            {
                return DateTime.Parse(targetValue.ToString()).ToString(SystemInfo.DateFormat);
            }

            return null;
        }

        /// <summary>
        /// 将指定对象的值转换为 Byte表示形式。
        /// </summary>
        /// <param name="targetValue">一个对象，用于提供要转换的值，或 null。</param>
        /// <returns>targetValue 的值的Byte表示形式，如果 targetValue 为 null，则返回null。</returns>
        public static byte[] ConvertToByte(Object targetValue)
        {
            return targetValue != DBNull.Value ? (byte[])targetValue : null;
        }

        public static byte ConvertToByteInt(object targetValue)
        {
            byte num = 0;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            byte result = 0;
            byte.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static DateTime ConvertToDateTime(object targetValue)
        {
            DateTime minValue = DateTime.MinValue;
            if (targetValue != DBNull.Value)
            {
                minValue = Convert.ToDateTime(targetValue.ToString());
            }
            return minValue;
        }

        public static decimal ConvertToDecimal(object targetValue)
        {
            decimal num = 0M;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            decimal result = 0M;
            decimal.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static double ConvertToDouble(object targetValue)
        {
            double num = 0.0;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            double result = 0.0;
            double.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static float ConvertToFloat(object targetValue)
        {
            float num = 0f;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            float result = 0f;
            float.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static int ConvertToInt(object targetValue)
        {
            int num = 0;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            int result = 0;
            int.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static int ConvertToInt32(object targetValue)
        {
            int num = 0;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            int result = 0;
            int.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static long ConvertToInt64(object targetValue)
        {
            long num = 0L;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            long result = 0L;
            long.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static long ConvertToLong(object targetValue)
        {
            long num = 0L;
            if (targetValue == DBNull.Value)
            {
                return num;
            }
            long result = 0L;
            long.TryParse(targetValue.ToString(), out result);
            return result;
        }

        public static byte? ConvertToNullableByteInt(object targetValue)
        {
            byte? nullable = null;
            if (targetValue != DBNull.Value)
            {
                byte result = 0;
                byte.TryParse(targetValue.ToString(), out result);
                nullable = new byte?(result);
            }
            return nullable;
        }
        #endregion
    }
}
