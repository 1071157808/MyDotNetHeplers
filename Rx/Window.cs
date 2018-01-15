using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace FixedWindow {
    class Program {
        static void Main (string[] args) {
            var sequence = (from number in Enumerable.Range (1, 103) select number)
                .ToObservable ();
            var windowedSequence = sequence.Window (10);
            windowedSequence.Subscribe (os => {
                os = os.SubscribeOn (Scheduler.NewThread);
                Console.WriteLine ("Window {0}", os.Count ().FirstOrDefault ());
                os.Subscribe (Console.WriteLine);
            });
            Console.ReadKey ();
        }
    }
}

// ----------------------------------------------------------

var sequence = (from number in Enumerable.Range (1, 103) select number).ToObservable ();
var windowedSequence = sequence.Window (10);
windowedSequence.Subscribe (os => {
    Console.WriteLine ("Window");
    //因为window截取的也是一个Sequence，所以也可以使用Subscribe
    //这里就是buffer和window的区别
    //buffer返回的是一个IObservable<IList<int>>对象
    //window返回的是一个IObservable<IObservable<int>>对象
    //这两个方法主要用在组的计算，间隔时间内的计算
    Console.WriteLine (os);
    os.Subscribe (Console.WriteLine);
});
Console.Read ();