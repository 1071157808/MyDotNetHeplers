using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace MemoryBarrier {
    class Program {
        static void Main (string[] args) {
            var isStop = false;
            var t = new Thread (() => {
                var isSuccess = false;
                while (!isStop) {
                    //在此方法之前的内存写入都要及时从cpu cache中更新到 memory
                    // 在此方法之后的内存读取都要从memory中读取，而不是cpu cache
                    Thread.MemoryBarrier ();
                    isSuccess = !isSuccess;
                }
            });
            t.Start ();
            Thread.Sleep (1000);
            isStop = true;
            t.Join ();
            Console.WriteLine ("主线程执行结束！");
            Console.ReadLine ();
        }
    }
}