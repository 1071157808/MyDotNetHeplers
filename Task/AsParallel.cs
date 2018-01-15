using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace AsParallelDemo {
    class Program {
        static void Main () {
            CancellationTokenSource source = new CancellationTokenSource ();
            var nums = Enumerable.Range (0, 2).ToList ();
            nums[0] = 10000;
            //WithDegreeOfParallelism 设置当前参与的线程数量
            //WithCancellation  用来操作取消动作
            //WithExecutionMode  ForceParallelism强制并行计算  default让系统自己选择是串行还是并行
            var query = from n in nums.AsParallel ().WithDegreeOfParallelism (Environment.ProcessorCount)
                .WithCancellation (source.Token)
                .WithExecutionMode (ParallelExecutionMode.ForceParallelism)
                .WithMergeOptions (ParallelMergeOptions.Default)
            select new {
                thread = GetThreadID (),
                num = n
            };
            //source.Cancel();
            foreach (var item in query) {
                Console.WriteLine (item);
            }
            Console.Read ();
        }
        static int GetThreadID () {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}