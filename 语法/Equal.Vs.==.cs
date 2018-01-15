using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace index {
    class Program {
        static void Main (string[] args) {
            object One = "this is One";
            object Two = One;
            //比较reference
            Console.WriteLine (One == Two); //ture
            //比较content
            Console.WriteLine (One.Equals (Two)); //ture
            object Three = "this is One";
            //这里如果直接使用字符串的话，就会把"this is One"的引用给Four
            object Four = new string ("this is One".ToCharArray ());
            //比较reference
            Console.WriteLine (Three == Four); //false
            //比较content
            Console.WriteLine (Three.Equals (Four)); //ture
            //String是特殊的类型，因为.net对String使用了内存中的检查，所以相同的字符串会是一个引用
            string Five = "this is One";
            string Sive = "this is One";
            //比较reference
            Console.WriteLine (Five == Sive); //false
            //比较content
            Console.WriteLine (Five.Equals (Sive)); //ture
            Console.ReadKey ();
        }
    }
}