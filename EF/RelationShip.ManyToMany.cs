modelBuilder.Entity<BlogPost> ()
    .HasMany (b => b.Categories)
    .WithMany (c => c.BlogPosts)
    .Map (
        m => {
            m.MapLeftKey ("BlogPostID");
            m.MapRightKey ("CategoryID");
            m.ToTable ("BlogPost_Category");
        }
    );