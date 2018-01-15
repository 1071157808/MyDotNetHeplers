
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DateTimeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = "2016/4/16";
            string str = "4/16/2016";
            //var date = ConvertExcelDateTimeIntoCLRDateTime(str);
            double date = double.Parse(str);
            var dateTime = DateTime.FromOADate(date).ToString("MMMM dd, yyyy");
            Console.WriteLine();
        }
        public static DateTime ConvertExcelDateTimeIntoCLRDateTime(object value)
        {
            if (value is DateTime)
            {
                return DateTime.Parse(value.ToString());
            }
            else
            {
                string dt = DateTime.FromOADate(Convert.ToInt32(value)).ToString("d");
                return DateTime.Parse(dt);
            }
        }
    }
}
