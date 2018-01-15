
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApplication8
{
    class ConcurrentQueueProgram
    {
        static void Main(string[] args)
        {
            //表示线程安全的先进先出(FIFO)队列
            //TryDequeue 尝试移除并返回位于队列头开始处的对象.
            //TryPeek尝试返回位于队列头开始处的对象但不将其移除.
            ConcurrentQueue<int> sharedQueue = new ConcurrentQueue<int>();
            for (int i = 0; i < 1000000; i++)
            {
                sharedQueue.Enqueue(i);
            }
            int itemCount = 0;
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    while (sharedQueue.Count > 0)
                    {
                        int queueElement;
                        bool gotElement = sharedQueue.TryDequeue(out queueElement);
                        if (gotElement)
                        {
                            Interlocked.Increment(ref itemCount);
                        }
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
