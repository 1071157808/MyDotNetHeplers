HashSet<T>在Framework3.5才新增的，而SortedSet<T>是Framework4.0新增的。两者都有下面的特性

	* 基于哈希的查询使得Contains执行非常快速
	* 两个集合都不存储重复的元素，如果试图添加重复元素会自动忽略
	* 不能通过位置（索引）获取元素

SortedSet<T>的元素是排过序的，而HashSet<T>的元素未排序。



