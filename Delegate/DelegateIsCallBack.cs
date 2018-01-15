

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DelegateIsCallBackFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Talk(SlowSpeak);
            Console.ReadKey();
        }
        static void SlowSpeak(int i)
        {
            Console.WriteLine(i + " i am slowly speak" + i);
        }
    }
    public class Person
    {
        public delegate void Speak(int i);
        public void Talk(Speak speak)
        {
            for (int i = 0; i < 50; i++)
            {
                speak(i);
            }
        }
    }
}

