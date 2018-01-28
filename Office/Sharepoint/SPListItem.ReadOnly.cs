using (SPSite oSiteCollection = new SPSite ("http://MyServer";)) {
    using (SPWeb oWebsite = oSiteCollection.OpenWeb ()) {
        SPList oList = oWebsite.Lists["MyList"];
        SPListItem oItem = oList.Items[0];
        oItem.Fields["MyField"].ReadOnlyField = true;
        oItem.Fields["MyField"].Update ();
    }
}