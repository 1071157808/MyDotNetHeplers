这个删除的写法比较好
db.Posts.Where (p => p.Title == "Caring for tropical fish" ||
        p.Title == "Cat care 101")
    .ToList ()
    .ForEach (p => db.Posts.Remove (p));