using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace JoinBlockDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        static JoinBlock<int, string> jb = new JoinBlock<int, string> ();
        static ActionBlock<Tuple<int, string>> ab = new ActionBlock<Tuple<int, string>> ((i) => {
            Console.WriteLine (i.Item1 + " " + i.Item2);
        });
        public static void TestSync () {
            jb.LinkTo (ab);
            for (int i = 0; i < 5; i++) {
                jb.Target1.Post (i);
            }
            for (int i = 6; i > 0; i--) {
                Thread.Sleep (1000);
                //JoinBlock 需要等参数全部传输完了才开始执行关联的action动作的
                jb.Target2.Post (i.ToString ());
            }
            Console.WriteLine ("Finished post");
        }
    }
}