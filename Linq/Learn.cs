//Linq的数据源
// 必须可枚举的，即必须是数组或者集合
// （继承了IEnumerable<T>接口就可以，注意是IEnumerable<T>，不是IEnumerable接口，不一样，继承后者只能使用foreach，不能使用linq）
var query = this._customerList.Where(c => c.City == "台北";
custom = c, Index = this._customerList.IndexOf(c) });
// from 指定数据源和范围变量
// where 根据布尔表达式(由逻辑与 或 等组成)从数据源中筛选元素
// select 指定查询结果中的元素所具有的类型或表现形式
// group 对对查询结果按照键值进行分组
// into 提供一个标示符，它可以充当对 join group 或 select 子句结果的引用
// orderby 对查询出的元素进行排序
// join 按照两个指定匹配条件来联接俩个数据源
// let 产生一个用于查询表达式中子表达式查询结果的范围变量

// Distinct - 过滤集合中的相同项；延迟
// Union - 连接不同集合，自动过滤相同项；延迟
// Concat - 连接不同集合，不会自动过滤相同项；延迟
// Intersect - 获取不同集合的相同项（交集）；延迟
// Except - 从某集合中删除其与另一个集合中相同的项；延迟
// Skip - 跳过集合的前n个元素；延迟
// Take - 获取集合的前n个元素；延迟0怕、
// SkipWhile - 直到某一条件成立就停止跳过；延迟
// TakeWhile - 直到某一条件成立就停止获取；延迟
// Single - 根据表达式返回集合中的某一元素；不延迟
// SingleOrDefault - 根据表达式返回集合中的某一元素（如果没有则返回默认值）；不延迟
// Reverse - 对集合反向排序；延迟
// SelectMany - Select选择（一对多）；延迟

