public void DelItem (string listID, string itemID) {
    string siteCol = System.Configuration.ConfigurationManager.AppSettings["siteCol"];
    SPSecurity.RunWithElevatedPrivileges (delegate () //虚拟管理员，否则其他用户访问没有权限 
        {
            using (SPSite site = new SPSite (siteCol)) {
                using (SPWeb web = site.OpenWeb ("expense")) {
                    SPList list = web.Lists["EBRL"];
                    //允许修改list 
                    site.AllowUnsafeUpdates = true;
                    web.AllowUnsafeUpdates = true;
                    //填充list表单 
                    SPQuery query = new SPQuery ();
                    query.Query = string.Format (@"<Where><And><Eq><FieldRef Name='ListID' />                                           
                                                 <Value Type='Text'>{0}</Value> 
                                                 </Eq><Eq><FieldRef Name='ItemID' /> 
                                                 <Value Type='Text'>{1}</Value></Eq></And></Where>", listID, itemID);
                    SPListItemCollection items = list.GetItems (query);
                    //拒绝后删除记录 
                    items[0].Delete ();
                }
            }
        }
    );
}