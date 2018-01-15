// Observable.Timeout

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimeoutDemo {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (DateTime.Now);
            // create a single event in 10 seconds time
            var observable = Observable.Timer (TimeSpan.FromSeconds (10)).Timestamp ();
            // raise exception if no event received within 9 seconds
            // 9秒内没有触发就报异常

            var observableWithTimeout = Observable.Timeout (observable, TimeSpan.FromSeconds (9));
            using (observableWithTimeout.Subscribe (
                x => Console.WriteLine ("{0}: {1}", x.Value, x.Timestamp),
                ex => Console.WriteLine ("{0} {1}", ex.Message, DateTime.Now))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }
    }
}