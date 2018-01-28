// Basic example
public class Customer {
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Phones { get; set; }
    public bool IsActive { get; set; }
}

// Open database (or create if not exits)
using (var db = new LiteDatabase (@"MyData.db")) {
    // Get customer collection
    var customers = db.GetCollection<Customer> ("customers");

    // Create your new customer instance
    var customer = new Customer {
        Name = "John Doe",
        Phones = new string[] { "8000-0000", "9000-0000" },
        IsActive = true
    };

    // Insert new customer document (Id will be auto-incremented)
    customers.Insert (customer);

    // Update a document inside a collection
    customer.Name = "Joana Doe";

    customers.Update (customer);

    // Index document using a document property
    customers.EnsureIndex (x => x.Name);

    // Use Linq to query documents
    var results = customers.Find (x => x.Name.StartsWith ("Jo"));
}


//---------------------------------------------------------
// Store files
using(var db = new LiteDatabase("MyData.db"))
{
    // Upload a file from file system
    db.FileStore.Upload("/my/file-id", @"C:\Temp\picture1.jgn");
    
    // Upload a file from Stream
    db.FileStore.Upload("/my/file-id", myStream);
    
    // Open as an stream
    var stream = db.FileStore.OpenRead("/my/file-id");
    
    // Write to another stream
    stream.CopyTo(Response.Output);
    
}



//----------------------------------------------------------
// Custom entity mapping to BsonDocument
            
// Re-use mapper from global instance
var mapper = BsonMapper.Global;            

mapper.Entity<Customer>()
        .Key(x => x.CustomerKey)
        .Field(x => x.Name, "customer_name")
        .Ignore(x => x.Age);
            
using(var db = new LiteDatabase(@"MyData.db"))
{
    var doc = mapper.ToDocument(new Customer { ... });
    var json = JsonSerializer.Serialize(doc, true);
    
    /* json:
    {
        "_id": 1,
        "customer_name": "John Doe"
    }
    */
}





//----------------------------------------------------
// In memory database
var mem = new MemoryStream();

using(var db = new LiteDatabase(mem))
{
    ...
}

// Get database as binary array
var bytes = mem.ToArray();

// LiteDB support any Stream read/write as input
// You can implement your own IDiskService to persist data



//------------------------------------------------
// DbRef to cross references
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

// DbRef to cross references
public class Order
{
    public ObjectId Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public List Products { get; set; }
}       

// Re-use mapper from global instance
var mapper = BsonMapper.Global;

// Produts and Customer are other collections (not embedded document)
// you can use [BsonRef("colname")] attribute
mapper.Entity<Order>()
    .DbRef(x => x.Products, "products")
    .DbRef(x => x.Customer, "customers");
            
using(var db = new LiteDatabase(@"MyData.db"))
{
    var customers = db.GetCollection("customers");
    var products = db.GetCollection("products");
    var orders = db.GetCollection("orders");

    // create examples
    var john = new Customer { Name = "John Doe" };
    var tv = new Product { Description = "TV Sony 44\"", Price = 799 };
    var iphone = new Product { Description = "iPhone X", Price = 999 };
    var order1 = new Order { OrderDate = new DateTime(2017, 1, 1), Customer = john, Products = new List() { iphone, tv } };
    var order2 = new Order { OrderDate = new DateTime(2017, 10, 1), Customer = john, Products = new List() { iphone } };

    // insert into collections
    customers.Insert(john);
    products.Insert(new Product[] { tv, iphone });
    orders.Insert(new Order[] { order1, order2 });

    // create index in OrderDate
    orders.EnsureIndex(x => x.OrderDate);

    // When query Order, includes references
    var query = orders
        .Include(x => x.Customer)
        .Include(x => x.Products)
        .Find(x => x.OrderDate == new DateTime(2017, 1, 1));

    // Each instance of Order will load Customer/Products references
    foreach(var c in query)
    {
        Console.WriteLine("#{0} - {1}", c.Id, c.Customer.Name);

        foreach(var p in c.Products)
        {
            Console.WriteLine(" > {0} - {1:c}", p.Description, p.Price);
        }
    }
}