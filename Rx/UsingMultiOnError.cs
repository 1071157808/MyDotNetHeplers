using System;
using System.Linq;
using System.Reactive.Linq;
namespace UsingMultiOnError {
    class Program {
        static void Main (string[] args) {
            var sequences = new IObservable<int>[] {
                (from number in Enumerable.Range (10, 10) select number)
                .ToObservable ()
                .Select (number => number / (number % 7)),
                (from number in Enumerable.Range (22, 10) select number)
                .ToObservable ()
                .Select (number => number / (number % 7)),
                (from number in Enumerable.Range (33, 10) select number)
                .ToObservable ()
                .Select (number => number / (number % 7)),
                (from number in Enumerable.Range (44, 10) select number)
                .ToObservable ()
                .Select (number => number / (number % 7)),
                (from number in Enumerable.Range (55, 10) select number)
                .ToObservable ()
                .Select (number => number / (number % 7)),
            };
            //发生异常的时候继续执行剩下的序列
            sequences.OnErrorResumeNext ().Subscribe (Console.WriteLine);
            Console.Read ();
        }
    }
}