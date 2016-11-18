using MSCampus.RedisHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHelper redis = new RedisHelper();
            Console.WriteLine("当前的时间是："+DateTime.Now);
            for (int i = 0; i < 5000; i++)
            {
                man spike= new man()
                {
                    name = i,
                    sex = i * 20
                };
                redis.AddData("127.0.0.1:6379", i.ToString(), jingya);
            }
            Console.WriteLine("程序执行完成后的时间是：" + DateTime.Now);
            Console.ReadKey();
        }

    }
    public class man
    {
        public int name;
        public int sex;
    }
}
