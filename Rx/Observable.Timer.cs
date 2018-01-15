using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimerDemo {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (DateTime.Now);
            var observable = Observable.Timer (
                    //这个时间是当前时间加上这个时间，就是需要等待的时间
                    TimeSpan.FromSeconds (10),
                    //这个时间是间隔时间
                    TimeSpan.FromSeconds (3)
                )
                .Timestamp ();
            // or, equivalently 同等的
            // var observable = Observable.Timer(DateTime.Now + TimeSpan.FromSeconds(5),
            //                                                TimeSpan.FromSeconds(1)).Timestamp();
            using (observable.Subscribe (
                x => Console.WriteLine ("{0}: {1}", x.Value, x.Timestamp))) {
                Console.WriteLine ("Press any key to unsubscribe");
                Console.ReadKey ();
            }
            Console.WriteLine ("Press any key to exit");
            Console.ReadKey ();
        }
    }
}


//  --------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
namespace UsingTimer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting");
            var period = TimeSpan.FromSeconds(.5);
            var done = new ManualResetEvent(false);
            var sequence = Observable.Timer(DateTimeOffset.Now + TimeSpan.FromSeconds(4), period)
                .Finally(() => done.Set())
                .Skip(5)
                .Take(3);
            sequence.Subscribe(t => Console.WriteLine("Step {0}  Elapsed {1} seconds", t, t*period.TotalSeconds));
            done.WaitOne();
            Console.WriteLine("Finished");
            Console.Read();
        }
    }
}





