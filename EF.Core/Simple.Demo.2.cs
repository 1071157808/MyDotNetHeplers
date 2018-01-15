   using System.Collections.Generic;
   using System;
   using Microsoft.EntityFrameworkCore.Metadata;
   using Microsoft.EntityFrameworkCore;
   usingSystem.ComponentModel.DataAnnotations.Schema;
   namespace ConsoleApp35 {
       public class BloggingContext : DbContext {
           public DbSet<Blog> Blogs { get; set; }
           public DbSet<Post> Posts { get; set; }
           public DbSet<Order> Orders { get; set; }
           protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
               //sqlserver方式
               optionsBuilder.UseSqlServer (@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
               //sqlite方式
               optionsBuilder.UseSqlite ("Data Source=blogging.db");

           }
           protected override void OnModelCreating (ModelBuilder modelBuilder) {
               modelBuilder.Entity<Blog> (entity => {
                   entity.Property (e => e.Url).IsRequired ();
               });
               modelBuilder.Entity<Blog> ().HasKey (a => a.BlogId);
               modelBuilder.Entity<Blog> ()
                   .Property<string> ("Views")
                   .HasField ("_views")
                   .UsePropertyAccessMode (PropertyAccessMode.Field)
                   .Metadata
                   .BeforeSaveBehavior = PropertySaveBehavior.Save;
               modelBuilder.Entity<Blog> ()
                   .OwnsOne (c => c.PhysicalAddress);
               modelBuilder.Entity<Blog> ()
                   .OwnsOne (c => c.WorkAddress);
               //modelBuilder.Entity<Blog>().ForSqlServerIsMemoryOptimized();
               modelBuilder.HasSequence<int> ("OrderNumbers");

               modelBuilder.Entity<Post> ()
                   .HasOne (p => p.Blog)
                   .WithMany (b => b.Posts)
                   .HasForeignKey (p => p.BlogId)
                   .HasConstraintName ("ForeignKey_Post_Blog");

           }
       }
       public class Order {
           public int OrderId { get; set; }
           public int OrderNo { get; set; }
           public string Url { get; set; }
       }
       public class Blog {
           public int BlogId { get; set; }
           public string Url { get; set; }
           string _views;
           public string Content { get; set; }

           [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
           public DateTime Inserted { get; set; }

           [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
           public DateTime LastUpdated { get; set; }

           public ICollection<Post> Posts { get; set; }
           public Image Image { get; set; }
           public Address WorkAddress { get; set; }
           public Address PhysicalAddress { get; set; }
       }
       public class Address {
           public int Id { get; set; }
           public string Name { get; set; }
           public string Age { get; set; }
       }
       public class Post {
           public int PostId { get; set; }
           public string Title { get; set; }
           public int BlogId { get; set; }
           public Blog Blog { get; set; }
       }
       public class Image {
           public int ImageId { get; set; }
           public string Name { get; set; }
       }
   }