public class BloggingContext : DbContext

{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public int TenantId {get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //模型级过滤器将使用正确的上下文实例中的值，即执行查询的那个
        //使用  IgnoreQueryFilters() 方法在一次查询中禁用过滤器
        //过滤器不允许使用导航属性进行过滤
        modelBuilder.Entity<Post>().HasQueryFilter(
            p => !p.IsDeleted
            && p.TenantId == this.TenantId );
    }
}