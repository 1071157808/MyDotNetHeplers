https://technet.microsoft.com/zh-CN/library/system.threading.tasks.taskcontinuationoptions

LazyCancellation  
在延续取消的情况下，防止延续的完成直到完成先前的任务。
task1 -> continuewith  task2  -> continuewith -> task3
就是说，continuewith的时候，预先判断了source.token的值，结果发现任务已经取消。
这个时候，task2就不会执行了。。，但是task3和task2有延续。。。
有因为task2 和task1已经没有延续关系了。。。所以 task1和task3可以并行，
看似continuewith的关系得不到延续。。。。【并行】
TaskContinuationOptions.LazyCancellation 它的本质就是：
需要等待task1执行完成之后再判断source.token的状态。。。。 这样的话，
首先就形成了一条链： task1 -> task2 -> task3...



ExecuteSynchronously
task2 也希望使用 task1的线程去执行，这样可以防止线程切换
指定应同步执行延续任务。 指定此选项后，延续任务在导致前面的任务转换为其最终状态的相同线程上运行。
如果在创建延续任务时已经完成前面的任务，则延续任务将在创建此延续任务的线程上运行。 
如果前面任务的 CancellationTokenSource 已在一个 finally（在 Visual Basic 中为 Finally）块中释放，
则使用此选项的延续任务将在该 finally 块中运行。 只应同步执行运行时间非常短的延续任务。
由于任务以同步方式执行，因此无需调用诸如 Task.Wait 的方法来确保调用线程等待任务完成。


OnlyOnRanToCompletion
表示延续任务必须在前面task完成状态才能执行
指定只应在延续任务前面的任务已完成运行的情况下才安排延续任务。 如果前面任务完成的 Task.Status 
属性是 TaskStatus.RanToCompletion，则前面的任务会运行直至完成。 此选项对多任务延续无效


NotOnRanToCompletion
表示延续任务必须在前面task非完成状态才能执行
指定不应在延续任务前面的任务已完成运行的情况下安排延续任务。 如果前面任务完成的 
Task.Status 属性是 TaskStatus.RanToCompletion，则前面的任务会运行直至完成。
 此选项对多任务延续无效。


 注意：
 NotOnRanToCompletion，NotOnCanceled，NotOnFaulted 指不应在延续任务前面的任务“已经完成、已经取消、
    已有异常”的情况下，安排延续任务
 OnlyOnRanToCompletion，OnlyOnCanceled，OnlyOnFaulted 指只应在延续任务前面的任务“已经完成、已经取消、
    已有异常”的情况下，安排延续任务
