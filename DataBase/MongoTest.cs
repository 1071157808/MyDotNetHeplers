using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongodbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoHelper<entity> mongo = new MongoHelper<entity>();

            //插入数据
            //Console.WriteLine("程序开始时间是" + DateTime.Now);
            //for (int i = 0; i < 1000; i++)
            //{
            //    entity enti = new entity();
            //    enti.id = i;
            //    enti.name = i.ToString();
            //    enti.value = (i * 2).ToString();
            //    mongo.Add(enti);
            //}
            //Console.WriteLine("程序结束时间是" + DateTime.Now);

            ////获取数据
            //List<entity> entityList = mongo.GetAll();
            //foreach (var item in entityList)
            //{
            //    Console.WriteLine(item.name + "   " + item.value);
            //}

            //带身份证密码的是这种格式
            //第一种
            string connectionString = "mongodb://spike:spike@localhost/taobao";
            //第二种
            //string connectionString = "mongodb://spike:spike@localhost:27017/taobao";
            //不带身份证密码的是这种格式
            //string connectionString = "mongodb://localhost:27017";
            ////简单 客户端连接 带用户名和密码
            //var connectionString = "mongodb://admin:54peixun.com@localhost/taobao";
            var client = new MongoClient(connectionString);
            ////MongoClient client = new MongoClient(settings);
            //获取数据库
            IMongoDatabase database = client.GetDatabase("taobao");

            //获取集合
            IMongoCollection<entity> collection = database.GetCollection<entity>("forpwd");
            //IMongoCollection<Order> collection2 = database.GetCollection<Order>("Order");
            //插入1000W数据
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                //Entity user7 = new Entity { Name = "微软训练营(X):2000万级 MongoDB 别高并发测试", Id = Guid.NewGuid().ToString(), Age = 38 };

                //collection.InsertOneAsync(user7);

                entity entity = new entity() { id=i.ToString(),name = i.ToString() + ".0", value = "高级架构班 MongoDB集群分片实战" };
                collection.InsertOne(entity);
            }
            //var collection = _database.GetCollection<BsonDocument>("restaurants");
            //await collection.InsertOneAsync(document);

            sw.Stop();

            long total = sw.ElapsedMilliseconds;
            //return totalTime;
            Console.WriteLine(total);
            Console.ReadKey();

        }
    }
    public class entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
