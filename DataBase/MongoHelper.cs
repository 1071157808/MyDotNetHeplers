using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongodbTest
{
    /// <summary>
    /// 新青年X开发训练营 国内最新的技术课程 www.54peixun.com
    /// 上海6期平均月薪超过18800！北京8期超过20000！国内最高！
    /// 10期永新年薪100万！7期黄源年薪80万！18位年薪超40万！5位技术总监！
    /// 世界顶级计算机编程大师 Delphi、C#、Typescript 之父Anders中国唯一签名、合影
    /// 微软MSDN技术俱乐部QQ群 29754721 微软X安卓实战训练营 203822816
    /// 创建时间：2016-05-26
    ///高性能缓存Cache MongoHelper帮助类 @54peixun.com
    /// </summary>
    public class MongoHelper<T> where T : class
    {
        public IMongoCollection<T> Collection { get; private set; }
        public MongoHelper()
        {
            string connectionString = "mongodb://127.0.0.1:27017";
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase("test");
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
        public MongoHelper(string connectionString, string dbName)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "mongodb://127.0.0.1:27017";
            }
            MongoClient client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
        public void Add(T entity)
        {
            Collection.InsertOne(entity);
        }
        public void Delete(string fieldName, string value)
        {
            var filter = Builders<T>.Filter.Eq(fieldName, value);
            Collection.DeleteOne(filter);
        }
        public void Update(string fieldName, string value, T entity)
        {
            var filter = Builders<T>.Filter.Eq(fieldName, value);
            var update = Builders<T>.Update.Set("Id", 110);
            Collection.UpdateOne(filter, update);
        }
        public List<T> GetAll()
        {
            // 这个语句写的有些问题
            var documents = Collection.Find(new BsonDocument()).ToList();
            return documents;
        }
        public T GetOne(string fieldName, string value)
        {
            var filter = Builders<T>.Filter.Eq(fieldName, value);
            var document = Collection.Find(filter).First();
            return document;
        }
    }
}