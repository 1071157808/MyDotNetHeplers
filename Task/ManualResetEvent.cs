using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManSetConsole {
    class Program {
        static void Main (string[] args) {
            Program p = new Program ();
            p.Do ();
            Console.Read ();
        }

        ManualResetEvent _manualResetEvent = new ManualResetEvent (false);
        public void Do () {
            Thread t1 = new Thread (this.Thread1Foo);
            t1.Start (); //启动线程1
            Thread t2 = new Thread (this.Thread2Foo);
            t2.Start (); //启动线程2
            Thread.Sleep (3000); //睡眠当前主线程，即调用BT_Temp_Click的线程
            _manualResetEvent.Set (); //想象成将IsRelease设为True
        }
        void Thread1Foo () {
            _manualResetEvent.WaitOne ();
            //阻塞线程1，直到主线程发信号给线程1,告知_menuResetEvent你的IsRelease属性已经为true，
            //这时不再阻塞线程1,程序继续往下跑
            Console.WriteLine ("t1 end");
        }
        void Thread2Foo () {
            _manualResetEvent.WaitOne ();
            //阻塞线程2，直到主线程发信号给线程1,告知_menuResetEvent你的IsRelease属性已经为true，
            //这时不再阻塞线程2,程序继续往下跑
            Console.WriteLine ("t2 end");
        }

    }
}