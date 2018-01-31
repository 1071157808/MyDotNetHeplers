https: //blogs.msdn.microsoft.com/alexj/2009/01/11/savechangesfalse/

    建议不要将windows的transcation和ef混用的文章
https: //coderwall.com/p/jnniww/why-you-shouldn-t-use-entity-framework-with-transactions

这篇文章的大概意思就是： 在transcationScope中的ef会放弃本身的事务，
将操作每个操作变成原子性的， 都会对数据库的表格进行占用， 造成死锁， 这将导致DB的读取效率问题，
而EF本身每一个saveChanges () 都是一个事务操作， 是一个原子性操作， 这个要比transcationScope对数据库的影响小



这个transcation的rollback是对ExecuteSqlCommand手写sql进行回滚的，
因为ExecuteSqlCommand会每条语句单独执行，
不会像LINQ语句进行事务的包裹， 如果普通的linq语句，
就没必要用ef的transcation， 因为已经默认包含了

using (var context = new BloggingContext ()) {
    using (var dbContextTransaction = context.Database.BeginTransaction ()) {
        try {
            context.Database.ExecuteSqlCommand (
                @"UPDATE Blogs SET Rating = 5" +
                " WHERE Name LIKE '%Entity Framework%'"
            );

            var query = context.Posts.Where (p => p.Blog.Rating >= 5);
            foreach (var post in query) {
                post.Title += "[Cool Blog]";
            }

            context.SaveChanges ();

            dbContextTransaction.Commit ();
        } catch (Exception) {
            dbContextTransaction.Rollback (); //Required according to MSDN article 
            throw; //Not in MSDN article, but recommended so the exception still bubbles up
        }
    }
}