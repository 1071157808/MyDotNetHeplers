如果你在WCF中用Entity Framework来获取数据并返回实体对象， 那么对下面的错误一定不陌生。
接收对 http: //localhost:5115/ReService.svc 的 HTTP 响应时发生错误。这可能是由于服务终结点绑定未使用 HTTP 协议造成的。
    这还可能是由于服务器中止了 HTTP 请求上下文(可能由于服务关闭) 所致。 有关详细信息， 请参见服务器日志。

为什么会序列化失败
为了方便说明， 我们先做个示例来重现这个错误。
默认情况下， Entity Framework为了支持它的一些高级特性(延迟加载等)， 默认将自动生成代理类是设置为true
这种代理的方式导致wcf的序列化的问题

public MyContext () {
    this.Configuration.ProxyCreationEnabled = true;
}

我们可以通过自定义Attribute，加在服务契约上面，标识通过这个服务返回的方法都要进行反序列化
虽然这样可以解决问题，但是多一层序列化会影响效率，希望EF的后续版本可以解决问题吧。
