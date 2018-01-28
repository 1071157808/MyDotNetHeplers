/// <summary> 
/// 
/// </summary> 
/// <param name="ID"></param> 
/// <returns></returns> 
public SPListItemCollection GetSPListItemCollection (stringID) {
    SPListItemCollection itemCollection = newSPListItemCollection ();
    SPSecurity.RunWithElevatedPrivileges (
        delegate {
            using (SPSite spsite = newSPSite (this.CurrentUrl)) {
                using (SPWeb spWeb = spsite.OpenWeb ()) {
                    SPList listInstance = spWeb.Lists[this.ListName];
                    SPQuery query = newSPQuery ();
                    query.Query = "<Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + ID + "</Value></Eq></Where>";
                    itemCollection = listInstance.GetItems (query);
                }
            }
        }
    );
    returnitemCollection;
}