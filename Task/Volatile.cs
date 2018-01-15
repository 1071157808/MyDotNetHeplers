using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace VolatileDemo {
    class Program {
        // 同步锁
        //volatile可以看作一种同步锁
        public static volatile bool isStop = false;
        static void Main (string[] args) {
            //isStop = false;
            var t = new Thread (() => {
                var isSuccess = false;
                while (!isStop) {
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