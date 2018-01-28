using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace actionblock {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        //BroadcastBlock并不保存数据，在每一个数据被发送到所有接收者以后，
        //这条数据就会被后面最新的一条数据所覆盖。
        //如没有目标Block和BroadcastBlock相连的话，数据将被丢弃。
        //但BroadcastBlock总会保存最后一个数据
        static BroadcastBlock<int> bb = new BroadcastBlock<int> ((i) => { return i; });
        //linkto的动作是没有先后的顺序的
        static ActionBlock<int> displayBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Displayed " + i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now));
        static ActionBlock<int> saveBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Saved " + i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now));
        static ActionBlock<int> sendBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Sent " + i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now));
        public static void TestSync () {
            bb.LinkTo (displayBlock);
            bb.LinkTo (saveBlock);
            bb.LinkTo (sendBlock);
            for (int i = 0; i < 4; i++) {
                bb.Post (i);
            }
            Console.WriteLine ("Post finished");
        }
    }
}