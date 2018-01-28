SPWeb web = new SPSite ("http://nick";).OpenWeb ("test"); //Open website
web.AllowUnsafeUpdates = true;
SPList list = web.Lists["ListName"];
SPQuery query = new SPQuery ();
query.Query = "<Where>" +
    "<And><And>" +
    "<Eq><FieldRef Name=\"Filed_1\"/><Value Type=\"Text\">Test</Value></Eq>" +
    "<Eq><FieldRef Name=\"Filed_2\"/><Value Type=\"Text\">" + (string) OneValue + "</Value></Eq>" +
    "</And>" +
    "<Eq><FieldRef Name=\"Filed_3\"/><Value Type=\"Text\">" + (string) TwoValue + "</Value></Eq>" +
    "</And>" +
    "</Where>";
query.RowLimit = 10;
//查询
SPListItemCollection items = list.GetItems (query);