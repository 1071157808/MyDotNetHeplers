using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace TerminatingSubscription {
    class Program {
        static void Main (string[] args) {
            var query = from number in Enumerable.Range (1, 10) select Slow (number);
            var observableQuery = query.ToObservable (Scheduler.NewThread);
            // keep reference to object returned by subcribe
            var subscription = observableQuery.
            Subscribe (Console.WriteLine,
                e => Console.WriteLine (e.Message),
                () => Console.WriteLine ("Done"));
            Console.ReadKey ();
            // once key has been press dispose subscription
            subscription.Dispose ();
            Console.WriteLine ("Subscription Disposed");
            Console.ReadKey ();
        }
        private static int Slow (int number) {
            Thread.Sleep (1000);
            return number;
        }
    }
}