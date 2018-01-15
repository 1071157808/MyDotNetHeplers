/*  QQ群：166843154  http://www.cnblogs.com/1996V/p/8127576.html */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Demo
{
    public class Factory
    {
        public static List<Container> ContainerList = new List<Container>();
        static Factory()
        {
            for (int i = 0; i < 4; i++)
            {
                ContainerList.Add(new Container());
            }
            foreach (var item in ContainerList)
            {
                item.Run();
            }
        }
        static Container GetContainer(int userId)
        {
            //if (0 <= userId && userId < 10)
            //    return ContainerList[0];
            //return ContainerList[1];

            if (0 <= userId && userId < 10)
                return ContainerList[0];
            if (10 <= userId && userId < 20)
                return ContainerList[1];
            if (20 <= userId && userId < 30)
                return ContainerList[2];
            return ContainerList[3];
        }
        public static bool Add(int userId)
        {
            return GetContainer(userId).Add(userId);
        }
    }
    /// <summary>
    /// 容器
    /// </summary>
    public class Container
    {
        private ReaderWriterLockSlim obj = new ReaderWriterLockSlim();
        public ConcurrentDictionary<string, ConcurrentList<DateTime>> dic = new ConcurrentDictionary<string, ConcurrentList<DateTime>>();

        public bool Add(int userId)
        {
            obj.EnterReadLock();
            try
            {
                ConcurrentList<DateTime> dtList = dic.GetOrAdd(userId.ToString(), new ConcurrentList<DateTime>());
                return dtList.CounterAdd(10, DateTime.Now);
            }
            finally
            {
                obj.ExitReadLock();
            }
        }
        public void Run()
        {
            ThreadPool.QueueUserWorkItem(c =>
            {
                while (true)
                {
                    if (dic.Count > 0)
                    {
                        foreach (var item in dic.ToArray())
                        {
                            ConcurrentList<DateTime> list = item.Value;
                            foreach (DateTime dt in list.ToArray())  
                            {
                                if (DateTime.Now.AddSeconds(-3) > dt)
                                {
                                    list.Remove(dt);
                                    Console.WriteLine("已删除用户" + item.Key + "管道中的一条数据");
                                }
                            }
                            if (list.Count == 0)
                            {
                                obj.EnterWriteLock();
                                try
                                {
                                    if (list.Count == 0)
                                    {
                                        if (dic.TryRemove(item.Key, out ConcurrentList<DateTime> i))
                                        { Console.WriteLine("已清除用户" + item.Key + "的List管道"); }
                                    }
                                }
                                finally
                                {
                                    obj.ExitWriteLock();
                                }
                            }
                        }

                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
          );
        }


    }
    public class ConcurrentList<T> : List<T>
    {
        private object obj = new object();
        /// <summary>
        /// 如果超出所记的数  则返回失败
        /// </summary>
        /// <param name="num"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CounterAdd(int num, T value)
        {
            lock (obj)
            {
                if (base.Count >= num)
                    return false;
                else
                    base.Add(value);
                return true;
            }
        }
        public new bool Remove(T value)
        {
            lock (obj)
            {
                base.Remove(value);
                return true;
            }
        }
        public new T[] ToArray()
        {
            lock (obj)
            {
                return base.ToArray();
            }
        }
    }
}