// 线程同步的方法
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace CheckedAndUnchecked {
    class Program {
        static void Main (string[] args) {
            PrinterWithInterlockTest.TestPrint ();
            Console.Read ();
        }
    }
    class PrinterWithInterlockTest {
        /// <summary>
        /// 正在使用的打印机
        /// 0代表未使用，1代表正在使用
        /// </summary>
        public static int UsingPrinter = 0;
        /// <summary>
        /// 计算机数量
        /// </summary>
        public static readonly int ComputerCount = 3;
        /// <summary>
        /// 测试
        /// </summary>
        public static void TestPrint () {
            Thread thread;
            Random random = new Random ();
            for (int i = 0; i < ComputerCount; i++) {
                thread = new Thread (MyThreadProc);
                thread.Name = string.Format ("Thread{0}", i);
                Thread.Sleep (random.Next (3));
                thread.Start ();
            }
        }
        /// <summary>
        /// 线程执行操作
        /// </summary>
        private static void MyThreadProc () {
            //使用打印机进行打印
            while (true) {
                if (UsePrinter ()) {
                    break;
                }
            }
            //当前线程等待1秒
            Thread.Sleep (1000);
        }
        /// <summary>
        /// 使用打印机进行打印
        /// </summary>
        private static bool UsePrinter () {
            //检查打印机是否在使用，如果原始值为0，则为未使用，可以进行打印，否则不能打印，继续等待
            if (0 == Interlocked.Exchange (ref UsingPrinter, 1)) {
                Console.WriteLine ("{0} acquired the lock", Thread.CurrentThread.Name);
                //Code to access a resource that is not thread safe would go here.
                //Simulate some work
                Thread.Sleep (500);
                Console.WriteLine ("{0} exiting lock", Thread.CurrentThread.Name);
                //释放打印机
                Interlocked.Exchange (ref UsingPrinter, 0);
                return true;
            } else {
                Console.WriteLine ("{0} was denied the lock", Thread.CurrentThread.Name);
                return false;
            }
        }
    }
}