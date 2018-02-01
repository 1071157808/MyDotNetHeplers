我们的Task底层都是由不同的TaskScheduler支撑的

TaskScheduler 相当于Task的CPU处理器

默认的TaskScheduler是ThreadPoolTaskScheduler

wpf中的TaskScheduler是 SynchronizationContextTaskScheduler

ThreadPoolTaskScheduler

this.m_taskScheduler.InternalQueueTask (this);

大家也可以自定义一些TaskScheduler

protected internal override void QueueTask (Task task) {
    if ((task.Options & TaskCreationOptions.LongRunning) != TaskCreationOptions.None) {
        new Thread (ThreadPoolTaskScheduler.s_longRunningThreadWork) {
            IsBackground = true
        }.Start (task);
        return;
    }
    bool forceGlobal = (task.Options & TaskCreationOptions.PreferFairness) > TaskCreationOptions.None;
    ThreadPool.UnsafeQueueCustomWorkItem (task, forceGlobal);
}

