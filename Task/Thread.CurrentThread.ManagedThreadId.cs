using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace MultiThread {
    class Program {
        static void Main (string[] args) {
            for (int i = 0; i < 10; i++) {
                Thread t = new Thread (() => {
                    Console.WriteLine ("work{0},线程ID：{1}", i, Thread.CurrentThread.ManagedThreadId);
                });
                t.Name = "main" + i;
                t.Start ();
            }
            Console.WriteLine ("运行完成");
            Console.Read ();
        }
    }
}