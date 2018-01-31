protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
{
    string sConnString =
     @"Server=localhost;Database=EFSampleDB;Trusted_Connection=true;";
    optionbuilder.UseSqlServer(
        sConnString , b => b.MaxBatchSize(1) 
         //MaxBatchSize(1)  设置同时处理的个数，如果是1，就是禁止批处理了
    );
}
