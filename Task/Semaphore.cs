using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SemaphoreDemo {
    class Program {
        //static AutoResetEvent areLock = new AutoResetEvent(true);
        //static ManualResetEvent mreLock = new ManualResetEvent(false);
        //这个Semaphore的第一个参数是初始化线程的数量，第二个为最多几个线程
        static Semaphore seLock = new Semaphore (1, 10);
        static void Main (string[] args) {
            //比如开启5个task
            for (int i = 0; i < 5; i++) {
                Task.Factory.StartNew (
                    () => {
                        Run ();
                    });
            }
            Console.Read ();
        }
        static int nums = 0;
        static void Run () {
            for (int i = 0; i < 100; i++) {
                try {
                    seLock.WaitOne ();
                    Console.WriteLine (nums++);
                    seLock.Release ();
                } catch (Exception ex) {
                    Console.WriteLine (ex.Message);
                } finally { }
            }
        }
    }
}