using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace UsingToAsync {
    class Program {
        static void Main (string[] args) {
            var stest = "开始的数据";
            // delegate is executed asynchronously on thread pool
            var asyncFunction = Observable.ToAsync (
                () => {
                    Thread.Sleep (1000);
                    throw new Exception ("mfasd");
                });
            // executing function produces an observable
            var observable = asyncFunction ();
            //Console.ReadKey();
            // we can subscribe to observable
            observable.Subscribe (e => Console.WriteLine (e),
                e => Console.WriteLine (e.Message), () => Console.WriteLine ("I'm done"));
            /*
             * 开始的数据
                mfasd
             */
            //这个说明ToAsync的数据流的处理是异步的
            Console.WriteLine (stest);
            Console.Read ();
        }
    }
}