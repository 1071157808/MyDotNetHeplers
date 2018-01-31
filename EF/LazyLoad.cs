懒加载
使用的是动态代理，默认情况下，如果POCO类满足以下两个条件，EF就使用Lazy Loading:
1. POCO类是Public且不为Sealed。
2. 导航属性标记为Virtual。


关闭懒加载
ctx.Configuration.LazyLoadingEnabled=false;


知识点
ToList过的表就不用延迟加载了，这个会直接导到内存中
