modelBuilder.Entity<Employee>()
    .Property(b => b.LastPayRaise)
    .ValueGeneratedOnAddOrUpdate();

modelBuilder.Entity<Employee>()
    .Property(b => b.LastPayRaise)
    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;