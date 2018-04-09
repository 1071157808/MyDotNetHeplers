最重要的文章
https: //msdn.microsoft.com/zh-cn/magazine/jj991977.aspx

上面的文章讲的是async和awai最常见的死锁问题
public static class DeadlockDemo {
    private static async Task DelayAsync () {
        await Task.Delay (1000);
    }
    // This method causes a deadlock when called in a GUI or ASP.NET context.
    public static void Test () {
        // Start the delay.
        var delayTask = DelayAsync ();
        // Wait for the delay to complete.
        delayTask.Wait ();
    }
}

这个死锁产生的原因:
在Test中执行一个异步方法的时候，会将上下文(gui或者asp.net使用的是SynchronizationContext，
上下文为null则使用的是TaskScheduler)保存起来，等待恢复后执行
---注意：GUI 和 ASP.NET 应用程序具有 SynchronizationContext，它每次仅允许一个代码区块运行-----
而进入DelayAsync异步方法后，这个方法在完成时，会尝试捕获上下文，而这个上下文已经被占用，所以两个
线程相互等待，造成死锁。

请注意，控制台应用程序不会形成这种死锁。 它们具有线程池 SynchronizationContext 
而不是每次执行一个区块的 SynchronizationContext，因此当 await 完成时，它会在线程池线程上安排
 async 方法的剩余部分。 该方法能够完成，并完成其返回任务，因此不存在死锁。

解决方法：
1.async和await成对使用
var data = await GetDataAsync()   //await应该对这个上下文做了一些操作
2.使用这种方式
var data = Task.Run(GetDataAsync).Result


async， await只是用来解放服务器的压力， 提高服务器的工作效率的工作模式，
浏览器端并没有什么变化， 例子： 客人（ 客户端） 去KFC点餐， 点餐员（ 服务器线程池） 点完后交给后台处理，
点餐员继续下一位客户（ 异步）， 上一位客户端等待后台结束后取得用餐， 点餐结束。
可见这个是后台的优化操作， 和前端没啥关系， 如果前端也自己把页面写成了异步的，
那就就是页面的操作优化了， 和服务器端也没什么关系

从逐渐剖析Async中发现， Net提供的异步方式基本上一脉相承的, 如：
1. net4 .5 的Async， 抛去语法糖就是Net4 .0 的Task + 状态机。
2. net4 .0 的Task， 退化到3 .5 即是(Thread、 ThreadPool) + 实现的等待、 取消等API操作。

一： async await
1. 这两个关键词适专用于处理一些文件IO。【 潜规则】 ThreadPool IOthread
网络IO， 文件IO都有一些异步方法。 MemoryStream， FileStream。 WebRequest
2. Task 是最大限度的压榨 work thread。。。
3. 好处： 1. 代码简洁， 把异步的代码形式写成了同步方式。。

4. 提高了开发效率
坏处： 如果你用同步的思维去理解， 容易出问题。。。 返回值对不上
我们在编译器层面看到的代码， 不见得是真的代码。。。

四： 异步IO处理的流程 压榨IOthread
work thread: 是应用程序主动使用
IO thread： 是clr反向通知的。。
如果你用同步IO， 会是什么样的呢？？？