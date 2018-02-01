命令：!teb 
作用：查看线程的空间开销，数据都是存放在线程环境块中的
备注：显示中的TLS 代表 thread local storage


命令：!clrstack
作用：查看堆栈信息


命令：!threads
作用：查看dll中的线程
备注：DeadThread: 10  这个虽然表示线程挂掉了，
     但是没有被GC回收，从析构函数中可以看到 this.InternalFinalize();  
     就是说销毁之后，先进入终结器《1》 或许能够被复活《2》 下次被GC回收
     虽然thread已经死掉了，但是该占的资源还是要站


命令：!FinalizeQueue
作用；看看终结器中的内容，可以看到有10个线程等待被销毁

命令：!threadpool
作用；查看线程池
备注：显示内容---thread : Total : 8 Running : 0 Idle :8 MaxLimit : 2047 MinLimit : 8
从windbg中可以看到，ThreadPool当前没有死线程，而是都是默认初始化的。。。
最多可以开启2047个线程
工作线程最多开启1000个
DeadThread:       0
好像看到了当前的threadpool，
其中有“工作线程” 和 “IO线程”
工作线程： 给一般的异步任务执行的。。其中不涉及到 网络，文件 这些IO操作。。。 【开发者调用】
IO线程：  一般用在文件，网络IO上。。。  【CLR调用】
8的又来就是因为我有 8个逻辑处理器，也就是说可以8个Thread 并行处理





