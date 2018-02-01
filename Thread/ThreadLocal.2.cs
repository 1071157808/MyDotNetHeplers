//ThreadStatic Initialize only on first thread,
//ThreadLocal Initialize
//for each thread.Below is the simple demonstration:

    public static ThreadLocal<int> _threadlocal =
        new ThreadLocal<int> (() => {
            return Thread.CurrentThread.ManagedThreadId;
        });

    public static void Main () {
        new Thread (() => {
            for (int x = 0; x < _threadlocal.Value; x++) {
                Console.WriteLine ("First Thread: {0}", x);
            }
        }).Start ();

        new Thread (() => {
            for (int x = 0; x < _threadlocal.Value; x++) {
                Console.WriteLine ("Second Thread: {0}", x);
            }
        }).Start ();

        Console.ReadKey ();
    }

//下面的结果说明：ThreadLocal 对每个使用者来说都初始化了一遍
// First Thread: 0
// Second Thread: 0
// Second Thread: 1
// Second Thread: 2
// Second Thread: 3
// First Thread: 1
// First Thread: 2
