//普通的RouteConfig的写法
public class RouteConfig {
    public static void RegisterRoutes (RouteCollection routes) {
        routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
        routes.MapRoute (
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults : new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
}
//------------------------------------------------------------------------------------------------
//伪静态配置例子
routes.MapRoute(
    name: "Default2",
    url: "{controller}-{action}-{id}",
    defaults: new {
        controller = "Home",
        action = "Index",
        id = UrlParameter.Optional
        },
    constraints:
    new { controller = @"\d{4}", httpMethod = new HttpMethodConstraint("GET") }
);

//-------------------------------------------------------------------------------------------------
//具体的一个实例
// 酒店列表页匹配r
routes.MapRoute (
    "酒店列表页", "hotels/{action}-{city}-{price}-{star}",
    new { controller = "Hotel", action = "list", city = "beijing", price = "-1,-1", star = "-1" },
    new { city = @"[a-zA-Z]*", price = @"(\d)+\,(\d)+", star = "[-1-5]" }
); // 酒店频道所有匹配
routes.MapRoute ("酒店首页", "hotels/{*iiii}", new { controller = "Hotel", action = "default", hotelid = "" }); // 网站首页默认匹配
routes.MapRoute ("网站首页", "{*values}", new { controller = "Home", action = "index" });
public static void RegisterRoutes (RouteCollection routes) {
    routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
    routes.MapRoute ("Action1Html", // action伪静态
        "{controller}/{action}.html", // 带有参数的 URL
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    );
    routes.MapRoute (
        "IDHtml", // id伪静态
        "{controller}/{action}/{id}.html", // 带有参数的 URL
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    );
    routes.MapRoute (
        "ActionHtml", // action伪静态
        "{controller}/{action}.html/{id}", // 带有参数的 URL
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    );
    routes.MapRoute (
        "ControllerHtml", // controller伪静态
        "{controller}.html/{action}/{id}", // 带有参数的 URL
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    );
}
//①name参数：
//规则名称, 可以随意起名。不可以重名，否则会发生错误: “路由集合中已经存在名为“Default”的路由。路由名必须是唯一的”。
//②url参数：
//url获取数据的规则，这里不是正则表达式，将要识别的参数括起来即可，比如: {controller}/{action}
//最少只需要传递name和url参数就可以建立一条Routing(路由)规则，比如实例中的规则完全可以改为:
//routes.MapRoute( “Default”, “{controller}/{action}”);
//③defaults参数:
//url参数的默认值：如果一个url只有controller: localhost/home/，而且我们只建立了一条url获取数据规则: {controller}/{action}，那么这时就会为action参数设置defaults参数中规定的默认值。由于defaults参数是Object类型，所以可以传递一个匿名类型来初始化默认值：new { controller = “Home”, action = “Index” }。
//在ASP.Net MVC网站默认实例中使用的是三个参数的MapRoute方法:
//④constraints参数:
//用来限定每个参数的规则或Http请求的类型。constraints属性是一个RouteValueDictionary对象，也就是一个字典表，但是这个字典表的值可以有两种类型：
//一是：用于定义正则表达式的字符串（正则表达式不区分大小写）。通过使用正则表达式可以规定参数格式，比如controller参数只能为4位数字：new { controller = @”\d{4}”}