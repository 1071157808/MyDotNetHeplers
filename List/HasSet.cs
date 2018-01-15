int[] ii = { 1, 1, 7, 4, 3, 2, 1, 3, 2, 3, 4, 5, 6, 7, 7, 8, 45, 1 };
HashSet<int> set = newHashSet<int> ();
foreach (var item in ii) {
    set.Add (item);
}
Console.WriteLine (set.Count ()); // 统计出不重复的数字有多少个
foreach (var item inset) {
    Console.Write (" " + item);
}
SortedSet<int> sort_set = newSortedSet<int> (); // 这个自动在内部排序，输出是从小到大的排列
foreach (var item in ii) {
    sort_set.Add (item);
}
foreach (var item in sort_set) {
    Console.Write (" " + item);
}
Console.ReadKey ();