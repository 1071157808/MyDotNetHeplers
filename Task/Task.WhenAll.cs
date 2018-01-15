using System;
using System.Collections.Generic;
usingSystem.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
public class Example {
    public static void Main () {
        int failed = 0;
        var tasks = new List<Task> ();
        String[] urls = {
            "www.adatum.com",
            "www.cohovineyard.com",
            "www.cohowinery.com",
            "www.northwindtraders.com",
            "www.contoso.com"
        };
        foreach (var value in urls) {
            var url = value;
            tasks.Add (Task.Run (() => {
                var png = new Ping ();
                try {
                    var reply = png.Send (url);
                    if (!(reply.Status == IPStatus.Success)) {
                        Interlocked.Increment (ref failed);
                        throw new TimeoutException ("Unable to reach " + url + ".");
                    }
                } catch (PingException) {
                    Interlocked.Increment (ref failed);
                    throw;
                }
            }));
        }
        Task t = Task.WhenAll (tasks);
        try {
            t.Wait ();
        } catch { }
        if (t.Status == TaskStatus.RanToCompletion)
            Console.WriteLine ("All ping attempts succeeded.");
        else if (t.Status == TaskStatus.Faulted)
            Console.WriteLine ("{0} ping attempts failed", failed);
    }
}

using System;
using System.Threading.Tasks;
namespace WhenAllDemo {
    class Program {
        static void Main () {
            Task<int> task1 = Task.Factory.StartNew (() => {
                //做一些逻辑运算
                return 1;
            });
            Task<int> task2 = Task.Factory.StartNew (() => {
                //做一些逻辑运算
                return 2;
            });
            var task = Task.WhenAll<int> (new Task<int>[2] { task1, task2 });
            var result = task.Result;
            Console.WriteLine (task2.Result);
            Console.Read ();
        }
    }
}