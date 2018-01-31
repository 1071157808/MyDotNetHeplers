//使用事务来处理代码，其中两个saveChanges会在一个事务中
using (var context = new BloggingContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet"; });
                    context.SaveChanges();
                    context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/visualstudio"; });
                    context.SaveChanges();
                    var blogs = context.Blogs
                        .OrderBy(b => b.Url)
                        .ToList();
                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // TODO: Handle failure
                }
            }
        }
