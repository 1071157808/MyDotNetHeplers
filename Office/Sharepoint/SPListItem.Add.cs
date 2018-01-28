SPWeb site = SPControl.GetContextWeb (Context);
SPListItemCollection items = site.Lists["ListName"].Items;
SPListItem item = items.Add ();
item["Field_1"] = OneValue;
item["Field_2"] = TwoValue;
item.Update ();