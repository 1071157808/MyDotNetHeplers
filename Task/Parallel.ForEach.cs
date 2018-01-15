using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ForeachDemo {
    class Program {
        static void Main (string[] args) {
            int[] nums = new int[10];
            Parallel.For (0, nums.Length, (item) => {
                //do logic
                var temp = nums[item];
            });
            Dictionary<int, int> dic = new Dictionary<int, int> () { { 1, 100 }, { 2, 200 }, { 3, 300 }
            };
            Parallel.ForEach (dic, (item) => {
                Console.WriteLine (item.Key);
            });
        }
    }
}