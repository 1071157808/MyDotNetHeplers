public bool ResetPwdByNewPassword (DirectoryEntry userEntry, String originPassword, String newPassword) {
    var sAMAccountName = String.Empty;
    var result = false;
    try {
        if (userEntry.Properties.Contains ("sAMAccountName")) {
            sAMAccountName = userEntry.Properties["sAMAccountName"][0].ToString ();
            DirectoryEntry tempEntry = CheckLogin (sAMAccountName, originPassword);
            if (tempEntry != null) {
                //只能调用具有权限的管理员来更改用户密码
                DirectorySearcher searcher = new DirectorySearcher (_root);
                searcher.Filter = "(sAMAccountName=" + sAMAccountName + ")";
                DirectoryEntry userNewEntry = searcher.FindOne ().GetDirectoryEntry ();
                userNewEntry.Invoke ("SetPassword", new object[] { "" + newPassword + "" });
                userNewEntry.CommitChanges ();
                if (userNewEntry.Properties.Contains ("mobile")) {
                    var mobile = userNewEntry.Properties["mobile"][0].ToString ();
                    SendMsg (mobile, newPassword);
                }
                result = true;
            }
        }
    } catch (Exception ex) {
        result = false;
    }
    return result;
}