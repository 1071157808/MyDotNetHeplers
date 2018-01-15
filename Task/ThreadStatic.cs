using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadStatic {
    class Program {
        //ThreadStatic属性的含义就是单个线程中唯一
        //用 ThreadStaticAttribute 标记的 static 字段不在线程之间共享。每个执行线程都有单独的字段实例
        [ThreadStatic]
        static string username = "原始人";
        static void Main (string[] args) {
            username = "新人类";
            var t = new Thread (() => {
                //这个username是空的
                Console.WriteLine ("当前工作线程:{0}", username);
            });
            t.Start ();
            Console.WriteLine ("主线程:{0}", username);
            Console.Read ();
        }
    }
}