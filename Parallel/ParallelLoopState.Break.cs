早上终于理解了Parallel的ParallelLoopState.Break的函数的用法
我来用自己的意思解释一下：
通常在Parallel.For中会设置一个锁
  Monitor.Enter(rnd);
  delay = rnd.Next(1, 1001);
  Monitor.Exit(rnd);
当某个线程在使用的时候，其他线程是在排队等待的，也就是说在某个原子时刻，只有一个线程在执行
当某个线程触发了ParallelLoopState.Break函数，那么ParallelLoopState .ShouldExitCurrentIteration则会变为true
ParallelLoopState.LowestBreakIteration会变为当前所有并发的线程池中序号i最小的那个值，其他的所有正在执行的线程i都大于这个值，这样我们可以对其他大于这个值得线程进行一些操作，不想操作的话直接return 返回就行了








