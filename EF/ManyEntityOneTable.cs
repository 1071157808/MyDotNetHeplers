[Table ("People")]
public class Person {
    [Key, ForeignKey ("Photo")]
    public int PersonId { get; set; }
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public PersonPhoto Photo { get; set; }
}

[Table ("People")]
public class PersonPhoto {
    [Key, ForeignKey ("PhotoOf")]
    public int PersonId { get; set; }
    public byte[] Photo { get; set; }
    public string Caption { get; set; }
    public Person PhotoOf { get; set; }
}

[Table ("People")]
public class Person

[Table ("People")]
public class PersonPhoto