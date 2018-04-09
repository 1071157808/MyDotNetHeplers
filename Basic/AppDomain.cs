using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace UnloadDll {
    class Program {
        static void Main (string[] args) {
            string callingDomainName = AppDomain.CurrentDomain.FriendlyName; //Thread.GetDomain().FriendlyName;   
            Console.WriteLine (callingDomainName);
            AppDomain ad = AppDomain.CreateDomain ("DLL Unload test");
            ProxyObject obj = (ProxyObject) ad.CreateInstanceFromAndUnwrap (@"UnloadDll.exe", "UnloadDll.ProxyObject");
            obj.LoadAssembly ();
            obj.Invoke ("TestDll.Class1", "Test", "It's a test");
            AppDomain.Unload (ad);
            obj = null;
            Console.ReadLine ();
        }   
    }

    class ProxyObject : MarshalByRefObject {
        Assembly assembly = null;
        string curPath;

        public ProxyObject () {
            curPath = System.Environment.CurrentDirectory;
        }

        public void LoadAssembly () {
            assembly = Assembly.LoadFile (curPath + @"\TestDLL.dll");
        }

        public bool Invoke (string fullClassName, string methodName, params Object[] args) {
            if (assembly == null)
                return false;
            Type tp = assembly.GetType (fullClassName);
            if (tp == null)
                return false;
            MethodInfo method = tp.GetMethod (methodName);
            if (method == null)
                return false;
            Object obj = Activator.CreateInstance (tp);
            method.Invoke (obj, args);
            return true;
        }
    }
}



//----------------
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
  
namespace TestDll  
{  
    public class Class1  
    {  
        public void Test(string str)  
        {  
            Console.WriteLine(str);  
        }  
    }  
}  