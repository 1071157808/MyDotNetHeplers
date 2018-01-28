// 重置AD域用户的密码，设置AD用户头像和缩略图必须使用管理员权限才可以，普通用户的时候，系统会拒绝访问  
public bool ModifyAdUserAvatarJpegPhoto (DirectoryEntry userEntry, byte[] imgData) {
    try {
        string sAMAccountName = String.Empty;
        #region sAMAccountName
        if (userEntry.Properties.Contains ("sAMAccountName")) {
            sAMAccountName = userEntry.Properties["sAMAccountName"][0].ToString ();
            DirectorySearcher searcher = new DirectorySearcher (_root);
            searcher.Filter = "(sAMAccountName=" + sAMAccountName + ")";
            DirectoryEntry userNewEntry = searcher.FindOne ().GetDirectoryEntry ();
            userNewEntry.Properties["jpegPhoto"].Clear ();
            userNewEntry.Properties["jpegPhoto"].Add (imgData);
            userNewEntry.CommitChanges ();
            return true;
        } else {
            return false;
        }
        #endregion
    } catch (Exception ex) {
        return false;
    }
}