using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
namespace SkipIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = (from number in new int[] { 4, 5,1, 2, 3,6, 3, 1, 0,6,3,2 } select number)
                .ToObservable();
            //skipwhile中可以使用一个value和position来进行筛选
            //value是制定一个位置，筛选出满足条件的开始的位置
            //position是从value判断后的位置开始倒数满足条件的位置，找到第一个满足条件的位置并返回
            sequence.SkipWhile((value, position) => value <= 5 && position < 4)
                .Subscribe(Console.WriteLine);
            Console.Read();
        }
    }
}

// ----------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
namespace SkipPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = (from number in new int[] {4, 5, 3, 6, 2, 1, 0} select number)
                .ToObservable();
            //当skipwhile内的表达式成功的时候，就一直跳过，遇到第一个不符合规则的时候，以后的不再使用skip判断
            sequence.SkipWhile(value => value <= 5).Subscribe(Console.WriteLine);
            Console.Read();
        }
    }
}
