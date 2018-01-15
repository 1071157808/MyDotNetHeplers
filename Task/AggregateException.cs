using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HandleDemo {
    class Program {
        static void Main (string[] args) {
            var task = Task.Factory.StartNew (() => {
                var childTask1 = Task.Factory.StartNew (() => {
                    throw new Exception ("task1的异常");
                }, TaskCreationOptions.AttachedToParent);
                var childTask2 = Task.Factory.StartNew (() => {
                    throw new Exception ("task2的异常");
                }, TaskCreationOptions.AttachedToParent);
            });
            try {
                try {
                    //等待任务执行结束
                    task.Wait ();
                } catch (AggregateException ex) {
                    //这个handle返回未false的，会继续往上层的Exception抛出
                    ex.Handle (x => {
                        if (x.InnerException.Message == "task1的异常") {
                            return true;
                        }
                        return false;
                    });
                }
            } catch (Exception ex) {
                var str = ex.Message;
            }
            Console.ReadKey ();
        }
    }
}