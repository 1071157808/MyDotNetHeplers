public class PersonInfo {
    [Key]
    public int PersonId { get; set; }
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public byte[] Photo { get; set; }
    public string Caption { get; set; }
}

modelBuilder.Entity<PersonInfo> ().Map (m => {
    m.ToTable ("A");
    m.Properties (p => p.FirstName);
    m.Properties (p => p.LastName);
    m.Properties (p => p.RowVersion);
    m.Properties (p => p.SocialSecurityNumber);
}).Map (m => {
    m.ToTable ("B");
    m.Properties (p => p.Photo);
    m.Properties (p => p.Caption);
});


