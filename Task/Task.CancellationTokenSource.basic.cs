一：task中的取消功能
1. thread。在这个种如何做取消操作。。。
isstop变量取判断thread中是否可以退出。。。。 low。。。
不能让多个线程操作一个共享变量，否则会在release版本中有潜在bug。。。。
2. task中有一个专门的类【CancellationTokenSource】去处理 “任务取消”
CancellationTokenSource 远比 isStop这个变量强的多。。。
1. 使用cancel实现isStop同样的功能。。。
强在哪里？？？？
<1> 当任务取消的时候，我希望有一个函数能够被触发，这个触发可以做一些资源的清理，
    又或者是更新数据库信息。。。
<2> 延时取消
我想2秒之后自动取消，N秒。。。。 webservice。。。wcf。



《1》 CancelAfter   
 source.CancelAfter(new TimeSpan(0, 0, 0, 1));
《2》 CancellationTokenSource 的构造函数中进行取消
CancellationTokenSource source = new CancellationTokenSource(1000);
<3> 取消的组合 将CancellationTokenSource 组合成一个链表
    其中任何一个CancellationTokenSource被取消，组合source也会被取消。。。
    var s3= s1 && s2;
<4> ThrowIfCancellationRequested 比 IsCancellationRequested 多了throw。。。
    如果一个任务被取消，我希望代码抛出一个异常。。。
    if(IsCancellationRequested) throw new Exception("adasdaf");
     == 等价操作  ==     
    throwIfCancellationRequested




