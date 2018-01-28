using System;
using System.Collections.Generic;
using System.Linq;
usingSystem.Net;
using System.Text;
using System.Xml;
namespace SharePointGetList {
    class Program {
        static void Main (string[] args) {
            var proxy = new WebReference.Lists ();
            proxy.Url = @"http://192.168.8.13:80/_vti_bin/Lists.asmx";;
            //在同一个域中使用下面这个
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //跨域的时候使用下面这个(not test)
            //proxy.Credentials = new NetworkCredential(用户名, 密码, 域名);
            //proxy.Credentials = new NetworkCredential(@"sitrc\spadmin", "Sitrcadmin52524567", "http://192.168.8.13:80";);
            /*Declare an XmlNode object and initialize it with the XML
            response from the GetListCollection method. */
            System.Xml.XmlNode node = proxy.GetListCollection ();
            /*Loop through XML response and parse out the value of the
            Title attribute for each list. */
            StringBuilder str = new StringBuilder ();
            foreach (System.Xml.XmlNode xmlnode in node) {
                //str.Append(xmlnode.Attributes["Title"].Value + Environment.NewLine);
                Console.WriteLine (xmlnode.ParentNode.LocalName);
                //if (xmlnode.Attributes["Title"].Value == "供应商")
                //{
                //    foreach (XmlAttribute xmlAttribute in xmlnode.Attributes)
                //    {
                //        Console.WriteLine(xmlAttribute.Name + "  " + xmlAttribute.Value);
                //    }
                //}
            }
            Console.WriteLine (str);
            Console.ReadKey ();
        }
    }
}