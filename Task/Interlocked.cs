using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace InterlockedDemo {
    class Program {
        static void Main (string[] args) {
            var sum = 0;
            Interlocked.Increment (ref sum);
            Console.WriteLine (sum);
            Interlocked.Decrement (ref sum);
            Console.WriteLine (sum);
            Interlocked.Add (ref sum, 20);
            Console.WriteLine (sum);
            Interlocked.Exchange (ref sum, 60);
            Console.WriteLine (sum);
            //如果sum==60，则用1000替换sum中的值
            //这个返回值不知道是怎么来的
            var result = Interlocked.CompareExchange (ref sum, 1000, 60);
            Console.WriteLine (sum);
            Console.WriteLine (result);
            Console.Read ();
        }
    }
}