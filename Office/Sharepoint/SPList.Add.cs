// Name, type, and description of list to create.
private static string lstName = "Customers";
private static SPListTemplateType lstType = SPListTemplateType.Contacts;
private static string lstDesc = "A list of customers.";
// Create a list.
SPListCollection lists = web.Lists;
Guid listID = lists.Add (lstName, lstDesc, lstType);
SPList list = lists[listID];
list.OnQuickLaunch = true;
list.Update ();
Console.WriteLine ("Created {0} list.", list.Title);