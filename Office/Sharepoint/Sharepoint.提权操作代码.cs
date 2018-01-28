public string GetName () {
    string str = "";
    SPSecurity.RunWithElevatedPrivileges (delegate () {
        SPSite site = new SPSite ("http://win2012moss:6003";);
        SPWeb web = site.OpenWeb ();
        SPList list = web.Lists["用户通讯录"];
        SPQuery query = new SPQuery ();
        SPListItemCollection sic = list.GetItems (query);
        System.Data.DataTable dt = sic.GetDataTable ();
        if (dt.Rows.Count > 0) {
            str = dt.Rows[0]["UserName"].ToString ();
        } else {
            str = "wushuju";
        }
    });
    return str;
}