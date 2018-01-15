using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimestampDemo {
    class Program {
        static void Main (string[] args) {
            // Timestamp()返回的是一个当前的时间戳的标签，既有value也有Timestamp（时间戳）
            var observable = Observable.Interval (TimeSpan.FromSeconds (1)).Timestamp ();
            using (observable.Subscribe (
                x => Console.WriteLine ("{0}: {1}", x.Value, x.Timestamp))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }
    }
}