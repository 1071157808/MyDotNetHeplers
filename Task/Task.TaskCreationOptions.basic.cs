TaskCreationOptions ：
1. AttachedToParent  ：指定将任务附加到任务层次结构中的某个父级
建立了父子关系。。。  父任务想要继续执行，必须等待子任务执行完毕
  看例子可以看到，其中是一个WaitAll的一个操作

2.DenyChildAttach： 不让子任务附加到父任务上去

3.HideScheduler： 子任务默认不使用父类的Task的Scheduler,而是使用默认的。

4.LongRunning：如果你明知道是长时间运行的任务，建议你使用此选项。。
 长时间使用线程，  建议使用 “Thread” 而不是“threadPool"。
 租车公司车少了，租车公司多租车，还车导致车增多，CPU不够，引起效率降低

如果长期租用不还给threadPool,threadPool为了满足市场需求，会新开一些线程
满足当前使用，如果此时租用线程被归还，这会导致ThreadPool的线程过多，销毁和
调度都是一个很大的麻烦

5.PreferFairness： 给你的感觉就是一个”queue“的感觉
对开发来说，用不用这个没啥关系
会将Task放入到ThreadPool的全局队列中, 让work thread进行争抢
默认情况会放到task的一个本地队列中

6.RunContinuationsAsynchronously 
强制异步执行添加到当前任务的延续任务。