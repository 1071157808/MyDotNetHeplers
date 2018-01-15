using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimeIntervalDemo {
    class Program {
        static void Main (string[] args) {
            // 这个TimeInterval()返回的是一个TimeInterval对象，包含了value和Interval，
            // 就是当前值（也是从0开始累加）和时间间隔的值
            var observable = Observable
                .Interval (TimeSpan.FromSeconds (1))
                .TimeInterval ();
            using (observable.Subscribe (
                x => Console.WriteLine ("{0}: {1}", x.Value, x.Interval))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }
    }
}