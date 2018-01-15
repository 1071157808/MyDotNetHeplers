using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace _01.ThreadStartJoin {
    class Program {
        static void Main (string[] args) {
            Thread t = new Thread (new ThreadStart (() => {
                Thread.Sleep (5000);
                Console.WriteLine ("子线程执行结束");
            }));
            t.Start ();
            t.Join (); //在此处等待子线程执行完
            Console.WriteLine ("主线程执行结束");
            Console.ReadKey ();
        }
    }
}