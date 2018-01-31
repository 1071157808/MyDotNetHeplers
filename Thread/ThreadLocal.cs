using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadLocal {
    class Program {
        static void Main (string[] args) {
            //ThreadLocal也用来做线程间的可见性变量存储
            ThreadLocal<string> local = new ThreadLocal<string> ();
            local.Value = "hello world!!!";
            var t = new Thread (() => {
                //这个显示的也为空
                Console.WriteLine ("当前工作线程:{0}", local.Value);
            });
            t.Start ();
            Console.WriteLine ("主线程:{0}", local.Value);
            Console.Read ();
        }
    }
}