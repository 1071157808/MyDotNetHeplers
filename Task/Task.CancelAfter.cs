var cancelTokenSource = newCancellationTokenSource ();
//var cancelTokenSource = newCancellationTokenSource(3000);  //也可以这样声明
Task.Factory.StartNew (() => {
    while (!cancelTokenSource.IsCancellationRequested) {
        Console.WriteLine (DateTime.Now);
        Thread.Sleep (1000);
    }
}, cancelTokenSource.Token);

Console.WriteLine ("Press any key to cancel");
Console.ReadLine ();
cancelTokenSource.Cancel ();
//cancelTokenSource.CancelAfter(3000);  //也可以这样延时取消
Console.WriteLine ("Done");
Console.ReadLine ();

