using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace ExecutionDataflowBlockOptionsDemo {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (" ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
            TestSync3 ();
            Console.Read ();
        }
        /// <summary>
        /// 指定并行处理的数量，这样会同时使用3个线程进行并发处理
        /// </summary>
        public static ActionBlock<int> abAsync = new ActionBlock<int> ((i) => {
            Thread.Sleep (1000);
            Console.WriteLine (i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
        }, new ExecutionDataflowBlockOptions () { MaxDegreeOfParallelism = 3 });
        public static void TestSync3 () {
            for (int i = 0; i < 10; i++) {
                abAsync.Post (i);
            }
            Console.WriteLine ("Post finished");
        }
    }
}