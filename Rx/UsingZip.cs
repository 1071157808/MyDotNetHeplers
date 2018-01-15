using System;
using System.Linq;
using System.Reactive.Linq;
namespace UsingZip {
    class Program {
        static void Main (string[] args) {
            var sequence1 = (from number in Enumerable.Range (0, 10) select number)
                .ToObservable ();
            var sequence2 = (from number in Enumerable.Range (0, 10) select number * number)
                .ToObservable ();
            //zip合成新的对象，里面的属性有left和right代表zip前的两个位置
            var zippedSequence = sequence1.Zip (sequence2, (left, right) => new { left, right });
            zippedSequence.Subscribe (zip =>
                Console.WriteLine ("Number {0}  Square {1}", zip.left, zip.right));
            Console.Read ();
        }
    }
}