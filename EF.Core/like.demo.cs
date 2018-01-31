//like支持通配符
var aCustomers =
    from c in context.Customers
    where EF.Functions.Like(c.Name, "a%");
    select c;


var result= 
    dataContext.Categories.Where(
        item => EF.Functions.Like(item.CategoryName, "%t%"))
        .ToList();