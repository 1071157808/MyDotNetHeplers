
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
namespace ConsoleApplication4
{
    class DynamicProgram
    {
        static void Main(string[] args)
        {
            //这个是老式的写法
            var doc = XDocument.Load("Employees.xml");
            foreach (var element in doc.Element("Employees").Elements("Employee"))
            {
                Console.WriteLine(element.Element("FirstName").Value);
            }
            //这是用Dynamic的写法
            var doc2 = XDocument.Load("Employees.xml").AsExpando();
            foreach (var item in doc2.Employees)
            {
                Console.WriteLine(item.FirstName);
            }
        }
    }
    public static class ExpandoXml
    {
        public static dynamic AsExpando(this XDocument xDocument)
        {
            return CreateExpando(xDocument.Root);
        }
        private static dynamic CreateExpando(XElement xElement)
        {
            var result = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
            if (xElement.Elements().Any(x => x.HasElements))
            {
                var list = new List<System.Dynamic.ExpandoObject>();
                result.Add(xElement.Name.ToString(), list);
                foreach (var childElement in xElement.Elements())
                {
                    list.Add(CreateExpando(childElement));
                }
            }
            else
            {
                foreach (var leafElement in xElement.Elements())
                {
                    result.Add(leafElement.Name.ToString(), leafElement.Value);
                }
            }
            return result;
        }
    }
}
