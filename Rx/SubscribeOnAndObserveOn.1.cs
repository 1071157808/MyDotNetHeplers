
// ToObservable、SubscribeOn、ObserveOn分析对比
var observableNumbers = numbers
    //感觉这个和下面的这个SubscribeOn的意义是一样的
    //简单说这个是Subscribe事件流的线程管理方式
    //.ToObservable(Scheduler.NewThread)
    .ToObservable ()
    //SubscribeOn指的是在事件流迭代的（或者说流入的过程中的线程的处理方式）
    //简单说这个是Subscribe事件流的线程管理方式
    //给事件流OnNext动作一个线程
    //给OnError一个线程（如果可以执行）
    //给OnComplete一个线程
    .SubscribeOn (Scheduler.NewThread)
    //ObserveOn指的是在订阅者在执行时间的时候的线程的处理方式
    //简单说这个就是对observer的线程的管理方式
    //但是这个Observer针对的是事件流的每一个元素
    //所以操作的时候会给每个事件一个单独的线程
    .ObserveOn (Scheduler.NewThread)