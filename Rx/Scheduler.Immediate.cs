using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace ImmediateVsCurrentThread {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Application Thread {0}", Thread.CurrentThread.ManagedThreadId);
            var observableQuery = (from number in Enumerable.Range (1, 5) select number)
                // 使用immediate后，当前线程会被释放掉，所以不会执行后面的Console.WriteLine Application Finished函数
                .ToObservable (Scheduler.Immediate)
                // 使用CurrentThread，当前线程不会被释放掉，所以会继续执行后面的Console.WriteLine Application Finished函数
                //.ToObservable(Scheduler.CurrentThread)
                .Repeat ()
                .Take (10);
            observableQuery.Subscribe (n =>
                Console.WriteLine ("Value {0}\tThread {1}",
                    n, Thread.CurrentThread.ManagedThreadId),
                () => Console.WriteLine ("Done"));
            Console.WriteLine ("Application Finished");
            Console.Read ();

        }
    }
}