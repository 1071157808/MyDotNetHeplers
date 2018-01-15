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

