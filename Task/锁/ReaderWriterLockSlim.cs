1. 用EnterReadLock 带代替AcquireReaderLock 方法， 性能比内核版本要高得多。。

ReaderWriterLockSlim slim = new ReaderWriterLockSlim ();
slim.EnterReadLock ();
slim.ExitReadLock ();
slim.EnterWriteLock ();
slim.ExitWriteLock ();

//旧的写法
ReaderWriterLock rwlock = new ReaderWriterLock ();
//rwlock.AcquireReaderLock()
Console.Read ();

总结一下：
混合锁大量的使用了3个变量，
thread.sleep (0)
thread.sleep (1)
thread.Yield ()
混合锁： 先在用户模式下内旋， 如果超过一定的阈值， 会切换到内核锁。。。
在内旋的情况下， 我们会看到大量的Sleep (0), Sleep (1), Yield等语法。。。