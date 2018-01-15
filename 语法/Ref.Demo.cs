
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RefApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            Person a = new Person(ref i);
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
    class Person
    {
        public Person(ref int age)
        {
            age = age + 1;
        }
    }
}
