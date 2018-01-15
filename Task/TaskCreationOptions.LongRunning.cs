using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace DenyChildAttach {
    class Program {
        static void Main (string[] args) {
            Task task = new Task (() => {
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
                //如果你明知道是长时间运行的任务，建议你使用此选项
            }, TaskCreationOptions.LongRunning);
            task.Start ();
            task.Wait (); //task.WaitAll(task1,task2);
            Console.WriteLine ("我是主线程！！！！");
            Console.Read ();
        }
    }
}