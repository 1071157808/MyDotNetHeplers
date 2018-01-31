publicclassSampleDBContext : DbContext {
    publicSampleDBContext () {
        Database.EnsureDeleted ();
        Database.EnsureCreated ();
    }
    protected override void OnConfiguring (DbContextOptionsBuilder optionbuilder) {
        var sqlConnectionStringBuilder = new SqlConnectionStringBuilder {
            DataSource = "****",
            InitialCatalog = "EFSampleDB",
            UserID = "sa", Password = "***"
        };
        optionsBuilder.UseSqlServer (sqlConnectionStringBuilder.ConnectionString);
    }
    protected override void OnModelCreating (ModelBuilder modelbuilder) {
        modelbuilder.ForSqlServerUseSequenceHiLo ("DBSequenceHiLo");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}


	* 在SampleDBContext构造函数初始化数据库，类型于EF 6中的DropCreateDatabaseAlways；
	* OnConfiguring() 方法用于配置数据库链接字符串；
	* OnModelCreating方法用于定义实体模型。要定义HiLo序列，请使用ForSqlServerUseSequenceHiLo扩展方法。您需要提供序列的名称。

----------------sqlserver和oracle都支持这个功能
CreateSequence [dbo].[Sequence_Test] As [BigInt]         
--整数类型StartWith1        
--起始值IncrementBy1      
--增量值MinValue1         
--最小值MaxValue9999999   
--最大值Cycle              
--达到最值循环 [ CYCLE | NO CYCLE ]Cache  5;          
--每次取出5个值缓存使用 [ CACHE [<常量>] | NO CACHE ]


	* 序列用于生成数据库范围的序列号；
	* 序列不与一个表相关联，您可以将其与多个表相关联；
	* 它可以用于插入语句来插入标识值，也可以在T-SQL脚本中使用。


