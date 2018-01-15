using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
namespace AverageByTime {
    class Program {
        static void Main (string[] args) {
            var sequence = (from number in RandomNumbers (103) select Slow (number))
                .ToObservable ();
            var bufferedSequence = sequence.Buffer (TimeSpan.FromSeconds (4));

            //后面的10是限定最大数量，这个是或者的条件，等于限制了2个限制条件
            // var bufferedSequence = sequence.Buffer(TimeSpan.FromSeconds(10), 10);
            // 直接设置数量
            // var bufferedSequence = sequence.Buffer(3);
            bufferedSequence.Subscribe (list =>
                Console.WriteLine ("Size {0} Average {1}",
                    list.Count,
                    list.Sum () / Math.Max (1, list.Count)));
            Console.ReadKey ();
        }
        private static readonly Random Rand = new Random ();
        static IEnumerable<double> RandomNumbers (int count) {
            while (count > 0) {
                count--;
                yield return Rand.Next (1, 1000);
            }
        }
        static double Slow (double number) {
            Thread.Sleep (Rand.Next (1, 30) * 100);
            return number;
        }
    }
}

// ------------------------------------------------------------------------

var sequence = (from number in Enumerable.Range (1, 103) select number)
    .ToObservable ();
var bufferedSequence = sequence.Buffer (10);
bufferedSequence.Subscribe (buffer => {
    Console.WriteLine ("Buffer size {0}", buffer.Count);
    foreach (var i in buffer) {
        Console.WriteLine ("  {0}", i);
    }
});
Console.ReadKey ();