using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace UsingCatch {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("main thd {0}", Thread.CurrentThread.ManagedThreadId);
            var done = new ManualResetEvent (false);
            var query = from number in Enumerable.Range (0, 10) select number;
            var sequence = query.ToObservable (Scheduler.NewThread);
            sequence
                .Select (number => number / (number - 4))
                //报错以后剩余的就不再计算了，但会执行finally里面的内容
                .Catch ((Exception ex) => Observable.Empty<int> ())
                .Finally (() => done.Set ())
                .Subscribe (Console.WriteLine);
            done.WaitOne ();
            Console.WriteLine ("I'm done");
            Console.Read ();
        }
    }
}