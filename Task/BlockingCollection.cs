using System;  
using System.Text;  
  
using System.Threading.Tasks;  
using System.Collections.Concurrent;  
  
  
//  BlockingCollection 一个支持界限和阻塞的容器

// Add ：向容器中插入元素
// TryTake：从容器中取出元素并删除
// TryPeek：从容器中取出元素，但不删除。
// CompleteAdding：标记容器为不可添加的。此时如果还想继续添加会发生异常。
// IsCompleted： 当此集合被标记为完成，或者此集合被标记为空，返回false，否则返回true
namespace Sample4_4_concurrent_bag  
{  
    class Program  
    {  
        internal static BlockingCollection<int> _TestBCollection;  
  
        class ThreadWork1  // producer  
        {  
            public ThreadWork1()  
            { }  
  
            public void run()  
            {  
                System.Console.WriteLine("ThreadWork1 run { ");  
                for (int i = 0; i < 100; i++)  
                {  
                    System.Console.WriteLine("ThreadWork1 producer: " + i);  
                    _TestBCollection.Add(i);  
                    //if (i == 50)  
                    //    _TestBCollection.CompleteAdding();  
                }  
                _TestBCollection.CompleteAdding();  
  
                System.Console.WriteLine("ThreadWork1 run } ");  
            }  
        }  
  
        class ThreadWork2  // consumer  
        {  
            public ThreadWork2()  
            { }  
  
            public void run()  
            {  
                int i = 0;  
                int nCnt = 0;  
                bool IsDequeuue = false;  
                System.Console.WriteLine("ThreadWork2 run { ");  
                while (!_TestBCollection.IsCompleted)  
                {  
                    IsDequeuue = _TestBCollection.TryTake(out i);  
                    if (IsDequeuue)  
                    {  
                        System.Console.WriteLine("ThreadWork2 consumer: " + i * i + "   =====" + i);  
                        nCnt++;  
                    }  
                }  
                System.Console.WriteLine("ThreadWork2 run } ");  
            }  
        }  
  
        static void StartT1()  
        {  
            ThreadWork1 work1 = new ThreadWork1();  
            work1.run();  
        }  
  
        static void StartT2()  
        {  
            ThreadWork2 work2 = new ThreadWork2();  
            work2.run();  
        }  
        static void Main(string[] args)  
        {  
            Task t1 = new Task(() => StartT1());  
            Task t2 = new Task(() => StartT2());  
  
            _TestBCollection = new BlockingCollection<int>();  
  
            Console.WriteLine("Sample 4-4 Main {");  
  
            Console.WriteLine("Main t1 t2 started {");  
            t1.Start();  
            t2.Start();  
            Console.WriteLine("Main t1 t2 started }");  
  
            Console.WriteLine("Main wait t1 t2 end {");  
            Task.WaitAll(t1, t2);  
            Console.WriteLine("Main wait t1 t2 end }");  
  
            Console.WriteLine("Sample 4-4 Main }");  
  
            Console.ReadKey();  
        }  
    }  
}  