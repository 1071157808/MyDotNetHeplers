var blogs = context.Blogs
    .OrderByDescending(blog => blog.Rating)
    .Select(blog => new
    {
        Id = blog.BlogId,
        Url = StandardizeUrl(blog.Url)
    })
    .ToList();


//这个StandardizeUrl函数在以前的ef中是无法执行的
public static string StandardizeUrl(string url)
{
    url = url.ToLower();
    if (!url.StartsWith("http://";))
    {
        url = string.Concat("http://";, url);
    }
    return url;
