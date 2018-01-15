using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApplication2 {
    class Program {
        static void Main (string[] args) {
            // Task 新建线程 同步 异步
            
            #region 异步调用
            //new方式启动
            var task = new Task<string> (() => {
                Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
                return "ss";
            });
            task.Start ();
            var msg = task.Result;
            //使用TaskFactory启动
            Task task2 = Task.Factory.StartNew (() => {
                Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
            });
            //使用Task的Run方法
            ////Run方法好像被取消了
            //Task task3 = Task.Run(() =>
            //{
            //    Console.WriteLine("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
            //});
            #endregion
            #region 同步调用
            //这个是同步执行。。。。也就是阻塞执行。。。
            Task task4 = new Task (() => {
                System.Threading.Thread.Sleep (1000);
                Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
            });
            task.RunSynchronously ();
            Console.WriteLine ("我是主线程");
            #endregion

        }
    }
}