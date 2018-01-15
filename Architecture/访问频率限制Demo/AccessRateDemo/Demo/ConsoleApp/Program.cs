/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadKey();
            start();
            Console.ReadKey();
        }
        static Random ra = new Random();
        static void start()
        {
            for (int i = 0; i < 650; i++)
            {
                ThreadPool.QueueUserWorkItem(e =>
                {
                    for (int x = 0; x < 10; x++)
                    {
                        Factory.Add(ra.Next(0, 40));
                    }
                });
            }
        }

    }
}
