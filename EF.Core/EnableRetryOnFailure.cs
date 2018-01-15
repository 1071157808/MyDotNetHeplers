Connection resiliency
所谓的连接弹性则是执行数据库命令失败时我们可以重试，我们可以在OnConfiguring或者Startup.cs中设置，如下：
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(
            "connection string",
            options => options.EnableRetryOnFailure());
}
