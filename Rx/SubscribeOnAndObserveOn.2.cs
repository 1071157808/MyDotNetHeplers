//更深入的理解
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace UsingSynchronize {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (Thread.CurrentThread.ManagedThreadId);
            var xs = Observable.Create<string> (observer => {
                Console.WriteLine ("{0} Side effect1", Thread.CurrentThread.ManagedThreadId);
                observer.OnNext ("Hi");
                observer.OnNext ("There");
                Console.WriteLine ("{0} Side effect2", Thread.CurrentThread.ManagedThreadId);
                observer.OnCompleted ();
                return Disposable.Empty;
            });
            var obj = new object ();

            xs
                //SubscribeOn 只是让事件流的初始化用了一个单独的线程
                .SubscribeOn (Scheduler.NewThread)
                //ObserveOn让事件流中的OnNext输入到delgate执行的时候
                //使用了一个单独的线程
                .ObserveOn (Scheduler.NewThread).
            Take (3)
                .Subscribe (
                    a =>
                    Console.WriteLine ("t: {0}   value: {1}", Thread.CurrentThread.ManagedThreadId,
                        a)
                );
            Console.Read ();
#if false
            var numbers = from number in Enumerable.Range (1, 10000) select number;
            var oddsNEvens = new OddsNEvens ();
            var observableNumbers1 = numbers.ToObservable (Scheduler.NewThread).Synchronize ();
            var observableNumbers2 = numbers.ToObservable (Scheduler.NewThread).Synchronize ();
            observableNumbers1.Subscribe (oddsNEvens.Check, () => Console.WriteLine (oddsNEvens));
            observableNumbers2.Subscribe (oddsNEvens.Check, () => Console.WriteLine (oddsNEvens));
#endif
        }
    }
    class OddsNEvens {
        public void Check (int number) {
            if ((number % 2) == 0) {
                EvenCount += 1;
            } else {
                OddCount += 1;
            }

        }
        public int OddCount { get; private set; }
        public int EvenCount { get; private set; }
        public override string ToString () {
            return String.Format ("Odds {0}  Evens {1}", OddCount, EvenCount);
        }
    }
}