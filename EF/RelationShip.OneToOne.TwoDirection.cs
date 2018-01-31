public virtual DbSet<Person> Persons { get; set; }
public virtual DbSet<Man> Mans { get; set; }
protected override void OnModelCreating (DbModelBuilder modelBuilder) {
    //双向one to one
    //man的id不能是identity的
    modelBuilder.Entity<Man> ()
        .HasRequired (a => a.Person)
        .WithOptional (a => a.Man)
        .WillCascadeOnDelete (true);
}

[Table ("Man")]
public class Man {
    [Key]
    public int ManId { get; set; }
    public string Name { get; set; }
    public virtual Person Person { get; set; }
}

[Table ("Person")]
public class Person {
    [Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
    public int PersonId { get; set; }
    public string Name { get; set; }
    public virtual Man Man { get; set; }
}
static void Main (string[] args) {
    var model = new Model1 ();
    Person p = new Person { Name = "tt" };
    Man m = new Man { Name = "spikett" };
    p.Man = m;
    model.Persons.Add (p);
    var i = model.SaveChanges ();
    if (i > 0) {
        Console.WriteLine ("输出成功");
    } else {
        Console.WriteLine ("输出失败");
    }
}
//修改直接赋值也是可以的
static void Main (string[] args) {
    var model = new Model1 ();
    var p = model.Persons.FirstOrDefault (a => a.Name == "ss");
    Man m = new Man { Name = "ddd" };
    p.Man = m;
    var i = model.SaveChanges ();
    if (i > 0) {
        Console.WriteLine ("输出成功");
    } else {
        Console.WriteLine ("输出失败");
    }
}

//-----------Simple demo----------------
//Attribute方式
   public class User
  {     
    public int UserId { get; set; }     
    public string Name { get; set; }     
    public int BillingAddressId { get; set; }    
    public int DeliveryAddressId { get; set; }     

    [ForeignKey("BillingAddressId")]     
    public Address BillingAddress { get; set; }     

    [ForeignKey("DeliveryAddressId")]     
    public Address DeliveryAddress { get; set; }
  }
  //Fluent api 方式
    modelBuilder
     .Entity<Post>()
     .HasRequired(a => a.Blog)
     .WithOptional(a => a.Post)
     .WillCascadeOnDelete(true);   //级联删除的意思  //或者使用[required]属性加在外键表上
     //注意Post的Key不能是自增长的

