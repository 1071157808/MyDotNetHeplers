using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace index
{
    class Program
    {
        // 不能用static修饰，Compile time constant，编译器的常量
        public const int age = 25;
        // 可以用static修饰，Runtime constant ,可以在别的地方初始化,只能初始化一次
        //运行期的常量
        public static readonly double PI = 3.14;
        static void Main(string[] args)
        {
            Console.WriteLine(PI);
            Console.Read();
        }
    }
}
