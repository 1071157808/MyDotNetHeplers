static Main(string[] args){
    var isStop = false;
    var t = new Thread(()=>
        var iSuccess  = false;
        While(!isStop){
            Thread.MemoryBarrier();
            //在此方法之后的内存读取都要从memory中读取，而不是cpu cache
            iSuccess = !iSuccess;        
        }
    }
    t.Start();
    Thread.Sleep(2000);
    isStop =true;
    Console.WriteLine("主线程运行结束");
    Console.Read();
}
