using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace async {
    class Program {
        static void Main (string[] args) {
            Method ();
            Console.WriteLine ("now right here");
            Console.ReadKey ();
        }
        public static async void Method () {
            await Task.Run (new Action (Speak));
            Console.WriteLine ("Here is contiune thread");
        }
        public static void Speak () {
            Thread.Sleep (20000);
            Console.WriteLine ("I am done");
        }
    }
}