
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VirtualAndOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            SecondChild c = new SecondChild();
            Console.WriteLine(c.GetMethodOwnerName()); // 输出Second level Child"
            ChildClass x = new ChildClass();
            Console.WriteLine(x.GetMethodOwnerName()); // 输出 ChildClass
            Console.ReadKey();
        }
    }
    public class BaseClass
    {
        public virtual string GetMethodOwnerName()
        {
            return "Base Class";
        }
    }
    public class ChildClass : BaseClass
    {
        public new virtual string GetMethodOwnerName()
        {
            return "ChildClass";
        }
    }
    public class SecondChild : ChildClass
    {
        public override string GetMethodOwnerName()
        {
            return "Second level Child";
        }
    }
}
