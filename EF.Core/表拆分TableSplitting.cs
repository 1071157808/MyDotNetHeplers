modelBuilder.Entity<Product>()
    .HasOne(e => e.Details).WithOne(e => e.Product)
    .HasForeignKey<ProductDetails>(e => e.Id);
modelBuilder.Entity<Product>().ToTable("Products");
modelBuilder.Entity<ProductDetails>().ToTable("Products");

//现在可以将两个或多个实体类型映射到同一表，
//其中主键列将被共享，每一行对应两个或多个实体。
//要使用表拆分，
//必须在共享表的所有实体类型之间配置标识关系（外键属性构成主键）