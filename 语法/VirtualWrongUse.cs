using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Class {
    // 可能会引起问题的类的继承问题，父类后来增加的方法可能会引起子类的函数重载错误
    class Program {
        static void Main (string[] args) {
            man spike = new man ();
            spike.Speak (1); //输出  i am Person
            Console.ReadKey ();
        }
    }
    class Person {
        public virtual void Speak (int i) {
            Console.WriteLine ("i am Person");
        }
    }
    class man : Person {
        public void Speak (string i) {
            Console.WriteLine ("I am a man");
        }
    }
}