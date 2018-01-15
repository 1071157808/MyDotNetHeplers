//AuthorizeAttribute的OnAuthorization方法内部调用了AuthorizeCore方法
//这个方法是实现验证和授权逻辑的地方，如果这个方法返回true，
//表示授权成功，如果返回false， 表示授权失败
//会给上下文设置一个HttpUnauthorizedResult，这个ActionResult执行的结果是向浏览器返回
public class CheckLoginAttribute : AuthorizeAttribute {
    protected override bool AuthorizeCore (HttpContextBase httpContext) {
        bool Pass = false;
        if (!CheckLogin.AdminLoginCheck ()) {
            httpContext.Response.StatusCode = 401; //无权限状态码
            Pass = false;
        } else {
            Pass = true;
        }
        return Pass;
    }
    protected override void HandleUnauthorizedRequest (AuthorizationContext filterContext) {
        base.HandleUnauthorizedRequest (filterContext);
        if (filterContext.HttpContext.Response.StatusCode == 401) {
            filterContext.Result = new RedirectResult ("/");
        }
    }
}

四叔身份证：
630104197006201517
