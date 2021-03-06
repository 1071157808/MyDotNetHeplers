string joins = "<Join Type='LEFT' ListAlias='Systems'><Eq><FieldRef Name='System' RefType='Id' /><FieldRef List='Systems' Name='ID' /></Eq></Join>";
string projectedFields = "<Field Name='AppName' Type='Lookup' List='Systems' ShowField='AppName' /><Field Name='ShortName' Type='Lookup' List='Systems' ShowField='ShortName' />";
string viewfields = "<FieldRef name='ReferenceName' /><FieldRef name='ReferenceLink' /><FieldRef Name='AppName' /><FieldRef Name='ShortName' />";
string query = string.Format ("<Where><Eq><FieldRef Name='ShortName' /> <Value Type='Text'>{0}</Value></Eq></Where>", Application);
var spQuery = new SPQuery ();
spQuery.Joins = joins;
spQuery.Query = query;
spQuery.ViewFields = viewfields;
spQuery.ProjectedFields = projectedFields;
var items = sourceList.GetItems (spQuery);