//类自定义索引器
class Program {
    staticvoidMain (string[] args) {
        man mm = new man ();
        mm[0] = "spike";
        mm[1] = "spike002";
        mm[2] = "spike004";
        mm[3] = "spike004";
        for (int i = 0; i < 10; i++) {
            Console.WriteLine (mm[i]);
        }
        Console.ReadKey ();
    }
    class man {
        public man () {
            for (int i = 0; i < 10; i++) {
                manlist[i] = "N.A.";
            }
        }
        // 其实外面的索引器就是在这里给定义好大小的，这就是这个方法的局限性
        private string[] manlist = newstring[10];
        publicstringthis [int index] {
            set { manlist[index] = value; }
            get { return manlist[index]; }
        }
    }
}



//Class Index Inherit 
//类索引的继承
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Super[] arrs = new Super[3];
            arrs[0] = new Super();
            arrs[1] = new SonOverride();
            arrs[2] = new SonNew();
            for (int i = 0; i < arrs.Length; i++)
            {
                arrs[i].Show();
            }
            SonNew sonNew = new SonNew();
            sonNew.Show();
            Console.ReadKey();
        }
    }
    public class Super
    {
        public virtual void Show()
        {
            Console.WriteLine("Super");
        }
    }
    public class SonOverride : Super
    {
        public override void Show()
        {
            Console.WriteLine("Son Override");
        }
    }
    public class SonNew : Super
    {
        public new void Show()
        {
            Console.WriteLine("Son New");
        }
    }
}



