using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IntervalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //每间隔2秒输出一个整数，从0开始累加
            IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(2));
            using (observable.Subscribe(Console.WriteLine))
            {
                Console.WriteLine("Press any key to unsubscribe");
                Console.ReadKey();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
