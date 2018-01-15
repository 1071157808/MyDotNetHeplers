Console.WriteLine ("Before");
Task task1 = Task.Run (
    () => { Console.WriteLine ("Start with ....."); }
).ContinueWith ((a) => { Console.WriteLine ("continuing A ....."); }); // 这里面的的a其实是Task a，大概是方便lambda内部的函数调用吧
Task task2 = task1.ContinueWith (
    (a) => { Console.WriteLine ("continuing B ....."); }
);
Task task3 = task1.ContinueWith (
    (a) => { Console.WriteLine ("continuing C ....."); }
);
Task.WaitAll (task2, task3);
Console.WriteLine ("Finsihed");
Console.ReadKey ();