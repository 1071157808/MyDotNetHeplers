   try {
       this.m_taskScheduler.InternalQueueTask (this);
   } catch (ThreadAbortException exceptionObject) {
       this.AddException (exceptionObject);
       this.FinishThreadAbortedTask (true, false);
   }

   internal void InternalQueueTask (Task task) {
       task.FireTaskScheduledIfNeeded (this);
       this.QueueTask (task);
   }

   protected internal override void QueueTask (Task task) {
       if ((task.Options & TaskCreationOptions.LongRunning) != TaskCreationOptions.None) {
           new Thread (ThreadPoolTaskScheduler.s_longRunningThreadWork) {
               //ThreadPoolTaskScheduler是默认使用的线程池
               IsBackground = true
           }.Start (task);
           return;
       }
       bool forceGlobal = (task.Options & TaskCreationOptions.PreferFairness) > TaskCreationOptions.None;
       ThreadPool.UnsafeQueueCustomWorkItem (task, forceGlobal);
   }