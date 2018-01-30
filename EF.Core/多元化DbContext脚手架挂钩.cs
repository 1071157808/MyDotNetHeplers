public class MyDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection services)
    {
        services.AddSingleton<IPluralizer, MyPluralizer>();
    }
}

public class MyPluralizer : IPluralizer
{
    public string Pluralize(string name)
    {
        return Inflector.Inflector.Pluralize(name) ?? name;
    }
    public string Singularize(string name)
    {
        return Inflector.Inflector.Singularize(name) ?? name;
    }
}

EF Core 2.0 introduces a new IPluralizer service that 
is used to singularize entity type names and pluralize DbSet names. 
The default implementation is a no-op, so this is just a hook
 where folks can easily plug in their own pluralizer.

Here is what it looks like for a developer to hook 
in their own pluralizer