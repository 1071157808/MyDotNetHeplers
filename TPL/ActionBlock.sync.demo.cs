using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace ActionBlockDemo {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (" ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
            TestSync ();
            Console.Read ();
        }
        /// <summary>
        /// ActionBlock中使用同步的方法，同步方法默认会使用线程池中的一个线程（我记得是这样的）
        /// </summary>
        public static ActionBlock<int> abSync = new ActionBlock<int> ((i) => {
            Thread.Sleep (1000);
            Console.WriteLine (i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
        });
        public static void TestSync () {
            for (int i = 0; i < 10; i++) {
                abSync.Post (i);
            }
            Console.WriteLine ("Post finished");
        }
    }
}