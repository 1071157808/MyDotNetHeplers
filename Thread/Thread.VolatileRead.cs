using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace VolatileRead {
    class Program {
        static void Main (string[] args) {
            var isStop = 0;
            var t = new Thread (() => {
                var isSuccess = false;
                while (isStop == 0) {
                    //立即将这个变量从CPU读取到内存中
                    Thread.VolatileRead (ref isStop);
                    //立马将此变量的值写入所有CPU中
                    //Thread.VolatileWrite(ref isStop,2);
                    isSuccess = !isSuccess;
                }
            });
            t.Start ();
            Thread.Sleep (1000);
            isStop = 1;
            t.Join ();
            Console.WriteLine ("主线程执行结束！");
            Console.ReadLine ();
        }
    }
}