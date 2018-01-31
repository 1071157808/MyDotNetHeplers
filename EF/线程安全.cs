因为 DbContext 不是线程安全的， 所以我们在多线程应用程序运用它的时候， 要注意下面两点：

    *
    同一时刻， 一个上下文只能执行一个异步方法。 *
    实体状态改变， 对应一个上下文， 不能跨上下文修改实体状态， 也不能跨上下文应用实体状态。

//正确用法
using (var context = new TestDbContext2 ()) {
    var clients = await context.Clients.ToListAsync ();
    var servers = await context.Servers.ToListAsync ();
}

//错误用法
using (var context = new TestDbContext2 ()) {
    var clients = context.Clients.ToListAsync ();
    var servers = context.Servers.ToListAsync ();
    await Task.WhenAll (clients, servers);
}
//这个写法会导致下面的异常
A second operation started on this context before a previous asynchronous operation completed. 
在这个上下文，第二个操作开始于上一个异步操作完成之前

Use 'await' to ensure that any asynchronous operations have completed 
before calling another method on this context. 
在这个上下文，使用 await 来确保所有的异步操作完成于另一个方法调用之前。

Any instance members are not guaranteed to be thread safe.
所有实例成员都不能保证是线程安全的。