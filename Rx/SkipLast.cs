using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
namespace SkipEnd {
    class Program {
        static void Main (string[] args) {
            var sequence = (from number in new int[] { 4, 5, 3, 6, 2, 1, 0 } select Work (number))
                .ToObservable ();
            sequence
                .SkipLast (2)
                .Subscribe (a => Console.WriteLine ("****当前的线程ID是{0},数值是{1} \n --------", Thread.CurrentThread.ManagedThreadId, a));
            Console.Read ();
        }
        static int Work (int number) {
            //Console.WriteLine("Work {0}", number);
            //Thread.Sleep(500);
            Console.WriteLine ("当前的线程ID是{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("数字为" + number);

            return number;
        }
    }
}