using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




// Task.Run Task.Run则是等线程池空闲后在执行
namespace ConsoleApplication7 {
    class Program {
        static void Main (string[] args) {
            Task t1 = new Task (speak);
            t1.Start ();
            t1.Wait ();
            //使用Task.Factory.StartNew创建任务
            Task t2 = Task.Factory.StartNew (speak);
            //wait函数意味着
            //t2.Wait();
            //使用new的方法创建任务
            Task t3 = new Task (speak);
            t3.Start ();
            //t3.Wait();
            //也可以这样，让两个任务同时执行
            Task.WaitAll (t2, t3);
            Task.Run (() => Console.WriteLine ("您的数值已经被提交了"));
            Console.ReadKey ();
        }
        static void speak () {
            for (int i = 0; i < 100000; i++) {
                Console.WriteLine (i + "的时间是" + DateTime.Now + "线程的id是" + Thread.CurrentThread.ManagedThreadId);
            }
            Thread.Sleep (2000);

        }
    }
}