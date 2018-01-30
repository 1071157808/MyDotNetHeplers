
//在OnModelCreating中可以对数据库的对象进行处理，
//然后这些处理后的对象才被传送到数据库那端，
//和EF6是不一样的，EF6不能做到这个

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
     {
     modelBuilder.Entity(entity.Name).ToTable("tbl_" + entity.ClrType.Name.ToLower());
     foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(200);
                }
                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.Relational().Name = fk.Relational().Name.ToLower();
                }
    }
}
