static void Main (string[] args) {
    var task1 = new Task (() => {
        Console.WriteLine ("Task 1 Begin");
        System.Threading.Thread.Sleep (2000);
        Console.WriteLine ("Task 1 Finish");
    });
    var task2 = new Task (() => {
        Console.WriteLine ("Task 2 Begin");
        System.Threading.Thread.Sleep (3000);
        Console.WriteLine ("Task 2 Finish");
    });

    task1.Start ();
    task2.Start ();
    var result = task1.ContinueWith<string> (task => {
        Console.WriteLine ("task1 finished!");
        return "This is task result!";
    });

    Console.WriteLine (result.Result.ToString ());

    Console.Read ();
}