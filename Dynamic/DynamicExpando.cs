
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using System.Dynamic;
namespace ConsoleApplication4
{
    class DynamicExpandoampleProgram
    {
        static void Main(string[] args)
        {
            //第一种写法
            Dictionary<string, object> dict = new Dictionary<string, object>();
            Dictionary<string, object> address = new Dictionary<string, object>();
            dict["Address"] = address;
            address["State"] = "china";
            Console.WriteLine(((Dictionary<string, object>)dict["Address"])["State"]);
            //第二种写法
            dynamic expando = new ExpandoObject();
            expando.address = new ExpandoObject();
            expando.address.state = "china";
            Console.WriteLine(expando.address.state);
            Console.Read();
        }
    }
}
