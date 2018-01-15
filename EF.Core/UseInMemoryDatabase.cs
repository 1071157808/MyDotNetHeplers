public virtual void ApplyServices (IServiceCollection services) {
    Check.NotNull (services, nameof (services));

    services.AddEntityFrameworkInMemoryDatabase ();
}

public class TestStartup : Startup {
    public TestStartup (IHostingEnvironment env) : base (env) { }

    public override void ConfigureServices (IServiceCollection services) {
        services
            .AddEntityFrameworkInMemoryDatabase ()
            .AddDbContext<APIContext> ((sp, options) => {
                options.UseInMemoryDatabase ().UseInternalServiceProvider (sp);
            });
        base.ConfigureServices (services);
    }
}


// --------------------------------------------------
[TestMethod]
public void BlogTest(){
    var options = new DbContextOptionsBuilder()
        .UseInMemoryDatabase(databaseName:"BlogTest")
        .Options;
    using (var db = new BloggingContext(options))
    {
       db.Blogs.Add(new Blog(url = "aaa")) ;
       db.SaveChanges();
    }
}




