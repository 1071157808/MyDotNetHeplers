public class AspNetUnhandledExceptionModule : IHttpModule {

    public void Init (HttpApplication context) {
        context.Error += new EventHandler (context_Error);
    }

    public void context_Error (object sender, EventArgs e) {
        //此处处理异常
        HttpContext ctx = HttpContext.Current;
        HttpResponse response = ctx.Response;
        HttpRequest request = ctx.Request;

        //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
        Exception ex = ctx.Server.GetLastError ();
        //实际发生的异常
        Exception iex = ex.InnerException;

        response.Write ("来自ErrorModule的错误处理<br />");
        response.Write (iex.Message);

        ctx.Server.ClearError ();
    }
}

//--------在webconfig中加入下面的信息------------
<httpModules>
<add name="errorCatchModule" type="WebModules.AspNetUnhandledExceptionModule, WebModules" />
</httpModules>


