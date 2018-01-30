var city = "London"; 
var contactTitle = "Sales Representative"; 
using (var context = CreateContext()) {
    context.Set < Customer > ()
        .FromSql($@"
            SELECT *
            FROM ""Customers""
            WHERE ""City"" = {city} AND
                ""ContactTitle"" = {contactTitle}")
            .ToArray(); 

}