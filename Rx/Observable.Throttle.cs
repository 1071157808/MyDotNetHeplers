using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ThrottleDemo {
    class Program {
        // Generates events with interval that alternates between 500ms and 1000ms every 5 events
        static IEnumerable<int> GenerateAlternatingFastAndSlowEvents () {
            int i = 0;
            while (true) {
                if (i > 1000) {
                    yield break;
                }
                yield return i;
                Thread.Sleep (i++ % 10 < 5 ? 500 : 1000);
            }
        }
        static void Main (string[] args) {
            var observable = GenerateAlternatingFastAndSlowEvents ().ToObservable ().Timestamp ();
            // throttle节流器的作用是把这个节流时间内的序列的数字都忽略掉（pass掉）
            var throttled = observable.Throttle (TimeSpan.FromSeconds (1));
            using (throttled.Subscribe (x => Console.WriteLine ("{0}: {1}", x.Value, x.Timestamp))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }
    }
}