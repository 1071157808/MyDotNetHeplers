private List<Reference> ConvertToReferenceList (SPListItemCollection collection) {
    var result = new List<Reference> ();
    foreach (SPListItem item in collection) {
        var name = item["ReferenceName"].ToString ();
        var link = item["ReferenceLink"].ToString ();
        result.Add (new Reference { Name = name, Link = link });
    }
    return result;
}