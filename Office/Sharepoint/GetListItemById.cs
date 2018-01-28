using (SPSite _site = newSPSite (SPContext.Current.Site.Url)) {
    using (SPWeb _web = _site.OpenWeb ()) {
        SPListolist = _web.Lists["myTestList"];
        SPListItem Item = olist.GetItemById (ItemID);
        Response.Write ("Item Title: " + Item["Title"].ToString ());
    }
}