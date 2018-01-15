Stack ss = newStack ();
ss.Push (1);
ss.Push (2);
ss.Push ("jingya");
Console.WriteLine (ss.Count);
Console.WriteLine (ss.Peek ());
ss.Pop ();
Console.WriteLine (ss.Peek ());
Console.ReadKey ();