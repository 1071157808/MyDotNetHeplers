public class Person {
    public int PersonId { get; set; }
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}
//或者
modelBuilder.Entity<Person> ().Property (p => p.RowVersion).IsRowVersion ();

//仅对某个字段做并发控制
public class Person {
    public int PersonId { get; set; }

    [ConcurrencyCheck]
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] RowVersion { get; set; }
}

//或者
modelBuilder.Entity<Person>().Property(p => p.SocialSecurityNumber).IsConcurrencyToken();



