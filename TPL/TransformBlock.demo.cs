using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace BigDemo {
    class Program {
        static void Main (string[] args) {
            TestSync ();
            Console.Read ();
        }
        public static ActionBlock<string> abSync = new ActionBlock<string> ((i) => {
            Thread.Sleep (1000);
            Console.WriteLine (i + " ThreadId:" + Thread.CurrentThread.ManagedThreadId + " Execute Time:" + DateTime.Now);
        });
        public static TransformBlock<int, string> tbSync = new TransformBlock<int, string> ((i) => {
            i = i * 2;
            return i.ToString ();
        });
        public static void TestSync () {
            tbSync.LinkTo (abSync);
            for (int i = 0; i < 10; i++) {
                tbSync.Post (i);
            }
            tbSync.Complete ();
            Console.WriteLine ("Post finished");
            tbSync.Completion.Wait ();
            Console.WriteLine ("TransformBlock process finished");
        }
    }
}

webclient结合使用
using System;
using System.Collections.Generic;
using System.Linq;
usingSystem.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace TransformBlockDemo {
    class Program {
        static void Main (string[] args) { }
        public static TransformBlock<string, string> tbUrl = new TransformBlock<string, string> ((url) => {
            WebClient webClient = new WebClient ();
            return webClient.DownloadString (new Uri (url));
        });
        public static void TestDownloadHTML () {
            tbUrl.Post ("www.baidu.com");
            tbUrl.Post ("www.sina.com.cn");
            string baiduHTML = tbUrl.Receive ();
            string sinaHTML = tbUrl.Receive ();
        }
    }
}