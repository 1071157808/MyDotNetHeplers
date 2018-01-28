// Apply the new content type to the list.
list.ContentTypesEnabled = true;
if (list.IsContentTypeAllowed (ct)) {
    // Add the new content type.
    SPContentType lstCT = list.ContentTypes.Add (ct);
    // Remove the default content type.
    list.ContentTypes[0].Delete ();
    // Commit changes to the list.
    list.Update ();
    Console.WriteLine ("Applied {0} content type to {1} list.",
        lstCT.Name, list.Title);
} else {
    Console.WriteLine ("{0} list does not allow {1} content type.",
        list.Title, ct.Name);
}