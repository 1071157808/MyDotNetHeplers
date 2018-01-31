启用Migration功能
Enable-Migrations -EnableAutomaticMigrations   
Enable-Migrations -StartUpProjectName Portal


多个数据库的时候，要选中数据库的名称
Enable-Migrations -EnableAutomaticMigrations -ContextTypeName TenderProjectModel
Enable-migrations -ContextTypeName IdentityDb -MigrationsDirectory DAL\IdentityMigrations

//----------添加一个Migration--------------------
Add-Migration AddCity       //后面的名字是随便写的
多个数据库的时候
add-migration -ConfigurationTypeName SMSApp.DAL.IdentityMigrations.Configuration "InitialCreate"


//----------------Update migration---------------------
Update-Database -Verbose
多个数据库时候
update-database -ConfigurationTypeName SMSApp.DAL.IdentityMigrations.Configuration -verbose


版本回溯（也是修改表的数据结构，并不影响里面的数据，但是有些修改如果有数据就无法修改表结构成功）
Update-Database –TargetMigration:"201309201643300_AddCity"


生成数据库版本之间的Sql脚本
Update-Database -Script -SourceMigration:"201309201643300_AddCity" -TargetMigration:"201309201708043_ModifyCity"   

Update-Database -Script -SourceMigration: $InitialDatabase -TargetMigration: "201611070113553_InitialCreate"


执行Sql脚本
Update-Database -Script


不能随意删除Migration文件夹内的同步文件，
否则数据同步会失败。
在某次项目中多次进行Migration，
但是将第一次创建数据表的Miragtion文件删除了，总是update-database失败，找了好半天才发现原因在这里。
