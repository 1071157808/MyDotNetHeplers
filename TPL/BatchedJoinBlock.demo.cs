using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace BatchedJoinBlockDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        //创建时指定的每个批次大小BatchedJoinBlock<T1, T2>对象，指定为3
        static BatchedJoinBlock<int, string> bjb = new BatchedJoinBlock<int, string> (3);
        static ActionBlock<Tuple<IList<int>, IList<string>> > ab = new ActionBlock<Tuple<IList<int>, IList<string>> > ((i) => {
            Console.WriteLine ("-----------------------------");
            foreach (int m in i.Item1) {
                Console.WriteLine (m);
            };
            foreach (string s in i.Item2) {
                Console.WriteLine (s);
            };
        });
        public static void TestSync () {
            bjb.LinkTo (ab);
            for (int i = 0; i < 5; i++) {
                bjb.Target1.Post (i);
            }
            for (int i = 5; i > 0; i--) {
                bjb.Target2.Post (i.ToString ());
            }
            Console.WriteLine ("Finished post");
        }
    }
}