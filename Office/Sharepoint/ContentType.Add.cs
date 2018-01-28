// Create a new site content type.
SPContentTypeCollection cts = web.ContentTypes;
SPContentType ct = new SPContentType (cts[parentId], // parent
    cts, // collection
    ctName); // name
// Add the content type to the site collection.
cts.Add (ct);
Console.WriteLine (
    "Added {0} content type to site collection.", ct.Name);