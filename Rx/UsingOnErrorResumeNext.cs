using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace UsingOnErrorResumeNext {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("main thd {0}", Thread.CurrentThread.ManagedThreadId);
            var done = new ManualResetEvent (false);
            var query = from number in Enumerable.Range (0, 10) select number;
            var sequence = query.ToObservable (Scheduler.NewThread);
            sequence
                .Select (number => number / (number - 5))
                //发生异常的时候返回一个可以继续执行的序列，如果不指定就按照原来的序列继续返回
                .OnErrorResumeNext (Observable.Return (int.MaxValue))
                .Finally (() => done.Set ())
                .Subscribe (Console.WriteLine);
            done.WaitOne ();
            Console.WriteLine ("I'm done");
            Console.Read ();
        }
    }
}