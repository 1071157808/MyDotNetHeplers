private static string fldName = "LastOrder";
private static SPFieldType fldType = SPFieldType.DateTime;
// Create a site field to link to.
SPFieldCollection fields = web.Fields;
fldName = fields.Add (fldName, fldType, false);
Console.WriteLine ("Created {0} site column.", fldName);
// Link the content type to the field.
SPField field = fields.GetField (fldName);
SPFieldLink fieldLink = new SPFieldLink (field);
ct.FieldLinks.Add (fieldLink);
Console.WriteLine (
    "Linked {0} content type to {1} column.",
    ct.Name, field.InternalName);
// Commit changes to the database.
ct.Update ();