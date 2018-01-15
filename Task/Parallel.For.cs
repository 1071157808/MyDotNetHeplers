using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ForDemo {
    class Program {
        static void Main () {
            ConcurrentStack<int> stack = new ConcurrentStack<int> ();
            //并行计算
            Parallel.For (0, 100, new ParallelOptions () {
                //最多同时并行的线程池中线程的数量为7
                //MaxDegreeOfParallelism = 7
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1,
                    CancellationToken = new CancellationToken ()
            }, (item, loop) => {
                if (item == 10) {
                    //这个不仅中断了item这个task，还会中断其他所有的task
                    loop.Stop ();
                    return;
                }
                stack.Push (item);
            });
            Console.WriteLine (string.Join (",", stack));
            #region 计算0-99之间的和
            var totalNums = 0;
            Parallel.For<int> (1, 100, () => { return 0; }, (current, loop, total) => {
                total += (int) current;
                return total;
            }, (total) => {
                Interlocked.Add (ref totalNums, total);
            });
            Console.WriteLine (totalNums);
            #endregion
        }
    }
}