using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace TransformManyBlockDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        static TransformManyBlock<int, int> tmb = new TransformManyBlock<int, int> ((i) => { return new int[] { i, i + 1 }; });
        static ActionBlock<int> ab = new ActionBlock<int> ((i) => Console.WriteLine (i));
        public static void TestSync () {
            //这个地方就是将TransformManyBlock中的多个参数依次转换成了一个参数给ActionBlock
            tmb.LinkTo (ab);
            for (int i = 0; i < 4; i++) {
                tmb.Post (i);
            }
            Console.WriteLine ("Finished post");
        }
    }
}