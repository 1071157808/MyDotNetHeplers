using System;
using ServiceStack.Redis;

namespace MSCampus.RedisHelper
{
    /// <summary>
    /// 新青年X开发训练营 国内最新的技术课程 www.54peixun.com
    /// 上海6期平均月薪超过18800！北京8期超过20000！国内最高！
    /// 10期永新年薪100万！7期黄源年薪80万！18位年薪超40万！5位技术总监！
    /// 世界顶级计算机编程大师 Delphi、C#、Typescript 之父Anders中国唯一签名、合影
    /// 微软MSDN技术俱乐部QQ群 29754721 微软X安卓实战训练营 203822816
    /// 创建时间：2016-05-26
    ///高性能缓存Cache Redis Helper帮助类 @54peixun.com
    /// </summary>
    public class RedisHelper
    {
        //string host = "127.0.0.1:6379"; 每个小时6000个消息
        public void AddData<T>(string host, string key, T entity)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                redisClient.ConnectTimeout = 3600;
                redisClient.Set(key, entity);
            }
        }
        public T GetData<T>(string host, string key)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                redisClient.ConnectTimeout = 3600;
                return redisClient.Get<T>(key);
            }
        }
        public void DeleteData<T>(string host, T entity)
        {
            using (RedisClient redisClient = new RedisClient(host))
            {
                redisClient.ConnectTimeout = 3600;
                redisClient.Delete<T>(entity);
            }
        }
    }
}

