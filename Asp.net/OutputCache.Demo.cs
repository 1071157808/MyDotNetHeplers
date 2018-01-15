[OutputCache(Duration=10,VaryByParam="none")]
public ActionResult TestCache(){}


[OutputCache(CacheProfile="outPutCache")]
public ActionResult TestCache({})

// 由于asp.net cache不能提供对外访问能力，因此，它不可能取代以mecache为代表的分布式缓存技术，
// 但它由于与不需要跨进程访问，效率也比分布式缓存速度更快，如果将ASP.NET Cache设计成一级缓存，
// 分布式缓存设计成二级缓存，就像CPU缓存那样，那么将能同时利用二者的优点，实现更快的功能和速度。


