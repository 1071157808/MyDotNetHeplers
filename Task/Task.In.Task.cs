     Task task = new Task (
         () => {
             var task1 = new Task<int> (() => {
                 Console.WriteLine ("执行线程1的ID：" + Thread.CurrentThread.ManagedThreadId);
                 return Thread.CurrentThread.ManagedThreadId;
             });
             task1.Start ();
             Console.WriteLine ("执行task1线程的IDDDD：" + "task1.Result" + task1.Result + "   " + Thread.CurrentThread.ManagedThreadId);
         });