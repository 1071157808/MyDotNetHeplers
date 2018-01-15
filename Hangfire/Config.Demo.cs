public class Startup {
    public void Configuration (IAppBuilder app) {
        app.UseHangfire (config => {
            config.UseAuthorizationFilters (new DontUseThisAuthorizationFilter ());

            config
                .UseSqlServerStorage (@"server=xxxxx;database=Hangfire;uid=sa;pwd=123.com")
                .UseMsmqQueues (@".\Private$\hangfire{0}", "default", "critical");
        });

        app.MapHangfireDashboard ();
    }
}

public class DontUseThisAuthorizationFilter : IAuthorizationFilter {
    public bool Authorize (IDictionary<string, object> owinEnvironment) {
        return true;
    }
}
// -----------------------------------------------------------
// 也可以使用下面的这个有权限验证的方法
public class CustomAuthorizationFilter : IAuthorizationFilter {
    public bool Authorize (IDictionary<string, object> owinEnvironment) {
        var context = new OwinContext (owinEnvironment);
        if (GlobalContext.Current.UserInfo == null) {
            string urls = "/Index/Login?url=" + context.Request.Uri.Host;
            context.Response.Redirect (urls);
            return false;
        }
        return true;
    }
}