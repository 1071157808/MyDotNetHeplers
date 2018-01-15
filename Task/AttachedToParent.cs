using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace AttachedToParent {
    class Program {
        static void Main (string[] args) {
            #region 异步
            Task task = new Task (() => {
                Task task1 = new Task (() => {
                    Thread.Sleep (100);
                    Console.WriteLine ("task1");
                });
                Task task2 = new Task (() => {
                    Thread.Sleep (10);
                    Console.WriteLine ("task2");
                });
                task1.Start ();
                task2.Start ();
            });
            task.Start ();
            // 这个主线程会继续执行下面的console.write
            task.Wait (); //task.WaitAll(task1,task2);
            Console.WriteLine ("我是主线程！！！！");
            Console.Read ();
            #endregion
            #region 同步
            //AttachedToParent的意思就是将task加入主线程的task中
            //如果不添加，那么就是将task单独启动，并不与主线程关联
            task = new Task (() => {
                Task task1 = new Task (() => {
                    Thread.Sleep (100);
                    Console.WriteLine ("task1");
                }, TaskCreationOptions.AttachedToParent);
                Task task2 = new Task (() => {
                    Thread.Sleep (10);
                    Console.WriteLine ("task2");
                }, TaskCreationOptions.AttachedToParent);
                task1.Start ();
                task2.Start ();
            });
            task.Start ();
            //等待主线程的task中的所有线程执行结束，才执行wait之后的console.write
            task.Wait (); //task.WaitAll(task1,task2);
            Console.WriteLine ("我是主线程！！！！");
            Console.Read ();
            #endregion
        }
    }
}