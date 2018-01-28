public bool ModifyAdUserAvatarThumbnailPhoto (DirectoryEntry userEntry, byte[] imgData) {
    try {
        string sAMAccountName = String.Empty;
        #region sAMAccountName
        if (userEntry.Properties.Contains ("sAMAccountName")) {
            sAMAccountName = userEntry.Properties["sAMAccountName"][0].ToString ();
            DirectorySearcher searcher = new DirectorySearcher (_root);
            searcher.Filter = "(sAMAccountName=" + sAMAccountName + ")";
            DirectoryEntry userNewEntry = searcher.FindOne ().GetDirectoryEntry ();
            userNewEntry.Properties["thumbnailPhoto"].Clear ();
            userNewEntry.Properties["thumbnailPhoto"].Add (imgData);
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