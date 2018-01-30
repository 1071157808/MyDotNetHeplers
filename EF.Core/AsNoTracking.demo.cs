var student = await _context.Students
        .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
        .AsNoTracking()
        .SingleOrDefaultAsync(m => m.ID == id);


Include 和 ThenInclude 两个方法
会让Context去额外加载Student的导航属性Enrollments，
和Enrollments的导航属性Course



加不加AsNoTracking，生成的sql是一模一样的，但是执行时间却是4.8倍。
原因仅仅只是第一条EF语句多加了一个AsNoTracking。

注意：
AsNoTracking干什么的呢？无跟踪查询而已，也就是说查询出来的对象不能直接做修改。
所以，我们在做数据集合查询显示，而又不需要对集合修改并更新到数据库的时候，
一定不要忘记加上AsNoTracking。
如果查询过程做了select映射就不需要加AsNoTracking。
如：
    db.Students.Where(t=>t.Name.Contains("张三"))
        .select(t=>new (t.Name,t.Age)).ToList()
