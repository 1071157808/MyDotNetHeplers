// By convention, sequences are not introduced in to the model.
// A sequence generates a sequential numeric values in the database.Sequences are not
// associated with a specific table.
// 
// SequenceNumber是SQL Server2012推出的一个新特性。 这个特性允许数据库级别的序列号在多表或多列之间共享。
// 对于某些场景会非常有用， 比如， 你需要在多个表之间公用一个流水号。
// SQL Server2012中的SequenceNumber尝试 - CareySon - 博客园

class MyContext : DbContext {
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.HasSequence<int> ("OrderNumbers");
    }
}
public class Order {
    public int OrderId { get; set; }
    public int OrderNo { get; set; }
    public string Url { get; set; }
}

class MyContext : DbContext {
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.HasSequence<int> ("OrderNumbers", schema: "shared")
            .StartsAt (1000)
            .IncrementsBy (5);
    }
}

class MyContext : DbContext {
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.HasSequence<int> ("OrderNumbers", schema: "shared")
            .StartsAt (1000)
            .IncrementsBy (5);
        modelBuilder.Entity<Order> ()
            .Property (o => o.OrderNo)
            .HasDefaultValueSql ("NEXT VALUE FOR shared.OrderNumbers");
    }
}
public class Order {
    public int OrderId { get; set; }
    public int OrderNo { get; set; }
    public string Url { get; set; }
}