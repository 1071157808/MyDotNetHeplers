//这个是老外写的，我没有做验证
//下面的两段代码因为post被加载到上下文中了，被跟踪了，所以会被删除
using (var context = new BloggingContext())
{
    var blog = context.Blogs.Include(b => b.Posts).First();
    context.Remove(blog);
    context.SaveChanges();
}

DELETE FROM [Post]
   WHERE [PostId] = @p0;
   DELETE FROM [Post]
   WHERE [PostId] = @p1;
   DELETE FROM [Blog]
   WHERE [BlogId] = @p2;


//---------------------------------------
//下面两端代码因为post没有被加载到上下文中，所以不会被删除
using (var context = new BloggingContext())
{
    var blog = context.Blogs.First();
    context.Remove(blog);
    context.SaveChanges();
}

DELETE FROM [Blog]
   WHERE [BlogId] = @p0;





