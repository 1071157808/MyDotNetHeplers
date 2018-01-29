桌面新建文件，后缀名改为UDL，然后配置好后改回txt，再把
txt中的连接字符串配置到web.config中

常用配置连接字符串
(localdb)\v11.0
(localdb)\MSSQLLocalDB 


//Mysql

<system.data>
<DbProviderFactories>
<remove invariant="MySql.Data.MySqlClient"/>
<add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL"
type="MySql.Data.MySqlClient.MySqlClientFactory,MySql.Data"/>
</DbProviderFactories>
</system.data>
<connectionStrings>
<add name="ConnectionStringName" connectionString="Datasource=hostname;Database=schema_name;uid=username;pwd=Pa$$w0rd;"
providerName="MySql.Data.MySqlClient"/>
</connectionStrings>


// Sqlserver
<connectionStrings>
<add name="ConnectionStringName"
connectionString="Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xx;Password=xxx;Connect Timeout=120;"
providerName="System.Data.SqlClient" />
</connectionStrings>


<connectionString="…… data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|data.mdf;User Instance=true">


这里有一个DataDirectory的宏，他表示什么意义呢？ DataDirectory 是表示数据库路径的替换字符串。由于无需对完整路径进行硬编码，DataDirectory 简化了项目的共享和应用程序的部署。例如，无需使用以下连接字符串： "Data Source= c:\program files\MyApp\app_data\Mydb.mdf" 通过使用 |DataDirectory|（包含在如下所示的竖线中），即可具有以下连接字符串： "Data Source = |DataDirectory|\Mydb.mdf" 不仅仅是Sql server 2005 express中使用，也可以在其他的文件数据库中使用，例如Sqllite数据库文件的连接字符串：
通过该选项，DBA 无需将数据库文件附加到服务器即可使用它们。当连接字符串中包括 AttachDBFilename 关键字时，指定的文件被附加到 SQL Server 实例，并且客户端连接到新附加的数据库。AttachDBFilename 选项的参数是要附加的文件名。以下是一个示例。
   AttachDbFilename=|DataDirectory|\Database1.mdf;
|DataDirectory| 是打开连接的程序所在目录的快捷方式。要附加其他目录中的文件，必须提供该文件的完整路径。此例中的日志文件名为 Database1_log.ldf 并与数据库文件位于同一目录下。如果数据库文件已经附加到 SQL Server 实例，则向现有数据库打开该连接。

这是一个不错的选项，因为如果您是管理员，就可以通过在应用程序的连接字符串中指定文件名来附加并连接到一个数据库文件。许多开发人员在他们的系统上以管理员身份运行，因此，AttachDBFilename 可以为他们正常工作。问题在于，Microsoft 强烈建议“不要”以管理员身份运行，因为这样做可以减少病毒可能造成的危害数量。在这种情况下，我们需要的是一种方法，使得无需作为 Windows Administrators 组的成员就能使用 AttachDBFilename。解决方案是用户实例功能。


