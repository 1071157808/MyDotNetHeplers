using System;
using System.Threading;
namespace ThreadIsStop {
    class Program {
        static void Main (string[] args) {
            var isStop = false;
            var thread = new Thread (() => {
                while (!isStop) {
                    Thread.Sleep (100);
                    Console.WriteLine ("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);
                }
            });
            thread.Start ();
            Thread.Sleep (1000);
            isStop = true;
            Console.Read ();
        }
    }
}