// In the case of continuation cancellation,
// prevents completion of the continuation until the antecedent 先前的 has completed.
// 等先前的完成后，这个才会继续走

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CancellationTokenSourceDemo {
    class Program {
        static void Main (string[] args) {
            CancellationTokenSource source = new CancellationTokenSource ();
            source.Cancel ();
            Task task1 = new Task (() => {
                Thread.Sleep (1000);
                Console.WriteLine ("task1 tid={0}， dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            });
            var task2 = task1.ContinueWith (t => {
                Console.WriteLine ("task2 tid={0}， dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            }, source.Token, TaskContinuationOptions.LazyCancellation, TaskScheduler.Current);
            var task3 = task2.ContinueWith (t => {
                Console.WriteLine ("task3 tid={0}， dt={1}  {2}", Thread.CurrentThread.ManagedThreadId,
                    DateTime.Now, task2.Status);
            });
            task1.Start ();
            Console.Read ();
        }
    }
}