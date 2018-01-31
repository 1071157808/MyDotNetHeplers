Has方法：
HasOptional：前者包含后者一个实例或者为null
HasRequired：前者(A)包含后者(B)一个不为null的实例
HasMany：前者包含后者实例的集合
With方法：
WithOptional：后者(B)可以包含前者(A)一个实例或者null
WithRequired：后者包含前者一个不为null的实例
WithMany：后者包含前者实例的集合



modelBuilder.Entity<BlogSite>().HasMany(b => b.BlogPosts).WithRequired(p => p.BlogSite);