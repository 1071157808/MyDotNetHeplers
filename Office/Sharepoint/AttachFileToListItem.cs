using (SPSite _site = newSPSite (SPContext.Current.Site.Url)) {
    using (SPWeb _web = _site.OpenWeb ()) {
        //Let's suppose your Item Id is 1
        intItemId = 1;
        SPListoList = _web.Lists["myTestList"];
        SPListItem _item = oList.GetItemById (ItemId);
        if (FileUpload1.HasFile) {
            _web.AllowUnsafeUpdates = true;
            Stream fs = FileUpload1.PostedFile.InputStream;
            byte[] _bytes = new byte[fs.Length];
            fs.Position = 0;
            fs.Read (_bytes, 0, (int) fs.Length);
            fs.Close ();
            fs.Dispose ();
            _item.Attachments.Add (FileUpload1.PostedFile.FileName, _bytes);
            _item.Update ();
            _web.AllowUnsafeUpdates = false;
        }
    }
}