
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 整数溢出检查
namespace CheckedAndUnchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            checked    // 打开整数溢出检查 
            {
                try
                {
                    int a = int.MaxValue;
                    Console.WriteLine("a = {0}", a);
                    a++;    // a++ 后 a 已经超出了 int 的范围，发生异常，后面的代码不再执行 
                    Console.WriteLine("a = {0}", a);
                    Console.WriteLine("运行不到此处");
                }
                catch (OverflowException oEx)
                {
                    Console.WriteLine(oEx);
                }
            }
            unchecked    // 关闭整数溢出检查 
            {
                int a = int.MaxValue;   // a = 2147483647 
                Console.WriteLine("a = {0}", a);
                a++;    // 虽然 a++ 后 a 已经超出 int 的范围 
                        // 但使用 unchecked 是此处不检查此异常，故后面的代码继续执行 
                Console.WriteLine("a = {0}", a);  // a = -2147483648，最大值 +1 变为最小值 
                Console.WriteLine("可以运行到此处");
            }
            Console.Read();
        }
    }
}
