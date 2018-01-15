
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication7
{
    class AnonymousBetterThanTuple
    {
        static void Main(string[] args)
        {
            string str = "spike Mrs";
            var obj = Cast(ParseData(str), new { FirstName = "", SecondName = "" });
            Console.WriteLine(obj.FirstName + "  " + obj.SecondName);
            Console.ReadKey();
        }
        static object ParseData(string strData)
        {
            string[] arrayData = strData.Split(' ');
            return new { FirstName = arrayData[0], SecondName = arrayData[1] };
        }
        static T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }
    }
}