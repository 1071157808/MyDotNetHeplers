public class Blog {
    [Column ("blog_id")]
    public int BlogId { get; set; }
    public string Url { get; set; }
}
// Flant api 定义方式
class MyContext : DbContext {
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.Entity<Blog> ()
            .Property (b => b.BlogId)
            .HasColumnName ("blog_id");
    }
}
public class Blog {
    public int BlogId { get; set; }
    public string Url { get; set; }
}