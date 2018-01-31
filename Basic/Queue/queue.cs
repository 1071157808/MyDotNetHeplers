Queue<T> 和Queue是先进先出(FIFO) 的数据结构
//通过Enqueue和Dequeue方法实现添加元素到队列的尾部和从队列的头部移除元素
Queue q = new Queue ();

q.Enqueue ('A');   添加元素到队列的尾部
q.Enqueue ('M');
q.Enqueue ('G');
q.Enqueue ('W');
System.Console.WriteLine(q.peek());  Peek方法从队列的头部获取一个元素（不移除该元素）
Console.WriteLine ("Current queue: ");
foreach (char c in q)
    Console.Write (c + " ");
Console.WriteLine ();
q.Enqueue ('V');
q.Enqueue ('H');
Console.WriteLine ("Current queue: ");
foreach (char c in q)
    Console.Write (c + " ");
Console.WriteLine ();
Console.WriteLine ("Removing some values ");
char ch = (char) q.Dequeue ();                     从队列头部移除元素
Console.WriteLine ("The removed value: {0}", ch);
ch = (char) q.Dequeue ();
Console.WriteLine ("The removed value: {0}", ch);
Console.ReadKey ();