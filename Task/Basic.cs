为什么要有Task。
Task => Thread + ThreadPool + 优化和功能扩展
Thread：        容易造成时间 + 空间开销，而且使用不当，容易造成线程过多，导致时间片切换
ThreadPool：    控制能力比较弱。 做thread的延续，阻塞，取消，超时等等功能都是做不了的，
因为threadpool控制权在CLR，而不是在我们这里
Task 看起来像是一个Thread
Task 是在ThreadPool的基础上进行的封装，结合了thread和threadpool的优点
.net 4.0之后，微软是极力的推荐 Task,来作为异步计算

Task<TResult>

让Task具有返回值, 它的父类其实就是Task
具体的启动方式和Task是一样的
这个thread和threadpool都没有这个功能



