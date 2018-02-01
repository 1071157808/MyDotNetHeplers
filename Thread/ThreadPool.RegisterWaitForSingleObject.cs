  static void Main (string[] args) {
      ThreadPool.RegisterWaitForSingleObject (
          new AutoResetEvent (true), 
          new WaitOrTimerCallback ((obj, b) => {
            //做逻辑判断，判断是否在否以时刻执行。。。
            Console.WriteLine ("obj={0}，tid={1}, datetime={2}", obj, Thread.CurrentThread.ManagedThreadId,
                DateTime.Now);
      }), "hello world", 1000, false);

      Console.Read ();
  }


  //ThreadPool 定时器功能
  //定时器的功能肯定需要 工作线程来处理
  //ThreadPool中的线程有分类，工作线程work thread可以调用多个IO线程，IO Thread

  
System.threading    下面有timer  ，这个timer是最底层的，多用这个

System.Timer        下面也有Timer，这是封装过的，下面一样

System.Windows.Form 下面Timer。。。

System.Web.UI        下面Timer。。。


Timer底层有一个队列    TimerQueue instance2 = TimerQueue.Instance;

internal class TimerQueue

Timer 首先是用 ThreadPool.UnsafeQueueUserWorkItem(waitCallback, timer); 来完成定时功能


实战开发中，基本上不会用Timer来处理问题。。。。

因为处理的功能太少：

用其他的定时框架 如Quarz.net