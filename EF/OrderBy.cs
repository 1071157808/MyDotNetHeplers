// OrderBy可以使用关联的实体
directories = modelDb
    .DirectoryEntities
    .OrderBy (a => a.SolidEntity.Name)
    .Skip (start)
    .Take (length)
    .ToList ();

// 也可以使用OrderBy来进行字段和顺序的组合，columName必须是字段的名称，sort要么是asc，要么是desc

directories = modelDb
    .DirectoryEntities
    .OrderBy (columName + " " + sort)
    .Skip (start)
    .Take (length)
    .ToList ();

// 可以使用稍微复杂一点的lambda表达式
directories = directoriestotalTemp
    .OrderBy (a => a.DrawEntities.Max (c => c.Version))
    .Skip (start)
    .Take (length)
    .ToList ();

// 在order中的语句可以复杂一些，但是在where中就不行（我记得是where中不可以嵌套使用lambda表达式的）
directories = directoriestotalTemp
    .OrderBy (a => a.DrawEntities.OrderByDescending (c => c.Version).FirstOrDefault ().VersionState)
    .Skip (start)
    .Take (length)
    .ToList ();

//也可以使用动态的字符串拼接来执行排序，但是要注意避免SQL 注入
using System.Linq.Dynamic
vehicles = vehicles.AsQueryable ().OrderBy ("Make ASC, Year DESC").ToList ();