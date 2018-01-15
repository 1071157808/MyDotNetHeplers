
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApplication8
{
    class ConcurrentBagProgram
    {
        static void Main(string[] args)
        {
            //表示实现的是一个无序的集合类
            //该类有两个重要的方法用来访问队列中的元素.分别是:
            //TryTake 尝试移除并返回位于队列头开始处的对象.
            //TryPeek尝试返回位于队列头开始处的对象但不将其移除.
            ConcurrentBag<int> sharedBag = new ConcurrentBag<int>();
            for (int i = 0; i < 1000; i++)
            {
                sharedBag.Add(i);
            }
            int itemCount = 0;
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    while (sharedBag.Count > 0)
                    {
                        int queueElement;
                        bool gotElement = sharedBag.TryTake(out queueElement);
                        if (gotElement)
                            Interlocked.Increment(ref itemCount);
                    }
                });
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
            Console.WriteLine("Items processed:{0}", itemCount);
            Console.WriteLine("Press Enter to finish");
            Console.WriteLine(itemCount);
            Console.ReadLine();
        }
    }
}
