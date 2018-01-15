using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = typeof(Test);
            var classAttribute = (Person)Attribute.GetCustomAttribute(info, typeof(Person));
            Console.WriteLine(classAttribute.Name);
            Console.WriteLine(classAttribute.Age);
            Console.ReadKey();
        }
    }
    //自定义一个Person属性
    class Person : Attribute
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string s, int i)
        { this.Name = s; this.Age = i; }
    }
    [Person("spike", 23)]
    class Test
    {
        public int aa;
        public string ss;
    }
}
