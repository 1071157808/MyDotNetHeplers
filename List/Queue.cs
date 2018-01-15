Queue qq = newQueue ();
qq.Enqueue (10);
qq.Enqueue (22);
Console.WriteLine (qq.Count);
Console.WriteLine (qq.Peek ()); // 弹出第一个数组元素
Console.WriteLine (qq.Dequeue ()); // 从queue头移除对象
Console.WriteLine (qq.Peek ()); // 返回第一个元素但不移除
var i = qq.ToArray (); // 返回的是object[] 数组
Console.WriteLine (i.GetType ());
Console.ReadKey ();