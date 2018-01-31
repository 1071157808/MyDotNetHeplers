显示加载
使用Entry方法， 对于集合使用Collection， 单个实体则使用Reference。
using (var context = new SchoolDBEntities ()) {
    //Disable Lazy loading
    context.Configuration.LazyLoadingEnabled = false;

    var student = (from s in context.Students where s.StudentName == "Bill"
        select s).FirstOrDefault<Student> ();
    context.Entry (student).Reference (s => s.Standard).Load ();
}

modelDb.Entry(某个entity).CurrentValues.SetValues(新的entity);