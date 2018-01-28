using (SPSite site = new SPSite (SPContext.Current.Site.Url)) {
    using (SPWeb web = site.OpenWeb ()) {
        SPList list = web.Lists["MyListName"];
        web.AllowUnsafeUpdates = true;
        SPListItem item = list.Items.Add ();
        item["Title"] = "Hello";
        item.Update ();
        web.AllowUnsafeUpdates = false;
    }
}