using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace TaskContinue {
    class Program {
        static void Main (string[] args) {
            Task task1 = new Task (() => {
                System.Threading.Thread.Sleep (1000);
                Console.WriteLine ("我是工作线程1:{0}", DateTime.Now);
            });
            task1.Start ();
            Task task2 = new Task (() => {
                System.Threading.Thread.Sleep (2000);
                Console.WriteLine ("我是工作线程2:{0}", DateTime.Now);
            });
            task2.Start ();
            //异步
            Task.WhenAny (task1, task2).ContinueWith (t => {
                //执行“工作线程3”的内容
                Console.WriteLine ("我是主线程 {0}", DateTime.Now);
            });
            //异步
            Task.WhenAll (task1, task2).ContinueWith (t => {
                //执行“工作线程3”的内容
                Console.WriteLine ("我是工作线程 {0}", DateTime.Now);
            });
            //等待task1，task2结束之后进行某项操作
            Task.WhenAll (task1, task2).ContinueWith ((t) => { return "sdfa"; });
            //Task.Factory的Continue操作
            Task.Factory.ContinueWhenAll (new Task[2] { task1, task2 }, (t) => {
                //执行“工作线程3”的内容
                Console.WriteLine ("我是主线程 {0}", DateTime.Now);
            });
            Console.Read ();
        }
    }
}