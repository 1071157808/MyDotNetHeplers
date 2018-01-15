public static DirectoryEntry GetDirectoryEntry(string serverIp, string domain, string userName, string pwd)
{
    DirectoryEntry de = new DirectoryEntry();
    de.Path = "LDAP://" + serverIp;
    de.Username = domain + "\\" + userName;
    de.Password = pwd;
    //eg:
    //de.Path = "LDAP://test.com/CN=Users;DC=Yourdomain";
    //de.Username = @"test\0202";
    //de.Password = "123456";
    return de;
}
