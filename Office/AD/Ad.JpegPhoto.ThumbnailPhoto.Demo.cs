class Program {
    static void Main (string[] args) {
        //userRoot是用户登录后，才能使用的root
        DirectoryEntry userRoot = new DirectoryEntry ("LDAP://test.com", "administrator", "P@ssw0rd");
        DirectorySearcher searcher = new DirectorySearcher (userRoot);
        searcher.Filter = "(sAMAccountName=" + "man" + ")";
        DirectoryEntry userEntry = searcher.FindOne ().GetDirectoryEntry ();
        var thumbnailAbsolutePath = @"E:\code\01.ADMgr项目文件\03.开发文件\avatar.jpg";
        byte[] imgData = System.IO.File.ReadAllBytes (thumbnailAbsolutePath);
        userEntry.Properties["jpegPhoto"].Clear ();
        userEntry.Properties["jpegPhoto"].Add (imgData);
        userEntry.CommitChanges ();
        var thumbnailAbsolutePath2 = @"E:\code\01.ADMgr项目文件\03.开发文件\avatar75.jpg";
        byte[] imgData2 = System.IO.File.ReadAllBytes (thumbnailAbsolutePath2);
        userEntry.Properties["thumbnailPhoto"].Clear ();
        userEntry.Properties["thumbnailPhoto"].Add (imgData2);
        userEntry.CommitChanges ();
        userEntry.Dispose ();
        Console.ReadKey ();
    }
}