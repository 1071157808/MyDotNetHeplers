

private static double _Run(string description, Action<int, int> action, int a, int b)
{
    if (action == null) throw new ArgumentNullException("action");
    // 启动计时器
    var stopwatch = Stopwatch.StartNew();
    // 运行要测量的代码
    action(a, b);
    // 终止计时
    stopwatch.Stop();
    // 输出结果
    Console.WriteLine("{0}: {1}", description, stopwatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
    // 返回执行时间
    return stopwatch.Elapsed.TotalMilliseconds;
}
