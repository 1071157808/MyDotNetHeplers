
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApplication8
{
    // 集合的并发，避免使用传统的锁(lock)机制等方式来处理并发访问集合.因此当有多个线程并发访问集合时，应首先考虑使用这些类代替 System.Collections 和 System.Collections.Generic 命名空间中的对应类型
    class BankAccount
    {
        public int Balance
        {
            get;
            set;
        }
    }
    class ConcurrentBagProgram
    {
        static void Main(string[] args)
        {
            //实现的是一个键 - 值集合类.它提供的方法有:
            //TryAdd:尝试向集合添加一个键 - 值
            //TryGetValue:尝试返回指定键的值.
            //TryRemove:尝试移除指定键处的元素.
            //TryUpdate:尝试更新指定键的值.
            BankAccount account = new BankAccount();
            ConcurrentDictionary<object, int> sharedDict = new ConcurrentDictionary<object, int>();
            Task<int>[] tasks = new Task<int>[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                sharedDict.TryAdd(i, account.Balance);
                tasks[i] = new Task<int>((keyObj) =>
                {
                    int currentValue;
                    bool gotValue;
                    for (int j = 0; j < 1000; j++)
                    {
                        gotValue = sharedDict.TryGetValue(keyObj, out currentValue);
                        sharedDict.TryUpdate(keyObj, currentValue + 1, currentValue);
                    }
                    int result;
                    gotValue = sharedDict.TryGetValue(keyObj, out result);
                    if (gotValue)
                    {
                        return result;
                    }
                    else
                    {
                        throw new Exception(String.Format("No data item available for key {0}", keyObj));
                    }
                }, i);
                tasks[i].Start();
            }
            for (int i = 0; i < tasks.Length; i++)
            {
                account.Balance += tasks[i].Result;
            }
            Console.WriteLine("Expected value {0}, Balance: {1}", 10000, account.Balance);
            Console.WriteLine("Press enter to finish");
            Console.WriteLine(account.Balance);
            Console.ReadLine();
        }
    }
}
