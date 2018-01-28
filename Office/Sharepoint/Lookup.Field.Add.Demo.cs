using System;
using Microsoft.SharePoint;
namespace RelatedLists {
    class Program {
        static void Main (string[] args) {
            using (SPSite siteCollection = new SPSite ("http://localhost";)) {
                using (SPwebsite = siteCollection.OpenWeb ()) {
                    SPList lookupList = site.Lists.TryGetList ("Customers");
                    SPList relatedList = site.Lists.TryGetList ("Pending Orders");
                    if (lookupList != null && relatedList != null) {
                        string strPrimaryCol = relatedList.Fields.AddLookup ("Customer ID", lookupList.ID, true);
                        SPFieldLookup primaryCol = (SPFieldLookup) relatedList.Fields.GetFieldByInternalName (strPrimaryCol);
                        primaryCol.LookupField = lookupList.Fields["ID"].InternalName;
                        primaryCol.Indexed = true;
                        primaryCol.RelationshipDeleteBehavior = SPRelationshipDeleteBehavior.Restrict;
                        primaryCol.Update ();
                    }
                }
            }
            Console.Write ("\nPress ENTER to continue...");
            Console.ReadLine ();
        }
    }
}