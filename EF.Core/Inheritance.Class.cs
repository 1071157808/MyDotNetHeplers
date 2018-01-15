class MyContext : DbContext {
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<RssBlog> RssBlogs { get; set; }
}
public class Blog {
    public int BlogId { get; set; }
    public string Url { get; set; }
}
public class RssBlog : Blog {
    public string RssUrl { get; set; }
}

class MyContext : DbContext {
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.Entity<RssBlog> ();
    }
}
继承类型
两个表都会具有同样的列