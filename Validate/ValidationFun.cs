namespace MyCompany.PeiXun.Tools
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ValidationFun
    {
        private static Regex RegCHZN = new Regex("[一-龥]");

        public static string GetMatchValue(string input, string pattern)
        {
            if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            {
                return Regex.Match(input, pattern, RegexOptions.IgnoreCase).Value;
            }
            return string.Empty;
        }

        public static string GetMatchValue(string input, string pattern, string resultPattern)
        {
            return GetMatchValue(input, pattern, resultPattern, RegexOptions.IgnoreCase);
        }

        public static string GetMatchValue(string input, string pattern, string resultPattern, RegexOptions options)
        {
            if (Regex.IsMatch(input, pattern, options))
            {
                return Regex.Match(input, pattern, options).Result(resultPattern);
            }
            return string.Empty;
        }

        public static bool IsDate(ref string date)
        {
            if (IsNullOrEmpty((string) date))
            {
                return true;
            }
            date = date.Trim();
            date = date.Replace(@"\", "-");
            date = date.Replace("/", "-");
            if (date.IndexOf("今") != -1)
            {
                date = DateTime.Now.ToString();
            }
            try
            {
                date = Convert.ToDateTime((string) date).ToString("d");
                return true;
            }
            catch
            {
                if (IsInt(date))
                {
                    string str;
                    string str2;
                    if (date.Length == 8)
                    {
                        str = date.Substring(0, 4);
                        str2 = date.Substring(4, 2);
                        string str3 = date.Substring(6, 2);
                        if ((Convert.ToInt32(str) < 0x76c) || (Convert.ToInt32(str) > 0x834))
                        {
                            return false;
                        }
                        if ((Convert.ToInt32(str2) > 12) || (Convert.ToInt32(str3) > 0x1f))
                        {
                            return false;
                        }
                        date = Convert.ToDateTime(str + "-" + str2 + "-" + str3).ToString("d");
                        return true;
                    }
                    if (date.Length == 6)
                    {
                        str = date.Substring(0, 4);
                        str2 = date.Substring(4, 2);
                        if ((Convert.ToInt32(str) < 0x76c) || (Convert.ToInt32(str) > 0x834))
                        {
                            return false;
                        }
                        if (Convert.ToInt32(str2) > 12)
                        {
                            return false;
                        }
                        date = Convert.ToDateTime(str + "-" + str2).ToString("d");
                        return true;
                    }
                    if (date.Length == 5)
                    {
                        str = date.Substring(0, 4);
                        str2 = date.Substring(4, 1);
                        if ((Convert.ToInt32(str) < 0x76c) || (Convert.ToInt32(str) > 0x834))
                        {
                            return false;
                        }
                        date = str + "-" + str2;
                        return true;
                    }
                    if (date.Length == 4)
                    {
                        str = date.Substring(0, 4);
                        if ((Convert.ToInt32(str) < 0x76c) || (Convert.ToInt32(str) > 0x834))
                        {
                            return false;
                        }
                        date = Convert.ToDateTime(str).ToString("d");
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool IsEmail(string email)
        {
            if (IsNullOrEmpty(email))
            {
                return true;
            }
            email = email.Trim();
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            return IsMatch(email, pattern);
        }

        public static bool IsHasCHZN(string inputData)
        {
            return RegCHZN.Match(inputData).Success;
        }

        public static bool IsIdCard(string idCard)
        {
            if (IsNullOrEmpty(idCard))
            {
                return true;
            }
            idCard = idCard.Trim();
            StringBuilder builder = new StringBuilder();
            builder.Append("^(11|12|13|14|15|21|22|23|31|32|33|34|35|36|37|41|42|43|44|45|46|");
            builder.Append("50|51|52|53|54|61|62|63|64|65|71|81|82|91)");
            builder.Append(@"(\d{13}|\d{15}[\dx])$");
            return IsMatch(idCard, builder.ToString());
        }

        public static bool IsInt(string number)
        {
            if (IsNullOrEmpty(number))
            {
                return true;
            }
            number = number.Trim();
            string pattern = "^[1-9]+[0-9]*$";
            return IsMatch(number, pattern);
        }

        public static bool IsIP(string ip)
        {
            if (IsNullOrEmpty(ip))
            {
                return true;
            }
            ip = ip.Trim();
            string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
            return IsMatch(ip, pattern);
        }

        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }

        public static bool IsMobiletelePhone(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, "^13[0-9]{1}[0-9]{8}$|^15[9]{1}[0-9]{8}$|^18[9]{1}[0-9]{8}$");
        }

        public static bool IsNTS(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9\u4e00-\u9fa5]+$");
        }

        public static bool IsNullOrEmpty<T>(T data)
        {
            if (data == null)
            {
                return true;
            }
            if (data.GetType() == typeof(string))
            {
                return string.IsNullOrEmpty(data.ToString().Trim());
            }
            return (data.GetType() == typeof(DBNull));
        }

        public static bool IsNullOrEmpty(object data)
        {
            return IsNullOrEmpty<object>(data);
        }

        public static bool IsNullOrEmpty(string text)
        {
            return ((text == null) || string.IsNullOrEmpty(text.ToString().Trim()));
        }

        public static bool IsNumber(string number)
        {
            if (IsNullOrEmpty(number))
            {
                return true;
            }
            number = number.Trim();
            string pattern = "^[1-9]+[0-9]*[.]?[0-9]*$";
            return IsMatch(number, pattern);
        }

        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)");
        }

        public static bool IsPostCode(string postCode)
        {
            return Regex.IsMatch(postCode, @"^\d{6}$");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"20\d{2}\-[0-1]{1,2}\-[0-3]?[0-9]?(\s*((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?))?");
        }

        public static bool IsURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            return Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }

        public static bool IsValidInput(string str)
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(str))
            {
                string strContent = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\"";
                string[] strArray = StringFun.SplitString(strContent, ",");
                string str3 = str;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str3.IndexOf(strArray[i]) >= 0)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public static bool IsValidInput(ref string input)
        {
            try
            {
                if (!IsNullOrEmpty((string) input))
                {
                    input = input.Replace("'", "''").Trim();
                    string[] strArray = "and |or |exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ".Split(new char[] { '|' });
                    foreach (string str2 in strArray)
                    {
                        if (input.ToLower().IndexOf(str2) != -1)
                        {
                            input = string.Empty;
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

