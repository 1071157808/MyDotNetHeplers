一： task的阻塞和延续操作
这些都是task的核心
1. 阻塞
thread => Join方法【 让调用线程阻塞】
Task:
WaitAll方法 必须其中所有的task执行完成才算完成
WaitAny方法， 只要其中一个task执行完成就算完成
task.wait方法： 等待操作
上面这些等待操作， 返回值都是void。。。。
现在有一个想法就是， 我不想阻塞主线程实现一个waitall的操作。。。。
t1 执行完成了执行 t2， 这就是延续的概念（ 异步）
WhenAll
WhenAny
Task工厂中的一些延续操作。。。
ContinueWhenAll
ContinueWhenAny
本节课就是介绍Task的7种阻塞方式 + 延续
如果会打组合拳， task异步任务还是写的非常漂亮。。。。
WaitAll与 WhenAll区别
Task.WaitAll blocks the current thread until everything has completed.终端当前的线程知道所有的线程完成

TaskEx.WhenAll returns a task which represents the action of waiting until everything has completed.返回一个task， 这个task等待所有的事情完成

在并发编程中， task类有两个作用
1. 作为并行任务
可使用阻塞函数 task.wait task.waitAll task.WaitAny task.Result

2. 作为异步任务
使用await task.whenAll Task.WhenAny

遇到这种问题其实就是应该使用异步的task来解决问题， 而不是用并行的task的方法