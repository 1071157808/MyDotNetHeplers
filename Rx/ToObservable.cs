static void Main (string[] args) {
    var observable = MyAdHoSequence ().ToObservable ();
    observable.Subscribe (Console.WriteLine);
}
static IEnumerable<int> MyAdHoSequence () {
    yield return 1;
    yield return 2;
    yield return 3;
}


var numbers = from number in new int[] { 1, 2, 3 } select number;
默认是SingleThread单线程的
	1. var observableNumbers = numbers.ToObservable()
会新开一个单线程来处理
	2. var observableNumbers = numbers.ToObservable(Scheduler.NewThread) 
线程池是后台线程，程序中只要前台线程执行完就关闭程序，不管后台线程是否正在操作
    3. var observableNumbers = numbers.ToObservable(Scheduler.ThreadPool);  

