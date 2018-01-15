// You can also get a LINQ query that represents the contents of a navigation property.
This allows you to do things such as running an aggregate operator over the related entities without loading them into memory

// 使用Query来计算导航属性的内容，这个允许你在不把关联对象加载到内存中，就可以对关联的实体做一些操作
using (var context = new BloggingContext ()) {
    var blog = context.Blogs
        .Single (b => b.BlogId == 1);
    var postCount = context.Entry (blog)
        .Collection (b => b.Posts)
        .Query ()
        .Count ();
}

using (var context = new BloggingContext ()) {
    var blog = context.Blogs
        .Single (b => b.BlogId == 1);
    var goodPosts = context.Entry (blog)
        .Collection (b => b.Posts)
        .Query ()
        .Where (p => p.Rating > 3)
        .ToList ();
}