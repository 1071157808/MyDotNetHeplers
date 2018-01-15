using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace ParallelNameSpace {
    class Program {
        static void Main (string[] args) {
            int amount = 0;
            List<int> list = new List<int> ();
            while (amount < 100000000) {
                amount++;
                list.Add (amount);
            }
            Console.WriteLine ("继续");
            DateTime startTime = DateTime.Now;
            foreach (var item in list) {
                DateTime t = DateTime.Now.AddSeconds (item);
            } //耗时11s
            TimeSpan elapsed = DateTime.Now - startTime;
            Console.WriteLine ("完成：" + elapsed);
            Console.WriteLine ("使用Parallel");
            startTime = DateTime.Now;
            Parallel.ForEach (list, item => {
                DateTime t = DateTime.Now.AddSeconds (item);
            }); //耗时2s
            elapsed = DateTime.Now - startTime;
            Console.WriteLine ("完成：" + elapsed);
            Console.ReadKey ();
        }
    }
}