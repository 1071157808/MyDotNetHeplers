// 微软在 ASP.NET MVC5 中引入了一种新型路由：Attribute路由，顾名思义，Attribute路由是通过Attribute来定义路由。当然，MVC5也支持以前定义路由的方式，你可以在一个项目中混合使用这两种方式来定义路由。
// 在以前的版本中我们通常在 RouteConfig.cs 文件中通过以下方式来定义路由：
routes.MapRoute (
    name: "ProductPage",
    url: "{productId}/{productTitle}",
    defaults : new { controller = "Products", action = "Show" },
    constraints : new { productId = "\\d+" }
);
//在MVC5中，我们可以把路由定义和 Action 放在一起：
[Route ("{productId:int}/{productTitle}")]
public ActionResult Show (int productId) { ... }
//当然，首先得启用Attribute路由，我们可以调用MapMvcAttributeRoutes方法来启用Attribute路由：
public class RouteConfig {
    public static void RegisterRoutes (RouteCollection routes) {
        routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
        routes.MapMvcAttributeRoutes ();
    }
}
// URL可选参数和默认值
// 我们可以使用问号“?”来标记一个可选参数，也可以对参数设定默认值：
public class BooksController : Controller {
    // 匹配: /books
    // 匹配: /books/1430210079
    // 问号表示 isbn 是可选的
    [Route ("books/{isbn?}")]
    public ActionResult View (string isbn) {
        if (!String.IsNullOrEmpty (isbn)) {
            return View ("OneBook", GetBook (isbn));
        }
        return View ("AllBooks", GetBooks ());
    }
}
// 匹配: /books/lang
// 匹配: /books/lang/en
// 匹配: /books/lang/he
// 如果URL不传递 lang 参数，则lang的值为“en”
[Route ("books/lang/{lang=en}")]
public ActionResult ViewByLanguage (string lang) {
    return View ("OneBook", GetBooksByLanguage (lang));
}
//路由前缀
//有时候在同一个 Controller 中，所有 Action 匹配的 URL 都拥有相同的前缀，如下：
public class ReviewsController : Controller {
    // 匹配: /reviews
    [Route ("reviews")]
    public ActionResult Index () { ... }
    // 匹配: /reviews/5
    [Route ("reviews/{reviewId}")]
    public ActionResult Show (int reviewId) { ... }
    // 匹配: /reviews/5/edit
    [Route ("reviews/{reviewId}/edit")]
    public ActionResult Edit (int reviewId) { ... }
}
//我们看到 ReviewsController 下的所有 Action 前面都带有 "reviews"，这时我们可以在 Controller 上使用 [RoutePrefix]设置路由前缀，为每个 Action 所匹配的 URL 加上共同的前缀 "reviews"：
[RoutePrefix ("reviews")]
public class ReviewsController : Controller {
    // 匹配: /reviews
    [Route]
    public ActionResult Index () { ... }
    // 匹配: /reviews/5
    [Route ("{reviewId}")]
    public ActionResult Show (int reviewId) { ... }
    // 匹配: /reviews/5/edit
    [Route ("{reviewId}/edit")]
    public ActionResult Edit (int reviewId) { ... }
}
//但是，如果某一个 Action 不想要这个前缀怎么办？当然有办法，我们可以用波浪号“~”来去掉它：
[RoutePrefix ("reviews")]
public class ReviewsController : Controller {
    // 匹配: /spotlight-review
    [Route ("~/spotlight-review")]
    public ActionResult ShowSpotlight () { ... }
}
//默认路由
//我们除了可以在 Action 上使用[Route]外，也可以用在 Controller 上，当[Route]用在 Controller 上时，它就定义了一个默认路由规则，它会对这个 Controller 下的所有 Action 起作用，除非某个 Action 上也应用了 [Route] 特性覆盖了 Controller 上的[Route]。但要注意的是应用在 Controller 上的 [Route] 一定要加上 {action}，否则会抛出“RouteData 必须包含名为'action'且值为非空字符串的项。”错误。应用在 Action 上的 [Route] 则不用加，因为 {action} 就是当前 Action。
[RoutePrefix ("promotions")]
[Route ("{action=index}")]
//上面定义了默认路由，并且{action}的默认值为"index"，
//也就是说 URL 不包含 {action} 时，默认调用的 Action 是 Index。
public class ReviewsController : Controller {
    // 匹配: /promotions
    public ActionResult Index () { ... }
    // 匹配: /promotions/archive
    public ActionResult Archive () { ... }
    // 匹配: /promotions/new
    public ActionResult New () { ... }
    // 匹配: /promotions/edit/5
    // 这里覆盖了默认路由规则
    // 按照默认路由，这里应该匹配：/promotions/editProduct?promoId=5
    [Route ("edit/{promoId:int}")]
    public ActionResult EditProduct (int promoId) { ... }
}
//路由约束
//路由约束可以让你指定参数的类型以及范围等，格式为：{参数:约束}，举例如下：
// 匹配: /users/5
[Route ("users/{id:int}"]
    // 这里约束了参数“id”必须为整数类型
    public ActionResult GetUserById (int id) { ... }
    //下面是支持的路由约束列表：
    * alpha， 必须为大小写字母（ a - z， A - Z）， 如： { x : alpha }；
    * bool， 必须为布尔值， 如： { x : bool }
    * datetime， 必须为DateTime（ 时间和日期） 类型， 如： { x : datetime }
    * decimal， 必须为decimal类型， 如： { x : decimal }
    * double， 必须为64bit浮点数， 如： { x : double }
    * float， 必须为32bit浮点数， 如： { x : float }
    * guid， 必须为GUID， 如： { x : guid }
    * int， 必须为32bit整数， 如： { x : int }
    * length， 字符串长度必须为指定值或者在指定范围内， 如： { x : length (6) } { x : length (1, 20) }
    * long， 必须为64bit整数， 如： { x : long }
    * max， 小于等于指定值的整数， 如： { x : max (10) }
    * maxlength， 字符串长度小于等于指定值， 如： { x : maxlength (10) }
    * min， 大于等于指定值的整数整数， 如： { x : min (10) }
    * minlength， 字符串长度大于等于指定值， 如： { x : minlength (10) }
    * range， 必须是给定范围内的整数， 如： { x : range (10, 50) }
    * regex， 必须与正则表达式匹配， 如： {
        x: ( ^ \d { 3 } - \d { 3 } - \d { 4 }
                $)}
// 你可以在一个参数后面应用多个约束，用冒号分隔它们，如下：
// 匹配: /users/5
// 但是不匹配 /users/10000000000 因为id的值已经超过了int.MaxValue,
// 也不匹配 /users/0 因为后面有个min(1)约束，id 的值必须大于等于 1.
[Route ("
                users / { id: int: min(1) }
                ")]
public ActionResult GetUserById (int id) { ... }
// 值得注意的是加在可选参数上的约束，例如：
// 匹配: /greetings/bye
// 也匹配 /greetings 因为message是可选参数,
// 但是不匹配 /greetings/see-you-tomorrow 因为有maxlength(3)约束.
[Route ("
                greetings / { message: maxlength(3) ? }
                ")]
public ActionResult Greet (string message) { ... }
6、自定义路由约束
我们可以通过实现 IRouteConstraint 接口来自定义路由约束。下面的例子展示如何自定义路由约束：
public class ValuesConstraint : IRouteConstraint
{
    private readonly string[] validOptions;
    public ValuesConstraint (string options)
    {
        validOptions = options.Split ('|');
    }
    public bool Match (HttpContextBase httpContext, Route route,
    string parameterName, RouteValueDictionary values,
    RouteDirection routeDirection)
    {
        object value;
        if (values.TryGetValue (parameterName, out value) && value != null)
        {
            return validOptions.Contains (value.ToString (), StringComparer.OrdinalIgnoreCase);
        }
        return false;
    }
}
// 下面的代码是显示如何注册自定义的路由约束
public class RouteConfig
{
    public static void RegisterRoutes (RouteCollection routes)
    {
        routes.IgnoreRoute (" { resource }.axd / {* pathInfo }
                ");
        var constraintsResolver = new DefaultInlineConstraintResolver ();
        constraintsResolver.ConstraintMap.Add ("
                values ", typeof (ValuesConstraint));
        routes.MapMvcAttributeRoutes (constraintsResolver);
    }
}
// 现在我们就可以在代码中使用这些自定义的路由约束了：
public class TemperatureController : Controller
{
    // 匹配 temp/celsius 以及 /temp/fahrenheit 但不匹配 /temp/kelvin
    [Route ("
                temp / { scale: values(celsius | fahrenheit) }
                ")]
    public ActionResult Show (string scale)
    {
        return Content ("
                scale is " + scale);
    }
}
//路由名称
//你可以为路由规则指定一个名称，以方便生成相应的URL，举例如下：
[Route ("
                menu ", Name = "
                mainmenu ")]
public ActionResult MainMenu () { ... }
你可以使用 Url.RouteUrl 来生成相应的 URL：
<a href = "
                @Url.RouteUrl("
                mainmenu ")" > Main menu</ a>
                // Area
                //ASP.Net MVC 的 Area 概念对组织大型Web应用程序很有帮助，在Attribute路由中当然少不了对它的支持，只要使用 [RouteArea]，就可以把 Controller 归属到某一个 Area 下，这时你可以放心的删除 Area 下的 AreaRegistration 类了：
                [RouteArea ("Admin")]
                [RoutePrefix ("menu")]
                [Route ("{action}")] public class MenuController : Controller {
                    // 匹配: /admin/menu/logi
                    public ActionResult Login () { ... }
                    // 匹配: /admin/menu/show-options
                    [Route ("show-options")]
                    public ActionResult Options () { ... }
                    // 匹配: /stats
                    [Route ("~/stats")]
                    public ActionResult Stats () { ... }
                }
                // 现在你可以和以往的版本一样使用 "Admin" Area，下面的代码会生成 URL "/Admin/menu/show-options"：
                Url.Action ("Options", "Menu", new { Area = "Admin" })
                // 你还可以通过 AreaPrefix 来设置 Area 前缀，例如：
                [RouteArea ("BackOffice", AreaPrefix = "back-office")]
                // 如果你同时使用 Attribute、AreaRegistration 类这两种方式来注册 Area 的话，你应该在注册 Attribute 路由和传统路由映射之间使用 AreaRegistration 注册 Area，原因很简单，路由注册顺序必须是从最精确的匹配规则开始再到普通的匹配规则，最后才是模糊的匹配规则，这样就避免了在进行路由匹配时，过早的匹配了模糊规则，而相对精确的匹配起不到任何作用。下面的例子展示了这一点：
                public static void RegisterRoutes (RouteCollection routes) {
                    routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
                    routes.MapMvcAttributeRoutes ();
                    AreaRegistration.RegisterAllAreas ();
                    routes.MapRoute (
                        name: "Default",
                        url: "{controller}/{action}/{id}",
                        defaults : new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                    }