 class Program {
     //默认1个线程同时运行，最大10个
     static SemaphoreSlim slim = new SemaphoreSlim (1, 10);

     static void Main (string[] args) {
         for (int i = 0; i < 10; i++) {
             Task.Run (() => {
                 Run ();
             });
         }

         //某一个时刻，我想改变默认的并行线程个数，从默认的1 改成10

         System.Threading.Thread.Sleep (2000);
         slim.Release (10);

         Console.Read ();
     }

     static void Run () {
         slim.Wait ();

         Thread.Sleep (1000 * 5);

         Console.WriteLine ("当前t1={0} 正在运行 {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);

         slim.Release ();
     }
 }