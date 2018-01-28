public string AddNewItem () {
    stringretVal = string.Empty;
    try {
        SPSecurity.RunWithElevatedPrivileges (delegate () {
            using (SPSite site = newSPSite (SPContext.Current.Web.Url)) {
                using (SPWeb web = site.OpenWeb ()) {
                    SPList list = web.Lists["TEST"];
                    SPListItem item = list.Items.Add ();
                    item["Title"] = string.Format ("Test at {0}", DateTime.Now.ToString ());
                    //如果修改的不留痕迹，要使用SystemUpdate;
                    item.SystemUpdate ();
                }
            }
            retVal = "operation  success!";
        });
    } catch (Exception ex) {
        retVal += ex.Message;
    }
    returnretVal;
}