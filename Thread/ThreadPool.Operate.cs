class Program {
    static void Main (string[] args) {
        //把线程池的最大值设置为1000
        ThreadPool.SetMaxThreads (1000, 1000);
        ThreadPoolMessage ("Start");

        //新立文件File.sour
        FileStream stream = new FileStream ("File.sour", FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true);
        byte[] bytes = new byte[16384];
        string message = "An operating-system ThreadId has no fixed relationship........";
        bytes = Encoding.Unicode.GetBytes (message);

        //启动异步写入
        stream.BeginWrite (bytes, 0, (int) bytes.Length, new AsyncCallback (Callback), stream);
        stream.Flush ();
        Console.ReadKey ();
    }

    static void Callback (IAsyncResult result) {
        //显示线程池现状
        Thread.Sleep (200);
        ThreadPoolMessage ("AsyncCallback");
        //结束异步写入
        FileStream stream = (FileStream) result.AsyncState;
        stream.EndWrite (result);
        stream.Close ();
    }

    //显示线程池现状
    static void ThreadPoolMessage (string data) {
        int a, b;
        ThreadPool.GetAvailableThreads (out a, out b);
        string message = string.Format ("{0}\n CurrentThreadId is {1}\n " +
            "WorkerThreads is:{2} CompletionPortThreads is :{3}",
            data, Thread.CurrentThread.ManagedThreadId, a.ToString (), b.ToString ());
        Console.WriteLine (message);
    }
}