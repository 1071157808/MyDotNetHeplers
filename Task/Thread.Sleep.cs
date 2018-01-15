Console.WriteLine("this is a sleep function test");
Thread.Sleep(5000);
Console.WriteLine("this is new thread function");
//注意：避免在正式的生产代码中使用Sleep()函数
//1.没有参数就是没有延迟时间设置，相当于没有写
//2.使用sleep(时间设定值)来同步的程序被成为”穷人的同步“