namespace MyCompany.PeiXun.Tools
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    [Serializable]
    public sealed class StringFun
    {
        private int _indentLevel = 0;
        private StringBuilder _str = new StringBuilder();

        public void Append(string text, params object[] parameters)
        {
            if (parameters.Length == 0)
            {
                this._str.Append(text);
            }
            else
            {
                this._str.AppendFormat(text, parameters);
            }
        }

        public static int Asc(string character)
        {
            if (character.Length != 1)
            {
                throw new Exception("Character is not valid.");
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(character)[0];
        }

        public static string Base64ToString(string source)
        {
            if (source != "")
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(source);
                    source = Encoding.Default.GetString(bytes);
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
                source = HttpUtility.UrlDecode(source);
            }
            return source;
        }

        public void Clear()
        {
            Clear(this._str);
        }

        public static void Clear(StringBuilder text)
        {
            text.Remove(0, text.Length);
        }

        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }

        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length *= -1;
                    if ((startIndex - length) < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex -= length;
                    }
                }
                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else if ((length >= 0) && ((length + startIndex) > 0))
            {
                length += startIndex;
                startIndex = 0;
            }
            else
            {
                return "";
            }
            if ((str.Length - startIndex) < length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }

        public static void DecomposeUrl(string url, out string hostUrl, out string queryString)
        {
            if (url.IndexOf("?") != -1)
            {
                hostUrl = url.Substring(0, url.IndexOf('?'));
                queryString = url.Substring(url.IndexOf('?') + 1);
            }
            else
            {
                hostUrl = url;
                queryString = string.Empty;
            }
        }

        public void DecreaseIndent()
        {
            this._indentLevel--;
        }

        public static ArrayList FilterRepeatArrayItem(ArrayList arr)
        {
            ArrayList list = new ArrayList();
            if (arr.Count > 0)
            {
                list.Add(arr[0]);
            }
            for (int i = 0; i < arr.Count; i++)
            {
                if (!list.Contains(arr[i]))
                {
                    list.Add(arr[i]);
                }
            }
            return list;
        }

        public static void FirstCharUpper(ref string text)
        {
            string str = text.Substring(0, 1).ToUpper();
            text = str + text.Substring(1, text.Length - 1);
        }

        public static string GetCommaString(params int[] intArray)
        {
            return GetCommaString(false, intArray);
        }

        public static string GetCommaString(params string[] stringArray)
        {
            return GetCommaString(false, stringArray);
        }

        public static string GetCommaString(bool isAddQuotationMarks, params int[] intArray)
        {
            StringBuilder text = new StringBuilder();
            foreach (int num in intArray)
            {
                if (isAddQuotationMarks)
                {
                    text.AppendFormat("'{0}',", num);
                }
                else
                {
                    text.AppendFormat("{0},", num);
                }
            }
            return RemoveLastComma(text);
        }

        public static string GetCommaString(bool isAddQuotationMarks, params string[] stringArray)
        {
            StringBuilder text = new StringBuilder();
            foreach (string str in stringArray)
            {
                if (isAddQuotationMarks)
                {
                    text.AppendFormat("'{0}',", str);
                }
                else
                {
                    text.AppendFormat("{0},", str);
                }
            }
            return RemoveLastComma(text);
        }

        public static string GetCommaString(DataTable table, string columnName)
        {
            return GetCommaString(table, columnName, false);
        }

        public static string GetCommaString(DataTable table, string columnName, bool isAddQuotationMarks)
        {
            StringBuilder text = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                if (isAddQuotationMarks)
                {
                    text.AppendFormat("'{0}',", row[columnName].ToString());
                }
                else
                {
                    text.AppendFormat("{0},", row[columnName].ToString());
                }
            }
            return RemoveLastComma(text);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetLastChar(string text)
        {
            if (ValidationFun.IsNullOrEmpty(text))
            {
                return "";
            }
            return text.Substring(text.Length - 1, 1);
        }

        public static string GetNumberByNowDate()
        {
            return DateTime.Now.ToString("g").Replace("-", "").Replace(":", "").Replace(" ", "");
        }

        public static string GetPattern(string text)
        {
            return ("^" + text + "$");
        }

        public static string GetPercentage(int percent)
        {
            return (percent + "%");
        }

        public static string GetStringByLength(string str, int length, string p_TailString)
        {
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str.ToCharArray());
            if (bytes.Length >= length)
            {
                string str2 = Encoding.Default.GetString(bytes, 0, length - 4);
                if (str2[str2.Length - 1] == '?')
                {
                    str2 = Encoding.Default.GetString(bytes, 0, length - 3);
                }
                return (str2 + p_TailString);
            }
            return str;
        }

        public static int GetStringLength(string Text)
        {
            int num = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Encoding.Default.GetBytes(Text.Substring(i, 1)).Length > 1)
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
            }
            return num;
        }

        public static string GetSubString(string p_SrcString, int p_Length, bool bdot)
        {
            string s = "";
            if (p_Length >= p_SrcString.Length)
            {
                return p_SrcString;
            }
            int num = p_Length * 2;
            if (bdot)
            {
                num -= 3;
            }
            Encoding encoding = Encoding.GetEncoding("gb2312");
            for (int i = p_SrcString.Length; i >= 0; i--)
            {
                s = p_SrcString.Substring(0, i);
                if (encoding.GetBytes(s).Length <= num)
                {
                    break;
                }
            }
            if (bdot)
            {
                s = s + "...";
            }
            return s;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            if (p_Length < 0)
            {
                return str;
            }
            byte[] bytes = Encoding.Default.GetBytes(p_SrcString);
            if (bytes.Length <= p_StartIndex)
            {
                return str;
            }
            int length = bytes.Length;
            if (bytes.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = bytes.Length - p_StartIndex;
                p_TailString = "";
            }
            int num2 = p_Length;
            int[] numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num3 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (bytes[i] > 0x7f)
                {
                    num3++;
                    if (num3 == 3)
                    {
                        num3 = 1;
                    }
                }
                else
                {
                    num3 = 0;
                }
                numArray[i] = num3;
            }
            if ((bytes[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num2 = p_Length + 1;
            }
            destinationArray = new byte[num2];
            Array.Copy(bytes, p_StartIndex, destinationArray, 0, num2);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetValidScriptMsg(string msg)
        {
            StringBuilder builder = new StringBuilder(msg);
            builder.Replace(@"\", @"\\");
            builder.Replace("\n", @"\n");
            builder.Replace("\t", @"\t");
            builder.Replace("\r", @"\r");
            builder.Replace("'", @"\'");
            return builder.ToString();
        }

        public string HtmlDiscode(string theString)
        {
            theString = theString.Replace("&gt;", ">");
            theString = theString.Replace("&lt;", "<");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace("&quot;", "\"");
            theString = theString.Replace("'", "'");
            theString = theString.Replace("<br/> ", "\n");
            return theString;
        }

        public string HtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace(" ", "&nbsp;");
            theString = theString.Replace(" ", "&nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("'", "'");
            theString = theString.Replace("\n", "<br/> ");
            return theString;
        }

        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        public void IncreaseIndent()
        {
            this._indentLevel++;
        }

        public void IncreaseIndent(int step)
        {
            this._indentLevel += step;
        }

        public static string InputText(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            text = Regex.Replace(text, @"[\s]{2,}", " ");
            text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "\n");
            text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            text = text.Replace("'", "''");
            return text;
        }

        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            if (text.Length > maxLength)
            {
                text = text.Substring(0, maxLength);
            }
            text = Regex.Replace(text, @"[\s]{2,}", " ");
            text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "\n");
            text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            text = text.Replace("'", "''");
            return text;
        }

        public void RemoveEnd(string removeString)
        {
            string str = this._str.ToString().TrimEnd(removeString.ToCharArray());
            if (str != this._str.ToString())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(str);
                this._str = builder;
            }
        }

        public static string RemoveLastComma(StringFun text)
        {
            return text.ToString().TrimEnd(new char[] { ',' });
        }

        public static string RemoveLastComma(ref string text)
        {
            text = text.TrimEnd(new char[] { ',' });
            return text;
        }

        public static string RemoveLastComma(StringBuilder text)
        {
            return text.ToString().TrimEnd(new char[] { ',' });
        }

        public static string ReplaceBadChar(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string strContent = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\"";
            string[] strArray = SplitString(strContent, ",");
            string str3 = str;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > 0)
                {
                    str3 = str3.Replace(strArray[i], "");
                }
            }
            return str3;
        }

        public static string ReplaceHtml(string html)
        {
            Regex regex = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
            Regex regex6 = new Regex(@"\<img[^\>]+\>", RegexOptions.IgnoreCase);
            Regex regex7 = new Regex("</p>", RegexOptions.IgnoreCase);
            Regex regex8 = new Regex("<p>", RegexOptions.IgnoreCase);
            Regex regex9 = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
            html = regex.Replace(html, "");
            html = regex2.Replace(html, "");
            html = regex3.Replace(html, " _disibledevent=");
            html = regex4.Replace(html, "");
            html = regex5.Replace(html, "");
            html = regex6.Replace(html, "");
            html = regex7.Replace(html, "");
            html = regex8.Replace(html, "");
            html = regex9.Replace(html, "");
            html = html.Replace("&nbsp;", " ");
            html = html.Replace("&#40;", "(");
            html = html.Replace("&#41;", ")");
            html = html.Replace("\n\r", "");
            html = html.Replace("\r\n", "");
            html = html.Replace("\n", "");
            html = html.Replace("\r", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace(" ", "");
            return html;
        }

        public static string ReplaceSqlChar(string Text)
        {
            string str = Text;
            if ((str != null) && (str != ""))
            {
                return str.ToLower().Replace("'", "''").Trim();
            }
            return "";
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }

        public static string[] SplitString(string strContent, string strSplit, int p_3)
        {
            string[] strArray = new string[p_3];
            string[] strArray2 = SplitString(strContent, strSplit);
            for (int i = 0; i < p_3; i++)
            {
                if (i < strArray2.Length)
                {
                    strArray[i] = strArray2[i];
                }
                else
                {
                    strArray[i] = string.Empty;
                }
            }
            return strArray;
        }

        public static string StringToBase64(string source)
        {
            if (source != "")
            {
                source = HttpUtility.UrlEncode(source);
                byte[] bytes = Encoding.Default.GetBytes(source);
                source = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            return source;
        }

        public override string ToString()
        {
            return this._str.ToString();
        }

        public static string UnAsc(int asciiCode)
        {
            if ((asciiCode < 0) || (asciiCode > 0xff))
            {
                throw new Exception("ASCII Code is not valid.");
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = new byte[] { (byte) asciiCode };
            return encoding.GetString(bytes);
        }

        public int Length
        {
            get
            {
                return this._str.Length;
            }
        }
    }
}

