class MyContext:DbContext {
    public DbSet < Blog > Blogs {get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity < Blog > ()
            .HasIndex(b => b.Url); 
    }
}
public class Blog {
    public int BlogId {get; set; }
    public string Url {get; set; }
}

//设置索引的 唯一性
modelBuilder.Entity<Blog>()
            .HasIndex(b => b.Url)
            .IsUnique();


//设置多个索引
class MyContext : DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasIndex(p => new { p.FirstName, p.LastName });
    }
}
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

