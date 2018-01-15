// ExecuteSynchronously

// Specifies that the continuation task should be executed synchronously.
// 指定continuewith的task都是异步的
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ExecuteSynchronouslyDemo {
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
            }, source.Token, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Current);
            var task3 = task2.ContinueWith (t => {
                Console.WriteLine ("task3 tid={0}， dt={1}  {2}", Thread.CurrentThread.ManagedThreadId,
                    DateTime.Now, task2.Status);
            });
            var task4 = task3.ContinueWith (t => {
                Console.WriteLine ("task4 tid={0}， dt={1}  {2}", Thread.CurrentThread.ManagedThreadId,
                    DateTime.Now, task2.Status);
            });
            task1.Start ();
            Console.Read ();
        }
    }
}