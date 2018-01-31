
//当没有精确值设置的时候，就会生成一个默认的值
modelBuilder.Entity<Employee>()
    .Property(b => b.EmploymentStarted)
    .HasDefaultValueSql("CONVERT(date, GETDATE())");


    
