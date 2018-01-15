var tokenSource = new CancellationTokenSource ();
var token = tokenSource.Token;
var task = Task.Factory.StartNew (() => {
    for (var i = 0; i < 1000; i++) {
        System.Threading.Thread.Sleep (1000);
        if (token.IsCancellationRequested) {
            Console.WriteLine ("Abort mission success!");
            return;
        }
    }
}, token);
token.Register (() => {
    Console.WriteLine ("Canceled");
});
Console.WriteLine ("Press enter to cancel task...");
Console.ReadKey ();
tokenSource.Cancel ();