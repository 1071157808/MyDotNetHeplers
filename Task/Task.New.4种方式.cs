    //-----------------
    这个是异步执行
    Task task = new Task (() => {
        Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
    });

    task.Start ();

    Console.Read ();

    //------------------------------
    //使用TaskFactory启动
    var task = Task.Factory.StartNew (() => {
        Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
    });

    //------------------------------
    //使用Task的Run方法
    var task = Task.Run (() => {
        Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
    });

    //----------------------------------
    //这个是同步执行。。。。也就是阻塞执行。。。
    var task = new Task (() => {
        Console.WriteLine ("我是工作线程： tid={0}", Thread.CurrentThread.ManagedThreadId);
    });

    task.RunSynchronously ();