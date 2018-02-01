using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics.Tracing;
using System.Diagnostics;

//C# 中尽量用循环，F#中尽量用递归(为了32位和64位的兼容性)
//项目->属性->优化代码(generate tail calls)  选中！
//C#/32位或C#/Debug模式中JIT是不进行优化的
//C#/64位/Release是有JIT编译器进行尾递归优化的(非C#编译器优化)。
//http://www.cnblogs.com/mushroom/p/4311952.html

namespace 尾递归
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var st = FibonacciTailRecursive(2000000, 0, 1);
                Console.WriteLine(st);

            }
            catch (Exception ex)
            {
                var str = ex.Message;
                Console.WriteLine(str);
            }

            Console.Read();
        }
        private static int FibonacciTailRecursive(int n, int ret1, int ret2)
        {
            if (n == 0)
                return ret1;
            return FibonacciTailRecursive(n - 1, ret2, ret1 + ret2);
        }
    }
}