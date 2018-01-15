Model1 model = new Model1 ();
MyEntity e1 = new MyEntity {
    Name = "1"
};
MyEntity e2 = new MyEntity {
    Name = "2"
};
MyEntity e22 = new MyEntity {
    Name = "2"
};
MyEntity e3 = new MyEntity {
    Name = "3"
};
MyEntity e33 = new MyEntity {
    Name = "3"
};
model.MyEntities.Add (e1);
model.MyEntities.Add (e2);
model.MyEntities.Add (e22);
model.MyEntities.Add (e3);
model.MyEntities.Add (e33);
model.SaveChanges ();
var list = model.MyEntities.GroupBy (a => a.Name).Select (a => new { Key = a.Key, Count = a.Count () });
foreach (var item in list) {
    Console.WriteLine (item.Key + " " + item.Count);
}
Console.Read ();