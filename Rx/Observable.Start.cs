using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
namespace UsingStartFuncValue {
    class Program {
        static int MyThread () {
            return Thread.CurrentThread.ManagedThreadId;
        }
        static void Main (string[] args) {
            Console.WriteLine ("Application thread {0}", Thread.CurrentThread.ManagedThreadId);
            // executes MyThread but returns an observable sequence
            var observable = Observable.Start<int> (MyThread);
            // The sequence always has a single value in it
            Console.WriteLine ("Function Thread {0}", observable.First ());
            //输出
            //Application thread 1
            //Function Thread 3
            //表明Observable.Start启动的是一个单独的线程
            Console.Read ();
        }
    }
}