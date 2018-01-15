CompileQuery后的代码被加入了缓存中， 再次查询的时候访问的是cache中的内容， 所以速度会提升很多
官方的demo

// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/compiled-queries-linq-to-entities

static Func<AdventureWorksEntities, MyParams, IQueryable<SalesOrderHeader>> s_compiledQuery =
    CompiledQuery.Compile<AdventureWorksEntities, MyParams, IQueryable<SalesOrderHeader>> (
        (ctx, myparams) => from sale in ctx.SalesOrderHeaders where sale.ShipDate > myparams.startDate && sale.ShipDate < myparams.endDate &&
        sale.TotalDue > myparams.totalDue select sale);
static void CompiledQuery7 () {
    using (AdventureWorksEntities context = new AdventureWorksEntities ()) {
        MyParams myParams = new MyParams ();
        myParams.startDate = new DateTime (2003, 3, 3);
        myParams.endDate = new DateTime (2003, 3, 8);
        myParams.totalDue = 700.00M;
        IQueryable<SalesOrderHeader> sales = s_compiledQuery.Invoke (context, myParams);
        foreach (SalesOrderHeader sale in sales) {
            Console.WriteLine ("ID: {0}", sale.SalesOrderID);
            Console.WriteLine ("Ship date: {0}", sale.ShipDate);
            Console.WriteLine ("Total due: {0}", sale.TotalDue);
        }
    }
}

自定义查询方法

var query = EF.CompileQuery (
    (AdventureWorksContext db, string id) =>
    db.Customers.Single (c => c.AccountNumber == id)
);
using (var db = new AdventureWorksContext ()) {
    foreach (var id in accountNumbers) {
        var customer = query (db, id);
    }
}