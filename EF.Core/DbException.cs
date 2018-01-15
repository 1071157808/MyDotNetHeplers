try {
    var blog = db.Blogs.Find (2);
    EntityEntry temp = db.Entry (blog);
    blog.Url = "www.google.com";
    var i = db.SaveChanges ();
    Console.WriteLine ("Hello World!");
} catch (DbUpdateConcurrencyException ex) {
    EntityEntry entityEntry = ex.Entries[0];
    //kept in DbChangeTracker
    PropertyValues originalVaules = entityEntry.OriginalValues;
    PropertyValues currentVaules = entityEntry.CurrentValues;
    var properties = entityEntry.Properties;
    //Needs to call to database to get values
    //需要获取数据库的数据
    PropertyValues databaseValues = entityEntry.GetDatabaseValues ();
    //Discards local changes , get database values , resets change tracker
    //丢弃本地修改，获取数据库的值，重设change tracker
    entityEntry.Reload ();
} catch (DbUpdateException ex) {
    //do something
}