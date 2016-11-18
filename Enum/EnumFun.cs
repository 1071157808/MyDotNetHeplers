namespace MyCompany.PeiXun.Tools
{
    using System;
    using System.Collections;

    public class EnumFun
    {
        public static T GetInstance<T>(object member)
        {
            return GetInstance<T>(member.ToString());
        }

        public static T GetInstance<T>(string member)
        {
            return (T) Enum.Parse(typeof(T), member, true);
        }

        public static Hashtable GetMemberKeyValue<T>()
        {
            Hashtable hashtable = new Hashtable();
            string[] memberNames = GetMemberNames<T>();
            foreach (string str in memberNames)
            {
                hashtable.Add(str, GetMemberValue<T>(str));
            }
            return hashtable;
        }

        public static string GetMemberName<T>(object member)
        {
            Type underlyingType = GetUnderlyingType(typeof(T));
            object obj2 = ConvertFun.ConvertTo(member, underlyingType);
            return Enum.GetName(typeof(T), obj2);
        }

        public static string[] GetMemberNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }

        public static object GetMemberValue<T>(string memberName)
        {
            Type underlyingType = GetUnderlyingType(typeof(T));
            return ConvertFun.ConvertTo(GetInstance<T>(memberName), underlyingType);
        }

        public static Array GetMemberValues<T>()
        {
            return Enum.GetValues(typeof(T));
        }

        public static Type GetUnderlyingType(Type enumType)
        {
            return Enum.GetUnderlyingType(enumType);
        }

        public static bool IsDefined<T>(string member)
        {
            return Enum.IsDefined(typeof(T), member);
        }
    }
}

