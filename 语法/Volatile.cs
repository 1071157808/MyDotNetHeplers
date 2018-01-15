using System;
using System.Threading;
public class Worker {
    // This method is called when the thread is started.
    public void DoWork () {
        while (!_shouldStop) {
            Console.WriteLine ("Worker thread: working...");
        }
        Console.WriteLine ("Worker thread: terminating gracefully.");
    }
    public void RequestStop () {
        _shouldStop = true;
    }
    // Keyword volatile is used as a hint to the compiler that this data
    // member is accessed by multiple threads.
    private volatile bool _shouldStop;
}
public class WorkerThreadExample {
    static void Main () {
        // Create the worker thread object. This does not start the thread.
        Worker workerObject = new Worker ();
        Thread workerThread = new Thread (workerObject.DoWork);
        // Start the worker thread.
        workerThread.Start ();
        Console.WriteLine ("Main thread: starting worker thread...");
        // Loop until the worker thread activates.
        // 等待，直到workerThread线程开启
        while (!workerThread.IsAlive);
        // Put the main thread to sleep for 1 millisecond to
        // allow the worker thread to do some work.
        //主线程休息，让workerThread工作一些时间
        Thread.Sleep (1);
        // Request that the worker thread stop itself.
        workerObject.RequestStop ();
        // Use the Thread.Join method to block the current thread
        // until the object's thread terminates.
        //thread.Join()方法会造成当前进程（主进程）等待，直到其他正在执行的进程结束
        //在这里就是主线程等待workerThread线程执行结束
        workerThread.Join ();
        Console.WriteLine ("Main thread: worker thread has terminated.");
    }
    // Sample output:
    // Main thread: starting worker thread...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: working...
    // Worker thread: terminating gracefully.
    // Main thread: worker thread has terminated.
}