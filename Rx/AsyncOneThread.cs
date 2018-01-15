using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
#endregion
namespace AsyncSubscription {
    class Program {
        static void Main (string[] args) {
            // generate a sequence of numbers
            var numbers = from number in Enumerable.Range (1, 10) select number;
            // make an observeable sequence out of those numbers
            // 这个NewThread的意思是异步的启用一个单独的线程来处理observable事件流
            var observable = numbers.ToObservable (Scheduler.NewThread);
            // use the ObservableExtensions.Subscribe to start the callbacks
            // notice that when Subscribe is changed to run, the instruction blocks
            // until the entire observable sequence has been processed
            // 注意到Subscribe开始运行的时候，命令将暂停，直到整个observable序列被处理完
            var d = observable.Subscribe (Do);
            Console.WriteLine ("Done");
            Console.Read ();
            /*
             *
             * Done
                1 的线程id是3
                2 的线程id是3
                3 的线程id是3
                4 的线程id是3
                5 的线程id是3
            */
        }
        public static void Do (int item) {
            Thread.Sleep (1000);
            Console.WriteLine (item + " 的线程id是" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}