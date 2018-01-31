//Volatile关键字用法，不可以底层对代码进行优化
//变量的读取和写入都是从memory中的，
//这个属于用户模式锁的易变结构


static Main(string[] args){
    var isStop = 0;
    var t = new Thread(()=>
        var iSuccess  = false;
        While(isStop == 0){
            //从内存中读取    
            Thread.VolatileRead(ref isStop);
            iSuccess = !iSuccess;        
        }
    }
    t.Start();
    Thread.Sleep(2000);
    isStop =1;
    Console.WriteLine("主线程运行结束");
    Console.Read();
}
