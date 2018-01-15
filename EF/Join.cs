
Entity Framework Join Demo两表不必含有外键关系， 需要代码手动指定连接外键相等（ 具有可拓展性， 除了值相等， 还能指定是 >, < 以及其他对两表的相应键的关系）， 以及结果字段
var query = db.Categories // source
    .Join (db.CategoryMaps, // target
        c => c.CategoryId, // FK
        cm => cm.ChildCategoryId, // PK
        (c, cm) => new { Category = c, CategoryMaps = cm }) // project result
    .Select (x => x.Category); // select result