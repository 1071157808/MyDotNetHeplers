//一次处理一个对象用到的
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace WriteOnceBlockDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        static WriteOnceBlock<int> bb = new WriteOnceBlock<int> ((i) => { return i; });
        static ActionBlock<int> displayBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Displayed " + i));
        static ActionBlock<int> saveBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Saved " + i));
        static ActionBlock<int> sendBlock = new ActionBlock<int> ((i) => Console.WriteLine ("Sent " + i));
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