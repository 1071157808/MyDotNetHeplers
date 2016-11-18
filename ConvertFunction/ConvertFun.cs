namespace MyCompany.PeiXun.Tools
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public sealed class ConvertFun
    {
        public static DateTime BigIntToDateTime(long inputLong)
        {
            DateTime date = DateTime.Now.Date;
            DateTime.TryParse("1970-01-01", out date);
            double num = ((double)inputLong) / 86400.0;
            return date.AddDays(num);
        }

        public static int BytesToInt32(byte[] data)
        {
            if (data.Length < 4)
            {
                return 0;
            }
            int num = 0;
            if (data.Length >= 4)
            {
                byte[] dst = new byte[4];
                Buffer.BlockCopy(data, 0, dst, 0, 4);
                num = BitConverter.ToInt32(dst, 0);
            }
            return num;
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        public static string ConvertBase(string value, int from, int to)
        {
            try
            {
                string str = Convert.ToString(Convert.ToInt32(value, from), to);
                if (to == 2)
                {
                    switch (str.Length)
                    {
                        case 3:
                            str = "00000" + str;
                            break;

                        case 4:
                            str = "0000" + str;
                            break;

                        case 5:
                            str = "000" + str;
                            break;

                        case 6:
                            str = "00" + str;
                            break;

                        case 7:
                            str = "0" + str;
                            break;
                    }
                }
                return str;
            }
            catch
            {
                return "0";
            }
        }

        public static T ConvertTo<T>(object data)
        {
            if (ValidationFun.IsNullOrEmpty(data))
            {
                return default(T);
            }
            try
            {
                if (data is T)
                {
                    return (T)data;
                }
                if (typeof(T).BaseType == typeof(Enum))
                {
                    return EnumFun.GetInstance<T>(data);
                }
                if (data is IConvertible)
                {
                    return (T)Convert.ChangeType(data, typeof(T));
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public static object ConvertTo(object data, Type targetType)
        {
            if (ValidationFun.IsNullOrEmpty(data))
            {
                return null;
            }
            try
            {
                if (data is IConvertible)
                {
                    return Convert.ChangeType(data, targetType);
                }
                return data;
            }
            catch
            {
                return null;
            }
        }

        public static string RepairZero(string text, int limitedLength)
        {
            string str = "";
            for (int i = 0; i < (limitedLength - text.Length); i++)
            {
                str = str + "0";
            }
            return (str + text);
        }

        public static int SafeInt32(object objNum)
        {
            if (objNum != null)
            {
                string number = objNum.ToString();
                if (ValidationFun.IsNumber(number))
                {
                    if (number.ToString().Length > 9)
                    {
                        return 0x7fffffff;
                    }
                    return int.Parse(number);
                }
            }
            return 0;
        }

        public static string StreamToString(Stream stream)
        {
            return StreamToString(stream, Encoding.Default);
        }

        public static string StreamToString(Stream stream, Encoding encoding)
        {
            string str;
            try
            {
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    str = reader.ReadToEnd();
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                stream.Close();
            }
            return str;
        }

        public static byte[] StringToBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        public static bool StrToBool(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                strValue = strValue.Trim();
                return (((string.Compare(strValue, "true", true) == 0) || (string.Compare(strValue, "yes", true) == 0)) || (string.Compare(strValue, "1", true) == 0));
            }
            return false;
        }

        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            DateTime time;
            if ((strValue == null) || (strValue.ToString().Length > 20))
            {
                return defValue;
            }
            if (!DateTime.TryParse(strValue.ToString(), out time))
            {
                time = defValue;
            }
            return time;
        }

        public static decimal StrToDecimal(object strValue)
        {
            if (!(Convert.IsDBNull(strValue) || object.Equals(strValue, null)))
            {
                return StrToDecimal(strValue.ToString());
            }
            return 0M;
        }

        public static decimal StrToDecimal(string strValue)
        {
            decimal num;
            decimal.TryParse(strValue, out num);
            return num;
        }

        public static decimal StrToDecimal(string input, decimal defaultValue)
        {
            decimal num;
            if (decimal.TryParse(input, out num))
            {
                return num;
            }
            return defaultValue;
        }

        public static double StrToDouble(object strValue)
        {
            if (!(Convert.IsDBNull(strValue) || object.Equals(strValue, null)))
            {
                return StrToDouble(strValue.ToString());
            }
            return 0.0;
        }

        public static double StrToDouble(string strValue)
        {
            double num;
            double.TryParse(strValue, out num);
            return num;
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            float num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString()))
            {
                num = Convert.ToSingle(strValue);
            }
            return num;
        }

        public static int StrToInt(object strValue)
        {
            int num = -1;
            if (((strValue == null) || (strValue.ToString() == string.Empty)) || (strValue.ToString().Length > 10))
            {
                return num;
            }
            string str = strValue.ToString();
            string number = str[0].ToString();
            if (((str.Length == 10) && ValidationFun.IsNumber(number)) && (int.Parse(number) > 1))
            {
                return num;
            }
            if (!((str.Length != 10) || ValidationFun.IsNumber(number)))
            {
                return num;
            }
            int num2 = num;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num2 = Convert.ToInt32(strValue);
            }
            return num2;
        }

        public static int StrToInt(object strValue, int defValue)
        {
            if (((strValue == null) || (strValue.ToString() == string.Empty)) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            string str = strValue.ToString();
            string number = str[0].ToString();
            if (((str.Length == 10) && ValidationFun.IsNumber(number)) && (int.Parse(number) > 1))
            {
                return defValue;
            }
            if (!((str.Length != 10) || ValidationFun.IsNumber(number)))
            {
                return defValue;
            }
            int num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num = Convert.ToInt32(strValue);
            }
            return num;
        }

        public static bool ToBoolean(object data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty(data))
                {
                    return false;
                }
                return Convert.ToBoolean(data);
            }
            catch
            {
                return false;
            }
        }

        public static bool ToBoolean<T>(T data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return false;
                }
                return Convert.ToBoolean(data);
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ToDateTime(object date)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty(date))
                {
                    return Convert.ToDateTime("1900-1-1");
                }
                return Convert.ToDateTime(date);
            }
            catch
            {
                return Convert.ToDateTime("1900-1-1");
            }
        }

        public static decimal ToDecimal<T>(T data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0M;
                }
                return Convert.ToDecimal(data);
            }
            catch
            {
                return 0M;
            }
        }

        public static decimal ToDecimal(object data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty(data))
                {
                    return 0M;
                }
                return Convert.ToDecimal(data);
            }
            catch
            {
                return 0M;
            }
        }

        public static decimal ToDecimal(object data, int decimals)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<object>(data))
                {
                    return 0M;
                }
                return Math.Round(Convert.ToDecimal(data), decimals);
            }
            catch
            {
                return 0M;
            }
        }

        public static decimal ToDecimal<T>(T data, int decimals)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0M;
                }
                return Math.Round(Convert.ToDecimal(data), decimals);
            }
            catch
            {
                return 0M;
            }
        }

        public static double ToDouble(object data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty(data))
                {
                    return 0.0;
                }
                return Convert.ToDouble(data);
            }
            catch
            {
                return 0.0;
            }
        }

        public static double ToDouble<T>(T data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0.0;
                }
                return Convert.ToDouble(data);
            }
            catch
            {
                return 0.0;
            }
        }

        public static double ToDouble(object data, int decimals)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<object>(data))
                {
                    return 0.0;
                }
                return Math.Round(Convert.ToDouble(data), decimals);
            }
            catch
            {
                return 0.0;
            }
        }

        public static double ToDouble<T>(T data, int decimals)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0.0;
                }
                return Math.Round(Convert.ToDouble(data), decimals);
            }
            catch
            {
                return 0.0;
            }
        }

        public static float ToFloat<T>(T data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0f;
                }
                return Convert.ToSingle(data);
            }
            catch
            {
                return 0f;
            }
        }

        public static float ToFloat(object data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<object>(data))
                {
                    return 0f;
                }
                return Convert.ToSingle(data);
            }
            catch
            {
                return 0f;
            }
        }

        public static Guid ToGuid(object data)
        {
            if (ValidationFun.IsNullOrEmpty(data))
            {
                return Guid.Empty;
            }
            try
            {
                return new Guid(data.ToString());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static int ToInt32<T>(T data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty<T>(data))
                {
                    return 0;
                }
                return Convert.ToInt32(data);
            }
            catch
            {
                return 0;
            }
        }

        public static int ToInt32(object data)
        {
            try
            {
                if (ValidationFun.IsNullOrEmpty(data))
                {
                    return 0;
                }
                return Convert.ToInt32(data);
            }
            catch
            {
                return 0;
            }
        }

        public static string ToString(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            return data.ToString();
        }
    }
}

