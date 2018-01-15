using System;
using System.Linq;
using System.Reactive.Linq;
namespace PrimitiveSubscribe {
    class Program {
        static void Main (string[] args) {
            var observable = (new int[] { 1, 2, 3 }).ToObservable ();
            var myObserver = new MyObserver ();
            observable.Subscribe (myObserver);
        }
    }
    class MyObserver : IObserver<int> {
        public void OnCompleted () {
            Console.WriteLine ("I'm done");
        }
        public void OnError (Exception error) {
            Console.WriteLine ("Error {0}", error.Message);
        }
        public void OnNext (int value) {
            Console.WriteLine (value);
        }
    }
}