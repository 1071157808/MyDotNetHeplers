class Program {
    const int res = 1000;
    static void Main (string[] args) {
        ThreadStart threadstart = DoWork;
        Thread thread = new Thread (threadstart);
        thread.Start ();
        for (int i = 0; i < res; i++) {
            Console.Write ("-");
        }
        thread.Join (); //
        Console.ReadKey ();
    }
    static void DoWork () {
        for (int i = 0; i < res; i++) {
            Console.Write ("+");
        }
    }
    //1.其中thread.Join()方法会造成当前进程（主进程）等待，直到其他正在执行的进程结束
    //2.thread.IsBackGround = true; 将当前进程设置为后台进程
    //3.thread.Priority = ThreadPriority.Highest ; 将进程的优先级设置为最高级（当然还有其他枚举值）
    //4.Console.WriteLine(thread.ThreadState) 输出当前进程的状态

    /////////////////////////////////////////////////////////////////////////////////////////
    public static void CallToChildThread () {
        Console.WriteLine ("Child thread starts");
    }
    public static void CallToParentThread () {
        Console.WriteLine ("Parent thread starts");
    }
    static void Main (string[] args) {
        ThreadStart childref = new ThreadStart (CallToChildThread); // 创建线程的委托，并将需要调用的方法赋给委托
        childref += CallToParentThread; // 赋值新的方法给委托
        Console.WriteLine ("In Main: Creating the Child thread");
        Thread childThread = new Thread (childref);
        childThread.Start ();
        Console.ReadKey ();
    }