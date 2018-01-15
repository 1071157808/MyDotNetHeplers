using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryEntry deRoot = new DirectoryEntry("LDAP://10.10.2.11/RootDSE", "administrator", "P@ssw0rd");
            if (deRoot != null)
            {
                string defaultNamingContext = deRoot.Properties["defaultNamingContext"].Value.ToString();
                Console.WriteLine(defaultNamingContext);
                Console.WriteLine("成功输出了");
            }
            else
            {
                Console.WriteLine("找不到");
            }
            Console.ReadKey();
        }
    }
}
