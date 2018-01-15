/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using System;
using System.Threading;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(o => {
                    Thread.Sleep(300);
                    Access();
                });
            }
            Console.ReadKey();
        }

        static Random ra = new Random();
        static bool Access()
        {
            RedisHelper re = new RedisHelper(7);
            string user = "User_" + ra.Next(0, 10);
            if (re.LuaAddAccoundSorted(user, Convert.ToDouble(DateTime.Now.ToString("MMddHHmmssffff")), Guid.NewGuid().ToString(), 10) == "1")
            {
                Console.WriteLine(user + " 访问失败");
                return false;
            }
            else
            {
                Console.WriteLine(user + " 访问成功");
                return true;
            }
        }
        static void Run()
        {
            RedisHelper re = new RedisHelper(7);
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    try
                    {
                        double dtEnd = double.Parse((DateTime.Now.AddSeconds(-10)).ToString("MMddHHmmssffff"));
                        re.LuaForeachRemove("User_", dtEnd);
                        Thread.Sleep(100);
                    }
                    catch
                    {

                    }
                }
            });
        }
    }
}
