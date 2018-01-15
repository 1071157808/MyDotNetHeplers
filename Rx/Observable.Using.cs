// Observable.Using 处理资源文件

using System;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace DisposingFile {
    class Program {
        static void Main (string[] args) {
            // This observable sequence is based on a file stream that
            // must be cleaned up by calling dispose on it once
            // the sequence has been processed
            // 程序处理完了以后，这个资源类文件会被调用dispose关闭
            var observableCharacterSequence = Observable.Using<char, StreamReader> (
                    () =>
                    // StreamReader converts the stream of bytes from "characters.txt"
                    // into a stream of characters or a string depending.
                    // StreamReader implements IDisposable
                    new StreamReader (new FileStream ("characters.txt", FileMode.Open)),
                    // file is converted to string which converted to an array of
                    // characters that is enumerated by query
                    sr => (from c in sr.ReadToEnd ().ToCharArray () select c)
                    .ToObservable (Scheduler.NewThread));
            observableCharacterSequence.Subscribe (Console.WriteLine);
        }
    }
}

// -------------------------------------------------------------------
// Using处理完队列后， 会调用继承了IDisposable接口的Observer中的Dispose方法

using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace UsingUsing {
    // Class that implments dispose
    // used to show basic mechanics of Using
    class MyDispose : IDisposable {
        public void Dispose () {
            Console.WriteLine ("I've been disposed");
        }
    }
    class Program {
        static void Main (string[] args) {
            var query = from number in Enumerable.Range (1, 10) select number;
            // observable sequence run on a new thread
            var observableQuery = query.ToObservable (Scheduler.NewThread);
            // observable sequence that adds disposable object to the
            // objects that Rx will clean up when when it is finish processing
            // sequence
            var observableWithDispose = Observable.Using<int, MyDispose> (
                    // object that implements IDisposable, that Rx will Dispose on
                    // once the sequence has been processed
                    () => new MyDispose (),
                    // observable sequence this disposable object is being
                    // attached to. Notice that the disp param isn't used in this example
                    disp => observableQuery);
            // check console output and you will see that MyDispose.Dispose
            // is called after the sequence has been processed
            observableWithDispose.Subscribe (Console.WriteLine);
            Console.Read ();
        }
    }
}