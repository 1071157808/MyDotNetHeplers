using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace NotOnRanToCompletion {
    class Program {
        static void Main (string[] args) {
            Task task1 = new Task (() => {
                Thread.Sleep (1000);
                Console.WriteLine ("task1 tid={0}， dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
                throw new Exception ("hello world");
            });
            var task2 = task1.ContinueWith (t => {
                Console.WriteLine ("task2 tid={0}， dt={1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            }, TaskContinuationOptions.NotOnRanToCompletion);
        }
    }
}