//Below code update the list item Title with Title+ID whose Title is equal to mohit
using (SPSite _site = newSPSite (SPContext.Current.Site.Url)) {
    using (SPWeb _web = _site.OpenWeb ()) {
        SPListoList = _web.Lists["myTestList"];
        SPQuery _query = newSPQuery ();
        _query.Query = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>Mohit</Value></Eq></Where>";
        SPListItemCollection _itemCollection = oList.GetItems (_query);
        if (_itemCollection.Count > 0) {
            _web.AllowUnsafeUpdates = true;
            foreach (SPListItem Item in _itemCollection) {
                Item["Title"] = Item["Title"].ToString () + Item.ID.ToString ();
                Item.Update ();
            }
            _web.AllowUnsafeUpdates = false;
        }
    }
}