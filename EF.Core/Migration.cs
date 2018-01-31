//在终端中执行的命令
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations remove InitialCreate
dotnet ef database drop


//在nuget中执行的命令
//执行migration的命令
Add-Migration InitialCreate02
Update-Database
Remove-Migration
get-help entityframework


//dbfirst的命令
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer




//安装相关nuget包
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

//下面的这个适用于asp.net core上
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design


//可以直接在migration中写sql语句
migrationBuilder.Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
// Default value for FK points to department created above, with
// defaultValue changed to 1 in following AddColumn statement.
migrationBuilder.AddColumn<int>(
    name: "DepartmentID",
    table: "Course",
    nullable: false,
    defaultValue: 1);
