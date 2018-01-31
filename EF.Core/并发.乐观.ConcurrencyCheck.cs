public class Student
{
    public int StudentId { get; set; }

    [ConcurrencyCheck]
    public string RollNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}


//使用fluent api来定义
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>().Property(s => s.RollNumber).IsConcurrencyToken();
    base.OnModelCreating(modelBuilder);
}

