using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.DirectoryServices;

namespace DisneyMgr.Layouts.User
{
    public partial class CreateADUser : LayoutsPageBase
    {
        private string company;
        private string department;
        private string message;
        private string dc;
        private string _adminUserName = "spadmin";//AD用户名
        private string _pwd = "Sitrcadmin52524567";//AD密码
        private string _path = "LDAP://pm.com";//AD主机名
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void CreateUser(string displayName, string accountName, string pwd)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    if (!UserExists(accountName))
                    {
                        DirectoryEntry root = new DirectoryEntry(_path, _adminUserName, _pwd, AuthenticationTypes.Secure);
                        //using (var de = new DirectoryEntry())
                        //   {
                        //de.Path = "LDAP://FAST.Faserati/CN=Users,DC=pm,DC=com";
                        //de.Username = "Administrator";
                        //de.Password = "P@$$w0rd";
                        DirectoryEntry user = root.Children.Find("CN=Users").Children.Add("CN=" + displayName, "user");
                        user.Properties["samAccountName"].Add(accountName);
                        user.Properties["userPrincipalName"].Add(accountName + "@pm.com");
                        user.Properties["userPassword"].Add(pwd);
                        user.Properties["userAccountControl"].Add(66080);
                        user.Properties["sn"].Add(displayName);
                        user.Properties["displayname"].Add(displayName);
                        user.Properties["accountExpires"].Add("0");
                        user.CommitChanges();
                        SetPassword(accountName, pwd);
                        lbResult.Text = "*创建成功！";
                        lbResult.Visible = true;
                    }
                    else
                    {
                        lbResult.Text = "*该账号注册,请更换账户名称";
                        lbResult.Visible = true;
                    }
                });
           //}
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            CreateUser(tbName.Text, tbacount.Text, tbPassword.Text);
        }

        //#region 创建用户
        //public string CreateUser(string displayName, string accountName, string pwd)
        //{
        //    // string message = "";  

        //    string group = "";
        //    if (UserExists(accountName) == false)
        //    {
        //            DirectoryEntry    entry = new DirectoryEntry(_path, _adminUserName, _pwd, AuthenticationTypes.Secure);//.Children.Find(dn).Children.Find("OU=" + OuCompany);
        //             DirectoryEntry   entrygroup = new DirectoryEntry(_path, _adminUserName, _pwd, AuthenticationTypes.Secure);//.Children.Find("OU=xd-ad").Children.Find("OU=" + OuCompany);
                    
                

        //        try
        //        {
        //                DirectoryEntry user = entry.Children.Add("CN=" + accountName, "user");

        //                //域账号
        //                SetProperty(user, "sAMAccountName", accountName);

        //                SetProperty(user, "userPrincipalName", accountName + "@xd-ad.com.cn");

        //                #region 添加用户属性信息
        //                //密码永不过期

        //                //SetProperty(user, "userAccountControl", "66080");

        //                //姓名
        //                SetProperty(user, "sn", displayName);
        //                //显示名
        //                SetProperty(user, "displayname", displayName);

        //                user.CommitChanges();
        //                #endregion

        //                #region 给用户设置密码
        //                SetPassword(accountName, pwd);
        //                user.CommitChanges();
        //                #endregion

        //                    //账户永不过期
        //                    SetProperty(user, "accountExpires", "0");
        //                    user.CommitChanges();
                        
        //                #endregion

        //                #region 启动用户
        //                if (enabled == true)
        //                {
        //                    EnableAccount(user);
        //                }
        //                #endregion

        //                user.CommitChanges();
        //                entry.Close();
        //                message = "1";
                    
        //        }
        //        catch (Exception ex)
        //        {
        //            //entry.Children.Find("CN=" + cn).DeleteTree();
        //            message = ex.InnerException.Message;
        //        }
        //    }
        //    else
        //    {
        //        message = "0";
        //    }
        //    //return message;
        //    return message;
        //}
        //#endregion

        #region 判断用户是否存在
        public bool UserExists(string UserName)
        {
            DirectoryEntry entry = null;
            entry = new DirectoryEntry(_path, _adminUserName, _pwd, AuthenticationTypes.Secure);
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = entry;
            deSearch.Filter = "(&(objectClass=user) (sAMAccountName=" + UserName + "))";
            SearchResultCollection results = deSearch.FindAll();
            //不存在
            if (results.Count == 0)
            {
                return false;
            }
            //存在
            else
            {
                return true;
            }
        }

        #endregion

                #region 设置用户新密码
        public void SetPassword(string adname, string adpwd)
        {
            DirectoryEntry entry = null;
            //注意设置密码要用网域名：例如LDAP://xd-ad.com.cn",而不能用LDAP://IP(10.1.1.18)
            entry = new DirectoryEntry(_path, _adminUserName, _pwd, AuthenticationTypes.Secure);
            //DirectoryEntry ou = entry.Children.Find("OU=XD-AD");
            DirectorySearcher Dsearch = new DirectorySearcher(entry);
            try
            {
                // Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                Dsearch.Filter = "(SAMAccountName=" + adname + ")";
                Dsearch.PropertiesToLoad.Add("cn");
                SearchResult result = Dsearch.FindOne();
                if (result != null)
                {
                    DirectoryEntry dey = result.GetDirectoryEntry();
                    dey.Invoke("SetPassword", new object[] { "" + adpwd + "" });

                    dey.CommitChanges();
                    dey.Close();
                }
            }
            catch (Exception ex)
            {
                //Debug.Write(ex.Message);
                throw ex;
            }
            entry.Close();

        }
        #endregion
    }
}
