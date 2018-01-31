const int res = 1000;
static void Main (string[] args) {
    ThreadPool.QueueUserWorkItem (DoWork, "sss"); // 可以加个逗号传参数进去
    for (int i = 0; i < res; i++) {
        Console.Write ("-");
    }
    Console.ReadKey ();
}
static void DoWork (object ss) // 方法的参数必须是一个，且只能是可以转换为object的类型
{
    for (int i = 0; i < res; i++) {
        Console.Write ("+");
    }
}