设置NoTracking的方法

using (var context = new BloggingContext ()) {
    var blogs = context.Blogs
        .AsNoTracking ()
        .ToList ();
}

using (var context = new BloggingContext ()) {
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    var blogs = context.Blogs.ToList ();
}

下面的代码因为包含了实体对象， 所以会继续tracking
using (var context = new BloggingContext ()) {
    var blog = context.Blogs
        .Select (b =>
            new {
                Blog = b,
                    Posts = b.Posts.Count ()
            });
}

下面的对象因为不包含实体对象， 所以是notracking
using (var context = new BloggingContext ()) {
    var blog = context.Blogs
        .Select (b =>
            new {
                Id = b.BlogId,
                    Url = b.Url
            });
}