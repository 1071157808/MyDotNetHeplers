public class CompanyAddress {
    public int ID { get; set; }
    public string CompanyName { get; set; }
    public Address Address { get; set; }
}

public class FamilyAddress {
    public int ID { get; set; }
    public Address Address { get; set; }
}

[ComplexType]
public class Address {
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}

//唯一的作用就是简洁代码