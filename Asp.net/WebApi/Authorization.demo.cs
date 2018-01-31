//我使用json格式序列化，所以将默认的xml序列化移除
public static class WebApiConfig {
    public static void Register (HttpConfiguration config) {
        // ...

        var json = config.Formatters.JsonFormatter;
        // 解决json序列化时的循环引用问题
        json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        // 移除XML序列化器
        config.Formatters.Remove (config.Formatters.XmlFormatter);
    }
}

//全局权限验证过滤器
//新建一个类继承自AuthorizationFilterAttribute，
//它有一个虚方法OnAuthorization，在权限验证的时候调用，重写这个方法来验证权限。

[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class WebApiAuthAttribute : AuthorizationFilterAttribute {
    public override void OnAuthorization (HttpActionContext actionContext) {
        // 这是一个基本例子，使用的ASP.NET Forms 身份验证
        var context = HttpContext.Current;
        if (context.User.Identity.IsAuthenticated == false) {
            PreUnauthorized (actionContext);
            return;
        }
    }

    private void PreUnauthorized (HttpActionContext actionContext) {
        // 如果用户没有登录，则返回一个通用的错误Model
        actionContext.Response = actionContext.Request.CreateResponse (
            HttpStatusCode.OK,
            new AjaxModel {
                StatusCode = AjaxStatusCode.Unauthorized,
                    Message = "该操作需要用户登录"
            });
    }
}


//全局异常过滤器
//新建一个类继承自ExceptionFilterAttribute，同样有一个虚方法OnException，重写这个方法来处理异常。
public override void OnException (HttpActionExecutedContext actionExecutedContext) {
    Logger.Error (actionExecutedContext.Exception);
    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse (
        HttpStatusCode.OK,
        new AjaxModel {
            StatusCode = AjaxStatusCode.InternalServerError,
                Message = actionExecutedContext.Exception.Message
        });
}

//最后只需要在WebApiConfig里面添加一个过滤器
config.Filters.Add(new WebApiErrorHandleAttribute());