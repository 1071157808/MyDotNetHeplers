Task tt = Task.Run (
    () => {
        for (int count = 0; count < res; count++) {
            Console.Write ("-");
        }
    }
);
tt.Wait (); // 当前线程等待tt线程结束后再执行
// Task.WaitAll(tt); // 另一种写法
for (int i = 0; i < res; i++) {
    Console.Write ("+");
}
Console.ReadKey ();