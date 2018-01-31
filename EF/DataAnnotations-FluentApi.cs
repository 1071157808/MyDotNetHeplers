[Key]
public int DestinationId { get; set; }

modelBuilder.Entity<Destination> ().HasKey (d => d.DestinationId);

//-------------------------------------
[ForeignKey ("DestinationId")]
public Destination Destination { get; set; }

modelBuilder.Entity<Lodging> ()
    .HasRequired (p => p.Destination)
    .WithMany (p => p.Lodgings)
    .HasForeignKey (p => p.DestinationId);

//-------------------------------------------
[MinLength (10), MaxLength (30)]
public string Name { get; set; }

[StringLength (30)]
public string Country { get; set; }

modelBuilder.Entity<Destination> ().Property (p => p.Name).HasMaxLength (30);
modelBuilder.Entity<Destination> ().Property (p => p.Country).HasMaxLength (30);

//-----------------------------------------
[Required]
public string Country { get; set; }

[Required (ErrorMessage = "请输入描述")]
public string Description { get; set; }

modelBuilder.Entity<Destination> ().Property (p => p.Country).IsRequired ();

//--------------------------------------------
//将string映射成ntext，默认为nvarchar(max)
[Column (TypeName = "ntext")]
public string Owner { get; set; }

modelBuilder.Entity<Lodging> ().Property (p => p.Owner).HasColumnType ("ntext");

//-------------------------------------------
[Table ("MyLodging")]
public class Lodging {
    public int LodgingId { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public decimal Price { get; set; }
    public bool IsResort { get; set; }
    public Destination Destination { get; set; }

}

modelBuilder.Entity<Lodging> ().ToTable ("MyLodging");

//--------------------------------------------
[Column ("MyName")]
public string Name { get; set; }

modelBuilder.Entity<Lodging> ().Property (p => p.Name).HasColumnName ("MyName");

//---------------------------------------------

[Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
public Guid SocialId { get; set; }

modelBuilder.Entity<Person> ().Property (p => p.SocialId)
    .HasDatabaseGeneratedOption (DatabaseGeneratedOption.Identity);

//------------------------------------------------

[NotMapped]
public string Name {
    get {
        return FirstName + " " + LastName;
    }
}

modelBuilder.Entity<Person> ().Ignore (p => p.Name);

//---------------------------------------------
[NotMapped]
public class Person {
    [Key]
    public Guid SocialId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

modelBuilder.Ignore<Person> ();

//---------------------------------------------
[Timestamp]
public Byte[] TimeStamp { get; set; }

modelBuilder.Entity<Lodging> ().Property (p => p.TimeStamp).IsRowVersion ();

//-----------------------------------------------
[ComplexType]
public class Address {
    public string Country { get; set; }
    public string City { get; set; }
}

modelBuilder.ComplexType<Address> ();

//-----------------------------------------------