第一种方法
var blogs = context.Blogs
    .FromSql ("SELECT * FROM dbo.Blogs")
    .ToList ();
第二种方法
var blogs = context.Blogs
    .FromSql ("EXECUTE dbo.GetMostPopularBlogs")
    .ToList ();

第一种传参方法
var user = "johndoe";
var blogs = context.Blogs
    .FromSql ("EXECUTE dbo.GetMostPopularBlogsForUser {0}", user)
    .ToList ();
第二种传参方法
var user = "johndoe";
var blogs = context.Blogs
    .FromSql ($"EXECUTE dbo.GetMostPopularBlogsForUser {user}")
    .ToList ();
第三种传参方法
var user = new SqlParameter ("user", "johndoe");
var blogs = context.Blogs
    .FromSql ("EXECUTE dbo.GetMostPopularBlogsForUser @user", user)
    .ToList ();

结合普通的Linq
var searchTerm = ".NET";
var blogs = context.Blogs
    .FromSql ($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
    .Where (b => b.Rating > 3)
    .OrderByDescending (b => b.Rating)
    .ToList ();

Including related data
var searchTerm = ".NET";
var blogs = context.Blogs
    .FromSql ($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
    .Include (b => b.Posts)
    .ToList ();

Limitations
There are a couple of limitations to be aware of when using raw SQL queries:

    
SQL queries can only be used to
return entity types that are part of your model.There is an enhancement on our backlog to enable returning ad - hoc types from raw SQL queries.*The SQL query must
return data
for all properties of the entity type.*The column names in the result set must match the column names that properties are mapped to.Note this is different from EF6 where property / column mapping was ignored
for raw SQL queries and result set column names had to match the property names.*The SQL query cannot contain related data.However, in many cases you can compose on top of the query using the Include operator to
return related data (see Including related data).

1. 返回的类型必须和EF的类型对应
2. sql必须返回实体的所有属性
3. SQL的列的名称必须和实体的名称匹配
4. SQL查询不能包含关联数据， 要包含的话就使用Include