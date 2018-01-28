using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace ConcurrentExclusiveSchedulerPairDemo {
    class Program {
        static void Main (string[] args) {
            Test ();
            Console.Read ();
        }
        public static ActionBlock<int> readerAB1;
        public static ActionBlock<int> readerAB2;
        public static ActionBlock<int> readerAB3;
        public static ActionBlock<int> writerAB1;
        public static BroadcastBlock<int> bb = new BroadcastBlock<int> ((i) => { return i; });
        //我们可以把这两个TaskScheduler构造进要使用的Block中。
        //他们保证了在没有排他任务的时候（使用ExclusiveScheduler的任务），
        //其他任务（使用ConcurrentScheduler）可以同步进行，
        //当有排他任务在运行的时候，其他任务都不能运行。其实它里面就是一个读写锁

        public static void Test () {
            ConcurrentExclusiveSchedulerPair pair = new ConcurrentExclusiveSchedulerPair ();
            readerAB1 = new ActionBlock<int> ((i) => {
                Console.WriteLine ("ReaderAB1 begin handling." + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
                Thread.Sleep (500);
            }, new ExecutionDataflowBlockOptions () { TaskScheduler = pair.ConcurrentScheduler });
            readerAB2 = new ActionBlock<int> ((i) => {
                Console.WriteLine ("ReaderAB2 begin handling." + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
                Thread.Sleep (500);
            }, new ExecutionDataflowBlockOptions () { TaskScheduler = pair.ConcurrentScheduler });
            readerAB3 = new ActionBlock<int> ((i) => {
                Console.WriteLine ("ReaderAB3 begin handling." + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
                Thread.Sleep (500);
            }, new ExecutionDataflowBlockOptions () { TaskScheduler = pair.ConcurrentScheduler });
            writerAB1 = new ActionBlock<int> ((i) => {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("WriterAB1 begin handling." + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
                Console.ResetColor ();
                Thread.Sleep (3000);
            }, new ExecutionDataflowBlockOptions () { TaskScheduler = pair.ExclusiveScheduler });
            bb.LinkTo (readerAB1);
            bb.LinkTo (readerAB2);
            bb.LinkTo (readerAB3);
            Task.Run (() => {
                var i = 2;
                while (i < 4) {
                    bb.Post (1);
                    Thread.Sleep (1000);
                    i++;
                }
            });
            Task.Run (() => {
                var i = 2;
                while (i < 4) {
                    Thread.Sleep (6000);
                    writerAB1.Post (1);
                    i++;
                }
            });
        }
    }
}