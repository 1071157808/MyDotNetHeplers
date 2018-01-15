[Table ("blogs", Schema = "blogging")]
public class Blog {
    public int BlogId { get; set; }
    public string Url { get; set; }
}
s

modelBuilder.Entity<Blog> ()
    .ToTable ("blogs", schema: "blogging");





schema是一个数据库的前缀，如果不设置，数据库会默认使用dbo
class MyContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blogging");
    }
}
