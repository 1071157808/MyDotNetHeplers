
class MyContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property(b => b.Url)
            .HasField("_validatedUrl");
    }
}

public class Blog
{
    private string _validatedUrl;

    public int BlogId { get; set; }

    public string Url
    {
        get { return _validatedUrl; }
    }

    public void SetUrl(string url)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
        }

        _validatedUrl = url;
    }
}

modelBuilder.Entity<Blog>()
    .Property(b => b.Url)
    .HasField("_validatedUrl")
    .UsePropertyAccessMode(PropertyAccessMode.Field);

.Property(b => b.Url)        
这个意思就是有Url这个public字段，
可能会有get set方法，code first会尽可能的去使用set get方法

.HasField("_validatedUrl");
这个意思是有_validateUrl这个私有字段，这个_validate应该是一个约定名称
这个私有字段与Url绑定了，取值和设置值尽可能从url上取（我理解的）


就会使用字段来对属性进行处理。所以上面这种情况下（属性是影子属性），
代码的UsePropertyAccessMode(PropertyAccessMode.Field)其实不用写，
因为默认就是这种情形




