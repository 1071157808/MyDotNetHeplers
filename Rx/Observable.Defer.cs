// Observable.Defer 可以让其中定义的observes函数中的变量延迟

using System;
using System.Linq;
using System.Reactive.Linq;

namespace UsingDefer
{
    class Program
    {
        static void Main(string[] args)
        {
            // determines length of observable sequence
            var length = 3;
            // length of observable sequence is set when observable sequence is created
            var os1 = (from number in Enumerable.Range(1, length) select number).ToObservable();
            // we change the length
            length = 5;
            // Subscrition only produces 3 values because
            // length was 3 when observable sequence was created
            os1.Subscribe(Console.WriteLine);
            Console.WriteLine("Now try defered creation of observable sequence");
            // length is 5 at this point and observable sequence is
            // created using defer
            // Notice that the parameter of Defer is a factory, that is
            // a method that produces an observable sequence.
            // The method is not executed until the observable sequence
            // is subscribed to.
            var os = Observable.Defer(() => (from number in Enumerable.Range(1, length) select number).ToObservable());
            // length changed to 8
            length = 8;
            // subscription produces 8 values because
            // defered observable sequence is created at time
            // subscription
            os.Subscribe(Console.WriteLine);
        }
    }
}

