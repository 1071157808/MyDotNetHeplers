
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Permissions;
using System.Reflection;
using System.Threading;
namespace AppDomainNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var perm = new PermissionSet(PermissionState.None);
            perm.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            perm.AddPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess, @"C:\"));
            var setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //构建AppDomain
            AppDomain securedDomain = AppDomain.CreateDomain("securedDomain", null, setup, perm);
            try
            {
                Type thirdparty = typeof(ThridParty);
                securedDomain.CreateInstanceAndUnwrap(thirdparty.Assembly.FullName, thirdparty.FullName);
            }
            catch (Exception)
            {
                AppDomain.Unload(securedDomain);
            }
            //default appdomain
            object1 obj = new object1();
            Console.WriteLine("默认的appdomain已经启动");
            Console.ReadKey();
        }
    }
    class ThridParty
    {
        public ThridParty()
        {
            Console.WriteLine("Third party loaded");
            System.IO.File.Create(@"C:\1.txt");
        }
    }
    class object1
    {
    }
}
