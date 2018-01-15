using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParallelLinq {
    //博文推荐
    //https://www.codeproject.com/articles/156980/parallelism-in-net-plinq
    class Program {
        static void Main (string[] args) {
            var customers = new [] {
                new Customer { ID = 1, FirstName = "Sandeep", LastName = "Ramani" },
                new Customer { ID = 2, FirstName = "Dharmik", LastName = "Chotaliya" },
                new Customer { ID = 3, FirstName = "Nisar", LastName = "Kalia" },
                new Customer { ID = 4, FirstName = "Ravi", LastName = "Mapara" },
                new Customer { ID = 5, FirstName = "Hardik", LastName = "Mistry" },
                new Customer { ID = 6, FirstName = "Sandy", LastName = "Ramani" },
                new Customer { ID = 7, FirstName = "Jigar", LastName = "Shah" },
                new Customer { ID = 8, FirstName = "Kaushal", LastName = "Parik" },
                new Customer { ID = 9, FirstName = "Abhishek", LastName = "Swarnker" },
                new Customer { ID = 10, FirstName = "Sanket", LastName = "Patel" },
                new Customer { ID = 11, FirstName = "Dinesh", LastName = "Prajapati" },
                new Customer { ID = 12, FirstName = "Jayesh", LastName = "Patel" },
                new Customer { ID = 13, FirstName = "Nimesh", LastName = "Mishra" },
                new Customer { ID = 14, FirstName = "Shiva", LastName = "Reddy" },
                new Customer { ID = 15, FirstName = "Jasmin", LastName = "Malviya" },
                new Customer { ID = 16, FirstName = "Haresh", LastName = "Bhanderi" },
                new Customer { ID = 17, FirstName = "Ankit", LastName = "Ramani" },
                new Customer { ID = 18, FirstName = "Sanket", LastName = "Shah" },
                new Customer { ID = 19, FirstName = "Amit", LastName = "Shah" },
                new Customer { ID = 20, FirstName = "Nilesh", LastName = "Soni" }
            };
            var results = from c in customers
            where c.FirstName.StartsWith ("San")
            select c;
            //使用Parallel并行查询
            var resultsUserParallel = from c in customers.AsParallel ()
            where c.FirstName.StartsWith ("San")
            select c;
            //对并行查询的结果排序，AsOrdered影响性能，最好不用
            var resultsUserAsOrdered = from c in customers.AsParallel ().AsOrdered ()
            where c.FirstName.StartsWith ("San")
            select c;
            //强制使用Parallel并行查询，如果让AsParallel自己决定的话
            //有可能它会选择原来的Linq的执行方式
            var resultsForceParallelism = from c in customers.AsParallel ().WithExecutionMode (ParallelExecutionMode.ForceParallelism)
            where c.FirstName.StartsWith ("San")
            select c;
            //确定并行执行使用CPU的最多的数量
            var resultsDegreeOfParallelism = from c in customers.AsParallel ().WithDegreeOfParallelism (2)
            where c.FirstName.StartsWith ("San")
            select c;
            //随机产生一个有序的数
            IEnumerable<int> evens = ((ParallelQuery<int>) ParallelEnumerable.Range (0, 50000))
                .Where (i => i % 2 == 0)
                .Select (i => i).ToList ();
            //使用并行产生重复的数字ParallelQuery<TResult>
            int sum = ParallelEnumerable.Repeat (2, 50000).Select (i => i).Sum ();
            Console.WriteLine (sum);
            Console.ReadKey ();
        }
    }
    public class Customer {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}