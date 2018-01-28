using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace BatchBlockDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        //贪婪模式和非贪婪模式。贪婪模式是默认的
        //贪婪模式是指任何Post到BatchBlock，BatchBlock都接收，并等待个数满了以后处理
        //非贪婪模式是指BatchBlock需要等到构造函数中设置的BatchSize个数的Source都向BatchBlock发
        //Post数据的时候才会处理,不然都会留在Source的Queue中
        //也就是说BatchBlock可以使用在每次从N个Source
        //那个收一个数据打包处理或从1个Source那里收N个数据打包处理。
        //这里的Source是指其他的继承ISourceBlock的，用LinkTo连接到这个BatchBlock的Block。
        //在另一个构造参数中GroupingDataflowBlockOptions，可以通过设置Greedy属性来选择是否贪婪模式和MaxNumberOfGroups来设置最大产生Batch的数量，
        //如果到达了这个数量，BatchBlock将不会再接收数据
        //Greedy是贪婪的意思，非贪婪模式还不会使用
        static BatchBlock<int> bb = new BatchBlock<int> (3, new GroupingDataflowBlockOptions { Greedy = true, MaxNumberOfGroups = 4 });
        static ActionBlock<int[]> ab = new ActionBlock<int[]> ((i) => {
            string s = string.Empty;
            foreach (int m in i) {
                s += m + " ";
            }
            Console.WriteLine (s);
        });
        public static void TestSync () {
            bb.LinkTo (ab);
            for (int i = 0; i < 10; i++) {
                bb.Post (i);
            }
            bb.Complete ();
            Console.WriteLine ("Finished post");
        }
    }
}