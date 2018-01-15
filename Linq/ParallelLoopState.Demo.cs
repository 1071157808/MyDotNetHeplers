
using System;
using System.Threading;
using System.Threading.Tasks;
public class Example
{
    public static void Main()
    {
        var rnd = new Random();
        int breakIndex = rnd.Next(1, 5);
        Nullable<long> lowest = new Nullable<long>();
        Console.WriteLine("Will call Break at iteration {0}\n",
                          breakIndex);
        var result = Parallel.For(1, 5, (i, state) =>
        {
            Console.WriteLine("Beginning iteration {0}", i);
            int delay;
            Monitor.Enter(rnd);
            delay = rnd.Next(1, 1001);
            Monitor.Exit(rnd);
            Thread.Sleep(delay);
            if (state.ShouldExitCurrentIteration)
            {
                if (state.LowestBreakIteration < i)
                    return;
            }
            if (i == breakIndex)
            {
                Console.WriteLine("Break in iteration {0}", i);
                state.Break();
                if (state.LowestBreakIteration.HasValue)
                    if (lowest < state.LowestBreakIteration)
                        lowest = state.LowestBreakIteration;
                    else
                        lowest = state.LowestBreakIteration;
            }
            Console.WriteLine("Completed iteration {0}", i);
        });
        if (lowest.HasValue)
            Console.WriteLine("\nLowest Break Iteration: {0}", lowest);
        else
            Console.WriteLine("\nNo lowest break iteration.");
        Console.ReadKey();
        //输出结果：
        //Will call Break at iteration 2
        //Beginning iteration 1
        //Beginning iteration 2
        //Beginning iteration 3
        //Beginning iteration 4
        //Completed iteration 1
        //Break in iteration 2
        //Completed iteration 2
        //Lowest Break Iteration: 2
    }
}
