using System;
using System.Linq;
using System.Reactive.Linq;

namespace AllDelegates {
    class Program {
        static void Main (string[] args) {
            // make an array of numbers
            var numbers = from number in new int[] { 1, 2, 0, 3 } select 10 / number;
            // make an observeable sequence out of those numbers
            var observable = numbers.ToObservable ();
            // use the ObservableExtensions.Subscribe to start the callbacks
            observable.Subscribe (Output, Oops, Done);
        }
        // called each time a value from the observable sequence is processed
        static void Output (int number) {
            Console.WriteLine (number);
        }
        // called if the processing of the observable sequence throws exception
        static void Oops (Exception exception) {
            Console.WriteLine (@"Oops ""{0}""", exception.Message);
        }
        // called after all values in the observable sequence have been processed
        static void Done () {
            Console.WriteLine ("I'm Done");
        }
    }
}