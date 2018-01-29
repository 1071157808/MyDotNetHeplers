这种处理方式同样能够获取全局未处理异常，但相对于使用HttpModule的实现，显得不够灵活和通用。
HttpModule优先于Global中的Application_Error方法。


void Application_Error (object sender, EventArgs e) {
    //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
    Exception ex = Server.GetLastError ();
    //实际发生的异常
    Exception iex = ex.InnerException;

    string errorMsg = String.Empty;
    string particular = String.Empty;
    if (iex != null) {
        errorMsg = iex.Message;
        particular = iex.StackTrace;
    } else {
        errorMsg = ex.Message;
        particular = ex.StackTrace;
    }
    HttpContext.Current.Response.Write ("来自Global的错误处理<br />");
    HttpContext.Current.Response.Write (errorMsg);

    Server.ClearError (); //处理完及时清理异常
}