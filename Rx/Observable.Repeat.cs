using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace RepeatInfinite {
    class Program {
        static void Main (string[] args) {
            //这个repeat会在每次重复的时候按照要求重新开一个新的线程   
            //这里的100只是一个数字，可以用数组
            var sequence = Observable.Repeat (100, Scheduler.NewThread);
            var subscribe = sequence.Subscribe (a => Console.WriteLine ("当前的线程的ID是{0}，当前输入的数字是{1}", Thread.CurrentThread.ManagedThreadId, a));
            Thread.Sleep (3000);
            //subscribe.Dispose();
            Console.Read ();
        }
    }
}