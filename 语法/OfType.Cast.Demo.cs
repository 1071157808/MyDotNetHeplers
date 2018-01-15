using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LinqCastOfType
{
    class Program
    {
        //OfType和Cast的区别，前者不会引起异常，后者会引起异常，都是转换成IEnunber<T>的泛型
        static void Main(string[] args)
        {
            //两者不同之处在于OfType函式使用as运算子
            //若元素型别无法转为指定型别,则略过该元素
            //Cast函式则是使用Convert.ChangeType函式转型
            //当元素型别无法透过Convert.ChangeType函式转型至指定型别时，即抛出例外
            //OfType不会引起异常，Cast会引起异常
            try
            {
                //不会引起异常
                LinqOfType();
                //会引起异常
                LinqCast();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        /// <summary>
        ///  //linq cast 将以前版本的集合转换为IEnumerable<T>
        /// </summary>
        private static void LinqCast()
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add("111");
            arraylist.Add("222333");
            arraylist.Add(333333333);
            IEnumerable<string> lists = arraylist.Cast<string>().Where(n => n.Length < 8);
            foreach (string list in lists)
            {
                Console.WriteLine(list);
            }
        }
        /// <summary>
        ///  //linq OfType 将以前版本的集合转换为IEnumerable<T>
        /// </summary>
        private static void LinqOfType()
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add("111");
            arraylist.Add("222333");
            arraylist.Add(333333333);
            IEnumerable<string> lists = arraylist.OfType<string>().Where(n => n.Length < 8);
            foreach (string list in lists)
            {
                Console.WriteLine(list);
            }
        }
    }
}