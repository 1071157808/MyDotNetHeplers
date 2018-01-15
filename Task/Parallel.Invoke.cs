using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ActionDemo {
    class Program {
        static void Main (string[] args) {
            Parallel.Invoke (
                () => {
                    Console.WriteLine ("我是并行计算1 " + Thread.CurrentThread.ManagedThreadId);
                }, () => {
                    Console.WriteLine ("我是并行计算2 " + Thread.CurrentThread.ManagedThreadId);
                });
        }
    }
}