显式加载的方法
//这个和下面的db.Blogs好像没有区别
var blog = db.Set<Blog> ().Find (1);
//var blog = db.Blogs.Find(1);
//var list = blog.Posts;
//加载ICollection<>对象
db.Entry (blog).Collection (b => b.Posts).Load ();
//加载单个对象
db.Entry (blog).Reference (b => b.Image).Load ();