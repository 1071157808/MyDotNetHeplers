private void RestrictDeleteOnLookupField (SPWeb web, string listUrl,
    Guid fieldGuid) {
    SPList list = web.GetList (GetListUrl (web.ServerRelativeUrl, listUrl));
    SPField field = list.Fields[fieldGuid];
    SPFieldLookup fieldLookup = (SPFieldLookup) field;
    fieldLookup.Indexed = true;
    fieldLookup.RelationshipDeleteBehavior = SPRelationshipDeleteBehavior.Restrict;
    fieldLookup.Update ();
}
public override void FeatureActivated (SPFeatureReceiverProperties properties) {
    try {
        ...
        //Restrict deletion of list items that would create a broken lookup
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.InventoryLocations,
            Constants.Fields.Guids.Part);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.Machines,
            Constants.Fields.Guids.Manufacturer);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.Machines,
            Constants.Fields.Guids.Category);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.MachineDepartments,
            Constants.Fields.Guids.Department);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.MachineDepartments,
            Constants.Fields.Guids.Machine);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.MachineParts,
            Constants.Fields.Guids.Machine);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.MachineParts,
            Constants.Fields.Guids.Part);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.PartSuppliers,
            Constants.Fields.Guids.Part);
        RestrictDeleteOnLookupField (rootWeb, Constants.ListUrls.PartSuppliers,
            Constants.Fields.Guids.Supplier);
        ...
    } catch (Exception e) { System.Diagnostics.Trace.WriteLine (e.ToString ()); }
}