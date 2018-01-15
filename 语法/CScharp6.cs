using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
//声明静态命名空间
using static System.Math;
namespace CScharp6._0Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializer for auto-properties
            Person one = new Person();
            Console.WriteLine(one.Name);
            Console.WriteLine(one.Dist);
            Console.WriteLine(one);
            //Index initializers  JObject
            Point point = new Point();
            JObject jObject = point.ToJson();
            //对异常中nameof的测试
            Point point2 = new Point();
            string str = point.Add(point2);
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
    //Initializer for auto-properties
    public class Person
    {
        //新的初始化属性的方式
        public string Age { get; } = "10";
        public string Name { get; } = "Spike";
        //使用静态命名空间的静态函数
        public double Dist => Sqrt(4);
        //使用${变量名} 的方式直接输出变量的值
        public override string ToString() => $"{Age},this is your name {Name}";
    }
    //Index initializers (important to json objects)
    public class Point
    {
        public Point() { }
        public Point(int i, int j)
        {
            this.X = i;
            this.Y = j;
        }
        public int X { get; }
        public int Y { get; }
        //new method
        public JObject ToJson() => new JObject() { ["x"] = X, ["y"] = Y };
        //old method
        //public JObject ToJson()
        //{
        //    //old method
        //    //var result = new JObject();
        //    //result["x"] = X;
        //    //result["y"] = Y;
        //    //new method
        //    var result = new JObject() {["x"] = X, ["y"] = Y};
        //    return result;
        //}
        //Null-conditional operators
        public static Point FromJson(JObject json)
        {
            //old method
            //if (json != null && json["x"] != null && json["x"].Type == JTokenType.Integer)
            //{
            //    return new Point((int)json["x"], (int)json["y"]);
            //}
            //new method
            if (json?["x"]?.Type == JTokenType.Integer)
            {
                return new Point((int)json["x"], (int)json["y"]);
            }
            return null;
        }
        //The name of operator
        public string Add(Point testPoint)
        {
            var data = "";
            try
            {
                if (testPoint != null)
                {
                    //old method
                    //throw new ArgumentNullException("point");
                    //new method
                    throw new ArgumentNullException(nameof(testPoint));
                }
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }
            return data;
        }
        public string TryAwaitTest(Point testPoint)
        {
            var data = "";
            try
            {
            }
            catch (ConfigurationException e) when (e.Equals(testPoint))
            {
                //这里可以写await异步方法
            }
            finally
            {
                //这里可以写await异步方法
            }
            return data;
        }
    }
}
