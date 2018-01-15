初始化code first
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=AppDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Scaffold-DbContext "Server=2013-20150707DJ\SQL2012EXPRESS;Database=AppDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
