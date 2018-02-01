一：锁机制的内核模式
1. 在万不得已的情况下，不要使用内核模式的锁，因为代价太大。。。其实我们有更多的方式可以替代：
   混合锁机制， lock
内核锁有三种锁机制：
2. 事件锁
3. 信号量
4. 互斥锁

二：事件锁 【开关锁，true,false的变量来进行控制】
请尽量不要使用内核模块的锁定机制，比如.NET的Mutex，Semaphore，AutoResetEvent和 ManuResetEvent，使用这样的机制涉及到了系统在用户模式和内核模式间的切换，性能差很多，但是他们的优点是可以跨进程同步线程，所以应该清 楚的了解到他们的不同和适用范围
下面的这些锁都是内核模式（Mutex，Semaphore，AutoResetEvent和 ManuResetEvent）
1. 自动事件锁 【AutoResetEvent】

2. 手动事件锁  ManuResetEvent

注意点
两者 ManualResetEvent  和 AutoResetEvent  是不一样的，所以不能混用。
3. 信号量 Semaphore 【他是通过int数值来控制线程个数】
static Semaphore seLock = new Semaphore(1, 10);  我当前只能是一个线程通过。。
第一个参数指的是当前允许可以有多少个线程通过
第二个参数指的是总共可以使用的线程的总数，我认为是指的是并发的数量
static Run(){
    for(int i = 0; i < 100; i++){    
        try{
            //等待信号，锁定线程
            seLock.WaitOne();
            Console.WriteLine(num++);
            //释放线程，发出信号
            seLock.Release();

        }catch(Exception ex){
        
        }
    }
}
5. 互斥锁 mutex 
一般用于资源竞争时对临界区的保护
Mutex混合了 AutoResetEvent与ManualResetEvent的一些特性，简单来说：
1.Mutex和AutoResetEvent一样，只能允许一个线程进入。当一个线程获得许可之后，其它等待的线程必须继续等待；
2.Mutex和ManualResetEvent一样，必须手动释放许可证，即调用Mutex.ReleaseMutex()方法。

6：这三种锁，我们发现都有一个WaitOne方法。。。因为他们都是继承于WaitHandle。。。

三种锁都是同根生，其实底层都是通过SafeWaitHandle来对win32api的一个引用。


一：ReaderWriteLock
不是从限定个数的角度出发。 而是按照读写的角度进行功能分区
sqllite: 库锁
sqlserver： 行锁 【我只锁住行】
多个线程可以一起读， 只能让要给线程去写。。。
模拟：多个线程读，一个线程写，那么写的线程是否会阻止读取的线程。。。。
读写 8/2 开。。。
如果你的写入线程时间太久。。。比如说：10s/20s
这个时候你的读线程会被卡死，从而超时。。。。
Ctrip。。。。。 机票db。。。
商旅事业部： orders,,,
机票事业部： orders。。。
给腾讯做对外接口【企业商旅】
order1 join order2...join plane   读取时间太长，也导致write线程长时间进不来，同样也导致了写入线程超时


二：CountdownEvent
限制线程数的一个机制
而且这个也非常实用

多个线程从某一张表中读取数据：
比如说：Orders            Products       Users
每张表我都喜欢通过多个线程去读取
比如说：Orders表 10w： 10个线程读取，一个线程1w
             Products表：5w  5个线程     一个1w
             Users  表 1w    2个线程      5w
   xxxx.continuewithcontinuewith....
 continuewith +  TaskCreationOptions.AttachedToParent
 CountdownEvent cdeLock = new CountdownEvent(10);

初始化的时候设置一个 默认threadcount上线。。。

当你使用一个thread。这个threacount就会--操作。。直到为0之后，继续下一步操作，相当于Task.Wait() 执行完成了。

Reset： 重置当前的threadcount上限
Signal：将当前的threadcount--操作
Wait： 相当于我们的Task.WaitAll




一：混合锁 = 用户模式锁  +  内核模式锁
1. Thread.Sleep(1)  让线程休眠1ms
   Thread.Sleep(0)  让线程放弃当前的时间片，让本线程更高或者同等线程得到时间片运行。
   Thread.Yield()   让线程立即放弃当前的时间片，可以让更低级别的线程得到运行，当其他thread时间片用完，本thread再度唤醒
    Yield < Sleep(0) < Sleep(1)   
     一个时间片 = 30ms。。
   通常会用到用户模式锁。。。while + 这些Thread
SemaphoreSlim：
ManualResetEventSlim：  有人看守的火车轨道标志，栅栏是合围状态  slim的默认状态，一般都是合围状态，即false，阻塞
ReaderWriterLockSlim：
不用说，他们比之前的内核版本，性能要高得多，因为不是调用win32程序
具体使用，前面的课程已经和大家聊过了，这次只是看一下不同。。。
1. ManualResetEventSlim：优化的点
《1》 构造函数中已经可以不提供默认状态，默认是false，表示合围状态。
《2》 使用Wait来代替WaitOne（是WaitHandle祖先类提供了一个方法）
《3》 支持任务取消
《4》 看一下Wait方法中的实现逻辑
<1> 原始的WaitOne函数调用方式
// System.Threading.WaitHandle
[SecurityCritical]
[MethodImpl(MethodImplOptions.InternalCall)]
private static extern int WaitOneNative(SafeHandle waitableSafeHandle, uint millisecondsTimeout, bool hasThreadAffinity, bool exitContext);
<2> 新的Wait方式
        for (int i = 0; i < spinCount; i++)
        {
            if (this.IsSet)
            {
                return true;
            }
            if (i < num2)
            {
                if (i == num2 / 2)
                {
                    Thread.Yield();
                }
                else
                {
                    Thread.SpinWait(PlatformHelper.ProcessorCount * (4 << i));
                }
            }
            else
            {
                if (i % num4 == 0)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    if (i % num3 == 0)
                    {
                        Thread.Sleep(0);
                    }
                    else
                    {
                        Thread.Yield();
                    }
                }
            }
            if (i >= 100 && i % 10 == 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

其他的方式基本上和原来的内核版本保持一致。。。

二：SemaphoreSlim

 
三：ReaderWriterLockSlim

















