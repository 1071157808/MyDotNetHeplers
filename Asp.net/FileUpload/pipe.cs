IServiceProvider provider = (IServiceProvider) HttpContext.Current;
HttpWorkerRequest wr = (HttpWorkerRequest) provider.GetService (typeof (HttpWorkerRequest));
byte[] bs = wr.GetPreloadedEntityBody ();
....
if (!wr.IsEntireEntityBodyIsPreloaded ()) {
    int n = 1024;
    byte[] bs2 = new byte[n];
    while (wr.ReadEntityBody (bs2, n) > 0) {
        .....
    }
}

//pipe这种大文件的读取方式我还没有尝试过