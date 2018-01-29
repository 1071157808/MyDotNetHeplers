using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication7 {
    class Program {
        static void Main (string[] args) {
            string sAMAccountName = "10010";
            DirectoryEntry userRoot = GetDirectoryEntry ("10.10.2.11", "test.com", "administrator", "P@ssw0rd");
            DirectorySearcher searcher = new DirectorySearcher (userRoot);
            //searcher.Filter = "(sAMAccountName=" + sAMAccountName + ")";
            searcher.Filter = "(&(objectClass=organizationalUnit)(name=" + "0102-01002.集团财务部" + "))";
            DirectoryEntry entry = searcher.FindOne ().GetDirectoryEntry ();
            string addresslistname = ModifyPathToIdentity (entry.Path);
            Console.WriteLine (addresslistname);
            Console.ReadKey ();
            //string bb2 = adMgrExchange.EnableMail(addresslistname);
        }
        public static DirectoryEntry GetDirectoryEntry (string serverIp, string domain, string userName, string pwd) {
            DirectoryEntry de = new DirectoryEntry ();
            de.Path = "LDAP://" + serverIp;
            de.Username = domain + "\\" + userName;
            de.Password = pwd;
            //eg:
            //de.Path = "LDAP://test.com/CN=Users;DC=Yourdomain";
            //de.Username = @"test\0202";
            //de.Password = "123456";
            return de;
        }
        public static string ModifyPathToIdentity (string path) {
            string identity = null;
            var arr = path.Split (',');
            for (int i = 0; i < arr.Length; i++) {
                var arr2 = arr[i].Split ('=');
                arr[i] = arr2[1];
            }
            StringBuilder temp = new StringBuilder ();
            string temp2 = arr[arr.Length - 2] + "." + arr[arr.Length - 1] + "/";
            temp.Append (temp2);
            for (int i = arr.Length - 3; i >= 0; i--) {
                temp.Append (arr[i] + "/");
            }
            string result = temp.ToString ().Substring (0, temp.ToString ().Length - 1);
            return result;
        }
    }
}