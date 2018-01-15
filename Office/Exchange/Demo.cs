using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main (string[] args) {
            var userName = "10101";
            //DirectoryEntry ouEntry = GetOuDirectoryEtnryByName(ouName);
            //var result = AddExchangeCompanyOrganization(ouEntry);
            //var result = AddExchangeDeptOrganization(ouEntry);
            //string newIdentity = ModifyPathToIdentity(ouEntry.Path);
            //string oldIdentity = "test.com/0100-02000.SuperMarket/0100-02001.SuperShip";
            //var result = RenameDeptOrganization(oldIdentity,newIdentity);
            var userEntry = GetDirectoryEntryByAdNumber (userName);
            var result = EnableAdUserExchangeMail (userEntry);
            Console.Read ();
        }
        #region 开启Script初始化连接
        public static WSManConnectionInfo ExchangeScriptInit () {
            var _exIp = "win-2ickeabl4tr.test.com";
            //var _exIp = "Localhost";
            var _exadmin = "administrator@test.com";
            var _expwd = "P@ssw0rd";
            try {
                var SHELL_URI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";;
                // 邮件服务器地址赋值                         
                //System.Uri serverUri = new Uri(String.Format("http://Xd-svr0185.xd-ad.com.cn/PowerShell";, @"xd-ad\admin"));
                //System.Uri serverUri = new Uri(String.Format("http://exchangedag.xd-ad.com.cn/PowerShell";, @"xd-ad\admin"));
                //var serverUri =new Uri(string.Format("http://"; + _expath + "/PowerShell", @"" + _exadmin + ""));
                var serverUri = new Uri (string.Format ("http://"; + _exIp + "/PowerShell"));
                PSCredential creds;
                //在内存中加密字符串
                var securePassword = new SecureString ();
                foreach (var c in _expwd) {
                    securePassword.AppendChar (c);
                }
                //creds = new PSCredential(@"xd-ad\admin", securePassword);
                // 生成凭证（根据exchange的管理员用户名和密码）
                creds = new PSCredential (@"" + _exadmin + "", securePassword);
                // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo (serverUri, SHELL_URI, creds);
                connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
                return connectionInfo;
            } catch (Exception) {
                return null;
            }
        }
        #endregion
        public static void InvokeSystemPS (string cmd) {
            List<string> ps = new List<string> ();
            ps.Add ("Set-ExecutionPolicy RemoteSigned");
            ps.Add ("Set-ExecutionPolicy -ExecutionPolicy Unrestricted");
            ps.Add ("& " + cmd);
            Runspace runspace = RunspaceFactory.CreateRunspace ();
            runspace.Open ();
            Pipeline pipeline = runspace.CreatePipeline ();
            foreach (var scr in ps) {
                pipeline.Commands.AddScript (scr);
            }
            pipeline.Invoke (); //Execute the ps script
            runspace.Close ();
        }
        private static bool RunScript (string cmd) {
            // create Powershell runspace
            try {
                RunspaceConfiguration rsConfig = RunspaceConfiguration.Create ();
                PSSnapInException snapInException = null;
                PSSnapInInfo info = rsConfig.AddPSSnapIn ("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
                Runspace myRunSpace = RunspaceFactory.CreateRunspace (rsConfig);
                myRunSpace.Open ();
                Pipeline pipeLine = myRunSpace.CreatePipeline ();
                Command myCommand = new Command (cmd, true);
                pipeLine.Commands.Add (myCommand);
                Collection<PSObject> commandResults = pipeLine.Invoke ();
                foreach (PSObject obj in commandResults) {
                    Console.WriteLine (obj.ToString ());
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        #region 新增公司组织
        public static bool AddExchangeCompanyOrganization (DirectoryEntry companyEntry) {
            try {
                string identity = ModifyPathToIdentity (companyEntry.Path);
                // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
                var array = identity.Split ('/');
                var displayName = array[array.Length - 1];
                var alias = displayName.Substring (0, displayName.IndexOf ('.'));
                var name = array[array.Length - 1];
                //筛选名称
                var conditionnalName = array[array.Length - 1];
                //container是部门上一级：帐号类型的名称
                //var container = array[array.Length - 2];
                var updateName = identity.Substring (identity.IndexOf ('/')).Replace ('/', '\\');
                //var container = temp.Substring(0, temp.LastIndexOf('/')).Replace('/', '\\');
                //容器的名称，对于公司来说应该是\\test.com
                var container = "\\";
                var groupIdentity = identity + "/" + displayName;
                var connectionInfo = ExchangeScriptInit ();
                using (var rs = RunspaceFactory.CreateRunspace (connectionInfo)) {
                    var psh = PowerShell.Create ();
                    psh.Runspace = rs;
                    rs.Open ();
                    var sScript = @"Enable-DistributionGroup -Identity '" + groupIdentity + "' -Alias '" + alias + "'";
                    psh.Commands.AddScript (sScript);
                    var sScript1 = "new-AddressList -Name '" + name + "' -RecipientContainer '" + identity + "' -IncludedRecipients 'AllRecipients' -ConditionalCompany  '" + conditionnalName + "' -Container '" + container + "' -DisplayName '" + displayName + "'";
                    //new-AddressList -Name 'test5' -RecipientContainer 'test.com/xd-ad/集团公司/党委' -IncludedRecipients 'AllRecipients' -ConditionalDepartment '党委' -Container '\\集团公司' -DisplayName 'test5'
                    psh.Commands.AddScript (sScript1);
                    //新增公司就没必要更新AddressList了
                    var sScript2 = "update-AddressList -identity '" + updateName + "'";
                    psh.Commands.AddScript (sScript2);
                    var psresults = psh.Invoke ();
                    if (psresults == null) {
                        return false;
                    }
                    var strbmessage = new StringBuilder ();
                    if (psh.Streams.Error.Count > 0) {
                        foreach (var err in psh.Streams.Error) {
                            strbmessage.AppendLine (err.ToString ());
                            Console.WriteLine (err);
                        }
                        return false;
                    }
                    rs.Close ();
                    psh.Runspace.Close ();
                    return true;
                }
            } catch (Exception e) {
                Console.WriteLine (e.Message);
                return false;
            }
        }
        #endregion
        #region 新增部门组织
        public static bool AddExchangeDeptOrganization (DirectoryEntry deptEntry) {
            try {
                string identity = ModifyPathToIdentity (deptEntry.Path);
                // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
                var connectionInfo = ExchangeScriptInit ();
                var array = identity.Split ('/');
                var displayName = array[array.Length - 1];
                var alias = displayName.Substring (0, displayName.IndexOf ('.'));
                var name = array[array.Length - 1];
                //筛选名称
                var conditionnalName = array[array.Length - 1];
                //container是部门上一级：公司的名称
                var recipientContainer = identity.Substring (0, identity.Length - displayName.Length - 1);
                var updateName = identity.Substring (identity.IndexOf ('/')).Replace ('/', '\\');
                var temp = identity.Substring (identity.IndexOf ('/') + 1);
                var container = "\\" + temp.Substring (0, temp.LastIndexOf ('/')).Replace ('/', '\\');
                var groupIdentity = identity + "/" + displayName;
                using (var rs = RunspaceFactory.CreateRunspace (connectionInfo)) {
                    var psh = PowerShell.Create ();
                    psh.Runspace = rs;
                    rs.Open ();
                    var sScript = "Enable-DistributionGroup -identity '" + groupIdentity + "' -Alias '" + alias + "'";
                    psh.Commands.AddScript (sScript);
                    var sScript1 = "new-AddressList -Name '" + name + "' -RecipientContainer '" + identity +
                        "' -IncludedRecipients 'AllRecipients' -ConditionalDepartment '" + conditionnalName +
                        "' -Container '" + container + "' -DisplayName '" + displayName + "'";
                    //new-AddressList -Name 'test5' -RecipientContainer 'test.com/xd-ad/集团公司/党委' -IncludedRecipients 'AllRecipients' -ConditionalDepartment '党委' -Container '\\集团公司' -DisplayName 'test5'
                    psh.Commands.AddScript (sScript1);
                    var sScript2 = "update-AddressList -identity '" + updateName + "'";
                    psh.Commands.AddScript (sScript2);
                    var psresults = psh.Invoke ();
                    if (psresults == null) {
                        return false;
                    }
                    var strbmessage = new StringBuilder ();
                    if (psh.Streams.Error.Count > 0) {
                        foreach (var err in psh.Streams.Error) {
                            strbmessage.AppendLine (err.ToString ());
                        }
                        return false;
                    }
                    rs.Close ();
                    psh.Runspace.Close ();
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }
        }
        #endregion
        #region 重命名公司组织
        public static bool RenameCompanyOrganization (string oldIdentity, string newIdentity) {
            try {
                //old operate
                var oldArray = oldIdentity.Split ('/');
                var oldDisplayName = oldArray[oldArray.Length - 1];
                var oldIdentityName = "\\" + oldDisplayName;
                // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
                var connectionInfo = ExchangeScriptInit ();
                var array = newIdentity.Split ('/');
                var displayName = array[array.Length - 1];
                var alias = displayName.Substring (0, displayName.IndexOf ('.'));
                var name = array[array.Length - 1];
                //var updateName = identity.Substring(identity.IndexOf('/') + 1).Replace('/', '\\');
                var updateName = newIdentity.Substring (newIdentity.IndexOf ('/')).Replace ('/', '\\');
                //筛选名称
                var conditionnalName = array[array.Length - 1];
                var groupName = newIdentity + "/" + displayName;
                var newIdentityName = "\\" + displayName;
                var recipientContainer = newIdentity;
                using (var rs = RunspaceFactory.CreateRunspace (connectionInfo)) {
                    var psh = PowerShell.Create ();
                    psh.Runspace = rs;
                    rs.Open ();
                    var sScript = "Set-DistributionGroup -Alias '" + alias + "' -DisplayName '" + displayName + "' -Identity '" + groupName + "'";
                    //"Set-DistributionGroup -Alias '"+ alias + """' -DisplayName '炊事房1' -Identity 'test.com/xd-ad/集团公司/炊事房/炊事房'";
                    //Set - DistributionGroup - DisplayName '0100-02000.SuperMarket002' - Identity 'test.com/0100-02000.SuperMarket002/0100-02000.SuperMarket002'
                    psh.Commands.AddScript (sScript);
                    var sScript1 = "set-AddressList -displayName '" + displayName + "' -name '" + name +
                        "' -IncludedRecipients 'AllRecipients' -ConditionalCompany  '" + conditionnalName +
                        "' -recipientContainer '" + recipientContainer + "' -identity '" + oldIdentityName +
                        "'";
                    psh.Commands.AddScript (sScript1);
                    var sScript2 = "update-AddressList -identity '" + newIdentityName + "'";
                    psh.Commands.AddScript (sScript2);
                    var psresults = psh.Invoke ();
                    if (psresults == null) {
                        return false;
                    }
                    var strbmessage = new StringBuilder ();
                    if (psh.Streams.Error.Count > 0) {
                        foreach (var err in psh.Streams.Error) {
                            strbmessage.AppendLine (err.ToString ());
                            Console.WriteLine (err);
                        }
                        return false;
                    }
                    rs.Close ();
                    psh.Runspace.Close ();
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }
        }
        #endregion
        #region 重命名部门组织
        public static bool RenameDeptOrganization (string oldIdentity, string identity) {
            // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
            var connectionInfo = ExchangeScriptInit ();
            var array = identity.Split ('/');
            //别名alias约定成.前的一串数字
            var displayName = array[array.Length - 1];
            var alias = displayName.Substring (0, displayName.IndexOf ('.'));
            var identityGroupName = identity + "/" + displayName;
            //old operate
            var oldArray = oldIdentity.Split ('/');
            var oldDisplayName = oldArray[oldArray.Length - 1];
            var oldIdentityName = "\\" + oldArray[oldArray.Length - 2] + "\\" + oldDisplayName;
            var newIdentityName = "\\" + array[array.Length - 2] + "\\" + displayName;
            var recipientContainer = identity.Substring (0, identity.Length - displayName.Length - 1);
            try {
                using (var rs = RunspaceFactory.CreateRunspace (connectionInfo)) {
                    var psh = PowerShell.Create ();
                    psh.Runspace = rs;
                    rs.Open ();
                    var sScript = "Set-DistributionGroup -DisplayName '" + displayName + "'  -Identity '" + identityGroupName + "'";
                    //Set-DistributionGroup -DisplayName '0100-01011.集团公司领导班子' -Name '0100-01011.集团公司领导班子' -Identity 'test.com/xd-ad/0100-01001.集团公司/0100-01011.集团公司领导l班子/0100-01011.集团公司领导班子'
                    psh.Commands.AddScript (sScript);
                    // 这个oldIdentity就是地址列表中ou以前的名称
                    var sScript1 = "set-AddressList -DisplayName '" + displayName + "' -Name '" + displayName + "' -IncludedRecipients 'AllRecipients' -ConditionalDepartment '" + displayName + "' -RecipientContainer '" + recipientContainer + "' -identity '" + oldIdentityName + "'";
                    // set-AddressList -DisplayName '0100-01011.集团公司领导班子' -Name '0100-01011.集团公司领导班子' -IncludedRecipients 'AllRecipients' -ConditionalDepartment '0100-01011.集团公司领导班子' -RecipientContainer 'test.com/xd-ad临时员工/0100-01001.集团公司/0100-01011.集团公司领导l班子' -Identity '\xd-ad临时员工\0100-01001.集团公司\0100-01011.集团公司领导'
                    psh.Commands.AddScript (sScript1);
                    // 这里更改部门上一级的公司OU存在争议，可改可不改暂时不清楚，暂时不写
                    var sScript2 = "update-AddressList -identity '" + newIdentityName + "'";
                    //updateName "xd-ad被禁账户\\0100-01001.集团公司\\0100-01011.集团公司领导l班子"
                    psh.Commands.AddScript (sScript2);
                    var psresults = psh.Invoke ();
                    if (psresults == null) {
                        return false;
                    }
                    var strbmessage = new StringBuilder ();
                    if (psh.Streams.Error.Count > 0) {
                        foreach (var err in psh.Streams.Error) {
                            strbmessage.AppendLine (err.ToString ());
                        }
                        return false;
                    }
                    rs.Close ();
                    psh.Runspace.Close ();
                    return true;
                }
            } catch (Exception e) {
                return false;
            }
        }
        #endregion
        #region 设置用户的邮箱
        //启用和编辑用户都使用
        public static string EnableAdUserExchangeMail (DirectoryEntry userEntry) {
            try {
                var message = "";
                string identity = ModifyPathToIdentity (userEntry.Path);
                var identityName = identity.Substring (identity.IndexOf ("/")).Replace ("/", "\\");
                //string result = EnableMail(addresslistname);
                #region 取得Exchange所需要的数据
                var ouCompanyName = userEntry.Parent.Parent.Name.Substring (3);
                //根据公司的名称，在数据库中找到该公司所对应的数据库名称，并赋值给dataBase变量
                string dataBase = "shanghaiyuan";
                if (userEntry.Properties.Contains ("homeMDB") && userEntry.Properties.Contains ("homeMTA")) {
                    message = "该AD域用户邮件已开启！";
                    return message;
                } else if (dataBase == null) {
                    message = "邮箱数据库未定义！";
                    return message;
                }
                var alias = "";
                //电子邮件
                if (userEntry.Properties.Contains ("mail")) {
                    //
                    var email = userEntry.Properties["mail"][0].ToString ();
                    if (email.Contains ("@")) {
                        alias = email.Substring (0, email.IndexOf ("@", StringComparison.Ordinal));
                    } else {
                        alias = userEntry.Properties["givenName"][0].ToString ();
                    }
                } else {
                    var temp = identity.Substring (identity.LastIndexOf ("/") + 1);
                    alias = temp.Substring (0, temp.IndexOf ("."));
                }
                // 生成一个连接类型，传入exchange服务器IP、将要使用的Scheme以及管理员凭据
                var connectionInfo = ExchangeScriptInit ();
                // 创建一个命令空间，创建管线通道，传入要运行的powershell命令，执行命令
                using (var rs = RunspaceFactory.CreateRunspace (connectionInfo)) {
                    var psh = PowerShell.Create ();
                    psh.Runspace = rs;
                    rs.Open ();
                    var sScript = "Enable-Mailbox -identity  '" + identity + "' -Alias '" + alias + "' -Database '" +
                        dataBase + "'";
                    psh.Commands.AddScript (sScript);
                    var sScript2 = "update-AddressList -identity '" + identityName + "'";
                    psh.Commands.AddScript (sScript2);
                    var psresults = psh.Invoke ();
                    if (psresults == null) {
                        message = "邮件开启失败！";
                    }
                    if (psh.Streams.Error.Count > 0) {
                        var strbmessage = new StringBuilder ();
                        foreach (var err in psh.Streams.Error) {
                            strbmessage.AppendLine (err.ToString ());
                            Console.WriteLine (err);
                        }
                        message = strbmessage.ToString ();
                        message = "邮件开启失败！" + message;
                    } else {
                        message = "邮件开启成功！";
                    }
                    rs.Close ();
                    psh.Runspace.Close ();
                }
                #endregion
                return "";
            } catch (Exception ex) {
                return "操作失败";
            }
        }
        #endregion
        #region 将DirectoryEntry的path属性更改为identity需要的字符串
        public static string ModifyPathToIdentity (string path) {
            string identity = String.Empty;
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
        #endregion
        #region OuName->DirectoryEntry
        public static DirectoryEntry GetOuDirectoryEtnryByName (string ouName) {
            DirectoryEntry _root = new DirectoryEntry ();
            _root.Path = "LDAP://" + "10.10.2.11";
            _root.Username = "test.com" + "\\" + "administrator";
            _root.Password = "P@ssw0rd";
            try {
                DirectorySearcher deSearch = new DirectorySearcher (_root);
                deSearch.Filter = "(&(objectClass=organizationalUnit)(name=" + ouName + "))";
                DirectoryEntry ouEntry = deSearch.FindOne ().GetDirectoryEntry ();
                return ouEntry;
            } catch {
                return null;
            }
        }
        #endregion
        #region number->DirectoryEntry
        public static DirectoryEntry GetDirectoryEntryByAdNumber (string number) {
            try {
                DirectoryEntry _root = new DirectoryEntry ();
                _root.Path = "LDAP://" + "10.10.2.11";
                _root.Username = "test.com" + "\\" + "administrator";
                _root.Password = "P@ssw0rd";
                DirectorySearcher search = new DirectorySearcher (_root);
                search.Filter = "(&(givenName=" + number + ")(objectClass=person))";
                search.PropertiesToLoad.Add ("cn");
                DirectoryEntry user = search.FindOne ().GetDirectoryEntry ();
                return user;
            } catch {
                return null;
            }
        }
        #endregion
    }

}