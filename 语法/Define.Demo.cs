

#define yy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
#if yy
            Console.WriteLine("如果存在yy，就输出yy");
#else
            global::System.Console.WriteLine("如果不存在，这里就是灰色的");
#endif
        }
    }
}
