using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SemaphoreSlimDemo {
    class Program {
        //  信号锁
        //默认1个线程同时运行，最大10个
        //第二个参数是设置最大的使用这个锁的对象的数量
        static SemaphoreSlim slim = new SemaphoreSlim (5, 21);
        static void Main (string[] args) {
            for (int i = 0; i < 20; i++) {
                Task.Run (() => {
                    Run ();
                });
            }
            //某一个时刻，改变默认的并行线程个数，从默认的1改成10
            System.Threading.Thread.Sleep (2000);
            slim.Release (10);
            Console.Read ();
        }
        static void Run () {
            slim.Wait ();
            Thread.Sleep (1000 * 2);
            Console.WriteLine ("当前t1={0} 正在运行 {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            slim.Release ();
        }
    }
}