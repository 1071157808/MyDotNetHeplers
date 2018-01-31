  public class Address {
      public int Id { get; set; }
      public string StreetName { get; set; }
      public int PersonId { get; set; }
      public virtual Person Person { get; set; }
  }
  public class PeopleContext : DbContext {
      public IDbSet<Person> Persons { get; set; }
      public IDbSet<Address> Addresses { get; set; }
      protected override void OnModelCreating (DbModelBuilder modelBuilder) {
          // one to many Person - Address
          modelBuilder.Entity<Person> ()
              .HasOptional (x => x.Address).WithMany ()
              .HasForeignKey (x => x.AddressId);
          // one to many Address - Person
          modelBuilder.Entity<Address> ()
              .HasRequired (x => x.Person).WithMany ()
              .HasForeignKey (x => x.PersonId);
      }
  }
  //不是一个程序，下面的程序是我写的
  var model = new Model1 ();
  Man man = new Man {
      Name = "spike"
  };
  Person p = new Person { Name = "ss" };
  model.Persons.Add (p);
  man.Person = p;
  model.Mans.Add (man);
  var i = model.SaveChanges ();
  if (i > 0) {
      Console.WriteLine ("输出成功");
  } else {
      Console.WriteLine ("输出失败");
  }
  }



  //--------------------Simple demo---------------------
  modelBuilder.Entity<BlogSite>()
    .HasRequired(b => b.BlogUser)
    .WithMany()
    .HasForeignKey(b => b.UserID)
    .WillCascadeOnDelete(false);;
