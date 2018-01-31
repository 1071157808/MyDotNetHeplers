
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class TestAction
    {
        public static void Main(String[] args)
        {
            ClassA myObj = new ClassA();
            Console.WriteLine("myObj.State={0}", myObj.State);
            ClassA.ClassB myOtherObj = new ClassA.ClassB();
            myOtherObj.SetPrivateState(myObj, 999);
            Console.WriteLine("myObj.State={0}", myObj.State);
            Console.ReadKey();
            Console.ReadKey();
        } //main
    } //IsInstanceTes
    public class ClassA
    {
        private int state = 1;
        public int State
        {
            get { return state; }
        }
        public class ClassB
        {
            public void SetPrivateState(ClassA target, int newState)
            {
                target.state = newState;
            }
        }
    }
}    

