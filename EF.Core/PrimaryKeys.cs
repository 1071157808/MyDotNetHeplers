class MyContext : DbContext {
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.Entity<Blog> ()
            .HasKey (b => b.BlogId)
            .HasName ("PrimaryKey_BlogId");
    }
}
public class Blog {
    public int BlogId { get; set; }
    public string Url { get; set; }
}



 从0开始不自增长
[Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 

modelBuilder.Entity<Address>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);




也可以使用Sequence执行要开始的数值和增长间隔，这个需要利用SQL SERVER的特性

class MyContext : DbContext
{
public DbSet<Order> Orders { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
            .StartsAt(1000)
            .IncrementsBy(5);

//Once a sequence is introduced, you can use it to generate values for properties in your model. For example, you can use Default Values to insert the next value from the sequence.
modelBuilder.Entity<Order>()
            .Property(o => o.OrderNo)
            .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");
}
}
