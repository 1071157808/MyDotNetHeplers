public string AddNewItem () {
    stringretVal = string.Empty;
    try {
        SPSecurity.RunWithElevatedPrivileges (delegate () {
            using (SPSite site = newSPSite (SPContext.Current.Web.Url)) {
                using (SPWeb web = site.OpenWeb ()) {
                    SPList list = web.Lists["TEST"];
                    SPListItem item = list.Items.Add ();
                    item["Title"] = string.Format ("Test at {0}", DateTime.Now.ToString ());
                    item.Update ();
                }
            }
            retVal = "operation  success!";
        });
    } catch (Exception ex) {
        retVal += ex.Message;
    }
    returnretVal;
}