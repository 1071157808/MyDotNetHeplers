using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MutexDemo {
    class Program {
        //static AutoResetEvent areLock = new AutoResetEvent(true);
        //static ManualResetEvent mreLock = new ManualResetEvent(false);
        //static Semaphore seLock = new Semaphore(1, 10);
        static Mutex mutex = new Mutex ();
        static Mutex mutex2 = new Mutex (true, "demo");
        static void Main (string[] args) {
            //比如开启5个task
            for (int i = 0; i < 5; i++) {
                Task.Factory.StartNew (() => {
                    Run ();
                });
            }
            Console.Read ();
        }
        static int nums = 0;
        static void Run () {
            for (int i = 0; i < 100; i++) {
                try {
                    //seLock.WaitOne();
                    mutex.WaitOne ();
                    Console.WriteLine (nums++);
                    //seLock.Release();
                    mutex.ReleaseMutex ();
                } catch (Exception ex) {
                    Console.WriteLine (ex.Message);
                } finally { }
            }
        }
    }
}