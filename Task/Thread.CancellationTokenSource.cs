using System;
using System.Threading;
using System.Threading.Tasks;
namespace IsCancellationRequestedDemo {
    class Program {
        static void Main (string[] args) {
            CancellationTokenSource source = new CancellationTokenSource ();
            source.Token.Register (() => {
                //如果当前的token被取消，此函数将会被执行
                Console.WriteLine ("当前source已经被取消，现在可以做资源清理了。。。。");
            });
            var task = Task.Factory.StartNew (() => {
                while (!source.IsCancellationRequested) {
                    Thread.Sleep (100);
                    Console.WriteLine ("当前thread={0} 正在运行", Thread.CurrentThread.ManagedThreadId);
                }
            }, source.Token);
            Thread.Sleep (1000);
            source.Cancel ();
            Console.Read ();
        }
    }
}

// ----------------------------------------------------------------------------
// CancellationTokenSource.CreateLinkedTokenSource
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace CreateLinkedTokenSourceDemo {
    class Program {
        static void Main (string[] args) {
            CancellationTokenSource source1 = new CancellationTokenSource ();
            //现在要让source1取消
            //source1.Cancel();
            CancellationTokenSource source2 = new CancellationTokenSource ();
            source2.Cancel ();
            var combineSource = CancellationTokenSource.CreateLinkedTokenSource (source1.Token, source2.Token);
            Console.WriteLine ("s1={0}  s2={1}  s3={2}", source1.IsCancellationRequested,
                source2.IsCancellationRequested,
                combineSource.IsCancellationRequested);
            //s1=False  s2=True  s3=True
            Console.Read ();
        }
    }
}