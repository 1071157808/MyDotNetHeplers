using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace ActionBlockAsync {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (" ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
            //TestSync();
            TestSync2 ();
            Console.Read ();
        }
        /// <summary>
        /// ActionBlock中使用异步的方法，异步方法会使用线程池中的线程
        /// </summary>
        public static ActionBlock<int> abSync2 = new ActionBlock<int> (async (i) => {
            await Task.Delay (1000);
            Console.WriteLine (i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
        });
        public static void TestSync2 () {
            for (int i = 0; i < 10; i++) {
                abSync2.Post (i);
            }
            Console.WriteLine ("Post finished");
        }
    }
}